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

namespace Web.admin.system
{
    public partial class AccountSet : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 30, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindData();
            }
        }
        /// <summary>
        /// 填充數据
        /// </summary>
        protected void BindData()
        {
            bind_repeater(bankBLL.GetList(""), rpBank, "ID desc", trNull, anpBank);
        }
        /// <summary>
        /// 銀行賬戶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            if (textBankName.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行名称不能为空!');", true);
                return;
            }
            if (textBankAccount.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行账号不能为空!');", true);
                return;
            }
            if (textBankAccountUser.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('开户名不能为空!');", true);
                return;
            }
            BuidModel(1);
        }
        /// <summary>
        /// 插入表1：銀行2：财付通3：支付宝
        /// </summary>
        /// <param name="type"></param>
        protected void BuidModel(int type)
        {
            string BankAccount = "";
            string BankName = "";
            string BankAccountUser = "";
            
            switch (type)
            {
                case 1:
                    BankAccount = textBankAccount.Value;
                    BankName = textBankName.Value;
                    BankAccountUser = textBankAccountUser.Value;

                    break;
            }
            lgk.Model.tb_systemBank bank = new lgk.Model.tb_systemBank();
            bank.BankAccount = BankAccount;
            bank.BankName = BankName;
            bank.BankAccountUser = BankAccountUser;
            bank.BankType = type;
            if (bankBLL.Add(bank) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('设置成功！');window.location.href='AccountSet.aspx';", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('设置失败!');", true);
                return;
            }
                    
        }
        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rpBank_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_systemBank bank = bankBLL.GetModel(ID);
            if (bank == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已删除!');", true);
                return;
            }
            if (e.CommandName == "modify")
            {
                Response.Redirect("BankEdit.aspx?ID=" + ID);
            }
            if (e.CommandName == "del")
            {
                if (bankBLL.Delete(Convert.ToInt32(ID)))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除失败!');", true);
                }
            }
            BindData();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void anpBank_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
