using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lgk.Model;
using lgk.BLL;
using Library;

namespace Web.user.team
{
    public partial class RecommendTree_1 : PageCore
    {
        private int x = 1;
        private int y = 2;
        private int z = 3;
        private static int _selectPlatform = 3;
        public int hasChild = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码
            
            if (!IsPostBack)
            {
                BindTreeRe();
                x = GetID();
                ViewState["x"] = x;
                ViewState["y"] = y;
                ViewState["z"] = z;
            }
            else
            {
                x = int.Parse(ViewState["x"].ToString());
                y = int.Parse(ViewState["y"].ToString());
                z = int.Parse(ViewState["z"].ToString());
            }
        }

        private void BindTreeRe()
        {
            int id = int.Parse(getLoginID().ToString());
            lgk.BLL.UserView uview = new UserView(id, y, z, _selectPlatform, 1, "zh-cn");
            Literal1.Text = uview.AddTable();
        }

        private int GetID()
        {
            if (getIntRequest("tt") != 0)
            {
                return getIntRequest("tt");
            }
            return 1;
        }

        private void BindTree1()
        {
            int id = int.Parse(getLoginID().ToString());
            UserView uview = new UserView(id, y, z, _selectPlatform, 1, "zh-cn");
            Literal1.Text = uview.AddTable();
        }
        private void BindTree()
        {
           
            UserView uview = new UserView(x, y, z, _selectPlatform, 1, "zh-cn");
            Literal1.Text = uview.AddTable();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtUserCode.Text != "")
            {
                int xNode = GetUserID(txtUserCode.Text);
                if (xNode != 0)
                {
                    //ArrayList bli = getli(TextBox1.Text);
                    x = xNode;
                    ViewState["x"] = x;
                    BindTree();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('没有这个用户!');", true);
                    BindTree();
                }
            }
            else
            {
                x = 1;
                ViewState["x"] = x;
                BindTree();
            }
        }

        protected void btnMy_Click(object sender, EventArgs e)
        {
            BindTreeRe();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            z = z - 1;
            if (z < 2) z = 2;
            ViewState["z"] = z;
            BindTree();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "11", "parent.document.all('mainFrame').style.height=document.body.scrollHeight;", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            z = z + 1;
            ViewState["z"] = z;
            BindTree();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "11", "parent.document.all('mainFrame').style.height=document.body.scrollHeight;", true);
        }

    }
}