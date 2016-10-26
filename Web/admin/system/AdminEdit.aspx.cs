/*********************************************************************************
*Copyright(c) 	2012 ZXHLRJ.COM
 * �������ڣ�		2012-6-5 12:05:33
 * �� �� ����		AdminEdit.cs
 * CLR �汾:		2.0.50727.3053
 * �� �� �ˣ�		
 * �ļ��汾��		1.0.0.0
 * �� �� �ˣ� 
 * �޸����ڣ� 
 * ��ע������ 
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Library;
namespace Web.admin.system
{
    public partial class AdminEdit : AdminPageBase
    {
        lgk.BLL.tb_power powerBLL = new lgk.BLL.tb_power();//Ȩ��
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 32, getLoginID());//Ȩ��
            spd.jumpAdminUrl1(this.Page, 1);//��ת��������

            tvAdminTree.Attributes.Add("onclick", "postBackByObject()");
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
                {
                    lblPrompt.Text = "�ܴaΪ�����ǲ��޸�";
                    txtUserCode.ReadOnly = true;
                    BindInfo(Request.QueryString["id"]);
                }
                else
                {
                    txtUserCode.ReadOnly = false;
                }
                getDataSource();
                BindTree();
            }
        }

        protected void BindInfo(string id)
        {
            lgk.Model.tb_admin admin = adminBLL.GetModel(int.Parse(id));
            txtUserCode.Text = admin.UserName;
            txtName.Text = admin.TrueName;
        }
        void getDataSource()
        {

            DataTable dt = powerBLL.GetList("").Tables[0];
            ViewState["dt"] = dt;
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null && Request.QueryString["id"] != "1")
            {
                lgk.Model.tb_admin admin = adminBLL.GetModel(int.Parse(Request.QueryString["id"]));

                if (admin.Limits != null && admin.Limits != "")
                {
                    ViewState["limits"] = admin.Limits.Split(',');
                }
                else
                {
                    ViewState["limits"] = new string[] { "0" };
                }
            }
            else
            {
                ViewState["limits"] = new string[] { "0" };
            }


        }
        DataTable dt_allPower
        {
            get
            {
                return ViewState["dt"] as DataTable;
            }
        }
        string[] str_limits
        {
            get
            {
                return (string[])ViewState["limits"];
            }
        }
        public void BindTree()
        {
            InitTreeView(dt_allPower);
        }

        /// <summary>
        /// ��ʼ�����ΈD
        /// </summary>
        /// <param name="dt"></param>
        private void InitTreeView(DataTable dt)
        {
            if (dt == null)
            {
                return;
            }
            if (dt.Rows.Count == 0)
            {
                return;
            }

            //TreeNode rootNode = new TreeNode("Root");

            DataTable powers = powerBLL.GetList(string.Format("ParentID = {0}", 0)).Tables[0];
            for (int i = 0; i < powers.Rows.Count; i++)
            {
                int id = int.Parse(powers.Rows[i]["ID"].ToString());
                string text = powers.Rows[i]["MenuName"].ToString();
                TreeNode childNode = new TreeNode(text, id.ToString());
                childNode.ShowCheckBox = true;
                if (isChecked(id.ToString()))
                {
                    childNode.Checked = true;
                }
                if (childNode != null)
                {
                    AddChilds(childNode, id);
                }
                //rootNode.ChildNodes.Add(childNode);
                tvAdminTree.Nodes.Add(childNode);
            }
            //tvAdminTree.Nodes.Add(rootNode);
        }

        private void AddChilds(TreeNode pNode, int pid)
        {
            DataTable powers = powerBLL.GetList(string.Format("ParentID = {0}", pid)).Tables[0];
            if (powers != null)
            {
                for (int i = 0; i < powers.Rows.Count; i++)
                {
                    string text = powers.Rows[i]["MenuName"].ToString();
                    string id = powers.Rows[i]["ID"].ToString();
                    TreeNode childNode = new TreeNode(text, id);
                    childNode.ShowCheckBox = true;

                    if (isChecked(id))
                    {
                        childNode.Checked = true;
                    }
                    pNode.ChildNodes.Add(childNode);
                }
            }
        }

        private bool isChecked(string id)
        {
            for (int i = 0; i < str_limits.Length; i++)
            {
                if (id == str_limits[i])
                {
                    return true;
                }
            }
            return false;
        }
        ///// <summary>
        /////�ݹ�����ӽڵ�
        ///// </summary>
        ///// <param name="node"></param>
        ///// <param name="dt"></param>
        //private void AddChildNodes(TreeNode node, DataTable dt)
        //{
        //    if (node.Value.ToString() == "0")
        //    {
        //        return;
        //    }
        //    DataRow[] drList = dt.Select("ParentID =" + node.Value);
        //    foreach (DataRow dr in drList)
        //    {
        //        TreeNode cNode = new BLL.LimitsTreeNodeBLL(dr, str_limits);
        //        node.ChildNodes.Add(cNode);
        //        AddChildNodes(cNode, dt);
        //    }

        //}


        private void AddReg(TreeNode tn, DataTable dt)
        {
            if (tn.Value.ToString() == "0")
            {
                return;
            }
        }
        /// <summary>
        /// ���水ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//��ת��������

            string limitsid = "";
            foreach (TreeNode node in tvAdminTree.Nodes)
            {
                if (node.Checked == true)
                {
                    limitsid += node.Value;
                    limitsid += ",";
                }
                foreach (TreeNode childNode in node.ChildNodes)
                {
                    if (childNode.Checked == true)
                    {
                        limitsid += childNode.Value;
                        limitsid += ",";
                    }
                }
            }
            if (limitsid.Length > 0)
            {
                limitsid = limitsid.Substring(0, limitsid.Length - 1);
            }
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null && Request.QueryString["id"] != "1")
            {
                if (ValidateUpdate())//����
                {
                    lgk.Model.tb_admin admin = adminBLL.GetModel(int.Parse(Request.QueryString["id"]));
                    admin.TrueName = txtName.Text;
                    if (txtPass.Text.Trim().Length > 0)
                    {
                        admin.Password = PageValidate.GetMd5(txtPass.Text);
                    }
                    if (txtSecondPass.Text.Trim().Length > 0)
                    {
                        admin.SecondPassword = PageValidate.GetMd5(txtSecondPass.Text);
                    }
                    if (txtThirdPass.Text.Trim().Length > 0)
                    {
                        admin.ThirdPassword = PageValidate.GetMd5(txtThirdPass.Text);
                    }
                    admin.Limits = limitsid;
                    if (adminBLL.Update(admin))
                    {
                        MessageBox.ShowAndRedirect(this, "�޸ĳɹ�!", "AdminManage.aspx");
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "succeed", "alert('�޸ĳɹ�!')window.location='AdminManage.aspx'", true);
                        //Response.Redirect("AdminManage.aspx");
                    }
                    else
                    {
                        MessageBox.Show(this, "�޸�ʧ��!");
                        return;
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "fail", "alert('�޸�ʧ��!')", true);
                    }
                }

            }
            else
            {

                if (ValidateAdd())//���
                {
                    lgk.Model.tb_admin admin = new lgk.Model.tb_admin();
                    admin.UserName = txtUserCode.Text.Trim();
                    admin.TrueName = txtName.Text.Trim();
                    admin.Password = PageValidate.GetMd5(txtPass.Text.Trim());
                    admin.SecondPassword = PageValidate.GetMd5(txtSecondPass.Text.Trim());
                    admin.Limits = limitsid;
                    admin.AddDate = DateTime.Now;
                    admin.ThirdPassword = PageValidate.GetMd5(this.txtThirdPass.Text.Trim());
                    if (adminBLL.Add(admin) > 0)
                    {
                        MessageBox.ShowAndRedirect(this, "����Ա��ӳɹ�!", "AdminManage.aspx");
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "succeed", "alert('����Ա��ӳɹ�!');window.location='AdminManage.aspx'", true);
                    }
                    else
                    {
                        MessageBox.Show(this, "����Ա���ʧ��!");
                        return;
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "fail", "alert('����Ա���ʧ��!')", true);
                    }
                }

            }
        }

        /// <summary>
        /// ��֤���
        /// </summary>
        /// <returns></returns>
        public bool ValidateAdd()
        {
            if (txtUserCode.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "����Ա��Ų���Ϊ��");
                return false;
            }

            lgk.Model.tb_admin admin = adminBLL.GetModel(txtUserCode.Text);
            if (admin != null)
            {
                MessageBox.Show(this, "�Ѵ��ڵĹ���Ա���");
                return false;
            }

            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "����Ա��������Ϊ��");
                return false;
            }

            if (txtPass.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "��¼���벻��Ϊ��");
                return false;
            }

            if (txtPass.Text != txtRPass.Text)
            {
                MessageBox.Show(this, "��������ĵ�¼���벻һ��");
                return false;
            }

            if (txtSecondPass.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "�������벻��Ϊ��");
                return false;
            }

            if (txtSecondPass.Text != txtRSecondPass.Text)
            {
                MessageBox.Show(this, "��������Ķ������벻һ��");
                return false;
            }
            if (txtThirdPass.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "�������벻��Ϊ��");
                return false;
            }

            if (txtThirdPass.Text != txtRThirdPass.Text)
            {
                MessageBox.Show(this, "����������������벻һ��");
                return false;
            }
            return true;
        }

        /// <summary>
        /// ��֤����
        /// </summary>
        /// <returns></returns>
        public bool ValidateUpdate()
        {
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "����Ա��������Ϊ��");
                return false;
            }
            if (txtPass.Text != txtRPass.Text)
            {
                MessageBox.Show(this, "��������ĵ�¼���벻һ��");
                return false;
            }

            if (txtSecondPass.Text != txtRSecondPass.Text)
            {
                MessageBox.Show(this, "��������Ķ������벻һ��");
                return false;
            }
            if (txtThirdPass.Text != txtRThirdPass.Text)
            {
                MessageBox.Show(this, "����������������벻һ��");
                return false;
            }
            return true;
        }
        /// <summary>
        /// ȫѡ��ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvAdminTree.Nodes)
            {
                foreach (TreeNode childNode in node.ChildNodes)
                {
                    childNode.Checked = ckCheck.Checked;
                }
                node.Checked = ckCheck.Checked;
            }
            ckUnCheck.Checked = false;
        }
        /// <summary>
        /// ��ѡ��ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckUnCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvAdminTree.Nodes)
            {
                foreach (TreeNode childNode in node.ChildNodes)
                {
                    if (childNode.Checked == true)
                    {
                        childNode.Checked = false;
                    }
                    else
                    {
                        childNode.Checked = true;
                    }
                }

                if (node.Checked == true)
                {
                    node.Checked = false;
                }
                else
                {
                    node.Checked = true;
                }
            }
            ckCheck.Checked = false;
        }

        /// <summary>
        /// ���ڵ�ȫѡ�ӽڵ�Ҳȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvAdminTree_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            //if (e.Node.Value == "0")
            //{
            //    foreach (TreeNode node in e.Node.ChildNodes)
            //    {
            //        node.Checked = e.Node.Checked;
            //    }
            //}
            bool isChecked = e.Node.Checked;
            if (e.Node.ChildNodes.Count > 0)
            {
                foreach (TreeNode node in e.Node.ChildNodes)
                {
                    node.Checked = isChecked;
                }
            }
            bool ischeck = false;
            TreeNodeCollection vNodes; // ���ڽڵ��б�
            if (e.Node.Parent != null) // ���ڵ�
            {
                vNodes = e.Node.Parent.ChildNodes;
                foreach (TreeNode node in vNodes)
                {
                    if (node.Checked == true)
                    {
                        ischeck = true;
                        break;
                    }
                }
                e.Node.Parent.Checked = ischeck;
            }

        }

        protected void tvAdminTree_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "��ʾ", "<script>alert('ok');</script>",true);
            //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "", "setTopLoad()", true);
            ScriptManager.RegisterClientScriptBlock(this, typeof(string), "tishi", "setTopLoad()", true);
        }
    }
}
