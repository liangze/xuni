using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Web.MallInterface
{
    /// <summary>
    /// Recommend 的摘要说明
    /// </summary>
    public class Recommend : IHttpHandler
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

            string n0 = string.Format("数据流:{0}", json);
            System.IO.File.AppendAllText(context.Server.MapPath("~/log_buy.txt"), n0 + "---获取数据流*********");

            if (!string.IsNullOrEmpty(json) || json.Trim() != string.Empty)
            {
                string key = context.Request.Form["Key"].ToString();
                string str1 = PageValidate.GetMd5("HongBao").ToLower();
                string str2 = PageValidate.GetMd5(str1).ToLower();

                if (key.Equals(str2))
                {
                    string data = context.Request.Form["json"].ToString();

                    byte[] a = Convert.FromBase64String(data);

                    string jss = "[" + Encoding.Default.GetString(a) + "]";

                    string n2 = string.Format("解码成字符串:{0}", ",," + jss);
                    System.IO.File.AppendAllText(context.Server.MapPath("~/log_buy.txt"), n2 + "---这是解码成字符串*********");

                    JavaScriptSerializer js = new JavaScriptSerializer();

                    var mall = js.Deserialize<List<MallInfo>>(jss).FirstOrDefault();

                    if (mall != null)
                    {
                        AllCore ac = new AllCore();

                        lgk.Model.tb_user userInfo = ac.userBLL.GetModel(" UserCode='" + mall.UserCode + "'");
                        if (userInfo != null)
                        {
                            lgk.Model.tb_UserOrder orderInfo = ac.userOrderBLL.GetModel("OrderCode='" + mall.OrderCode + "'");
                            if (orderInfo == null)
                            {
                                #region 加入订单表
                                lgk.Model.tb_UserOrder orderModel = new lgk.Model.tb_UserOrder();
                                orderModel.UserID = userInfo.UserID;
                                orderModel.OrderCode = mall.OrderCode;
                                orderModel.SellAmount = Convert.ToDecimal(mall.SellAmount);
                                orderModel.IntegralAmount = 0;
                                orderModel.PurchaseAmount = 0;
                                orderModel.BuyTime = Convert.ToDateTime(mall.BuyTime);
                                orderModel.order001 = mall.PayType;//支付方式(1->2现金币，2->3购物币)
                                orderModel.Province = mall.Province;
                                orderModel.City = mall.City;
                                orderModel.Country = mall.Country;
                                orderModel.Status = 1;
                                orderModel.Flag = 0;

                                #region 循环订单明细
                                foreach (Goods good in mall.Goods)
                                {
                                    lgk.Model.tb_UserOrderDetail detail = new lgk.Model.tb_UserOrderDetail();

                                    detail.OrderCode = mall.OrderCode;
                                    detail.Integral = good.FinancialRatio;//理财金比例
                                    detail.Purchase = good.MarketingRatio;//营销成本比例
                                    detail.Sale = good.ProductPrice;//产品价格（单价）
                                    detail.SellerCode = good.SellerCode;//商家编号
                                    detail.Quantity = good.Num;//购买数量
                                    detail.Equity = good.Equity;//股权
                                    detail.EquityTop = good.EquityTop;//封顶
                                    detail.d001 = 0;
                                    detail.d002 = 0;
                                    detail.d003 = "";

                                    ac.userOrderDetailBLL.Add(detail);
                                }
                                #endregion

                                ac.userOrderBLL.Add(orderModel); 
                                #endregion

                                //购物结算
                                //ac.flag_Shopping(userInfo.UserID, orderModel.OrderCode);

                                result = true;
                                message = "操作成功";
                            }
                            else
                            {
                                message = "此订单编号已存在";
                            }
                        }
                        else
                        {
                            message = "此购买人不存在";
                        }
                    }
                    else
                    {
                        message = "数据有null值";
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

        public class MallInfo
        {
            public string UserCode { get; set; }//购买人
            public string OrderCode { get; set; }//订单编号
            public DateTime BuyTime { get; set; }//购买时间
            public int PayType { get; set; }//支付方式
            public decimal SellAmount { get; set; }//总销售金额
            public string Province { get; set; }//省
            public string City { get; set; }//市
            public string Country { get; set; }//县
            public List<Goods> Goods { get; set; }
        }
        public class Goods
        {
            public decimal ProductPrice { get; set; }//产品价格（单价）
            public int Num { get; set; }//购买数量
            public string SellerCode { get; set; }//商家编号
            public decimal FinancialRatio { get; set; }//理财金比例
            public decimal MarketingRatio { get; set; }//营销成本比例
            public decimal Equity { get; set; }//股权
            public decimal EquityTop { get; set; }//股权（封顶）
        }
    }

//{ 
//    'UserCode': "购买人", 
//    'BuyTime': "下单时间", 
//    'OrderCode': "订单编号", 
//    'SellAmount': "总销售金额",
//    "Goods": [ 
//        { 
//            'ProductPrice': "产品单价", 
//            'Num': "购买数量", 
//            'SellerCode': "商家编号", 
//            'FinancialRatio': "理财金比例", 
//            'MarketingRatio': "营销成本比例",
//            'Equity': "股权",
//            'EquityTop': "股权（封顶）"
//        }, 
//        { 
//            'ProductPrice': "产品单价", 
//            'Num': "购买数量", 
//            'SellerCode': "商家编号", 
//            'FinancialRatio': "理财金比例", 
//            'MarketingRatio': "营销成本比例",
//            'Equity': "股权",
//            'EquityTop': "股权（封顶）"
//        }
//    ] 
//}
}