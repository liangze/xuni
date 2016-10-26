using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.Cash
{
    public partial class CashOrderDetail : PageCore
    {
        /// <summary>
        /// 登录用户编号
        /// </summary>
        private long iUserID = 0;

        /// <summary>
        /// 订单编号
        /// </summary>
        private long iOrderID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码

            iUserID = getLoginID();

            if (Request["OrderID"] != null && Request["OrderID"].Length > 0)
            {
                if (PageValidate.IsLong(Request["OrderID"]))
                {
                    iOrderID = Convert.ToInt64(Request["OrderID"].ToString());
                }
            }
            else
            {
                iOrderID = 0;
            }

            btnBack.Text = GetLanguage("Return");//返 回

            if (!IsPostBack)
            {
                ShowData();
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowData()
        {
            lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(iOrderID);

            if (cashorderInfo != null)
            {
                #region 订单信息
                lblOrderCode.Text = cashorderInfo.OrderCode;
                lbOrderDate.Text = cashorderInfo.OrderDate.ToString();
                ltBRemark.Text = cashorderInfo.BRemark;
                ltSRemark.Text = cashorderInfo.SRemark;
                #endregion

                #region 商品信息
                ltTitle.Text = cashsellBLL.GetModel(cashorderInfo.CashsellID).Title;
                lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);
                ltAmount.Text = cashbuyInfo.Amount.ToString("0.00");
                ltNumber.Text = (cashbuyInfo.Number + cashbuyInfo.Number * getParamAmount("Gold2") / 100).ToString();
                ltPayment.Text = cashbuyInfo.Number.ToString();
                ltArrival.Text = (cashbuyInfo.Number + cashbuyInfo.Number * getParamAmount("Gold3") / 100).ToString();
                ltPrice.Text = cashbuyInfo.Price.ToString("0.00");
                ltBuyNum.Text = cashbuyInfo.BuyNum.ToString();
                #endregion

                #region 卖家信息
                lgk.Model.tb_user suserInfo = userBLL.GetModel(cashorderInfo.SUserID);

                ltSUserCode.Text = suserInfo.UserCode;//会员编号

                ltSBankName.Text = suserInfo.BankName;//开户银行

                ltSTrueName.Text = suserInfo.TrueName;//银行姓名

                ltSBankAccount.Text = suserInfo.BankAccount;//银行帐号

                ltSBankAccountUser.Text = suserInfo.BankAccountUser;//银行姓名

                ltSBankBranch.Text = suserInfo.BankBranch;//开户网点

                if (suserInfo.QQnumer != null)
                    ltSQQnumer.Text = suserInfo.QQnumer;//卖家QQ号码

                ltSPhoneNum.Text = suserInfo.PhoneNum;//卖家手机号码
                #endregion

                #region 买家信息
                lgk.Model.tb_user buserInfo = userBLL.GetModel(cashorderInfo.BUserID);

                ltBUserCode.Text = buserInfo.UserCode;//会员编号

                ltBBankName.Text = buserInfo.BankName;//开户银行

                ltBTrueName.Text = buserInfo.TrueName;//银行姓名

                ltBBankAccount.Text = buserInfo.BankAccount;//银行帐号

                ltBBankAccountUser.Text = buserInfo.BankAccountUser;//银行姓名

                ltBBankBranch.Text = buserInfo.BankBranch;//开户网点

                if (buserInfo.QQnumer != null)
                    ltBQQnumer.Text = buserInfo.QQnumer;//卖家QQ号码

                ltBPhoneNum.Text = buserInfo.PhoneNum;//卖家手机号码
                #endregion

                #region 信用等级
                int iBValues = cashcreditBLL.GetValues(cashorderInfo.SUserID, "BValues");
                if (iBValues > 0)
                {
                    for (int i = 0; i < iBValues; i++)
                    {
                        ltSGrade.Text += "<img alt='' src='../../images/start.png' />";
                    }
                }

                int iSValues = cashcreditBLL.GetValues(cashorderInfo.BUserID, "SValues");
                if (iSValues > 0)
                {
                    for (int i = 0; i < iSValues; i++)
                    {
                        ltBGrade.Text += "<img alt='' src='../../images/start.png' />";
                    }
                }
                #endregion
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CashOrderList.aspx");
        }
    }
}