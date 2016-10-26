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
    public partial class CashbuyDetail : PageCore
    {
        /// <summary>
        /// 登录用户编号
        /// </summary>
        private long iUserID = 0;

        /// <summary>
        /// EP币销售ID
        /// </summary>
        private long iCashsellID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码

            iUserID = getLoginID();

            btnBack.Text = GetLanguage("Return");//返 回

            if (Request["CashsellID"] != null && Request["CashsellID"].Length > 0)
            {
                if (PageValidate.IsLong(Request["CashsellID"]))
                {
                    iCashsellID = Convert.ToInt64(Request["CashsellID"].ToString());
                }
            }
            else
            {
                iCashsellID = 0;
            }

            if (!IsPostBack)
            {
                ShowData();

                btnBack.Text = GetLanguage("Back");//返回
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowData()
        {
            lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetModel(iCashsellID);

            if (cashsellInfo != null)
            {
                #region 商品信息
                ltTitle.Text = cashsellInfo.Title;
                ltAmount.Text = cashsellInfo.Amount.ToString("0.00");
                ltNumber.Text = (cashsellInfo.Number + cashsellInfo.Charge).ToString();
                ltPayment.Text = cashsellInfo.Number.ToString();
                ltArrival.Text = (cashsellInfo.Number + cashsellInfo.Number * getParamAmount("Gold3") / 100).ToString();
                ltPrice.Text = cashsellInfo.Price.ToString("0.00");
                ltUnitNum.Text = cashsellInfo.UnitNum.ToString();
                #endregion

                #region 卖家信息
                lgk.Model.tb_user userInfo = userBLL.GetModel(cashsellInfo.UserID);
                ltUserCode.Text = userInfo.UserCode;//会员编号

                ltBankName.Text = userInfo.BankName;//开户银行

                ltTrueName.Text = userInfo.TrueName;//银行姓名

                ltBankAccount.Text = userInfo.BankAccount;//银行帐号

                ltBankAccountUser.Text = userInfo.BankAccountUser;//银行姓名

                ltBankBranch.Text = userInfo.BankBranch;//开户网点

                ltQQnumer.Text = userInfo.QQnumer;//卖家QQ号码

                ltPhoneNum.Text = userInfo.PhoneNum;//卖家手机号码
                #endregion

                #region 信用等级
                lgk.Model.Cashcredit cashcreditInfo = cashcreditBLL.GetModel("UserID=" + cashsellInfo.UserID + "");
                if (cashcreditInfo != null)
                    ltGrade.Text = cashcreditInfo.BValues.ToString();
                #endregion
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cashbuy.aspx");
        }
    }
}