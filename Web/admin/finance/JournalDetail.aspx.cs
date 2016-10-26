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
    public partial class JournalDetail : AdminPageBase//System.Web.UI.Page
    {
        protected int iJournalType = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 20, getLoginID());//权限

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            long iUserID = Convert.ToInt64(Request.QueryString["UserID"].ToString());
            iJournalType = Convert.ToInt32(Request.QueryString["JournalType"].ToString());

            if (iJournalType == 1)
            {
                ltRemark.Text = "流通币账户";
                ltIncome.Text = "流通币账户";
                ltExpenditure.Text = "流通币账户";
                ltBalance.Text = "流通币账户";
            }
            else if (iJournalType == 2)
            {
                ltRemark.Text = "MDD钻币账户";
                ltIncome.Text = "MDD钻币账户";
                ltExpenditure.Text = "MDD钻币账户";
                ltBalance.Text = "MDD钻币账户";
            }
            else if (iJournalType == 3)
            {
                ltRemark.Text = "平台费用账户";
                ltIncome.Text = "平台费用账户";
                ltExpenditure.Text = "平台费用账户";
                ltBalance.Text = "平台费用账户";
            }
            else if (iJournalType == 4)
            {
                ltRemark.Text = "购物币账户";
                ltIncome.Text = "购物币账户";
                ltExpenditure.Text = "购物币账户";
                ltBalance.Text = "购物币账户";
            }
            else if (iJournalType == 5)
            {
                ltRemark.Text = "注册币账户";
                ltIncome.Text = "注册币账户";
                ltExpenditure.Text = "注册币账户";
                ltBalance.Text = "注册币账户";
            }

            string strWhere = string.Format("JournalType=" + iJournalType + " and j.UserID=" + iUserID);

            bind_repeater(journalBLL.GetList(strWhere), Repeater1, "ID desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
