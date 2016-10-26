/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-19 11:10:39 
 * 文 件 名：		jiaoyipan.cs 
 * CLR 版本: 		2.0.50727.3053 
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
using DataAccess;
using System.Data;

namespace Web.user.licai
{
    public partial class jiaoyipan : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindBase();
                bindMaiRu();
                bindMaiChu();
                BindLoginMessage();
            }
        }

        /// <summary>
        /// 欢迎信息
        /// </summary>
        public void BindLoginMessage()
        {
            //this.lbl_uname.Text = us.GetUserCode(getLoginID());
            //this.lbl_times.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Today.ToString("dddd", new System.Globalization.CultureInfo("zh-CN"));
            //this.lbl_ip.Text = Page.Request.UserHostAddress;
        }
        /// <summary>
        /// 其他信息
        /// </summary>
        private void bindBase()
        {
            //我的股票信息
            //decimal dai = Convert.ToDecimal(bn.GetNum(1, 1, 1, getLoginID()));
            //this.Label3.Text = dai.ToString();
            //lgk.Model.tb_user user = us.GetModel(getLoginID());
            //this.Label2.Text = (user.Lmoney + dai).ToString();
            //this.Label4.Text = user.Lmoney.ToString();
            //lbl_ucode.Text = user.UserCode;
            ///最近交易的一条记录
            string sql = "select top 1 id from gp_BusinessNotes where status = 2 order by BusinessTime desc ";
            lgk.Model.gp_BusinessNotes note = gp_notesBLL.GetModel(Convert.ToInt32(DbHelperSQL.GetSingle(sql)));
            if (note == null)
            {
                this.lbl_mai1.Text = "无";
                this.lbl_mai2.Text = "无";
                this.lbl_amount.Text = "0.00";
                this.lbl_num.Text = "0";
                this.lbl_time.Text = "时间";
            }
            else
            {
                if (note.BusinessType == 1)
                {
                    this.lbl_mai1.Text = note.FromUserCode.ToString();
                    this.lbl_mai2.Text = note.UserCode.ToString();
                }
                if (note.BusinessType == 2)
                {
                    this.lbl_mai1.Text = note.UserCode.ToString();
                    this.lbl_mai2.Text = note.FromUserCode.ToString();
                }
                this.lbl_amount.Text = note.BusinessPrice.ToString();
                this.lbl_num.Text = note.BusinessAmount.ToString();
                this.lbl_time.Text = note.BusinessTime.ToString();
            }
        }
        /// <summary>
        /// 系统待卖出记录
        /// </summary>
        private void bindMaiChu()
        {
            string strWhere = string.Format(" BusinessType = 1 and status = 1 ");
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater3, "BusinessPrice asc,BusinessTime asc", tr3, AspNetPager3);
        }
        /// <summary>
        /// 系统待买入记录
        /// </summary>
        private void bindMaiRu()
        {
            string strWhere = string.Format(" BusinessType = 2 and status = 1 ");
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater1, "BusinessPrice asc,BusinessTime asc", tr1, AspNetPager1);
        }


        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bindMaiRu();
        }
        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            bindMaiChu();
        }
    }
}
