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
    public partial class BuyList : PageCore
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
            string strWhere = "UserID=" + getLoginID() + " AND IsSell=0";

            #region 下定时间
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

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int iIsSell = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "IsSell"));

                Literal ltIsSell = (Literal)e.Item.FindControl("ltIsSell");//订单状态

                //GetLanguage("WaitingBuy");//0持有，1挂单，2已生成订单卖出中,3已卖出
                if (iIsSell == 0)
                {
                    ltIsSell.Text = GetLanguage("Hold");//持有
                }
                else if (iIsSell == 1)
                {
                    ltIsSell.Text = GetLanguage("Guadan");//挂单
                }
                else if (iIsSell == 2)
                {
                    ltIsSell.Text = GetLanguage("Saleing");//出售中
                }
                else if (iIsSell == 3)
                {
                    ltIsSell.Text = GetLanguage("HasSold");//已卖出
                }
            }
        }
    }
}