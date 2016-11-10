using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DataAccess;
using Library;
using System.Text.RegularExpressions;
using System.Data;
using System.Web.UI.HtmlControls;


namespace Web.user.shop
{
    public partial class Retail : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtUserCode.Value = LoginUser.UserCode;
                txtTrueName.Value = LoginUser.TrueName;
                txtBonusAccount.Value = LoginUser.ShopAccount.ToString();

                btnSubmit.Text = GetLanguage("Buy");//购买
            }
        }  

        private void BindData()
        {
            string strWhere = "";
            strWhere = " Goods003<>'1' and StateType=1";//报单产品
            bind_repeater(GetGoodsList(strWhere), rptProduct, " ID desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 验证代码
        /// </summary>
        /// <returns></returns>
        protected bool RegValidate()
        {
            string baodanID = Request["baodanID"];
            if (string.IsNullOrEmpty(baodanID) || baodanID.Trim() == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ChooseProducts") + "');", true);//请选择报单产品
                return false;
            }
            string[] baodanIDs = baodanID.Split(',');
            foreach (string id in baodanIDs)
            {
                string num = Request["num_" + id];
                if (string.IsNullOrEmpty(num) || num.Trim() == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ProductQuantity") + "');", true);//请选择报单产品
                    return false;
                }
                int n;
                if (int.TryParse(num, out n) == false)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NumberError") + "');", true);//数量格式错误
                    return false;
                }

            }
            //判断报单产品总金额是否等于等级要求fdsf
            lgk.Model.tb_user userInfo = userBLL.GetModel(LoginUser.UserID);

            List<lgk.Model.tb_goodsCar> listCar = new List<lgk.Model.tb_goodsCar>();//购物车集合
            decimal dMoney = 0;
            foreach (string id in baodanIDs)
            {
                int num = int.Parse(Request["num_" + id]);

               lgk.Model.tb_goods tb_goodsModel = goodsBLL.GetModel(int.Parse(id));//根据发布商品编号找到

                if (Convert.ToInt32(tb_goodsModel.Pic5) < num) //判断库存量
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("InventoryProblem") + "');", true);
                    return false;
                }

                dMoney += tb_goodsModel.Price * num;
                if (userInfo.BonusAccount < dMoney)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NotCurrent") + "');", true);
                    return false;
                }
            }

            return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RegValidate())
            {
                lgk.Model.tb_user userInfo = userBLL.GetModel(LoginUser.UserID);//取得当前用户


                lgk.Model.tb_Order orderInfo = new lgk.Model.tb_Order();//订单

                lgk.Model.tb_OrderDetail orderDetailModel = new lgk.Model.tb_OrderDetail();//订单详情

                lgk.Model.tb_goods goodsInfo = new lgk.Model.tb_goods();
                string baodanGoodsID = Request["baodanID"];

                #region
                DateTime time = DateTime.Now;
                List<lgk.Model.tb_goodsCar> listCar = new List<lgk.Model.tb_goodsCar>();//购物车集合

                string[] baodanIDs = baodanGoodsID.Split(',');
                foreach (string id in baodanIDs)
                {
                    goodsInfo = goodsBLL.GetModel(int.Parse(id));//根据发布商品编号找到
                    int num = int.Parse(Request["num_" + id]);
                    lgk.Model.tb_goodsCar goodsCar = new lgk.Model.tb_goodsCar();
                    goodsCar.GoodsID = int.Parse(id);
                    goodsCar.Goods006 = num;//数量
                    goodsCar.Price = goodsInfo.Price;
                    goodsCar.TotalMoney = goodsInfo.Price * num;
                    listCar.Add(goodsCar);

                }

                foreach (lgk.Model.tb_goodsCar car in listCar)
                { //寻坏商品
                    if (Convert.ToInt32(goodsInfo.Pic5) < car.Goods006) //判断库存量
                    {
                        MessageBox.Show(this, "" + GetLanguage("InventoryProblem") + "");//库存不足
                        return;
                    }
                }
                #region
                decimal dPVTotal = listCar.Sum(p => p.TotalMoney); //总价格
                if (userInfo.ShopAccount < dPVTotal)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('消费积分账户余额不足');", true);//账户余额不足
                    return;
                }
                try
                {
                    #region 写入订单
                    string code = DateTime.Now.ToString("yyyyMMddhhmmssffff");//订单编号
                    //写入订单
                    orderInfo.UserID = userInfo.UserID;//用户
                    lgk.Model.tb_Address addressInfo = addressBLL.GetUserModel(userInfo.UserID);
                    if(addressInfo==null)
                    {
                        MessageBox.Show(this, "请先设置地址");//请先设置默认地址
                        return;
                    }
                    DataSet addressDS = addressBLL.GetList("UserID=" + LoginUser.UserID + " and Address01=1");//获取用户的地址

                    if (addressDS.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(this, "请先设置默认地址");//请先设置默认地址
                        return;
                    }
                    orderInfo.OrderCode = code;//订单编号
                    orderInfo.UserAddr = addressDS.Tables[0].Rows[0]["Address"].ToString();//userInfo.Address;//发货地址
                    //orderModel.OrderSum = car.Goods006;//订单数--
                    orderInfo.OrderSum = listCar.Sum(p => p.Goods006);

                    //decimal bb = tb_goodsModel.Goods002 * car.Goods006;  //总BV
                    orderInfo.OrderDate = time;
                    orderInfo.IsSend = 1;
                    orderInfo.Order3 = "";//快递公司
                    orderInfo.Order4 = "";//快递单号
                    orderInfo.Order5 = addressDS.Tables[0].Rows[0]["PhoneNum"].ToString();//联系电话
                    orderInfo.Order6 = addressDS.Tables[0].Rows[0]["MemberName"].ToString();//收货人
                    orderInfo.PayMethod = 1;//--
                    orderInfo.OrderType = 0;//支付方式：0购物币支付
                    orderInfo.OrderTotal = dPVTotal;
                    orderInfo.PVTotal = dPVTotal;
                    orderBLL.Add(orderInfo);//加入订单表

                    //减去会员表里面的购物币
                    UpdateAccount("ShopAccount", userInfo.UserID, dPVTotal, 0);

                    #endregion

                    foreach (lgk.Model.tb_goodsCar car in listCar)
                    { //寻坏商品
                        //tb_goodsModel = tb_goodsBLL.GetModelAndName(car.GoodsID);//根据发布商品编号找到充值账号密码
                        if (Convert.ToInt32(goodsInfo.Pic5) >= car.Goods006) //判断库存量
                        {
                            #region 写入订单详情
                            //写入订单详情
                            orderDetailModel.OrderCode = code;
                            orderDetailModel.ProcudeID = car.GoodsID; //产品编号--
                            orderDetailModel.ProcudeName = goodsInfo.GoodsName;// car.GoodsName;//名称--
                            orderDetailModel.Price = goodsInfo.Price;//car.RealityPrice;// 单价
                            orderDetailModel.OrderSum = car.Goods006;// car.Goods006 数量--
                            orderDetailModel.PV = goodsInfo.Goods002;// car.Goods00积分--
                            orderDetailModel.OrderTotal = car.TotalMoney;
                            orderDetailModel.OrderDate = time;//
                            //orderDetailModel.ProcudeTypeID = car.TypeID;//
                            orderDetailBLL.Add(orderDetailModel);//加入订单详情
                            //orderDetailModel.OrderTotal = dd; 
                            #endregion

                            //修改库存
                            goodsInfo.Pic5 = (Convert.ToInt32(goodsInfo.Pic5) - car.Goods006).ToString();//修改库存
                            goodsBLL.Update(goodsInfo);

                            #region 写入到结算表
                            //写入到结算表
                            lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                            model.UserID = LoginUser.UserID;
                            model.Remark = "购买产品:" + goodsInfo.GoodsName;//名称--;
                            model.InAmount = 0;//收入0;
                            model.OutAmount = Convert.ToDecimal(orderDetailModel.OrderTotal);//购买价(支出消费积分)
                            model.BalanceAmount = userBLL.GetMoney(userInfo.UserID, "ShopAccount");//消费积分余额
                            model.JournalType = 7;//消费积分
                            model.JournalDate = DateTime.Now;
                            model.Journal01 = LoginUser.UserID;//来自会员;
                            model.Journal02 = 1;//0是删除的订单，1是正常的订单
                            journalBLL.Add(model);
                            #endregion

                        }
                        else
                        {
                            MessageBox.Show(this, "" + GetLanguage("InventoryProblem") + ""); //库存不足
                            return;
                        }
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');window.location.href='order.aspx';", true);
                }
                catch//(Exception ex)
                {
                    MessageBox.Show(this, "" + GetLanguage("OperationFailed") + "");
                    //MessageBox.Show(this, ex.Message);
                }
                #endregion

                #endregion
            }
        }
    }
}