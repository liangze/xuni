/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-7-15 11:46:51 
 * 文 件 名：		MemberList.cs 
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
using System.Data;

namespace Web.user.team
{
    public partial class MemberList : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();

                btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

        /// <summary>
        ///查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strStart = txtStart.Text.Trim();
            string strEnd = txtEnd.Text.Trim();

            string strWhere = "IsOpend = 2";

            if (LoginUser.IsAgent == 1)
                strWhere += " AND AgentsID=" + Loginagent.ID + "";
            else
                strWhere += " AND (RecommendID = " + LoginUser.UserID + " OR RecommendPath LIKE '%" + LoginUser.RecommendPath + "-')";

            #region 会员编号姓名

            strWhere += " AND UserCode LIKE  '%" + this.txtUserCode.Value.Trim() + "%'";

            #endregion

            if (GetLanguage("LoginLable") == "en-us")
            {
                strStart = txtStartEn.Text.Trim();
                strEnd = txtEndEn.Text.Trim();
            }

            #region 开通时间
            if (strStart != "" && strEnd == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) BETWEEN '" + strStart + "' AND '" + strEnd + "'");
            }
            #endregion

            return strWhere;
        }

        /// <summary>
        /// 绑定已开通会员列表
        /// </summary>
        private void BindData()
        {
            bind_repeater(userBLL.GetOpenList(GetWhere()), Repeater1, "OpenTime desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 搜索提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 分页提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
