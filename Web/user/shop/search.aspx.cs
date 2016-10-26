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
    public partial class search : System.Web.UI.Page
    {
        AllCore ac = new AllCore();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        private string Pid()//传来的名称
        {
            if (Request["name"] != null && Request["name"].ToString()!="")
            {
                return Request["name"].ToString();
            }
            else
                return "";
        }

    

        private void bind()
        {
            tb_goods_cxth good = new tb_goods_cxth();
            lgk.BLL.tb_goods tb_goodsBLL = new tb_goods();
            if (Pid()!="") //只有一级类
            {   
                string where=string.Format(" [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=77 and GoodsName like '%{0}%' ",Pid());
                DataSet dt = good.GetList(1000, where, "Goods007"); //团购类

                string where2=string.Format(" [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=78 and GoodsName like '%{0}%' ",Pid());
                DataSet dt2 = good.GetList(1000, where2, "Goods007"); //秒杀类

                string where3=string.Format(" [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild]=79 and GoodsName like '%{0}%' ",Pid());
                DataSet dt3 = good.GetList(1000, where3, "Goods007"); //限时类

                string where1 = string.Format(" [Goods001]=1 and [StateType]=1 and Goods003=0  and GoodsName like '%{0}%' ", Pid());
                DataSet dt1 = tb_goodsBLL.GetList(1000, where1, "Goods007");//普通类

                if (dt.Tables[0].Rows.Count > 0)//团购类
                {
                    ac.bind_repeater(dt, rptProduct, "Goods007 desc", null);
                }
                if (dt3.Tables[0].Rows.Count > 0)//限时类
                {
                    ac.bind_repeater(dt3, Repeater3, "Goods007 desc", null);
                }
                if (dt2.Tables[0].Rows.Count > 0)//秒杀类
                {
                    ac.bind_repeater(dt2, Repeater2, "Goods007 desc", null);
                }
                if (dt1.Tables[0].Rows.Count > 0)//普通类
                {
                    ac.bind_repeater(dt1, Repeater1, "Goods007 desc", null);
                }
                if (dt.Tables[0].Rows.Count <= 0 && dt1.Tables[0].Rows.Count <= 0 && dt2.Tables[0].Rows.Count <= 0 && dt3.Tables[0].Rows.Count <= 0)
                {
                    NotingPanle.Visible = true;
                }
            }
          
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();

        }

    }
}