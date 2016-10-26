/*********************************************************************************
*Copyright(c) 	2012 ZXHLRJ.COM
 * �������ڣ�		2012-5-9 16:12:50
 * �� �� ����		ConsumptionRecords.cs
 * CLR �汾:		2.0.50727.3053
 * �� �� �ˣ�		
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

using System.Data;
using Library;
namespace web.user.product
{
    public partial class ConsumptionRecords : PageCore//System.Web.UI.Page
    {
        lgk.BLL.tb_Order orderBLL = new lgk.BLL.tb_Order();
        //SecondPasswordBLL76 spd = new SecondPasswordBLL76();//��������
        protected void Page_Load(object sender, EventArgs e)
        {
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
            string strWhere = "IsSend=2 ";

            strWhere += " and UserID=" + getLoginID();
            string StarTime = this.textStart.Value.Trim();
            string EndTime = this.textEnd.Value.Trim();
            if (textOrderID.Value != "")
            {
                strWhere += " and OrderCode like '%" + textOrderID.Value + "%'";
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
                    state = "δ����";
                    break;
                case "1":
                    state = "�ѷ���";
                    break;
                case "2":
                    state = "���ջ�";
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
