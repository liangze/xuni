using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Library;

namespace Web.user.shop
{
    public partial class Foot : System.Web.UI.UserControl
    {
        AllCore ac = new AllCore();
        public DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
           // dt = new lgk.BLL.tb_Link().GetList(5," Link001=1 ","Status desc").Tables[0];
          //  GetLanguage();
        }

        public void GetLanguage()
        {
            //if (ac != null)
            //{
            //    Label1.Text = ac.GetLanguage("copyright");
            //}
        }
    }
}