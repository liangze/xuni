﻿/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-11-29 10:38:24 
 * 文 件 名：		dl_BonusDetail.cs 
 * CLR 版本: 		2.0.50727.3643 
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

namespace Web.admin.finance
{
    public partial class dl_BonusDetail : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 15, getLoginID());//权限
            //if (Session["a_pass"] == null)
            //{
            //    spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            //    Session["a_pass"] = "on";
            //}
            if (!IsPostBack)
            {
                bind();
            }
        }
        private void bind()
        {
            bind_repeater(bo.GetList_money(getWhere()), Repeater1, "SttleTime desc", trBonusNull, AspNetPager1);
        }

        private string getWhere()
        {
            string SttleTime = Request.QueryString["SttleTime"].ToString();
            string strWhere = string.Format(" b.Amount<>0 and b.Bonus001=2 and Convert(nvarchar(10),SttleTime,120)='" + SttleTime + "'");
            if (this.txtUserCode.Text != "")
            {
                strWhere += " and u.usercode like '%" + this.txtUserCode.Text + "%'";
            }
            if (this.txtTrueName.Text != "")
            {
                strWhere += " and u.truename like '%" + this.txtTrueName.Text + "%'";
            }
            return strWhere;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int userid = Convert.ToInt32(e.CommandArgument);
            string SttleTime = Request.QueryString["SttleTime"].ToString();
            if (e.CommandName.Equals("Open"))
            {
                Response.Redirect("dl_BonusDetails.aspx?userid=" + userid + "&SttleTime=" + SttleTime);
            }
        }
    }
}
