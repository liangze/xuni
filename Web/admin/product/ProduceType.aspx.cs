/*********************************************************************************
*Copyright(c) 	2012 ZXHLRJ.COM
 * �������ڣ�		2012-5-10 15:38:04
 * �� �� ����		ProduceType.cs
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
using System.Drawing;

namespace web.admin.product
{
    public partial class ProduceType : AdminPageBase//System.Web.UI.Page//
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 55, getLoginID());//Ȩ��
            //spd.jumpAdminUrl(this.Page, 1);//��ת�����ܴa
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        ///��� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// �����ݵ�repeater2�ؼ�
        /// </summary>
        /// <param name="str"></param>
        private void BindData()
        {
            this.ddlPriduceType.DataSource = produceTypeBLL.GetList(" ParentID=0");
            this.ddlPriduceType.DataTextField = "TypeName";
            this.ddlPriduceType.DataValueField = "ID";
            this.ddlPriduceType.DataBind();
            bind_repeater(produceTypeBLL.GetList(" ParentID<>0"), Repeater1, "", span1, AspNetPager1);
        }

        /// <summary>
        /// �����Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPriduceType.Text))
            {
                MessageBox.Show(this, "���������������");
                return;
            }

            else
            {
                string Name = this.txtPriduceType.Text;
                int ParentID = ConvertToInt(this.ddlPriduceType.SelectedValue);
                lgk.Model.tb_produceType model = new lgk.Model.tb_produceType();
                model.TypeName = Name;
                model.ParentID = ParentID;
                if (produceTypeBLL.Add(model) > 0)
                {
                    MessageBox.Show(this, "��ӳɹ���");
                    BindData();
                    this.txtPriduceType.Text = "";
                }
            }
        }

        /// <summary>
        /// �󶨸��������
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public string GetParentName(object ParentID)
        {
            lgk.Model.tb_produceType model = produceTypeBLL.GetModel(ConvertToInt(ParentID));
            return model.TypeName;
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string name = e.CommandName.ToString();
            int id = Convert.ToInt32(e.CommandArgument);
            //string[] ids = id.Split(',');
            //int cid = int.Parse( ids[0]);
            //int pid = int.Parse(ids[1]);
            lgk.Model.tb_produceType model = produceTypeBLL.GetModel(id);
            if (name == "del")//ɾ��
            {
                int online = goodsBLL.GetModelList(" Goods001=1 and GoodsType=" + id).Count;
                int d = tb_SalesroomBll.GetModelList(" SaTargetPoint=" + id).Count;
                if (online > 0)// || tb_SalesroomBll.GetModelList(" SaTargetPoint=" + id).Count > 0)
                {
                    MessageBox.Show(this, "�����¼ܴ�����µ�������Ʒ����ɾ����");
                    return;
                }
                else
                {
                    if (id == 77 || id == 78 || id == 79)
                    {
                        //if (typeBLL.DeleteForHide(id))
                        //{
                        //    MessageBox.Show(this, "ɾ���ɹ���");
                        //}
                        MessageBox.Show(this, "�������ɾ����");
                        return;
                    }
                    else
                    {
                        int p2 = produceTypeBLL.GetModelList(" parentid=" + id).Count;
                        if (p2 > 0)
                        {
                            MessageBox.Show(this, "����ɾ��������µ��������");
                            return;
                        }
                        else if (produceTypeBLL.DeleteForHide(id))
                        {
                            MessageBox.Show(this, "ɾ���ɹ���");
                        }
                    }

                }
            }
            if (name == "Update")//�޸�
            {
                TextBox txt_des = (TextBox)e.Item.FindControl("txtTypeName");//��������
                if (string.IsNullOrEmpty(txt_des.Text))
                {
                    MessageBox.Show(this, "���������������");
                    return;
                }
                else
                {
                    model.TypeName = txt_des.Text.Trim();
                    if (produceTypeBLL.Update(model))
                    {
                        MessageBox.Show(this, "�༭�ɹ���");
                    }
                }
            }
            BindData();
        }


    }
}