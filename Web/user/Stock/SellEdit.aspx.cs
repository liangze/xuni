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
    public partial class SellEdit : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                ShowData();
                BindData();
            }
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        private void ShowData()
        {
            if (getParamInt("shares8") == 0)
            {
                ltReminder.Text = "股票未拆分，不允许卖出股票！";
            }

            if (getParamInt("shares16") == 0)
            {
                ltReminder.Text = "系统不允许手动卖出股票！";
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            bind_repeater(stockBLL.GetList(GetWhere()), Repeater1, "BuyDate desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "";

            strWhere = "UserID=" + getLoginID() + " AND (IsSell=0 OR IsSell=1) AND Surplus>0";

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

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            string strOrderCode = "";
            lgk.Model.Stockorder stockorderInfo = new lgk.Model.Stockorder();
            List<lgk.Model.Stock> myStockList = stockBLL.GetModelList(GetWhere());

            if (myStockList.Count == 0)
            {
                MessageBox.MyShow(this, "没有股票可卖！");
                return;
            }

            foreach (lgk.Model.Stock stockInfo in myStockList)
            {
                stockorderInfo.StockID = stockInfo.StockID;
                stockorderInfo.UserID = stockInfo.UserID;
                strOrderCode = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                strOrderCode = strOrderCode + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                stockorderInfo.OrderCode = strOrderCode + GetRandom();
                stockorderInfo.OrderDate = DateTime.Now;
                stockorderInfo.Remark = "";
                stockorderInfo.Status = 0;

                stockorderBLL.Add(stockorderInfo);

                stockInfo.IsSell = 2;
                stockBLL.Update(stockInfo);
            }
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <returns></returns>
        private string GetRandom()
        {
            Random ran = new Random();
            int index = 1;
            string num = "";
            while (index < 5)
            {
                num += ran.Next(0, 4);
                index++;
            }
            return num;
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int iIsSell = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "IsSell"));

                Literal ltIsSell = (Literal)e.Item.FindControl("ltIsSell");//股票状态
                LinkButton lbtnBuy = (LinkButton)e.Item.FindControl("lbtnBuy");//股票状态

                if (iIsSell == 0)
                {
                    ltIsSell.Text = "持有";
                    lbtnBuy.Visible = true;
                }
                else if (iIsSell == 1)
                {
                    ltIsSell.Text = "挂单";
                    lbtnBuy.Visible = false;
                }
                else if (iIsSell == 2)
                {
                    ltIsSell.Text = "卖出中";
                    lbtnBuy.Visible = false;
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Buy")
            {
                int iStockID = Convert.ToInt32(e.CommandArgument);

                if (getParamInt("shares8") == 0)
                {
                    MessageBox.MyShow(this, "股票未拆分，不允许卖出！");
                    return;
                }

                if (getParamInt("shares16") == 0)
                {
                    MessageBox.MyShow(this, "系统不允许手动卖出股票！");
                    return;
                }

                int iFlag = SellStock(iStockID);

                if (iFlag == 0)
                {
                    MessageBox.MyShow(this, "卖出失败！");
                    return;
                }
                else if (iFlag == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('卖出成功！');window.location.href='SellEdit.aspx';", true);//购买股票成功
                }
                else if (iFlag == 2)
                {
                    MessageBox.MyShow(this, "股票未拆分，不允许卖出！");
                    return;
                }
                else if (iFlag == 3)
                {
                    MessageBox.MyShow(this, "当前价格下，不允许卖出股票！");
                    return;
                }
            }
        }

        /// <summary>
        /// 卖出股票
        /// </summary>
        /// <param name="iStockID"></param>
        /// <returns></returns>
        protected int SellStock(int iStockID)
        {
            int iFlag = 0;
            long iOrderID = 0;
            string strOrderCode = "";
            int iSplit = getParamInt("shares8");//获取当前的股票拆分次数
            decimal dCurrent = getParamAmount("shares5");//当前股价

            lgk.Model.Stockorder stockorderInfo = new lgk.Model.Stockorder();
            lgk.Model.Stock stockInfo = stockBLL.GetModel(iStockID);

            if (stockInfo != null)
            {
                stockorderInfo.StockID = stockInfo.StockID;
                stockorderInfo.UserID = stockInfo.UserID;
                strOrderCode = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                strOrderCode = strOrderCode + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                stockorderInfo.OrderCode = strOrderCode + GetRandom();
                stockorderInfo.OrderDate = DateTime.Now;
                stockorderInfo.Remark = "";
                stockorderInfo.Status = 0;

                if (stockInfo.SplitNum < iSplit)
                {
                    if (stockInfo.Price == dCurrent)
                    {
                        iOrderID = stockorderBLL.Add(stockorderInfo);
                        if (iOrderID > 0)
                        {
                            stockInfo.IsSell = 2;
                            if (stockBLL.Update(stockInfo))
                                iFlag = 1;
                        }
                    }
                    else
                        iFlag = 3;
                }
                else
                {
                    iFlag = 2;
                }
            }

            return iFlag;
        }
    }
}