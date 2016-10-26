using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using lgk.BLL;
using Library;

namespace Web.user.shop
{
    public partial class Default1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lgk.BLL.tb_Link link = new lgk.BLL.tb_Link();
                AllCore ac = new AllCore();
               // ac.bind_repeater(link.GetList(27, "Link001=1", "Status"), Repeater1, "Status", null);
                ac.bind_repeater(link.GetList(5, "Link001=3", "Status"), Repeater2, "Status", null);//首页图片5张
                cishan();
                BindColumns();
            }
            IList<lgk.Model.tb_produceType> ddlList = new lgk.BLL.tb_produceType().GetModelList2(5, "parentID=0 and Type01 = 0", "ID asc ");
            IList<lgk.Model.tb_produceType> ddlList2 = new lgk.BLL.tb_produceType().GetModelList("ParentID=0 and Type01 = 0");
            if (ddlList != null)
            {
                RepeaterChannel.DataSource = ddlList2;
                RepeaterChannel.DataBind();
                this.Repeater3.DataSource = ddlList;
                this.Repeater3.DataBind();

                lgk.BLL.tb_produceType gp = new lgk.BLL.tb_produceType();

            }
            if (getLoginId() > 0)
            {
                lgk.BLL.tb_goodsCar car = new lgk.BLL.tb_goodsCar();
                DataSet ds = car.GetList("BuyUser=" + getLoginId());
                lblCar.Text = ds.Tables[0].Rows.Count.ToString();
                hiddeName.Value = "1";
            }

            BindGongGaoData();
        }
        public void cishan()
        {
            lgk.BLL.tb_systemMoney modre = new tb_systemMoney();
            lgk.Model.tb_systemMoney mdoer = modre.GetModel(1);
            //lblFundCisan.Text = mdoer.Money001.ToString();

        }
        private void BindColumns()
        {
            //关于
            RepeaterBind(Repeater_About, 6);
            //新手指南
            RepeaterBind(Repeater_Guide, 7);
            //配送安装
            RepeaterBind(Repeater_Build, 8);
            //售后服务
            RepeaterBind(Repeater_Service, 9);
            //购物保障
            RepeaterBind(Repeater_security, 10);
        }

        private void RepeaterBind(Repeater rp, int type )
        {
            List<lgk.Model.tb_news> ds = new lgk.BLL.tb_news().GetModelList("NewType = " + type.ToString());
            rp.DataSource = ds;
            rp.DataBind();
        }

        /// <summary>
        /// 获取当前登录UserCode ID
        /// </summary>
        /// <returns></returns>
        public int getLoginId()
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
        /// 获取当前登录UserCode
        /// </summary>
        /// <returns></returns>
        public string getLoginName()
        {
            if (Request.Cookies["A128076_user"] != null)
            {
                return Request.Cookies["A128076_user"]["name"];
            }
            else
            {
                return "";
            }
        }

        protected string ReturnStr(string obj)
        {

            string str = "";

            if (obj != null)
            {

                return str = "style=\"background: url(../../Upload/" + obj + ") 0 0 repeat-x;\"";
            }
            else
                return str;
        }

        protected string ReturnStrBj(string obj)
        {

            string str = "";

            if (obj != null)
            {

                return str = "style=\"background: url(../../Upload/" + obj + ") center center no-repeat;\"";
            }
            else
                return str;
        }

        protected void rptypelist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater dl = e.Item.FindControl("Repeater4") as Repeater;
                Repeater dl2 = e.Item.FindControl("Repeater5") as Repeater;
                int id = ((lgk.Model.tb_produceType)e.Item.DataItem).ID;
                //Label l = e.Item.FindControl("L1") as Label;
                //   int id = Convert.ToInt32(l.Text);
                //  int id = row.;
                IList<lgk.Model.tb_produceType> ddlList = new lgk.BLL.tb_produceType().GetModelList(" ParentID=" + id);
                IList<lgk.Model.tb_produceType> ddlList2 = new lgk.BLL.tb_produceType().GetModelList(" ParentID=" + id);
                if (dl != null)
                {
                    dl.DataSource = ddlList;
                    dl2.DataSource = ddlList;
                    dl2.DataBind();
                    dl.DataBind();
                }
            }
        }

        /// <summary>
        /// 商城公告
        /// </summary>
        protected void BindGongGaoData()
        {
            AllCore ac = new AllCore();
            ac.bind_repeater(ac.newsBLL.GetList(6, "NewType = 5", "PublishTime desc"), rpNews, "PublishTime desc", trNull);
        }


        protected void rptypelist2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater dl1 = e.Item.FindControl("rpd") as Repeater;
                int id1 = ((lgk.Model.tb_produceType)e.Item.DataItem).ID;
                IList<lgk.Model.tb_produceType> ddlList1 = new lgk.BLL.tb_produceType().GetModelList(" ParentID=" + id1);
                dl1.DataSource = ddlList1;
                dl1.DataBind();
            }
        }
    }
}