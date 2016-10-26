using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class RegSuccess2 : AllCore//System.Web.UI.Page
    {
        protected string usercode = "";
        protected string levelname = "";
        protected string RegMoney = "";
        protected string diskaamount = "";
        protected string diskbamount = "";
        protected string gushu = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        private void bind()
        {
            if (Request.QueryString["UserCode"] != null)
            {
                lgk.Model.tb_user model = userBLL.GetModel(GetUserID(getStringRequest("UserCode")));
                usercode = model.UserCode;
                levelname = levelBLL.GetLevelName(model.LevelID);
                RegMoney = model.RegMoney.ToString();
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}