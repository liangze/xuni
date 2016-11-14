using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin.team
{
    public partial class EmptyUpgrade1 : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 10, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码
            if (!IsPostBack)
            {
                BindLevel();
                BindData();
            }
        }
        #region 绑定用户級別
        /// <summary>
        /// 绑定用户級別
        /// </summary>
        private void BindLevel()
        {
            IList<lgk.Model.tb_level> List = new lgk.BLL.tb_level().GetModelList("");
            dropLevel.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "-1";
            li.Text = "-请选择-";
            dropLevel.Items.Add(li);
            foreach (lgk.Model.tb_level item in List)
            {
                ListItem items = new ListItem();
                items.Value = item.LevelID.ToString();
                items.Text = item.LevelName;
                dropLevel.Items.Add(items);
            }
        }
        #endregion
        /// <summary>
        ///已开通查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strRegStart = this.txtRegStart.Text.Trim();
            string strRegEnd = txtRegEnd.Text.Trim();
            string strOpenStart = txtOpenStart.Text.Trim();
            string strOpenEnd = txtOpenEnd.Text.Trim();
            string strWhere = "IsOpend<>2";
            #region 会员类型
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
                if (this.dropType.SelectedValue == "3")
                {
                    strWhere += " and RecommendCode like  '%" + this.txtInput.Value.Trim() + "%'";
                }
                if (this.dropType.SelectedValue == "4")
                {
                    strWhere += " and ParentCode like  '%" + this.txtInput.Value.Trim() + "%'";
                }
                if (this.dropType.SelectedValue == "5")
                {
                    strWhere += " and User006 like  '%" + this.txtInput.Value.Trim() + "%'";
                }
            }
            #endregion
            #region 会员等级
            if (this.dropLevel.SelectedValue != "-1")
            {
                strWhere += " and tb_user.LevelID=" + dropLevel.SelectedValue;
            }
            #endregion
            #region 注册时间
            if (strRegStart != "" && strRegEnd == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RegTime,120)  >= '" + strRegStart + "'");
            }
            else if (strRegStart == "" && strRegEnd != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  <= '" + strRegEnd + "'");
            }
            else if (strRegStart != "" && strRegEnd != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  between '" + strRegStart + "' and '" + strRegEnd + "'");
            }
            #endregion
            #region 开通时间
            if (strOpenStart != "" && strOpenEnd == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OpenTime,120) >= '" + strOpenStart + "'");
            }
            else if (strOpenStart == "" && strOpenEnd != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OpenTime,120) <= '" + strOpenEnd + "'");
            }
            else if (strOpenStart != "" && strOpenEnd != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OpenTime,120) between '" + strOpenStart + "' and '" + strOpenEnd + "'");
            }
            #endregion
            return strWhere;
        }
        /// <summary>
        /// 绑定已开通会员列表
        /// </summary>
        private void BindData()
        {
            bind_repeater(userBLL.GetOpenList(GetWhere()), Repeater1, "OpenTime desc", tr1, AspNetPager1);
        }
        /// <summary>
        /// 导出申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码
            DataSet ds = userBLL.GetOpenList(GetWhere());
            DataTable dv = ds.Tables[0];
            if (Repeater1.Items.Count == 0)
            {
                MessageBox.MyShow(this, "不能导出空表格");
                return;
            }
            if (dv.Rows.Count == 0)
            {
                MessageBox.MyShow(this, "错误的操作!");
                return;
            }
            string str = ToOpenExecl(Server.MapPath("../../Upload"), dv);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }
        /// <summary>
        /// 搜索提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        /// <summary>
        /// 分页提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        public string adre(int type)
        {
            string bi = "";
            lgk.Model.tb_agent typer = agentBLL.GetModel("userid=" + type);
            if (typer == null)
            { bi = "无"; }
            else
            {
                if (typer.AgentType == 1)
                {
                    bi = "一级服务中心";
                }
                else if (typer.AgentType == 2)
                {
                    bi = "二级服务中心";
                }
                else if (typer.AgentType == 3)
                {
                    bi = "三级服务中心";
                }
            }
            return bi;
        }
        public string GetTrueName(string strName)
        {
            string str = "";
            if (strName.Trim() != "")
            {
                if (strName.Trim() == "admin")
                {
                    str = "admin";
                }
                else
                {
                    lgk.Model.tb_user userModel = userBLL.GetModel(" UserCode='" + strName + "'");
                    if (userModel != null)
                    {
                        if (userModel.RecommendCode == "admin")
                        {
                            str = "";
                        }
                    }
                }
            }
            return str;
        }
        /// <summary>
        /// 报单方式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string TypeName(object obj)
        {
            string str = string.Empty;
            try
            {
                if (obj != null)
                {
                    string value = obj.ToString();
                    if (value == "0")
                    {
                        str = "未开通";
                    }
                    else if (value == "2")
                    {
                        str = "开通";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int iUserID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "UserID"));

                string levelName = DataBinder.Eval(e.Item.DataItem, "LevelName").ToString();
                Literal ltlLevelName = (Literal)e.Item.FindControl("ltlLevelName"); // 等级名称
                ltlLevelName.Text = levelName;
            }
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int iUserID = int.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_user userInfo = userBLL.GetModel(iUserID);
            if (e.CommandName == "yi")// 
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                userInfo.LevelID = 0;
                userBLL.Update(userInfo);
                MessageBox.MyShow(this, "操作成功!");
            }
            if (e.CommandName == "er")// 
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码
                userInfo.LevelID = 1;
                userBLL.Update(userInfo);
                MessageBox.MyShow(this, "操作成功!");
            }
            if (e.CommandName == "san")// 
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码
                userInfo.LevelID = 2;
                userBLL.Update(userInfo);
                MessageBox.MyShow(this, "操作成功!");
            }
            if (e.CommandName == "si")// 
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码
                userInfo.LevelID = 3;
                userBLL.Update(userInfo);
                MessageBox.MyShow(this, "操作成功!");
            }
            BindData();
        }
        /// <summary>
        /// 开通给定编号的用户
        /// </summary>
        /// <param name="iUserID">用户编号</param>
        private void UserOpen(int iUserID)
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(iUserID);
            if (userInfo != null)
            {
                if (GetRecommend(iUserID) && GetBonus(iUserID))
                {
                    userInfo.IsOpend = 2;
                    userInfo.User008 = "激活";
                    userBLL.Update(userInfo);
                    MessageBox.MyShow(this, "激活成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "条件不满足,无法激活!");
                }
            }
            else
                MessageBox.MyShow(this, "该会员不存在或已删除,无法再进行此操作!");
        }
        /// <summary>
        /// 获取给定用户编号的会员直推资产（直接推荐人的投资总额）
        /// </summary>
        /// <param name="iUserID">给定用户编号</param>
        /// <returns></returns>
        private bool GetRecommend(int iUserID)
        {
            bool bFalg = false;
            decimal dAsset = Convert.ToDecimal(0.00);
            IList<lgk.Model.tb_user> list = userBLL.GetModelList("[RecommendID] = " + iUserID);
            if (list != null)
            {
                foreach (lgk.Model.tb_user item in list)
                {
                    dAsset += item.RegMoney;
                }
                if (dAsset > 20000)
                    bFalg = true;
                else
                    bFalg = false;
            }
            else
            {
                bFalg = false;
            }
            return bFalg;
        }
        /// <summary>
        /// 判断给定用户编号的会员直推奖金是否大于投资资金。
        /// </summary>
        /// <param name="iUserID">给定用户编号</param>
        /// <returns></returns>
        private bool GetBonus(int iUserID)
        {
            bool bFalg = false;
            decimal dBonus = Convert.ToDecimal(0.00);
            lgk.Model.tb_user userInfo = userBLL.GetModel(iUserID);
            IList<lgk.Model.tb_bonus> list = bonusBLL.GetModelList("[UserID] = " + iUserID + " AND TypeID = 1");
            if (list != null)
            {
                foreach (lgk.Model.tb_bonus item in list)
                {
                    dBonus += item.Amount;
                }
                if (dBonus > userInfo.RegMoney)
                    bFalg = true;
                else
                    bFalg = false;
            }
            return bFalg;
        }
    }
}