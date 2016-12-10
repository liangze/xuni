/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-12-25 10:04:41 
 * 文 件 名：		order.cs 
 * CLR 版本: 		2.0.50727.3643 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.shop
{
    public partial class order : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string getWhere()
        {
            string id = Request.QueryString["type"];
            string str = " o.UserID=" + LoginUser.UserID;
            switch (id)
            {
                case "1": str += ""; break;
                case "2": str += " and o.IsSend=0"; break;//未付款
                case "3": str += " and o.IsSend=1"; break;//待发货
                case "4": str += " and o.IsSend=2"; break;//已发货
                case "5": str += " and o.IsSend=3"; break;//已完成
            }
            return str;
        }

        private void bind()
        {
            bind_repeater(GetAllOrderList(getWhere()), Repeater1, "IsSend asc,OrderDate desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string strOrderCode = e.CommandArgument.ToString();

            lgk.Model.tb_Order orderInfo = orderBLL.GetModelByCode(strOrderCode);
            if (orderInfo==null)
            {
                MessageBox.ShowAndRedirect(this, "订单已经修改", "order.aspx");//未收货成功
                return;
            }

            if (e.CommandName.Equals("Payment"))
            {
                #region 确认收货
                HiddenField hft = (HiddenField)e.Item.FindControl("hft");//状态
                if (hft.Value == "2") //确认收货
                {
                    orderInfo.IsSend = 3;
                    if (orderBLL.Update(orderInfo))
                    {
                        //proc_Award_Shopping结算购物奖
                        //bonusBLL.ShoppingAward(orderInfo.UserID, orderInfo.PVTotal);

                        MessageBox.ShowAndRedirect(this, GetLanguage("CashReceipt"), "order.aspx");//收货成功
                        return;
                    }
                    else
                    {
                        MessageBox.ShowAndRedirect(this, GetLanguage("FailedReceive"), "order.aspx");//收货失败
                        return;
                    }
                }
                #endregion
            }
            if (e.CommandName.Equals("Receipt"))
            {
                orderInfo.IsSend = 4;
                if (orderBLL.Update(orderInfo))
                {
                    MessageBox.ShowAndRedirect(this, GetLanguage("NotSuccessfully"), "order.aspx");//未收货成功
                    return;
                }
                else
                {
                    MessageBox.ShowAndRedirect(this, GetLanguage("NoReceiptFail"), "order.aspx");//未收货失败
                    return;
                }
            }
            if (e.CommandName.Equals("Detail"))
            {
                Response.Redirect("order_detail.aspx?OrderCode=" + strOrderCode);
            }
            if (e.CommandName.Equals("cancel")) //删除订单
            {
                #region 删除订单
                lgk.Model.tb_user user = userBLL.GetModel(orderInfo.UserID);
                try
                {
                    user.ShopAccount += orderInfo.PVTotal;
                    userBLL.Update(user);

                    add_journal(orderInfo.UserID, orderInfo.PVTotal, 0, user.ShopAccount, 7,"删除订单", "Delete orders", orderInfo.UserID);

                    DeleteByCode(orderInfo.OrderCode);
                    orderBLL.Delete(orderInfo.OrderID);
                    MessageBox.ShowAndRedirect(this, GetLanguage("OrderSuccessfully"), "order.aspx");//订单删除成功
                }
                catch
                {
                    MessageBox.ShowAndRedirect(this, GetLanguage("OrderFailed"), "order.aspx");//订单删除失败
                }
                #endregion
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {
                //未付款0，待发货1，待收货为2，已完成3
                LinkButton lbtnPayment = (LinkButton)e.Item.FindControl("lbtnPayment");
                LinkButton lbtnReceipt = (LinkButton)e.Item.FindControl("lbtnReceipt");
                HiddenField hft = (HiddenField)e.Item.FindControl("hft");//状态
                if (lbtnPayment != null && hft != null)
                {
                    int iType = int.Parse(hft.Value);
                    if (iType <= 1)
                    {
                        lbtnPayment.Visible = false;
                        lbtnReceipt.Visible = true;
                        return;
                    }
                    if (iType == 2)
                    {
                        lbtnPayment.Visible = true;
                        lbtnReceipt.Visible = true;
                        lbtnPayment.Text = GetLanguage("ConfirmReceipt");//确认收货
                        return;
                    }
                    else if (iType >= 3)
                    {
                        lbtnPayment.Visible = false;
                        lbtnReceipt.Visible = false;
                        return;
                    }
                }
            }
        }

        protected string GetState(string id)
        {
            string state = "";
            if (Language == "zh-cn")
            {
                switch (id)
                {
                    case "0":
                        state = "未付款";
                        break;
                    case "1":
                        state = "待发货";
                        break;
                    case "2":
                        state = "已发货";
                        break;
                    case "3":
                        state = "已完成";
                        break;
                    case "4":
                        state = "已收货";
                        break;
                }
            }
            else
            {
                switch (id)
                {
                    case "0":
                        state = GetLanguage("Non-payment");
                        break;
                    case "1":
                        state = GetLanguage("ToBeShipped");
                        break;
                    case "2":
                        state = GetLanguage("Shipped");
                        break;
                    case "3":
                        state = GetLanguage("Completed");
                        break;
                    case "4":
                        state = GetLanguage("NotReceive");
                        break;
                }
            }
            return state;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }
    }
}
