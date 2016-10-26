﻿/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-14 15:11:17 
 * 文 件 名：		BonusDetail.cs 
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
using System.Data;
using Library;

namespace Web.admin.finance
{
    public partial class BonusDetail : AdminPageBase//System.Web.UI.Page
    {
        private string strWhere = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 14, getLoginID());//权限

            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            bind_repeater(bo.GetList_money(GetWhere()), Repeater1, "SttleTime desc", trBonusNull, AspNetPager1);
        }

        private string GetWhere()
        {
            string SttleTime = Request.QueryString["SttleTime"].ToString();
            strWhere = string.Format(" b.Amount > 0 and Convert(nvarchar(10),SttleTime,120)='" + SttleTime + "'");
            if (this.txtUserCode.Text != "")
            {
                strWhere += " and u.UserCode LIKE '%" + this.txtUserCode.Text + "%'";
            }
            if (this.txtTrueName.Text != "")
            {
                strWhere += " and u.TrueName LIKE '%" + this.txtTrueName.Text + "%'";
            }
            return strWhere;
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long iUserID = Convert.ToInt32(e.CommandArgument);
            string SttleTime = Request.QueryString["SttleTime"].ToString();
            if (e.CommandName.Equals("Open"))
            {
                Response.Redirect("BonusDetails.aspx?UserID=" + iUserID + "&SttleTime=" + SttleTime);
            }
        }
    }
}
