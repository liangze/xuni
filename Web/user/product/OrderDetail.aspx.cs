/*********************************************************************************
*Copyright(c) 	2012 ZXHLRJ.COM
 * �������ڣ�		2012-4-20 15:10:22
 * �� �� ����		OrderDetail.cs
 * CLR �汾:		2.0.50727.3053
 * �� �� �ˣ�		����
 * �ļ��汾��		1.0.0.0
 * �� �� �ˣ� 
 * �޸����ڣ� 
 * ��ע������ 
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using BLL;
using System.Data;
namespace web.user.product
{
    public partial class OrderDetail : PageCore
    {
        lgk.BLL.tb_OrderDetail orderBLL = new lgk.BLL.tb_OrderDetail();
        lgk.BLL.tb_flag fg = new lgk.BLL.tb_flag();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    Bind(Request.QueryString["id"]);
                }
            }
        }

        protected void Bind(string order)
        {
            bind_repeater(GetDetail(order), Repeater1, "OrderDate desc", null, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                Bind(Request.QueryString["id"]);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyOrder.aspx");
        }
    }
}
