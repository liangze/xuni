/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-5-15 11:28:14 
 * 文 件 名：		ProManage.cs 
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

namespace Web.admin.team
{
    public partial class ProManage : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 11, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼
            if (!IsPostBack)
            {
                ddlL();
                bind_pro();
            }
        }
        protected string getLastLevel(int lastLevel)
        {
            try
            {
                return levelBLL.GetModel(lastLevel).LevelName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void ddlL()
        {
            IList<lgk.Model.tb_level> ddlList = new lgk.BLL.tb_level().GetModelList("");
            ddlLevel.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            ddlLevel.Items.Add(li);
            foreach (lgk.Model.tb_level item in ddlList)
            {
                ListItem items = new ListItem();
                items.Value = item.LevelID.ToString();
                items.Text = item.LevelName;
                ddlLevel.Items.Add(items);
            }
        }

        private void bind_pro()
        {
            string StarTime = this.txtStar.Text.Trim();
            string EndTime = this.txtEnd.Text.Trim();
            string strWhere = " 1=1 ";//1 会员晋升 2 开通报单中心
            if (txtUserCode.Text != "")
            {
                strWhere += " and u.usercode like '%" + txtUserCode.Text.Trim() + "%'";
            }
            if (StarTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),p.AddDate,120)  >= '" + StarTime + "'");
            }
            if (EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),p.AddDate,120)  <= '" + EndTime + "'");
            }
            bind_repeater(GetProList(strWhere), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind_pro();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind_pro();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string usercode = TextBox1.Text.Trim();
            if (usercode == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入要晋升的会员编号!');", true);
                return;
            }

            lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID(usercode));
            lgk.Model.tb_userPro userpro = proBLL.GetModelByUserID(Convert.ToInt32(userInfo.UserID));
            
            if (userInfo == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该会员不存在!');", true);
                return;
            }
            
            if (userInfo.IsOpend == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该会员尚未开通，请开通后再进行此操作!');", true);
                return;
            }
            if (userpro != null)
            {
                if (userpro.Flag == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该会员尚有申请未审核！');", true);
                    return;
                }
            }
            
            int endLevel = Convert.ToInt32(ddlLevel.SelectedValue.Trim());
            if (endLevel == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择晋升级别!');", true);
                return;
            }
            if (endLevel <= userInfo.LevelID)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('晋升级别不能小于当前会员级别!');", true);
                return;
            }
            if (userInfo != null)
            {
                //记录升级表
                lgk.Model.tb_userPro upModel = new lgk.Model.tb_userPro();
                upModel.UserID = Convert.ToInt32(userInfo.UserID);
                upModel.LastLevel = userInfo.LevelID;
                upModel.Remark = "后台晋升";
                upModel.Flag = 0;
                upModel.Pro001 = 0;
                upModel.EndLevel = endLevel;
                upModel.ProMoney = 0;
                upModel.AddDate = DateTime.Now;
                upModel.FlagDate = DateTime.Now;
                upModel.Pro008 = "1";//1会员晋升 2 报单中心 
                
                if (proBLL.Add(upModel) > 0 && flag_pro(Convert.ToInt32(userInfo.UserID),2))
                { 
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('会员后台晋升成功！');window.location.href='ProManage.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('会员后台晋升失败！');", true);
                    return;
                }
            }
            else
            {
                MessageBox.MyShow(this, "该会员不存在!");
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_userPro model = proBLL.GetModel(id);
            lgk.Model.tb_user user = userBLL.GetModel(model.UserID);
            if (model == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('已删除,无法进行此操作！');window.location.href='ProManage.aspx';", true);
            }
            else
            {
                if (model.Flag == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('已审核,无法进行此操作！');window.location.href='ProManage.aspx';", true);
                }
                else
                {
                    if (e.CommandName == "flag")
                    {
                        if (flag_pro(model.ID, 1))
                        {
                            decimal reEmoney = model.ProMoney;
                            
                            AllCore acore = new AllCore();//1收入2支出
                            acore.add_userRecord(user.UserCode, DateTime.Now, reEmoney, 2);
                            
                            //UpdateSystemAccount("MoneyAccount", reEmoney, 1);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('审核成功!');", true);
                        }
                    }
                    if (e.CommandName == "delete")
                    {
                        ////加入流水账表
                        //lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                        //jmodel.UserID = Convert.ToInt32(model.UserID);
                        //jmodel.Remark = "会员晋升(未通过审核)";
                        //jmodel.InAmount = model.ProMoney;
                        //jmodel.OutAmount = 0;
                        //jmodel.BalanceAmount = user.Emoney + model.ProMoney;
                        //jmodel.JournalDate = DateTime.Now;
                        //jmodel.JournalType = 1;
                        ////返还扣除金额
                        //var u = userBLL.GetModel(model.UserID);
                        //decimal prom=0;
                        //if (u != null&&decimal.TryParse(model.ProMoney.ToString(),out prom))
                        //{
                        //    u.Emoney = u.Emoney +prom;
                        //}
                        //decimal reEmoney = (decimal)model.ProMoney;userBLL.Update(u)&&journalBLL.Add(jmodel) > 0 && 
                        if (proBLL.Delete(Convert.ToInt32(id)))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除成功!');", true);
                        }
                    }
                    bind_pro();
                }
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string usercode = this.TextBox1.Text.Trim();
            lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID(usercode));
            if (userInfo != null)
            {
                txtLevel.Value = levelBLL.GetModel(userInfo.LevelID).LevelName;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该会员不存在!');", true);
                txtLevel.Value = "";
            }
        }
    }
}
