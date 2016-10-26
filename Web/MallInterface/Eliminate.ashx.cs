using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Web.MallInterface
{
    /// <summary>
    /// Eliminate 的摘要说明
    /// </summary>
    public class Eliminate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string json = String.Empty;
            string message = string.Empty;
            bool result = false;

            using (var reader = new StreamReader(context.Request.InputStream))
            {
                json = reader.ReadToEnd();
            }

            if (!string.IsNullOrEmpty(json) || json.Trim() != string.Empty)
            {
                AllCore core = new AllCore();
                string eliminate = context.Request.Form["Eliminate"].ToString();
                if (!string.IsNullOrEmpty(eliminate))
                {
                    if (core.ClearDataBase() > 0)
                    {
                        result = true;
                        message = "清除成功";
                    }
                    else
                    {
                        message = "清除失败";
                    }
                }
                else
                {
                    message = "传递数据为空";
                }
            }
            SendResponse(context, result, message);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void SendResponse(HttpContext context, bool result, string returnString)
        {
            context.Response.Clear();
            string json = "[{\"status\":\"" + result.ToString().ToLower() + "\",\"message\":\"" + returnString + "\"}]";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.Serialize(json);
            context.Response.Write(json);
            context.Response.End();
        }
    }
}