using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.finance
{
    public partial class yungou : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            //bind_repeater(cashbuyBLL.GetList(GetWhere()), Repeater1, "BuyDate ASC", tr1, AspNetPager1);
            bind_repeater(userBLL.GetList(GetWhere()), Repeater1, "Emoney desc,BonusAccount desc,isopend desc", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
            //string strWhere = "1=1";

            //string strUserCode = this.txtUserCode.Text.Trim();
            //long UserId = userBLL.GetUserID(strUserCode);
            //if (!string.IsNullOrEmpty(strUserCode))
            //{
            //    strWhere += " AND UserID=" + UserId;
            //}
            //#region 下定时间
            //string strStartTime = txtStart.Text.Trim();
            //string strEndTime = txtEnd.Text.Trim();

            //if (strStartTime != "" && strEndTime == "")
            //{
            //    strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120) >= '" + strStartTime + "'");
            //}
            //else if (strStartTime == "" && strEndTime != "")
            //{
            //    strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120) <= '" + strEndTime + "'");
            //}
            //else if (strStartTime != "" && strEndTime != "")
            //{
            //    strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120) between '" + strStartTime + "' AND '" + strEndTime + "'");
            //}
            //#endregion

            //return strWhere;
            string strWhere = string.Format("IsOpend > 0");

            if (this.textUserCode.Value != "")
            {
                strWhere += " and UserCode like '%" + this.textUserCode.Value.Trim() + "%'";
            }
            if (this.txtTrueName.Text != "")
            {
                strWhere += " and TrueName like '%" + this.txtTrueName.Text.Trim() + "%'";
            }
            return strWhere;
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            //{
            //    long iStockID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "StockID"));

            //    //Literal ltIsBuy = (Literal)e.Item.FindControl("ltIsBuy");

            //    lgk.Model.tb_Stock stockInfo = stockBLL.GetModel(iStockID);

            //    if (stockInfo.IsSell == 0)//0持有，1挂单，2已生成订单卖出中,3已卖出
            //        ltIsBuy.Text = "持有";
            //    else if (stockInfo.IsSell == 1)
            //        ltIsBuy.Text = "挂单";
            //    else if (stockInfo.IsSell == 2)
            //        ltIsBuy.Text = "卖出中";
            //    else if (stockInfo.IsSell == 3)
            //        ltIsBuy.Text = "已卖出";
            //}
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long iUserID = int.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_user orUerser = userBLL.GetModel(iUserID);
            TextBox txtGongsi = (TextBox)e.Item.FindControl("txtGongsi");//解冻金额
            if (e.CommandName.Equals("enter")) //确认解冻云购积分
            {
                #region 1判断当前用户输入的解冻金额
                if (string.IsNullOrEmpty(txtGongsi.Text))
                {
                    MessageBox.Show(this, "解冻失败，原因：解冻金额不能为空");
                    return;
                }
                decimal price = 0;//解冻金额
                if (!decimal.TryParse(txtGongsi.Text.Trim(), out price))
                {
                    MessageBox.MyShow(this, "请输入有效数据");//请输入有效数据
                    return;
                }
                //order.Order3 = txtGongsi.Text;
                //order.Order4 = txtDanhao.Text;
                UpdateAccount("User012", iUserID, price, 0);//云购积分解冻更新
                UpdateAccount("User014", iUserID, price, 1);//
                UpdateAccount("StockAccount", iUserID, price, 1);//获得云商积分

                decimal balanceAmount = orUerser.User012 - price;//云购积分账户结余金额
                add_journal(iUserID, 0, price, balanceAmount, 9, "云购积分解冻", "", iUserID);//云购积分加入流水线

                decimal balanceAmount2 = orUerser.StockAccount + price;//云商积分账户结余金额
                add_journal(iUserID, price, 0, balanceAmount2, 4, "云购积分解冻", "", iUserID);//云商积分加入流水线


                MessageBox.ShowAndRedirect(this, "积分解冻成功","yungou.aspx");
                return;

                #endregion
            }
            if (e.CommandName.Equals("detail"))
            {
                Response.Redirect("JournalDetail.aspx?UserID=" + iUserID + "&JournalType=9");
            }
        }
    }
}