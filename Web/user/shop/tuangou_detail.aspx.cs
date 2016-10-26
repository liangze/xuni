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

namespace Web.user.shop
{
    public partial class tuangou_detail : System.Web.UI.Page
    {
        AllCore ac = new AllCore();
        tb_produceType prodType = new tb_produceType();
        tb_goods_cxth good = new tb_goods_cxth();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                bind();
            }
               
        }
        private int Pid()//传递商品ID
        {
            if (Request["id"] != null && PageValidate.IsInteger(Request["id"].ToString()))
            {
                return int.Parse(Request["id"].ToString());
            }
            else
            {
                Response.Redirect("tuangou.aspx");
                return 0;
            }
        }

        private int Fid()//传递秒杀，团购，限时抢购ID
        {
            if (Request["pid"] != null && PageValidate.IsInt(Request["pid"].ToString()))
            {   
                return int.Parse(Request["pid"].ToString());
            }
            else
                return 0;
        }

        protected string OneName()
        {
            if (Fid() > 0) //只有一级类
            {
                lgk.Model.tb_produceType typModel = new lgk.Model.tb_produceType();
                lgk.BLL.tb_produceType typBLL = new lgk.BLL.tb_produceType();
                typModel = typBLL.GetModel(Fid());
                if (typModel != null) {
                    return typModel.TypeName;
                }else
                    return "";
            }
            else
                return "";
        }

        private void bind()
        {
            if (Pid() > 0 && Fid() > 0 && Fid()!=78) //只有一级类
            {
                DataSet ds = good.GetList(1, "[Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopId]=" + Fid() + " and g.[ID]=" + Pid(), "[Goods007]");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ac.bind_repeater(ds, rptProduct, "Goods007 desc", tr1);
                }
                else {
                    Response.Redirect("tuangou.aspx");
                }
            }
            else
            {
                Response.Redirect("tuangou.aspx");
            }
        }

        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //LinkButton btn = e.Item.FindControl("JS_bnr_state") as LinkButton;
            //btn.Click += new EventHandler(btn_Click);
        }

       
    }
}