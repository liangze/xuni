/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-14 12:17:16 
 * 文 件 名：		RecommendTree.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using DataAccess;

namespace Web.user.team
{
    public partial class RecommendTree : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                //if (Request.QueryString["UserID"] != "" || Request.QueryString["UserID"] != null)
                //{
                //    this.TreeView1.Nodes.Add(getTree(Convert.ToInt64(Request.QueryString["UserID"])));
                //}

                this.TreeView1.Nodes.Add(getTree(int.Parse(getLoginID().ToString())));

                //Button4.Text = GetLanguage("MemberList");//会员列表
                //Button1.Text = GetLanguage("AvailableMembers");//已开通会员
                //btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

        public TreeNode getTree(int uid)
        {
            lgk.Model.tb_user Model = new lgk.Model.tb_user();

            if (userBLL.GetModel(uid) == null)
            {
                return null;
            }
            Model = userBLL.GetModel(uid);
            //if (Session["xx"] == null)
            //{
            //    int a = int.Parse(Model.Layer.ToString()) + 5;
            //    Session["a"] = a;
            //    Session["xx"] = 99;
            //}
            TreeNode node = new TreeNode();
            string LevelName = levelBLL.GetModel(Model.LevelID).LevelName;
            string dd = "";
            //if (Model.IsOpend == 0)
            //{ 
            //    dd = "[<span style='color:red;'>未开通</span>]";
            //}
            //else if (Model.IsOpend == 2)
            //{
            //    dd = "[已开通]";
            //}

            if (Model.IsLock == 1)
            {
                dd += "[<span style='color:red;'>已冻结</span>]";
            } 
            if (uid == 1)
            {
                node.Text = Model.UserCode;
                node.ImageUrl = "../../images/ico_admin.gif";
                node.NavigateUrl = "RecommendTree.aspx?userid=" + Model.UserID;
            } 
            else
            {
                if (Model.IsOpend == 0)
                {
                    dd += "[<span style='color:red;'>未开通</span>]";
                    node.Text = Model.UserCode + Model.TrueName+dd;
                    node.NavigateUrl = "RecommendTree.aspx?userid=" + Model.UserID;
                }
                else
                {
                    //node.Text = Model.UserCode + Model.TrueName + dd + "[个人]:" + Model.RegMoney + "[左总]:" + Model.LeftScore + "[右总]:" + Model.RightScore + "[左余]" + Model.LeftBalance + "[右余]" + Model.RightBalance + "[左新]" + Model.LeftNewScore + "[右新]" + Model.RightNewScore;
                    node.Text = Model.UserCode + Model.TrueName + dd + "[已开通][左区总业绩]" + Model.LeftScore + "[右区总业绩]" + Model.RightScore + "[左新业绩]" + Model.LeftNewScore + "[右新业绩]" + Model.RightNewScore;
                    node.NavigateUrl = "RecommendTree.aspx?userid=" + Model.UserID;
                }
              
            }

            IList<lgk.Model.tb_user> list = userBLL.GetModelList(" ParentID = " + userBLL.GetModel(uid).UserID + " and Layer>=" + Model.Layer + "");
            if (list == null)
            {
                return null;
            }
            foreach (lgk.Model.tb_user item in list)
            {
                node.ChildNodes.Add(getTree(Convert.ToInt32(item.UserID)));
            }
            return node;
        }

        #region 搜索
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    int UserID = getLoginID();
        //    string uName = this.txtUserCode.Text.Trim();
        //    if (UserID == 2)
        //    {
        //        if (!string.IsNullOrEmpty(uName))
        //        {
        //            if (GetUserID(uName) > 0)
        //            {
        //                UserID = GetUserID(uName);
        //                TreeView1.Nodes.Clear();
        //                this.TreeView1.Nodes.Add(getTree(UserID));
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("WantUserIsNull") + "');", true);//您要查询的会员编号不存在
        //            }
        //        }
        //    }
        //    else
        //    {

        //        if (!string.IsNullOrEmpty(uName))
        //        {
        //            if (GetUserID(uName) > 0)
        //            {
        //                if (checkName(GetUserID(uName)))
        //                {
        //                    UserID = GetUserID(uName);
        //                    TreeView1.Nodes.Clear();
        //                    this.TreeView1.Nodes.Add(getTree(UserID));
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("WantUserIsdownline") + "');window.location.href='RecommendTree.aspx'", true);//您要查询的会员编号不在您的下线
        //                }
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("WantUserIsNull") + "');window.location.href='RecommendTree.aspx'", true);//您要查询的会员编号不存在
        //            }
        //        }
        //    }
        //} 
        #endregion

        private bool checkName(int p)
        {
            bool result = false;
            string strPath = DbHelperSQL.GetSingle("select RecommendPath from tb_user where UserID =" + getLoginID()).ToString();
            string strSql = string.Format("select count(0) from tb_user where RecommendPath like '%{0}%' and UserID={1}", getLoginID(), p);
            if (int.Parse(DbHelperSQL.GetSingle(strSql).ToString()) > 0)
            {
                result = true;
            }
            return result;
        }

        protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            Response.Write("<script>parent.document.all('mainFrame').style.height=document.body.scrollHeight+1;</script>");
        }

    }
}