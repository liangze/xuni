﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Library;

namespace Web.admin.product
{
    public partial class OrderAuction : AdminPageBase//System.Web.UI.Page
    {
        lgk.BLL.tb_Order ob = new lgk.BLL.tb_Order();
        lgk.BLL.tb_user ub = new lgk.BLL.tb_user();
        lgk.BLL.tb_OrderDetail obd = new lgk.BLL.tb_OrderDetail();
        lgk.BLL.tb_produce pb = new lgk.BLL.tb_produce();
        lgk.BLL.tb_flag fg = new lgk.BLL.tb_flag();

        string StarTime;
        string EndTime;
        string strWhere = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string getWhere()
        {
            string id2 = Request.QueryString["id"];
            string UserID2 = Request.QueryString["UserID"];
            string id = Request.QueryString["type"];
            string usercode = this.txtInput.Value.Trim();
            string StarTime = this.txtStar.Text.Trim();
            string EndTime = txtEnd.Text.Trim();
            string strWhere = "TypeID = 5";
            // str += " and u.IsOpend in ( '2','3') "; //已开通的会员 空单会员
            // str += " and IsDel = 0 ";   //未删除的订单
            strWhere += " and IsSend > 0";
            switch (id)
            {
                case "1": strWhere += ""; break;
                case "2": strWhere += "and o.IsSend=0"; break;//未付款
                case "3": strWhere += "and o.IsSend=1"; break;//待发货
                case "4": strWhere += "and o.IsSend=2"; break;//已发货
                case "5": strWhere += "and o.IsSend=3"; break;//已完成
            }
            if (UserID2 != null)
            {
                if (int.Parse(id2) == 1)
                {
                    strWhere += " and u.UserID=" + UserID2 + " ";
                }
                if (int.Parse(id2) == 2)
                {
                    lgk.Model.tb_user modeluser = userBLL.GetModel(int.Parse(UserID2));
                    strWhere += " and u.RecommendPath like '%" + modeluser.RecommendPath + "%'";
                }

            }
            if (!string.IsNullOrEmpty(usercode))
            {
                strWhere += " and u.UserCode='" + usercode + "' ";
            }

            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OrderDate,120)  >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format("  and Convert(nvarchar(10),OrderDate,120)  <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format("  and Convert(nvarchar(10),OrderDate,120)  between '" + StarTime + "' and '" + EndTime + "'");
            }
            return strWhere;
        }

        private void bind()
        {
            bind_repeater(GetAllOrderList(getWhere()), Repeater1, "IsSend asc,OrderDate desc", tr1, AspNetPager1);
        }
        /// <summary>
        /// 搜索提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            lgk.Model.tb_Order order = ob.GetModelByCode(e.CommandArgument.ToString());

            if (order == null)
            {
                MessageBox.ShowAndRedirect(this, "已经删除过的记录!", "OrderAuction.aspx");
                return;
            }
            if (order.IsDel == 2)
            {
                MessageBox.ShowAndRedirect(this, "已经删除过的记录!", "OrderAuction.aspx");
                return;
            }

            TextBox txtGongsi = (TextBox)e.Item.FindControl("txtGongsi");//快递公司
            TextBox txtDanhao = (TextBox)e.Item.FindControl("txtDanhao");//快递单号

            if (e.CommandName.Equals("Send")) //确认发货 
            {
                if (order.IsSend == 0)
                {
                    MessageBox.ShowAndRedirect(this, "未付款的记录!", "OrderAuction.aspx");
                    return;
                }
                if (order.IsSend > 1)
                {
                    MessageBox.ShowAndRedirect(this, "已发货的记录!", "OrderAuction.aspx");
                    return;
                }

                #region 1判断当前用户输入的快递名称及单号 2保存快递信息
                if (string.IsNullOrEmpty(txtGongsi.Text))
                {
                    MessageBox.Show(this, "发货失败，原因：快递公司不能为空");
                    return;
                }
                if (string.IsNullOrEmpty(txtDanhao.Text))
                {
                    MessageBox.Show(this, "发货失败，原因：快递单号不能为空");
                    return;
                }
                order.Order3 = txtGongsi.Text;
                order.Order4 = txtDanhao.Text;

                if (!ob.Update(order))
                {
                    MessageBox.Show(this, "发货失败，原因：保存快递信息失败");
                    return;
                }
                #endregion

                if (string.IsNullOrEmpty(order.Order3) || string.IsNullOrEmpty(order.Order4))
                {
                    MessageBox.ShowAndRedirect(this, "请先填写快递公司和快递单号!", "OrderAuction.aspx");
                    return;
                }

                if (order.OrderType == 3)
                {
                    ob.Update(order);
                    MessageBox.ShowAndRedirect(this, "发货已成功！\r\n 由于还需要支付宝平台返回验证消息 \r\n 请稍后刷新查看发货状态", "OrderAuction.aspx");
                }
                else
                {
                    order.IsSend = 2;//已发货
                    order.SendDate = DateTime.Now; //发货时间  结算奖金以发货时间为准
                    if (ob.Update(order))
                    {
                        MessageBox.ShowAndRedirect(this, "发货已成功!", "OrderAuction.aspx");
                    }
                }
            }
            if (e.CommandName.Equals("Detail"))
            {
                Response.Redirect("OrderDetail.aspx?oid=" + order.OrderCode);
            }

            return;
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                //long iOrderID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "OrderID"));

                ////未付款0，待发货1，待收货为2，已完成3
                //// LinkButton link = (LinkButton)e.Item.FindControl("LinkButton3");//编辑
                //TextBox txtGongsi = (TextBox)e.Item.FindControl("txtGongsi");//公司
                //TextBox txtDanhao = (TextBox)e.Item.FindControl("txtDanhao");//单号
                //Literal Literal1 = (Literal)e.Item.FindControl("Literal1");//公司
                //Literal Literal2 = (Literal)e.Item.FindControl("Literal2");//单号
                //HiddenField hft = (HiddenField)e.Item.FindControl("hft");//状态
                //LinkButton lbtnEnter = (LinkButton)e.Item.FindControl("lbtnEnter");

                //lgk.Model.tb_Order orderInfo = orderBLL.GetModel(iOrderID);

                //lgk.Model.tb_OrderDetail orderDetailInfo = orderDetailBLL.GetModelByOrderCode(orderInfo.OrderCode);

                //lgk.BLL.tb_goods_cxth _goodsBLL = new lgk.BLL.tb_goods_cxth();
                //lgk.Model.tb_goods_cxth model = _goodsBLL.GetModel(orderDetailInfo.ProcudeID);

                //if (model.IsLucky == 0)
                //    lbtnEnter.Visible = false;
                //else
                //    lbtnEnter.Visible = true;

                //if (txtGongsi != null && txtDanhao != null && hft != null)
                //{
                //    Literal1.Text = "";
                //    Literal2.Text = "";
                //    string typen = hft.Value;
                //    if (!"1".Equals(typen))
                //    {
                //        Literal1.Text = txtGongsi.Text;
                //        Literal2.Text = txtDanhao.Text;
                //        txtGongsi.Visible = false;
                //        txtDanhao.Visible = false;
                //        // link.Visible = false;
                //        return;
                //    }
                //}
            }
        }

        protected string GetState(string id, string isDel)
        {
            string state = "";
            switch (id)
            {
                case "0":
                    state = "<span class='red'>付款失败</span>";
                    break;
                case "1":
                    if (isDel == "1")
                        state = "<span class='red'>申请取消</span>";
                    else if (isDel == "2")
                        state = "<span class='red'>已取消</span>";
                    else state = "待发货";
                    break;
                case "2":
                    state = "已发货";
                    break;
                case "3":
                    state = "已完成";
                    break;
                case "4":
                    state = "未收到货";
                    break;
            }
            return state;
        }

        protected void daochu_Click(object sender, EventArgs e)
        {
            DataSet ds = GetAllOrderList(getWhere());
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = "IsSend asc,OrderDate desc";

            if (dv.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('不能导出空表格!');", true);
                return;
            }
            //生成列的中午对应表
            string str = ToOrderExecl(Server.MapPath("../../Upload"), dv.Table);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }
    }
}