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
    public partial class Bonusa : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转3级密码

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            bind_repeater(stockBLL.GetList(GetWhere()), Repeater1, "BuyDate desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private string GetWhere()
        {
            string strWhere = "";

            strWhere = "UserID=" + getLoginID() + "";

            return strWhere;
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int iUserID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "UserID"));
                int iStockID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "StockID"));

                Literal ltUserName = (Literal)e.Item.FindControl("ltUserName");//会员编号
                Literal ltBalance = (Literal)e.Item.FindControl("ltBalance");//可提现余额
                Literal ltCurrentPrice = (Literal)e.Item.FindControl("ltCurrentPrice");//当前股价

                lgk.Model.Stock stockInfo = stockBLL.GetModel(iStockID);

                decimal dAmount = stockBLL.GetModel(iStockID).Amount;//A盘资金
                decimal dBalance = Convert.ToDecimal(0.00);//利润

                dBalance = stockInfo.Number * (getParamAmount("shares5") - stockInfo.Price);

                ltBalance.Text = dBalance.ToString();

                ltCurrentPrice.Text = getParamAmount("shares5").ToString("0.0000");

                ltUserName.Text = userBLL.GetModel(iUserID).UserCode;
            }
        }
    }
}