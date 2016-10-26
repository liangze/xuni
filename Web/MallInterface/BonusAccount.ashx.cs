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
    /// BonusAccount 的摘要说明
    /// </summary>
    public class BonusAccount : IHttpHandler
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
                AllCore ac = new AllCore();
                string usercode = context.Request.Form["username"].ToString();
                decimal amount = Convert.ToDecimal(context.Request.Form["Amount"].ToString());
                string remark = context.Request.Form["Remark"].ToString();

                string t = string.Format("usercode:{0}, amount:{1}, remark:{2}", usercode, amount, remark);
                System.IO.File.AppendAllText(context.Server.MapPath("~/log03.txt"), t);

                if (!string.IsNullOrEmpty(usercode))
                {
                    lgk.Model.tb_user userModel = ac.userBLL.GetModel(" UserCode='" + usercode + "'");
                    //加入明细表
                    lgk.Model.tb_journal jModel = new lgk.Model.tb_journal();
                    jModel.UserID = Convert.ToInt32(userModel.UserID);
                    if (amount > 0)
                    {
                        jModel.InAmount = amount;
                        jModel.OutAmount = 0;
                    }
                    else
                    {
                        jModel.InAmount = 0;
                        jModel.OutAmount = 0 - amount;
                    }
                    jModel.BalanceAmount = userModel.BonusAccount + amount;
                    jModel.JournalDate = DateTime.Now;
                    jModel.JournalType = 1;
                    jModel.Remark = remark;
                    jModel.RemarkEn = "";
                    jModel.Journal01 = Convert.ToInt32(userModel.UserID);
                    jModel.Journal02 = 1;
                    //用户信息修改
                    userModel.BonusAccount += amount;

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
                    message = "用户账号不存在";
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