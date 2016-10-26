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
    /// RedBag 的摘要说明
    /// </summary>
    public class RedBag : IHttpHandler
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

            string s = string.Format("json:{0}", json);
            System.IO.File.AppendAllText(context.Server.MapPath("~/log-redbag.txt"), s);

            if (!string.IsNullOrEmpty(json) || json.Trim() != string.Empty)
            {
                string key = context.Request.Form["Key"].ToString();
                string str1 = PageValidate.GetMd5("HongBao").ToLower();
                string str2 = PageValidate.GetMd5(str1).ToLower();

                if (key.Equals(str2))
                {
                    string usercode = context.Request.Form["UserCode"].ToString();//用户编号
                    decimal amount = Convert.ToDecimal(context.Request.Form["RedbagAmount"].ToString());//点击金额
                    DateTime time = Convert.ToDateTime(context.Request.Form["ClickTime"].ToString());//点击时间
                    int top = Convert.ToInt32(context.Request.Form["TopClick"].ToString());//最多可点击
                    decimal advertid = Convert.ToDecimal(context.Request.Form["AdvertID"].ToString());//广告的ID

                    string t = string.Format("amount:{0}, time:{1}, top:{2}", amount, time, top);
                    System.IO.File.AppendAllText(context.Server.MapPath("~/log-redbag.txt"), t);

                    if (!string.IsNullOrEmpty(usercode))
                    {
                        AllCore ac = new AllCore();
                        lgk.Model.tb_user userModel = ac.userBLL.GetModel(" UserCode='" + usercode + "'");
                        if (userModel != null)
                        {
                            int a = ac.journalBLL.GetCount(" DATEDIFF(DAY,JournalDate,'" + time + "')=0 and JournalType=5 and Journal05=" + advertid + " and Remark like '%点击广告%' ");
                            if (a < top)
                            {
                                //加入明细表
                                lgk.Model.tb_journal jModel = new lgk.Model.tb_journal();
                                jModel.UserID = Convert.ToInt32(userModel.UserID);
                                jModel.InAmount = amount;
                                jModel.OutAmount = 0;
                                jModel.BalanceAmount = userModel.StockMoney + amount;
                                jModel.JournalDate = time;
                                jModel.JournalType = 5;
                                jModel.Remark = "点击广告获得红包";
                                jModel.RemarkEn = "";
                                jModel.Journal01 = Convert.ToInt32(userModel.UserID);
                                jModel.Journal02 = 1;
                                jModel.Journal05 = advertid;//广告ID
                                //用户信息修改
                                userModel.StockMoney += amount;

                                if (ac.userBLL.Update(userModel) && ac.journalBLL.Add(jModel) > 0)
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
                                message = "今日点击广告次数达到封顶";
                            }
                        }
                        else
                        {
                            message = "此用户不存在";
                        }
                    }
                    else
                    {
                        message = "传递的用户账号数据为空";
                    }
                }
                else
                {
                    message = "验证出错";
                }
            }

            SendResponse(context, result, message);
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}