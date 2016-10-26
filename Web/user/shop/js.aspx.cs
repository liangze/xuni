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
//using Com.Alipay;
//using Web.Pay.Alipay;

namespace Web.user.shop
{
    public partial class js : PageCore//System.Web.UI.Page
    {
        //统计总数
      //  decimal p = 0;
        decimal Tmoney = 0;//应付金
        decimal TCount = 0;//总金
        int PhoneRechargeType = 0;
        int Tjf = 0;//应付积分
        AllCore ac = new AllCore();
        DataSet ds = new DataSet();
        lgk.BLL.tb_goodsCar goodsCar = new lgk.BLL.tb_goodsCar();
        //lgk.Model.tb_goodsCar carModel = new lgk.Model.tb_goodsCar();
         IList<lgk.Model.tb_goodsCar> listCar = new List<lgk.Model.tb_goodsCar>();//购物车集合
        lgk.BLL.tb_goods tb_goodsBLL = new lgk.BLL.tb_goods();
        lgk.Model.tb_goods tb_goodsModel = new lgk.Model.tb_goods();
        public lgk.BLL.tb_user userbll = new lgk.BLL.tb_user();
        bool isOnlyPayCard = true;
        private decimal Emoney = 0, XFMoney = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Emoney = LoginUser.Emoney;
                //XFMoney = (decimal)LoginUser.XFMoney;

                RadioButtonList1.Items.Clear();

                RadioButtonList1.Items.Add(new ListItem(string.Format("积分 （余额：{0}）", Emoney), "0"));
                RadioButtonList1.Items.Add(new ListItem(string.Format("消费金 （余额：{0}）", XFMoney), "1"));
                RadioButtonList1.Items.Add(new ListItem("在线支付", "2"));
               // if(LoginUser.UserCode == "YL31")
                    RadioButtonList1.Items.Add(new ListItem("支付宝", "3"));
            }
            var prtype = produceTypeBLL.GetList(" TypeName='话费充值'");
            if (prtype.Tables[0].Rows.Count > 0)
            {
                PhoneRechargeType = Convert.ToInt32(prtype.Tables[0].Rows[0]["ID"]);//一级分类
            }

            if (getLoginName() > 0)
            {
                bind();
            }
            else
                Response.Redirect("login.aspx");
        }
        private string Ids()//商品编号集
        {
            if (Request["ids"] != null)
            {
               string old= Server.UrlDecode(Request["ids"].ToString());
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

        private void bind()
        {
            //默认地址
            lgk.BLL.tb_Address addressBLL = new lgk.BLL.tb_Address();
            bind_repeater(addressBLL.GetList("UserID=" + getLoginID()), address, "ID desc", trNoData);
          
            if (Ids() != "")
            {
                string where = string.Format(" and ID in({0})", Ids());
                ds = goodsCar.GetList("BuyUser=" + getLoginName() + where);

                if (ds.Tables[0].Rows.Count > 0)
                {
                   ac.bind_repeater(ds, rptProduct, "AddTime desc", tr1);
   
                   for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                   {
                       lgk.Model.tb_goodsCar carModel = new lgk.Model.tb_goodsCar();
                       decimal zongjin = Convert.ToDecimal(ds.Tables[0].Rows[i]["Price"].ToString());
                       carModel.Price = zongjin;//商品单价
                       decimal a = Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalMoney"].ToString());
                       carModel.TotalMoney = a;//购买总价
                       Tmoney += a;

                       int jifen = Convert.ToInt32(ds.Tables[0].Rows[i]["TotalGoods006"].ToString());//应付积分
                       carModel.TotalGoods006 = jifen;//购买总积分
                       Tjf += jifen;

                       carModel.ID=Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());//购物编号
                       carModel.GoodsID= Convert.ToInt32(ds.Tables[0].Rows[i]["GoodsID"].ToString());//商品ID
                       carModel.GoodsCode = ds.Tables[0].Rows[i]["GoodsCode"].ToString();//商品编号
                       carModel.GoodsName = ds.Tables[0].Rows[i]["GoodsName"].ToString();//商品名称
                       carModel.RealityPrice= Convert.ToDecimal(ds.Tables[0].Rows[i]["RealityPrice"].ToString());//购买价格
                       carModel.TypeID= Convert.ToInt32(ds.Tables[0].Rows[i]["TypeID"].ToString());//一级名称
                       carModel.TypeIDName = ds.Tables[0].Rows[i]["TypeIDName"].ToString();//一级名称
                       carModel.GoodsType = Convert.ToInt32(ds.Tables[0].Rows[i]["GoodsType"].ToString());//二级名称
                       carModel.GoodsTypeName = ds.Tables[0].Rows[i]["GoodsTypeName"].ToString();//二级名称
                       carModel.Pic1= ds.Tables[0].Rows[i]["Pic1"].ToString();//图片
                       carModel.Remarks= ds.Tables[0].Rows[i]["Remarks"].ToString();//详情
                       carModel.AddTime= Convert.ToDateTime(ds.Tables[0].Rows[i]["AddTime"].ToString());//时间
                       carModel.Goods002= Convert.ToInt32(ds.Tables[0].Rows[i]["Goods002"].ToString());//单积分
                       carModel.Goods005= Convert.ToDecimal(ds.Tables[0].Rows[i]["Goods005"].ToString());//折扣
                       carModel.Goods006= Convert.ToInt32(ds.Tables[0].Rows[i]["Goods006"].ToString());//购买数量
                       carModel.BuyUser= Convert.ToInt32(ds.Tables[0].Rows[i]["BuyUser"].ToString());//购买者
                        carModel.gColor = ds.Tables[0].Rows[i]["gColor"].ToString();
                        carModel.gSize = ds.Tables[0].Rows[i]["gSize"].ToString();
                        listCar.Add(carModel);
                       TCount += carModel.Price * carModel.Goods006;

                            //判断是否只有充值卡
                        if (carModel.TypeID != PhoneRechargeType) //手机充值
                        {
                            isOnlyPayCard = false;
                        }
                   }

                   if (isOnlyPayCard)
                   {
                       JS_edit_address_edit.Visible = false;
                       address_box.Visible = false;
                   }
                   else
                   {
                       JS_edit_address_edit.Visible = true;
                       address_box.Visible = true;
                   }

                   JS_goods_total.Text = Tmoney.ToString(); //总金

                   JS_after.Text = (Tmoney * Convert.ToInt32( GetUserLev())/10).ToString();//折扣购买金
               //    Span1.Text = Tjf.ToString();
                 //  Span3.Text = (Tjf * Convert.ToInt32(GetUserLev())/10).ToString();//折扣购买积分
                 
                }

               
            }
            
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

                //if (userModel.XFMoney < Amount) //取出用户消费金
                //{
                //    MessageBox.Show(this, "您的消费金不足支付!");
                //    return;
                //}
                //创建订单
                if (CreateOrder(out _goodsname, out _orderCode, pay,1))
                {
                    //userModel.XFMoney -= Amount;//扣除积分
                    userBLL.Update(userModel);

                    //加入流水表
                    //AddJournal(_goodsname, Amount, (decimal)userModel.XFMoney, 3);

                    MessageBox.ShowAndRedirect(this, "购买成功!", "../index.aspx");
                }

                #endregion
            }
            else if (pay == "0")
            { //积分
                #region

                if (userModel.Emoney < Amount) //取出用户积分
                {
                    MessageBox.Show(this, "您的积分余额不足支付!");
                    return;
                }
                //创建订单
                if (CreateOrder(out _goodsname, out _orderCode, pay,1))
                {
                    userModel.Emoney -= Amount;//扣除积分
                    userBLL.Update(userModel);

                    AddJournal(_goodsname, Amount, userModel.Emoney, 2);
                    MessageBox.ShowAndRedirect(this, "购买成功!", "../index.aspx");
                }

                #endregion
            }
            else if (pay == "2")
            {   //在线支付 --环讯支付
                //创建订单
                if (CreateOrder(out _goodsname, out _orderCode, pay,0))
                {
                    Response.Redirect(string.Format("/IPS/OrderPayContent.aspx?Amount={0}&Attach={1}&orderCode={2}", Amount, "shoppingcar", _orderCode));
                    return;
                }

            }
            //else if (pay == "3")
            //{ //在线支付 --支付宝
            //    //MessageBox.Show(this, "目前只能用在线支付、消费金和积分购买!");
            //    if (CreateOrder(out _goodsname, out _orderCode, pay, 0))
            //    {
            //        TradeParam tp = new TradeParam();
            //        tp.notify_url = "http://www.zshshop.cn/Pay/Alipay/OrderNotity.aspx";
            //        tp.return_url = "http://www.zshshop.cn/Pay/Alipay/OrderReturnContent.aspx";
            //        tp.seller_email = "zhaishenghuo588@163.com";
            //        tp.out_trade_no =  _orderCode;
            //        tp.subject = "商品"; //_goodsname;
            //        tp.price =  Amount.ToString("0.00");
            //        tp.quantity = "1";
            //        tp.logistics_fee = "0.00";
            //        tp.logistics_type = "EXPRESS";
            //        tp.logistics_payment = "SELLER_PAY";
            //        tp.body = ""; //_goodsname;
            //        tp.show_url = "http://www.zshshop.cn";
            //        lgk.BLL.tb_Address addressBLL = new lgk.BLL.tb_Address();
            //        lgk.Model.tb_Address myaddress = addressBLL.GetModel(int.Parse(Request["address"]));

            //        tp.receive_name = myaddress.MemberName;
            //        tp.receive_address = myaddress.AreaInProvince + " " + myaddress.Address;
            //        tp.receive_zip = "";
            //        tp.receive_phone = myaddress.PhoneNum;
            //        tp.receive_mobile = string.IsNullOrEmpty(myaddress.Phone) ? "": myaddress.Phone;//备用手机

            //        string trade = Newtonsoft.Json.JsonConvert.SerializeObject(tp);
            //        System.IO.File.AppendAllText(Server.MapPath("~/log/log.log"), trade + "\r\n");
            //        //纯担保交易接口
            //        CreatePartnerTradeByBuyer(tp);
            //        return;
            //    }
            //    return;
            //}
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
             

            if (listCar.Count > 0)
            {
                #region MyRegion
                foreach (lgk.Model.tb_goodsCar car in listCar)
                { //寻坏商品
                    tb_goodsModel = tb_goodsBLL.GetModelAndName(car.GoodsID);//根据发布商品编号找到充值账号密码
                    if (tb_goodsModel.StateType == 0) //判断是否 审核通过 0未审核
                    {
                        MessageBox.Show(this, "商品" + tb_goodsModel.GoodsCode + "审核未通过,请删除该商品!");
                        return false;
                    }
                    if (tb_goodsModel.Goods003 == "1") //判断是否 删除 1已经删除
                    {
                        MessageBox.Show(this, "商品" + tb_goodsModel.GoodsCode + "已被删除,请移除该商品!");
                        return false;
                    }
                    if (tb_goodsModel.Goods001 == 0) //判断是否 0下架
                    {
                        MessageBox.Show(this, "商品" + tb_goodsModel.GoodsCode + "已经下架,请删除该商品!");
                        return false;
                    }
                    if (Convert.ToInt32(tb_goodsModel.Pic5) < car.Goods006) //判断库存量
                    {
                        MessageBox.Show(this, "商品" + tb_goodsModel.GoodsCode + "库存不足,请重新修改数量!");
                        return false;
                    }
                } 
                #endregion

                #region
                try
                {
                    //string code = DateTime.Now.ToString("yyyyMMddhhmmssffff");//订单编号
                    Random rand = new Random();
                    orderCode = DateTime.Now.ToString("yyyyMMddhhmmss") + rand.Next(10000, 99999); //订单编号

                    decimal pvTotal = 0, orderTotal = 0;
                    int orderSum = 0;

                    pvTotal = listCar.Sum(s => s.TotalGoods006); //总积分
                    orderTotal = listCar.Sum(s => s.TotalMoney); //总金额
                    orderSum = listCar.Sum(s => s.Goods006);//订单数
                    //写入订单
                    orderModel.UserID = getLoginID();//用户
                    orderModel.OrderCode = orderCode;//订单编号
                    orderModel.UserAddr = addr;//发货地址
                    orderModel.OrderSum = orderSum;//订单数--
                    //if (car.TypeID == PhoneRechargeType) //手机充值
                    //{
                    //    orderModel.OrderTotal = orderTotal;
                    //    orderModel.PVTotal = pvTotal;
                    //}
                    //else
                    //{
                        orderModel.OrderTotal = orderTotal;// *Convert.ToInt32(GetUserLev()) / 10;//购买总金--乘以折扣
                        orderModel.PVTotal = pvTotal;// *Convert.ToInt32(GetUserLev()) / 10;//总积分
                    //}

                    orderModel.OrderDate = time;
                    //if (car.TypeID == PhoneRechargeType) //手机充值
                    //{
                    //    orderModel.IsSend = 2;//1待发货--0未付款.2已发货3已完成4.未收到货
                    //}
                    //else { orderModel.IsSend = 1; }

                    orderModel.IsSend = IsSend;

                    orderModel.PayMethod = 1;//--
                    //orderModel.Order5 = tel;//备用电话
                    //orderModel.Order6 = mobie;//收货电话
                    //orderModel.Order7 = name;//收货姓名
                    orderModel.OrderType = int.Parse( pay);//支付方式  0-积分；1-消费金；2：环讯
                    orderBLL.Add(orderModel);//加入订单表
                    goodsname += string.Format("订单号{0}，", orderCode);

                    foreach (lgk.Model.tb_goodsCar car in listCar)
                    { //寻坏商品
                        tb_goodsModel = tb_goodsBLL.GetModelAndName(car.GoodsID);//根据发布商品编号找到充值账号密码
                        if (Convert.ToInt32(tb_goodsModel.Pic5) >= car.Goods006) //判断库存量
                        {
                            #region
                            
                            //写入订单详情
                            orderDetailModel.OrderCode = orderCode;
                            orderDetailModel.ProcudeID = car.GoodsID; //产品编号--
                            orderDetailModel.ProcudeName = car.GoodsName;//名称--
                            orderDetailModel.Price = Convert.ToDecimal(car.RealityPrice);//单价--
                            orderDetailModel.OrderSum = car.Goods006;//数量--
                            orderDetailModel.PV = car.Goods002;//积分--
                            orderDetailModel.gColor = car.gColor;
                            orderDetailModel.gSize = car.gSize;
                            if (car.TypeID == PhoneRechargeType) //手机充值
                            {
                                //orderDetailModel.OderZC = 10;//没折扣折扣
                                orderDetailModel.PVTotal = car.TotalGoods006;//总积分
                                orderDetailModel.OrderTotal = car.TotalMoney;
                            }
                            else
                            {
                                //orderDetailModel.OderZC = Convert.ToDecimal(GetUserLev());//折扣
                                orderDetailModel.PVTotal = car.TotalGoods006;// *Convert.ToInt32(GetUserLev()) / 10;//总积分
                                orderDetailModel.OrderTotal = car.TotalMoney;// *Convert.ToInt32(GetUserLev()) / 10;
                            }
                            //商品名称 流水表记录用
                            goodsname += orderDetailModel.ProcudeName+"|";

                            orderDetailModel.OrderDate = time;//
                            //orderDetailModel.ProcudeTypeID = car.TypeID;//
                            orderDetailModelBLL.Add(orderDetailModel);//加入订单详情

                            //修改库存
                            tb_goodsModel.Pic5 = (Convert.ToInt32(tb_goodsModel.Pic5) - car.Goods006).ToString();//修改库存
                            tb_goodsBLL.Update(tb_goodsModel);

                            //如果是手机充值,则发消息账号密码
                            //if (car.TypeID == PhoneRechargeType)
                            //{
                            //    messageModel.Userid = getLoginName();
                            //    messageModel.MobileNum = mobie;
                            //    messageModel.Mcontent = "您购买的" + tb_goodsModel.TypeIDName + ":" + tb_goodsModel.GoodsTypeName + "充值账号为:" + tb_goodsModel.CzCard + ",充值密码为:" + tb_goodsModel.CzPwd;//内容
                            //    messageModel.Flag = "成功"; //发送成功
                            //    messageBLL.Add(messageModel);//加入消息表
                            //}


                            //    MySQL(string.Format("proc_yeji(getLoginID(),car.TotalGoods006)"));
                            //从购物篮减掉
                            goodsCar.Delete(car.ID);
                            #endregion
                            // MessageBox.ShowAndRedirect(this, "购买成功!", "../index.aspx");
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
        public void AddJournal(string GoodsNames, decimal OrderTotal, decimal BalanceAmount, int JournalType)
        {
            //写入到结算表
            lgk.Model.tb_journal joModel = new lgk.Model.tb_journal();
            joModel.UserID = getLoginName();
            joModel.Remark = "购买产品:" + GoodsNames;//名称--;
            joModel.InAmount = 0;//收入0;
            joModel.OutAmount = OrderTotal;//购买价(支出金币)
            joModel.BalanceAmount = BalanceAmount;//余额
            joModel.JournalType = JournalType;//金币
            joModel.JournalDate = DateTime.Now;
            joModel.Journal01 = (int)LoginUser.UserID ;//tb_goodsModel.UploadUser;//来自会员;
            ac.journalBLL.Add(joModel);
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

        protected string GetUserLev()
        { //获取会员级别

            if (getLoginName() > 0)
            {

                lgk.BLL.tb_user user = new lgk.BLL.tb_user();
                lgk.BLL.tb_globeParam globeParam = new lgk.BLL.tb_globeParam();
                lgk.Model.tb_globeParam globeParamModel = new lgk.Model.tb_globeParam();
                int lev = user.GetModel(getLoginName()).LevelID;
                //获取当前用户优惠折扣
                    string strWhere = string.Format(" ParamName='zc{0}'", lev);
                    globeParamModel = globeParam.GetModel(strWhere);
                    if (globeParamModel==null||globeParamModel.ID < 0)
                    {
                        return "10";
                    }
                    else
                    {
                       
                        if (int.Parse(globeParamModel.ParamVarchar) == 0)
                        {
                            return "10";
                        }
                        else
                        {
                            return globeParamModel.ParamVarchar;
                        }
                    }
                }
                else
                    return "10";

            }

        /// <summary>
        /// 纯担保交易接口
        /// </summary>
        //protected void CreatePartnerTradeByBuyer(TradeParam tp)
        //{
        //    ////////////////////////////////////////////请求参数////////////////////////////////////////////

        //    //支付类型
        //    string payment_type = "1";
        //    //必填，不能修改
        //    //服务器异步通知页面路径
        //    string notify_url = tp.notify_url;// "http://www.zshshop.cn/Pay/Alipay/notify_url.aspx";
        //    //需http://格式的完整路径，不能加?id=123这类自定义参数

        //    //页面跳转同步通知页面路径
        //    string return_url = tp.return_url; //"http://www.zshshop.cn/Pay/Alipay/return_url.aspx";
        //    //需http://格式的完整路径，不能加?id=123这类自定义参数，不能写成http://localhost/

        //    //卖家支付宝帐户
        //    string seller_email = tp.seller_email;
        //    //必填

        //    //商户订单号
        //    string out_trade_no = tp.out_trade_no;// WIDout_trade_no.Text.Trim();
        //    //商户网站订单系统中唯一订单号，必填

        //    //订单名称
        //    string subject = tp.subject;// WIDsubject.Text.Trim();
        //    //必填

        //    //付款金额
        //    string price = tp.price;// WIDprice.Text.Trim();
        //    //必填

        //    //商品数量
        //    string quantity = tp.quantity;// "1";
        //    //必填，建议默认为1，不改变值，把一次交易看成是一次下订单而非购买一件商品
        //    //物流费用
        //    string logistics_fee = tp.logistics_fee;// "0.00";
        //    //必填，即运费
        //    //物流类型
        //    string logistics_type = tp.logistics_type;// "EXPRESS";
        //    //必填，三个值可选：EXPRESS（快递）、POST（平邮）、EMS（EMS）
        //    //物流支付方式
        //    string logistics_payment = tp.logistics_payment;// "SELLER_PAY";
        //    //必填，两个值可选：SELLER_PAY（卖家承担运费）、BUYER_PAY（买家承担运费）
        //    //订单描述

        //    string body = tp.body;// WIDbody.Text.Trim();
        //    //商品展示地址
        //    string show_url = tp.show_url;// WIDshow_url.Text.Trim();
        //    //需以http://开头的完整路径，如：http://www.商户网站.com/myorder.html

        //    //收货人姓名
        //    string receive_name = tp.receive_name;// WIDreceive_name.Text.Trim();
        //    //如：张三

        //    //收货人地址
        //    string receive_address = tp.receive_address;// WIDreceive_address.Text.Trim();
        //    //如：XX省XXX市XXX区XXX路XXX小区XXX栋XXX单元XXX号

        //    //收货人邮编
        //    string receive_zip = tp.receive_zip;// WIDreceive_zip.Text.Trim();
        //    //如：123456

        //    //收货人电话号码
        //    string receive_phone = tp.receive_phone;// WIDreceive_phone.Text.Trim();
        //    //如：0571-88158090

        //    //收货人手机号码
        //    string receive_mobile = tp.receive_mobile;// WIDreceive_mobile.Text.Trim();
        //    //如：13312341234


        //    ////////////////////////////////////////////////////////////////////////////////////////////////

        //    //把请求参数打包成数组
        //    SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
        //    sParaTemp.Add("partner", Config.Partner);
        //    sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
        //    sParaTemp.Add("service", "create_partner_trade_by_buyer");
        //    sParaTemp.Add("payment_type", payment_type);
        //    sParaTemp.Add("notify_url", notify_url);
        //    sParaTemp.Add("return_url", return_url);
        //    sParaTemp.Add("seller_email", seller_email);
        //    sParaTemp.Add("out_trade_no", out_trade_no);
        //    sParaTemp.Add("subject", subject);
        //    sParaTemp.Add("price", price);
        //    sParaTemp.Add("quantity", quantity);
        //    sParaTemp.Add("logistics_fee", logistics_fee);
        //    sParaTemp.Add("logistics_type", logistics_type);
        //    sParaTemp.Add("logistics_payment", logistics_payment);
        //    sParaTemp.Add("body", body);
        //    sParaTemp.Add("show_url", show_url);
        //    sParaTemp.Add("receive_name", receive_name);
        //    sParaTemp.Add("receive_address", receive_address);
        //    sParaTemp.Add("receive_zip", receive_zip);
        //    sParaTemp.Add("receive_phone", receive_phone);
        //    sParaTemp.Add("receive_mobile", receive_mobile);

        //    string trade = Newtonsoft.Json.JsonConvert.SerializeObject(sParaTemp);
        //    System.IO.File.AppendAllText(Server.MapPath("~/log/log.log"), trade + "\r\n");
        //    //建立请求
        //    string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
        //    Response.Write(sHtmlText);

        //}
    }
}