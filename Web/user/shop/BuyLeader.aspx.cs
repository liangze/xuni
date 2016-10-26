using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Library;

namespace Web.user.shop
{
    public partial class BuyLeader : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData("3");
            }
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        protected void BindData(string id)
        {
            lgk.Model.tb_news newInfo = newsBLL.GetModel(Convert.ToInt64(id));
            if (newInfo == null)
            {
                //lblTitle.Visible = false;
                //lblDate.Visible = false;
                //lbPublisher.Visible = false;
                lilContent.Text = "暂无数据";
            }
            else
            {
                //lblTitle.Text = newInfo.NewsTitle;
                //lblDate.Text = newInfo.PublishTime.ToString("yyyy-MM-dd HH:mm:ss");
                //lbPublisher.Text = newInfo.Publisher;
                lilContent.Text = newInfo.NewsContent;
            }
        }
    }
}