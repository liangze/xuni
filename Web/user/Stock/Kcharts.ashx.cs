using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Tradinghall.Ajax
{
    /// <summary>
    /// Kcharts 的摘要说明
    /// </summary>
    public class Kcharts : IHttpHandler
    {
        DataSet ds = new DataSet();
        JavaScriptSerializer jsS = new JavaScriptSerializer();
        List<object> lists = new List<object>();
        string result = "";

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string itype = context.Request["type"];
            string ineed = context.Request["need"].ToString();
            int a = 0;
            if (!string.IsNullOrEmpty(ineed))
            {
                a = Convert.ToInt32(ineed);
            }

            if (!string.IsNullOrEmpty(itype))
            {
                switch (itype)
                {
                    case "line":
                        GetLine(context, a);
                        break;
                    case "k":
                        GetK(context, a);
                        break;
                }
            }
        }

        #region K线图
        /// <summary>
        /// K线图
        /// </summary>
        /// <param name="context"></param>
        public void GetK(HttpContext context, int iTime)
        {
            lgk.BLL.Cashorder co = new lgk.BLL.Cashorder();

            string str = "";
            int iType = 0;//类型--1：分钟，2：小时，3：天
            int a = 0;
            if (iTime == 0)//默认1小时
            {
                iType = 1;
                a = 60;
            }
            else if (iTime == 1)//5分钟
            {
                iType = 1;
                a = 5;
            }
            else if (iTime == 2)//15分钟
            {
                iType = 1;
                a = 15;
            }
            else if (iTime == 3)//30分鬃
            {
                iType = 1;
                a = 30;
            }
            else if (iTime == 4)//1小时
            {
                iType = 1;
                a = 60;
            }
            else if (iTime == 5)//1天
            {
                iType = 3;
                a = 1;
            }
            else if (iTime == 6)//1月
            {
                iType = 3;
                a = 30;
            }
            if (iType == 1)
            {
                ds = co.GetMimuteChart(a);
            }
            else if (iType == 2)
            {
                ds = co.GetHourChart(a);
            }
            else if (iType == 3)
            {
                ds = co.GetDayChart(a);
            }
            lists = new List<object>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string showtime = dr["showtime"].ToString();//时间
                // 开盘，收盘，最低，最高
                string strOpenprice = co.GetOpenPrice(showtime, a, iType).ToString();
                string strCloseprice = co.GetClosePrice(showtime, a, iType).ToString();
                string strMaxprice = dr["maxprice"].ToString(); //最高价格
                string strMinprice = dr["minprice"].ToString();//最低价格

                Array ary = new string[] { strOpenprice, strCloseprice, strMinprice, strMaxprice };

                decimal totalmoney = co.GetSumAmount(showtime, a, iType);

                var obj = new { name = showtime, value = ary, mvalue = totalmoney };//
                lists.Add(obj);
            }
            jsS = new JavaScriptSerializer();
            result = jsS.Serialize(lists);
            context.Response.Write(result);
        } 
        #endregion

        #region 折线图
        /// <summary>
        /// 折线图
        /// </summary>
        /// <param name="context"></param>
        public void GetLine(HttpContext context, int iTime)
        {
            lgk.BLL.Cashorder co = new lgk.BLL.Cashorder();
            string str = "";
            if (iTime == 0)//默认1小时
            {
                str = " datediff(day,o.OrderDate,getdate())=0";
            }
            if (iTime == 1)//5分钟
            {
                str = " datediff(minute,o.OrderDate,getdate())<=5";
            }
            else if (iTime == 2)//15分钟
            {
                str = " datediff(minute,o.OrderDate,getdate())<=15";
            }
            else if (iTime == 3)//30分鬃
            {
                str = " datediff(minute,o.OrderDate,getdate())<=30";
            }
            else if (iTime == 4)//1小时
            {
                str = " datediff(minute,o.OrderDate,getdate())<=60";
            }
            else if (iTime == 5)//1天
            {
                str = " datediff(day,o.OrderDate,getdate())=0";
            }
            else if (iTime == 6)//1月
            {
                str = " datediff(month,o.OrderDate,getdate())=0";
            }
            str += " ";
            ds = co.GetMimuteChart(5);
            lists = new List<object>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string showtime = dr["showtime"].ToString();//时间
                string strprice = dr["maxprice"].ToString(); //最高价格
                string strnum = dr["minprice"].ToString();//最低价格

                // 数量,价格，会员编号，
                //Array ary = new string[] { strnum, strprice, strucode, ordertime };
                //var obj = new { name = dr["Price"].ToString(), value = dr["Number"].ToString(), mvalue = ary, time = ordertime };//
                //lists.Add(obj);
            }

            jsS = new JavaScriptSerializer();
            result = jsS.Serialize(lists);
            context.Response.Write(result);
        } 
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}