using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Library;
using System.Drawing;
using lgk.BLL;
using System.Data;
using System.Text;
namespace Web.user.shop
{
    public partial class tuangou : System.Web.UI.Page
    {
        AllCore ac = new AllCore();

        tb_goods_cxth _goodBLL = new tb_goods_cxth();

        private int thtype = 0 ; //特惠类型

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private string GetWhere()
        {
            string strWh = " and 1=1";
            if (Request.Cookies["region_name"] != null && Request.Cookies["region_name"].ToString() != "")
            {
               // strWh = string.Format(" and City like '%{0}%' ", Server.UrlDecode(Request.Cookies["region_name"].Value));
                if (Server.UrlDecode(Request.Cookies["region_name"].Value) == "")
                {
                    strWh = " and 1=1";
                }
                else
                {
                    strWh = string.Format(" and City like '%{0}%' ", Server.UrlDecode(Request.Cookies["region_name"].Value));
                }

            }
            return strWh;

        }

        private void BindData()
        {
            ac.bind_repeater(_goodBLL.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 AND IsLucky=0" + GetWhere(), "[Goods007]"), rptProduct, "Goods007 desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}