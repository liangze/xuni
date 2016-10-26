using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.shop
{
    public partial class ChangeUrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetId() > 0)
            {
                if (GetId() == 5)
                    Response.Redirect("xianshiqianggou.aspx?ptype=5");
                else
                    Response.Redirect("shopList.aspx?ptype=" + GetId());
            }
        }

        private int GetId()
        {
            if (Request["type"] != null && Request["type"] != "" && PageValidate.IsInt(Request["type"]) == true)
            {
                return Convert.ToInt32(Request["type"].ToString());
            }
            else
            {
                return 0;
            }
        }

        private int CxTh() //促销特惠跳转
        {
            if (Request["t"] != null && Request["t"] != "" && PageValidate.IsInt(Request["t"]) == true)
            {
                return Convert.ToInt32(Request["t"].ToString());
            }
            else
            {
                return 0;
            }
        }
    }
}