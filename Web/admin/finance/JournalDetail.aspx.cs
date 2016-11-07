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
                ltRemark.Text = "注册积分账户";
                ltIncome.Text = "注册积分账户";
                ltExpenditure.Text = "注册积分账户";
                ltBalance.Text = "注册积分账户";
            }
            else if (iJournalType == 2)
            {
                ltRemark.Text = "奖金积分账户";
                ltIncome.Text = "奖金积分账户";
                ltExpenditure.Text = "奖金积分账户";
                ltBalance.Text = "奖金积分账户";
            }
            //m_user.Emoney = 0;// 注册积分         写流水类型：1
            //m_user.BonusAccount = 0;// 奖金积分 		2
            //m_user.AllBonusAccount = 0;// 电子积分		3
            //m_user.StockAccount = 0;// 云商积分		4
            //m_user.StockMoney = 0;// 感恩积分		5
            //m_user.GLmoney = 0;// 购物积分			6
            //m_user.ShopAccount = 0;// 消费积分		7
            //User011// 爱心基金	 8
            //User012// 云购积分	 9
            else if (iJournalType == 3)
            {
                ltRemark.Text = "电子积分账户";
                ltIncome.Text = "电子积分账户";
                ltExpenditure.Text = "电子积分账户";
                ltBalance.Text = "电子积分账户";
            }
            else if (iJournalType == 4)
            {
                ltRemark.Text = "云商积分账户";
                ltIncome.Text = "云商积分账户";
                ltExpenditure.Text = "云商积分账户";
                ltBalance.Text = "云商积分账户";
            }
            else if (iJournalType == 5)
            {
                ltRemark.Text = "感恩积分账户";
                ltIncome.Text = "感恩积分账户";
                ltExpenditure.Text = "感恩积分账户";
                ltBalance.Text = "感恩积分账户";
            }
            else if (iJournalType == 6)
            {
                ltRemark.Text = "购物积分账户";
                ltIncome.Text = "购物积分账户";
                ltExpenditure.Text = "购物积分账户";
                ltBalance.Text = "购物积分账户";
            }
            else if (iJournalType == 7)
            {
                ltRemark.Text = "消费积分账户";
                ltIncome.Text = "消费积分账户";
                ltExpenditure.Text = "消费积分账户";
                ltBalance.Text = "消费积分账户";
            }
            else if (iJournalType == 8)
            {
                ltRemark.Text = "爱心基金账户";
                ltIncome.Text = "爱心基金账户";
                ltExpenditure.Text = "爱心基金账户";
                ltBalance.Text = "爱心基金账户";
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
