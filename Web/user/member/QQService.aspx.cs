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

namespace Web.user.member
{
    public partial class QQService : AllCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_repeater(qqBLL.GetList("QQType = 0"), Repeater1, "id desc", tr1);
                bind_repeater(qqBLL.GetList("QQType = 1"), Repeater2, "id desc", tr2);
            }
        }
    }
}
