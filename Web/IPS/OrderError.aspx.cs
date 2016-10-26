/*********************************************************************************
* Copyright(c)  	2011 ZXHLRJ.COM
 * 创建日期：		2011-12-26 9:52:39 
 * 文 件 名：		OrderError.cs 
 * CLR 版本: 		2.0.50727.3625 
 * 创 建 人：		黄炳仪
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThirdPartyPaymentExample.IPS
{
    /// <summary>
    /// 交易错误页面
    /// </summary>
    public partial class OrderError : System.Web.UI.Page
    {
        public string FailResult { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FailResult += string.Format("<div>错误代码:{0} </div>",Request["errCode"]);
        }
    }
}
