using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Web.MallInterface
{
    public class MallMsg
    {
        public string status { get; set; }
        public string message{ get; set; }
    }
    public class MallMsgs
    {
        public string status { get; set; }
        public string success { get; set; }
    }
    public class ToMall
    {
            private static string MallURL
            {
                get
                {
                    string mallURL = System.Configuration.ConfigurationManager.AppSettings["SyncMallSite"];
                    return mallURL;
                }
            }

            private string url_Register = MallURL + "/index.php?act=api&op=register";//同步注册
            private string url_Jxs = MallURL; //+ "/shop/index.php?act=api&op=store";//同步经销商
            private string url_Bonus = MallURL + "/index.php?act=api&op=predeposit";//同步金额
            private string url_Auto = MallURL + "/index.php?act=api&op=receive";//同步自动收货
            private string url_DelAll = MallURL + "/index.php?act=api&op=clear";//同步清除数据

            #region 注册账号
            /// <summary>
            /// 注册账号
            /// </summary>
            /// <param name="UserCode"></param>
            /// <param name="PassWord"></param>
            /// <param name="Email"></param>
            public MallMsg SyncRegister(string UserCode, string PassWord, string Email)
            {
                string json = "username=" + UserCode + "&password=" + PassWord + "&email=" + Email;
                byte[] postData = Encoding.UTF8.GetBytes(json);

                string resultjson = "[" + WEBRequest.Request(postData, url_Register) + "]";

                MallMsg infoMsg = new JavaScriptSerializer().Deserialize<List<MallMsg>>(resultjson).FirstOrDefault();
                //MallMsg sd = getReturn();

                string t = string.Format("status:{0}, message:{1}", infoMsg.status, infoMsg.message);
                System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath("~/log_reg.txt"), t);

                if (infoMsg != null)
                {
                    return infoMsg;
                }
                else
                {
                    return null;
                }
            } 
            #endregion

            #region 经销商
            /// <summary>
            /// 经销商
            /// </summary>
            /// <param name="UserCode"></param>
            /// <param name="storename"></param>
            public MallMsg SyncJxs(string UserCode, string storename)
            {
                string json = "username=" + UserCode + "&store_name=" + storename;

                byte[] postData = Encoding.UTF8.GetBytes(json);
                string resultjson = "[" + WEBRequest.Request(postData, url_Jxs) + "]";

                MallMsg infoMsg = new JavaScriptSerializer().Deserialize<List<MallMsg>>(resultjson).FirstOrDefault();

                string t = string.Format("status:{0}, message:{1}", infoMsg.status, infoMsg.message);
                System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath("~/log06.txt"), t);

                if (infoMsg != null)
                {
                    return infoMsg;
                }
                else
                {
                    return null;
                }
            } 
            #endregion

            public class UserInfo
            {
                public string username { set; get; }
                public decimal amount { set; get; }
                public string admin_name { set; get; }
            }

            #region 同步奖金账户
            /// <summary>
            /// 同步奖金账户
            /// </summary>
            /// <param name="UserCode"></param>
            /// <param name="storename"></param>
            public MallMsgs SyncBonusAccount()
            {
                lgk.BLL.tb_journal journalBLL = new lgk.BLL.tb_journal();
                lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();

                var jList = journalBLL.GetModelList(" DATEDIFF(DAY,JournalDate,GETDATE())=0 AND Journal02<>1 ");// 
                string url = "";
                int i = 0;
                if (jList.Count > 0)
                {
                    foreach (var jour in jList)
                    {
                        UserInfo userinfo = new UserInfo();
                        userinfo.username = userBLL.GetUserCodeByUserID(Convert.ToInt64(jour.UserID));
                        if (jour.InAmount > 0)
                        {
                            userinfo.amount = jour.InAmount;
                        }
                        else
                        {
                            userinfo.amount = 0 - jour.OutAmount;
                        }
                        userinfo.admin_name = "admin";

                        url += "usernames[" + i.ToString() + "]=" + userinfo.username + "&amount[" + i.ToString() + "]=" + userinfo.amount + "&admin_name[" + i.ToString() + "]=" + userinfo.admin_name;
                        i += 1;
                        if (i < jList.Count)
                        {
                            url += "&";
                        }

                        lgk.Model.tb_journal Jmodel = journalBLL.GetModel(jour.ID);
                        Jmodel.Journal02 = 1;
                        journalBLL.Update(Jmodel);
                    }

                    byte[] postData = Encoding.UTF8.GetBytes(url);
                    string resultjson = "[" + WEBRequest.Request(postData, url_Bonus) + "]";

                    MallMsgs infoMsg = new JavaScriptSerializer().Deserialize<List<MallMsgs>>(resultjson).FirstOrDefault();

                    string t = string.Format("status:{0}, message:{1}", infoMsg.status, infoMsg.success);
                    System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath("~/log04.txt"), t);

                    if (infoMsg != null)
                    {
                        return infoMsg;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            } 
            #endregion

            #region 发货7天后默认收货
            /// <summary>
            /// 发货7天后默认收货
            /// </summary>
            /// <param name="UserCode"></param>
            /// <param name="storename"></param>
            public MallMsg SyncAutoReceive(DateTime jstime)
            {
                lgk.BLL.tb_UserOrder userorderBLL = new lgk.BLL.tb_UserOrder();
                var orderList = userorderBLL.GetModelList(" DATEDIFF(minute,ReceiveTime,'" + jstime.ToString("yyyy-MM-dd HH:mm:ss") + "')=0 AND [Status]=4 AND Flag in (0,2)");//

                string url = "";
                int i = 0;
                if (orderList.Count > 0)
                {
                    foreach (var order in orderList)
                    {
                        url += "ordercode[" + i.ToString() + "]=" + order.OrderCode;
                        i += 1;
                        if (i < orderList.Count)
                        {
                            url += "&";
                        }
                    }
                    byte[] postData = Encoding.UTF8.GetBytes(url);
                    string resultjson = "[" + WEBRequest.Request(postData, url_Auto) + "]";

                    MallMsg infoMsg = new JavaScriptSerializer().Deserialize<List<MallMsg>>(resultjson).FirstOrDefault();

                    string t = string.Format("status:{0}, message:{1}", infoMsg.status, infoMsg.message);
                    System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath("~/log05.txt"), t);

                    if (infoMsg != null)
                    {
                        return infoMsg;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            } 
            #endregion

            #region 清除数据
            /// <summary>
            /// 清除数据
            /// </summary>
            /// <returns></returns>
            public MallMsg SyncDelAll()
            {
                string json = "eliminate=true";

                byte[] postData = Encoding.UTF8.GetBytes(json);
                string resultjson = "[" + WEBRequest.Request(postData, url_DelAll) + "]";

                MallMsg infoMsg = new JavaScriptSerializer().Deserialize<List<MallMsg>>(resultjson).FirstOrDefault();

                string t = string.Format("status:{0}, message:{1}", infoMsg.status, infoMsg.message);
                System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath("~/log08.txt"), t);

                if (infoMsg != null)
                {
                    return infoMsg;
                }
                else
                {
                    return null;
                }
            } 
            #endregion

            public MallMsg getReturn()
            {
                MallMsg infoMsg = null;
                infoMsg.status = HttpContext.Current.Request.Form["status"].ToString();
                infoMsg.message = HttpContext.Current.Request.Form["message"].ToString();
                if (infoMsg != null)
                {
                    return infoMsg;
                }
                else
                {
                    return null;
                }
            }

        
    }
}