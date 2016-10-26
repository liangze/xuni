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
    /// Refund 的摘要说明
    /// </summary>
    public class Refund : IHttpHandler
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
                string key = context.Request.Form["Key"].ToString();
                string str1 = PageValidate.GetMd5("HongBao").ToLower();
                string str2 = PageValidate.GetMd5(str1).ToLower();
                if (key.Equals(str2))
                {
                    string ordercode = context.Request.Form["OrderCode"].ToString();
                    int orderflag = Convert.ToInt32(context.Request.Form["OrderFlag"].ToString());
                    DateTime refundtime = Convert.ToDateTime(context.Request.Form["RefundTime"].ToString());

                    string t = string.Format("ordercode:{0}, orderflag:{1}, refundtime:{2}", ordercode, orderflag, refundtime);
                    System.IO.File.AppendAllText(context.Server.MapPath("~/log12.txt"), t);

                    if (!string.IsNullOrEmpty(ordercode))
                    {
                        lgk.BLL.tb_UserOrder userOrderBLL = new lgk.BLL.tb_UserOrder();

                        lgk.Model.tb_UserOrder orderModel = userOrderBLL.GetModel(" OrderCode='" + ordercode + "'");
                        if (orderModel != null)
                        {
                            orderModel.Flag = orderflag;
                            if (orderflag == 1)//申请
                            {
                                orderModel.ApplyTime = refundtime;
                            }
                            else//完成（2：失败，3：成功）
                            {
                                orderModel.FinishTime = refundtime;
                            }

                            if (userOrderBLL.Update(orderModel))
                            {
                                result = true;
                                message = "操作成功";
                            }
                            else
                            {
                                message = "操作异常";
                            }
                        }
                        else
                        {
                            message = "此订单编号不存在";
                        }
                    }
                    else
                    {
                        message = "订单编号数据为空";
                    }
                }
                else
                {
                    message = "验证出错";
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