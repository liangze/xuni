/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-12-24 15:49:19 
 * 文 件 名：		index.cs 
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

namespace Web.user.shop
{
    public partial class index : AllCore//PageCore//System.Web.UI.Page
    {
        protected string imgstr = "";
        public string cnen = "en-us";
        int PhoneRechargeType = 0;
        protected void Page_Load(object sender, EventArgs e)
        {            
            cnen = GetLanguage("LoginLable");  
            if (!IsPostBack)
            {
                if (Request["lan"] != null)
                {
                    HttpCookie CultureCookie = new HttpCookie("Culture");
                    CultureCookie.Value = Request["lan"].ToString();
                    Response.Cookies.Add(CultureCookie);
                    Response.Redirect("index.aspx");
                }

                var prtype = produceTypeBLL.GetList(" TypeName='话费充值'");
                if (prtype.Tables[0].Rows.Count > 0)
                {
                    PhoneRechargeType = Convert.ToInt32(prtype.Tables[0].Rows[0]["ID"]);//一级分类
                }

                ShopHead1.Url = "index";
                bind();

                
              //  BindProductType(produceTypeBLL.GetList(" ParentID=1"), Repeater_ProductParent);
            }

            //焦点图
            DataTable dt = new lgk.BLL.tb_Link().GetList(5, " Link001=3 ", "Status desc").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                imgstr += "<item><img>../../upload/" + dr["LinkImage"] + "</img><url></url></item>";
            }
        }
        private void bind()
        {
            Repeater1.DataSource = goodsBLL.GetList(5, string.Format(" TypeID != {0} ",PhoneRechargeType), " AddTime desc");
            Repeater1.DataBind();
        }
    }
}
