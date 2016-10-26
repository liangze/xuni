using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.MallInterface
{
    public partial class Test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public class returnMsg
        {
            public string status { get; set; }
            public string message { get; set; }
        }

        protected void Sub_Click(object sender, EventArgs e)
        {
            //string iusercode = "asd122";
            //string itjUsercode = this.TjUserCode.Text.Trim();
            //string iPassword = "1";
            //string Email = "123@qq.com";
            //string isellAmount = this.SellAmount.Text.Trim();
            //DateTime iBuytime = Convert.ToDateTime(this.BuyTime.Text);

            //string json = "[{\"UserCode\":\"" + iusercode + "\",\"Password\":\"" + iPassword + "\",\"Email\":\"" + Email + "\"}]";
            //string json = "json=eyJVc2VyQ29kZSI6ImFzZDEyMyIsIkJ1eVRpbWUiOiIyMDE1LTA3LTIwIiwiT3JkZXJDb2RlIjoiSERfMTIzNDMzNTYiLCJTZWxsQW1vdW50IjoiMTAwIiwiUGF5VHlwZSI6IjEiLCJQcm92aW5jZSI6Ilx1NTMxN1x1NGVhYyIsIkNpdHkiOiJcdTUzMTdcdTRlYWNcdTVlMDIiLCJDb3VudHJ5IjoiXHU0ZTA5XHU5MWNjXHU1YzZmIiwiR29vZHMiOlt7IlByb2R1Y3RQcmljZSI6IjEwMCIsIk51bSI6IjEiLCJTZWxsZXJDb2RlIjoiMTIzIiwiRmluYW5jaWFsUmF0aW8iOiIwLjAxIiwiTWFya2V0aW5nUmF0aW8iOiIwLjAyIiwiRXF1aXR5IjoiMSIsIkVxdWl0eVRvcCI6IjEwMCJ9LHsiUHJvZHVjdFByaWNlIjoiMTAwIiwiTnVtIjoiMiIsIlNlbGxlckNvZGUiOiIxMjU0IiwiRmluYW5jaWFsUmF0aW8iOiIwLjAxIiwiTWFya2V0aW5nUmF0aW8iOiIwLjAzIiwiRXF1aXR5IjoiMTAiLCJFcXVpdHlUb3AiOiIxMDAifV19&Key=3b64e22cbc99a96cbacec98db71563e6";
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //string json = "UserCode=asd123&RedbagAmount=100&ClickTime=2015-07-01 10:00:00&TopClick=10";
            string json = "Key=3b64e22cbc99a96cbacec98db71563e6&OrderCode=HE_12343356&OrderStatus=3&OrderTime=2015-07-01 10:00:00&OrderType=1";

            string url_Register = "http://localhost:2982/MallInterface/OrderStatus.ashx";

            byte[] postData = Encoding.UTF8.GetBytes(json);
            string resultjson = WEBRequest.Request(postData, url_Register);

            //反序列化返回信息
            returnMsg sd = getReturn(resultjson);
            Response.Write(sd.status+sd.message);
            
        }

        public returnMsg getReturn(string resultjson)
        {
            returnMsg infoMsg = null;
            JavaScriptSerializer js = new JavaScriptSerializer();
            infoMsg = js.Deserialize<List<returnMsg>>(resultjson).FirstOrDefault();
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