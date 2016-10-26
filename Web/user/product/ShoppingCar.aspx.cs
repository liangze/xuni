using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using BLL;
using System.Data;
using Library;
namespace web.user.product
{
    public partial class ShoppingCar : PageCore
    {
        //JournalBLL journalBLL = new JournalBLL();
        lgk.BLL.tb_Order orderBLL = new lgk.BLL.tb_Order();
        lgk.BLL.tb_OrderDetail orderDetailBLL = new lgk.BLL.tb_OrderDetail();
        lgk.BLL.tb_produce produceBLL = new lgk.BLL.tb_produce();
        lgk.BLL.tb_flag fg = new lgk.BLL.tb_flag();
        //ThirdPasswordBLL76 tpd = new ThirdPasswordBLL76(); //三级密码

        protected void Page_Load(object sender, EventArgs e)
        {
            //tpd.jumpUrl(this, 1);//跳转三级密码
            if (!IsPostBack)
            {
                bind();
                bindMoney(0, 0);
                BindUserMoney();
            }

        }
        protected void BindUserMoney()
        {
            txtMoney.Value = LoginUser.Emoney.ToString();
        }
        protected void bind()
        {
            DataTable dt = Session["buycar"] as DataTable;
            if (dt != null)
            {
                DataView dv = dt.DefaultView;
                AspNetPager1.RecordCount = dv.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dv;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;
                Repeater1.DataSource = pds;
                if (dv.Count == 0)
                {
                    this.divno.Visible = true;
                }
                else
                {
                    this.divno.Visible = false;
                }
                Repeater1.DataBind();
            }
            else
            {
                this.divno.Visible = true;
                Repeater1.DataSource = null;
                Repeater1.DataBind();
            }
        }
 
        protected void bindMoney(int id,int count)
        {
            decimal money = 0;
            decimal totalCount = 0;
            DataTable car = (DataTable)Session["buycar"];
            if (car == null)
            {
                txtTotalMoney.Value = "0";
                txtCount.Value = "0";
                return;
            }
            for (int i = 0; i < car.Rows.Count; i++)
            {

                if (id.ToString() == car.Rows[i]["ProcudeID"].ToString())
                {
                    int num = Convert.ToInt32(car.Rows[i]["count"]);
                    car.Rows[i]["count"] = count;
                    car.Rows[i]["totalMoney"] = Convert.ToDecimal(car.Rows[i]["MemberPrice"]) * count;
                   
                }
                money += Convert.ToDecimal(car.Rows[i]["totalMoney"]);
                totalCount += Convert.ToInt32(car.Rows[i]["count"]);
            }
            txtTotalMoney.Value = money.ToString();
            txtCount.Value = totalCount.ToString();
            Session["buycar"] = car;
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            bool b = true;
            lgk.Model.tb_user user = LoginUser;
            if (user.Emoney < Convert.ToDecimal(txtTotalMoney.Value))
            {
                MessageBox.Show(this, "E币余额不足请先充值");
                return;
            }
             DataTable dt = Session["buycar"] as DataTable;
             if (dt == null)
             {
                 MessageBox.Show(this, "购物车中无商品");
                 return;
             }
            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                count += Convert.ToInt32(dt.Rows[i]["count"]);
            }
            if (count == 0)
            {
                MessageBox.Show(this, "购物车中无商品");
                return;
            }
            lgk.Model.tb_Order order = new lgk.Model.tb_Order() 
            {
                UserID = user.UserID,
                UserAddr=user.Address,
                OrderCode=GetOrderID(),
                OrderSum=count,
                OrderTotal=Convert.ToDecimal(txtTotalMoney.Value),
                PVTotal = 0,
                OrderDate=DateTime.Now,
                IsSend=0,
                PayMethod=1,
            };
            long id = orderBLL.Add(order);
            if (id == 0)
            {
                MessageBox.Show(this, "添加订单失败");
                b = false;
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lgk.Model.tb_OrderDetail detail = new lgk.Model.tb_OrderDetail()
                {
                    OrderCode=order.OrderCode,
                    ProcudeID = Convert.ToInt32(dt.Rows[i]["ProcudeID"]),
                    ProcudeName = dt.Rows[i]["procudeName"].ToString(),
                    Price = Convert.ToDecimal(dt.Rows[i]["MemberPrice"]),
                    PV = 0,
                    OrderSum = Convert.ToInt32(dt.Rows[i]["count"]),
                    OrderTotal = Convert.ToDecimal(dt.Rows[i]["totalMoney"]),
                    PVTotal = 0,
                    OrderDate = DateTime.Now
                };
                if (orderDetailBLL.Add(detail) == 0)
                {
                    MessageBox.Show(this, "添加订单失败");
                    b = false;
                    break;
                }
            }

            if (b && UpdateAccount("EMoney", user.UserID, Convert.ToDecimal(txtTotalMoney.Value), 0) > 0)
            {
                Session["buycar"] = null;
                MessageBox.ShowAndRedirect(this, "添加订单成功", "MyOrder.aspx");
            }
            BindUserMoney();

        }
        /// <summary>
        /// 购物数量改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtCount_TextChanged(object sender, EventArgs e)
        {
            int index = ((RepeaterItem)((TextBox)sender).NamingContainer).ItemIndex;
            TextBox count = (TextBox)Repeater1.Items[index].FindControl("txtCount");//数量
            if (!PageValidate.IsNumber(count.Text))
            {
                MessageBox.Show(this, "请输入整数，最低购买0");
                count.Text = "0";

            }
            if (count.Text == "" || count.Text == null)
            {
                count.Text = "0";
            }
            HiddenField id = (HiddenField)Repeater1.Items[index].FindControl("hidid");//id
            Label MemberPrice = (Label)Repeater1.Items[index].FindControl("lblMemberPrice");//会员价
            Label MarketPrice = (Label)Repeater1.Items[index].FindControl("MarketPrice");//市场价pv
            Label total = (Label)Repeater1.Items[index].FindControl("lblTotal");//总金额
            total.Text = (Convert.ToDecimal(MemberPrice.Text) * Convert.ToInt32(count.Text)).ToString();
            bindMoney(Convert.ToInt32(id.Value), Convert.ToInt32(count.Text));
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            int index = ((RepeaterItem)((ImageButton)sender).NamingContainer).ItemIndex;
            TextBox count = (TextBox)Repeater1.Items[index].FindControl("txtCount");//数量
            HiddenField id = (HiddenField)Repeater1.Items[index].FindControl("hidid");//id
            Label MemberPrice = (Label)Repeater1.Items[index].FindControl("lblMemberPrice");//会员价单价
            Label MarketPrice = (Label)Repeater1.Items[index].FindControl("lblMarketPrice");//市场价
            Label total = (Label)Repeater1.Items[index].FindControl("lblTotal");//总金额
            count.Text = (Convert.ToInt32(count.Text) + 1).ToString();
            total.Text = (Convert.ToDecimal(MemberPrice.Text) * Convert.ToInt32(count.Text)).ToString();
            bindMoney(Convert.ToInt32(id.Value), Convert.ToInt32(count.Text));
        }
        /// <summary>
        /// 减少
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnCut_Click(object sender, ImageClickEventArgs e)
        {
            int index = ((RepeaterItem)((ImageButton)sender).NamingContainer).ItemIndex;
            TextBox count = (TextBox)Repeater1.Items[index].FindControl("txtCount");//数量

            if (Convert.ToInt32(count.Text)>0)
            {
                HiddenField id = (HiddenField)Repeater1.Items[index].FindControl("hidid");//id
                Label MemberPrice = (Label)Repeater1.Items[index].FindControl("lblMemberPrice");//会员价单价
                Label MarketPrice = (Label)Repeater1.Items[index].FindControl("lblMarketPrice");//市场价
                Label total = (Label)Repeater1.Items[index].FindControl("lblTotal");//总金额
                count.Text = (Convert.ToInt32(count.Text) - 1).ToString();
                total.Text = (Convert.ToDecimal(MemberPrice.Text) * Convert.ToInt32(count.Text)).ToString();
                bindMoney(Convert.ToInt32(id.Value), Convert.ToInt32(count.Text)); 
            }
        }
        /// <summary>
        /// 继续购物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("OnlineBuy.aspx");
        }
       /// <summary>
       /// 清空购物车
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["buycar"] = null;
            bind();
            bindMoney(0, 0);
            MessageBox.Show(this, "清空成功");
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                DataTable _dt = Session["buycar"] as DataTable;
                DataRow[] _drs = null;
                if (_dt != null)
                {
                    _drs = _dt.Select("ProcudeID=" + e.CommandArgument.ToString());
                    foreach (DataRow _dr in _drs)
                    {
                        _dt.Rows.Remove(_dr);
                    }
                    _dt.AcceptChanges();
                }
                MessageBox.Show(this, "删除成功");
                bind();
                bindMoney(0, 0);

            }
           
        }

        protected string GetOrderID()
        {
            while (1 == 1)
            {
                string code = DateTime.Now.ToString("yyyyMMdd");
                Random rad = new Random();//实例化随机数产生器rad；
                int codeValue = rad.Next(1000, 10000);//用rad生成大于等于1000，小于等于9999的随机数；
                code += codeValue.ToString();
                if (GetOrderID(code) == 0)
                {
                    return code;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool b = true;
            lgk.Model.tb_user user = LoginUser;
            if (user.Emoney < Convert.ToDecimal(txtTotalMoney.Value))
            {
                MessageBox.Show(this, "E币余额不足请先充值");
                return;
            }
            DataTable dt = Session["buycar"] as DataTable;
            if (dt == null)
            {
                MessageBox.Show(this, "没购买商品，请先购买");
                return;
            }
            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                count += Convert.ToInt32(dt.Rows[i]["count"]);
            }
            if (count == 0)
            {
                MessageBox.Show(this, "没购买商品，请先购买");
                return;
            }
            lgk.Model.tb_Order order = new lgk.Model.tb_Order()
            {
                UserID = user.UserID,
                UserAddr = user.Address,
                OrderCode = GetOrderID(),
                OrderSum = count,
                OrderTotal = Convert.ToDecimal(txtTotalMoney.Value),
                PVTotal = 0,
                OrderDate = DateTime.Now,
                IsSend = 0,
                PayMethod = 1,
            };
            long id = orderBLL.Add(order);
            if (id == 0)
            {
                MessageBox.Show(this, "添加订单失败");
                b = false;
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lgk.Model.tb_OrderDetail detail = new lgk.Model.tb_OrderDetail()
                {
                    OrderCode = order.OrderCode,
                    ProcudeID = Convert.ToInt32(dt.Rows[i]["ProcudeID"]),
                    ProcudeName = dt.Rows[i]["procudeName"].ToString(),
                    Price = Convert.ToDecimal(dt.Rows[i]["MemberPrice"]),
                    PV = 0,
                    OrderSum = Convert.ToInt32(dt.Rows[i]["count"]),
                    OrderTotal = Convert.ToDecimal(dt.Rows[i]["totalMoney"]),
                    PVTotal = 0,
                    OrderDate = DateTime.Now
                };
                if (orderDetailBLL.Add(detail) == 0)
                {
                    MessageBox.Show(this, "添加订单失败");
                    b = false;
                    break;
                }
            }

            if (b && UpdateAccount("EMoney", user.UserID, Convert.ToDecimal(txtTotalMoney.Value), 0) > 0)
            {
                Session["buycar"] = null;
                MessageBox.ShowAndRedirect(this, "添加订单成功", "MyOrder.aspx");
            }
            BindUserMoney();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("OnlineBuy.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["buycar"] = null;
            bind();
            bindMoney(0, 0);
            MessageBox.Show(this, "清空成功");
        }
    }
}