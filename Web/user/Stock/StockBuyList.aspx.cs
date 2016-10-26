using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Library;

namespace Web.user.Stock
{
    public partial class StockBuyList : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "[tb_StockBuy].[UserID] = " + getLoginID() + "";

            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (currentCulture == "en-us")
            {
                strStartTime = txtStartEn.Text.Trim();
                strEndTime = txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120) >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120) <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120) BETWEEN '" + strStartTime + "' AND '" + strEndTime + "'");
            }

            return strWhere;
        }

        /// <summary>
        /// 填充信息
        /// </summary>
        protected void BindData()
        {
            bind_repeater(stockBuyBLL.GetInnerList(GetWhere()), Repeater1, "BuyDate desc", tr1, AspNetPager1);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                long iStockBuyID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "StockBuyID"));

                Literal ltIsBuy = (Literal)e.Item.FindControl("ltIsBuy");

                lgk.Model.tb_StockBuy stockBuyInfo = stockBuyBLL.GetModel(iStockBuyID);

                if (stockBuyInfo.IsBuy == 0)//购买状态(0等待买入，1购买中，2购买完毕)
                    ltIsBuy.Text = GetLanguage("WaitingBuy");//等待买入
                else if (stockBuyInfo.IsBuy == 1)
                    ltIsBuy.Text = GetLanguage("BuyIn");//购买中
                else if (stockBuyInfo.IsBuy == 2)
                    ltIsBuy.Text = GetLanguage("Completed");//购买完毕（已完成）
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}