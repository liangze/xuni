using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DataAccess;
using Library;
using System.Text.RegularExpressions;
using System.Data;
using System.Web.UI.HtmlControls;

namespace Web.user.shop
{
    public partial class Retail2 : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dd =getStringRequest("oid");
            lgk.Model.tb_goods model = goodsBLL.GetModel("GoodsCode='" + dd + "'");
            goodscode.Text = model.GoodsCode;
            Label1.Text = model.GoodsName;
            Label2.Text = model.GoodsName_en;
            Label3.Text = model.Pic5;
            Label4.Text = model.Price.ToString();
            Label5.Text = model.Goods006.ToString();
            Label6.Text = model.Goods002.ToString();
            Label7.Text = model.Remarks;
      
        }
    }
}