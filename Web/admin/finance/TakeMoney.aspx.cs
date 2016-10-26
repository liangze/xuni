using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;

namespace Web.admin.finance
{
    public partial class TakeMoney : AdminPageBase//System.Web.UI.Page
    {
        private string strWhere = "";
        string StarTime;
        string EndTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 16, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
            txtMoney.Value = GetTotalTake(0).ToString("0.00");
        }
        protected void lbtnApply_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeMoney.aspx");
        }

        protected void lbtnDraw_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeList.aspx");
        }
        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            StarTime = txtStar.Text.Trim();
            EndTime = txtEnd.Text.Trim();
            strWhere = " b.Flag=0";
            if (this.txtUserCode.Value != "")
            {
                strWhere += " and u.usercode like '%" + this.txtUserCode.Value.Trim() + "%'";
            }
            if (this.txtTrueName.Value != "")
            {
                strWhere += " and u.trueName like '%" + this.txtTrueName.Value.Trim() + "%'";
            }
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),b.TakeTime,120) >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),b.TakeTime,120) <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),b.TakeTime,120) between '" + StarTime + "' and '" + EndTime + "'");
            }
            return strWhere;
        }
        /// <summary>
        /// 填充申请记录
        /// </summary>
        private void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), Repeater1, "TakeTime desc", tr1, AspNetPager1);
        }
        /// <summary>
        /// 搜索申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        /// <summary>
        /// 导出申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            DataSet ds = GetTakeList(GetWhere());
            DataTable dt = ds.Tables[0];
            if (Repeater1.Items.Count == 0)
            {
                MessageBox.MyShow(this, "不能导出空表格");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.MyShow(this, "错误的操作");
                return;
            }
            string str = ToTakeExecl2(Server.MapPath("../../Upload"), dt);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }
        /// <summary>
        /// 审核分页申请记录
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long ID = Convert.ToInt64(e.CommandArgument); //ID
            lgk.Model.tb_takeMoney cModel = takeBLL.GetModel(ID);
            lgk.BLL.tb_systemMoney sy = new lgk.BLL.tb_systemMoney();
            //lgk.BLL.tb_rechargeable dotx = new lgk.BLL.tb_rechargeable();
            lgk.Model.tb_systemMoney system = sy.GetModel(1);
            if (cModel == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已删除,无法再进行此操作！');window.location.href='TakeMoney.aspx';", true);
            }
            else
            {

                if (cModel.Flag == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已审核,无法再进行此操作！');window.location.href='TakeMoney.aspx';", true);

                }
                else
                {
                    lgk.Model.tb_user user = userBLL.GetModel(Convert.ToInt32(cModel.UserID));
                    if (e.CommandName.Equals("Open"))//确认
                    {
                        cModel.Flag = 1;
                        cModel.Take006 = DateTime.Now;
                        if (takeBLL.Update(cModel) && UpdateSystemAccount("MoneyAccount", Convert.ToDecimal(cModel.RealityMoney), 0) > 0)
                        {
                           //发送短信通知
                            string content = GetLanguage("MessageTakeMoneyOK").Replace("{username}", user.UserCode).Replace("{time}", Convert.ToDateTime(cModel.TakeTime).ToString("yyyy年MM月dd日HH时mm分")).Replace("{timeEn}", Convert.ToDateTime(cModel.TakeTime).ToString("yyyy/MM/dd HH:mm"));
                            SendMessage(Convert.ToInt32(cModel.UserID), user.PhoneNum, content);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='TakeMoney.aspx';", true);

                        }
                    }
                    if (e.CommandName.Equals("Remove"))//删除
                    {
                        //加入流水账表
                        lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                        model.UserID = cModel.UserID;
                        model.Remark = "取消提现";
                        model.InAmount = cModel.TakeMoney;
                        model.OutAmount = 0;
                        model.BalanceAmount = user.BonusAccount + cModel.TakeMoney;
                        model.JournalDate = DateTime.Now;
                        model.JournalType = 1;
                        model.Journal01 = cModel.UserID;
                        if (journalBLL.Add(model) > 0 && UpdateAccount("BonusAccount", user.UserID, cModel.TakeMoney, 1) > 0 && takeBLL.Delete(ID))
                        {
                            MessageBox.MyShow(this, "取消成功");
                            BindData();
                        }
                        else
                        {
                            MessageBox.MyShow(this, "取消失败");
                        }
                    }
                }
            }
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
