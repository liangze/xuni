﻿/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-19 18:57:30 
 * 文 件 名：		Leavewords.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		黎胜刚
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace web.user.member
{
    public partial class Leavewords : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.Text = GetLanguage("Submit");//提交
                btnBack.Text = GetLanguage("Return");//返回
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtTitle.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TitleIsNull") + "');", true);//标题不能为空
                return;
            }
            if (txtPubContext.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ContentIsNull") + "');", true);//内容不能为空
                return;
            }

            lgk.Model.tb_leaveMsg leaveMsg = new lgk.Model.tb_leaveMsg()
            {
                MsgTitle = txtTitle.Value,
                MsgContent = txtPubContext.Text,
                LeaveTime = DateTime.Now,
                IsRead = 0,
                IsReply = 0,
                FromUserType = 1,
                UserID = LoginUser.UserID,
                UserCode = LoginUser.UserCode,
                FromIDIsDel = 0,
                ToIDIsDel = 0,
                ToUserID = 1,
                ToUserType = 2,
                ToUserCode = "admin"

            };

            if (leaveMsgBLL.Add(leaveMsg) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("SentSuccessfully") + "');window.location.href='LeaveOut.aspx';", true);//发送成功
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("SendFailed") + "');", true);//发送失败
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveOut.aspx");
        }
    }
}
