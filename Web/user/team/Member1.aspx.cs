using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;

namespace Web.user.team
{
    public partial class Member1 : PageCore
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];

        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码
            if (!IsPostBack)
            {
                BindLevel();
                BindData();
            }
            btnSearch.Text = GetLanguage("Determine");//确定
        }

        public string getColumn2(int type)
        {
            string bi = "";
            int typer = agentBLL.GetModel("userid=" + type).AgentType;
            if (typer == 1)
            {
                bi = "一级服务中心";
            }
            else if (typer == 2)
            {
                bi = "二级服务中心";
            }
            else if (typer == 3)
            {
                bi = "三级服务中心";
            }
            return bi;
        }

        #region 绑定用户級別
        /// <summary>
        /// 绑定用户級別
        /// </summary>
        private void BindLevel()
        {
            if (currentCulture == "zh-cn")
            {
                dropType.Items.Add(new ListItem("-请选择-", "0"));
                dropType.Items.Add(new ListItem("会员编号", "1"));
                dropType.Items.Add(new ListItem("会员姓名", "2"));
            }
            else
            {
                dropType.Items.Add(new ListItem("-Please choose-", "0"));
                dropType.Items.Add(new ListItem("Member number", "1"));
                dropType.Items.Add(new ListItem("Member name", "2"));
            }

            //IList<lgk.Model.tb_level> ddlList = new lgk.BLL.tb_level().GetModelList(" LevelID<6 ");
            //dropLevel.Items.Clear();
            //ListItem li = new ListItem();
            //li.Value = "0";
            //li.Text = GetLanguage("PleaseSselect");//"-请选择-"
            //dropLevel.Items.Add(li);
            //foreach (lgk.Model.tb_level item in ddlList)
            //{
            //    ListItem items = new ListItem();
            //    items.Value = item.LevelID.ToString();
            //    if (currentCulture == "en-us")
            //    {
            //        items.Text = item.level03;
            //    }
            //    else
            //    {
            //        items.Text = item.LevelName;
            //    }
            //    dropLevel.Items.Add(items);
            //}
        }
        #endregion

        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            lgk.Model.tb_user model = userBLL.GetModel(getLoginID());
            string strWhere = "";
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            strWhere = " IsOpend=0  and User006 = '" + model.UserCode + "';";//and AgentsID=" + Loginagent.ID
            if (this.dropType.SelectedValue != "0")
            {
                if (this.dropType.SelectedValue == "1")
                {
                    strWhere += " and usercode like  '%" + this.txtInput.Value.Trim() + "%'";
                }
                if (this.dropType.SelectedValue == "2")
                {
                    strWhere += " and truename like  '%" + this.txtInput.Value.Trim() + "%'";
                }
            }
            //if (this.dropLevel.SelectedValue != "0" && this.dropLevel.SelectedValue != "")
            //{
            //    strWhere += " and LevelID=" + dropLevel.SelectedValue;
            //}
            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RegTime,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  between '" + strStartTime + "' and '" + strEndTime + "'");
            }
            return strWhere;
        }

        public DataSet g()
        {
           

            //lgk.Model.tb_user Model = new lgk.Model.tb_user();
            //Model = userBLL.GetModel(getLoginID());


            string sql = " select * from tb_user where ParentID='"+ getLoginID() + "' ";

            DataSet ds = userBLL.getData_Chaxun(sql, "");
            return ds;

        }

        /// <summary>
        /// 填充申请记录
        /// </summary>
        private void BindData()
        {
            bind_repeater(g(), Repeater1, "Userid desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 搜索申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        
         
            

        /// <summary>
        /// 分页申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        /// <summary>
        /// 短信
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetHtmlFromUrl(string url)
        {
            string a = null;

            if (url == null || url.Trim().ToString() == "")
            {
                return a;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "Get";
                hr.Timeout = 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, System.Text.Encoding.Default);
                a = ser.ReadToEnd();
                Response.Write("<br/>resp=" + ser.ReadToEnd());

            }
            catch (Exception ex)
            {
                a = ex.Message;
            }
            return a;
        }

    }
}