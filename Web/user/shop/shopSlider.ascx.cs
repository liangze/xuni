using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Library;

namespace Web.user.shop
{
    public partial class shopSlider : System.Web.UI.UserControl
    {
        AllCore ac = new AllCore();
        public string cnen = "zh-cn";
        public lgk.BLL.tb_produceType produceTypeBLL = new lgk.BLL.tb_produceType();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllLanguage();
            if (!IsPostBack)
            {
                BindProductType(produceTypeBLL.GetList(" ParentID=0"), Repeater_ProductParent);
            }
        }

        private void GetAllLanguage()
        {
            cnen = ac.GetLanguage("LoginLable");
            Label1.Text = ac.GetLanguage("ProductCategory");
        }

        private string SplitTypeName(string typename)
        {
            if (cnen == "zh-cn")
            {
                return typename.Split('-')[0];
            }
            else
            {
                return typename.Split('-')[1];
            }
        }

        /// <summary>
        /// 商品分类：一级类目
        /// </summary>
        /// <param name="dateSet">数据源</param>
        /// <param name="Repeater1">绑定的Repeater控件名</param>
        public void BindProductType(DataSet dateSet, Repeater Repeater1)
        {
            DataSet ds = dateSet;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataColumn newCol = new DataColumn();
                newCol.ColumnName = "url";
                dt.Columns.Add(newCol);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i]["ID"].ToString();

                    string typename = dt.Rows[i]["TypeName"].ToString();
                    string newname = SplitTypeName(typename);
                    dt.Rows[i]["TypeName"] = newname;

                    if (id == "39")
                    {
                        dt.Rows[i]["url"] = "Salesroom.aspx?payment=2";
                    }
                    else
                    {
                        if (id == "38")
                        {
                            dt.Rows[i]["url"] = "channel.aspx?type=" + id + "&payment=1";
                        }
                        else
                        {
                            dt.Rows[i]["url"] = "channel.aspx?type=" + id + "&payment=2";
                        }
                    }
                }
                Repeater1.Visible = true;
                Repeater1.DataSource = dt.DefaultView;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.Visible = false;
            }
        }

        /// <summary>
        /// 商品类型二级列表
        /// </summary>
        protected void Repeater_ProductParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //判断里层repeater处于外层repeater的哪个位置（ AlternatingItemTemplate，FooterTemplate，HeaderTemplate，，ItemTemplate，SeparatorTemplate）
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("Repeater_ProductChild") as Repeater;//找到里层的repeater对象
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
                DataSet ds = produceTypeBLL.GetList(" ParentID=" + rowv["ID"].ToString().Trim());//获取填充子类的id 
                DataTable dt = ds.Tables[0];

                DataColumn newCol = new DataColumn();
                newCol.ColumnName = "url";
                dt.Columns.Add(newCol);

                if (dt.Rows.Count <= 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["TypeName"] = "无分类商品";
                    dt.Rows.Add(dr);
                }
                else
                {
                    //DataColumn newCol = new DataColumn();
                    //newCol.ColumnName = "url";
                    //dt.Columns.Add(newCol);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string id = dt.Rows[i]["id"].ToString();

                        string typename = dt.Rows[i]["TypeName"].ToString();
                        string newname = SplitTypeName(typename);
                        dt.Rows[i]["TypeName"] = newname;

                        if (rowv["ID"].ToString().Trim() == "39")
                        {
                            dt.Rows[i]["url"] = "Salesroom.aspx?goodtype=" + id + "&payment=2";
                        }
                        else
                        {
                            if (dt.Rows[i]["ParentID"].ToString() == "38")
                            {
                                dt.Rows[i]["url"] = "channel.aspx?goodtype=" + id + "&payment=1";
                            }
                            else
                            {
                                dt.Rows[i]["url"] = "channel.aspx?goodtype=" + id + "&payment=2";
                            }
                        }
                    }
                }
                rep.DataSource = dt;
                rep.DataBind();
            }
        }

    }
}