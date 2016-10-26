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
    public partial class miaoshaList : System.Web.UI.Page
    {
        AllCore ac = new AllCore();
        tb_produceType prodType = new tb_produceType();
        tb_goods_cxth good = new tb_goods_cxth();
        protected void Page_Load(object sender, EventArgs e)
        {
            BingDingType();

            if (!IsPostBack)
            {
                bind();
            }

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
        private string GetWhere()
        {
            string strWh = " and 1=1";
            if (Request.Cookies["region_name"] != null && Request.Cookies["region_name"].ToString() != "")
            {
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
        private void bind()
        {
            if (Pid() > 0 && Cid() < 1) //只有一级类
            {
                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78 and [TypeID]=" + Pid()+ GetWhere(), "[Goods007]"), rptProduct, "Goods007 desc", tr1, AspNetPager1);
            }
            else if (Pid() < 1 && Cid() > 0) //只有二级类
            {
                //默认
                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78 "+ GetWhere(), "[Goods007]"), rptProduct, "Goods007 desc", tr1, AspNetPager1);
            }
            else if (Pid() > 0 && Cid() > 0) //一二级类都有
            {

                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78 and [TypeID]=" + Pid() + " and [GoodsType]=" + Cid() + GetWhere(), "[Goods007]"), rptProduct, "Goods007 desc", tr1, AspNetPager1);
            }
            else
            { //都没有,默认

                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78 " + GetWhere(), "[Goods007]"), rptProduct, "Goods007 desc", tr1, AspNetPager1);

            }

        }
        private void BingDingType()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = good.GetGoodsOneName(78);//一级分类,78为秒杀
            DataTable dtTwo = new DataTable();
            int Count = 0;//共计是品
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int OneTypeID = Convert.ToInt32(dt.Rows[i]["OneTypeID"].ToString());
                    string OneName = dt.Rows[i]["OneName"].ToString();
                    string total = dt.Rows[i]["total"].ToString();
                    sb.Append(@"<dl class='tuan_serch_item clearfix'><dt class='Left red'><b>" + OneName + "：</b><a href='miaoshaList.aspx?ptype=" + OneTypeID + "'>全部" + OneName + "<span>(" + total + ")</span></a></dt><dd>");
                    dtTwo = good.GetGoodsTwoName(78, OneTypeID);//二级分类
                    Count = Count + Convert.ToInt32(total);
                    if (dtTwo.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtTwo.Rows.Count; j++)
                        {
                            string TwoName = dtTwo.Rows[j]["TwoName"].ToString();
                            int GoodsType = Convert.ToInt32(dtTwo.Rows[j]["GoodsType"].ToString());
                            string Total = dtTwo.Rows[j]["total"].ToString();
                            sb.Append("<a href='miaoshaList.aspx?ptype=" + OneTypeID + "&ctype=" + GoodsType + "'>" + TwoName + "<span>(" + Total + ")</span></a>");
                        }
                        sb.Append("	</dd></dl>");
                    }
                }
            }

            hidd.Value = sb.ToString();
            hiddCount.Value = Count.ToString();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();

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
                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78" + GetWhere(), "[Goods007]"), rptProduct, "Goods007 asc", tr1, AspNetPager1);
                New = 1;
            }
            else
            {
                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78" + GetWhere(), "[Goods007]"), rptProduct, "Goods007 desc", tr1, AspNetPager1);
                New = 0;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (New == 0)
            {
                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78" + GetWhere(), "[Goods007]"), rptProduct, "[SealCount] asc", tr1, AspNetPager1);
                New = 1;
            }
            else
            {
                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78" + GetWhere(), "[Goods007]"), rptProduct, "[SealCount] desc", tr1, AspNetPager1);
                New = 0;
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (New == 0)
            {
                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78" + GetWhere(), "[Goods007]"), rptProduct, "[RealityPrice] asc", tr1, AspNetPager1);
                New = 1;
            }
            else
            {
                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78" + GetWhere(), "[Goods007]"), rptProduct, "[RealityPrice] desc", tr1, AspNetPager1);
                New = 0;
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (New == 0)
            {
                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78" + GetWhere(), "[Goods007]"), rptProduct, "[Goods005] asc", tr1, AspNetPager1);
                New = 1;
            }
            else
            {
                ac.bind_repeater(good.GetList(1000, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78" + GetWhere(), "[Goods007]"), rptProduct, "[Goods005] desc", tr1, AspNetPager1);
                New = 0;
            }
        }
    }
}