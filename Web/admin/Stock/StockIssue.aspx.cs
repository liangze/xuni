using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Library;

namespace Web.admin.Stock
{
    public partial class StockIssue : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 6, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                lgk.Model.tb_systemMoney ToalMoney = systemBll.GetModel(1);
                ToalNumber.Text = ToalMoney.MoneyAccount.ToString();
                ShowData();
                BindData();
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowData()
        {
            lgk.Model.tb_StockIssue issueInfo = stockIssueBLL.GetModel("IsSell > 0");

            if (issueInfo != null)
            {
               
                lbtnOK.Visible = false;
                ltWarning.Text = "云商积分已发行，不能重复发行！";
                txtNum.Text = getParamInt("Shares1").ToString("0");//本期发行量
               
            }
            else
            {
                //txtNum.Text = "0";//本期发行量
                txtNum.Text = getParamInt("Shares1").ToString("0");//本期发行量
            }
        }

        private void BindData()
        {
            bind_repeater(stockIssueBLL.GetList(""), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void lbtnOK_Click(object sender, EventArgs e)
        {
            if (stockIssueBLL.Exists())
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('云商积分已发行，不能重复发行！');", true);
                return;
            }
            else
            {
                lgk.Model.tb_StockIssue issueInfo = new lgk.Model.tb_StockIssue();
                int ciNumber = stockIssueBLL.Existss();//获取发行期数
                decimal Number = getParamAmount("Shares1");//
                issueInfo.IssueAmount = Number;
                issueInfo.SurplusAmount = Number;
                issueInfo.IssuePrice = getParamAmount("Shares2");
                issueInfo.Periods = ciNumber+1;
                issueInfo.AddDate = DateTime.Now;
                issueInfo.IsSell = 1;

                #region 购买云商积分,公司账户云商积分增加
                lgk.Model.tb_systemMoney systemMoney = systemBll.GetModel(1);
                systemMoney.MoneyAccount += Number;//公司账户增加
                systemBll.Update(systemMoney);
                #endregion

                int iIssueID = stockIssueBLL.Add(issueInfo);

                if (iIssueID > 0)
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发行成功！');window.location.href='StockIssue.aspx'", true);
                else
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发行失败，请检查数据后再试！');window.location.href='StockIssue.aspx'", true);
            }
        }

        protected void lbtnIssue_Click(object sender, EventArgs e)
        {
            Response.Redirect("StockIssue.aspx");
        }

        //protected void lbtnSplit_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("SplitStock.aspx");
        //}
    }
}