/*********************************************************************************
*Copyright(c) 	2012 ZXHLRJ.COM
 * �������ڣ�		2012-5-8 17:46:07
 * �� �� ����		BusinessDetail.cs
 * CLR �汾:		2.0.50727.3053
 * �� �� �ˣ�		
 * �ļ��汾��		1.0.0.0
 * �� �� �ˣ� 
 * �޸����ڣ� 
 * ��ע������ 
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace web.user.member
{
    public partial class BusinessDetail : PageCore//System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                BindData(Request.QueryString["id"]);
            }
        }
        /// <summary>
        /// �������
        /// </summary>
        protected void BindData(string id)
        {
            lgk.Model.tb_news newInfo = newsBLL.GetModel(Convert.ToInt64(id));
            lblTitle.Text = newInfo.NewsTitle;
            lblAuthor.Text = newInfo.Publisher;
            lblDate.Text = newInfo.PublishTime.ToString("yyyy-MM-dd HH:mm:ss");
            lilContent.Text = newInfo.NewsContent;
            newInfo.Click += 1;
            newsBLL.Update(newInfo);
        }
        
    }
}
