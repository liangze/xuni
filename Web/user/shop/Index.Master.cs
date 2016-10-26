using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Library;
namespace Web.user.shop
{
    public partial class Index : System.Web.UI.MasterPage
    {
      //  private string City = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {   lgk.BLL.tb_systemMoney smoneyBLL = new lgk.BLL.tb_systemMoney();
        //lgk.Model.tb_systemMoney modermoney = smoneyBLL.GetModel(1);
        // Label_cisan.Text = modermoney.Money001.ToString();
            IList<lgk.Model.tb_produceType> ddlList = new lgk.BLL.tb_produceType().GetModelList(" ParentID = 0");
            if (ddlList != null)
            {
                //if (Request["city"] != null)
                //{
                //    City = Request["city"].ToString();

                //}
                //else
                //{
                //    string ip = HttpContext.Current.Request.UserHostAddress;
                //    City = GetCityFromIP(ip);
                //}
                //City = GetCityFromName(City);

                //HttpCookie cookie = new HttpCookie("region_name");
                //cookie.Value = Server.UrlEncode(Request.Cookies["region_name"].Value);// 
                //Response.AppendCookie(cookie);

                RepeaterChannel.DataSource = ddlList;
                RepeaterChannel.DataBind();


               
            }

            if (getLoginId() > 0) {

                lgk.BLL.tb_goodsCar car = new lgk.BLL.tb_goodsCar();
               DataSet ds=  car.GetList("BuyUser=" + getLoginId());
               lblCar.Text = ds.Tables[0].Rows.Count.ToString();
               hiddeName.Value = "1";
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

        /// <summary>
        /// 获取当前登录UserCode ID
        /// </summary>
        /// <returns></returns>
        public int  getLoginId()
        {
            if (Request.Cookies["A128076_user"] != null)
            {
                return Convert.ToInt32( Request.Cookies["A128076_user"]["Id"]);
            }
            else
            {
                return 0;
            }
        }
    }
}