/*********************************************************************************
* Copyright(c)  	2011 ZXHLRJ.COM
 * 创建日期：		2011-12-26 9:52:23 
 * 文 件 名：		OrderFail.cs 
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
    /// 交易失败页面
    /// </summary>
    public partial class OrderFail : System.Web.UI.Page
    {
        public string ErrorResult { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorResult += string.Format("<div> 编号:{0} </div>",Request["billno"]);
            ErrorResult += string.Format("<div> 时间:{0} </div>", Request["date"]);
            ErrorResult += string.Format("<div> 币种:{0} </div>", Request["Currency_type"]);
            ErrorResult += string.Format("<div> 金额:{0} </div>", Request["amount"]);
            ErrorResult += string.Format("<div> 附加:{0} </div>", Request["attach"]);
        }
    }
}
