/*********************************************************************************
*Copyright(c) 	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-19 16:07:39
 * 文 件 名：		OnlineBuy.cs
 * CLR 版本:		2.0.50727.3053
 * 创 建 人：		黄灵
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
    public partial class OnlineBuy : PageCore//System.Web.UI.Page//
    {
        lgk.BLL.tb_produce produceBLL = new lgk.BLL.tb_produce();
        lgk.BLL.tb_produceType pt = new lgk.BLL.tb_produceType();
        lgk.BLL.tb_flag fg = new lgk.BLL.tb_flag();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindType();
                BindGoods();
                BindEmoney();
                anpGoods.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
            }
        }

        private void bindType()
        {
            IList<lgk.Model.tb_produceType> ddlList = new lgk.BLL.tb_produceType().GetModelList(" ");
            this.DropDownList1.Items.Clear();
            //ListItem li = new ListItem();
            //li.Value = "0";
            //li.Text = "-请选择-";
            //DropDownList1.Items.Add(li);
            foreach (lgk.Model.tb_produceType item in ddlList)
            {
                ListItem items = new ListItem();
                items.Value = item.TypeName;
                items.Text = item.TypeName;
                DropDownList1.Items.Add(items);
            }
        }
        protected void BindEmoney()
        {
            textMoney.Value = LoginUser.Emoney.ToString();
        }
        protected void BindGoods()
        {

            DataTable dt;
            try
            {
                dt = GetShopList(getWhere()).Tables[0];
            }
            catch (Exception)
            {
                dt = GetShopList("1<>1").Tables[0]; ;
            }
            if (dt.Rows.Count > 0)
            {

                DataView dv = dt.DefaultView;
                dv.Sort = "ProcudeID desc";
                anpGoods.RecordCount = dv.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dv;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = anpGoods.CurrentPageIndex - 1;
                pds.PageSize = anpGoods.PageSize;
                dlGoods.DataSource = pds;
                dlGoods.DataBind();
                trGoodsNull.Visible = false;
            }
            else
            {
                dt.Rows.Clear();
                dlGoods.DataSource = dt;
                dlGoods.DataBind();
                trGoodsNull.Visible = true;
            }
        }

        private string getWhere()
        {
            string str = "1=1 ";
            if (textCode.Value != "")
            {
                str += " and p.ProcudeCode like '%" + textCode.Value + "%'";
            }
            if (textName.Value != "")
            {
                str += " and p.procudeName like '%" + textName.Value + "%'";
            }
            if (textMinPrice.Value != "")
            {
                str += " and p.MemberPrice>=" + textMinPrice.Value;
            }
            if (textMaxPrice.Value != "")
            {
                str += "and p.MemberPrice<=" + textMinPrice.Value;
            }
            str += " and LinkURL like '%" + DropDownList1.SelectedValue + "%'";
            return str;
        }
        /// <summary>
        /// 放入购物车
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void dlGoods_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();//商品id
            bool b = true;//购物车是否有商品存在
            if (e.CommandName == "buy")
            {
                Image img = (Image)e.Item.FindControl("Image1");
                TextBox name = (TextBox)e.Item.FindControl("txtGoodsName");
                TextBox MarketPrice = (TextBox)e.Item.FindControl("txtMarketPrice");
                TextBox MemberPrice = (TextBox)e.Item.FindControl("txtMemberPrice");
                TextBox count = (TextBox)e.Item.FindControl("txtCount");
                DataTable car = (DataTable)Session["buycar"];
                if (count.Text == "" || count.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入购买数量在购买!');", true);
                    return;
                }
                if (!PageValidate.IsNumber(count.Text))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('只能输入整数!');", true);
                    return;
                }
                if (car == null)
                {
                    car = new DataTable("buycar");

                    car.Columns.Add("ProcudeID", typeof(int));//商品id
                    car.Columns.Add("img", typeof(string));//图片名称
                    car.Columns.Add("procudeName", typeof(string));//商品名称
                    car.Columns.Add("MarketPrice", typeof(decimal));//市场价格
                    car.Columns.Add("MemberPrice", typeof(decimal));//会员价格
                    car.Columns.Add("count", typeof(int));//购买数量
                    car.Columns.Add("totalMoney", typeof(decimal));//购买总金额
                    DataRow dr = car.NewRow();
                    dr[0] = Convert.ToInt32(id);
                    dr[1] = img.ImageUrl;
                    dr[2] = name.Text;
                    dr[3] = Convert.ToDecimal(MarketPrice.Text);
                    dr[4] = Convert.ToDecimal(MemberPrice.Text);
                    dr[5] = Convert.ToInt32(count.Text);
                    dr[6] = Convert.ToDecimal(MemberPrice.Text) * Convert.ToInt32(count.Text);

                    car.Rows.Add(dr);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('已加入购物车!');", true);
                }
                else
                {
                    for (int i = 0; i < car.Rows.Count; i++)
                    {
                        if (id == car.Rows[i]["ProcudeID"].ToString())
                        {
                            b = false;
                            int num = Convert.ToInt32(car.Rows[i]["count"]);
                            car.Rows[i]["count"] = num + Convert.ToInt32(count.Text);
                            car.Rows[i]["totalMoney"] = Convert.ToDecimal(car.Rows[i]["totalMoney"]) + Convert.ToDecimal(car.Rows[i]["MemberPrice"]) * Convert.ToInt32(count.Text);
                            break;
                        }
                    }
                    if (b)
                    {
                        DataRow dr = car.NewRow();
                        dr[0] = Convert.ToInt32(id);
                        dr[1] = img.ImageUrl;
                        dr[2] = name.Text;
                        dr[3] = Convert.ToDecimal(MarketPrice.Text);
                        dr[4] = Convert.ToDecimal(MemberPrice.Text);
                        dr[5] = Convert.ToInt32(count.Text);
                        dr[6] = Convert.ToDecimal(MemberPrice.Text) * Convert.ToInt32(count.Text);

                        car.Rows.Add(dr);
                    }
                }
                Session["buycar"] = car;
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('已加入购物车!');", true);
            }
            
            
        }

        protected void anpGoods_PageChanged(object sender, EventArgs e)
        {
            BindGoods();
        }

        protected void txtCount_TextChanged(object sender, EventArgs e)
        {
            int id = ((DataListItem)((TextBox)sender).NamingContainer).ItemIndex;
            TextBox price = (TextBox)dlGoods.Items[id].FindControl("txtMemberPrice");//单价
            TextBox count = (TextBox)dlGoods.Items[id].FindControl("txtCount");//数量
            if (!PageValidate.IsNumber(count.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('只能输入最小是0的整数!');", true);
                count.Text = "0";
               
            }
            if (count.Text == "")
            {
                count.Text = "0";
            }
            TextBox totalMoney = (TextBox)dlGoods.Items[id].FindControl("txtTotalMoneny");//总金额
            TextBox totalPV = (TextBox)dlGoods.Items[id].FindControl("txtTotalPV");//总PV
            totalMoney.Text = (Convert.ToInt32(count.Text) * Convert.ToDecimal(price.Text)).ToString();
        }

        protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGoods(); 
        }

       
        protected string filterStr(string str)
        {
            if (str != null && str != "")
            {
                str = System.Text.RegularExpressions.Regex.Replace(str, "<[^>]*?>", "");
            }
            
            return str;
        }
        protected string CutStr(string str, int length)
        {
            if (str != null && str != "")
            {
                if (str.Length > 150)
                {
                    return str.Substring(0, 150) + "...";
                }
            }
            return str;
        }

        protected void btnChuSearch_Click(object sender, EventArgs e)
        {
            BindGoods(); 
        }
    }
}
