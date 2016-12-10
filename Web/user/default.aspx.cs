/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-7-16 17:43:01 
 * 文 件 名：		@default.cs 
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

namespace Web.user
{
    public partial class _default : PageCore
    {
        public int dengji { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                BindData();
                 string sql = "select * from tb_agent1 where userid="+getLoginID()+ " order by AgentType desc ";
                DataTable dt = userBLL.getData_Chaxun(sql,"").Tables[0];
                if (dt.Rows.Count>0)
                {
                    dengji = int.Parse(dt.Rows[0]["AgentType"].ToString());
                }
                else
                {
                    dengji = 0;
                }
             

                
            }
        }

        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "1=1";
            return strWhere;
        }

        /// <summary>
        /// 填充信息
        /// </summary>
        protected void BindData()
        {
            bind_repeater(newsBLL.GetList(GetWhere()), Repeater1, "PublishTime desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

    }
}
