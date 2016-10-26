/*********************************************************************************
*Copyright(c) 	2012 ZXHLRJ.COM
 * �������ڣ�		2012-6-5 9:40:49
 * �� �� ����		AdminManage.cs
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
using BLL;
using Library;

namespace Web.admin.system
{
    public partial class AdminManage : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 32, getLoginID());//Ȩ��
            spd.jumpAdminUrl(this.Page, 1);//��ת��������

            if (!IsPostBack)
            {
                BindAdmin();
            }
        }
        /// <summary>
        /// ������T���
        /// </summary>
        protected void BindAdmin()
        {
            bind_repeater(adminBLL.GetList("ID<>1"), rpAdmin, "AddDate desc", trNull, anpAdmin);
        }
        /// <summary>
        /// ��ӹ���T
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//��ת��������
            Response.Redirect("AdminEdit.aspx");
        }
        /// <summary>
        /// ��ҳ�ؼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindAdmin();
        }

        protected void rpAdmin_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            if (ID == getLoginID())
            {
                MessageBox.Show(this, "�޷�����");
                return;
            }
            if (e.CommandName.Equals("del"))//ɾ��
            {
                spd.jumpAdminUrl1(this.Page, 1);//��ת��������

                lgk.Model.tb_admin admin = adminBLL.GetModel(ID);
                if (adminBLL.Delete(admin.ID))
                {
                    MessageBox.ShowAndRedirect(this, "ɾ���ɹ�", "AdminManage.aspx");
                }
                else
                {
                    MessageBox.Show(this, "ɾ��ʧ��");
                }
            }
            else if (e.CommandName.Equals("modify"))
            {
                spd.jumpAdminUrl1(this.Page, 1);//��ת��������

                Response.Redirect("AdminEdit.aspx?id=" + ID);
            }
        }
    }
}
