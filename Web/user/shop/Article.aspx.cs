using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.shop
{
    public partial class Article : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    BindData(id);
                    BindColumns();
                }
            }
        }

        private void BindColumns()
        { 
            List<lgk.Model.tb_news> about = new lgk.BLL.tb_news().GetModelList(" NewsType = 7");
            List<lgk.Model.tb_news> guide = new lgk.BLL.tb_news().GetModelList(" NewsType = 8");
            List<lgk.Model.tb_news> build = new lgk.BLL.tb_news().GetModelList(" NewsType = 9");
            List<lgk.Model.tb_news> service = new lgk.BLL.tb_news().GetModelList(" NewsType = 10");
            List<lgk.Model.tb_news> security = new lgk.BLL.tb_news().GetModelList(" NewsType = 11");
            //关于
            RepeaterBind(Repeater_About,about);
            //新手指南
            RepeaterBind(Repeater_Guide,guide);
            //配送安装
            RepeaterBind(Repeater_Build, build);
            //售后服务
            RepeaterBind(Repeater_Service, service);
            //购物保障
            RepeaterBind(Repeater_security, security);
        }

        private void RepeaterBind(Repeater rp,List<lgk.Model.tb_news> ds)
        {
            rp.DataSource = ds;
            rp.DataBind();
        }

        private void BindData(int id)
        {
            lgk.Model.tb_news ddl = new lgk.BLL.tb_news().GetModel(id);

            if (ddl != null)
            {
                lbTitle.Text = ddl.NewsTitle;
                lilContent.Text = ddl.NewsContent;
            }
        }
    }
}