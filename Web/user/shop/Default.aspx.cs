using System;
using System.Collections.Generic;
using System.Linq;
using lgk.BLL;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Library;
using System.Web;
using System.Web.UI.WebControls;
using DataAccess;

namespace Web.user.shop
{
    public partial class Default : System.Web.UI.Page
    {
        DataTable source = new DataTable();
        //tb_produceType type = new tb_produceType();
        private string City = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["city"] != null)
                {
                    City = Request["city"].ToString();
                    City = GetCityFromName(City);
                }
                else
                {
                    string ip = HttpContext.Current.Request.UserHostAddress;
                }

                HttpCookie cookie = new HttpCookie("region_name");
                cookie.Value = Server.UrlEncode(City);// 
                Response.AppendCookie(cookie);
                GetTop_Week_Recommend(City);
                GetTop_quanggou(City);
                GetTopProduct1(City);
                GetTopProduct2(City);
                GetTopProduct3(City);
                GetTopProduct4(City);
                GetTopProduct5(City);
            }
        }

        private string GetWhere(string city)
        {
            string strWh = " and 1=1";
            //if (Request.Cookies["region_name"] != null && Request.Cookies["region_name"].ToString() != "")
            //{
               // string strCity = Server.UrlDecode(cookie.Value);
                if (city == "")
                {
                    strWh = " and 1=1";
                }
                else
                {
                    strWh = string.Format(" and City like '%{0}%' ",city);
                }
            //}
            return strWh;
        }


        /// <summary>
        /// 每周推荐
        /// </summary>
        /// <param name="city"></param>
        private void GetTop_Week_Recommend(string city)
        {
            int Goods004 = 3;
            //审核通过,并上架
            string strWhere = string.Format("g.[StateType]=1 and g.Goods001=1 and g.Goods003=0 and Charindex( '," + Goods004 + ",' , (','+ [Goods004]+',' ),0) >0  " + GetWhere(city));
            //string strWhere = string.Format("g.Goods001=1 and g.Goods003=0 and Charindex( '," + Goods004 + ",' , (','+ [Goods004]+',' ),0) >0  " + GetWhere(city));
            string filedorder = "g.Addtime desc";
            tb_goods goods = new tb_goods();
            //goods.GetList(10, strwhere, filedorder);
            DataList_week_recommend.DataSource = goods.GetList(3, strWhere, filedorder);
            DataList_week_recommend.DataBind();
        }

        /// <summary>
        /// 限时抢购
        /// </summary>
        /// <param name="city"></param>
        private void GetTop_quanggou(string city)
        {
            // string typename = "限时抢购";
            //tb_produceType Type01--0：显示菜单栏，1：隐藏菜单栏
            //Type02--2：抢购；3：秒杀；4：团购
            tb_goods_cxth good = new tb_goods_cxth();
            //var qggoods = good.GetList(4, " [Goods001]=1 and [StateType]=1 and Goods003=0 and [PareTopChild] in (select id from tb_produceType where type02 =2 ) ", "[Goods007] desc");
            var qggoods = good.GetList(4, "[StateType]=1 AND [Goods001]=1 AND Goods003=0 AND TypeID = 5 AND IsLucky=0", "[Goods007] desc");

            DataList_quanggou.DataSource = qggoods;
            DataList_quanggou.DataBind();
        }


        //新品上市
        private void GetTopProduct1(string city)
        {
            string strwhere = string.Format("g.[StateType]=1 and g.Goods001=1 and g.Goods003=0 and g.Goods004 like '%1%'" + GetWhere(city)); //审核通过,并上架
            //string strwhere = string.Format("g.Goods001=1 and g.Goods003=0 and g.Goods004 like '%1%'" + GetWhere(city)); //审核通过,并上架
            string filedorder = "g.Addtime desc";
            tb_goods goods = new tb_goods();
           // goods.GetList(10, strwhere, filedorder);
            DataList1.DataSource = goods.GetList(8, strwhere, filedorder);
            DataList1.DataBind();
        }

        //热销产品
        private void GetTopProduct2(string city)
        {
            //int typeID = 36;
            string strwhere = string.Format("g.[StateType]=1 and g.Goods001=1 and g.Goods003=0 and g.Goods004 like '%2%' " + GetWhere(city)); //审核通过,并上架
            //string strwhere = string.Format("g.Goods001=1 and g.Goods003=0 and g.Goods004 like '%2%' " + GetWhere(city)); //审核通过,并上架
            string filedorder = "g.Addtime desc";
            tb_goods goods = new tb_goods();
            //goods.GetList(10, strwhere, filedorder);
            DataList2.DataSource = goods.GetList(8, strwhere, filedorder);
            DataList2.DataBind();
        }

        //母婴用品
        private void GetTopProduct3(string city)
        {
            int typeID = 36;
            string strwhere = string.Format("g.[StateType]=1 and g.Goods001=1 and g.Goods003=0 and g.Goods004 like '%4%' "+ GetWhere(city)); //审核通过,并上架
            //string strwhere = string.Format("g.Goods001=1 and g.Goods003=0 and g.Goods004 like '%4%' " + GetWhere(city)); //审核通过,并上架
            string filedorder = "g.Addtime desc";
            tb_goods goods = new tb_goods();
           // goods.GetList(10, strwhere, filedorder);
            DataList3.DataSource = goods.GetList(8, strwhere, filedorder);
            DataList3.DataBind();
        }

        //食品保健
        private void GetTopProduct4(string city)
        {
            int typeID = 38;
            string strwhere = string.Format("g.[StateType]=1 and g.Goods001=1 and g.Goods003=0 and g.Goods004 like '%5%' "+ GetWhere(city)); //审核通过,并上架
            //string strwhere = string.Format("g.Goods001=1 and g.Goods003=0 and g.Goods004 like '%5%' " + GetWhere(city)); //审核通过,并上架
            string filedorder = "g.Addtime desc";
            tb_goods goods = new tb_goods();
           // goods.GetList(10, strwhere, filedorder);
            DataList4.DataSource = goods.GetList(8, strwhere, filedorder);
            DataList4.DataBind();
        }

        //个人护理
        private void GetTopProduct5(string city)
        {
            string strwhere = string.Format("g.[StateType]=1 and g.Goods001=1 and g.Goods003=0 and g.Goods004 like '%6%' " + GetWhere(city)); //审核通过,并上架
            //string strwhere = string.Format("g.Goods001=1 and g.Goods003=0 and g.Goods004 like '%6%' " + GetWhere(city)); //审核通过,并上架
            string filedorder = "g.Addtime desc";
            tb_goods goods = new tb_goods();
           // goods.GetList(10, strwhere, filedorder);
            DataList5.DataSource = goods.GetList(8, strwhere, filedorder);
            DataList5.DataBind();
        }

        public class Info
        {
            public string ret { get; set; }
            public string start { get; set; }
            public string end { get; set; }
            public string country { get; set; }
            public string province { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string isp { get; set; }
            public string type { get; set; }
            public string desc { get; set; }
        }
        public class CityData
        {
            public string pinyin { get; set; }
            public string region_name { get; set; }
            public string region_id { get; set; }

        }

        private string GetCityFromIP(string ip = "")
        {
            string city = string.Empty;
            //新浪获取 IP 地址接口 "http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js";

            string url_ip = string.Format("http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=json&ip={0}", ip);
            string url_curr = "http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=json";
            string url;

          if (ip.Equals("127.0.0.1") || ip.Equals("::1"))
                url = url_curr;
           else url = url_ip;

            Encoding encoding = Encoding.UTF8;
            try
            {
                string json = Library.WEBRequest.Request(Encoding.UTF8.GetBytes(""), url);
                json = string.Format("[{0}]", json);
                // string json = @"{'ret':1,'start':'171.36.0.0','end':'171.37.223.255','country':'\u4e2d\u56fd','province':'\u5e7f\u897f','city':'\u5357\u5b81','district':'','isp':'\u8054\u901a','type':'','desc':''}";

                List<Info> infoList = JsonConvert.DeserializeObject<List<Info>>(json);

                var _infolist = infoList.FirstOrDefault();
                if (_infolist != null)
                    city = _infolist.city;
            }
            catch (Exception e)
            {
                throw e;
            }
            return city;
        }

        private string GetCityFromName(string findkey)
        {
            string city = string.Empty;
            try
            {
                var _citylist = GetCityListFromJson();

                var citysingle = _citylist.SingleOrDefault(s => s.pinyin == findkey || s.region_name == findkey);
                if (citysingle != null)
                    city = citysingle.region_name;
                return city;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 反序列化json
        /// </summary>
        /// <returns></returns>
        private List<CityData> GetCityListFromJson()
        {
            string json = GetCityJsonFromFile();
            try
            {
                List<CityData> infoList = JsonConvert.DeserializeObject<List<CityData>>(json);
                return infoList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 获取城市json格式的CityData.Json文件，本地文件
        /// </summary>
        /// <returns></returns>
        private string GetCityJsonFromFile()
        {
            StringBuilder output = new StringBuilder();
            /**/
            ///初始化该字符串的长度为0
            output.Length = 0;

            FileStream fs = new FileStream(HttpRuntime.AppDomainAppPath + "Scripts\\CityData.js", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader read = new StreamReader(fs);
            read.BaseStream.Seek(0, SeekOrigin.Begin);
            /**/
            ///读取文件
            while (read.Peek() > -1)
            {
                /**/
                ///取文件的一行内容并换行
                output.Append(read.ReadLine() + "\n");
            }

            /**/
            ///关闭释放读数据流
            read.Close();
            string json = output.ToString();
            return json;
        }

    }
}