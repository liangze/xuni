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
    public partial class cxjs : PageCore//System.Web.UI.Page  //
    {
        private decimal dShopAccount = 0;

        lgk.Model.tb_goods_cxth tb_goods_cxthModel = new lgk.Model.tb_goods_cxth();
        lgk.BLL.tb_goods_cxth tb_goods_cxthBLL = new lgk.BLL.tb_goods_cxth();

        private int Purchase = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            tb_goods_cxthModel = tb_goods_cxthBLL.GetModel(Cid());//根据发布商品编号找到实体
            Purchase = tb_goods_cxthModel.Purchase;

            //获取抢购产品购买数量
            int qy = GetOrderSum(tb_goods_cxthModel.ID, LoginUser.UserID);
            if(qy >= Purchase)
            {
                string purl = Request.UrlReferrer.ToString();
                MessageBox.ShowAndRedirect(this, "您已购买达到该商品限购数量!", purl);//转账成功
            }
            if (!IsPostBack)
            {
                dShopAccount = LoginUser.ShopAccount;
                dShopAccount = LoginUser.ShopAccount;
                RadioButtonList1.Items.Clear();
                RadioButtonList1.Items.Add(new ListItem(string.Format("购物币（余额：{0}）", dShopAccount), "1"));
            }

            if (getLoginName() > 0)
            {
                bind();
            }
            else{
                if (Pid() > 0 && Cid() > 0)
                   Response.Redirect("../../login.aspx?action="+ Server.UrlEncode("/user/shop/tuangou_detail.aspx?pid=" + Pid() + "&gid=" + Cid()));  
                else
                   Response.Redirect("../../login.aspx");
                 
                }
        }

        private void bind()
        {
            //默认地址
            lgk.BLL.tb_Address addressBLL = new lgk.BLL.tb_Address();
            bind_repeater(addressBLL.GetList("UserID=" + getLoginID()), address, "ID desc", trNoData);

            if (Pid() > 0 && Cid() > 0 && Count() > 0)
            {
                lgk.BLL.tb_goods_cxth cxModel = new lgk.BLL.tb_goods_cxth();
                string strWhere = string.Format("g.PareTopId=" + Pid() + " and g.ID=" + Cid() + " and g.StateType=1");
                DataSet ds = cxModel.GetList(1, strWhere, "[AddTime]");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int c = Convert.ToInt32(ds.Tables[0].Rows[0]["Goods006"].ToString());
                    if (Count() > c)
                    {
                        ds.Tables[0].Rows[0]["Goods006"] = c;//数量
                    }
                    else
                    {
                        ds.Tables[0].Rows[0]["Goods006"] = Count();//数量
                    }
                    decimal price = Convert.ToDecimal(ds.Tables[0].Rows[0]["RealityPrice"].ToString());//单价
                    decimal jifen = Convert.ToDecimal(ds.Tables[0].Rows[0]["Goods002"].ToString());//单价
                    new AllCore().bind_repeater(ds, rptProduct, "AddTime desc", tr1);

                    JS_goods_total.Text = (price * Count()).ToString();//总金额
                    JS_after.Text = (price * Count()).ToString();//应付金额
                    //Span1.Text = (jifen * Count()).ToString();//总积分
                    //Span3.Text = (jifen * Count()*Convert.ToInt32(GetUserLev()) / 10).ToString();//应付积分
                }
                else
                {
                    Response.Redirect("tuangou.aspx");
                }
            }

        }

        private int Pid()
        { //父ID

            if (Request["pid"] != null && PageValidate.IsInt(Request["pid"]))
            {

                return Convert.ToInt32(Request["pid"].ToString());
            }
            else
                return 0;
        }

        private int Cid() //商品ID
        {

            if (Request["gid"] != null && PageValidate.IsInt(Request["gid"]) == true)
            {

                return Convert.ToInt32(Request["gid"].ToString());
            }
            else
                return 0;

        }

        private int Count() //商品数量
        {

            if (Request["sl"] != null && PageValidate.IsInt(Request["sl"]) == true)
            {
                int result=Convert.ToInt32(Request["sl"].ToString());
                if (result > Purchase)
                    return Purchase;
                else
                    return result;
            }
            else
                return 0;

        }

        protected void JS_submit_form_Click(object sender, EventArgs e)
        {
            /*
            string name= JS_consignee.Text.Trim();//姓名
            string addr = JS_address.Text.Trim();
            string mobie = JS_mobile.Text.Trim();
            string tel = JS_tel.Text.Trim();//备用手机
            */
            string _goodsname = string.Empty;
            string _orderCode = string.Empty;

            if (RadioButtonList1.SelectedValue == "")
            {
                MessageBox.Show(this, "请选择支付方式!");
                return;
            }

            if (JS_edit_address_edit.Visible == true && Request["address"] == null)
            {
                MessageBox.Show(this, "请选择填写收货地址!");
                return;
            }

            string pay = RadioButtonList1.SelectedValue;//支付方式
            lgk.Model.tb_user userModel = new lgk.Model.tb_user();
            lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
            userModel = userBLL.GetModel(getLoginName());//取得当前用户

            decimal Amount = Convert.ToDecimal(JS_after.Text); //支付金额

            if (pay == "1")
            { //消费金支付
                #region

                if (userModel.ShopAccount < Amount) //取出用户消费金
                {
                    MessageBox.Show(this, "您的购物币余额不足!");
                    return;
                }
                //创建订单
                if (CreateOrder(out _goodsname, out _orderCode, pay, 1))
                {
                    userModel.ShopAccount -= Amount;//扣除积分
                    userBLL.Update(userModel);

                    //加入流水表
                    AddJournal(_goodsname, Amount, (decimal)userModel.ShopAccount, 4);

                    MessageBox.ShowAndRedirect(this, "购买成功!", "../index.aspx");
                }

                #endregion
            }
            else return;
        }
        /// <summary>
        /// 支付 支出写入流水表
        /// </summary>
        /// <param name="GoodsNames">购买的产品名称</param>
        /// <param name="OrderTotal">订单金额</param>
        /// <param name="BalanceAmount">账户余额</param>
        /// <param name="JournalType">支付类型 2-积分；3：消费金</param>
        public void AddJournal(string GoodsNames, decimal OrderTotal, decimal BalanceAmount, int JournalType)
        {
            //写入到结算表
            lgk.Model.tb_journal joModel = new lgk.Model.tb_journal();
            joModel.UserID = LoginUser.UserID;
            joModel.Remark = "购买产品:" + GoodsNames;//名称--;
            joModel.InAmount = 0;//收入0;
            joModel.OutAmount = OrderTotal;//购买价(支出金币)
            joModel.BalanceAmount = BalanceAmount;//余额
            joModel.JournalType = JournalType;//金币
            joModel.JournalDate = DateTime.Now;
            joModel.Journal01 = LoginUser.UserID;//tb_goodsModel.UploadUser;//来自会员;
            journalBLL.Add(joModel);
        }
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="goodsname"></param>
        /// <param name="orderCode"></param>
        /// <param name="pay"></param>
        /// <param name="IsSend">1待发货--0未付款.2已发货3已完成4.未收到货</param>
        /// <returns></returns>
        public bool CreateOrder(out string goodsname, out string orderCode, string pay, int IsSend)
        {
            string name = "";
            string addr = "";
            string mobie = "";
            string tel = "";//备用手机

            goodsname = "";
            orderCode = "";

            DateTime time = DateTime.Now;

            lgk.Model.tb_Order orderModel = new lgk.Model.tb_Order();//订单
            lgk.BLL.tb_Order orderBLL = new lgk.BLL.tb_Order();//订单

            lgk.Model.tb_OrderDetail orderDetailModel = new lgk.Model.tb_OrderDetail();//订单详情
            lgk.BLL.tb_OrderDetail orderDetailModelBLL = new lgk.BLL.tb_OrderDetail();//订单详情

            lgk.Model.tb_message messageModel = new lgk.Model.tb_message();//发送消息
            lgk.BLL.tb_message messageBLL = new lgk.BLL.tb_message();//发送消息

            if (JS_edit_address_edit.Visible == true && Request["address"] != null)
            {
                lgk.BLL.tb_Address addressBLL = new lgk.BLL.tb_Address();
                lgk.Model.tb_Address myaddress = addressBLL.GetModel(int.Parse(Request["address"]));

                name = myaddress.MemberName;
                addr = myaddress.AreaInProvince + " " + myaddress.Address;
                mobie = myaddress.PhoneNum;
                tel = myaddress.Phone;//备用手机
            }

            #region MyRegion

            if (tb_goods_cxthModel.StateType == 0) //判断是否 审核通过 0未审核
            {
                MessageBox.Show(this, "商品" + tb_goods_cxthModel.GoodsCode + "审核未通过,请删除该商品!");
                return false;
            }
            if (tb_goods_cxthModel.Goods003 == 1) //判断是否 删除 1已经删除
            {
                MessageBox.Show(this, "商品" + tb_goods_cxthModel.GoodsCode + "已被删除,请移除该商品!");
                return false;
            }
            if (tb_goods_cxthModel.Goods001 == 0) //判断是否 0下架
            {
                MessageBox.Show(this, "商品" + tb_goods_cxthModel.GoodsCode + "已经下架,请删除该商品!");
                return false;
            }
            if ((Convert.ToInt32(tb_goods_cxthModel.Purchase) - Convert.ToInt32(tb_goods_cxthModel.SealPurchase)) <= 0) //判断库存量
            {
                MessageBox.Show(this, "商品" + tb_goods_cxthModel.GoodsCode + "竞拍已完成，请重新选择商品！");
                return false;
            }

            #endregion

            #region
            try
            {
                //string code = DateTime.Now.ToString("yyyyMMddhhmmssffff");//订单编号
                Random rand = new Random();
                orderCode = DateTime.Now.ToString("yyyyMMddhhmmss") + rand.Next(10000, 99999); //订单编号

                goodsname += string.Format("订单号{0}，", orderCode);

                orderModel.UserID = getLoginName();//用户
                orderModel.OrderCode = orderCode;//订单编号
                orderModel.UserAddr = addr;//发货地址
                orderModel.OrderSum = Count();//订单数--
                orderModel.OrderTotal = (tb_goods_cxthModel.RealityPrice) * Count();//购买总金--
                orderModel.PVTotal = (tb_goods_cxthModel.Goods002) * Count() ;//总积分
                orderModel.OrderDate = time;
                orderModel.TypeID = tb_goods_cxthModel.TypeID;//产品类型
                orderModel.PareTopChild = tb_goods_cxthModel.PareTopId.ToString();//什么类型的团购，秒杀
                orderModel.IsSend = IsSend;
                orderModel.PayMethod = 1;//---
                orderModel.Order5 = tel;//备用电话
                orderModel.Order6 = mobie;//收货电话
                orderModel.Order7 = name;//收货姓名
                orderModel.OrderType = int.Parse(pay);//支付方式  0-积分；1-消费金；2：环讯
                orderBLL.Add(orderModel);//加入订单表
                                            //写入订单详情
                orderDetailModel.OrderCode = orderCode;
                orderDetailModel.ProcudeID = tb_goods_cxthModel.ID; //产品编号--
                orderDetailModel.ProcudeName = tb_goods_cxthModel.GoodsName;//名称--
                orderDetailModel.Price = Convert.ToDecimal(tb_goods_cxthModel.RealityPrice);//单价--
                orderDetailModel.OrderSum = Count();//数量--
                orderDetailModel.PV = tb_goods_cxthModel.Goods002;//积分--
                orderDetailModel.PVTotal = (tb_goods_cxthModel.Goods002) * Count() ;//总积分--
                orderDetailModel.OrderDate = time;//
                orderDetailModel.ProcudeTypeID = tb_goods_cxthModel.PareTopId;
                orderDetailModel.OrderTotal = orderDetailModel.Price * orderDetailModel.OrderSum;
                orderDetailModelBLL.Add(orderDetailModel);//加入订单详情

                //tb_goods_cxthModel.SealCount += orderDetailModel.OrderSum;  //购买数量
                tb_goods_cxthModel.SealPurchase += 1;
                tb_goods_cxthBLL.Update(tb_goods_cxthModel);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "提交失败,请重试!");
                return false;
            }
            return true;

            #endregion
        }

        /// <summary>
        /// 获取当前登录UserCode ID
        /// </summary>
        /// <returns></returns>
        public int getLoginName()
        {
            if (Request.Cookies["A128076_user"] != null)
            {
                return int.Parse(Request.Cookies["A128076_user"]["Id"]);
            }
            else
            {
                return 0;
            }
        }
    }
}