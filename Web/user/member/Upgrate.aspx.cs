using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data.SqlClient;
using System.Data;

namespace Web.user.member
{
    public partial class Upgrate : PageCore
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转三级密码
            if (!IsPostBack)
            {
                ShowInfo();
                BindLevel();
                btnSubmit.Enabled = false;
            }
        }
        private void ShowInfo() // 显示会员编号、开通时间、等级信息
        {
            txtUserCode.Value = LoginUser.UserCode;
            int level = LoginUser.LevelID > (int)LoginUser.User017 ? LoginUser.LevelID : (int)LoginUser.User017;
            txtPresentLevel.Value = levelBLL.GetLevelName(level);
        }
        private void BindLevel() // 绑定用户等级
        {
            IList<lgk.Model.tb_level> List = new lgk.BLL.tb_level().GetModelList("");
            DropDownList1.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "-1";
            li.Text = "-请选择-";
            DropDownList1.Items.Add(li);
            foreach (lgk.Model.tb_level item in List)
            {
                ListItem items = new ListItem();
                items.Value = item.LevelID.ToString();
                items.Text = item.LevelName;
                DropDownList1.Items.Add(items);
            }
        }
        // 选择的升级的等级是否大于当前等级且大于User017(后台调整的等级)
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newLevel = int.Parse(DropDownList1.SelectedValue);
            if (newLevel > LoginUser.LevelID && newLevel > (int)(LoginUser.User017))
            {
                switch (DropDownList1.SelectedValue)
                {
                    case "0": PayFor(); btnSubmit.Enabled = true; break;
                    case "1": PayFor(); btnSubmit.Enabled = true; break;
                    case "2": PayFor(); btnSubmit.Enabled = true; break;
                    case "3": PayFor(); btnSubmit.Enabled = true; break;
                    default: txtPayFor.Value = string.Empty; break;
                }
            }
            else
            {
                btnSubmit.Enabled = false;
                DropDownList1.SelectedIndex = 0;
                Response.Write("<script>alert('升级等级低于当前等级');location.href=Upgrade.aspx;</script>");
            }
        }
        // 付款=升级至某等级的投资额-当前等级的投资额
        private void PayFor()
        {
            int oldUser017 = (int)(LoginUser.User017);
            int oldLevel = LoginUser.LevelID > oldUser017 ? LoginUser.LevelID : oldUser017;
            decimal payFor = getParamAmount("VIP" + DropDownList1.SelectedValue.ToString()) - getParamAmount("VIP" + LoginUser.LevelID.ToString());
            txtPayFor.Value = "注册币：" + payFor;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int nlevel = Convert.ToInt32(DropDownList1.SelectedValue); // 新等级
            int oldUser017 = (int)(LoginUser.User017);
            int oldLevel = LoginUser.LevelID > oldUser017 ? LoginUser.LevelID : oldUser017; // 取会员原等级与后台调整的等级最大值
            lgk.Model.tb_user model = userBLL.GetModel(getLoginID());
            if (oldLevel< nlevel)
            {
                int newLevelID = int.Parse(DropDownList1.SelectedValue);
                if (newLevelID < 0)
                {
                    DropDownList1.SelectedIndex = 0;
                    Response.Write("<script>alert('请选择升级等级');location.href=Upgrade.aspx;</script>");
                    return;
                }
                decimal pay = levelBLL.GetModel(newLevelID).RegMoney - levelBLL.GetModel(oldLevel).RegMoney;
                decimal newRegMoney = levelBLL.GetModel(newLevelID).RegMoney;
                if (newLevelID >= 0 && (LoginUser.Emoney >= pay)) // 扣除100%注册币
                {
                    // 存储过程，传入UID,newRegMoney,selectedValue
                    if (bonusBLL.Upgrade(LoginUser.UserID, newRegMoney, newLevelID) > 0)
                    {
                        DropDownList1.SelectedIndex = 0;
                        lgk.BLL.tb_user B_user = new lgk.BLL.tb_user();
                        lgk.Model.tb_user model_ = userBLL.GetModel(getLoginID());//选择的人
                        long UserID = long.Parse(getLoginID().ToString());

                        #region 线上升级判断升级
                        string path = model_.UserPath;
                        string[] ID = path.Split('-');
                        foreach (var id in ID)
                        {
                            if (id == UserID.ToString())
                            {
                                continue;
                            }
                            lgk.Model.tb_user model_1 = userBLL.GetModel(long.Parse(id)); //头上的人
                            if (id == model_.ParentID.ToString())//倒数第二层特殊处理
                            {
                                int zy = model_.Location;

                                if (zy == 1)
                                {
                                    
                                    string sql9 = "select * from tb_user where  ParentID=" + id + "";
                                    DataTable dt9 = userBLL.getData_Chaxun(sql9, "").Tables[0];
                                    if (dt9.Rows.Count == 2)
                                    {
                                        SqlConnection conn = new SqlConnection(sconn);
                                        conn.Open();
                                        string sql1 = string.Format("select * from tb_agent1 where AgentCode='" + model_1.UserCode + "'");
                                        SqlDataAdapter da = new SqlDataAdapter(sql1, conn);
                                        DataTable dt1 = new DataTable();
                                        da.Fill(dt1);
                                        conn.Close();



                                        if (dt1.Rows.Count == 4)
                                        {
                                            continue;
                                        }
                                        if (dt1.Rows.Count == 0)
                                        {
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static0") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql11 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 1 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql11, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static0") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 1 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }

                                        if (dt1.Rows.Count == 1)
                                        {
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static1") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql11 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 2 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql11, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static1") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 2 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                        if (dt1.Rows.Count == 2)
                                        {
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static2") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql11 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 3 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql11, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static2") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 3 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                        if (dt1.Rows.Count == 3)
                                        {
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static3") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql11 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 4 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql11, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static3") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 4 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                    }
                                    continue;
                                }
                                if (zy == 2)
                                {
                                  
                                    string sql9 = "select * from tb_user where  ParentID=" + id + "";
                                    DataTable dt9 = userBLL.getData_Chaxun(sql9, "").Tables[0];
                                    if (dt9.Rows.Count == 2)
                                    {
                                        SqlConnection conn = new SqlConnection(sconn);
                                        conn.Open();
                                        string sql11 = string.Format("select * from tb_agent1 where AgentCode='" + model_1.UserCode + "'");
                                        SqlDataAdapter da = new SqlDataAdapter(sql11, conn);
                                        DataTable dt11 = new DataTable();
                                        da.Fill(dt11);
                                        conn.Close();


                                        if (dt11.Rows.Count == 4)
                                        {
                                            continue;
                                        }
                                        if (dt11.Rows.Count == 0)
                                        {
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static0") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 1 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static0") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 1 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }

                                        if (dt11.Rows.Count == 1)
                                        {
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static1") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 2 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static1") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 2 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                        if (dt11.Rows.Count == 2)
                                        {
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static2") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 3 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static2") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 3 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                        if (dt11.Rows.Count == 3)
                                        {
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static3") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 4 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static3") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "','" + model_1.UserID + "','" + 4 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                    }
                                    continue;
                                }

                                continue;
                            }

                            string sql = "select * from tb_user  where ParentID = '" + id + "' order by Location";
                            DataSet ds = B_user.getData_Chaxun(sql, "");
                            DataTable dt = ds.Tables[0];
                            if (dt.Rows.Count < 2)
                            { 
                                string sql9 = "select * from tb_user where  ParentID=" + id + "";
                                DataTable dt9 = userBLL.getData_Chaxun(sql9, "").Tables[0];
                                if (dt9.Rows.Count == 2)
                                {
                                    SqlConnection conn = new SqlConnection(sconn);
                                    conn.Open();
                                    string sql1 = string.Format("select * from tb_agent1 where AgentCode='" + model_1.UserCode + "'");
                                    SqlDataAdapter da = new SqlDataAdapter(sql1, conn);
                                    DataTable dt1 = new DataTable();
                                    da.Fill(dt1);
                                    conn.Close();


                                    if (dt1.Rows.Count == 4)
                                    {
                                        continue;
                                    }
                                    if (dt1.Rows.Count == 0)
                                    {
                                        if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static0") * 10000)
                                        {
                                            SqlConnection conn1 = new SqlConnection(sconn);
                                            conn1.Open();
                                            string sql11 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 1 + "',getdate() )";
                                            SqlCommand cmd = new SqlCommand(sql11, conn1);
                                            int reInt = cmd.ExecuteNonQuery();
                                            conn1.Close();
                                        }
                                        if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static0") * 10000)
                                        {
                                            SqlConnection conn1 = new SqlConnection(sconn);
                                            conn1.Open();
                                            string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 1 + "',getdate() )";
                                            SqlCommand cmd = new SqlCommand(sql111, conn1);
                                            int reInt = cmd.ExecuteNonQuery();
                                            conn1.Close();
                                        }
                                    }

                                    if (dt1.Rows.Count == 1)
                                    {
                                        if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static1") * 10000)
                                        {
                                            SqlConnection conn1 = new SqlConnection(sconn);
                                            conn1.Open();
                                            string sql11 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 2 + "',getdate() )";
                                            SqlCommand cmd = new SqlCommand(sql11, conn1);
                                            int reInt = cmd.ExecuteNonQuery();
                                            conn1.Close();
                                        }
                                        if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static1") * 10000)
                                        {
                                            SqlConnection conn1 = new SqlConnection(sconn);
                                            conn1.Open();
                                            string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 2 + "',getdate() )";
                                            SqlCommand cmd = new SqlCommand(sql111, conn1);
                                            int reInt = cmd.ExecuteNonQuery();
                                            conn1.Close();
                                        }
                                    }
                                    if (dt1.Rows.Count == 2)
                                    {
                                        if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static2") * 10000)
                                        {
                                            SqlConnection conn1 = new SqlConnection(sconn);
                                            conn1.Open();
                                            string sql11 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 3 + "',getdate() )";
                                            SqlCommand cmd = new SqlCommand(sql11, conn1);
                                            int reInt = cmd.ExecuteNonQuery();
                                            conn1.Close();
                                        }
                                        if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static2") * 10000)
                                        {
                                            SqlConnection conn1 = new SqlConnection(sconn);
                                            conn1.Open();
                                            string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 3 + "',getdate() )";
                                            SqlCommand cmd = new SqlCommand(sql111, conn1);
                                            int reInt = cmd.ExecuteNonQuery();
                                            conn1.Close();
                                        }
                                    }
                                    if (dt1.Rows.Count == 3)
                                    {
                                        if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static3") * 10000)
                                        {
                                            SqlConnection conn1 = new SqlConnection(sconn);
                                            conn1.Open();
                                            string sql11 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 4 + "',getdate() )";
                                            SqlCommand cmd = new SqlCommand(sql11, conn1);
                                            int reInt = cmd.ExecuteNonQuery();
                                            conn1.Close();
                                        }
                                        if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static3") * 10000)
                                        {
                                            SqlConnection conn1 = new SqlConnection(sconn);
                                            conn1.Open();
                                            string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 4 + "',getdate() )";
                                            SqlCommand cmd = new SqlCommand(sql111, conn1);
                                            int reInt = cmd.ExecuteNonQuery();
                                            conn1.Close();
                                        }
                                    }
                                }
                                continue;
                            }
                            if (dt.Rows.Count == 2)
                            {
                                string zuo = dt.Rows[0]["UserID"].ToString();
                                string you = dt.Rows[1]["UserID"].ToString();
                                string sql1 = "select * from tb_user  where UserID = '" + UserID + "' and UserPath like '%" + zuo + "%'  ;select * from tb_user  where UserID = '" + UserID + "' and UserPath like '%" + you + "%';";
                                DataSet ds1 = B_user.getData_Chaxun(sql1, "");
                                DataTable dt1 = ds1.Tables[0];
                                DataTable dt2 = ds1.Tables[1];
                                if (dt1.Rows.Count > 0)
                                {
                                    


                                    string sql9 = "select * from tb_user where  ParentID=" + id + "";
                                    DataTable dt9 = userBLL.getData_Chaxun(sql9, "").Tables[0];
                                    if (dt9.Rows.Count == 2)
                                    {
                                        SqlConnection conn = new SqlConnection(sconn);
                                        conn.Open();
                                        string sql11 = string.Format("select * from tb_agent1 where AgentCode='" + model_1.UserCode + "'");
                                        SqlDataAdapter da = new SqlDataAdapter(sql11, conn);
                                        DataTable dt11 = new DataTable();
                                        da.Fill(dt11);
                                        conn.Close();


                                        if (dt11.Rows.Count == 4)
                                        {
                                            continue;
                                        }
                                        if (dt11.Rows.Count == 0)
                                        {
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static0") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 1 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static0") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 1 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }

                                        if (dt11.Rows.Count == 1)
                                        {
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static1") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 2 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static1") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 2 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                        if (dt11.Rows.Count == 2)
                                        {
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static2") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 3 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static2") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 3 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                        if (dt11.Rows.Count == 3)
                                        {
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static3") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 4 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static3") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 4 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                    }
                                    continue;
                                }
                                if (dt2.Rows.Count > 0)
                                { 
                                    string sql9 = "select * from tb_user where  ParentID=" + id + "";
                                    DataTable dt9 = userBLL.getData_Chaxun(sql9, "").Tables[0];
                                    if (dt9.Rows.Count == 2)
                                    {

                                        SqlConnection conn = new SqlConnection(sconn);
                                        conn.Open();
                                        string sql11 = string.Format("select * from tb_agent1 where AgentCode='" + model_1.UserCode + "'");
                                        SqlDataAdapter da = new SqlDataAdapter(sql11, conn);
                                        DataTable dt11 = new DataTable();
                                        da.Fill(dt11);
                                        conn.Close();


                                        if (dt11.Rows.Count == 4)
                                        {
                                            continue;
                                        }
                                        if (dt11.Rows.Count == 0)
                                        {
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static0") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 1 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static0") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 1 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }

                                        if (dt11.Rows.Count == 1)
                                        {
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static1") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 2 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static1") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 2 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                        if (dt11.Rows.Count == 2)
                                        {
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static2") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 3 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static2") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 3 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                        if (dt11.Rows.Count == 3)
                                        {
                                            if (model_1.RightScore >= model_1.LeftScore && model_1.LeftScore >= getParamAmount("Static3") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 4 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                            if (model_1.LeftScore > model_1.RightScore && model_1.RightScore > getParamAmount("Static3") * 10000)
                                            {
                                                SqlConnection conn1 = new SqlConnection(sconn);
                                                conn1.Open();
                                                string sql111 = "insert into tb_agent1(AgentCode,Flag,UserID,AgentType,OpenTime)values('" + model_1.UserCode + "','" + 1 + "'," + model_1.UserID + ",'" + 4 + "',getdate() )";
                                                SqlCommand cmd = new SqlCommand(sql111, conn1);
                                                int reInt = cmd.ExecuteNonQuery();
                                                conn1.Close();
                                            }
                                        }
                                    }
                                    continue;
                                }
                            }
                        }
                        #endregion

                        Response.Write("<script>alert('升级成功');location.href=Upgrade.aspx;</script>");
                    }
                    else
                    {
                        DropDownList1.SelectedIndex = 0;
                        Response.Write("<script>alert('升级失败');location.href=Upgrade.aspx;</script>");
                    }
                }
                else
                {
                    DropDownList1.SelectedIndex = 0;
                    Response.Write("<script>alert('注册币不足');location.href=Upgrade.aspx;</script>");
                }
            }
            else
            {
                DropDownList1.SelectedIndex = 0;
                Response.Write("<script>alert('升级等级小于当前等级');location.href=Upgrade.aspx;</script>");
            }
        }
    }
}