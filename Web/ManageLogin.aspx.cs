/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-2-4 16:48:14 
 * 文 件 名：		ManageLogin.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web
{
    public partial class ManageLogin : AllCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (this.txtUserName.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入用户名!');", true);
                //MessageBox.Show(this, "请输入用户名!");
                return;
            }
            if (this.txtUserName.Value.Trim() == "用户名")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入用户名!');", true);
                //MessageBox.Show(this, "请输入用户名!");
                return;
            }
            if (this.txtPwd.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入密码!');", true);
                //MessageBox.Show(this, "请输入密码!");
                return;
            }
            //if (this.txtfield.Text == "")
            //{
            //    MessageBox.Show(this, "验证码不能为空!");
            //    return;
            //}
            if (!ExistsAdmin(txtUserName.Value.Trim(), PageValidate.GetMd5(txtPwd.Value.Trim())))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('账号或密码错误!');", true);
                //MessageBox.Show(this, "账号或密码错误");
                return;
            }
            //string xd = Session["CheckCode"] != null && Session["CheckCode"].ToString() != "" ? Session["CheckCode"].ToString() : "";
            //if (xd.ToLower() != txtfield.Text.ToLower())
            //{
            //    MessageBox.Show(this, "验证码错误");
            //    return;
            //}
            lgk.Model.tb_admin admin = adminBLL.GetModel(txtUserName.Value.Trim());
            //if (admin.Limits == null)
            //{
            //    MessageBox.Show(this, "您的权限不足，请联系超级管理员");
            //    return;
            //}
            UserUtil.Login(this.txtUserName.Value.Trim(), "A128076_admin", false);
            //放入cookie
            HttpCookie UserCookie = new HttpCookie("A128076_admin");
            DataSet ds = GetAdminModel(txtUserName.Value, PageValidate.GetMd5(txtPwd.Value));
            UserCookie["Id"] = ds.Tables[0].Rows[0]["ID"].ToString();
            UserCookie["name"] = Convert.ToString(txtUserName.Value);
            Response.AppendCookie(UserCookie);
            Response.Redirect("admin/index.aspx");
        }
    }
}
