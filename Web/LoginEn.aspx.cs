using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web
{
    public partial class LoginEn : AllCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long iUserID = Convert.ToInt64(Request["UserID"]);

            if (!IsPostBack)
            {
                string host = Request.Url.Host;
                if (Request["name"] != null)
                {
                    //登录另一个域名
                    string UserName = Request.QueryString["name"];
                    lgk.Model.tb_user uModel = userBLL.GetModel(GetUserID(UserName));
                    if (uModel.Password != PageValidate.GetMd5(Request.QueryString["pwd"]))
                    {
                        return;//密码不对
                    }

                    UserUtil.Login(UserName, "A128076_user", false);
                    //放入cookie
                    HttpCookie UserCookie = new HttpCookie("A128076_user");
                    if (Request["id"] == null)
                    {
                        UserCookie["Id"] = GetUserID(UserName).ToString();
                    }
                    else
                    {
                        UserCookie["Id"] = Request.QueryString["id"];
                    }

                    UserCookie["name"] = UserName;
                    Response.AppendCookie(UserCookie);
                    HttpCookie CultureCookie = new HttpCookie("Culture");
                    //CultureCookie.Value = Request.QueryString["lan"];
                    CultureCookie.Value = "zh-cn";
                    Response.AppendCookie(CultureCookie);
                    //Response.Redirect("/HTMLPage1.htm");
                    //Response.Redirect("http://" + host.Replace("www.", "vip.") + "/user/index.aspx");//跳转到会员中心
                    Response.Redirect("/user/index.aspx");
                }
                if (string.IsNullOrEmpty(Request["adminid"]) == false)
                {
                    Security sec = new Security();//解密传递过来的参数
                    string admin = sec.DecryptQueryString(Request["adminid"].ToString());//Request["adminid"].ToString();//
                    RegexR reg = new RegexR();
                    if (reg.Nums(admin) == true)
                    {
                        AdminEnter(admin, iUserID);
                    }
                    else
                    {
                        bindLogin();
                    }
                }
            }
        }

        private void bindLogin()
        {
            if (Session["goto_uid"] != null)
            {
                lgk.Model.tb_user loginuser = userBLL.GetModel(Convert.ToInt64(Session["goto_uid"]));
                //放入cookie
                HttpCookie UserCookie = new HttpCookie("A128076_user");
                UserCookie["Id"] = loginuser.UserID.ToString();
                UserCookie["name"] = loginuser.UserCode;
                Response.AppendCookie(UserCookie);
                Session.Remove("goto_uid");
                Response.Redirect("user/index.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (setBLL.GetModel(1).IsOpenWeb == 0)
            {
                MessageBox.ShowAndRedirect(this, setBLL.GetModel(1).CloseWebRemark, "login.aspx");
            }
            else
            {
                if (this.TBUserName.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Please enter your user name!');", true);
                    return;
                }
                if (this.TBUserName.Value.Trim() == "用户名")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Please enter your user name!');", true);
                    return;
                }
                if (this.TBPassWord.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Please enter your password!');", true);
                    return;
                }
                if (this.TBPassWord.Value.Trim() == "密码")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Please enter your password!');", true);
                    return;
                }
                if (this.TBCode.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Verification code can not be empty!');", true);
                    return;
                }

                string xd = Session["CheckCode"] != null && Session["CheckCode"].ToString() != "" ? Session["CheckCode"].ToString() : "";
                if (xd.ToLower() != TBCode.Value.Trim().ToLower())
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Verification code error!');", true);
                    return;
                }
                lgk.Model.tb_user user = userBLL.GetModel(GetUserID(TBUserName.Value.Trim()));
                if (user == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Account or password is incorrect!');", true);
                    return;
                }
                if (user.Password != PageValidate.GetMd5(TBPassWord.Value))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Account or password is incorrect!');", true);
                    return;
                }
                if (user.IsOpend == 0 || user.IsOpend == 4 || user.IsLock == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Account is not open or is frozen cannot log on!');", true);
                    return;
                }
                string UserName = this.TBUserName.Value.Trim();
                UserUtil.Login(UserName, "A128076_user", false);
                //放入cookie
                HttpCookie UserCookie = new HttpCookie("A128076_user");
                UserCookie["Id"] = user.UserID.ToString();
                UserCookie["name"] = UserName;
                Response.AppendCookie(UserCookie);
                HttpCookie CultureCookie = new HttpCookie("Culture");
                CultureCookie.Value = "en-us";//英文
                Response.AppendCookie(CultureCookie);

                //登录商城
                //Response.Redirect("http://" + Request.Url.Host.Replace("vip.", "www.") + "?name=" + UserName + "&pwd=" + txtPwd.Text + "&lan=" + CultureCookie.Value);
                Response.Redirect("/user/index.aspx");
                //Response.Redirect("/HTMLPage1.htm");
            }
        }

        protected void AdminEnter(string adminid, long iUserID)
        {
            lgk.Model.tb_user user = userBLL.GetModel(iUserID);

            UserUtil.Login(this.TBUserName.Value.Trim(), "A128076_user", false);
            Session["adminid"] = adminid;//管理员以会员身份登陆会员前台页面后，作出标记
            lgk.BLL.SecondPasswordBLL76.AdminId = Convert.ToInt32(adminid);//管理员以会员身份登陆会员前台页面后，作出标记

            //放入cookie
            HttpCookie UserCookie = new HttpCookie("A128076_user");
            UserCookie["Id"] = user.UserID.ToString();
            UserCookie["name"] = Convert.ToString(TBUserName.Value.Trim());
            Response.AppendCookie(UserCookie);
            Response.Redirect("user/index.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user/passwordupdata.aspx");
        }
    }
}