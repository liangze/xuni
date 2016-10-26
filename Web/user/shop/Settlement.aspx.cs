using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Drawing;
using lgk.BLL;
using System.Data;
using System.Text;
using lgk.Model;

namespace Web.user.shop
{
    public partial class Settlement : PageCore
    {
        decimal dTmoney = 0;//应付金
        decimal TCount = 0;//总金
        int iTIntegral = 0;//应付积分
        DataSet ds = new DataSet();

        IList<lgk.Model.tb_goodsCar> listCar = new List<lgk.Model.tb_goodsCar>();//购物车集合
        lgk.Model.tb_goods goodsInfo = new lgk.Model.tb_goods();

        private decimal dShopAccount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dShopAccount = LoginUser.ShopAccount;
                rbtnPaymentMethod.Items.Clear();
                rbtnPaymentMethod.Items.Add(new ListItem(string.Format("购物币（余额：{0}）", dShopAccount), "1"));
            }

            if (GetLoginName() > 0)
                BindData();
            else
                Response.Redirect("login.aspx");
        }

        private string GetIDS()//商品编号集
        {
            if (Request["IDS"] != null)
            {
                string old = Server.UrlDecode(Request["IDS"].ToString());
                string id = old.Trim(',');//去掉最后逗号
                string[] _id = id.Split(',');
                int tick = 0;
                for (int i = 0; i < _id.Length; i++)
                {
                    if (PageValidate.IsInt(_id[i]) == false)
                    {
                        tick = -1;
                        break;
                    }
                }
                if (tick != -1)
                { //可以
                    return id;
                }
                else
                {
                    return "";
                }
            }
            else
                return "";
        }

        private void BindData()
        {
            //默认地址
            lgk.BLL.tb_Address addressBLL = new lgk.BLL.tb_Address();

            bind_repeater(addressBLL.GetList("UserID=" + getLoginID()), address, "ID desc", trNoData);

            if (GetIDS() != "")
            {
                string strWhere = string.Format(" AND [ID] IN({0})", GetIDS());
                ds = goodsCarBLL.GetList("BuyUser=" + GetLoginName() + strWhere);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    bind_repeater(ds, rptProduct, "AddTime desc", tr1);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        lgk.Model.tb_goodsCar carModel = new lgk.Model.tb_goodsCar();
                        carModel.Price = Convert.ToDecimal(ds.Tables[0].Rows[i]["Price"].ToString());//商品单价
                        decimal dTotalMoney = Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalMoney"].ToString());//商品总价
                        carModel.TotalMoney = dTotalMoney;//购买总价
                        dTmoney += dTotalMoney;

                        int iIntegral = Convert.ToInt32(ds.Tables[0].Rows[i]["TotalGoods006"].ToString());//应付积分
                        carModel.TotalGoods006 = iIntegral;//购买总积分
                        iTIntegral += iIntegral;

                        carModel.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());//购物编号
                        carModel.GoodsID = Convert.ToInt32(ds.Tables[0].Rows[i]["GoodsID"].ToString());//商品ID
                        carModel.GoodsCode = ds.Tables[0].Rows[i]["GoodsCode"].ToString();//商品编号
                        carModel.GoodsName = ds.Tables[0].Rows[i]["GoodsName"].ToString();//商品名称
                        carModel.RealityPrice = Convert.ToDecimal(ds.Tables[0].Rows[i]["RealityPrice"].ToString());//购买价格
                        carModel.TypeID = Convert.ToInt32(ds.Tables[0].Rows[i]["TypeID"].ToString());//一级名称
                        carModel.TypeIDName = ds.Tables[0].Rows[i]["TypeIDName"].ToString();//一级名称
                        carModel.GoodsType = Convert.ToInt32(ds.Tables[0].Rows[i]["GoodsType"].ToString());//二级名称
                        carModel.GoodsTypeName = ds.Tables[0].Rows[i]["GoodsTypeName"].ToString();//二级名称
                        carModel.Pic1 = ds.Tables[0].Rows[i]["Pic1"].ToString();//图片
                        carModel.Remarks = ds.Tables[0].Rows[i]["Remarks"].ToString();//详情
                        carModel.AddTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["AddTime"].ToString());//时间
                        carModel.Goods002 = Convert.ToInt32(ds.Tables[0].Rows[i]["Goods002"].ToString());//单积分
                        carModel.Goods005 = Convert.ToDecimal(ds.Tables[0].Rows[i]["Goods005"].ToString());//折扣
                        carModel.Goods006 = Convert.ToInt32(ds.Tables[0].Rows[i]["Goods006"].ToString());//购买数量
                        carModel.BuyUser = Convert.ToInt32(ds.Tables[0].Rows[i]["BuyUser"].ToString());//购买者
                        carModel.gColor = ds.Tables[0].Rows[i]["gColor"].ToString();
                        carModel.gSize = ds.Tables[0].Rows[i]["gSize"].ToString();
                        listCar.Add(carModel);
                        TCount += carModel.Price * carModel.Goods006;
                    }

                    JS_edit_address_edit.Visible = true;
                    address_box.Visible = true;

                    lblTotal.Text = dTmoney.ToString(); //产品金额共计
                    lblTotalPayable.Text = dTmoney.ToString(); //应付总额
                }
            }
        }

        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            string _goodsname = string.Empty;
            string _orderCode = string.Empty;

            if (rbtnPaymentMethod.SelectedValue == "")
            {
                MessageBox.Show(this, "请选择支付方式!");
                return;
            }

            if (JS_edit_address_edit.Visible == true && Request["address"] == null)
            {
                MessageBox.Show(this, "请选择填写收货地址!");
                return;
            }

            string strPayment = rbtnPaymentMethod.SelectedValue;//支付方式

            lgk.Model.tb_user userInfo = userBLL.GetModel(GetLoginName());//取得当前用户

            decimal dAmount = Convert.ToDecimal(lblTotalPayable.Text); //支付金额

            if (strPayment == "1")
            {
                #region 购物币支付

                if (userInfo.ShopAccount < dAmount) //判断购物币
                {
                    MessageBox.Show(this, "您的购物币余额不足!");
                    return;
                }
                //创建订单
                if (CreateOrder(out _goodsname, out _orderCode, strPayment, 1))
                {
                    userInfo.ShopAccount -= dAmount;//扣除购物币
                    userBLL.Update(userInfo);

                    bonusBLL.ShoppingAward(userInfo.UserID, dAmount);

                    AddJournal(_goodsname, dAmount, userInfo.ShopAccount, 4);//购物币
                    MessageBox.ShowAndRedirect(this, "购买成功!", "../index.aspx");
                }

                #endregion
            }
            else return;
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="goodsname"></param>
        /// <param name="orderCode"></param>
        /// <param name="pay"></param>
        /// <param name="IsSend">1待发货--0未付款.2已发货3已完成4.未收到货</param>
        /// <returns></returns>
        public bool CreateOrder(out string strGoodsName, out string strOrderCode, string strPayment, int IsSend)
        {
            string strName = "", strAddr = "", strMobie = "", strTel = "";//备用手机

            strGoodsName = "";
            strOrderCode = "";

            DateTime time = DateTime.Now;
            lgk.Model.tb_Order orderInfo = new lgk.Model.tb_Order();//订单
            lgk.Model.tb_OrderDetail orderDetailInfo = new lgk.Model.tb_OrderDetail();//订单详情

            if (JS_edit_address_edit.Visible == true && Request["address"] != null)
            {
                lgk.Model.tb_Address myaddress = addressBLL.GetModel(int.Parse(Request["address"]));

                strName = myaddress.MemberName;
                strAddr = myaddress.AreaInProvince + " " + myaddress.Address;
                strMobie = myaddress.PhoneNum;
                strTel = myaddress.Phone;//备用手机
            }

            if (listCar.Count > 0)
            {
                #region 验证商品
                foreach (lgk.Model.tb_goodsCar car in listCar)
                { 
                    //循环商品
                    goodsInfo = goodsBLL.GetModelAndName(car.GoodsID);//根据发布商品编号找到充值账号密码
                    if (goodsInfo.Goods003 == "1") //判断是否 删除 1已经删除
                    {
                        MessageBox.Show(this, "商品" + goodsInfo.GoodsCode + "已被删除，请移除该商品!");
                        return false;
                    }
                    if (goodsInfo.Goods001 == 0) //判断是否 0下架
                    {
                        MessageBox.Show(this, "商品" + goodsInfo.GoodsCode + "已经下架，请移除该商品!");
                        return false;
                    }
                    if (Convert.ToInt32(goodsInfo.Pic5) < car.Goods006) //判断库存量
                    {
                        MessageBox.Show(this, "商品" + goodsInfo.GoodsCode + "库存不足,请重新修改数量!");
                        return false;
                    }
                }
                #endregion

                #region
                try
                {
                    Random rand = new Random();
                    strOrderCode = DateTime.Now.ToString("yyyyMMddhhmmss") + rand.Next(10000, 99999); //订单编号

                    decimal dPVTotal = 0, dOrderTotal = 0;
                    int iOrderSum = 0;

                    dPVTotal = listCar.Sum(s => s.TotalGoods006); //总积分
                    dOrderTotal = listCar.Sum(s => s.TotalMoney); //总金额
                    iOrderSum = listCar.Sum(s => s.Goods006);//订单数
                    //写入订单
                    orderInfo.UserID = getLoginID();//用户
                    orderInfo.OrderCode = strOrderCode;//订单编号
                    orderInfo.UserAddr = strAddr;//收货地址
                    orderInfo.OrderSum = iOrderSum;//订单数--

                    orderInfo.OrderTotal = dOrderTotal;//总金额(购物币额度)
                    orderInfo.PVTotal = dPVTotal;//总积分

                    orderInfo.OrderDate = time;

                    orderInfo.IsSend = IsSend;

                    orderInfo.PayMethod = 1;//--
                    orderInfo.Order5 = strTel;//备用电话
                    orderInfo.Order6 = strMobie;//收货电话
                    orderInfo.Order7 = strName;//收货姓名
                    orderInfo.OrderType = int.Parse(strPayment);//1购物币
                    orderInfo.TypeID = 0;//产品类型
                    orderInfo.PareTopChild = "0";//什么类型的团购，秒杀
                    orderBLL.Add(orderInfo);//加入订单表

                    strGoodsName += string.Format("订单号{0}，", strOrderCode);

                    foreach (lgk.Model.tb_goodsCar carInfo in listCar)
                    { 
                        //循环商品
                        goodsInfo = goodsBLL.GetModelAndName(carInfo.GoodsID);//根据发布商品编号找到充值账号密码
                        if (Convert.ToInt32(goodsInfo.Pic5) >= carInfo.Goods006) //判断库存量
                        {
                            #region 写入订单详情
                            orderDetailInfo.OrderCode = strOrderCode;
                            orderDetailInfo.ProcudeID = carInfo.GoodsID; //产品编号--
                            orderDetailInfo.ProcudeName = carInfo.GoodsName;//名称--
                            orderDetailInfo.Price = Convert.ToDecimal(carInfo.Price);//单价--
                            orderDetailInfo.OrderSum = carInfo.Goods006;//数量--
                            orderDetailInfo.PV = carInfo.Goods002;//积分--

                            orderDetailInfo.OrderTotal = carInfo.TotalMoney;//总金额(购物币额度)
                            orderDetailInfo.PVTotal = carInfo.TotalGoods006;//总积分
                            orderDetailInfo.gColor = carInfo.gColor;
                            orderDetailInfo.gSize = carInfo.gSize;

                            //商品名称 流水表记录用
                            strGoodsName += orderDetailInfo.ProcudeName + "|";

                            orderDetailInfo.OrderDate = time;//
                            //orderDetailModel.ProcudeTypeID = car.TypeID;//
                            orderDetailBLL.Add(orderDetailInfo);//加入订单详情

                            //修改库存
                            goodsInfo.Pic5 = (Convert.ToInt32(goodsInfo.Pic5) - carInfo.Goods006).ToString();//修改库存
                            goodsBLL.Update(goodsInfo);

                            goodsCarBLL.Delete(carInfo.ID);
                            #endregion
                        }
                        else
                        {
                            MessageBox.Show(this, "库存数量不足,请修改数量!");
                            return false;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "提交失败,请重试!");
                    return false;
                }
                return true;

                #endregion

            }
            else return false;
        }

        /// <summary>
        /// 支付 支出写入流水表
        /// </summary>
        /// <param name="GoodsNames">购买的产品名称</param>
        /// <param name="OrderTotal">订单金额</param>
        /// <param name="BalanceAmount">账户余额</param>
        /// <param name="JournalType">支付类型 2-积分；3：消费金</param>
        public void AddJournal(string strGoodsName, decimal OrderTotal, decimal BalanceAmount, int JournalType)
        {
            //写入流水表
            lgk.Model.tb_journal joModel = new lgk.Model.tb_journal();

            joModel.UserID = GetLoginName();
            joModel.Remark = "购买产品:" + strGoodsName;//名称--;
            joModel.InAmount = 0;//收入0;
            joModel.OutAmount = OrderTotal;//购买价(支出金币)
            joModel.BalanceAmount = BalanceAmount;//余额
            joModel.JournalType = JournalType;//金币
            joModel.JournalDate = DateTime.Now;
            joModel.Journal01 = LoginUser.UserID;//来自会员;

            journalBLL.Add(joModel);
        }

        /// <summary>
        /// 获取当前登录UserCode ID
        /// </summary>
        /// <returns></returns>
        public long GetLoginName()
        {
            if (Request.Cookies["A128076_user"] != null)
            {
                return long.Parse(Request.Cookies["A128076_user"]["Id"]);
            }
            else
            {
                return 0;
            }
        }
    }
}