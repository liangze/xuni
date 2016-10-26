using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using lgk.Model;

namespace Web.user.finance
{
    public partial class TransferToEmoney : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                txtBonusAccount.Value = LoginUser.BonusAccount.ToString();//佣金币余额
                txtEmoney.Value = LoginUser.Emoney.ToString();//现金币余额
                txtStockMoney.Value = LoginUser.GLmoney.ToString();//购物币余额

                BindCurrency();
                BindData();
                btnSubmit.Text = GetLanguage("Submit");//提交
                btnSubmit.OnClientClick = "javascript:return confirm('" + GetLanguage("TransferConfirm") + "')";
                btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

        private void BindCurrency()
        {
            if (GetLanguage("LoginLable") == "zh-cn")
            {
                dropCurrency.Items.Add(new ListItem("-请选择-", "0"));
                dropCurrency.Items.Add(new ListItem("流通币转MDD钻币", "1"));
                dropCurrency.Items.Add(new ListItem("流通币转注册币", "2"));
                dropCurrency.Items.Add(new ListItem("流通币转购物币", "3"));
                dropCurrency.Items.Add(new ListItem("注册币转购物币", "4"));
                dropCurrency.Items.Add(new ListItem("注册币转其他会员", "5"));

                dropType.Items.Add(new ListItem("-请选择-", "0"));
                dropType.Items.Add(new ListItem("流通币", "1"));
                dropType.Items.Add(new ListItem("MDD钻币", "2"));
                dropType.Items.Add(new ListItem("平台费用", "3"));
                dropType.Items.Add(new ListItem("购物币", "4"));
                dropType.Items.Add(new ListItem("注册币", "5"));
            }
            else
            {
                dropCurrency.Items.Add(new ListItem("-Please choose-", "0"));
                dropCurrency.Items.Add(new ListItem("Currency to MDD drill", "1"));
                dropCurrency.Items.Add(new ListItem("Currency to Registered currency", "2"));
                dropCurrency.Items.Add(new ListItem("Currency to shopping currency", "3"));
                dropCurrency.Items.Add(new ListItem("Registered currency to shopping currency", "4"));
                dropCurrency.Items.Add(new ListItem("Registered currency to other members", "5"));

                dropType.Items.Add(new ListItem("-Please choose-", "0"));
                dropType.Items.Add(new ListItem("Currency", "1"));
                dropType.Items.Add(new ListItem("MDD Drill", "2"));
                dropType.Items.Add(new ListItem("Platform cost", "3"));
                dropType.Items.Add(new ListItem("Shopping currency", "4"));
                dropType.Items.Add(new ListItem("Registered currency", "5"));
            }
        }

        private bool CheckOpen(string value)
        {
            switch (value)
            {
                case "1":
                    var iOpen1 = getParamInt("Transfer4");
                    if (iOpen1 != 1)//流通币转MDD钻币功能未开放
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "2":
                    var iOpen2 = getParamAmount("Transfer5");
                    if (iOpen2 != 1)//流通币转注册币功能未开放
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "3":
                    var iOpen3 = getParamAmount("Transfer6");
                    if (iOpen3 != 1)//流通币转购物币功能未开放
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "4":
                    var iOpen4 = getParamAmount("Transfer7");
                    if (iOpen4 != 1)//注册币转购物币功能未开放
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "5":
                    var iOpen5 = getParamAmount("Transfer8");
                    if (iOpen5 != 1)//注册币转其他会员功能未开放
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                default://请选择转账类型
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ChooseTransfer") + "');", true);
                    return false;
            }
            return true;
        }

        protected void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            string strUserCode = txtUserCode.Text.Trim();
            var user = userBLL.GetModel(" UserCode='" + strUserCode + "'");
            if (user != null)
            {
                txtTrueName.Text = user.TrueName;
            }
            else
            {
                txtTrueName.Text = string.Empty;
                MessageBox.Show(this, GetLanguage("numberIsExist"));//会员编号不存在
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long toUserID = 0;
            lgk.Model.tb_user userInfo = userBLL.GetModel(getLoginID());
            lgk.Model.tb_change changeInfo = new lgk.Model.tb_change();

            if (dropCurrency.SelectedValue == "0")
            {
                MessageBox.Show(this, "" + GetLanguage("ChooseTransfer") + "");//请选择转账类型
                return;
            }
            if (!CheckOpen(dropCurrency.SelectedValue))
            {
                MessageBox.Show(this, "" + GetLanguage("Feature") + "");//该功能未开放
                return;
            }
            int iTypeID = int.Parse(dropCurrency.SelectedValue);
            if (txtMoney.Text.Trim() == "")
            {
                MessageBox.Show(this, "" + GetLanguage("transferMoneyIsnull") + "");//转账金额不能为空
                return;
            }

            decimal dResult = 0;
            if (decimal.TryParse(txtMoney.Text.Trim(), out dResult))
            {
                decimal dTrans = getParamAmount("Transfer1");//转账最低金额
                decimal d = getParamAmount("Transfer2");//转账倍数基数
                if (dResult < dTrans)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("equalTo") + dTrans + "');", true);//转账金额必须是大于等于XX的整数
                    return;
                }
                if (d != 0 && dResult % d != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("amountMustbe") + "" + d + "" + GetLanguage("Multiples") + "');", true);//转账金额必须是XX的倍数
                    return;
                }
            }

            if (iTypeID != 0)
            {
                if (iTypeID <= 3 && dResult > userInfo.BonusAccount)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NotCurrent") + "');", true);
                    return;
                }
                else if (iTypeID >= 4 && dResult > userInfo.StockAccount)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NotRegistered") + "');", true);
                    return;
                }
            }
            
            string strUserCode = txtUserCode.Text.Trim();
            var toUser = userBLL.GetModel(" UserCode='" + strUserCode + "'");
            if (toUser == null)
            {
                MessageBox.Show(this, GetLanguage("numberIsExist"));//会员编号不存在
                return;
            }
            else
            {
                toUserID = int.Parse(toUser.UserID.ToString());
            }

            if (toUserID <= 0)
            {
                MessageBox.Show(this, GetLanguage("objectExist"));//转帐对象不存在
                return;
            }

            if (dropCurrency.SelectedValue == "5")
            {
                if (toUserID == userInfo.UserID)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TransferToOuner") + "');", true);
                    return;
                }

                if (!userBLL.OnRecommendSameLine(userInfo.UserID, toUserID))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("objectExist") + "');", true);
                    return;
                }
            }

            changeInfo.UserID = getLoginID();
            changeInfo.ToUserID = toUserID;
            changeInfo.ToUserType = 0;
            changeInfo.MoneyType = 0;
            changeInfo.Amount = dResult;
            changeInfo.ChangeType = Convert.ToInt32(dropCurrency.SelectedValue);
            changeInfo.ChangeDate = DateTime.Now;
            changeInfo.Change005 = dResult - dResult * getParamAmount("Transfer3") / 100;

            if (changeBLL.Add(changeInfo) > 0)
            {
                try
                {
                    if (changeInfo.ChangeType == 1)//流通币转MDD钻币
                    {
                        #region 流通币转MDD钻币
                        decimal dBonusAccount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                        if (dBonusAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("BonusAccount", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("Emoney", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（流通币减少）
                            lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                            model.UserID = userInfo.UserID;
                            model.Remark = "流通币转MDD钻币";
                            model.RemarkEn = "Currency to MDD drill";
                            model.InAmount = 0;
                            model.OutAmount = changeInfo.Amount;

                            model.BalanceAmount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                            model.JournalDate = DateTime.Now;
                            model.JournalType = 1;
                            model.Journal01 = toUserID;
                            journalBLL.Add(model);

                            //加入流水账表(购物币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "流通币转MDD钻币";
                            journalInfo.RemarkEn = "Currency to MDD drill";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(getLoginID(), "Emoney");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 2;
                            journalInfo.Journal01 = userInfo.UserID;

                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("objectExist") + "');", true);//奖金币转拍币功能未开放
                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 2)//流通币转注册币
                    {
                        #region 流通币转注册币
                        decimal dBonusAccount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                        if (dBonusAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("BonusAccount", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("StockAccount", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（佣金币减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "流通币转注册币";
                            jmodel.RemarkEn = "Currency to Registered currency";
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Amount;

                            jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = 1;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "流通币转注册币";
                            journalInfo.RemarkEn = "Currency to Registered currency";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "StockAccount");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 5;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("objectExist") + "');", true);//奖金币转拍币功能未开放
                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 3)//流通币转购物币
                    {
                        #region 流通币转购物币
                        decimal dBonusAccount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                        if (dBonusAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("BonusAccount", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("ShopAccount", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（佣金币减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "流通币转购物币";
                            jmodel.RemarkEn = "Currency to shopping currency";
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Amount;
                            jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = 1;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "流通币转购物币";
                            journalInfo.RemarkEn = "Currency to shopping currency";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "ShopAccount");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 3;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("objectExist") + "');", true);//奖金币转拍币功能未开放
                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 4)//注册币转购物币
                    {
                        #region 注册币转购物币
                        decimal dStockAccount = userBLL.GetMoney(getLoginID(), "StockAccount");
                        if (dStockAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("StockAccount", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("ShopAccount", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（佣金币减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "注册币转购物币";
                            jmodel.RemarkEn = "Registered currency to shopping currency";
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Amount;
                            jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "StockAccount");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = 5;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "注册币转购物币";
                            journalInfo.RemarkEn = "Registered currency to shopping currency";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "ShopAccount");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 3;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("objectExist") + "');", true);//奖金币转拍币功能未开放
                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 5)//注册币转其他会员
                    {
                        #region 注册币转其他会员
                        decimal dStockAccount = userBLL.GetMoney(getLoginID(), "StockAccount");
                        if (dStockAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("StockAccount", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("StockAccount", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（佣金币减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "注册币转给" + txtUserCode.Text;
                            jmodel.RemarkEn = "Registered currency to " + txtUserCode.Text;
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Amount;
                            jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "StockAccount");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = 5;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "获得" + LoginUser.UserCode + "转来注册币";
                            journalInfo.RemarkEn = "Get " + LoginUser.UserCode + " Transfer Registered currency";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "StockAccount");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 5;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("objectExist") + "');", true);//奖金币转拍币功能未开放
                        }
                        #endregion
                    }
                }
                catch
                {
                    MessageBox.Show(this, GetLanguage("addError"));//添加流水账错误
                }
                MessageBox.ShowAndRedirect(this, GetLanguage("TransferSuccess"), "TransferToEmoney.aspx");//转账成功
            }
            else
            {
                MessageBox.Show(this, GetLanguage("OperationFailed"));//操作失败
            }
        }

        private string GetWhere()
        {
            string strWhere = string.Format(" and c.UserID=" + getLoginID());

            if (dropType.SelectedValue != "0")
            {
                strWhere += " AND c.ChangeType = " + dropType.SelectedValue + "";
            }

            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();
            if (GetLanguage("LoginLable") == "en-us")
            {
                strStartTime = this.txtStartEn.Text.Trim();
                strEndTime = this.txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {
            bind_repeater(changeBLL.GetDataSet(GetWhere()), Repeater1, "ChangeDate desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 根据选择級別获取金額
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dropCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropCurrency.SelectedValue == "5")
            {
                txtUserCode.Enabled = true;
                txtUserCode.Text = string.Empty;
                txtTrueName.Text = string.Empty;
            }
            else
            {
                txtUserCode.Enabled = false;
                txtUserCode.Text = LoginUser.UserCode;
                txtTrueName.Text = LoginUser.TrueName;
            }
        }

        protected void txtMoney_TextChanged(object sender, EventArgs e)
        {
            string strMoney = txtMoney.Text.Trim();
            if (strMoney != "")
            {
                decimal dMoney = decimal.Parse(strMoney);
                decimal dValue = dMoney - dMoney * getParamAmount("Transfer3") / 100;

                txtActualAmount.Value = dValue.ToString();
            }
        }

    }
}