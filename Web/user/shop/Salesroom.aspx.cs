using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;
using System.Text;

namespace Web.user.shop
{
    public partial class Salesroom : AllCore//PageCore
    {
        public string cnen = "zh-cn";

        protected void Page_Load(object sender, EventArgs e)
        {
            cnen = GetLanguage("LoginLable");
            AspNetPager1.FirstPageText = GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");

            if (!IsPostBack)
            {
                //竞拍
                gp_opBLL.ExecProc("proc_salesroom");
               ShopHead1.Url = "auction";
               bind(); 
            }
        }

        private void bind()
        {
            DataSet ds = new DataSet();
            int type = GetInt("type",0);
            string where = " SaState =1 and SaBeginTime>=GETDATE()";//（0下架，1上架，2已成交，3已失败）
            if (type > 0)
            {
                where += " and SaTypeID="+type;
            }
            ds = tb_SalesroomBll.GetList(where);

            bind_repeater(ds, Repeater1, "SaAddTime desc", null, AspNetPager1);
        }

        /// <summary>
        /// 获取地址栏参数,且转换为整数型
        /// </summary>
        /// <param name="query"></param>
        /// <param name="ndefault"></param>
        /// <returns></returns>
        public int GetInt(string query, int ndefault)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request[query]))
            {
                return ToInt(ReplaceValue(HttpContext.Current.Request[query]), ndefault);
            }
            return ndefault;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
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

        /// <summary>
        /// 倒计时
        /// </summary>
        /// <param name="id"></param>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public string CountDown(int id,DateTime beginTime)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"countDown count" + id + "\"><span></span>天<span></span>时<span></span>分<span></span>秒</div>");
            string year, month, day, Hour, Minute, Second;
            year = beginTime.Year.ToString();
            month = beginTime.Month.ToString();
            day=beginTime.Day.ToString();
            Hour = beginTime.Hour.ToString();
            Minute = beginTime.Minute.ToString();
            Second = beginTime.Second.ToString();
            sb.Append("<script>$(function(){  ");
            sb.Append(" var tYear = \"\"; ");
            sb.Append(" var tMonth = \"\"; ");
            sb.Append(" var tDate = \"\";");
            sb.Append(" var tHour = \"\";  ");
            sb.Append(" var tMinute = \"\"; ");
            sb.Append(" var tSecond = \"\"; ");

            sb.Append(" var iRemain = \"\"; ");
            sb.Append(" var sDate = \"\"; ");
            sb.Append(" var sHour = \"\";");
            sb.Append(" var sMin = \"\";  ");
            sb.Append(" var sSec = \"\"; ");
            sb.Append(" var sMsec = \"\"; ");

            sb.Append("function setDig(num, n) {");
            sb.Append("var str = \"\" + num;");
            sb.Append(" while (str.length < n) {");
            sb.Append("str = \"0\" + str}");
            sb.Append("return str;}");

            sb.Append("function getdate(year, month, date, Hour, Minute, Second) {");
            sb.Append("var oStartDate = new Date();var oEndDate = new Date();");
            sb.Append("tYear = year;tMonth = month;tDate = date;");
            sb.Append(" tHour = Hour;tMinute = Minute;tSecond = Second;");
            sb.Append("oEndDate.setFullYear(parseInt(tYear));oEndDate.setMonth(parseInt(tMonth) - 1);oEndDate.setDate(parseInt(tDate));");
            sb.Append("oEndDate.setHours(parseInt(tHour));oEndDate.setMinutes(parseInt(tMinute));oEndDate.setSeconds(parseInt(tSecond));");
            sb.Append("iRemain = (oEndDate.getTime() - oStartDate.getTime()) / 1000;sDate = setDig(parseInt(iRemain / (60 * 60 * 24)), 3); iRemain %= 60 * 60 * 24;");
            sb.Append("sHour = setDig(parseInt(iRemain / (60 * 60)), 2);iRemain %= 60 * 60;sMin = setDig(parseInt(iRemain / 60), 2);");
            sb.Append("iRemain %= 60;sSec = setDig(iRemain, 2);sMsec = sSec * 100;}");
           
            sb.Append("function updateShow(id) {");
            sb.Append("$(\".count\" + id + \" span\").each(function (index, element) {");
            sb.Append("if (index == 0) {$(this).text(sDate);} else if (index == 1) {$(this).text(sHour); } else if (index == 2) {");
            sb.Append("$(this).text(sMin);} else if (index == 3) {$(this).text(sSec);}});}");

            sb.Append("function autoTime() {");
            sb.Append("getdate('" + year + "','" + month + "','" + day + "','" + Hour + "','" + Minute + "','" + Second + "');");
            sb.Append(" if (iRemain < 0) {");
            sb.Append(" clearTimeout(setT);return; }");
            sb.Append(" updateShow('"+id+"');");
            sb.Append("var setT = setTimeout(autoTime, 1000);}");
            sb.Append("autoTime();})</script>");
            //sb.Append("autoTime('" + year + "','" + month + "','" + day + "','" + Hour + "','" + Minute + "','" + Second + "','" + id + "');})</script>");
            return sb.ToString();
        }
    }
}