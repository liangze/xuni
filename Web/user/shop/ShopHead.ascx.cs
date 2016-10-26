using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.shop
{
    public partial class ShopHead : System.Web.UI.UserControl
    {
        AllCore ac = new AllCore();
        public string loginbtn = "zh-cn";
        public string Url { set; get; }
        public string Domain = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Url == null)
            {
                Url = "index";
            }
            string host = Request.Url.Host;
            Domain = host.Replace("www.","");

            GetAllLanguage();
        }

        public void GetAllLanguage()
        {
            if (ac == null)
            {
                return;
            }
            Label1.Text = ac.GetLanguage("MyRegister");
            LogOutLab.Text = ac.GetLanguage("Exit");
            MemberLab.Text = ac.GetLanguage("Member");
            Label4.Text = ac.GetLanguage("UserName");
            Label5.Text = ac.GetLanguage("ShopPassword");
            loginbtn = ac.GetLanguage("LoginLable");
        }
    }
}