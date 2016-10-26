/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-7-15 11:46:41 
 * 文 件 名：		Member.cs 
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

namespace Web.user.team
{
    public partial class Member : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码
            if (!IsPostBack)
            {
                BindLevel();
                BindData();
            }
            btnSearch.Text = GetLanguage("Determine");//确定
        }

        public string getColumn2(int type)
        {
            string bi = "";
            int typer = agentBLL.GetModel("userid=" + type).AgentType;
            if (typer == 1)
            {
                bi = "一级服务中心";
            }
            else if (typer == 2)
            {
                bi = "二级服务中心";
            }
            else if (typer == 3)
            {
                bi = "三级服务中心";
            }
            return bi;
        }

        #region 绑定用户級別
        /// <summary>
        /// 绑定用户級別
        /// </summary>
        private void BindLevel()
        {
            if (currentCulture == "zh-cn")
            {
                dropType.Items.Add(new ListItem("-请选择-", "0"));
                dropType.Items.Add(new ListItem("会员编号", "1"));
                dropType.Items.Add(new ListItem("会员姓名", "2"));
            }
            else
            {
                dropType.Items.Add(new ListItem("-Please choose-", "0"));
                dropType.Items.Add(new ListItem("Member number", "1"));
                dropType.Items.Add(new ListItem("Member name", "2"));
            }

            //IList<lgk.Model.tb_level> ddlList = new lgk.BLL.tb_level().GetModelList(" LevelID<6 ");
            //dropLevel.Items.Clear();
            //ListItem li = new ListItem();
            //li.Value = "0";
            //li.Text = GetLanguage("PleaseSselect");//"-请选择-"
            //dropLevel.Items.Add(li);
            //foreach (lgk.Model.tb_level item in ddlList)
            //{
            //    ListItem items = new ListItem();
            //    items.Value = item.LevelID.ToString();
            //    if (currentCulture == "en-us")
            //    {
            //        items.Text = item.level03;
            //    }
            //    else
            //    {
            //        items.Text = item.LevelName;
            //    }
            //    dropLevel.Items.Add(items);
            //}
        } 
        #endregion

        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "";
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            strWhere = " IsOpend=0 and AgentsID=" + Loginagent.ID;
            if (this.dropType.SelectedValue != "0")
            {
                if (this.dropType.SelectedValue == "1")
                {
                    strWhere += " and usercode like  '%" + this.txtInput.Value.Trim() + "%'";
                }
                if (this.dropType.SelectedValue == "2")
                {
                    strWhere += " and truename like  '%" + this.txtInput.Value.Trim() + "%'";
                }
            }
            //if (this.dropLevel.SelectedValue != "0" && this.dropLevel.SelectedValue != "")
            //{
            //    strWhere += " and LevelID=" + dropLevel.SelectedValue;
            //}
            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RegTime,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  between '" + strStartTime + "' and '" + strEndTime + "'");
            }
            return strWhere;
        }

        /// <summary>
        /// 填充申请记录
        /// </summary>
        private void BindData()
        {
            bind_repeater(userBLL.GetList(GetWhere()), Repeater1, "RegTime desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 搜索申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 审核分页申请记录
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long UserID = long.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_user model = userBLL.GetModel(UserID);
            if (model == null)
            {
                MessageBox.MyShow(this, GetLanguage("MemberDelete"));//该会员已删除,无法再进行此操作
                return;
            }
            if (model.IsOpend != 0)
            {
                MessageBox.MyShow(this, GetLanguage("MemberActivated"));//该会员已激活,无法再进行此操作
                return;
            }
            if (e.CommandName.Equals("open"))//
            {
                AllCore acore = new AllCore();//1收入2支出
                
                //开通会员检查
                int i = acore.OpenCheck(model);
                if (i != 0)
                {
                    MessageBox.MyShow(this, acore.OpenCheckErrorMsg(i));
                    return;
                }
                if (flag_open(UserID, 2) > 0)
                {
                    acore.add_userRecord(model.UserCode, DateTime.Now, model.RegMoney, 2);
                    MessageBox.MyShow(this, GetLanguage("OpenSuccess"));//开通成功
                }
                else 
                {
                    MessageBox.MyShow(this, GetLanguage("FailedToOpen")); //开通失败
                }
            }
            //if (e.CommandName.Equals("open1"))//
            //{
            //    model.IsOpend = 3;//空单3 实单 2
            //    model.OpenTime = DateTime.Now;
            //    model.User008 = "空单";
            //    if (userBLL.Update(model))
            //    {
            //        //AllCore acore = new AllCore();//1收入2支出
            //        //acore.add_userRecord(model.UserCode, DateTime.Now, 0, 2);
            //        MessageBox.MyShow(this, "开通空单成功!");
            //    }
            //    else { MessageBox.MyShow(this, "开通失败!"); }
            //}
            if (e.CommandName.Equals("Remove"))//删除
            {
                //返回注册金额
                //var user = userBLL.GetModel(UserID);
                //var agent = agentBLL.GetModel(user.AgentsID);
                //var data = userBLL.GetModel(agent.UserID);
                //data.Emoney = data.Emoney + user.RegMoney;
                if ( flag_delete(UserID) > 0)
                {
                    MessageBox.MyShow(this, GetLanguage("DeletedSuccessfully"));//删除成功
                }
                else
                {
                    MessageBox.MyShow(this, GetLanguage("DeleteFailed"));//删除失败
                }
            }
            BindData();
        }

        /// <summary>
        /// 分页申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}