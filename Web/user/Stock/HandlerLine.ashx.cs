using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Web.user.Stock
{
    /// <summary>
    /// HandlerLine 的摘要说明
    /// </summary>
    public class HandlerLine : IHttpHandler
    {
        DataSet ds = new DataSet();
        JavaScriptSerializer jsS = new JavaScriptSerializer();

        List<object> lists = new List<object>();

        string result = "";

        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request["type"];

            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "line":
                        GetLine(context);
                        break;
                }
            }
        }

        public void GetLine(HttpContext context)
        {
            lgk.BLL.tb_Stock stockBLL = new lgk.BLL.tb_Stock();
            ds = stockBLL.GetList("CONVERT(VARCHAR(19),BuyDate,120) <= CONVERT(VARCHAR(19),GETDATE(),120) group by CONVERT(VARCHAR(19),BuyDate,120) ", "CONVERT(VARCHAR(19),BuyDate,120)");
            lists = new List<object>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var obj = new { name = dr["cd"], value = dr["sp"] };
                lists.Add(obj);
            }

            jsS = new JavaScriptSerializer();
            result = jsS.Serialize(lists);
            context.Response.Write(result);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}