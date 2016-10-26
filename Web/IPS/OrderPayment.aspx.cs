/*********************************************************************************
* Copyright(c)  	2011 ZXHLRJ.COM
 * 创建日期：		2011-12-24 14:31:57 
 * 文 件 名：		OrderPayment.cs 
 * CLR 版本: 		2.0.50727.3625 
 * 创 建 人：		黄炳仪
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using Web.user.shop;
using System.Xml.Linq;

namespace ThirdPartyPaymentExample.IPS
{
    /// <summary>
    /// 环迅支付接口页面
    /// 
    /// </summary>
    public partial class OrderPayment : System.Web.UI.Page
    {
        AllCore ac = new AllCore();
        public string ConfirmHtml { get; set; }

        private const string TESTING_ENVIRONMENT = "Testing";
        private const string OFFICIAL_ENVIRONMENT = "Official";
        private const string CONFIG_FILE = @"~/IPS/Config.xml";
        XDocument xDoc = null;
        string sAttach = "";
        string ActualAmount = "";
        string DealAmount = "";
        string PayRatio = "";
        string usercode = "";
        string aeq = "";//编号
        int payment = 1;//支付方式：1-积分支付；2-E币支付

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                payment = shoppingcar.payment;//Convert.ToInt32(Request["payment"]);

                //显示确认支付信息
                ActualAmount = Request["Amount"];//实际金额
                //usercode = Request["1277openduser"];
                //DealAmount= Request["Deal"];//应付金额
                //PayRatio = Request["PayRatio"];//支付比例
                sAttach = Request["Attach"];//附加信息
                aeq = Request["aeq"];//充值记录编号
                long id = 0;
                long.TryParse(aeq, out id);

                if (sAttach == "remit")
                {
                    lgk.BLL.tb_remit remitBLL = new lgk.BLL.tb_remit();//充值记录表对象
                    var model = remitBLL.GetModel(id);

                    ConfirmHtml += string.Format("<div>支付金额:{0}</div>", ActualAmount);
                    //ConfirmHtml += string.Format("<div>开通用户编号:{0}</div>", usercode);
                    //ConfirmHtml += string.Format("<div>应付金额:{0}</div>", ActualAmount);

                    //订单日期
                    Date.Value = DateTime.Now.ToString("yyyyMMdd");
                    //订单号
                    Random rand = new Random();
                    Billno.Value = DateTime.Parse(model.AddDate.ToString()).ToString("yyyyMMddhhmmss") + rand.Next(10000, 99999) + model.ID;
                }
                else
                {
                    //string orderID = GetOrderID();//获取订单编号

                    ConfirmHtml += string.Format("<div>支付金额:{0}</div>", ActualAmount);
                    //订单日期
                    Date.Value = DateTime.Now.ToString("yyyyMMdd");
                    //订单号
                    Random rand = new Random();
                    Billno.Value = DateTime.Now.ToString("yyyyMMddhhmmss") + rand.Next(10000, 99999);
                }

                //加载配置项目
                xDoc = XDocument.Load(Server.MapPath(CONFIG_FILE));
                //txtusercode.Value = usercode;
                string strNewUrl = Request.Url.ToString().ToLower().Replace("/ips/", "/");//取得当前的外网
                strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
                //成功返回页面
                Merchanturl.Value = strNewUrl + "IPS/OrderReturn.aspx";
                //失败返回页面
                FailUrl.Value = strNewUrl + "IPS/OrderError.aspx";
                //错误返回页面
                ErrorUrl.Value = strNewUrl + "IPS/OrderError.aspx";
                //环迅环境
                string environment = xDoc.Element("Root").Element("Environment").Value;
                test.Value = environment.Equals(TESTING_ENVIRONMENT) ? "1" : "0";
                //商户帐号
                XElement xEle = xDoc.Descendants("IPS").SingleOrDefault(t => t.Attribute("name").Value.Equals(environment));
                Mer_code.Value = xEle.Element("Account").Value;
                //商户证书
                Mer_key.Value = xEle.Element("Certificate").Value;
                //交易金额
                Amount.Value = ActualAmount.ToString();
                //显示金额 
                DispAmount.Value = Amount.Value;
                //支付币种
                Currency_Type.Value = xDoc.Element("Root").Element("CurrencyType").Value;
                //支付方式
                Gateway_Type.Value = xDoc.Element("Root").Element("GatewayType").Value;
                //界面语言
                Lang.Value = xDoc.Element("Root").Element("Lang").Value;
                //附加信息
                Attach.Value = sAttach;
                //支付加密方式
                OrderEncodeType.Value = xDoc.Element("Root").Element("OrderEncodeType").Value;
                //返回加密方式
                RetEncodeType.Value = xDoc.Element("Root").Element("RetEncodeType").Value;
                //Server返回方式
                Rettype.Value = xDoc.Element("Root").Element("Rettype").Value;
                //Server返回页面
                ServerUrl.Value = xDoc.Element("Root").Element("ServerUrl").Value;
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

    }
}
