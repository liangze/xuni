using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;


//1、
//localhost:46954/Interface/RegInterface.ashx
//注册
//json格式：[{"UserInfo":[{"UserCode":"张三","RegTime":"2015-03-30"]}]

//2、
//localhost:46954/Interface/YjInterface.ashx
//佣金：
//json格式：[{"MallBonus":[{"ShopID":"张三","SttlePoints":"100","SyncID":"1","FromShopID":"李四,"SttleDate":"2015-03-30"}]}]
//ShopID：用户编号
//SttlePoints：佣金金额
//SyncID：哪一期
//FromShopID：来源用户编号
//SttleDate：时间

namespace Web.sync
{
    public class ResultMsg
    {
        public string status { get; set; }
        public string message { get; set; }
    }



    public class SyncWei
    {
        private static string WeiURL
        {
            get
            {
                string weiURL = System.Configuration.ConfigurationManager.AppSettings["SyncWeiSite"];
                return weiURL;
            }
        }

        //  private static string url = "http://localhost:46954";
        private string url_Register = WeiURL + "/Interface/SyncRegister.ashx";

        /// <summary>
        /// 同步加盟商 到 钱包 到 微会员 三个系统的会员账号
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="RegTime"></param>
        /// <returns></returns>
        public ResultMsg SyncRegister(string UserCode,string RecommandCode, DateTime RegTime)
        {
            string json = "[{\"UserCode\":\"" + UserCode + "\",\"RecommandCode\":\"" + RecommandCode + "\",\"RegTime\":\"" + RegTime.ToString("yyyy-MM-dd HH:mm:ss") + "\"}]";
            ResultMsg infoMsg = null;

            try
            {
                byte[] postData = Encoding.UTF8.GetBytes(json);
                string resultjson = WEBRequest.Request(postData, url_Register);

                //反序列化返回信息
                infoMsg = JsonConvert.DeserializeObject<List<ResultMsg>>(resultjson).FirstOrDefault();
                if (infoMsg != null)
                {
                    return infoMsg;
                }
                else return null;
            }
            catch (Exception)
            {
                return null;
            }
        }




    }
}