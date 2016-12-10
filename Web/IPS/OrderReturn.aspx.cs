using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Library;
using IPSVERIFYLib;
using Web.user.shop;

/// <summary>
/// 交易成功返回页面
/// </summary>
public partial class OrderReturn : System.Web.UI.Page
{
    AllCore ac = new AllCore();
    lgk.Model.tb_user LoginUser = null;
    int payment = 3;//支付方式：1-积分支付；2-E币支付

    private void Page_Load(object sender, System.EventArgs e)
    {
        int loginid = getLoginID();
        LoginUser = ac.userBLL.GetModel(long.Parse(loginid.ToString()));

        //接收数据
        string billno = Request["billno"];
        string amount = Request["amount"];
        string currency_type = Request["Currency_type"];
        string mydate = Request["date"];
        string succ = Request["succ"];
        string msg = Request["msg"];
        string attach = Request["attach"];
        string ipsbillno = Request["ipsbillno"];
        string retEncodeType = Request["retencodetype"];
        string signature = Request["signature"];
        string bankbillno = Request["bankbillno"];

        //签名原文
        //billno+【订单编号】+currencytype+【币种】+amount+【订单金额】+date+【订单日期】+succ+【成功标志】+ipsbillno+【IPS订单编号】+retencodetype +【交易返回签名方式】
        string content = "billno" + billno + "currencytype" + currency_type + "amount" + amount + "date" + mydate + "succ" + succ + "ipsbillno" + ipsbillno + "retencodetype" + retEncodeType;

        //签名是否正确
        Boolean verify = false;

        //验证方式：16-md5withRSA  17-md5
        if (retEncodeType == "16")
        {
            string pubfilename = "C:\\PubKey\\publickey.txt";
            RSAMD5Class m_RSAMD5Class = new RSAMD5Class();
            int result = m_RSAMD5Class.VerifyMessage(pubfilename, content, signature);

            //result=0   表示签名验证成功
            //result=-1  表示系统错误
            //result=-2  表示文件绑定错误
            //result=-3  表示读取公钥失败
            //result=-4  表示签名长度错
            //result=-5  表示签名验证失败
            //result=-99 表示系统锁定失败
            if (result == 0)
            {
                verify = true;
            }
        }
        else if (retEncodeType == "17")
        {
            //登陆http://merchant.ips.com.cn/商户后台下载的商户证书内容
            string merchant_key = "40301353982421808762056564364329661849129129580266796478374708865375995863383797310863218357532035320426083319557639800106764832";
            //string merchant_key = "GDgLwwdK270Qj1w4xho8lyTpRQZV9Jm5x4NwWOTThUa4fMhEBK9jOXFrKRT6xhlJuU2FEa89ov0ryyjfJuuPkcGzO5CeVx5ZIrkkt1aBlZV36ySvHOMcNv8rncRiy3DQ";
            //Md5摘要
            string signature1 = FormsAuthentication.HashPasswordForStoringInConfigFile(content + merchant_key, "MD5").ToLower();

            if (signature1 == signature)
            {
                verify = true;
            }

        }

        //判断签名验证是否通过
        if (verify == true)
        {
            //判断交易是否成功
            if (succ != "Y")
            {
                Response.Write("交易失败！");
                Response.End();
            }
            else
            {
                /****************************************************************
				//比较返回的订单号和金额与您数据库中的金额是否相符			
				if(不等)
                {
                    Response.Write("从IPS返回的数据和本地记录的不符合，失败！");
					Response.End(); 
                }
                else
                {
					Reponse.Write("交易成功，处理您的数据库！");
				}
                ****************************************************************/
                if (attach == "remit")
                {
                    string dt = billno.Substring(0, 14);
                    string id = billno.Substring(19);
                    DateTime addTime = DateTime.Now;
                    DateTime.TryParse(dt, out addTime);
                    long remitID = 0;
                    long.TryParse(id, out remitID);
                    lgk.BLL.tb_remit remitBLL = new lgk.BLL.tb_remit();
                    lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
                    lgk.BLL.tb_journal journalBLL = new lgk.BLL.tb_journal();

                    var remit = remitBLL.GetModel(remitID);
                    if (remit != null && remit.State == 0)
                    {
                        AllCore allCoreBLL = new AllCore();
                        remit.State = 1;
                        //加入流水账表
                        lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                        jmodel.UserID = remit.UserID;
                        jmodel.Remark = "在线充值E币";
                        jmodel.InAmount = remit.RemitMoney;
                        jmodel.OutAmount = 0;
                        jmodel.BalanceAmount = userBLL.GetModel(Convert.ToInt32(remit.UserID)).Emoney + remit.RemitMoney;
                        jmodel.JournalDate = DateTime.Now;
                        jmodel.JournalType = 2;
                        jmodel.Journal01 = remit.UserID;
                        if (remitBLL.Update(remit) && journalBLL.Add(jmodel) > 0 && allCoreBLL.UpdateSystemAccount("MoneyAccount", remit.RemitMoney, 1) > 0 && allCoreBLL.UpdateAccount("Emoney", remit.UserID, remit.RemitMoney, 1) > 0)
                        {
                            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('确认成功!');", true);
                            Response.Write("交易成功！");
                        }
                        else
                        {
                            Response.Write("充值记录更新失败！");
                            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('确认失败!');", true);
                        }
                    }
                    else
                    {
                        Response.Write("充值记录不存在或信息异常！");
                    }
                }
                else if (attach == "shoppingcar")
                {
                    PayOnline(true);
                }
                Response.End();
            }
        }
        else
        {
            Response.Write("签名不正确！");
        }
    }

    protected string GetOrderID()
    {
        while (1 == 1)
        {
            string code = DateTime.Now.ToString("yyyyMMdd");
            Random rad = new Random();//实例化随机数产生器rad；
            int codeValue = rad.Next(1000, 10000);//用rad生成大于等于1000，小于等于9999的随机数；
            code += codeValue.ToString();

            if (ac.GetOrderID(code) == 0)
            {
                return code;
            }
        }
    }

    /// <summary>
    /// 获取当前登录代理商ID
    /// </summary>
    /// <returns></returns>
    public int getLoginID()
    {
        if (Request.Cookies["A128076_user"] != null)
        {
            return Convert.ToInt32(Request.Cookies["A128076_user"]["Id"]);
        }
        else
        {
            return 0;
        }
    }

    //在线支付成功或失败后，对系统的操作
    protected void PayOnline(bool bresult)
    {
        decimal money = 0;
        decimal jifen = 0;

        DataTable car = (DataTable)Session["A128076_" + getLoginID() + "_ShoppingCar"];

        int rows = car.Rows.Count;
        int count = 0;
        for (int i = 0; i < rows; i++)
        {
            if (Convert.ToInt32(car.Rows[i]["payMent"]) == payment)
            {
                count += Convert.ToInt32(car.Rows[i]["count"]);
                money += Convert.ToDecimal(car.Rows[i]["totalMoney"]);
                jifen += Convert.ToDecimal(car.Rows[i]["totalPV"]);
            }
        }

        bool b = true;
        string orderID = GetOrderID();//形成一条订单记录，存入订单表
        for (int i = 0; i < rows; i++)
        {
            if (Convert.ToInt32(car.Rows[i]["payMent"]) == payment)
            {
                lgk.Model.tb_goods model_goods = ac.goodsBLL.GetModel(Convert.ToInt32(car.Rows[i]["ProcudeID"]));
                if (model_goods.RealityPrice < Convert.ToInt32(car.Rows[i]["count"]))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('【" + model_goods.GoodsName + "】" + ac.GetLanguage("LowStock") + "!');", true);//库存不足
                    b = false;
                    break;
                }
                else
                {
                    lgk.Model.tb_OrderDetail detail = new lgk.Model.tb_OrderDetail()
                    {
                        OrderCode = orderID,
                        ProcudeID = Convert.ToInt32(car.Rows[i]["ProcudeID"]),
                        ProcudeName = car.Rows[i]["procudeName"].ToString(),
                        Price = Convert.ToDecimal(car.Rows[i]["Goods006"]),
                        PV = Convert.ToInt32(car.Rows[i]["Goods002"]),
                        OrderSum = Convert.ToInt32(car.Rows[i]["count"]),
                        OrderTotal = Convert.ToDecimal(car.Rows[i]["totalMoney"]),
                        PVTotal = Convert.ToInt32(car.Rows[i]["totalPV"]),
                        OrderDate = DateTime.Now
                    };
                    if (ac.orderDetailBLL.Add(detail) == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + ac.GetLanguage("AddFailed") + "');", true);//添加失败
                        b = false;
                        break;
                    }
                }
            }
        }
        if (b)
        {
            int OrderType = 5;

            lgk.Model.tb_Order order = new lgk.Model.tb_Order()
            {
                UserID = LoginUser.UserID,
                UserAddr = LoginUser.Address,
                OrderCode = orderID,
                OrderSum = count,
                OrderTotal = money,
                PVTotal = jifen,
                OrderDate = DateTime.Now,
                IsSend = 1,
                PayMethod = 2,
                OrderType = OrderType,
            };
            if (bresult == true)//在线支付成功：添加订单到数据库；返回购物车（清空）
            {
                long id = ac.orderBLL.Add(order);//将订单记录存入订单表
                if (id == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + ac.GetLanguage("OrderToFailed") + "');", true);//添加订单失败
                    b = false;
                    return;
                }
                new lgk.BLL.tb_user().Update(LoginUser);

                ac.add_journal(getLoginID(), 0, jifen, Convert.ToDecimal(LoginUser.Emoney), 5, "购物提交订单", "Submit shopping order", getLoginID());

                Session["NN1405501_" + getLoginID() + "_ShoppingCar"] = null;

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + ac.GetLanguage("TradesSuccessfully") + "');", true);

                //Response.Write("<script>window.open('../../user/shop/shoppingcar.aspx?payment=" + payment + ")</script>");
                Response.Redirect("../user/shop/shoppingcar.aspx?payment=" + payment);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + ac.GetLanguage("TradesFailed") + "');", true);

                Response.Redirect("../user/shop/shoppingcar.aspx?payment=" + payment);//支付失败：不添加订单到数据库；返回购物车（不清空）
            }

        }
    }

}