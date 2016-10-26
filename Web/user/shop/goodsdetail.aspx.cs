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
    public partial class goodsdetail : System.Web.UI.Page
    {
        AllCore ac = new AllCore();
        DataSet ds = new DataSet();
        lgk.BLL.tb_goods goodsBLL = new lgk.BLL.tb_goods();
        lgk.Model.tb_goods goodsInfo = new lgk.Model.tb_goods();
        lgk.BLL.tb_goodsCar goodsCarBLL = new lgk.BLL.tb_goodsCar();
        lgk.Model.tb_goodsCar goodsCarInfo = new lgk.Model.tb_goodsCar();
        lgk.BLL.tb_produceType produceTypeBLL = new lgk.BLL.tb_produceType();
        public lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
        lgk.BLL.tb_goods_property_size sizeBLL = new lgk.BLL.tb_goods_property_size();
        lgk.BLL.tb_goods_property_color colorBLL = new lgk.BLL.tb_goods_property_color();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private int Pid()//一父iD
        {
            if (Request["pid"] != null && PageValidate.IsInt(Request["pid"].ToString()))
            {
                return int.Parse(Request["pid"].ToString());
            }
            else
                Response.Redirect("Default.aspx");
            return 0;
        }

        private int Cid() //商品id
        {
            if (Request["gid"] != null && PageValidate.IsInt(Request["gid"].ToString()))
            {
                return int.Parse(Request["gid"].ToString());
            }
            else
                Response.Redirect("Default.aspx");
            return -1;
        }

        private void BindData()
        {
            if (Pid() > 0 && Cid() > 0) //一二级类都有and [StateType]=1 
            {
                ds = goodsBLL.GetList(1, "[Goods001]=1 and Goods003=0 and [TypeID]=" + Pid() + " and g.[ID]=" + Cid(), "[Goods007]");
                goodsInfo = goodsBLL.GetModelAndName(Cid());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ac.bind_repeater(ds, rptProduct, "Goods007 desc", tr1);

                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (GetLoginName() > 0)
            {
                if (e.CommandName == "btnAdd")
                {

                    if (((Panel)e.Item.FindControl("PanelProperty")).Visible)
                    {
                        if (hhsize.Value.Trim() == "")
                        {
                            MessageBox.Show(this, "请选择尺码!");
                            return;
                        }
                        if (hhcolor.Value.Trim() == "")
                        {
                            MessageBox.Show(this, "请选择颜色!");
                            return;
                        }

                    }

                    goodsInfo = goodsBLL.GetModelAndName(Cid());
                    #region
                    if (goodsInfo.ID > 0 && goodsInfo != null && Convert.ToInt32(goodsInfo.Pic5) > 0)
                    {
                        goodsCarInfo.GoodsID = goodsInfo.ID;
                        goodsCarInfo.GoodsCode = goodsInfo.GoodsCode;
                        goodsCarInfo.GoodsName = goodsInfo.GoodsName;
                        goodsCarInfo.Price = goodsInfo.Price;
                        goodsCarInfo.RealityPrice = goodsInfo.RealityPrice;
                        goodsCarInfo.ShopPrice = goodsInfo.ShopPrice;

                        goodsCarInfo.TypeID = goodsInfo.TypeID;
                        goodsCarInfo.TypeIDName = produceTypeBLL.GetTypeName(goodsInfo.TypeID);
                        goodsCarInfo.GoodsType = goodsInfo.GoodsType;
                        goodsCarInfo.GoodsTypeName = produceTypeBLL.GetTypeName(goodsInfo.GoodsType);
                        goodsCarInfo.Pic1 = goodsInfo.Pic1;
                        goodsCarInfo.Remarks = goodsInfo.Remarks;
                        goodsCarInfo.Goods002 = goodsInfo.Goods002;
                        goodsCarInfo.Goods005 = decimal.Parse(goodsInfo.Goods005.ToString());
                        //动态
                        if (count.Value == "")
                        {
                            goodsCarInfo.Goods006 = 1;
                        }
                        else
                        {
                            goodsCarInfo.Goods006 = Convert.ToInt32(count.Value);//数量
                        }
                        goodsCarInfo.BuyUser = GetLoginName();//购买者
                        if (userBLL.GetModel(GetLoginName()).LevelID > 0)
                        {
                            goodsCarInfo.TotalMoney = goodsCarInfo.Goods006 * goodsCarInfo.RealityPrice;//总金
                        }
                        else
                        {
                            goodsCarInfo.TotalMoney = goodsCarInfo.Goods006 * goodsCarInfo.ShopPrice;//总金
                        }
                        goodsCarInfo.TotalMoney = goodsCarInfo.Goods006 * goodsCarInfo.Price;//总金
                        goodsCarInfo.TotalGoods006 = goodsCarInfo.Goods006 * goodsCarInfo.Goods002;//总积分
                        goodsCarInfo.AddTime = DateTime.Now;
                        goodsCarInfo.gColor = hhcolor.Value.Trim();
                        goodsCarInfo.gSize = hhsize.Value.Trim();
                        string where = string.Format(" BuyUser ={0} and GoodsID={1}", goodsCarInfo.BuyUser, goodsCarInfo.GoodsID);
                        lgk.Model.tb_goodsCar _carModel = new lgk.Model.tb_goodsCar();
                        _carModel = goodsCarBLL.GetModel(where);

                        DataSet dsCount = goodsCarBLL.GetList("BuyUser=" + GetLoginName());
                        if (dsCount.Tables[0].Rows.Count <= 20)
                        {
                            #region
                            if (_carModel != null && _carModel.GoodsID > 0 && _carModel.RealityPrice == goodsInfo.RealityPrice && _carModel.Goods002 == goodsInfo.Goods002) //购物车中已经存在
                            {
                                //this.ClientScript.RegisterStartupScript(typeof(string), null, " if (confirm('购物车中已经存在该商品是否继续') == true) { $('#ctl00_ContentPlaceHolder1_hiddConfirm').val(1);} else {$('#ctl00_ContentPlaceHolder1_hiddConfirm').val(0);}", true);
                                //if (hiddConfirm.Value == "1") //确定
                                //{
                                _carModel.Goods006 += goodsCarInfo.Goods006;//加上原来的数量
                                // _carModel.Goods002 += carModel.Goods002;//积分
                                _carModel.TotalMoney += goodsCarInfo.TotalMoney;//总金
                                _carModel.TotalGoods006 += goodsCarInfo.TotalGoods006;//总积分
                                if (goodsCarBLL.Update(_carModel) == true)
                                {
                                    //MessageBox.Show(this, "成功加入购物车!");
                                    MessageBox.ShowAndRedirect(this.Page, "成功加入购物车!", this.Request.Url.AbsoluteUri);
                                }
                                else
                                {
                                    MessageBox.Show(this, "加入购物车失败,请重试!");
                                }
                                //}
                            }
                            else
                            {
                                if (goodsCarBLL.Add(goodsCarInfo) > 0)
                                {
                                    //  MessageBox.Show(this, "成功加入购物车!");
                                    MessageBox.ShowAndRedirect(this.Page, "成功加入购物车!", this.Request.Url.AbsoluteUri);
                                }
                                else
                                {
                                    MessageBox.Show(this, "加入购物车失败,请重试!");
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            MessageBox.Show(this, "购物车商品已经装满!");
                        }
                    }
                    else
                    {
                        // Response.Redirect("Default.aspx");
                    }
                    #endregion
                }
            }
            else
            {
                if (Pid() > 0 && Cid() > 0) //一二级类都有
                {
                    Response.Redirect("../../Login.aspx?action=" + Server.UrlEncode("/user/shop/goodsdetail.aspx?pid=" + Pid() + "&gid=" + Cid()));
                }
                else
                    Response.Redirect("../../Login.aspx");
            }
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

        protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rpSize = (Repeater)e.Item.FindControl("rpSize");
                Repeater rpColor = (Repeater)e.Item.FindControl("rpColor");
                //找到分类Repeater关联的数据项
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                //提取分类ID
                int goodsId = Convert.ToInt32(rowv["ID"]);
                //根据分类ID查询该分类下的产品，并绑定产品Repeater
                var size = ac.GetGoodsPropertySize(goodsId);
                rpSize.DataSource = size;
                rpSize.DataBind();
                if (size.Tables[0].Rows.Count == 0)
                {
                    ((Panel)e.Item.FindControl("PanelProperty")).Visible = false;
                }
                rpColor.DataSource = colorBLL.GetList(" goodsid=" + goodsId);
                rpColor.DataBind();
            }

        }
    }
}