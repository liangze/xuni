using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.member
{
    public partial class Recast : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转三级密码

            if (!IsPostBack)
            {
                ShowInfo();

              //  btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        private void ShowInfo()
        {
            txtUserCode.Value = LoginUser.UserCode;
            txtTrueName.Value = LoginUser.TrueName;
            txtIdenCode.Value = LoginUser.IdenCode;
            txtPhoneNum.Value = LoginUser.PhoneNum;
            txtBatch.Value = LoginUser.Batch.ToString();
            txtTotalAmount.Value = GetBonusAllTotal(getLoginID(), "Amount").ToString();
            txtCapValue.Value = getParamAmount("Seedpool4").ToString();

            if (LoginUser.IsOut == 1)
            {
               // btnSubmit.Visible = true;
                txtWhetherCast.Value = GetLanguage("YesCast");
            }
            else
            {
             //   btnSubmit.Visible = false;
                txtWhetherCast.Value = GetLanguage("NoCast");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(getLoginID());
            if (userInfo.Batch >= getParamInt("Batch1"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("RecastFull") + "');", true);
                return;
            }
            else if (userInfo.IsOut == 1)
            {
                decimal dRegMoney = getParamAmount("billMoney") * getParamAmount("Level1");
                if (userInfo.BonusAccount >= dRegMoney)
                {
                    userBLL.UpdateBatch(userInfo.UserID, 1);

                    #region 加入流水账表

                    lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                    journalInfo.UserID = userInfo.UserID;
                    journalInfo.Remark = "复投扣费";
                    journalInfo.RemarkEn = "Investment deduction";
                    journalInfo.InAmount = 0;
                    journalInfo.OutAmount = dRegMoney;
                    journalInfo.BalanceAmount = userInfo.BonusAccount - dRegMoney;
                    journalInfo.JournalDate = DateTime.Now;
                    journalInfo.JournalType = 1;
                    journalInfo.Journal01 = userInfo.UserID;

                    journalBLL.Add(journalInfo);

                    UpdateAccount("BonusAccount", userInfo.UserID, dRegMoney, 0);

                    #endregion
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ShortageCash") + "');", true);
                    return;
                }
            }
            else if (userInfo.IsOut == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AccountNotOut") + "');", true);
                return;
            }
        }
    }
}