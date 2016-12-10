/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-5-16 11:51:31 
 * 文 件 名：		index.cs 
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

namespace Web.user
{
    public partial class index : PageCore
    {
        public decimal tixian { get; set; }
        public decimal shuanggui { get; set; }
        public decimal zhitui { get; set; }
        public decimal chongzhi { get; set; }
        protected string strUrl = "default.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
              tixian =  getParamAmount("tixiankai");
              shuanggui = getParamAmount("shuanggui");
              zhitui = getParamAmount("zhitui");
            chongzhi = getParamAmount("chongzhi");
        }

        private void bind()
        {
            //
        }

    }
}