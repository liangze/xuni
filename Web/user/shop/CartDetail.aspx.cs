using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.shop
{
    public partial class CartDetail : PageCore//System.Web.UI.Page
    {
        AllCore ac = new AllCore();
        string cnen = "zh-cn";
        public static int payment = 1;//支付方式：1-积分支付；2-拍币支付
        lgk.Model.tb_user LoginUser1 = null;
        public bool JfPayShow = true;//默认积分支付显示


        protected void Page_Load(object sender, EventArgs e)
        {
            cnen = ac.GetLanguage("LoginLable");

            payment = Convert.ToInt32(Request["payment"]);
            if (payment == 1)
            {
                rdoPv.Checked = true;
                rdoPv.Visible = true;
            }
            ShowPayment();

            int id = getLoginID1();
            LoginUser1 = userBLL.GetModel(long.Parse(id.ToString()));
            if (!IsPostBack)
            {
                bind();
                bindMoney(0, 0);
            }
        }

        /// <summary>
        /// 获取当前登录代理商ID
        /// </summary>
        /// <returns></returns>
        public int getLoginID1()
        {
            if (Request.Cookies["A128076_user"] != null)
            {
                return Convert.ToInt32(Request.Cookies["A128076_user"]["Id"]);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 购物车数据
        /// </summary>
        protected void bind()
        {
            DataTable dt = Session["A128076_" + getLoginID1() + "_ShoppingCar"] as DataTable;
            if (dt != null)
            {
                DataView dv = dt.DefaultView;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dv;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = 0;
                pds.PageSize = 100;
                Repeater1.DataSource = pds;
                Repeater1.DataBind();
            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('购物车中无商品！');window.location.href='channel.aspx';", true);
            //}
        }

        /// <summary>
        /// 购物总金额，商品数量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        protected void bindMoney(int id, int count)
        {
            decimal money = 0;
            decimal jiFen = 0;
            DataTable car = (DataTable)Session["A128076_" + getLoginID1() + "_ShoppingCar"];
            if (car == null)
            {
                lilMoney.Text = "0";
                liJinfen.Text = "0";
                return;
            }
            for (int i = 0; i < car.Rows.Count; i++)
            {

                if (id.ToString() == car.Rows[i]["ProcudeID"].ToString())
                {
                    int num = Convert.ToInt32(car.Rows[i]["count"]);
                    car.Rows[i]["count"] = count;
                    car.Rows[i]["totalPV"] = Convert.ToDecimal(car.Rows[i]["Goods002"]) * count;
                    car.Rows[i]["totalMoney"] = Convert.ToDecimal(car.Rows[i]["Goods006"]) * count;


                }
                money += Convert.ToDecimal(car.Rows[i]["totalMoney"]);
                jiFen += Convert.ToDecimal(car.Rows[i]["totalPV"]);
            }
            lilMoney.Text = money.ToString();
            liJinfen.Text = jiFen.ToString();
            Session["A128076_" + getLoginID1() + "_ShoppingCar"] = car;
        }

        protected void imgbtnCut_Click(object sender, ImageClickEventArgs e)
        {
            int index = ((RepeaterItem)((ImageButton)sender).NamingContainer).ItemIndex;
            TextBox count = (TextBox)Repeater1.Items[index].FindControl("txtCount");//数量

            if (Convert.ToInt32(count.Text) > 0)
            {
                HiddenField id = (HiddenField)Repeater1.Items[index].FindControl("hidid");//id
                if (Convert.ToInt32(count.Text) > 1)
                {
                    count.Text = (Convert.ToInt32(count.Text) - 1).ToString();
                    bindMoney(Convert.ToInt32(id.Value), Convert.ToInt32(count.Text));
                    bind();
                }
            }
        }

        protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            int index = ((RepeaterItem)((ImageButton)sender).NamingContainer).ItemIndex;
            TextBox count = (TextBox)Repeater1.Items[index].FindControl("txtCount");//数量
            HiddenField id = (HiddenField)Repeater1.Items[index].FindControl("hidid");//id
            if (goodsBLL.GetModel(Convert.ToInt32(id.Value)).RealityPrice < Convert.ToInt32(count.Text) + 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("LowStock") + "');", true);//库存不足
                bindMoney(0, 0);
                bind();
            }
            else
            {
                count.Text = (Convert.ToInt32(count.Text) + 1).ToString();
                bindMoney(Convert.ToInt32(id.Value), Convert.ToInt32(count.Text));
                bind();
            }

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
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("minimum") + "');", true);//请输入整数，最低购买0！
                count.Text = "0";

            }
            if (count.Text == "" || count.Text == null)
            {
                count.Text = "0";
            }
            HiddenField id = (HiddenField)Repeater1.Items[index].FindControl("hidid");//id
            if (goodsBLL.GetModel(Convert.ToInt32(id.Value)).RealityPrice < Convert.ToInt32(count.Text) + 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("LowStock") + "');", true);//库存不足
                bindMoney(0, 0);
                bind();
            }
            else
            {
                bindMoney(Convert.ToInt32(id.Value), Convert.ToInt32(count.Text));
                bind();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                DataTable _dt = Session["A128076_" + getLoginID1() + "_ShoppingCar"] as DataTable;
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
                bind();
                bindMoney(0, 0);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("DeletedSuccessfully") + "');", true);//删除成功

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["A128076_" + getLoginID1() + "_ShoppingCar"] = null;
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("EmptySuccess") + "');window.location.href='index.aspx';", true);//清空成功
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "window.location.href='channel.aspx?type=1';", true);
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

        //改变购物车中商品的支付方式（积分换购商品除外）
        private void ChangePayment(DataTable table, int payment)
        {
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["payMent"]) != 1)
                {
                    row["payMent"] = payment;
                }
            }
        }


        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            decimal money = 0;
            decimal jifen = 0;
            DataTable car = (DataTable)Session["A128076_" + getLoginID1() + "_ShoppingCar"];
            if (car == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PaymentError") + "');", true);//还没有选择支付方式
                return;
            }
            if (this.rdoMoney.Checked == false && this.rdoPv.Checked == false && this.rdoZX.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("HavePayment") + "');", true);//还没有选择支付方式
                return;
            }
            if (car == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ShoppingNot") + "');", true);//购物车没有商品
                return;
            }
            if (string.IsNullOrEmpty(LoginUser1.Address))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("addressNot") + "');", true);//您还没有联系地址
                return;
            }
            if (car.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ShoppingNot") + "');", true);//购物车没有商品
                return;
            }

            //如果购物车中混合了正常购买商品和积分兑换商品，则将积分兑换商品提取出来单独自动处理处理
            bool hascharge = HasCharge(car);
            if (hascharge == true)
            {
                HandCharge(car);//自动处理积分换购
            }

            if (this.rdoMoney.Checked == false && this.rdoZX.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("HavePayment") + "');", true);//还没有选择支付方式
                return;
            }

            int rows = car.Rows.Count;
            int count = 0;//正常购买商品数量

            //如果是在线支付，则需要在支付成功后，才将订单记录存入订单表，否则，不存入;(处理都在OrderReturn页面)
            if (this.rdoZX.Checked == true)
            {
                ChangePayment(car, 3);//修改商品的支付方式为：在线支付

                //接着处理正常购买的商品：在线支付方式
                for (int i = 0; i < rows; i++)
                {
                    if (Convert.ToInt32(car.Rows[i]["payMent"]) == 3)
                    {
                        count += Convert.ToInt32(car.Rows[i]["count"]);
                        money += Convert.ToDecimal(car.Rows[i]["totalMoney"]);//正常购买商品的总金额
                        jifen += Convert.ToDecimal(car.Rows[i]["totalPV"]);
                    }
                }

                Response.Redirect("../../IPS/OrderPayment.aspx?Amount=" + money + "&Attach=shoppingcar&aeq=0");
                //Response.Write("<script>window.open('../../IPS/OrderPayment.aspx?Amount=" + order.OrderTotal + "&Attach=shoppingcar&ord=" + orderID + "','_blank')</script>");
                return;
            }

            ChangePayment(car, 2);//修改商品的支付方式为：拍币支付

            //接着处理正常购买的商品：拍币支付方式
            for (int i = 0; i < rows; i++)
            {
                if (Convert.ToInt32(car.Rows[i]["payMent"]) == 2)
                {
                    count += Convert.ToInt32(car.Rows[i]["count"]);
                    money += Convert.ToDecimal(car.Rows[i]["totalMoney"]);//正常购买商品的总金额
                    jifen += Convert.ToDecimal(car.Rows[i]["totalPV"]);
                }
            }

            if (LoginUser1.Emoney < money)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("EcurrencyBalance") + "');", true);//拍币账户余额不足
                return;
            }

            bool b = true;
            string orderID = GetOrderID();//形成一条订单记录，存入订单表
            for (int i = 0; i < rows; i++)
            {
                if (Convert.ToInt32(car.Rows[i]["payMent"]) == 2)
                {
                    lgk.Model.tb_goods model_goods = goodsBLL.GetModel(Convert.ToInt32(car.Rows[i]["ProcudeID"]));
                    if (model_goods.RealityPrice < Convert.ToInt32(car.Rows[i]["count"]))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('【" + model_goods.GoodsName + "】" + GetLanguage("LowStock") + "!');", true);//库存不足
                        b = false;
                        break;
                    }
                    else
                    {
                        lgk.Model.tb_OrderDetail detail = new lgk.Model.tb_OrderDetail()
                        {
                            OrderCode = orderID,
                            ProcudeID = Convert.ToInt32(car.Rows[i]["ProcudeID"]),
                            ProcudeName = car.Rows[i]["procudeName"].ToString(),
                            Price = Convert.ToDecimal(car.Rows[i]["Goods006"]),
                            PV = Convert.ToInt32(car.Rows[i]["Goods002"]),
                            OrderSum = Convert.ToInt32(car.Rows[i]["count"]),
                            OrderTotal = Convert.ToDecimal(car.Rows[i]["totalMoney"]),
                            PVTotal = Convert.ToInt32(car.Rows[i]["totalPV"]),
                            OrderDate = DateTime.Now
                        };
                        if (orderDetailBLL.Add(detail) == 0)//订单明细表存入数据库
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AddFailed") + "');", true);//添加失败
                            b = false;
                            break;
                        }
                    }
                }
            }
            if (b)
            {
                int OrderType = 0;
                if (this.rdoMoney.Checked)
                {
                    LoginUser1.Emoney -= money;//拍币支付，只扣拍币
                    OrderType = 1;
                }
                lgk.Model.tb_Order order = new lgk.Model.tb_Order()
                {
                    UserID = LoginUser1.UserID,
                    UserAddr = LoginUser1.Address,
                    OrderCode = orderID,
                    OrderSum = count,
                    OrderTotal = money,
                    PVTotal = jifen,
                    OrderDate = DateTime.Now,
                    IsSend = 1,
                    PayMethod = 2,
                    OrderType = OrderType,
                };

                long id = orderBLL.Add(order);//将订单记录存入订单表
                if (id == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OrderToFailed") + "');", true);//添加订单失败
                    b = false;
                    return;
                }
                new lgk.BLL.tb_user().Update(LoginUser1);
                if (this.rdoMoney.Checked)
                {
                    add_journal(getLoginID1(), 0, jifen, Convert.ToDecimal(LoginUser1.Emoney), 2,"购物提交订单", "Submit shopping order", getLoginID1());
                }
                Session["A128076_" + getLoginID1() + "_ShoppingCar"] = null;
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('提交订单成功!');top.location.href='../index.aspx?order=dd';", true);
            }
        }


        //判断购物车中是否存在积分兑换商品
        private bool HasCharge(DataTable car)
        {
            foreach (DataRow row in car.Rows)
            {
                if (Convert.ToInt32(row["payMent"]) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        //判断购物车中是否存在正常购买的商品
        private bool HasProduct(DataTable car)
        {
            foreach (DataRow row in car.Rows)
            {
                if (Convert.ToInt32(row["payMent"]) == 2 || Convert.ToInt32(row["payMent"]) == 3)
                {
                    return true;
                }
            }
            return false;
        }

        //如果购物车中有正常购买商品，则显示在线支付，拍币支付
        private void ShowPayment()
        {
            DataTable car = (DataTable)Session["A128076_" + getLoginID1() + "_ShoppingCar"];
            if (car == null)
            {
                return;
            }
            bool has = HasProduct(car);
            if (has == true)
            {
                JfPayShow = false;
                //rdoPv.Visible = JfPayShow;

                //rdoMoney.Visible = true;
                //rdoZX.Visible = true;
            }
            else
            {
                JfPayShow = true;
                //rdoPv.Visible = JfPayShow;

                //rdoMoney.Visible = false;
                //rdoZX.Visible = false;
            }
        }

        //购物车中，积分换购的商品单独提取出来，自动处理
        private void HandCharge(DataTable car)
        {
            if (car == null)
            {
                return;
            }

            decimal money = 0;
            decimal jifen = 0;

            int rows = car.Rows.Count;
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                if (Convert.ToInt32(car.Rows[i]["payMent"]) == 1)
                {
                    count += Convert.ToInt32(car.Rows[i]["count"]);
                    money += Convert.ToDecimal(car.Rows[i]["totalMoney"]);
                    jifen += Convert.ToDecimal(car.Rows[i]["totalPV"]);
                }
            }

            if (LoginUser1.StockAccount < jifen)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("pointsBalance") + "');", true);//积分账户余额不足
                return;
            }

            bool b = true;
            string orderID = GetOrderID();//形成一条订单记录，存入订单表
            for (int i = 0; i < rows; i++)
            {
                if (Convert.ToInt32(car.Rows[i]["payMent"]) == 1)
                {
                    lgk.Model.tb_goods model_goods = goodsBLL.GetModel(Convert.ToInt32(car.Rows[i]["ProcudeID"]));

                    if (model_goods.RealityPrice < Convert.ToInt32(car.Rows[i]["count"]))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('【" + model_goods.GoodsName + "】" + GetLanguage("LowStock") + "!');", true);//库存不足
                        b = false;
                        break;
                    }
                    else
                    {
                        lgk.Model.tb_OrderDetail detail = new lgk.Model.tb_OrderDetail()
                        {
                            OrderCode = orderID,
                            ProcudeID = Convert.ToInt32(car.Rows[i]["ProcudeID"]),
                            ProcudeName = car.Rows[i]["procudeName"].ToString(),
                            Price = Convert.ToDecimal(car.Rows[i]["Goods006"]),
                            PV = Convert.ToInt32(car.Rows[i]["Goods002"]),
                            OrderSum = Convert.ToInt32(car.Rows[i]["count"]),
                            OrderTotal = Convert.ToDecimal(car.Rows[i]["totalMoney"]),
                            PVTotal = Convert.ToInt32(car.Rows[i]["totalPV"]),
                            OrderDate = DateTime.Now
                        };
                        if (orderDetailBLL.Add(detail) == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AddFailed") + "');", true);//添加失败
                            b = false;
                            break;
                        }
                    }
                }
            }
            if (b)
            {
                int OrderType = 0;
                if (this.rdoPv.Checked)
                {
                    LoginUser1.StockAccount -= jifen;//积分兑换，只扣积分
                    OrderType = 0;
                }
                lgk.Model.tb_Order order = new lgk.Model.tb_Order()
                {
                    UserID = LoginUser1.UserID,
                    UserAddr = LoginUser1.Address,
                    OrderCode = orderID,
                    OrderSum = count,
                    OrderTotal = money,
                    PVTotal = jifen,
                    OrderDate = DateTime.Now,
                    IsSend = 1,
                    PayMethod = 1,
                    OrderType = OrderType,
                };

                long id = orderBLL.Add(order);//将订单记录存入订单表
                if (id == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OrderToFailed") + "');", true);//添加订单失败
                    b = false;
                    return;
                }
                new lgk.BLL.tb_user().Update(LoginUser1);

                add_journal(getLoginID1(), 0, jifen, Convert.ToDecimal(LoginUser1.StockAccount), 3, "购物提交订单", "Submit shopping order", getLoginID1());

                bool hasproduct = HasProduct(car);
                if (hasproduct == false)
                {
                    Session["A128076_" + getLoginID1() + "_ShoppingCar"] = null;//如果不存在正常购买商品，则清空
                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('提交订单成功!');top.location.href='../index.aspx?order=dd';", true);
            }
        }

    }
}