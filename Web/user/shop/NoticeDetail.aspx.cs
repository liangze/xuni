/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-19 17:54:34 
 * 文 件 名：		NoticeDetail.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Library;
using System.Drawing;
using lgk.BLL;
using System.Data;
using System.Text;
using lgk.Model;
using System.IO;
using Newtonsoft.Json;
namespace web.user.shop
{
    public partial class NoticeDetail : System.Web.UI.Page
    {
        public int typeId = 0;
        lgk.BLL.tb_news newsBLL = new lgk.BLL.tb_news();
        protected lgk.Model.tb_news news;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                BindData(Request.QueryString["id"]);
            }
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        protected void BindData(string id)
        {
            news = newsBLL.GetModel(Convert.ToInt64(id));
            if (news == null)
            {
                this.Response.Write("文章ID不存在！");
                this.Response.End();
            }
            BindGongGaoData();

            string City="";
            if (Request["city"] != null)
            {
                City = Request["city"].ToString();
                City = GetCityFromName(City);
            }
            GetTop_tieyou(City);
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
 

        public class CityData
        {
            public string pinyin { get; set; }
            public string region_name { get; set; }
            public string region_id { get; set; }

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
        /// 最新特惠
        /// </summary>
        /// <param name="city"></param>
        private void GetTop_tieyou(string city)
        {
            string typename = "促销特惠";
            lgk.BLL.tb_produceType ptBALL = new lgk.BLL.tb_produceType();
            List<lgk.Model.tb_produceType> list = ptBALL.GetModelList(" TypeName ='" + typename + "' ");
            if (list.Count > 0)
            {
                string strwhere = string.Format("g.[StateType]=1 and g.Goods001=1 and g.Goods003=0 and    GoodsType in  (SELECT   [ID] FROM  [dbo].[tb_produceType] where ParentID = " + list[0].ID + ")  " + GetWhere(city)); //审核通过,并上架
                string filedorder = "g.Addtime desc";
                lgk.BLL.tb_goods goods = new lgk.BLL.tb_goods();
                //goods.GetList(10, strwhere, filedorder);
                DataList_quanggou.DataSource = goods.GetList(10, strwhere, filedorder);
                DataList_quanggou.DataBind();
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
                strWh = string.Format(" and City like '%{0}%' ", city);
            }
            //}
            return strWh;

        }

        /// <summary>
        /// 网站公告
        /// </summary>
        protected void BindGongGaoData()
        {
            string where = "";
            AllCore ac = new AllCore();
            ac.bind_repeater(ac.newsBLL.GetList(20, where, "PublishTime desc"), rpNews, "PublishTime desc", trNull);
        }


    }
}
