using System;
using System.Text;
using System.Net;
using System.IO;

namespace Library
{
    public class WEBRequest
    {
        public static string Request(byte[] postData, string PostUrl)
        {
            string responseData = String.Empty;
            UTF8Encoding encoding = new UTF8Encoding();

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                responseData = reader.ReadToEnd();
            }
            else
            {
                //访问失败
            }

            return responseData;

        }

    }
}
