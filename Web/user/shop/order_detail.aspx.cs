/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-12-25 10:12:09 
 * 文 件 名：		order_detail.cs 
 * CLR 版本: 		2.0.50727.3643 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.shop
{
    public partial class order_detail : AllCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["OrderCode"] != null && Request.QueryString["OrderCode"] != "")
                {
                    ShowInfo(Request.QueryString["OrderCode"]);
                }

                btnBack.Text = GetLanguage("Return");//返回
            }
        }

        protected void ShowInfo(string order)
        {
            lgk.Model.tb_Order orderInfo = orderBLL.GetModel(" OrderCode='" + order + "'");
            lgk.Model.tb_user user = userBLL.GetModel(" UserID=" + orderInfo.UserID);

            txtOrderCode.Value = order == null ? "" : order;//订单号
            txtUserCode.Value = user.UserCode == null ? "" : user.UserCode;//会员编号
            txtTrueName.Value = user.TrueName == null ? "" : user.TrueName;//会员姓名
            txtAddress.Value = orderInfo.UserAddr == null ? "" : orderInfo.UserAddr;//收货地址
            txtTotalAmount.Value = orderInfo.OrderTotal.ToString() == null ? "" : orderInfo.OrderTotal.ToString();//总额
            txtExpress.Value = orderInfo.Order3 == null ? "" : orderInfo.Order3;//快递公司
            txtExpressOrder.Value = orderInfo.Order4 == null ? "" : orderInfo.Order4;//快递单号

            bind_repeater(GetDetail(order), Repeater1, "OrderDate desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                ShowInfo(Request.QueryString["id"]);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("order.aspx");
        }
    }
}
