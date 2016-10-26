using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Drawing;
using lgk.BLL;
using System.Data;
using System.Text;

namespace Web.user.shop
{
    public partial class shopList : System.Web.UI.Page
    {
        AllCore ac = new AllCore();

        lgk.BLL.tb_goods goodsBLL = new lgk.BLL.tb_goods();

        protected void Page_Load(object sender, EventArgs e)
        {
            BingDingType();

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private int Layer()//层
        {
            if (Request["layer"] != null && PageValidate.IsInt(Request["layer"].ToString()))
            {
                return int.Parse(Request["layer"].ToString());
            }
            else
                return 0;
        }

        private int Pid()//一级类
        {
            if (Request["ptype"] != null && PageValidate.IsInt(Request["ptype"].ToString()))
            {
                return int.Parse(Request["ptype"].ToString());
            }
            else
                return 0;
        }

        private int Cid() //二级类
        {
            if (Request["ctype"] != null && PageValidate.IsInt(Request["ctype"].ToString()))
            {
                return int.Parse(Request["ctype"].ToString());
            }
            else
                return -1;
        }
        private int Sid() //三级类
        {
            if (Request["stype"] != null && PageValidate.IsInt(Request["stype"].ToString()))
            {
                return int.Parse(Request["stype"].ToString());
            }
            else
                return 1;
        }

        private string GetWhere()
        {
            string strWh = " and 1=1";
            if (Request.Cookies["region_name"] != null && Request.Cookies["region_name"].ToString() != "")
            {
                // strWh = string.Format(" and City like '%{0}%' ", Server.UrlDecode(Request.Cookies["region_name"].Value));
                if (Server.UrlDecode(Request.Cookies["region_name"].Value) == "")
                {
                    strWh = " and 1=1";
                }
                else
                {
                    strWh = string.Format(" and City like '%{0}%' ", Server.UrlDecode(Request.Cookies["region_name"].Value));
                }

            }
            return strWh;

        }

        private void BindData()
        {
            if (Layer() > 0)
            {
                //g.[StateType] = 1 and 
                ac.bind_repeater(goodsBLL.GetList(1000, "g.Goods001 = 1 and g.Goods003 = 0 and g.Goods004 like '%" + Layer() + "%'", "[AddTime] desc"), rptProduct, "AddTime desc", tr1, AspNetPager1);
            }
            else if (Pid() > 0 && Cid() < 1) //只有一级类
            {
                ac.bind_repeater(goodsBLL.GetList(1000, "[Goods001]=1 and Goods003=0  and [TypeID]=" + Pid() + GetWhere(), "[AddTime]"), rptProduct, "AddTime desc", tr1, AspNetPager1);
            }
            else if (Pid() <0 && Cid() > 0&&Sid() < 1) //只有二级类
            {
                //默认
               // ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 " + GetWhere(), "[AddTime]"), rptProduct, "AddTime desc", tr1, AspNetPager1);
                ac.bind_repeater(goodsBLL.GetList(1000, "[Goods001]=1 and Goods003=0  and [GoodsType]=" + Cid() + GetWhere(), "[AddTime]"), rptProduct, "AddTime desc", tr1, AspNetPager1);
       
            }
            else if (Sid() > 1 && Cid() > 0 && Pid() < 1) //只有三级类
            {
                //默认
                // ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 " + GetWhere(), "[AddTime]"), rptProduct, "AddTime desc", tr1, AspNetPager1);
                ac.bind_repeater(goodsBLL.GetList(1000, "[Goods001]=1 and Goods003=0  and [Goods006]=" + Sid() + " and [GoodsType]=" + Cid() + GetWhere(), "[AddTime]"), rptProduct, "AddTime desc", tr1, AspNetPager1);

            }
            else if (Pid() > 0 && Cid() > 0) //一二级类都有
            {

                ac.bind_repeater(goodsBLL.GetList(1000, "[Goods001]=1 and Goods003=0  and [TypeID]=" + Pid() + " and [GoodsType]=" + Cid() + GetWhere(), "[AddTime]"), rptProduct, "AddTime desc", tr1, AspNetPager1);
            }
            else
            { //都没有,默认
                ac.bind_repeater(goodsBLL.GetList(1000, "[Goods001]=1 and Goods003=0  " + GetWhere(), "[AddTime]"), rptProduct, "AddTime desc", tr1, AspNetPager1);

            }

        }
        private void BingDingType()
        {
            string OneName = "";
            StringBuilder sb = new StringBuilder();
            DataTable dt = goodsBLL.GetGoodsOneName(Pid(), GetWhere());//一级分类,1为男士
            DataTable dtTwo = new DataTable();
            int Count = 0;//共计是品
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int OneTypeID = Convert.ToInt32(dt.Rows[i]["OneTypeID"].ToString());
                     OneName = dt.Rows[i]["OneName"].ToString();
                    string total = dt.Rows[i]["total"].ToString();
                    if (Pid() == OneTypeID && Cid() == -1 )
                    {
                        sb.Append(@"<dl class='tuan_serch_item clearfix'><dt class='Left red'><b>" + OneName + "：</b><span style='color:blue;width:100px;font-weight:bold;'>全部" + OneName + "<span>(" + total + ")</span></span></dt><dd>");
                    }
                    else
                    {
                        sb.Append(@"<dl class='tuan_serch_item clearfix'><dt class='Left red'  ><b>" + OneName + "：</b><span style='width:100px;padding-right:15px;'><a href='shopList.aspx?ptype=" + OneTypeID + "' >全部" + OneName + "<span>(" + total + ")</span></a></span></dt><dd>");
                    }
                    dtTwo = goodsBLL.GetGoodsTwoName(Pid(), GetWhere());//二级分类
                    Count = Count + Convert.ToInt32(total);
                    if (dtTwo.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtTwo.Rows.Count; j++)
                        {
                            string TwoName = dtTwo.Rows[j]["TwoName"].ToString();
                            int GoodsType = Convert.ToInt32(dtTwo.Rows[j]["GoodsType"].ToString());
                            string Total = dtTwo.Rows[j]["total"].ToString();
                            if (Pid() == OneTypeID && Cid() == GoodsType)
                            {
                                sb.Append("<b  style='color:blue;padding-left:15px;' >" + TwoName + "<span>(" + Total + ")</span></b>");
                            }
                            else
                            {
                                sb.Append("<a href='shopList.aspx?ptype=" + OneTypeID + "&ctype=" + GoodsType + "'>" + TwoName + "<span>(" + Total + ")</span></a>");
                            }
                        }
                        sb.Append("	</dd></dl>");
                    }
                }
            }
            lblTitle.Text = OneName;//导航
            hidd.Value = sb.ToString();
            hiddCount.Value = Count.ToString();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        public int New
        {
            get
            {
                if (ViewState["New"] != null)
                    return Convert.ToInt32(ViewState["New"].ToString());
                else return 0;
            }
            set { ViewState["New"] = value; }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (New == 0)
            {
                // and [StateType]=1
                ac.bind_repeater(goodsBLL.GetList(1000, " [Goods001]=1 and Goods003=0 and [TypeID]=" + Pid() + GetWhere(), "[AddTime]"), rptProduct, "AddTime asc", tr1, AspNetPager1);
                New = 1;
            }
            else
            {
                ac.bind_repeater(goodsBLL.GetList(1000, " [Goods001]=1 and Goods003=0 and [TypeID]=" + Pid() + GetWhere(), "[AddTime]"), rptProduct, "AddTime desc", tr1, AspNetPager1);
                New = 0;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (New == 0)
            {
                ac.bind_repeater(goodsBLL.GetList(1000, " [Goods001]=1 and Goods003=0 and [TypeID]=" + Pid() + GetWhere(), "[AddTime]"), rptProduct, "[AddTime] asc", tr1, AspNetPager1);
                New = 1;
            }
            else
            {
                ac.bind_repeater(goodsBLL.GetList(1000, " [Goods001]=1 and Goods003=0 and [TypeID]=" + Pid() + GetWhere(), "[AddTime]"), rptProduct, "[AddTime] desc", tr1, AspNetPager1);
                New = 0;
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (New == 0)
            {
                ac.bind_repeater(goodsBLL.GetList(1000, " [Goods001]=1 and Goods003=0 and [TypeID]=" + Pid() + GetWhere(), "[AddTime]"), rptProduct, "[RealityPrice] asc", tr1, AspNetPager1);
                New = 1;
            }
            else
            {
                ac.bind_repeater(goodsBLL.GetList(1000, " [Goods001]=1 and Goods003=0 and [TypeID]=" + Pid() + GetWhere(), "[AddTime]"), rptProduct, "[RealityPrice] desc", tr1, AspNetPager1);
                New = 0;
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (New == 0)
            {
                ac.bind_repeater(goodsBLL.GetList(1000, " [Goods001]=1 and Goods003=0 and [TypeID]=" + Pid() + GetWhere(), "[AddTime]"), rptProduct, "[Goods005] asc", tr1, AspNetPager1);
                New = 1;
            }
            else
            {
                ac.bind_repeater(goodsBLL.GetList(1000, " [Goods001]=1 and Goods003=0 and [TypeID]=" + Pid() + GetWhere(), "[AddTime]"), rptProduct, "[Goods005] desc", tr1, AspNetPager1);
                New = 0;
            }
        }

    }
}