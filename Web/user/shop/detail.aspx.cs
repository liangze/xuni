/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-12-24 17:41:50 
 * 文 件 名：		detail.cs 
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
using System.Data;
using DataAccess;

namespace Web.user.shop
{
    public partial class detail : AllCore//PageCore//System.Web.UI.Page
    {
        public string cnen = "zh-cn";//标注是英文版还是中文版
        public int payment = 1;//支付方式：1-积分支付；2-拍币支付
        private bool en = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            cnen = GetLanguage("Login");
            payment = Convert.ToInt32(Request["payment"]);
            if (Request.Cookies["Culture"].Value == "en-us")
            {
                en = true;
            }

            if (!IsPostBack)
            {
                int type = getIntRequest("type");
                switch (type)
                {
                    case 1: //男人
                        ShopHead1.Url = "man";
                        break;
                    case 36://女人
                        ShopHead1.Url = "woman";
                        break;
                    case 37://东方奢侈品
                        ShopHead1.Url = "east";
                        break;
                    case 38://积分兑购
                        ShopHead1.Url = "swap";
                        break;
                    default:
                        ShopHead1.Url = "man";
                        break;
                }

                if (getIntRequest("type") == 1)
                {
                    li1.Visible = true; li2.Visible = true;
                }
                BindProductDetail();
            }
        }

        /// <summary>
        /// 获取当前登录代理商ID
        /// </summary>
        /// <returns></returns>
        public int getLoginID()
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

        private void BindProductDetail()
        {
            lgk.Model.tb_goods model = goodsBLL.GetModel(getIntRequest("id"));
            if (model == null) { div_no.Visible = true; }
            else
            {
                div_yes.Visible = true;
                img1.Src = "../../Upload/" + model.Pic1;

                if (en)
                {
                    Label2.Text = model.GoodsName_en;
                }
                else
                {
                    Label2.Text = model.GoodsName;
                }
                //Label1.Text = model.Price.ToString();

                Label4.Text = model.GoodsCode;
                int num = ConvertToInt(DbHelperSQL.GetSingle("SELECT isnull(sum(OrderSum),0) AS ordersum FROM tb_OrderDetail t WHERE t.ProcudeID=" + model.ID));//销售数量
                int cun = (int)model.RealityPrice;
                Label3.Text = (cun - num).ToString();
                Label5.Text = num.ToString();
                Label6.Text = model.Price.ToString();//市场价
                Label7.Text = model.Goods006.ToString();//会员价
                lbScore.Text = model.Goods002.ToString();//积分
                CountPrice(1);
                
                if (en)
                {
                    Literal1.Text = model.Remarks_en;
                }
                else
                {
                    Literal1.Text = model.Remarks;
                }
                lbpId.Text = model.ID.ToString();
            }
        }

        protected void imgbtnCut_Click(object sender, ImageClickEventArgs e)
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(txtNum.Value.Trim());
                CountPrice(num - 1);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NumberError") + "');", true);//数量格式错误
                return;
            }
            if (num == 0) { ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NumberThanZero") + "');", true); return; }//数量必须大于零
            txtNum.Value = (Convert.ToInt32(txtNum.Value.Trim()) - 1).ToString();
        }

        protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(txtNum.Value.Trim());
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NumberError") + "');", true);//数量格式错误
                return;
            }
            num++;
            int id = 0;
            int.TryParse(lbpId.Text, out id);
            var good = goodsBLL.GetModel(id);
            if (num > good.RealityPrice)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("LowStock") + "');", true);//库存不足
                return;
            }
            txtNum.Value = (num.ToString()).ToString();
            CountPrice(num);
        }

        /// <summary>
        /// 计算总价
        /// </summary>
        public void CountPrice(int num)
        {
            if (payment == 1)
            {
                this.Label8.Text = (num * Convert.ToInt32(lbScore.Text)).ToString();
            }
            else
            {
                this.Label8.Text = double.Parse((num * Convert.ToDouble(Label7.Text)).ToString()).ToString("0.00");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (getLoginID() == 0)
            {
                if (cnen == "zh-cn")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请先登录！');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Please login!');", true);
                }
            }
            else
            {
                lgk.Model.tb_goods model = goodsBLL.GetModel(getIntRequest("id"));//商品
                string id = getIntRequest("id").ToString();//商品id
                bool b = true;//购物车是否有商品存在
                DataTable car = (DataTable)Session["A128076_" + getLoginID() + "_ShoppingCar"];

                if (txtNum.Value == "" || txtNum.Value == "0")
                {
                    if (cnen == "zh-cn")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入数量再加入购物车!');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Please input numbers!');", true);
                    }
                    return;
                }
                if (!PageValidate.IsNumber(txtNum.Value))
                {
                    if (cnen == "zh-cn")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('只能输入整数!');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Only integer!');", true);
                    }
                    return;
                }
                if (Convert.ToInt32(txtNum.Value) > model.RealityPrice)
                {
                    if (cnen == "zh-cn")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('库存不足!');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Understock!');", true);
                    }
                    return;
                }
                if (car == null)
                {
                    car = new DataTable("A128076_" + getLoginID() + "_ShoppingCar");

                    car.Columns.Add("ProcudeID", typeof(int));//商品id
                    car.Columns.Add("img", typeof(string));//图片名称
                    car.Columns.Add("procudeName", typeof(string));//商品名称
                    car.Columns.Add("Goods002", typeof(decimal));//积分
                    car.Columns.Add("Goods006", typeof(decimal));//价格
                    car.Columns.Add("count", typeof(int));//购买数量
                    car.Columns.Add("totalMoney", typeof(decimal));//购买总金额
                    car.Columns.Add("typeID", typeof(int));//商品类型(总)
                    car.Columns.Add("GoodsType", typeof(int));//商品类型(详情)
                    car.Columns.Add("totalPV", typeof(decimal));//总积分
                    car.Columns.Add("payMent", typeof(int));//支付方式
                    car.Columns.Add("Url", typeof(string));//Url

                    DataRow dr = car.NewRow();
                    dr[0] = getIntRequest("id");
                    dr[1] = model.Pic1;
                    if (en)
                    {
                        dr[2] = model.GoodsName_en;
                    }
                    else
                    {
                        dr[2] = model.GoodsName;
                    }
                    dr[3] = model.Goods002;
                    dr[4] = model.Goods006;
                    dr[5] = Convert.ToInt32(txtNum.Value);
                    dr[6] = model.Goods006 * Convert.ToInt32(txtNum.Value);
                    dr[7] = model.TypeID;
                    dr[8] = model.GoodsType;
                    dr[9] = model.Goods002 * Convert.ToInt32(txtNum.Value);
                    dr[10] = payment;
                    dr[11] = "detail.aspx?type=1&id=" + getIntRequest("id") + "&payment=" + payment;
                    car.Rows.Add(dr);
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('加入购物车成功!');", true);
                }
                else
                {
                    for (int i = 0; i < car.Rows.Count; i++)//存在指定支付类型的商品，则更新商品数量等；不存在，则新增
                    {
                        if (id == car.Rows[i]["ProcudeID"].ToString() && Convert.ToInt32(car.Rows[i]["payMent"]) == payment)
                        {
                            b = false;
                            int num = Convert.ToInt32(car.Rows[i]["count"]);
                            car.Rows[i]["count"] = num + Convert.ToInt32(txtNum.Value);
                            car.Rows[i]["totalPV"] = Convert.ToDecimal(car.Rows[i]["totalPV"]) + model.Goods002 * Convert.ToInt32(txtNum.Value);
                            car.Rows[i]["totalMoney"] = Convert.ToDecimal(car.Rows[i]["totalMoney"]) + model.Goods006 * Convert.ToInt32(txtNum.Value);
                            break;
                        }
                    }

                    if (b)
                    {
                        DataRow dr = car.NewRow();
                        dr[0] = getIntRequest("id");
                        dr[1] = model.Pic1;
                        if (en)
                        {
                            dr[2] = model.GoodsName_en;
                        }
                        else
                        {
                            dr[2] = model.GoodsName;
                        }
                        dr[3] = model.Goods002;
                        dr[4] = model.Goods006;
                        dr[5] = Convert.ToInt32(txtNum.Value);
                        dr[6] = model.Goods006 * Convert.ToInt32(txtNum.Value);
                        dr[7] = model.TypeID;
                        dr[8] = model.GoodsType;
                        dr[9] = model.Goods002 * Convert.ToInt32(txtNum.Value);
                        dr[10] = payment;
                        dr[11] = "detail.aspx?type=1&id=" + getIntRequest("id") + "&payment=" + payment;
                        car.Rows.Add(dr);
                    }
                }
                Session["A128076_" + getLoginID() + "_ShoppingCar"] = car;
                if (currentCulture == "zh-cn")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('加入购物车成功!');window.location.href='shoppingcar.aspx?payment=" + payment + "';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Add to cart success!');window.location.href='shoppingcar.aspx?payment=" + payment + "';", true);
                }
                txtNum.Value = "";
            }
        }

    }
}