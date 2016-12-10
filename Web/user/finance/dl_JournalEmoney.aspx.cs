/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-6-8 18:02:38 
 * 文 件 名：		dl_JournalEmoney.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 備注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.finance
{
    public partial class dl_JournalEmoney : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCurrency();
                BindData();
                btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

        /// <summary>
        /// 绑定币种
        /// </summary>
        public void BindCurrency()
        {
            
            //journalType: 1、注册积分，2、奖金积分，3、电子积分，4、云商积分，5、感恩积分，6、购物积分，7、消费积分，8、爱心基金，9、云购积分
            dropCurrency.Items.Add(new ListItem("-请选择-", "0"));
            dropCurrency.Items.Add(new ListItem("注册积分", "1"));
            dropCurrency.Items.Add(new ListItem("奖金积分", "2"));
            dropCurrency.Items.Add(new ListItem("电子积分", "3"));
            dropCurrency.Items.Add(new ListItem("云商积分", "4"));
            dropCurrency.Items.Add(new ListItem("感恩积分", "5"));
            dropCurrency.Items.Add(new ListItem("购物积分", "6"));
            dropCurrency.Items.Add(new ListItem("消费积分", "7"));
            dropCurrency.Items.Add(new ListItem("爱心基金", "8"));
            dropCurrency.Items.Add(new ListItem("云购积分", "8"));

            
        }

        private void BindData()
        {
            bind_repeater(journalBLL.GetList(GetWhere()), Repeater1, "id desc", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
            string strWhere = string.Format("u.UserID=" + getLoginID());

            if (dropCurrency.SelectedValue != "0")
            {
                strWhere += " AND j.JournalType=" + dropCurrency.SelectedValue + "";
            }

            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();
            if (GetLanguage("LoginLable") == "en-us")
            {
                strStartTime = this.txtStartEn.Text.Trim();
                strEndTime = this.txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),j.JournalDate,120) >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),j.JournalDate,120) <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),j.JournalDate,120) between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
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
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("dl_JournalAccount.aspx");
        }
    }
}