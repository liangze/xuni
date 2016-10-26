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
    public partial class BankSet : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 31, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                BindData();
            }
        }
        /// <summary>
        /// 填充数据
        /// </summary>
        protected void BindData()
        {
            lgk.Model.tb_bankName bank = banknameBLL.GetModel(banknameBLL.GetMaxId());
            if (bank != null)
            {
                txtBank.Text = bank.BankName;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            lgk.Model.tb_bankName bank = banknameBLL.GetModel(banknameBLL.GetMaxId());
            if (bank != null)
            {
                bank.BankName = txtBank.Text;
                if (banknameBLL.Update(bank))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('保存成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('保存失败!');", true);
                }
            }
            else
            {
                bank = new lgk.Model.tb_bankName();
                bank.BankName = txtBank.Text;
                if (banknameBLL.Add(bank) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('保存成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('保存失败!');", true);
                }
            }
            BindData();
        }
    }
}
