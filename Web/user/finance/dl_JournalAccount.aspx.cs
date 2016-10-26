/*********************************************************************************
*Copyright(c) 	2012 ZXHLRJ.COM
 * �������ڣ�		2012-6-6 16:01:41
 * �� �� ����		dl_JournalAccount.cs
 * CLR �汾:		2.0.50727.3053
 * �� �� �ˣ�		
 * �ļ��汾��		1.0.0.0
 * �� �� �ˣ� 
 * �޸����ڣ� 
 * ��ע������ 
**********************************************************************************/
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;

namespace Web.user.finance
{
    public partial class dl_JournalAccount : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//��ת�����ܴa

            if (!IsPostBack)
            {
                txtBonusAccount.Value = LoginUser.BonusAccount.ToString();
                txtEmoney.Value = LoginUser.Emoney.ToString();
                txtStockMoney.Value = LoginUser.StockMoney.ToString();
                txtShopAccount.Value = LoginUser.ShopAccount.ToString();
                txtStockAccount.Value = LoginUser.StockAccount.ToString();

                BindData();
                btnDetail.Text = GetLanguage("DetailAccount"); //"Ӷ�����ϸ"
                //btnSearch.Text = GetLanguage("Search");//����
            }
        }

        private void BindData()
        {
            bind_repeater(journalBLL.GetList(" u.UserID=" + getLoginID()), Repeater1, "id desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// �鿴�ֽ����ϸ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("dl_JournalEmoney.aspx");
        }
    }
}
