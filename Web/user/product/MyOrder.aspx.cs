/*********************************************************************************
*Copyright(c) 	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-19 16:08:05
 * 文 件 名：		MyOrder.cs
 * CLR 版本:		2.0.50727.3053
 * 创 建 人：		
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述： 
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Library;
namespace web.user.product
{
    public partial class MyOrder : PageCore
    {
        lgk.BLL.tb_Order orderBLL = new lgk.BLL.tb_Order();
        //SecondPasswordBLL76 spd = new SecondPasswordBLL76();//二级密码

        protected void Page_Load(object sender, EventArgs e)
        {
           // spd.jumpUrl(this, 1);//跳转二级密码
            if (!IsPostBack)
            {
                Bind();
            }
        }
        protected void Bind()
        {
            bind_repeater(orderBLL.GetList(getWhere()), Repeater1, "IsSend asc,OrderDate desc", trNull, AspNetPager1);
        }

        private string getWhere()
        {
            string strWhere = "1=1 ";

            strWhere += " and UserID=" + getLoginID();
            string StarTime = this.textStart.Value.Trim();
            string EndTime = this.textEnd.Value.Trim();
            if (textOrderID.Value != "")
            {
                strWhere += " and OrderCode like '%" + textOrderID.Value.Trim() + "%'";
            }
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OrderDate,120)  >= '" + StarTime + "' ");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OrderDate,120)  <= '" + EndTime + "' ");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OrderDate,120)  between '" + StarTime + "' and '" + EndTime + "' ");
            }
            return strWhere;
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName.Equals("show"))
            {
                Response.Redirect("OrderDetail.aspx?id=" + id);
            }
            if (e.CommandName.Equals("take"))
            {
                lgk.Model.tb_Order order = orderBLL.GetModelByCode(id);
                order.IsSend = 2;
                if (orderBLL.Update(order))
                {
                    MessageBox.ShowAndRedirect(this, "确认收货成功", "MyOrder.aspx");
                }
                else
                {
                    MessageBox.Show(this, "确认收货失败");
                    return;
                }
            }
        }

        protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Bind();
        }
        protected string GetState(string id)
        {
            string state = "";
            switch (id)
            { 
                case "0":
                    state = "未发货";
                    break;
                case "1":
                    state = "已发货";
                    break;
                case "2":
                    state = "已收货";
                    break;
            }
            return state;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}
