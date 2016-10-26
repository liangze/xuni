/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-12-24 17:11:41 
 * 文 件 名：		shop.cs 
 * CLR 版本: 		2.0.50727.3643 
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

namespace Web.user.shop
{
    public partial class shop : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected string getWhere()
        {
            string where = " Goods001=1 ";
            if (getIntRequest("type") != 0)
            {
                where += " and GoodsType=" + getIntRequest("type");
            }
            if (txtGoodName.Value.Trim() != "")
            {
                where += " and GoodsName like  '%" + this.txtGoodName.Value.Trim() + "%'";
            }
            if (txtPriceStar.Value.Trim() != "")
            {
                try
                {
                    decimal price = Convert.ToDecimal(txtPriceStar.Value.Trim());
                    where += " and Price>=" + price;
                }
                catch
                {
                    where += "";
                }
            }
            if (txtPriceEnd.Value.Trim() != "")
            {
                try
                {
                    decimal price = Convert.ToDecimal(txtPriceEnd.Value.Trim());
                    where += " and Price<=" + price;
                }
                catch
                {
                    where += "";
                }
            }
            return where;
        }
        private void bind()
        {
            bind_repeater(goodsBLL.GetList(getWhere()), Repeater1, "AddTime desc", null, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

    }
}
