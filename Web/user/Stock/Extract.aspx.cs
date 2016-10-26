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
    public partial class Extract : PageCore
    {
        protected string YuAmount = "0.00";//奖金余额
        protected string total = "0.00";//已提现
        protected string hkMoney = "0.00";//实际金额

        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转3级密码

            if (!IsPostBack)
            {
                BindData();
                ShowData();
                BindBank();
                btnSearch.Text = GetLanguage("Search");//搜索
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        /// <summary>
        /// 填充
        /// </summary>
        protected void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), rpTake, "TakeTime desc", tr1, AspNetPager1);
            txtQuestion.Value = GoldDdlQuest(LoginUser.User009);
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowData()
        {
            decimal dProfit = Convert.ToDecimal(0.00);
            lgk.Model.Stock stockInfo = stockBLL.GetModel("UserID=" + getLoginID() + "");

            if (stockInfo != null)
            {
                dProfit = stockInfo.Number * (getParamAmount("shares5") - stockInfo.Price);
                if (dProfit <= 0)
                    txtMoney.Value = "0.00";
                else
                    txtMoney.Value = dProfit.ToString();
            }

            if (dProfit > getParamAmount("tx_min"))
            {
                string strDate = DateTime.Now.DayOfWeek.ToString();
                if (strDate == "Friday")
                {
                    btnSubmit.Visible = true;
                }
                else
                {
                    btnSubmit.Visible = false;
                    ltReminder.Text = "星期五才能提现！";
                }
            }
            else
            {
                btnSubmit.Visible = false;
                ltReminder.Text = "奖金余额小于200元，不能提现！";
            }

            if (LoginUser.IsOpend == 3)
            {
                btnSubmit.Visible = false;
                ltReminder.Text = "您是空单会员不能提现，请咨询客服再试！";
            }
            else
                this.txtBalance.Value = GetTotalTake(getLoginID(), 1).ToString("0.00");//已提现金额
        }

        /// <summary>
        /// 绑定银行
        /// </summary>
        private void BindBank()
        {
            string strbandname = new lgk.BLL.tb_bankName().GetModel(1).BankName;
            string[] s = strbandname.Split('|');

            dropBank.Items.Clear();
            strbandname = s[0];
            if (s.Length < 2)
            {
                return;
            }
            if (currentCulture == "en-us")
            {
                strbandname = s[1];
            }
            string[] a = strbandname.Split('，');
            ListItem item_list = new ListItem();
            item_list.Value = "0";
            item_list.Text = GetLanguage("PleaseSselect");//"-请选择-"
            this.dropBank.Items.Add(item_list);
            foreach (string b in a)
            {
                ListItem item_list1 = new ListItem();
                item_list1.Value = b;
                item_list1.Text = b;
                this.dropBank.Items.Add(item_list1);
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = " u.UserID=" + getLoginID() + " and TakeType=1";

            if (GetLanguage("LoginLable") == "zh-cn")
            {
                if (this.txtStar.Text != "")
                {
                    strWhere += " and convert(varchar(10),TakeTime,120) >='" + this.txtStar.Text + "'";
                }
                if (this.txtEnd.Text != "")
                {
                    strWhere += " and convert(varchar(10),TakeTime,120) <='" + this.txtEnd.Text + "'";
                }
            }
            else
            {
                if (this.txtStarEn.Text != "")
                {
                    strWhere += " and convert(varchar(10),TakeTime,120) >='" + this.txtStarEn.Text + "'";
                }
                if (this.txtEndEn.Text != "")
                {
                    strWhere += " and convert(varchar(10),TakeTime,120) <='" + this.txtEndEn.Text + "'";
                }
            }
            return strWhere;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            decimal resultNum = 0;
            decimal tx_min = getParamAmount("tx_min");//最低提现额
            decimal tx_bs = getParamAmount("tx_bs");//倍数基数
            decimal tx_dh = getParamAmount("tx_dh");//兑换比例 1元多少人民币

            lgk.Model.Stock stockInfo = new lgk.Model.Stock();
            stockInfo = stockBLL.GetModel("UserID=" + getLoginID() + "");
            decimal dProfit = stockInfo.Number * (getParamAmount("shares5") - stockInfo.Price);
            #region 数据验证

            #region 提现金额验证
            if (txtTake.Text.Trim() == "")
            {
                MessageBox.MyShow(this, GetLanguage("WithdrawalIsnull"));//提现金额不能为空
                return;
            }

            if (decimal.TryParse(txtTake.Text.Trim(), out resultNum))
            {
                if (resultNum < tx_min)
                {
                    MessageBox.MyShow(this, GetLanguage("AmountThan") + tx_min + GetLanguage("TheInteger"));//提现金额必须是大于等于XX的整数!
                    return;
                }
                if (resultNum % tx_bs != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("amountMust") + tx_bs + GetLanguage("Multiples") + "');", true);//提现金额必须是" + tx_bs + "的倍数!
                    return;
                }
            }
            else
            {
                MessageBox.MyShow(this, GetLanguage("AmountErrors"));//金额格式输入错误
                return;
            }
            if (Convert.ToDecimal(txtTake.Text.Trim()) < tx_min)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AmountThan") + tx_min + "!');", true);//提现金额必须是大于等于XX
                return;
            }
            if (Convert.ToDecimal(txtTake.Text) > dProfit)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AmountBalance") + "');", true);//提现金额不能大于可提现奖金币余额
                return;
            }
            if (LoginUser.User010 != txtAnswer.Text.Trim())
            {
                MessageBox.Show(this, GetLanguage("answerErrors"));//密保答案错误
                return;
            }
            #endregion

            #region 提现选项
            if (radOurselfOne.Checked)
            {
                if (this.dropBank.SelectedValue == "0")
                {
                    MessageBox.Show(this, "请选择开户银行！");
                    return;
                }
                if (txtBankBranch.Text == "")
                {
                    MessageBox.Show(this, "银行支行不能为空！");
                    return;
                }
                if (txtBankAccount.Text == "")
                {
                    MessageBox.Show(this, "银行账户不能为空！");
                    return;
                }
                if (txtBankAccountUser.Text == "")
                {
                    MessageBox.Show(this, "开户姓名不能为空！");
                    return;
                }
                else if (txtBankAccountUser.Text != LoginUser.BankAccountUser)
                {
                    MessageBox.Show(this, "开户姓名和注册信息不一致！");
                    return;
                }
            }
            #endregion

            #endregion

            #region 提现申请

            lgk.Model.tb_takeMoney takeMoneyInfo = new lgk.Model.tb_takeMoney();
            takeMoneyInfo.TakeTime = DateTime.Now;
            takeMoneyInfo.TakeMoney = Convert.ToDecimal(txtTake.Text);//提现金额
            takeMoneyInfo.TakePoundage = Convert.ToDecimal(txtTake.Text.Trim()) * getParamAmount("tx_rete") / 100;//提现手续费
            takeMoneyInfo.RealityMoney = Convert.ToDecimal(txtTake.Text.Trim()) - takeMoneyInfo.TakePoundage;//实际到账金额
            takeMoneyInfo.Flag = 0;
            takeMoneyInfo.UserID = getLoginID();
            takeMoneyInfo.BonusBalance = dProfit - takeMoneyInfo.TakeMoney;//余额
            if (radOurselfOne.Checked)
            {
                takeMoneyInfo.BankName = this.dropBank.SelectedValue;//"开户银行";
                takeMoneyInfo.Take003 = txtBankBranch.Text;
                takeMoneyInfo.BankAccount = txtBankAccount.Text.Trim();
                takeMoneyInfo.BankAccountUser = txtBankAccountUser.Text.Trim();
            }
            else if (radOurselfTwo.Checked)
            {
                takeMoneyInfo.BankName = LoginUser.BankName;
                takeMoneyInfo.Take003 = LoginUser.BankBranch;
                takeMoneyInfo.BankAccount = LoginUser.BankAccount;
                takeMoneyInfo.BankAccountUser = LoginUser.BankAccountUser;
            }

            takeMoneyInfo.TakeType = 1;
            #endregion

            #region 加入流水账表
            lgk.Model.tb_journal model = new lgk.Model.tb_journal();
            model.UserID = stockInfo.UserID;
            model.Remark = "会员提现";
            model.RemarkEn = "Cash withdrawal";
            model.InAmount = 0;
            model.OutAmount = takeMoneyInfo.TakeMoney;
            model.BalanceAmount = takeMoneyInfo.BonusBalance;
            model.JournalDate = DateTime.Now;
            model.JournalType = 1;
            model.Journal01 = stockInfo.UserID;
            #endregion

            int iTake = takeBLL.Add(takeMoneyInfo);
            long lJour = journalBLL.Add(model);
            bool bFalg = stockBLL.UpdateStockNumber(stockInfo.StockID, Convert.ToDecimal(takeMoneyInfo.TakeMoney), getParamAmount("shares5"), 0);

            if (iTake > 0 && lJour > 0 && bFalg)
            {
                string ss = (GetLanguage("MessageTakeMoney").Replace("{username}", LoginUser.UserCode)).Replace("{time}", Convert.ToDateTime(model.JournalDate).ToString("yyyy年MM月dd日HH时mm分")).Replace("{timeEn}", Convert.ToDateTime(model.JournalDate).ToString("yyyy/MM/dd HH:mm"));//添加短信内容
                SendMessage((int)LoginUser.UserID, LoginUser.PhoneNum, ss);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("successful") + "');window.location.href='Extract.aspx';", true);//申请提现成功
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');", true);//操作失败
            }
        }

        protected void txtTake_TextChanged(object sender, EventArgs e)
        {
            if (txtTake.Text.Trim() != "")
            {
                decimal value = (Convert.ToDecimal(txtTake.Text) * (1 - getParamAmount("tx_rete") / 100));//转换人民币的倍数getParamAmount("tx_dh")
                txtExtMoney.Value = value.ToString();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void rpTake_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "change")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                lgk.Model.tb_takeMoney take = takeBLL.GetModel(id);
                if (take == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordDeleted") + "');", true);//该记录已删除，无法再进行此操作
                    return;
                }
                if (take.Flag != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordApproved") + "');", true);//该记录已审核，无法再进行此操作
                    return;
                }
                lgk.Model.Stock stockInfo = stockBLL.GetModel("UserID=" + take.UserID);
                decimal dProfit = stockInfo.Number * (getParamAmount("shares5") - stockInfo.Price);
                //加入流水账表
                lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                model.UserID = take.UserID;
                model.Remark = "取消提现";
                model.InAmount = take.TakeMoney;
                model.OutAmount = 0;
                model.BalanceAmount = dProfit + take.TakeMoney;
                model.JournalDate = DateTime.Now;
                model.JournalType = 1;
                model.Journal01 = take.UserID;
                bool bFalg = stockBLL.UpdateStockNumber(stockInfo.StockID, Convert.ToDecimal(take.TakeMoney), getParamAmount("shares5"), 1);

                if (journalBLL.Add(model) > 0 && bFalg && takeBLL.Delete(id))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("CancellationSuccess") + "');window.location.href='TakeMoney.aspx';", true);//取消成功
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("FailedToCancel") + "');", true);//取消失败
                }
            }
        }

    }
}