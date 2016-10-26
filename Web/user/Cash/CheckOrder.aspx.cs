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
    public partial class CheckOrder : PageCore
    {
        /// <summary>
        /// 登录用户编号
        /// </summary>
        private long iUserID = 0;

        /// <summary>
        /// 操作字符
        /// </summary>
        private string strAction = "";

        /// <summary>
        /// 订单编号
        /// </summary>
        private long iOrderID = 0;

        /// <summary>
        /// 操作方式
        /// </summary>
        private int iActionID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转3级密码

            iUserID = getLoginID();

            if (Request["Action"] != null && Request["Action"].Length > 0)
            {
                strAction = Request["Action"].ToString();

                string[] sArray = strAction.Split(',');

                if (sArray.Length == 2)
                {
                    if (PageValidate.IsLong(sArray[0]))
                        iOrderID = Convert.ToInt64(sArray[0]);

                    if (PageValidate.IsInteger(sArray[1]))
                        iActionID = Convert.ToInt32(sArray[1]);
                }
            }
            else
            {
                strAction = "";
                iOrderID = 0;
                iActionID = 0;
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
                ltOrderCode.Text = cashorderInfo.OrderCode;
                ltOrderDate.Text = cashorderInfo.OrderDate.ToString();
                #endregion

                #region 商品信息
                ltTitle.Text = cashsellBLL.GetModel(cashorderInfo.CashsellID).Title;
                lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);
                ltAmount.Text = cashbuyInfo.Amount.ToString();
                ltNumber.Text = (cashbuyInfo.Number + cashbuyInfo.Number * getParamAmount("Gold2") / 100).ToString();
                ltPayment.Text = cashbuyInfo.Number.ToString();
                ltArrival.Text = (cashbuyInfo.Number + cashbuyInfo.Number * getParamAmount("Gold3") / 100).ToString();
                ltPrice.Text = cashbuyInfo.Price.ToString();
                ltBuyNum.Text = cashbuyInfo.BuyNum.ToString();
                #endregion

                #region 卖家信息
                lgk.Model.tb_user userInfo = userBLL.GetModel(cashorderInfo.SUserID);
                ltSUserCode.Text = userInfo.UserCode;//会员编号

                ltSBankName.Text = userInfo.BankName;//开户银行

                ltSTrueName.Text = userInfo.TrueName;//银行姓名

                ltSBankAccount.Text = userInfo.BankAccount;//银行帐号

                ltSBankAccountUser.Text = userInfo.BankAccountUser;//银行姓名

                ltSBankBranch.Text = userInfo.BankBranch;//开户网点

                ltSQQnumer.Text = userInfo.QQnumer;//卖家QQ号码

                ltSPhoneNum.Text = userInfo.PhoneNum;//卖家手机号码
                #endregion

                #region 信用等级
                if (iUserID == cashorderInfo.SUserID)
                {
                    ltCredit.Text = GetLanguage("BuyersRating");
                    int iSValues = cashcreditBLL.GetValues(cashorderInfo.SUserID, "SValues");
                    if (iSValues > 0)
                    {
                        for (int i = 0; i < iSValues; i++)
                        {
                            ltGrade.Text += "<img alt='' src='../../images/start.png' />";
                        }
                    }
                }
                else if (iUserID == cashorderInfo.BUserID)
                {
                    ltCredit.Text = GetLanguage("SellersRating");
                    int iBValues = cashcreditBLL.GetValues(cashorderInfo.SUserID, "SValues");
                    if (iBValues > 0)
                    {
                        for (int i = 0; i < iBValues; i++)
                        {
                            ltGrade.Text += "<img alt='' src='../../images/start.png' />";
                        }
                    }
                }
                #endregion

                if (cashorderInfo.BUserID == iUserID && cashorderInfo.SStatus == 0 && cashorderInfo.BStatus == 0 && iActionID == 1)
                    btnCheck.Text = GetLanguage("Payment");//"付 款";
                else if (cashorderInfo.SUserID == iUserID && cashorderInfo.BStatus == 1 && cashorderInfo.SStatus == 0 && iActionID == 2)
                    btnCheck.Text = GetLanguage("ConfirmPayment");//"确认已付款"
                else
                    btnCheck.Visible = false;
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(iOrderID);

            if (cashorderInfo.BUserID == iUserID && cashorderInfo.SStatus == 0 && cashorderInfo.BStatus == 0 && iActionID == 1)
            {
                cashorderBLL.Update(iUserID, cashorderInfo.OrderID, DateTime.Now, 1);//付款
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');window.location.href='CashOrderList.aspx';", true);
            }
            else if (cashorderInfo.SUserID == iUserID && cashorderInfo.BStatus == 1 && cashorderInfo.SStatus == 0 && iActionID == 2)
            {
                cashorderBLL.Update(iUserID, cashorderInfo.OrderID, DateTime.Now, 2);//确认已付款

                cashorderBLL.Update(cashorderInfo.SUserID, iOrderID, DateTime.Now, 3);//发货

                lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);

                lgk.Model.Cashsell CashsellInfo = cashsellBLL.GetModel(cashbuyInfo.CashsellID);

                decimal dNumber = CashsellInfo.Number;
                //decimal dCharge = CashsellInfo.Charge;//总手续费
                decimal dMTaxRate = dNumber * getParamAmount("Gold3") / 100;//买家获得手续费
                decimal dCTaxRate = dNumber * getParamAmount("Gold4") / 100;//公司获得手续费

                //decimal dTNumber = dNumber - dCharge + dMTaxRate;
                decimal dTNumber = dNumber + dMTaxRate;

                UpdateAccount("BonusAccount", cashorderInfo.BUserID, dTNumber, 1);//发货给购买者

                UpdateSystemAccount("MoneyAccount", dCTaxRate, 1);

                ////SetAccount(iUserID, dAccount, "EP币发货！", 1);
                SetAccount(cashorderInfo.BUserID, dTNumber, "金币发货！", cashorderInfo.SUserID);

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');window.location.href='CashOrderList.aspx';", true);
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');window.location.href='CashOrderList.aspx';", true);
        }

        /// <summary>
        /// 加入流水账表
        /// </summary>
        /// <param name="iUserID">用户编号</param>
        /// <param name="dAccount">收发货数量</param>
        /// <param name="strRemark">备注</param>
        private void SetAccount(long iBUserID, decimal dAccount, string strRemark, long iSUserID)
        {
            #region 加入流水账表

            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            lgk.Model.tb_user userInfo = userBLL.GetModel(iBUserID);
            journalInfo.UserID = iBUserID;
            journalInfo.Remark = strRemark;//"EP币发货";
            journalInfo.RemarkEn = "Gold coin receipt!";
            journalInfo.InAmount = dAccount;
            journalInfo.OutAmount = 0;
            journalInfo.BalanceAmount = userInfo.BonusAccount;//EP币收货！
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = 1;
            journalInfo.Journal01 = iSUserID;

            #endregion

            journalBLL.Add(journalInfo);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CashOrderList.aspx");
        }
    }
}