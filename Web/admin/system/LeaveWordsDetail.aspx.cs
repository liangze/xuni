﻿/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-19 17:15:27 
 * 文 件 名：		LeaveWordsDetail.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		
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
using System.Data;

namespace web.admin.system
{
    public partial class LeaveWordsDetail : AdminPageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 23, getLoginID());//权限
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "")
                {
                    BindData(Request.QueryString["id"]);
                    BindReply(Request.QueryString["id"]);
                    if (Request.QueryString["type"] == "1")
                    {
                        UpdateState(Request.QueryString["id"]);
                    }

                }
            }
        }

        /// <summary>
        /// 填充回复
        /// </summary>
        /// <param name="id">回复的id</param>
        protected void BindReply(string id)
        {
            bind_repeater(leaveReMsgBLL.GetList("LeaveID=" + id), rpReply, "ReTime desc", divNull, anpReply);
        }

        /// <summary>
        /// 填充留言表
        /// </summary>
        /// <param name="id">显示的留言id</param>
        protected void BindData(string id)
        {
            long value = 0;
            if (long.TryParse(id, out value))
            {
                lgk.Model.tb_leaveMsg leaveMsg = leaveMsgBLL.GetModel(value);
                lblSendTitle.Text = leaveMsg.MsgTitle;
                lblSendContent.Text = leaveMsg.MsgContent.ToString();
                lblSendDate.Text = leaveMsg.LeaveTime.ToString("yyyy-MM-dd HH:mm:ss");
                if (leaveMsg.FromUserType == 1)
                {
                    lgk.Model.tb_user user = userBLL.GetModel(Convert.ToInt64(leaveMsg.UserID));
                    lblSendMember.Text = user.UserCode;
                }
                else
                {
                    lgk.Model.tb_admin admin = adminBLL.GetModel(Convert.ToInt32(leaveMsg.UserID));
                    lblSendMember.Text = admin.UserName;
                }
            }
        }

        /// <summary>
        /// 回复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRepeat_Click(object sender, EventArgs e)
        {
            if (txtPubContext.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "msgShow('系统提示','回复内容不能为空','info');", true);
                return;
            }
            lgk.Model.tb_admin admin = adminBLL.GetModel(getLoginID());
            lgk.Model.tb_leaveReMsg leaveReMsg = new lgk.Model.tb_leaveReMsg();
            leaveReMsg.LeaveID = Convert.ToInt64(Request.QueryString["id"]);
            leaveReMsg.UserType = 2;
            leaveReMsg.UserID = admin.ID;
            leaveReMsg.UserCode = admin.UserName;
            leaveReMsg.ReContent = txtPubContext.Text;
            leaveReMsg.ReTime = DateTime.Now;
            if (leaveReMsgBLL.Add(leaveReMsg) > 0 && UpdateState(leaveReMsg.LeaveID, "IsReply") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "msgShow('系统提示','回复成功!','info');", true);
                txtPubContext.Text = "";
                BindData(getStringRequest("id"));
                BindReply(getStringRequest("id"));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "msgShow('系统提示','回复失败!','info');", true);
            }
        }

        /// <summary>
        /// 更新是否已读状态
        /// </summary>
        /// <param name="id"></param>
        protected void UpdateState(string id)
        {
            UpdateState(Convert.ToInt64(id), "IsRead");
        }
        /// <summary>
        /// 获得编号
        /// </summary>
        /// <param name="userid">会员id</param>
        /// <returns>编号</returns>
        protected string GetUserCode(string userid, int type)
        {
            if (type == 1)
            {
                lgk.Model.tb_user user = userBLL.GetModel(Convert.ToInt64(userid));
                return user.UserCode;
            }
            else
            {
                lgk.Model.tb_admin admin = adminBLL.GetModel(int.Parse(userid));
                return "【管理员】" + admin.UserName;
            }
        }

        /// <summary>
        /// 分页控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void anpReply_PageChanged(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != "")
            {
                BindReply(Request.QueryString["id"]);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (getIntRequest("type")==1)
            {
                Response.Redirect("LeaveIn.aspx");
            }
            else
            {
                Response.Redirect("LeaveOut.aspx");
            }
            
        }

    }
}
