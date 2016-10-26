using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.shop
{
    public partial class channel : AllCore//PageCore
    {
        public int payment = 0;
        public string cnen = "zh-cn";

        protected void Page_Load(object sender, EventArgs e)
        {
            payment = Convert.ToInt32(Request["payment"]);
            cnen = GetLanguage("LoginLable");

            btnSearch.Text = GetLanguage("Search");
            AspNetPager1.FirstPageText = GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");

            if (!IsPostBack)
            {
               int type=GetInt("type",0);
               switch (type)
               {
                   case 1: //男人
                       ShopHead1.Url = "man";
                       break;
                   case 36://女人
                       ShopHead1.Url = "woman";
                       break;
                   case 37://东方奢侈品
                       ShopHead1.Url = "east";
                       break;
                   case 38://积分兑购
                       ShopHead1.Url = "swap";
                       break;
                   default: 
                       ShopHead1.Url = "man"; 
                       break;
               }
               int typeid = GetInt("typeid", 0);
               bind(); 
            }
        }

        protected string getWhere()
        {
            string where = " Goods001=1 ";
            int typeid = getIntRequest("type");
            if (typeid != 0)
            {
                where += " and typeid=" + typeid;//查找某一大类商品（一级分类）
            }
            int goodtype = getIntRequest("goodtype");
            if (goodtype != 0)
            {
                where += " and GoodsType=" + goodtype;//查找某一小类商品（二级分类）
            }
            if (txtGoodName.Value.Trim() != "")
            {
                where += " and GoodsName like  '%" + this.txtGoodName.Value.Trim() + "%'";
            }
            if (txtPriceStar.Value.Trim() != "")
            {
                decimal price = Convert.ToDecimal(txtPriceStar.Value.Trim());
                where += " and Price>=" + price;
            }
            if (txtPriceEnd.Value.Trim() != "")
            {
                decimal price = Convert.ToDecimal(txtPriceEnd.Value.Trim());
                where += " and Price<=" + price;
            }
            return where;
        }

        private void bind()
        {
            if (txtPriceStar.Value.Trim().Length > 0)
            {
                if (!PageValidate.IsNumber(txtPriceStar.Value.Trim()))
                {
                    MessageBox.Show(this.Page, "商品价格请输入数字!"); return;
                }
            }
            if (txtPriceEnd.Value.Trim().Length > 0)
            {
                if (!PageValidate.IsNumber(txtPriceEnd.Value.Trim()))
                {
                    MessageBox.Show(this.Page, "商品价格请输入数字!"); return;
                }
            }
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

        /// <summary>
        /// 获取地址栏参数,且转换为整数型
        /// </summary>
        /// <param name="query"></param>
        /// <param name="ndefault"></param>
        /// <returns></returns>
        public static int GetInt(string query, int ndefault)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request[query]))
            {
                return ToInt(ReplaceValue(HttpContext.Current.Request[query]), ndefault);
            }
            return ndefault;
        }

        private static string ReplaceValue(string value)
        {
            int index = value.IndexOf(",", StringComparison.Ordinal);
            if (index > 0)
            {
                return value.Substring(0, index);
            }
            if (index == 0)
            {
                return "";
            }
            return value;
        }

        /// <summary>
        /// 字符串转换为32位长整型
        /// </summary>
        /// <param name="Value"> 需要转换的字符串 </param>
        /// <param name="DefaultValue"> 默认值 </param>
        /// <returns> 32位长整型值 </returns>
        public static int ToInt(string Value, int DefaultValue)
        {
            int Result = DefaultValue;

            try
            {
                Result = Convert.ToInt32(Value);
            }
            catch { }

            return Result;
        }

    }
}