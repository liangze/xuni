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
    /// Pay 的摘要说明
    /// </summary>
    public class Pay : IHttpHandler
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
                    AllCore ac = new AllCore();
                    string usercode = context.Request.Form["UserCode"].ToString();//用户编号
                    decimal amount = Convert.ToDecimal(context.Request.Form["PayAmount"].ToString());//支付金额
                    int journalType = Convert.ToInt32(context.Request.Form["PayType"].ToString());//币种(1-2现金币，2-3购物币)
                    DateTime time = Convert.ToDateTime(context.Request.Form["PayTime"].ToString());//支付时间
                    string remark = context.Request.Form["Remark"].ToString();//用途说明

                    if (!string.IsNullOrEmpty(usercode))
                    {
                        lgk.Model.tb_user userModel = ac.userBLL.GetModel(" UserCode='" + usercode + "'");
                        if (userModel != null)
                        {
                            //加入明细表
                            lgk.Model.tb_journal jModel = new lgk.Model.tb_journal();
                            jModel.JournalDate = time;
                            jModel.JournalType = journalType;
                            jModel.Remark = remark;
                            jModel.RemarkEn = "";
                            jModel.Journal01 = Convert.ToInt32(userModel.UserID);
                            jModel.Journal02 = 1;

                            if (journalType == 1)
                            {
                                if (userModel.Emoney < amount)
                                {
                                    message = "现金币余额不足";
                                }
                                else
                                {
                                    jModel.BalanceAmount = userModel.Emoney - amount;
                                    userModel.Emoney -= amount;

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
                            }
                            else
                            {
                                if (userModel.GLmoney < amount)
                                {
                                    message = "购物币余额不足";
                                }
                                else
                                {
                                    jModel.BalanceAmount = userModel.GLmoney - amount;
                                    userModel.GLmoney -= amount;

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