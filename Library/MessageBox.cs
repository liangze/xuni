using System;
using System.Text;
using System.Web.UI;


namespace Library
{
    public class MessageBox
    {
        private MessageBox()
        {
        }

        /// <summary>
        /// 字符串过长采用“...”替换
        /// </summary>
        /// <param name="strText">字符串文本</param>
        /// <param name="Lenght">截取长度</param>
        /// <returns>ellipsis</returns>
        public static string Cut(string strText, int Lenght)
        {
            string ellipsis = strText.Trim();
            if (ellipsis.Length > Lenght)
            {
                ellipsis = strText.Trim().Substring(0, Lenght) + "...";
            }
            return ellipsis;
        }
        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(PageCore page, string msg)//System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }
        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(Page page, string msg)//System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }
        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowMsg(Page page, string msg)//System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert(" + msg.ToString() + ");</script>");
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void MyShow(System.Web.UI.Page page, string msg)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script type=\"text/javascript\" >");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.Append("</script>");
            page.Response.Write(Builder.ToString());
        }
        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            ShowAndRedirect(page, msg, url, "");
        }
        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url, string target)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            if (target != "")
            {
                Builder.AppendFormat(target + ".location.href='{0}'", url);
            }
            else
            {
                Builder.AppendFormat("location.href='{0}'", url);
            }
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }
        /// <summary>
        /// 自定义的弹出框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void CoolShow(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ymPrompt.alert('" + msg.ToString() + "');</script>");
        }
        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");

        }

        public static void CoolShowUrl(System.Web.UI.Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", string.Format("<script language='javascript' defer> ymPrompt.alert('{0}',null,null,'系统提示',function(){window.location.href='{1}'})</script>", msg, url));
        }
    }
}