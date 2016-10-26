/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-2-6 10:06:29 
 * 文 件 名：		SecondPassword.cs 
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

namespace Web.admin
{
    public partial class SecondPassword : AllCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["tpurl"] = "no";

            txtsecondPassword.Focus();
        }
        /// <summary>
        /// 获取当前登录会员ID
        /// </summary>
        /// <returns></returns>
        public int getLoginID()
        {
            if (Request.Cookies["A128076_admin"] != null)
            {
                return Convert.ToInt32(Request.Cookies["A128076_admin"]["Id"]);
            }
            else
            {
                return 0;
            }
        }

        protected void btn_s_Click(object sender, EventArgs e)
        {
            if (txtsecondPassword.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入二级密码!');", true);
                return;
            }
            string Md5Password = PageValidate.GetMd5(txtsecondPassword.Text.Trim());
            spd.rejumpUrl_byAdmin06(this.Page, Md5Password, getLoginID());
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('密码输入错误!');", true);
            txtsecondPassword.Focus();
        }
    }
}
