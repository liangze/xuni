using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using lgk.Model;
using System.Data;

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
                Emoney.Value = LoginUser.Emoney.ToString();//奖金币余额
                //txtStockMoney.Value = LoginUser.GLmoney.ToString();//购物币余额

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
                dropCurrency.Items.Add(new ListItem("奖金积分转注册积分", "1"));
                dropCurrency.Items.Add(new ListItem("注册积分转其他会员", "2"));
                dropType.Items.Add(new ListItem("-请选择-", "0"));
                dropType.Items.Add(new ListItem("奖金币", "1"));
                dropType.Items.Add(new ListItem("注册币", "2"));
            }
            else
            {
                dropCurrency.Items.Add(new ListItem("-Please choose-", "0"));
                dropCurrency.Items.Add(new ListItem("Gold coin to award entry ", "1"));
                dropCurrency.Items.Add(new ListItem("Other members of the registered currency", "2"));

                dropType.Items.Add(new ListItem("-Please choose-", "0"));
                dropType.Items.Add(new ListItem("EMoney", "1"));
                dropType.Items.Add(new ListItem("BonusMoney", "2"));
            }
        }

        private bool CheckOpen(string value)
        {
            switch (value)
            {
                case "1":
                    var iOpen1 = getParamInt("Transfer4");
                    if (iOpen1 != 1)//金币转其他会员是否开启
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "2":
                    var iOpen2 = getParamAmount("Transfer5");
                    if (iOpen2 != 1)//奖金币转其他会员是否开启
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
            string strMoney = txtMoney.Text.Trim();
            int aa = int.Parse(strMoney) % 100;
            if (aa != 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入100的倍数金额');", true);//奖金币转拍币功能未开放
                return;
            }

            decimal dResult = 0;
            if (decimal.TryParse(txtMoney.Text.Trim(), out dResult))
            {
                decimal dTrans = getParamAmount("zhuanzhang_4");//转账最低金额
                decimal d = getParamAmount("zhuanzhang_5");//转账倍数基数
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
                if (iTypeID == 1 && dResult > userInfo.BonusAccount)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NotCurrent") + "');", true);
                    return;
                }
                else if (iTypeID == 2 && dResult > userInfo.Emoney)
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
            lgk.BLL.tb_user u = new lgk.BLL.tb_user();
            string sql = "select *  from  tb_user where RecommendPath like '%"+ userInfo .UserID+ "%' and userid='"+ toUser.UserID + "';select *  from  tb_user where RecommendPath like '%" + toUser.UserID + "%' and userid='" + userInfo.UserID + "' ";

            DataSet ds = u.getData_Chaxun(sql, "");
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            if (dt.Rows.Count==0 && dt1.Rows.Count==0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('没有代数关系无法转账');", true);
                return;
            }


            changeInfo.UserID = getLoginID();
            changeInfo.ToUserID = toUserID;
            changeInfo.ToUserType = 0;
            changeInfo.MoneyType = 0;
            changeInfo.Amount = dResult;
            changeInfo.ChangeType = Convert.ToInt32(dropCurrency.SelectedValue);
            changeInfo.ChangeDate = DateTime.Now;
            if (dropCurrency.SelectedValue=="1")
            {
                changeInfo.Change005 = dResult * getParamAmount("zhuanzhang") - dResult * getParamInt("zhuanzhang_3") / 100*getParamAmount("zhuanzhang");
            }
            if (dropCurrency.SelectedValue == "2")
            {
                changeInfo.Change005 = dResult* getParamAmount("zhuanzhang_1");
            }

            try
            {
                if (changeInfo.ChangeType == 1)//奖金积分转注册积分
                {
                    decimal dBonusAccount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                    if (dBonusAccount >= changeInfo.Amount)
                    {
                        #region 奖金积分转注册积分
                        if (changeBLL.Add(changeInfo) > 0)
                        {
                            UpdateAccount("BonusAccount", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("Emoney", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（金币减少）
                            lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                            model.UserID = userInfo.UserID;
                            model.Remark = "奖金积分转注册积分";
                            model.RemarkEn = "Currency to Registration integral";
                            model.InAmount = 0;
                            model.OutAmount = changeInfo.Amount;

                            model.BalanceAmount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                            model.JournalDate = DateTime.Now;
                            model.JournalType = 2;
                            model.Journal01 = toUserID;
                            journalBLL.Add(model);

                            //加入流水账表(金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "奖金积分转注册积分";
                            journalInfo.RemarkEn = "Currency to Registration integral";
                            journalInfo.InAmount = changeInfo.Change005 ;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(getLoginID(), "Emoney");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 1;
                            journalInfo.Journal02 = 1;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                            MessageBox.ShowAndRedirect(this, GetLanguage("TransferSuccess"), "TransferToEmoney.aspx");//转账成功
                        }
                        else
                        {
                            MessageBox.Show(this, GetLanguage("OperationFailed"));//操作失败
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("E-moneyDollars") + "');", true);//金币余额不足
                    }
                    #endregion
                }
                else if (changeInfo.ChangeType == 2)//注册积分
                {
                    #region 注册积分
                    decimal Emoney = userBLL.GetMoney(getLoginID(), "Emoney");
                    if (Emoney >= changeInfo.Amount)
                    {
                        if (changeBLL.Add(changeInfo) > 0)
                        {
                            UpdateAccount("Emoney", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("Emoney", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（奖金币减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "注册币转其他会员";
                            jmodel.RemarkEn = "Other members of the registered currency";
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Amount;

                            jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "Emoney");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = 1;
                            jmodel.Journal02 = 2;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "收到" + userInfo.UserCode + "转来的注册币";
                            journalInfo.RemarkEn = "roger " + userInfo.UserCode + " Registered currency transferred";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "Emoney");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 1;
                            journalInfo.Journal02 = 2;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                            MessageBox.ShowAndRedirect(this, GetLanguage("TransferSuccess"), "TransferToEmoney.aspx");//转账成功
                        }
                        else
                        {
                            MessageBox.Show(this, GetLanguage("OperationFailed"));//操作失败

                        }
                        #endregion
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("balanceDollars") + "');", true);//奖金币转拍币功能未开放
                    }
                }
            }
            catch
            {
                MessageBox.Show(this, GetLanguage("addError"));//添加流水账错误
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

            if (dropCurrency.SelectedValue == "1")
            {
                txtUserCode.Enabled = false;
                txtUserCode.Text = LoginUser.UserCode;
                txtTrueName.Text = LoginUser.TrueName;
            }
            if (dropCurrency.SelectedValue == "2")
            {
                txtUserCode.Enabled = true;
                txtUserCode.Text = string.Empty;
                txtTrueName.Text = string.Empty;
            }


        }

        protected void txtMoney_TextChanged(object sender, EventArgs e)
        {
            string strMoney = txtMoney.Text.Trim();

            if (strMoney != "")
            {
                btnSubmit.Enabled = false;
                int aa = int.Parse(strMoney) % 100;
                if (aa != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入100的倍数金额');", true);//奖金币转拍币功能未开放
                    return;
                }

                decimal dMoney = decimal.Parse(strMoney);
                decimal dValue = dMoney* getParamAmount("zhuanzhang_1");
                txtActualAmount.Value = dValue.ToString();
                if (dropCurrency.SelectedValue=="1")
                {
                    dValue = dMoney*getParamAmount("zhuanzhang") - dMoney* getParamInt("zhuanzhang_3") /100* getParamAmount("zhuanzhang");
                    txtActualAmount.Value = dValue.ToString();
                }
                return;

            }

        }

    }
}