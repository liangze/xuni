using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.Stock
{
    public partial class SellList : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }

            btnSearch.Text = GetLanguage("Search");//搜索
        }

        private void BindData()
        {
            bind_repeater(stockBLL.GetList(GetWhere()), Repeater1, "BuyDate desc", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
            string strWhere = "UserID=" + getLoginID() + " AND (IsSell=2 OR IsSell=3)";

            #region 下订时间
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120)  between '" + strStartTime + "' AND '" + strEndTime + "'");
            }
            #endregion

            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}