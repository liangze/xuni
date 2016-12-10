using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.IO;

namespace Web
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string GetHtmlFromUrl(string url)
        {
            string strRet = null;

            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "Get";
                hr.Timeout =  1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, System.Text.Encoding.Default);
                Response.Write("<br/>resp=" + ser.ReadToEnd());
            }
            catch (Exception ex)
            {
                strRet = null;
            }
            return strRet;
        } 

        protected void Button2_Click(object sender, EventArgs e)
        {
            string DX = System.Configuration.ConfigurationManager.AppSettings["DX"];
            string DXMM = System.Configuration.ConfigurationManager.AppSettings["DXMM"];
            string uid = DX.ToString();
            string auth = DXMM.ToString();
            string mobile = "15778024437";
            string url = "http://sms.10690221.com:9011/hy/?uid=" + uid + "&auth=" + auth + "&mobile=" + mobile + "&msg=";

            //http://ip:port/hy/?uid=1234&auth=faea920f7412b5da7be0cf42b8c93759&mobile=13612345678&msg=hello&expid=0

            string content = "这是一条测试信息。";
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("GBK");
            content = HttpUtility.UrlEncode(content, encode);
            url += content;
            url += "&expid=0";


            Response.Write(url);
            GetHtmlFromUrl(url);
        }
    }
   
}