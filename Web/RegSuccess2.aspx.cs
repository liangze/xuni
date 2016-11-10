using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class RegSuccess2 : AllCore//System.Web.UI.Page
    {
        protected string usercode = "";
        protected string levelname = "";
        protected string RegMoney = "";
        protected string diskaamount = "";
        protected string diskbamount = "";
        protected string gushu = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        private void bind()
        {
            if (Request.QueryString["UserCode"] != null)
            {
                lgk.Model.tb_user model = userBLL.GetModel(GetUserID(getStringRequest("UserCode")));
                usercode = model.UserCode;
                levelname = levelBLL.GetLevelName(model.LevelID);
                RegMoney = model.RegMoney.ToString();
                string shouji = model.PhoneNum.ToString();
                int dx = getParamInt("duanxin");
                if (dx == 1)
                {
                    //短信
                    string DX = System.Configuration.ConfigurationManager.AppSettings["DX"];
                    string DXMM = System.Configuration.ConfigurationManager.AppSettings["DXMM"];
                    string uid = DX.ToString();
                    string auth = DXMM.ToString();
                    string mobile = model.PhoneNum;
                    string url = "http://sms.10690221.com:9011/hy/?uid=" + uid + "&auth=" + auth + "&mobile=" + mobile + "&msg=";

                    //http://ip:port/hy/?uid=1234&auth=faea920f7412b5da7be0cf42b8c93759&mobile=13612345678&msg=hello&expid=0

                    string content = "尊敬的云商会员您好！您的会员账号 " + model.UserCode + " 已经注册成功，祝您生活愉快！。";
                    string neirong = content;
                    System.Text.Encoding encode = System.Text.Encoding.GetEncoding("GBK");
                    content = HttpUtility.UrlEncode(content, encode);
                    url += content;
                    url += "&expid=0";
                    string jieguo = GetHtmlFromUrl(url);
                    string[] jiequ = jieguo.Split(',');
                    lgk.BLL.tb_message m = new lgk.BLL.tb_message();
                    lgk.Model.tb_message M_user = new lgk.Model.tb_message();
                    M_user.Flag = jiequ[0];
                    if (M_user.Flag != "0")
                    {
                        M_user.Mcontent = neirong;
                        M_user.MobileNum = model.PhoneNum;
                        m.Add(M_user);
                        GetHtmlFromUrl(url);
                        string[] jiequ1 = jieguo.Split(',');
                        M_user.Flag = jiequ1[0];
                    }
                    M_user.Mcontent = neirong;
                    M_user.MobileNum = model.PhoneNum;
                    m.Add(M_user);
                }
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        }
        /// <summary>
        /// 短信
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetHtmlFromUrl(string url)
        {
            string a = null;

            if (url == null || url.Trim().ToString() == "")
            {
                return a;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "Get";
                hr.Timeout = 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, System.Text.Encoding.Default);
                a = ser.ReadToEnd();
                Response.Write("<br/>resp=" + ser.ReadToEnd());

            }
            catch (Exception ex)
            {
                a = ex.Message;
            }
            return a;
        }

    }
}