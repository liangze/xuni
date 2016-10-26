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

public partial class Redirect : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    //提交地址
    //    string form_url;
    //    if (Request.Form["test"] == "1")
    //    {
    //        form_url = "https://pay.ips.net.cn/ipayment.aspx"; //测试
    //    }
    //    else
    //    {
    //        form_url = "https://pay.ips.com.cn/ipayment.aspx"; //正式
    //    }

    //    //商户号
    //    string Mer_code = Request.Form["Mer_code"];

    //    //商户证书：登陆http://merchant.ips.com.cn/商户后台下载的商户证书内容
    //    string Mer_key = Request.Form["Mer_key"];

    //    //商户订单编号
    //    string Billno = Request.Form["Billno"];

    //    //订单金额(保留2位小数)
    //    string Amount = Convert.ToString(Math.Round(decimal.Parse(Request.Form["Amount"]), 2));
        
    //    //订单日期
    //    string BillDate = Request.Form["Date"];

    //    //币种
    //    string Currency_Type = Request.Form["Currency_Type"];


        

    //    //支付卡种
    //    string Gateway_Type = Request.Form["Gateway_Type"];

    //    //语言
    //    string Lang = Request.Form["Lang"];

    //    //支付结果成功返回的商户URL
    //    string Merchanturl = Request.Form["Merchanturl"];

    //    //支付结果失败返回的商户URL
    //    string FailUrl = Request.Form["FailUrl"];

    //    //支付结果错误返回的商户URL
    //    string ErrorUrl = Request.Form["ErrorUrl"];

    //    //商户数据包
    //    string Attach = Request.Form["Attach"];

    //    //显示金额
    //    string DispAmount = Request.Form["DispAmount"];

    //    //订单支付接口加密方式
    //    string OrderEncodeType = Request.Form["OrderEncodeType"];

    //    //交易返回接口加密方式 
    //    string RetEncodeType = Request.Form["RetEncodeType"];

    //    //返回方式
    //    string Rettype = Request.Form["Rettype"];

    //    //Server to Server 返回页面URL
    //    string ServerUrl = Request.Form["ServerUrl"];

    //    //订单支付接口的Md5摘要，原文=订单号+金额+日期+支付币种+商户证书 
    //    string SignMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Billno +Currency_Type+ Amount + BillDate +OrderEncodeType+ Mer_key, "MD5").ToLower();

    //    string postForm = "<form name=\"frm1\" id=\"frm1\" method=\"post\" action=\"" + form_url + "\">";

    //    postForm += "<input type=\"hidden\" name=\"Mer_code\" value=\"" + Mer_code + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"Billno\" value=\"" + Billno + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"Amount\" value=\"" + Amount + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"Date\" value=\"" + BillDate + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"Currency_Type\" value=\"" + Currency_Type + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"Gateway_Type\" value=\"" + Gateway_Type + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"Lang\" value=\"" + Lang + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"Merchanturl\" value=\"" + Merchanturl + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"FailUrl\" value=\"" + FailUrl + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"ErrorUrl\" value=\"" + ErrorUrl + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"Attach\" value=\"" + Attach + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"DispAmount\" value=\"" + DispAmount + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"OrderEncodeType\" value=\"" + OrderEncodeType + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"RetEncodeType\" value=\"" + RetEncodeType + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"Rettype\" value=\"" + Rettype + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"ServerUrl\" value=\"" + ServerUrl + "\" />";
    //    postForm += "<input type=\"hidden\" name=\"SignMD5\" value=\"" + SignMD5 + "\" />";
    //    postForm += "</form>";

    //    //自动提交该表单到测试网关
    //    postForm += "<script type=\"text/javascript\" language=\"javascript\">setTimeout(\"document.getElementById('frm1').submit();\",100);</script>";

    //    Session["remitmoney"] = Amount;
    //    if (Request.Form["txtusercode"] != null)
    //    {
    //        string usercode = Request.Form["txtusercode"];
    //        Session["1277openduser"] = usercode;
    //    }
    //    Response.Write(postForm);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        //提交地址
        string form_url;
        if (Request.Form["test"] == "1")
        {
            form_url = "http://pay.ips.net.cn/ipayment.aspx"; //测试
        }
        else
        {
            form_url = "https://pay.ips.com.cn/ipayment.aspx"; //正式
        }


        //商户号
        string Mer_code = Request.Form["Mer_code"];

        //商户证书：登陆http://merchant.ips.com.cn/商户后台下载的商户证书内容
        string Mer_key = Request.Form["Mer_key"];

        //商户订单编号
        string Billno = Request.Form["Billno"];

        //订单金额(保留2位小数)
        string Amount = Convert.ToString(Math.Round(decimal.Parse(Request.Form["Amount"]), 2));

        //订单日期
        string BillDate = Request.Form["Date"];

        //币种
        string Currency_Type = Request.Form["Currency_Type"];

        //支付卡种
        string Gateway_Type = Request.Form["Gateway_Type"];

        //语言
        string Lang = Request.Form["Lang"];

        //支付结果成功返回的商户URL
        string Merchanturl = Request.Form["Merchanturl"];

        //支付结果失败返回的商户URL
        string FailUrl = Request.Form["FailUrl"];

        //支付结果错误返回的商户URL
        string ErrorUrl = Request.Form["ErrorUrl"];

        //商户数据包
        string Attach = Request.Form["Attach"];

        //显示金额
        string DispAmount = Request.Form["DispAmount"];

        //订单支付接口加密方式
        string OrderEncodeType = Request.Form["OrderEncodeType"];

        //交易返回接口加密方式 
        string RetEncodeType = Request.Form["RetEncodeType"];

        //返回方式
        string Rettype = Request.Form["Rettype"];

        //Server to Server 返回页面URL
        string ServerUrl = Request.Form["ServerUrl"];

        //订单支付接口的Md5摘要， 原文=billno+订单编号+ currencytype +币种+ amount +订单金额+ date +订单日期+ orderencodetype +订单支付接口加密方式+商户内部证书字符串
        string SignMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("billno" + Billno + "currencytype" + Currency_Type + "amount" + Amount + "date" + BillDate + "orderencodetype" + OrderEncodeType + Mer_key, "MD5").ToLower();

        string postForm = "<form name=\"frm1\" id=\"frm1\" method=\"post\" action=\"" + form_url + "\">";

        postForm += "<input type=\"hidden\" name=\"Mer_code\" value=\"" + Mer_code + "\" />";
        postForm += "<input type=\"hidden\" name=\"Billno\" value=\"" + Billno + "\" />";
        postForm += "<input type=\"hidden\" name=\"Amount\" value=\"" + Amount + "\" />";
        postForm += "<input type=\"hidden\" name=\"Date\" value=\"" + BillDate + "\" />";
        postForm += "<input type=\"hidden\" name=\"Currency_Type\" value=\"" + Currency_Type + "\" />";
        postForm += "<input type=\"hidden\" name=\"Gateway_Type\" value=\"" + Gateway_Type + "\" />";
        postForm += "<input type=\"hidden\" name=\"Lang\" value=\"" + Lang + "\" />";
        postForm += "<input type=\"hidden\" name=\"Merchanturl\" value=\"" + Merchanturl + "\" />";
        postForm += "<input type=\"hidden\" name=\"FailUrl\" value=\"" + FailUrl + "\" />";
        postForm += "<input type=\"hidden\" name=\"ErrorUrl\" value=\"" + ErrorUrl + "\" />";
        postForm += "<input type=\"hidden\" name=\"Attach\" value=\"" + Attach + "\" />";
        postForm += "<input type=\"hidden\" name=\"DispAmount\" value=\"" + DispAmount + "\" />";
        postForm += "<input type=\"hidden\" name=\"OrderEncodeType\" value=\"" + OrderEncodeType + "\" />";
        postForm += "<input type=\"hidden\" name=\"RetEncodeType\" value=\"" + RetEncodeType + "\" />";
        postForm += "<input type=\"hidden\" name=\"Rettype\" value=\"" + Rettype + "\" />";
        postForm += "<input type=\"hidden\" name=\"ServerUrl\" value=\"" + ServerUrl + "\" />";
        postForm += "<input type=\"hidden\" name=\"SignMD5\" value=\"" + SignMD5 + "\" />";
        postForm += "</form>";

        //自动提交该表单到测试网关
        postForm += "<script type=\"text/javascript\" language=\"javascript\">setTimeout(\"document.getElementById('frm1').submit();\",100);</script>";

        Response.Write(postForm);
    }
}
