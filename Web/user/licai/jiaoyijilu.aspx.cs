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

namespace Web.user.licai
{
    public partial class jiaoyijilu : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //bindMyDai();
                bindMyMaiChu();
                bindMyMaiRu();
                bindSplit();
            }
        }
        /// <summary>
        /// 我的卖出记录
        /// </summary>
        private void bindMyMaiChu()
        {
            string StarTime = this.txtMaichuStar.Text.Trim();
            string EndTime = this.txtMaichuEnd.Text.Trim();
            string strWhere = string.Format(" BusinessType = 1 and status = 2  and UserType=1 and UserID="+getLoginID());
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  >= '" + StarTime + "' ");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  <= '" + EndTime + "' ");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  between '" + StarTime + "' and '" + EndTime + "' ");
            }
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater2, "BusinessTime desc", tr2, AspNetPager2);
        }
        /// <summary>
        /// 我的买入记录
        /// </summary>
        private void bindMyMaiRu()
        {
            string StarTime = this.txtMairuStar.Text.Trim();
            string EndTime = this.txtMairuEnd.Text.Trim();
            string strWhere = string.Format(" BusinessType = 2 and status = 2 and UserType=1 and UserID=" + getLoginID());
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  >= '" + StarTime + "' ");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  <= '" + EndTime + "' ");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  between '" + StarTime + "' and '" + EndTime + "' ");
            }
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater1, "BusinessTime desc", tr1, AspNetPager1);
        }
        /// <summary>
        /// 我的待交易记录
        /// </summary>
        private void bindSplit()
        {
            string StarTime = this.TextBox1.Text.Trim();
            string EndTime = this.TextBox2.Text.Trim();
            string strWhere = string.Format("  Split01 = 1 and UserID=" + getLoginID());
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SplitStockTime,120)  >= '" + StarTime + "' ");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SplitStockTime,120)  <= '" + EndTime + "' ");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SplitStockTime,120)  between '" + StarTime + "' and '" + EndTime + "' ");
            }
            bind_repeater(gp_ssBLL.GetList(strWhere), Repeater4, "SplitStockTime desc", tr4, AspNetPager4);
        }
        protected string getType(int BusinessType)
        {
            if (BusinessType == 2)
            {
                return "买入交易";
            }
            return "卖出交易";
        }

        protected void btnMairu_Click(object sender, EventArgs e)
        {
            bindMyMaiRu();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bindMyMaiRu();
        }

        protected void btnMaichu_Click(object sender, EventArgs e)
        {
            bindMyMaiChu();
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            bindMyMaiChu();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bindSplit();
        }

        protected void AspNetPager4_PageChanged(object sender, EventArgs e)
        {
            bindSplit();
        }

        //protected void btnDai_Click(object sender, EventArgs e)
        //{
        //    bindMyDai();
        //}

        //protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        //{
        //    bindMyDai();
        //}
    }
}
