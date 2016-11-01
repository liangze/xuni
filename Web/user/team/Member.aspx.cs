/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-7-15 11:46:41 
 * 文 件 名：		Member.cs 
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
using System.Data;

namespace Web.user.team
{
    public partial class Member : PageCore//System.Web.UI.Page
    {
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

            strWhere = " IsOpend=0  and User006 = '"+ model.UserCode + "';";//and AgentsID=" + Loginagent.ID
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

        /// <summary>
        /// 填充申请记录
        /// </summary>
        private void BindData()
        {
            bind_repeater(userBLL.GetList(GetWhere()), Repeater1, "RegTime desc", tr1, AspNetPager1);
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
        /// 审核分页申请记录
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long UserID = long.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_user model = userBLL.GetModel(UserID);
            if (model == null)
            {
                MessageBox.MyShow(this, GetLanguage("MemberDelete"));//该会员已删除,无法再进行此操作
                return;
            }
            if (model.IsOpend != 0)
            {
                MessageBox.MyShow(this, GetLanguage("MemberActivated"));//该会员已激活,无法再进行此操作
                return;
            }
            if (e.CommandName.Equals("open"))//
            {
                AllCore acore = new AllCore();//1收入2支出
                
                //开通会员检查
                int i = acore.OpenCheck(model);
                if (i != 0)
                {
                    MessageBox.MyShow(this, acore.OpenCheckErrorMsg(i));
                    return;
                }
                if (flag_open(UserID, 2) > 0)
                {
                    lgk.BLL.tb_user B_user = new lgk.BLL.tb_user();
                    lgk.Model.tb_user model_ = userBLL.GetModel(UserID);//选择的人
                     int dengji = model_.LevelID ;
                    if (dengji==1)
                    {
                        string sql = "select * from tb_globeParam where ParamName like 'dengji'";
                        DataSet ds = B_user.getData_Chaxun(sql,"");
                        model_.LeftScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        model_.RightScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());;
                        model_.RightNewScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        model_.LeftNewScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        userBLL.Update(model_);
                    }
                    if (dengji == 2)
                    {
                        string sql = "select * from tb_globeParam where ParamName like 'dengji1'";
                        DataSet ds = B_user.getData_Chaxun(sql, "");
                        model_.LeftScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        model_.RightScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString()); ;
                        model_.RightNewScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        model_.LeftNewScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        userBLL.Update(model_);
                    }
                    if (dengji == 3)
                    {
                        string sql = "select * from tb_globeParam where ParamName like 'dengji2'";
                        DataSet ds = B_user.getData_Chaxun(sql, "");
                        model_.LeftScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        model_.RightScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString()); ;
                        model_.RightNewScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        model_.LeftNewScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        userBLL.Update(model_);
                    }
                    if (dengji == 4)
                    {
                        string sql = "select * from tb_globeParam where ParamName like 'dengji3'";
                        DataSet ds = B_user.getData_Chaxun(sql, "");
                        model_.LeftScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        model_.RightScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString()); ;
                        model_.RightNewScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        model_.LeftNewScore = decimal.Parse(ds.Tables[0].Rows[0]["ParamVarchar"].ToString());
                        userBLL.Update(model_);
                    } 
                    string path = model_.RecommendPath;
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
                            if (zy==1)
                            {
                                model_1.LeftScore += model_.LeftScore;
                                model_1.LeftNewScore += model_.LeftNewScore;
                                userBLL.Update(model_1);
                                continue;
                            }
                            if (zy == 2)
                            {
                                model_1.RightScore += model_.RightScore;
                                model_1.RightNewScore += model_.RightNewScore;
                                userBLL.Update(model_1);
                                continue;
                            }
                            continue;
                        }
                       
                        string sql = "select * from tb_user  where ParentID = '"+id+ "' order by Location";
                        DataSet ds = B_user.getData_Chaxun(sql, "");
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count < 2)
                        { 
                            model_1.LeftScore += model_.LeftScore;
                            model_1.LeftNewScore += model_.LeftNewScore;
                            userBLL.Update(model_1);
                            continue;
                        }
                        if (dt.Rows.Count>=2)
                        {
                            string zuo = dt.Rows[0]["UserID"].ToString();
                            string you = dt.Rows[1]["UserID"].ToString();
                            string sql1 = "select * from tb_user  where UserID = '" + zuo + "';select * from tb_user  where UserID = '" + you + "';";
                            DataSet ds1 = B_user.getData_Chaxun(sql1, "");
                            DataTable dt1 = ds1.Tables[0];
                            DataTable dt2 = ds1.Tables[1];
                            if (dt1.Rows.Count > 0)
                            {
                                model_1.LeftScore += model_.LeftScore;
                                model_1.LeftNewScore += model_.LeftNewScore;
                                userBLL.Update(model_1);
                                continue;
                            }
                            if (dt2.Rows.Count > 0)
                            {
                                model_1.RightScore += model_.RightScore;
                                model_1.RightNewScore += model_.RightNewScore;
                                userBLL.Update(model_1);
                                continue;
                            }
                        } 
                    }
                  

                    acore.add_userRecord(model.UserCode, DateTime.Now, model.RegMoney, 2);


                   //对碰奖
                    MessageBox.MyShow(this, GetLanguage("OpenSuccess"));//开通成功
                }
                else 
                {
                    MessageBox.MyShow(this, GetLanguage("FailedToOpen")); //开通失败
                }
            }
            //if (e.CommandName.Equals("open1"))//
            //{
            //    model.IsOpend = 3;//空单3 实单 2
            //    model.OpenTime = DateTime.Now;
            //    model.User008 = "空单";
            //    if (userBLL.Update(model))
            //    {
            //        //AllCore acore = new AllCore();//1收入2支出
            //        //acore.add_userRecord(model.UserCode, DateTime.Now, 0, 2);
            //        MessageBox.MyShow(this, "开通空单成功!");
            //    }
            //    else { MessageBox.MyShow(this, "开通失败!"); }
            //}
            if (e.CommandName.Equals("Remove"))//删除
            {
                //返回注册金额
                lgk.BLL.tb_user u = new lgk.BLL.tb_user();
                var user = userBLL.GetModel(UserID);
                //var agent = agentBLL.GetModel(user.AgentsID);
                var data = userBLL.GetModel(getLoginID());
                data.Emoney = data.Emoney + user.RegMoney;
                if ( flag_delete(UserID) > 0&& u.Update(data)==true)
                {
                    lgk.Model.tb_journal m_journal_sc = new lgk.Model.tb_journal();
                    m_journal_sc.UserID = getLoginID();
                    m_journal_sc.Remark = "" + data.UserCode + "删除会员" + user.UserCode + "退还：" + user.RegMoney + "";
                    m_journal_sc.RemarkEn = "" + data.UserCode + "del member " + user.UserCode + " back " + user.RegMoney + "";
                    m_journal_sc.InAmount = user.RegMoney;
                    m_journal_sc.OutAmount = 0;
                    m_journal_sc.BalanceAmount = data.Emoney;
                    m_journal_sc.JournalDate = DateTime.Now;
                    m_journal_sc.JournalType = 1;
                    m_journal_sc.Journal01 = int.Parse(getLoginID().ToString());
                    journalBLL.Add(m_journal_sc);
                    MessageBox.MyShow(this, GetLanguage("DeletedSuccessfully"));//删除成功

                }
                else
                {
                    MessageBox.MyShow(this, GetLanguage("DeleteFailed"));//删除失败
                }
            }
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
    }
}