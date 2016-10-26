/*********************************************************************************
*Copyright(c) 	2012 ZXHLRJ.COM
 * �������ڣ�		2012-5-8 10:48:21
 * �� �� ����		Business.cs
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
using BLL;
using System.Data;
using Library;

namespace web.user.member
{
    public partial class Business : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// �����Ϣ
        /// </summary>
        protected void BindData()
        {
            bind_repeater(newsBLL.GetList("NewType=2"), rpBusiness, "Click desc,PublishTime desc", divNull, anpBusiness);
        }

        protected void anpGoods_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
