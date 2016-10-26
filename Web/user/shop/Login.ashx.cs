using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library;
using System.Web.SessionState;

namespace Web.user.shop
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : AllCore, IHttpHandler, IRequiresSessionState
    {
        public override void ProcessRequest(HttpContext context)
        {
            string userCode = context.Request["ucode"] == null ? "" : context.Request["ucode"].ToString();
            string pwd = context.Request["pwd"] == null ? "" : context.Request["pwd"].ToString();
            bool isLogin = context.Request.Cookies["A128076_user"] != null;
            int returnparam = isLogin?0:2;
            if (!string.IsNullOrEmpty(userCode) && !string.IsNullOrEmpty(pwd))
            {
                returnparam = UserLogin(userCode, pwd, context);
            }
            context.Response.ClearContent();
            context.Response.ContentType = "text/plain";
            context.Response.Write(returnparam);
        }

        public  bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="ucode"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int UserLogin(string ucode, string pwd, HttpContext context)
        {
            ucode = HtmlEncode(ucode);
            if (setBLL.GetModel(1).IsOpenWeb == 0)
            {
                MessageBox.ShowAndRedirect(this, setBLL.GetModel(1).CloseWebRemark, "login.aspx");
            }
            else
            {
                int num = ConvertToInt(Session["num"]);
                if (num >= 3)
                {
                    return 4;
                }
                lgk.Model.tb_user user = userBLL.GetModel(GetUserID(ucode));
                if (user == null)
                {
                    return 1;//用户不存在
                }
                if (user.Password != PageValidate.GetMd5(pwd))
                {
                    num++;
                    Session["num"] = num;
                    return 2;//用户名密码错误
                }
                if (user.IsOpend == 0 || user.IsOpend == 4 || user.IsLock == 1)
                {
                    return 3;//账号未开通或已冻结不能登录
                }
                Session["num"] = 0;
                string url = HttpContext.Current.Request.Url.ToString().ToLower().Replace("http://www", "").Replace("http://vip", "");
                url = url.Substring(0, url.IndexOf("/"));
                UserUtil.Login(ucode, "A128076_user", false);
                //放入cookie
                HttpCookie UserCookie = new HttpCookie("A128076_user");
                UserCookie["Id"] = user.UserID.ToString();
                UserCookie["name"] = Convert.ToString(ucode);
                //UserCookie.Domain = url;
                context.Response.AppendCookie(UserCookie);
                // context.Response.Redirect("index.aspx");
            }
            return 0;
        }

        /// <summary>
        /// 替换html文本
        /// </summary>
        /// <param name="theString"></param>
        /// <returns></returns>
        public static string HtmlEncode(string theString)
        {
            theString = theString.Replace(">", "&gt;");
            theString = theString.Replace("<", "&lt;");
            theString = theString.Replace(" ", " &nbsp;");
            theString = theString.Replace(" ", " &nbsp;");
            theString = theString.Replace("\"", "&quot;");
            theString = theString.Replace("\'", "&#39;");
            theString = theString.Replace("\n", "<br/> ");
            theString = theString.Replace("select", "");
            theString = theString.Replace("insert", "");
            theString = theString.Replace("update", "");
            theString = theString.Replace("delete", "");
            theString = theString.Replace("'", "");
            return theString;
        }
    }
}