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
    public partial class BuyEdit : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
                BindData();
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        #region 填充
        /// <summary>
        /// 填充
        /// </summary>
        protected void BindData()
        {
            bind_repeater(tb_stockBuyBLL.GetList(GetWhere()), Repeater1, "BuyTime desc", tr1, AspNetPager1);
            bind_repeater(tb_stockModeBLL.GetList(" [Status]=1 "), Repeater2, " Period asc ", tr2);//活动
        } 
        #endregion

        #region 显示数据
        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowData()
        {
            int dBuySum = 0;//Convert.ToInt32(LoginUser.StockA);//GetBuySum();

            txtAmount.Value = dBuySum.ToString();//已购

            int a = getGPInt("Share7");
            lgk.Model.tb_StockIssue Issue = tb_stockIssueBLL.GetModel(" RoundNum=" + a);

            if (Issue == null) 
            {
                btnSubmit.Visible = false;
                ltReminder.Text = "股份尚未开始出售！";
            }
            else
            {
                //当前价格
                txtPrice.Value = getGPVarchar("Share5");
                if (Issue.IsSell == 0)
                {
                    btnSubmit.Visible = false;
                    ltReminder.Text = "此次股份出售已结束！";
                }
                else
                {
                    if (LoginUser.IsOpend != 2)
                    {
                        btnSubmit.Visible = false;
                        ltReminder.Text = "您尚未开通，无权购买股份，请联系代理再试！";
                    }
                    else
                    {
                        if (LoginUser.User015 <= 0)
                        {
                            btnSubmit.Visible = false;
                            ltReminder.Text = "您余额不足，请充值后再试！";
                        }
                        else
                        {
                            txtEmoney.Value = LoginUser.User015.ToString();//现有金额
                        }
                    }
                }
            }
        } 
        #endregion

        #region 获取已购买数量tb_Stock表
        /// <summary>
        /// 获取已购买数量tb_Stock表
        /// </summary>
        /// <returns></returns>
        private decimal GetBuySum()
        {
            decimal dBuySum = Convert.ToDecimal(0.00);//
            int a = getGPInt("Share7");
            IList<lgk.Model.tb_Stock> myList = new lgk.BLL.tb_Stock().GetModelList("UserID=" + getLoginID() + " RoundNum=" + a);
            if (myList.Count > 0)
            {
                foreach (lgk.Model.tb_Stock item in myList)
                {
                    dBuySum += item.s001;
                }
            }

            return dBuySum;
        } 
        #endregion

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "";

            strWhere = " UserID=" + LoginUser.UserID.ToString();

            #region 下定时间
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyTime,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyTime,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyTime,120)  between '" + strStartTime + "' AND '" + strEndTime + "'");
            }
            #endregion

            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region 数据验证

            //decimal dBuySum = Convert.ToDecimal(0.00);//已购买金额
            decimal dEmoney = Convert.ToDecimal(0.00);//现有金额

            string inum = txtBuy.Text.Trim();

            if (inum == "")
            {
                MessageBox.MyShow(this, "购买金额不能为空！");//额不能为空
                return;
            }

            try
            {
                int an = Convert.ToInt32(inum);
            }
            catch 
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('购买数量请输入整数');", true);
                return;
            }
            int buyNum = Convert.ToInt32(inum);//输入的购买数量

            if (LoginUser.ThreePassword != PageValidate.GetMd5(txtAnswer.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('三级密码错误');", true);
                return;
            }
            #endregion

            decimal price = getGPAmount("Share5");//起始价格
            lgk.Model.tb_StockMode mode = tb_stockModeBLL.GetModel(" Status=0 ");

            int totalStock = tb_stockBuyBLL.GetSum("sb001", " UserID=" + getLoginID());//我已购买的股份
            int limitStock = getGPInt("Share9");//每人限定购买的数额

            if (buyNum + totalStock > limitStock)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您要购买的数量已超过限定数量！');", true);
                return;
            }

            int er = tb_stockBuyBLL.proc_StockBuyBulk(Convert.ToInt32(LoginUser.UserID), buyNum);
            if (er > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('购买成功！');window.location.href='BuyEdit.aspx';", true);//
                return;
            }
            else if (er == -3)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您的余额不足！');", true);//
                return;
            }
            else if (er == -4)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('你要购买的数量已经超过您的限额！');", true);//
                return;
            }
            else if (er == -5)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此次股份售出已结束！');", true);//
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作出现异常！');", true);//
                return;
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int iStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status"));

                Literal ltStatus = (Literal)e.Item.FindControl("ltStatus");//订单状态

                if (iStatus == 0)
                {
                    ltStatus.Text = "等待买入";
                }
                else if (iStatus == 1)
                {
                    ltStatus.Text = "购买完成";
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "change")
            {
                int iStockBuyID = Convert.ToInt32(e.CommandArgument);
                lgk.Model.StockBuy stockBuyInfo = stockBuyBLL.GetModel(iStockBuyID);
                if (stockBuyInfo == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordDeleted") + "');", true);//该记录已删除，无法再进行此操作
                    return;
                }
                if (stockBuyInfo.IsBuy != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股份已购买，不能撤销！');", true);//该记录已审核，无法再进行此操作
                    return;
                }

                int iFalg = UpdateAccount("BonusAccount", getLoginID(), stockBuyInfo.Amount, 1);
                if (iFalg > 0)
                {
                    if (stockBuyBLL.Delete(stockBuyInfo.StockBuyID))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("CancellationSuccess") + "');window.location.href='BuyEdit.aspx';", true);//取消成功
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("FailedToCancel") + "');", true);//取消失败
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("FailedToCancel") + "');", true);//取消失败
                }
            }
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int iStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status"));

                Literal ltStatus = (Literal)e.Item.FindControl("ltStatus");//订单状态

                if (iStatus == 0)
                {
                    ltStatus.Text = "已发行";
                }
                else if (iStatus == 1)
                {
                    ltStatus.Text = "出售中";
                }
                else if (iStatus == 2)
                {
                    ltStatus.Text = "已结束";
                }
            }
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "buy")
            {
                TextBox tbBuyNum = (TextBox)e.Item.FindControl("txtbuyNum");
                if (tbBuyNum.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('购买数量不能为空！');", true);//
                    return;
                }

                if (!PageValidate.IsInteger(tbBuyNum.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('购买数量处请输入有效的数值！');", true);//
                    return;
                }

                int buyNum = Convert.ToInt32(tbBuyNum.Text.Trim());
                int iID = Convert.ToInt32(e.CommandArgument);
                lgk.Model.tb_StockMode stockModeInfo = tb_stockModeBLL.GetModel(iID);

                if (stockModeInfo == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordDeleted") + "');", true);//该记录已删除，无法再进行此操作
                    return;
                }
                if (stockModeInfo.sm001 < buyNum)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此种股份剩余量不足！');", true);//
                    return;
                }

                lgk.Model.tb_StockIssue Issue = tb_stockIssueBLL.GetModel(" RoundNum=" + stockModeInfo.RoundNum);
                if (Issue.SurplusQuantity < buyNum)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('系统股份剩余量不足！');", true);//
                    return;
                }

                //decimal price = getGPAmount("Share5");
                //decimal StockMoney = price * buyNum * 10;
                //if (StockMoney > LoginUser.BonusAccount)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您的余额不足！');", true);//
                //    return;
                //}
                int er = tb_stockBuyBLL.proc_StockBuy(getLoginID(), buyNum, stockModeInfo.Period);
                if (er > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('购买成功！');window.location.href='BuyEdit.aspx';", true);//
                    return;
                }
                else if (er == -3)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您的余额不足！');", true);//
                    return;
                }
                else if (er == -4)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('你要购买的数量已经超过您的限额！');", true);//
                    return;
                }
                else if (er == -5)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此次股份售出已结束！');", true);//
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作出现异常！');", true);//
                    return;
                }
            }
        }

    }
}