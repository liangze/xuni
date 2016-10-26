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
    public partial class SalesDetail : AllCore//PageCore//System.Web.UI.Page
    {
        public int SaState = 0;
        public string UserCode = string.Empty;
        private bool en = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Culture"].Value == "en-us")
            {
                en = true;
            }
            if (!IsPostBack)
            {
                //竞拍
                gp_opBLL.ExecProc("proc_salesroom");
                BindProductDetail();
            }
        }
        private void BindProductDetail()
        {
            var model = tb_SalesroomBll.GetModel(getIntRequest("SaId"));
            if (model == null) { div_no.Visible = true; }
            else
            {
                SaState =int.Parse(model.SaState.ToString());
                if (SaState == 2)
                {
                    long userid = long.Parse(model.SuccessUserID.ToString());
                    var user = userBLL.GetModel(userid);
                    UserCode = user != null ? user.UserCode : string.Empty;
                }
                div_yes.Visible = true;
                img1.Src = "../../Upload/" + model.SaPrImage;
                if (en)
                {
                    Label2.Text = model.SaPrName_en;
                }
                else
                {
                    Label2.Text = model.SaPrName;
                }
                Label6.Text = double.Parse(model.SaPrice.ToString()).ToString("0.00");//市场价
                Label7.Text = double.Parse(model.SaPrUsually.ToString()).ToString("0.00");//竞拍价价
                if (en)
                {
                    Literal1.Text = model.SaPrConent_en;
                }
                else
                {
                    Literal1.Text = model.SaPrConent;
                }
                if(model.SaBeginTime!=null)
                {
                    DateTime beginTime=DateTime.Parse(model.SaBeginTime.ToString());
                    tyear.Value = beginTime.Year.ToString();
                    tmonth.Value = beginTime.Month.ToString();
                    tdate.Value = beginTime.Day.ToString();
                    tHour.Value = beginTime.Hour.ToString();
                    tMinute.Value = beginTime.Minute.ToString();
                    tSecond.Value = beginTime.Second.ToString();
                }
                
            }
        }
        //protected void imgbtnCut_Click(object sender, ImageClickEventArgs e)
        //{
        //    int num = 0;
        //    try
        //    {
        //        num = Convert.ToInt32(txtNum.Value.Trim());
        //        CountPrice(num-1);
        //    }
        //    catch
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('数量格式错误!');", true);
        //        return;
        //    }
        //    if (num == 0) { ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('数量必须大于零!');", true); return; }
        //    txtNum.Value = (Convert.ToInt32(txtNum.Value.Trim()) - 1).ToString();
        //}

        //protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        int num = Convert.ToInt32(txtNum.Value.Trim());
        //        CountPrice(num+1);
        //    }
        //    catch
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('数量格式错误!');", true);
        //        return;
        //    }
        //    txtNum.Value = (Convert.ToInt32(txtNum.Value.Trim()) + 1).ToString();
        //}
        ///// <summary>
        ///// 计算总价
        ///// </summary>
        //public void CountPrice(int num) 
        //{
            
        //    this.Label8.Text = (num * Convert.ToDouble(Label7.Text)).ToString();
        //}

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    if (getLoginID() == 0)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请先登录！');window.location.href='../../Login.aspx';", true);
        //    }
        //    else
        //    {
        //        lgk.Model.tb_goods model = goodsBLL.GetModel(getIntRequest("id"));//商品
        //        string id = getIntRequest("id").ToString();//商品id
        //        bool b = true;//购物车是否有商品存在
        //        DataTable car = (DataTable)Session["A128076_" + getLoginID() + "_ShoppingCar"];

        //        if (txtNum.Value == "" || txtNum.Value == "0")
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入数量再加入购物车!');", true);
        //            return;
        //        }
        //        if (!PageValidate.IsNumber(txtNum.Value))
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('只能输入整数!');", true);
        //            return;
        //        }
        //        if (Convert.ToInt32(txtNum.Value) > model.RealityPrice)
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('库存不足!');", true);
        //            return;
        //        }
        //        if (car == null)
        //        {
        //            car = new DataTable("A128076_" + getLoginID() + "_ShoppingCar");

        //            car.Columns.Add("ProcudeID", typeof(int));//商品id
        //            car.Columns.Add("img", typeof(string));//图片名称
        //            car.Columns.Add("procudeName", typeof(string));//商品名称
        //            car.Columns.Add("Goods002", typeof(decimal));//积分
        //            car.Columns.Add("Goods006", typeof(decimal));//价格
        //            car.Columns.Add("count", typeof(int));//购买数量
        //            car.Columns.Add("totalMoney", typeof(decimal));//购买总金额
        //            car.Columns.Add("typeID", typeof(int));//商品类型(总)
        //            car.Columns.Add("GoodsType", typeof(int));//商品类型(详情)
        //            car.Columns.Add("totalPV", typeof(decimal));//总积分
        //            DataRow dr = car.NewRow();
        //            dr[0] = getIntRequest("id");
        //            dr[1] = model.Pic1;
        //            dr[2] = model.GoodsName;
        //            dr[3] = model.Goods002;
        //            dr[4] = model.Goods006;
        //            dr[5] = Convert.ToInt32(txtNum.Value);
        //            dr[6] = model.Goods006 * Convert.ToInt32(txtNum.Value);
        //            dr[7] = model.TypeID;
        //            dr[8] = model.GoodsType;
        //            dr[9] = model.Goods002 * Convert.ToInt32(txtNum.Value);

        //            car.Rows.Add(dr);
        //            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('加入购物车成功!');", true);
        //        }
        //        else
        //        {
        //            for (int i = 0; i < car.Rows.Count; i++)
        //            {
        //                if (id == car.Rows[i]["ProcudeID"].ToString())
        //                {
        //                    b = false;
        //                    int num = Convert.ToInt32(car.Rows[i]["count"]);
        //                    car.Rows[i]["count"] = num + Convert.ToInt32(txtNum.Value);
        //                    car.Rows[i]["totalPV"] = Convert.ToDecimal(car.Rows[i]["totalPV"]) + model.Goods002 * Convert.ToInt32(txtNum.Value);
        //                    car.Rows[i]["totalMoney"] = Convert.ToDecimal(car.Rows[i]["totalMoney"]) + model.Goods006 * Convert.ToInt32(txtNum.Value);
        //                    break;
        //                }
        //            }
        //            if (b)
        //            {
        //                DataRow dr = car.NewRow();
        //                dr[0] = getIntRequest("id");
        //                dr[1] = model.Pic1;
        //                dr[2] = model.GoodsName;
        //                dr[3] = model.Goods002;
        //                dr[4] = model.Goods006;
        //                dr[5] = Convert.ToInt32(txtNum.Value);
        //                dr[6] = model.Goods006 * Convert.ToInt32(txtNum.Value);
        //                dr[7] = model.TypeID;
        //                dr[8] = model.GoodsType;
        //                dr[9] = model.Goods002 * Convert.ToInt32(txtNum.Value);
        //                car.Rows.Add(dr);
        //            }
        //        }
        //        Session["A128076_" + getLoginID() + "_ShoppingCar"] = car;
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('加入购物车成功!');window.location.href='shoppingcar.aspx';", true);
        //        txtNum.Value = "";
        //    }
        //}
    }
}
