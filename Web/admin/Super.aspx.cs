using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using System.Text;
using System.IO;
using System.Data;

namespace Web.admin
{
    public partial class Super : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void update(string sql)
        {
            try
            {
                DataAccess.DbHelperSQL.ExecuteSql(sql);

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('更新成功。');", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected DataSet query(string sql)
        {
            try
            {
                return DataAccess.DbHelperSQL.Query(sql);

              //  ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('查询成功。');", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            update(TextBox1.Text);
            //string sql = GetUpdateSql("update1.sql");
            //update(sql);
        }

        private string GetUpdateSql(string fname)
        {
            string sql,filename = Server.MapPath("./") + fname;
            try
            {
                StreamReader sr = new System.IO.StreamReader(filename);

                using (StreamReader reader = File.OpenText(filename))
                {
                    sql = reader.ReadToEnd();
                    reader.Close();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sql;
        }

        protected void update2_Click(object sender, EventArgs e)
        {
            string sql = GetUpdateSql("update.sql");
            Repeater1.DataSource = query(sql);
            Repeater1.DataBind(); 
        }

        protected void update3_Click(object sender, EventArgs e)
        {
            CreateParamInsertSQL();
          //  update(sql);
        }

        protected void update4_Click(object sender, EventArgs e)
        {
            string sql = GetUpdateSql("update4.sql");
            update(sql);
        }

        protected void update5_Click(object sender, EventArgs e)
        {
            string sql = GetUpdateSql("update5.sql");
            update(sql);
        }

        protected void update6_Click(object sender, EventArgs e)
        {
            string sql = GetUpdateSql("update6.sql");
            update(sql);
        }

        protected void update7_Click(object sender, EventArgs e)
        {
            string sql = GetUpdateSql("update7.sql");
            update(sql);
        }

        private void CreateParamInsertSQL()
        {
            string strinsert = "INSERT INTO [tb_globeParam]([ParamName] ,[ParamAmount] ,[ParamInt],[ParamVarchar] ,[Remark]  ,[EndRemark]  ,[ParamType],[IsEdit])";
            string sql = "";
            string insertvalue ="";

            DataSet paramlist = DataAccess.DbHelperSQL.Query("select [ParamName] ,[ParamAmount] ,[ParamInt],[ParamVarchar] ,[Remark]  ,[EndRemark]  ,[ParamType],[IsEdit] from tb_globeParam");

            for(int i=0 ;i< paramlist.Tables[0].Rows.Count;i++)
            {
                insertvalue = "values(";
                DataRow dr = paramlist.Tables[0].Rows[i];
                for(int j =0 ;j< paramlist.Tables[0].Columns.Count;j ++)
                {
                    insertvalue += "'"+dr[j].ToString()+"',";
                }
                insertvalue = insertvalue.TrimEnd(',');
                insertvalue += ")";
                sql += strinsert + insertvalue;

            }
            string sss = sql;

        }

        protected void update8_Click(object sender, EventArgs e)
        {
            string sql = GetUpdateSql("update3.sql");
            update(sql);
        }

        protected void update9_Click(object sender, EventArgs e)
        {
            string sql = GetUpdateSql("update9.sql");
            update(sql);
        }

    }
}