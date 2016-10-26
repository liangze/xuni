using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Library;
using System.Drawing;
using lgk.BLL;
using System.Data;
using System.Text;
using lgk.Model;

namespace Web.user.shop
{
    public partial class goodscart : System.Web.UI.Page
    {
        AllCore ac = new AllCore();
        DataSet ds = new DataSet();

        public lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
        lgk.BLL.tb_goodsCar goodsCarBLL = new lgk.BLL.tb_goodsCar();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetLoginName() > 0)
                    BindData();
                else
                    Response.Redirect("../../login.aspx");
            }
        }

        private void BindData()
        {
            if (GetLoginName() > 0) //用户
            {
                ds = goodsCarBLL.GetList("BuyUser=" + GetLoginName(), userBLL.GetModel(GetLoginName()).LevelID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ac.bind_repeater(ds, rptProduct, "AddTime desc", tr1, AspNetPager1);

                }
                else
                {
                    //  Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 获取当前登录UserCode ID
        /// </summary>
        /// <returns></returns>
        public long GetLoginName()
        {
            if (Request.Cookies["A128076_user"] != null)
            {
                return long.Parse(Request.Cookies["A128076_user"]["Id"]);
            }
            else
            {
                return 0;
            }
        }

        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                if (goodsCarBLL.Delete(id) == true)
                {
                    BindData();
                    rptProduct.DataBind();
                }
                else
                {
                    MessageBox.Show(this, "删除失败,请重试!");
                }
            }

            if (e.CommandName == "subtract")//减去
            {
                TextBox txtCount = e.Item.FindControl("JS_goods_number_11081797") as TextBox;
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                if (PageValidate.IsInt(txtCount.Text.Trim()) == true)
                {
                    int iCount = Convert.ToInt32(txtCount.Text.Trim()) - 1;
                    if (iCount < 1)
                    {
                        iCount = 1;
                    }
                    ////修改库存
                    lgk.Model.tb_goodsCar carModelNew = new lgk.Model.tb_goodsCar();
                    lgk.Model.tb_goodsCar carModelOld = new lgk.Model.tb_goodsCar();
                    carModelOld = goodsCarBLL.GetModel(id);

                    carModelNew.ID = carModelOld.ID;
                    carModelNew.GoodsID = carModelOld.GoodsID;
                    carModelNew.GoodsCode = carModelOld.GoodsCode;
                    carModelNew.GoodsName = carModelOld.GoodsName;
                    carModelNew.Price = carModelOld.Price;
                    carModelNew.RealityPrice = carModelOld.RealityPrice;
                    carModelNew.ShopPrice = carModelOld.ShopPrice;
                    carModelNew.TypeID = carModelOld.TypeID;
                    carModelNew.TypeIDName = carModelOld.TypeIDName;
                    carModelNew.GoodsType = carModelOld.GoodsType;
                    carModelNew.GoodsTypeName = carModelOld.GoodsTypeName;
                    carModelNew.Pic1 = carModelOld.Pic1;
                    carModelNew.Remarks = carModelOld.Remarks;
                    carModelNew.AddTime = carModelOld.AddTime;
                    carModelNew.Goods002 = carModelOld.Goods002;
                    carModelNew.Goods005 = carModelOld.Goods005;
                    carModelNew.BuyUser = carModelOld.BuyUser;
                    carModelNew.Goods006 = iCount;//数量
                    carModelNew.TotalGoods006 = iCount * carModelOld.Goods002;//总积分
                    carModelNew.TotalMoney = iCount * carModelOld.Price;//总价
                    carModelNew.gColor = carModelOld.gColor;
                    carModelNew.gSize = carModelOld.gSize;

                    goodsCarBLL.Update(carModelNew);//修改
                    BindData();
                }
            }

            if (e.CommandName == "add")//加
            {
                TextBox txtCount = e.Item.FindControl("JS_goods_number_11081797") as TextBox;
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                if (PageValidate.IsInt(txtCount.Text.Trim()) == true)
                {
                    ////修改库存
                    lgk.Model.tb_goodsCar carModelNew = new lgk.Model.tb_goodsCar();
                    lgk.Model.tb_goodsCar carModelOld = new lgk.Model.tb_goodsCar();
                    carModelOld = goodsCarBLL.GetModel(id);

                    lgk.BLL.tb_goods goodsBLL = new lgk.BLL.tb_goods();
                    lgk.Model.tb_goods goodModel = new lgk.Model.tb_goods();

                    goodModel = goodsBLL.GetModel(carModelOld.GoodsID);//获取库存

                    int iCount = Convert.ToInt32(txtCount.Text.Trim()) + 1;
                    if (iCount > Convert.ToInt32(goodModel.Pic5))
                    {
                        iCount = Convert.ToInt32(goodModel.Pic5);
                    }

                    carModelNew.ID = carModelOld.ID;
                    carModelNew.GoodsID = carModelOld.GoodsID;
                    carModelNew.GoodsCode = carModelOld.GoodsCode;
                    carModelNew.GoodsName = carModelOld.GoodsName;
                    carModelNew.Price = carModelOld.Price;
                    carModelNew.RealityPrice = carModelOld.RealityPrice;
                    carModelNew.ShopPrice = carModelOld.ShopPrice;
                    carModelNew.TypeID = carModelOld.TypeID;
                    carModelNew.TypeIDName = carModelOld.TypeIDName;
                    carModelNew.GoodsType = carModelOld.GoodsType;
                    carModelNew.GoodsTypeName = carModelOld.GoodsTypeName;
                    carModelNew.Pic1 = carModelOld.Pic1;
                    carModelNew.Remarks = carModelOld.Remarks;
                    carModelNew.AddTime = carModelOld.AddTime;
                    carModelNew.Goods002 = carModelOld.Goods002;
                    carModelNew.Goods005 = carModelOld.Goods005;
                    carModelNew.BuyUser = carModelOld.BuyUser;
                    carModelNew.Goods006 = iCount;//数量
                    carModelNew.TotalGoods006 = iCount * carModelOld.Goods002;//总积分
                    carModelNew.gColor = carModelOld.gColor;
                    carModelNew.gSize = carModelOld.gSize;

                    carModelNew.TotalMoney = iCount * carModelOld.Price;//总价

                    goodsCarBLL.Update(carModelNew);//修改
                    BindData();
                }
            }
        }
    }
}