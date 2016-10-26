/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-1-13 12:28:53 
 * 文 件 名：		OrderPayment1.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		浪迹天涯
 * 文件版本：		1.0
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml.Linq;

namespace Web.IPS
{
    public partial class OrderPayment1 : System.Web.UI.Page
    {
        public string ConfirmHtml { get; set; }

        private const string TESTING_ENVIRONMENT = "Testing";
        private const string OFFICIAL_ENVIRONMENT = "Official";
        private const string CONFIG_FILE = @"~/IPS/Config.xml";
        XDocument xDoc = null;
        string sAttach = "";
        string ActualAmount = "";
        string DealAmount = "";
        string PayRatio = "";
        string usercode="";

   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //显示确认支付信息
                ActualAmount = Request["Amount"];//实际金额
                usercode = Request["1277openduser"];
                //DealAmount= Request["Deal"];//应付金额
                //PayRatio = Request["PayRatio"];//支付比例
                sAttach = Request["Attach"];//附加信息

                ConfirmHtml += string.Format("<div>支付金额:{0}</div>", ActualAmount);
                ConfirmHtml += string.Format("<div>开通用户编号:{0}</div>", usercode);
                //ConfirmHtml += string.Format("<div>应付金额:{0}</div>", ActualAmount);
               



                //加载配置项目
                xDoc = XDocument.Load(Server.MapPath(CONFIG_FILE));

                //订单日期
                Date.Value = DateTime.Now.ToString("yyyyMMdd");
                //订单号
                Random rand = new Random();
                string strNewUrl = Request.Url.ToString().ToLower().Replace("/ips/", "/");//取得当前的外网
                strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径

                Billno.Value = DateTime.Now.ToString("yyyyMMddhhmmss") + rand.Next(10000, 99999);
                txtusercode.Value = usercode;
                //成功返回页面
                Merchanturl.Value = strNewUrl+"rgsus.aspx";
                //失败返回页面
                FailUrl.Value = strNewUrl + "IPS/OrderError.aspx"; ;
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
    }
}
