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
    public partial class Cashsell : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转3级密码

            if (!IsPostBack)
            {
                ShowData();
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowData()
        {
            #region 用户信息
            ltUserCode.Text = LoginUser.UserCode;//会员编号

            ltBankName.Text = LoginUser.BankName;//开户银行

            ltTrueName.Text = LoginUser.TrueName;//银行姓名

            ltBankAccount.Text = LoginUser.BankAccount;//银行帐号

            ltBankAccountUser.Text = LoginUser.BankAccountUser;//银行姓名

            ltBankBranch.Text = LoginUser.BankBranch;//开户网点

            ltQQnumer.Text = LoginUser.QQnumer;//卖家QQ号码

            ltPhoneNum.Text = LoginUser.PhoneNum;//卖家手机号码
            #endregion

            decimal dBonus = LoginUser.BonusAccount;
            ltNumber.Text = Math.Round(dBonus, 0).ToString();

            if (dBonus < 1)
            {
                btnSubmit.Visible = false;
                if (currentCulture == "en-us")
                    ltWarning.Text = GetLanguage("AvailableGold");
                else
                    ltWarning.Text = GetLanguage("AvailableGold");
            }

            if (LoginUser.IsOpend == 1)
            {
                btnSubmit.Visible = false;
                if (currentCulture == "en-us")
                    ltWarning.Text = GetLanguage("CanORNo");
                else
                    ltWarning.Text = GetLanguage("CanORNo");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (getParamInt("Gold") == 0)
            {
                MessageBox.Show(this, GetLanguage("Feature"));//该功能未开放
                return;
            }

            #region 金额验证
            if (txtNumber.Text.Trim() == "")
            {
                MessageBox.MyShow(this, GetLanguage("AmountNoEmpty"));//卖出金额不能为空
                return;
            }
            decimal dNumber = 0;
            if (decimal.TryParse(txtNumber.Text.Trim(), out dNumber))
            {
                decimal dGold1 = getParamAmount("Gold1");
                if (dNumber < dGold1)
                {
                    MessageBox.MyShow(this, GetLanguage("Minimum"));//最小交易额!
                    return;
                }
            }
            else
            {
                MessageBox.MyShow(this, GetLanguage("NumberThanZero"));//金额格式输入错误
                return;
            }

            decimal dMaxNumber = 0;//每日最大挂卖数量
            decimal dBNumber = 0, dBaseNumber = 0;//每日挂卖基数
            decimal dANumber = 0;//今日已挂卖数量

            dBaseNumber = getParamAmount("Gold6");
            dBNumber = getParamAmount("Gold7");
            dMaxNumber = dBaseNumber + dBNumber * userBLL.GetCount("RecommendID = " + LoginUser.UserID + " AND IsOpend = 2");//每日挂卖基数
            dANumber = cashsellBLL.GetAlready(LoginUser.UserID) + dNumber;

            if (dANumber > dMaxNumber)
            {
                MessageBox.MyShow(this, GetLanguage("ConsignmentOver"));//寄售数量已超额
                return;
            }

            if (txtPrice.Text.Trim() == "")
            {
                MessageBox.MyShow(this, GetLanguage("PriceEmpty"));//价格不能为空
                return;
            }
            decimal dPrice = 0;
            if (decimal.TryParse(txtPrice.Text.Trim(), out dPrice))
            {
                decimal dGoldMin = getParamAmount("GoldMin");//最低价格
                decimal dGoldMax = getParamAmount("GoldMax");//最高价格

                if (dPrice < dGoldMin)
                {
                    MessageBox.MyShow(this, GetLanguage("PriceBetween"));
                    return;
                }
                else if (dPrice > dGoldMax)
                {
                    MessageBox.MyShow(this, GetLanguage("PriceBetween"));
                    return;
                }
            }
            else
            {
                MessageBox.MyShow(this, GetLanguage("PriceFormat"));//价格格式错误
                return;
            }

            #endregion

            if (txtThreePassword.Value.Trim() == "")
            {
                MessageBox.MyShow(this, GetLanguage("PleaseThreePassword"));
                return;
            }

            string strPassword = PageValidate.GetMd5(txtThreePassword.Value.Trim());
            int re = spd.findpwsCount(strPassword, 1, getLoginID());
            if (re == 0)
            {
                MessageBox.MyShow(this, GetLanguage("PasswordError"));
                return;
            }

            int iUnitNum = Convert.ToInt32(txtUnitNum.Value.Trim());//发布件数1
            decimal dFactorage = dNumber * getParamAmount("Gold2") / 100;//手续费

            lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
            lgk.Model.Cashsell cashsellInfo = new lgk.Model.Cashsell();

            decimal dAmount = dNumber * dPrice;

            userInfo = userBLL.GetModel(getLoginID());

            #region 赋值给金币销售表实体
            cashsellInfo.Title = dNumber.ToString() + "金币=" + dAmount.ToString() + "元，物超所值！";
            cashsellInfo.UserID = getLoginID();
            cashsellInfo.Amount = dAmount;//商品价格
            cashsellInfo.Number = Convert.ToInt32(dNumber);//单件数量
            cashsellInfo.Price = dPrice;//商品单价
            cashsellInfo.UnitNum = 1;//发布件数
            cashsellInfo.SaleNum = 0;//已卖件数
            cashsellInfo.Charge = dFactorage;//每件所需手续费
            cashsellInfo.SellDate = DateTime.Now;//提交时间
            cashsellInfo.Remark = "";
            cashsellInfo.PurchaseID = 0;
            cashsellInfo.IsSell = 1;
            #endregion

            #region 加入流水账表
            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            journalInfo.UserID = cashsellInfo.UserID;
            journalInfo.Remark = "卖出流通币";
            journalInfo.RemarkEn = "Sell Circulating gold";
            journalInfo.InAmount = 0;
            journalInfo.OutAmount = cashsellInfo.Number * iUnitNum + dFactorage;
            journalInfo.BalanceAmount = userInfo.BonusAccount - dNumber - dFactorage;
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = 1;
            journalInfo.Journal01 = cashsellInfo.UserID;
            #endregion

            decimal dBonusAccount = dNumber + dFactorage;

            if (userInfo.BonusAccount < dBonusAccount)
            {
                MessageBox.MyShow(this, GetLanguage("GoldInsufficient"));
                return;
            }

            if (cashsellBLL.Add(cashsellInfo) > 0 && journalBLL.Add(journalInfo) > 0 && UpdateAccount("BonusAccount", getLoginID(), dBonusAccount, 0) > 0)
            {
                SetCashcredit();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');window.location.href='CashsellList.aspx';", true);
            }
            else
                MessageBox.MyShow(this, GetLanguage("OperationFailed"));
        }

        /// <summary>
        /// 设置销售信用度
        /// </summary>
        private void SetCashcredit()
        {
            lgk.Model.Cashcredit cashcreditInfo = new lgk.Model.Cashcredit();

            if (cashcreditBLL.Exists("UserID=" + LoginUser.UserID + ""))
            {
                cashcreditInfo = cashcreditBLL.GetModel("UserID=" + LoginUser.UserID + "");

                cashcreditInfo.SNumber = cashcreditInfo.SNumber + 1;
                if (cashcreditInfo.SValues == 0)
                    cashcreditInfo.SValues = 0;

                cashcreditBLL.Update(cashcreditInfo);
            }
            else
            {
                cashcreditInfo.UserID = getLoginID();
                cashcreditInfo.BNumber = 0;
                cashcreditInfo.BTradeNum = 0;
                cashcreditInfo.BEndNum = 0;
                cashcreditInfo.BValues = 5;
                cashcreditInfo.SNumber = 1;
                cashcreditInfo.STradeNum = 0;
                cashcreditInfo.SEndNum = 0;
                cashcreditInfo.SValues = 5;

                cashcreditBLL.Add(cashcreditInfo);
            }
        }

        protected void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.Trim() != "")
            {
                decimal dNumber = Convert.ToDecimal(txtNumber.Text.Trim());//单件数量

                txtFactorage.Value = (dNumber * getParamAmount("Gold2") / 100).ToString();
            }
        }
    }
}