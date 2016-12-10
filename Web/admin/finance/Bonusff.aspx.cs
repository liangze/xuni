using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin.finance
{
    public partial class Bonusff : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MySQL(string.Format(" exec Proc_tb_FaFangOneKindBonus"));
            //  MySQL(string.Format(" exec proc_datebonus"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('奖金结算成功!');", true);
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MySQL(string.Format(" exec proc_fenhong"));
            //  MySQL(string.Format(" exec proc_datebonus"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('分红发放成功!');", true);
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            MySQL(string.Format(" exec proc_lingshou"));
            //  MySQL(string.Format(" exec proc_datebonus"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('零售积分结算成功!');", true);
        }
    }
}
