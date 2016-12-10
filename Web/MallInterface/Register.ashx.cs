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
    /// Register 的摘要说明
    /// </summary>
    public class Register : IHttpHandler
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
                    string usercode = context.Request.Form["UserCode"].ToString();
                    string password = context.Request.Form["Password"].ToString();
                    string email = context.Request.Form["Email"].ToString();

                    string t = string.Format("usercode:{0}, password:{1}, confirmPassword{2}", usercode, password, email);
                    System.IO.File.AppendAllText(context.Server.MapPath("~/log_reg.txt"), t);

                    AllCore ac = new AllCore();
                    lgk.Model.tb_user m_user = new lgk.Model.tb_user();
                    lgk.Model.tb_user RecommendModel = null;

                    RecommendModel = ac.userBLL.GetModel(" UserCode='system'");

                    //报单中心
                    long agentUserID = 0;

                    if (RecommendModel.IsAgent == 1)
                    {
                        agentUserID = RecommendModel.UserID;
                    }

                    lgk.Model.tb_user ModelAgent = ac.userBLL.GetModel(agentUserID);
                    //验证
                    if (ac.userBLL.GetCount("UserCode='" + usercode + "'") > 0)
                    {
                        message = "此用户账号已存在";
                    }
                    else if (ac.userBLL.GetCount("Email='" + email + "'") > 0)
                    {
                        message = "此邮箱已注册";
                    }
                    else
                    {
                        m_user.UserCode = usercode;
                        m_user.LevelID = 1;
                        decimal bill = ac.getParamAmount("billMoney");
                        decimal lev = ac.getParamAmount("Level1");
                        m_user.RegMoney = bill * lev;
                        string pwd = PageValidate.GetMd5(password);
                        m_user.Password = pwd;
                        m_user.SecondPassword = pwd;
                        m_user.ThreePassword = pwd;

                        m_user.RecommendID = RecommendModel.UserID;
                        m_user.RecommendCode = RecommendModel.UserCode;
                        m_user.RecommendPath = RecommendModel.RecommendPath;
                        m_user.RecommendGenera = RecommendModel.RecommendGenera + 1;

                        m_user.ParentID = RecommendModel.UserID;
                        m_user.ParentCode = RecommendModel.UserCode;
                        m_user.UserPath = RecommendModel.RecommendPath;
                        m_user.Layer = RecommendModel.RecommendGenera + 1;

                        m_user.IsAgent = 0;
                        m_user.User006 = ModelAgent.UserCode;
                        m_user.AgentsID = ac.agentBLL.GetAgentsIDByUserCode(ModelAgent.UserCode);//

                        m_user.LeftScore = 0;
                        m_user.LeftBalance = 0;
                        m_user.LeftNewScore = 0;
                        m_user.RightScore = 0;
                        m_user.RightBalance = 0;
                        m_user.RightNewScore = 0;

                        m_user.Location = 0;
                        m_user.User007 = "";
                        m_user.IsOpend = 0;
                        m_user.IsLock = 0;//是否被冻結(0-否,1-冻結)

                        m_user.Emoney = 0;//现金币账户
                        m_user.BonusAccount = 0;//佣金币账户
                        m_user.AllBonusAccount = 0;//累计獎金賬戶
                        m_user.StockAccount = 0;//代金券
                        m_user.StockMoney = 0;//红包积分
                        m_user.GLmoney = 0;//购物币
                        m_user.ShopAccount = 0;//存折账户

                        m_user.BankAccount = "";// "銀行賬號";
                        m_user.BankAccountUser = "";// "開户姓名";
                        m_user.BankName = "";// "開户銀行";
                        m_user.BankBranch = "";// "支行名稱";
                        m_user.BankInProvince = "";// "銀行所在省份";
                        m_user.BankInCity = "";//DropDownList1.SelectedItem.Text;// "銀行所在城市";

                        m_user.Email = email;
                        m_user.RegTime = DateTime.Now;
                        m_user.User002 = ModelAgent.UserID;

                        if (ac.userBLL.Add(m_user) > 0)
                        {
                            long iUserID = ac.GetUserID(usercode);
                            ac.flag_open(Convert.ToInt32(iUserID), 2);

                            result = true;
                            message = usercode + "注册成功！";
                        }
                        else
                        {
                            message = "注册失败！";
                        }
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

        public class UserInfo
        {
            public string UserCode { get; set; }//购买人
            public string Password { get; set; }//登录密码
            public string SecondPassword { get; set; }//二级密码
            public string ThirdPassword { get; set; }//三级密码
            public string AgentCode { get; set; }//报单中心编号
            public string RecommendCode { get; set; }//推荐人编号
        }
    }
}