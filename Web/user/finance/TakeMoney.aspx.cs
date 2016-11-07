using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;
using System.Collections.Generic;

namespace Web.user.finance
{
    public partial class TakeMoney : PageCore
    {
        //private decimal week = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                ShowData();
                BindData();
                btnSearch.Text = GetLanguage("Search");//搜索
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        /// <summary>
        /// 提现金额
        /// </summary>
        private void ShowData()
        {
            decimal dMin = getParamAmount("ATM2");

            txtBonusAccount.Value = LoginUser.BonusAccount.ToString("0.00");
            var iOpen4 = getParamAmount("ATM1");
            
            if(iOpen4==1)
            {
                if (LoginUser.BonusAccount >= dMin)
                {
                    btnSubmit.Visible = true;
                }
                else
                {
                    btnSubmit.Visible = false;
                }
            }
            else
            {
                btnSubmit.Visible = false;
                txtTake.Visible = false;
            }
           
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = " u.UserID=" + getLoginID() + "";
            string strStart = txtStart.Text.Trim();
            string strEnd = txtEnd.Text.Trim();

            if (strStart != "" && strEnd == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RegTime,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  between '" + strStart + "' and '" + strEnd + "'");
            }
            return strWhere;
        }

        /// <summary>
        /// 填充
        /// </summary>
        protected void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), Repeater1, "TakeTime desc", tr1, AspNetPager1);
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
            #region 数据验证
            //string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            //week = Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"));
            //var open2 = getParamAmount("extract4");
            //if (week != open2)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请在提现日进行此功能操作，谢谢!');", true);
            //    return;
            //}

            #region 提现金额验证
            if (txtTake.Text.Trim() == "")
            {
                MessageBox.MyShow(this, GetLanguage("WithdrawalIsnull"));//提现金额不能为空
                return;
            }
            decimal resultNum = 0;
            decimal tx_min = getParamAmount("ATM2");//最低体现额
            decimal tx_bs = getParamAmount("ATM3");//倍数基数
            if (decimal.TryParse(txtTake.Text.Trim(), out resultNum))
            {
                if (resultNum < tx_min)
                {
                    MessageBox.MyShow(this, GetLanguage("AmountThan") + tx_min);//提现金额必须是大于等于XX的整数!
                    return;
                }
                if (tx_bs != 0 && resultNum % tx_bs != 0)
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

            if (Convert.ToDecimal(resultNum) > LoginUser.BonusAccount)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseExchange") + "');", true);//请到流通币交易大厅交易
                return;
            }

           
            #endregion

            #endregion

            #region 提现申请
            lgk.Model.tb_takeMoney takeMoneyInfo = new lgk.Model.tb_takeMoney();
            takeMoneyInfo.TakeTime = DateTime.Now;
            takeMoneyInfo.TakeMoney = resultNum;
            takeMoneyInfo.TakePoundage = resultNum * getParamAmount("ATM4") / 100;
            takeMoneyInfo.RealityMoney = resultNum - takeMoneyInfo.TakePoundage;
            takeMoneyInfo.Flag = 0;
            takeMoneyInfo.UserID = getLoginID();
            takeMoneyInfo.BonusBalance = LoginUser.BonusAccount - takeMoneyInfo.TakeMoney;

            takeMoneyInfo.BankName = LoginUser.BankName;
            takeMoneyInfo.Take003 = LoginUser.BankBranch;
            takeMoneyInfo.BankAccount = LoginUser.BankAccount;
            takeMoneyInfo.BankAccountUser = LoginUser.BankAccountUser;
            #endregion

            #region 加入流水账表

            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            journalInfo.UserID = takeMoneyInfo.UserID;
            journalInfo.Remark = "会员提现";
            journalInfo.RemarkEn = "Cash withdrawal";
            journalInfo.InAmount = 0;
            journalInfo.OutAmount = takeMoneyInfo.TakeMoney;
            journalInfo.BalanceAmount = takeMoneyInfo.BonusBalance;
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = 2;
            journalInfo.Journal01 = takeMoneyInfo.UserID;

            #endregion

            if (takeBLL.Add(takeMoneyInfo) > 0 && journalBLL.Add(journalInfo) > 0 && UpdateAccount("BonusAccount", getLoginID(), takeMoneyInfo.TakeMoney, 0) > 0)
            {
                //string ss = (GetLanguage("MessageTakeMoney").Replace("{username}", LoginUser.UserCode)).Replace("{time}", Convert.ToDateTime(journalInfo.JournalDate).ToString("yyyy年MM月dd日HH时mm分")).Replace("{timeEn}", Convert.ToDateTime(journalInfo.JournalDate).ToString("yyyy/MM/dd HH:mm"));//添加短信内容
                //SendMessage((int)LoginUser.UserID, LoginUser.PhoneNum, ss);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("successful") + "');window.location.href='TakeMoney.aspx';", true);//申请提现成功
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
                decimal value = (Convert.ToDecimal(txtTake.Text) * (1 - getParamAmount("ATM4") / 100));//手续费getParamAmount("ATM4")

                txtExtMoney.Value = value.ToString();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "change")
            {
                long iID = Convert.ToInt64(e.CommandArgument);
                lgk.Model.tb_takeMoney take = takeBLL.GetModel(iID);
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
                lgk.Model.tb_user user = userBLL.GetModel(Convert.ToInt32(take.UserID));
                //加入流水账表
                lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                model.UserID = take.UserID;
                model.Remark = "取消提现";
                model.InAmount = take.TakeMoney;
                model.OutAmount = 0;
                model.BalanceAmount = user.BonusAccount + take.TakeMoney;
                model.JournalDate = DateTime.Now;
                model.JournalType = 2;
                model.Journal01 = take.UserID;

                if (journalBLL.Add(model) > 0 && UpdateAccount("BonusAccount", take.UserID, take.TakeMoney, 1) > 0 && takeBLL.Delete(iID))
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
