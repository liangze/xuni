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
    /// OrderStatus 的摘要说明
    /// </summary>
    public class OrderStatus : IHttpHandler
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

            string t1 = string.Format("数据流:{0}", json);
            System.IO.File.AppendAllText(context.Server.MapPath("~/logOrderStatus.txt"), t1);

            if (!string.IsNullOrEmpty(json) || json.Trim() != string.Empty)
            {
                string key = context.Request.Form["Key"].ToString();
                string str1 = PageValidate.GetMd5("HongBao").ToLower();
                string str2 = PageValidate.GetMd5(str1).ToLower();

                if (key.Equals(str2))
                {
                    string ordercode = context.Request.Form["OrderCode"].ToString();
                    int orderstatus = Convert.ToInt32(context.Request.Form["OrderStatus"].ToString());
                    DateTime ordertime = Convert.ToDateTime(context.Request.Form["OrderTime"].ToString());
                    int ordertype = Convert.ToInt32(context.Request.Form["OrderType"].ToString());

                    string t = string.Format("ordercode:{0}, orderstatus:{1}, ordertime:{2}", ordercode, orderstatus, ordertime);
                    System.IO.File.AppendAllText(context.Server.MapPath("~/logOrderStatus.txt"), t);

                    if (!string.IsNullOrEmpty(ordercode))
                    {
                        AllCore ac = new AllCore();

                        lgk.Model.tb_UserOrder orderModel = ac.userOrderBLL.GetModel(" OrderCode='" + ordercode + "'");
                        if (orderModel != null)
                        {
                            if (ordertype == 0)//收货
                            {
                                orderModel.Status = orderstatus;
                                orderModel.SendTime = ordertime;
                                if (ac.userOrderBLL.Update(orderModel))
                                {
                                    if (orderstatus == 3)
                                    {
                                        ac.Proc_Shopping(orderModel.UserID, orderModel.OrderCode);
                                    }
                                    
                                    result = true;
                                    message = "操作成功（订单状态）";
                                }
                                else
                                {
                                    message = "操作异常";
                                }
                            }
                            else//退款
                            {
                                orderModel.Flag = orderstatus;
                                if (orderstatus == 1)//申请
                                {
                                    orderModel.ApplyTime = ordertime;
                                }
                                else//完成（2：失败，3：成功）
                                {
                                    orderModel.FinishTime = ordertime;
                                }

                                if (ac.userOrderBLL.Update(orderModel))
                                {
                                    result = true;
                                    message = "操作成功（退款状态）";
                                }
                                else
                                {
                                    message = "操作异常";
                                }
                            }
                        }
                        else
                        {
                            message = "此订单编号不存在";
                        }
                    }
                    else
                    {
                        message = "传输的订单编号数据为空";
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