/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-13 17:39:15 
 * 文 件 名：		Registers.cs 
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
using System.Data.SqlClient;
using DataAccess;
using Library;
using System.Text.RegularExpressions;

namespace Web.user.shop
{
    public partial class Registers : AllCore//System.Web.UI.Page
    {
        public int getLoginID()
        {
            if (Request.Cookies["A128076_user"] != null)
            {
                return Convert.ToInt32(Request.Cookies["A128076_user"]["Id"]);
            }
            else
            {
                return 0;
            }

        }

        public int asd = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindBank();
                BindLevel();

                //textband();
                bind_DropDownList(dropProvince, provinceBLL.GetList("").Tables[0], "provinceID", "province"); //銀行省份
                //bind_DropDownList(DropDownList4, info_province.GetList("").Tables[0], "provinceID", "province"); //地址省份
                string state = getStringRequest("state");
                string[] a;
                if (state != "" && state != null)
                {
                    a = state.Split(',');
                    if (int.Parse(a[1].Trim()) == 1) { Radio1.Checked = true; } else { Radio2.Checked = true; }//注册区域
                    txtParentCode.Value = GetUserCode(int.Parse(a[0].Trim()));//接点会员
                    //asd = int.Parse(a[2].Trim());
                    //if (asd == 1 || asd <= 0)
                    //{
                    //    this.txtRecommendCode.Value = userBLL.GetModel(1).UserCode;
                    //    txtAgentCode.Value = userBLL.GetModel(1).UserCode;
                    //}
                    //else
                    //{
                        var data = userBLL.GetModel(getLoginID());
                        txtRecommendCode.Value = data != null ? data.UserCode : userBLL.GetModel(1).UserCode;
                        txtAgentCode.Value = data != null && data.IsAgent == 1 ? data.UserCode : userBLL.GetModel(1).UserCode;
                    //}
                }
                else
                {
                    var user = userBLL.GetModel(getLoginID());
                    var systemUser=userBLL.GetModel(1);
                    string code = user != null ? user.UserCode : systemUser.UserCode;
                    txtRecommendCode.Value = code;

                    int userid = GetUserID(code);
                    int parentid = getLeftParentIDForShop(userid);
                    txtParentCode.Value = GetUserCode(parentid);//getLeftParentID(GetUserID(code)));
                    if (user != null)
                    {
                        if (user.IsAgent == 1)
                        {
                            txtAgentCode.Value = code;
                        }
                        else
                        {
                            txtAgentCode.Value = GetUserCode(Convert.ToInt32(agentBLL.GetModel(user.AgentsID).UserID));
                        }
                    }
                    else
                    {
                        txtAgentCode.Value = systemUser.UserCode;
                    }
                    
                }
            }
        }

        /// <summary>
        /// 银行省市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.DropDownList3.SelectedValue != "0")
        //    {
        //        bind_DropDownList(this.DropDownList1, new lgk.BLL.tb_city().GetList("father='" + DropDownList3.SelectedValue + "'").Tables[0], "city", "city");
        //    }
        //}

        /// <summary>
        /// 地址省市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.DropDownList4.SelectedValue != "0")
        //    {
        //        bind_DropDownList(this.DropDownList5, new lgk.BLL.tb_city().GetList("father='" + DropDownList4.SelectedValue + "'").Tables[0], "city", "city");
        //    }
        //}
        //private void textband()
        //{
        //    this.txtPassword.Value = "1";
        //    this.txtRegPassword.Value = "1";
        //    this.txtSecondPassword.Value = "1";
        //    this.txtRegSecondPassword.Value = "1";
        //    this.txtThreePassword.Value = "1";
        //    this.txtRegThreePassword.Value = "1";
        //    this.txtBankBranch.Value = "北京市";
        //    this.txtBankAccount.Value = "6228482841450038018";
        //    this.txtBankAccountUser.Value = "黄达献";
        //    this.txtTrueName.Value = "黄达献";
        //    this.txtIdenCode.Value = "452425197806121026";
        //    this.txtPhoneNum.Value = "13255566699";
        //    this.txtAddress.Value = "北京市";
        //    this.txtEmail.Value = "530022@qq.com";
        //    this.txtNickName.Value = "昵称";
        //    //this.txtQQnumer.Value = "34343434";
        //    //this.txtCaiCode.Value = "2343242";
        //    //this.txtCaiName.Value = "财付通名";
        //}

        public string CheckUserID()
        {
            Random r = new Random();
            int strnum = 6;
            string strSQL = "";
            string UserID = "";
            UserID = "HF";
            for (int i = 0; i < strnum; i++)
            {
                UserID += r.Next(0, 9).ToString();
            }
            strSQL = "select count(*) From tb_user where UserCode like @UserCode + '%' ";
            SqlParameter[] parameters = {
				new SqlParameter("@UserCode", UserID)
            };
            if (int.Parse(DbHelperSQL.GetSingle(strSQL, parameters).ToString()) > 0)
            {
                return CheckUserID();
            }
            else
            {
                return UserID;
            }
        }

        /// <summary>
        /// 绑定银行
        /// </summary>
        private void BindBank()
        {
            #region 绑定银行
            string strBankName = banknameBLL.GetModel(1).BankName;
            string[] s = strBankName.Split('|');

            strBankName = s[0];
            if (currentCulture == "en-us")
            {
                strBankName = s[1];
            }

            string[] arrayBankName = strBankName.Split(',');

            dropBank.Items.Clear();
            ListItem item_list = new ListItem();
            item_list.Value = "0";
            item_list.Text = GetLanguage("PleaseSselect");//"-请选择-"
            foreach (string b in arrayBankName)
            {
                ListItem item = new ListItem();
                item.Value = b;
                item.Text = b;
                this.dropBank.Items.Add(item);
            }
            #endregion
        }

        /// <summary>
        /// 绑定用户級別
        /// </summary>
        private void BindLevel()
        {
            IList<lgk.Model.tb_level> list = new lgk.BLL.tb_level().GetModelList("");

            dropLevel.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            dropLevel.Items.Add(li);
            foreach (lgk.Model.tb_level item in list)
            {
                ListItem items = new ListItem();
                items.Value = item.LevelID.ToString();
                if (currentCulture == "en-us")
                {
                    items.Text = item.level03;
                }
                else
                {
                    items.Text = item.LevelName;
                }
                dropLevel.Items.Add(items);
            }
        }

        /// <summary>
        /// 根据选择級別获取金額
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dropLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropLevel.SelectedValue == "0")
            {
                txtRegMoney.Value = "0";
            }
            else
            {
                txtRegMoney.Value = (getParamAmount("Level" + dropLevel.SelectedValue) * getParamAmount("billMoney")).ToString();
            }
        }

        /// <summary>
        /// 检测账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = txtUserCode.Value.Trim();
            if (name == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入用户名!');", true);
                return;
            }
            if (!PageValidate.checkUserCode(txtUserCode.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('用户名必须由6-10位的英文字母或数字组成!');", true);
                return ;
            }
            string strSQL = "select count(*) From tb_user where UserCode = @UserCode";
            SqlParameter[] parameters = {
				new SqlParameter("@UserCode", name)
            };
            if (int.Parse(DbHelperSQL.GetSingle(strSQL, parameters).ToString()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该用户名已存在!');", true);
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该用户名可用!');", true);
                return;
            }
        }

        /// <summary>
        /// 判断是否在推荐会员下线
        /// </summary>
        /// <param name="pID">接点会员ID</param>
        /// <param name="reID">推荐会员ID</param>
        /// <returns></returns>
        private int FlagReg(int pID, int reID)
        {
            string strSql = @"select count(0) from tb_user where UserID =" + pID + " and UserPath like '%" + reID + "%'";
            if (Convert.ToInt32(DbHelperSQL.GetSingle(strSql)) > 0)
            {
                return 2;
            }
            return 1;
        }

        private int FlagLocation(int pID, int location,int isopen)
        {
            string strSql = "";
            strSql = @"select count(0) from tb_user where ParentID =" + pID + " and Location=" + location;
            if(isopen!=0)
            {
                strSql = @"select count(0) from tb_user where isopend<>0 and ParentID =" + pID + " and Location=" + location;
            }
            
            if (Convert.ToInt32(DbHelperSQL.GetSingle(strSql)) > 0)
            {
                return 2;
            }
            return 1;
        }

        /// <summary>
        /// 查询会员推荐数量/下线数量
        /// </summary>
        /// <param name="UserID">会员ID</param>
        /// <param name="Type">类型：r-直推，p-下线</param>
        /// <returns></returns>
        private int getnum(int UserID,string Type)
        {
            string strSql = "";
            if (Type == "r") { strSql = @"select count(0) from tb_user where RecommendID =" + UserID; }
            if (Type == "p") { strSql = @"select count(0) from tb_user where ParentID =" + UserID; }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql));
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RegValidate())
            {  
                lgk.Model.tb_user m_user = new lgk.Model.tb_user();
                lgk.Model.tb_user ModelRecommend = userBLL.GetModel(GetUserID(this.txtRecommendCode.Value.Trim()));//推薦用户
                lgk.Model.tb_user ModelParent = userBLL.GetModel(GetUserID(this.txtParentCode.Value.Trim()));//父节点用户
                lgk.Model.tb_user ModelAgent = userBLL.GetModel(GetUserID(txtAgentCode.Value.Trim()));//报单会员


                m_user.UserCode = txtUserCode.Value.Trim();//會員編號
                m_user.LevelID = Convert.ToInt32(dropLevel.SelectedValue.Trim());
                m_user.RecommendID = Convert.ToInt32(ModelRecommend.UserID);//推薦人ID
                m_user.RecommendCode = ModelRecommend.UserCode;//推薦人編號
                m_user.RecommendPath = ModelRecommend.RecommendPath; //路径
                m_user.RecommendGenera = Convert.ToInt32(ModelRecommend.RecommendGenera + 1);//（推薦代數）第几代
                m_user.User001 = 0;//

                m_user.ParentID = Convert.ToInt32(ModelParent.UserID);//父节点ID
                m_user.ParentCode = ModelParent.UserCode;//父节点編號
                m_user.UserPath = ModelParent.UserPath; //路径
                m_user.Layer = ModelParent.Layer + 1;//属于多少层
                m_user.LeftBalance = 0;
                m_user.LeftNewScore = 0;
                m_user.RightBalance = 0;
                m_user.RightNewScore = 0;
                m_user.LeftScore = 0;
                m_user.RightScore = 0;
                m_user.Location = Radio1.Checked == true ? 1 : 2;
                m_user.User007 = m_user.Location == 1 ? "左区" : "右区";
                m_user.IsOpend = 0;//是否启用 0-未激活, 2-已激活
                m_user.IsLock = 0;//是否被冻結(0-否,1-冻結)

                m_user.IsAgent = 0;//是否报單中心(0-否，1-是)
                m_user.User006 = txtAgentCode.Value.Trim();
                m_user.AgentsID = agentBLL.GetAgentsIDByUserCode(txtAgentCode.Value.Trim());//

                m_user.Emoney = 0;//C幣賬戶
                m_user.BonusAccount = 0;//獎金賬戶
                m_user.AllBonusAccount = 0;//累计獎金賬戶
                m_user.StockAccount = 0;//可交易期權
                m_user.StockMoney = 0;//期權賬戶
                //m_user.GLmoney = getParamAmount("whf");

                m_user.RegTime = DateTime.Now;//注册時間
                m_user.RegMoney = getParamAmount("billMoney") * getParamAmount("Level" + dropLevel.SelectedValue);//注册金额
                m_user.BillCount = 0;// getParamInt("reg" + ddlLevel.SelectedValue);//注册单数
                m_user.Password = PageValidate.GetMd5(this.txtPassword.Value.Trim());//一级密码
                m_user.SecondPassword = PageValidate.GetMd5(this.txtSecondPassword.Value.Trim());//二级密码
                m_user.ThreePassword = PageValidate.GetMd5(this.txtThreePassword.Value.Trim());

                m_user.BankAccount =this.txtBankAccount.Value.Trim();// "銀行賬號";
                m_user.BankAccountUser = this.txtBankAccountUser.Value.Trim();// "開户姓名";
                m_user.BankName = this.dropBank.SelectedValue;// "開户銀行";
                m_user.BankBranch = this.txtBankBranch.Value.Trim();// "支行名稱";
                m_user.BankInProvince = dropProvince.SelectedItem.Text;// "銀行所在省份";
                m_user.BankInCity = "";//DropDownList1.SelectedItem.Text;// "銀行所在城市";

                m_user.NiceName = string.Empty;//txtNickName.Value.Trim();//昵称
                m_user.TrueName = this.txtTrueName.Value.Trim();// "姓名";
                m_user.IdenCode = this.txtIdenCode.Value.Trim();// "身份证號";
                string phoneNum = this.txtPhoneNum.Value.Trim();
                m_user.PhoneNum = string.IsNullOrEmpty(phoneNum)?"-":phoneNum;// "手机號碼";
                //m_user.SafetyCodeQuestion = DropDownList4.SelectedItem.Text;
                //m_user.SafetyCodeAnswer = DropDownList5.SelectedItem.Text;
                m_user.Address = txtAddress.Value;//聯系地址
                m_user.User002 = 0;
                int jihuo = 0;
                //if (rdHK.Checked == true)
                //{
                //    jihuo = 1;
                //}
                //else if(rdZX.Checked==true)
                //{
                //    jihuo = 2;
                //}
                m_user.User004 = jihuo;//激活方式
                int q=0;
                int.TryParse(ddlQuestion.SelectedValue,out q);
                string question = q > 0 && q <= 3 ? ddlQuestion.SelectedItem.Text : string.Empty;
                m_user.User009 = question;//密保问题
                m_user.User010 = string.IsNullOrEmpty(question)?string.Empty:txtAnswer.Text.Trim();//密保答案
                m_user.User011 = 0;
                m_user.User018 = 0;//--用户竞拍该扣未扣的奖金币

                int aid = GetUserID(txtUserCode.Value.Trim());
                if (aid > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('注册失败，该会员编号已存在，请重新注册!');", true);
                }
                else
                {
                string state = getStringRequest("state");
                string[] a;
                if (state != "" && state != null)
                {
                    a = state.Split(',');
                    asd = int.Parse(a[2].Trim());
                }
                    if (userBLL.Add(m_user) > 0)
                    {
                        lgk.Model.tb_user model = userBLL.GetModel(GetUserID(m_user.UserCode));
                        model.UserPath = model.UserPath + "-" + model.UserID.ToString();
                        model.RecommendPath = model.RecommendPath + "-" + model.UserID.ToString();
                        userBLL.Update(model);
                        //插入用户
                        //flag_InsertRegUser(m_user.UserCode, m_user.ParentCode, m_user.Location); 
                        Response.Redirect("RegSuccess.aspx?usercode=" + m_user.UserCode + "&asd=" + asd);
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('注册成功!');window.location.href='RegSuccess.aspx?usercode=" + m_user.UserCode + "';", true);
                    }
                }
            }
        }

        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        protected bool RegValidate()
        {
            lgk.Model.tb_user ModelRecommend = new lgk.Model.tb_user();
            lgk.Model.tb_user ModelParent = new lgk.Model.tb_user();
            lgk.Model.tb_agent ModelAgent = new lgk.Model.tb_agent();
            if (txtUserCode.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入会员编号!');", true);
                return false;
            }
            if (!PageValidate.checkUserCode(txtUserCode.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('会员编号必须由6-10位的英文字母或数字组成!');", true);
                return false;
            }
            //if (txtUserCode.Value.Trim().Length != 7)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('用户名必须由7位数字组成!');", true);
            //    return false;
            //}
            if (GetUserID(txtUserCode.Value.Trim()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该会员编号已存在,请重新输入!');", true);
                return false;
            }
            if (txtPassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('登录密码不能为空!');", true);
                return false;
            }
            //else if (txtPassword.Value.Trim().Length < 6)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('登录密码长度不能小于6位!');", true);
            //    return false;
            //}
            if (txtRegPassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('确认密码不能为空!');", true);
                return false;
            }
            if (!txtPassword.Value.Trim().Equals(txtRegPassword.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('两次输入的登录密码不一致!');", true);
                return false;
            }
            if (txtSecondPassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('二级密码不能为空!');", true);
                return false;
            }
            //else if (txtSecondPassword.Value.Trim().Length < 6)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('二级密码长度不能小于6位!');", true);
            //    return false;
            //}
            if (txtRegSecondPassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('确认二级密码不能为空!');", true);
                return false;
            }
            if (!txtSecondPassword.Value.Trim().Equals(txtRegSecondPassword.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('两次输入的二级密码不一致!');", true);
                return false;
            }
            if (this.txtThreePassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('三级密码不能为空!');", true);
                return false;
            }
            if (this.txtRegThreePassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('确认三级密码不能为空!');", true);
                return false;
            }
            if (!txtThreePassword.Value.Trim().Equals(txtRegThreePassword.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('两次输入的三级密码不一致!');", true);
                return false;
            }

            if (dropLevel.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择要注册的会员级别!');", true);
                return false;
            }
            if (this.txtAgentCode.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('代理中心编号不能为空!');", true);
                return false;
            }
            else
            {
                string reName = this.txtAgentCode.Value.Trim();
                ModelAgent = agentBLL.GetModel(agentBLL.GetAgentsIDByUserCode(reName));//
                if (ModelAgent == null)//代理中心没有记录（）
                {
                    // this.txtAgentCode.Value = "system";//默认为代理中心
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('代理中心编号不存在!');", true);
                    return false;
                }
                if (ModelAgent != null && ModelAgent.Flag == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该代理中心未开通，无法使用!');", true);
                    return false;
                }
                if (ModelAgent != null && ModelAgent.Flag == 2)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该代理中心已被冻结，无法使用!');", true);
                    return false;
                }
            }
            if (txtRecommendCode.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('推荐人编号不能为空!');", true);
                return false;
            }
            else
            {
                string reName = this.txtRecommendCode.Value.Trim();
                ModelRecommend = userBLL.GetModel(GetUserID(reName));//推薦用户
                if (ModelRecommend == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该推荐会员不存在!');", true);
                    return false;
                }
                if (ModelRecommend.IsOpend == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该会员尚未开通，不能作为推荐会员!');", true);
                    return false;
                }
                //if (FlagReg(GetUserID(reName), GetUserID(this.txtAgentCode.Value.Trim())) == 1)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该推荐人不在报单会员脚下，无法注册新会员!');", true);
                //    return false;
                //}
            }
            int reNum = Convert.ToInt32(DbHelperSQL.GetSingle("select count(*) from tb_user where RecommendID=" + GetUserID(this.txtRecommendCode.Value.Trim())));
            if (txtParentCode.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('安置会员编号不能为空!');", true);
                return false;
            }
            else
            {
                string parName = this.txtParentCode.Value.Trim();
                ModelParent = userBLL.GetModel(GetUserID(parName));//父节点用户
                if (ModelParent == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该安置会员不存在!');", true);
                    return false;
                }
                else
                {
                    if (ModelParent.IsOpend == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该安置会员未开通!');", true);
                        return false;
                    }
                }
                //if (FlagReg(GetUserID(parName), GetUserID(this.txtRecommendCode.Value.Trim())) == 1)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('新注册的会员必须放在推荐会员下线!');", true);
                //    return false;
                //}
            }

            if (Radio1.Checked != true && Radio2.Checked != true)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择注册区域!');", true);
                return false;
            }
            int location = 0;
            if (Radio1.Checked == true) { location = 1; }
            if (Radio2.Checked == true) { location = 2; }
            if (FlagLocation(GetUserID(this.txtParentCode.Value.Trim()), location, 0) == 2)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该区域已有会员!');", true);
                return false;
            }
            if ((location == 2 && FlagLocation(GetUserID(this.txtParentCode.Value.Trim()), 1, 0) == 1))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该接点会员左区未有人，不能注册右区!');", true);
                return false;
            }
            //if (reNum == 0)
            //{
            //    if (Radio1.Checked == true)
            //    {
            //        if (ModelParent.UserID != getLeftParentID(GetUserID(this.txtRecommendCode.Value.Trim())))
            //        {
            //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('推荐会员推荐的第一人必须放在最左区!');", true);
            //            return false;
            //        }
            //    }
            //    if (Radio2.Checked == true)
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('推荐会员推荐的第一人必须放在最左区!');", true);
            //        return false;
            //    }
            //}
            //if (ModelParent.IsOpend == 0 && location == 2)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该接点会员尚未开通，不能注册右区!');", true);
            //    return false;
            //}

            if (this.dropBank.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择开户银行!');", true);
                return false;
            }
            if (this.dropProvince.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择省份!');", true);
                return false;
            }
            if (this.txtBankBranch.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行支行不能为空!');", true);
                return false;
            }
            if (this.txtBankAccount.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行卡号不能为空!');", true);
                return false;
            }
            if (!PageValidate.RegexTrueBank(this.txtBankAccount.Value))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行卡号输入错误!');", true);
                return false;
            }
            if (this.txtBankAccountUser.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('开户名不能为空!');", true);
                return false;
            }

            if (!PageValidate.RegexTrueName(txtBankAccountUser.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('开户名必须为2-30个中英文!');", true);
                return false;
            }

            string trueName = this.txtTrueName.Value.Trim();
            if (trueName == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('姓名不能为空!');", true);
                return false;
            }
            if (!PageValidate.RegexTrueName(trueName))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('姓名必须为2-30个中英文!');", true);
                return false;
            }

            //if (this.txtNickName.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('昵称不能为空!');", true);
            //    return false;
            //}

            string IdenCode = this.txtIdenCode.Value.Trim();
            if (IdenCode == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('身份证号不能为空!');", true);
                return false;
            }
            if (!PageValidate.RegexIden(IdenCode))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('身份证号格式错误!');", true);
                return false;
            }

            var phoneNum = this.txtPhoneNum.Value.Trim();
            //if (phoneNum == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('手机号不能为空!');", true);
            //    return false;
            //}
            if (!string.IsNullOrEmpty(phoneNum)&&!PageValidate.RegexPhone(phoneNum))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('联系电话格式错误!');", true);
                return false;
            }
            if (this.txtAddress.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('联系地址不能为空!');", true);
                return false;
            }
            if (ddlQuestion.SelectedValue.Trim() == "请选择")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择密保问题!');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtAnswer.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入密保答案!');", true);
                return false;
            }
            //if (rdHK.Checked != true && rdZX.Checked != true)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择激活方式!');", true);
            //    return false;
            //}
            //if (this.txtCaiCode.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('财付通号不能为空!');", true);
            //    return false;
            //}
            //if (this.txtCaiName.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('财付通名不能为空!');", true);
            //    return false;
            //}
            //if (this.DropDownList5.SelectedValue == "请选择")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择地址所在地!');", true);
            //    return false;
            //}
            //if (this.txtAddress.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('地址不能为空!');", true);
            //    return false;
            //}
            //if (this.txtYouBian.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('邮编号码不能为空!');", true);
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// 自动生成用户编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            UserCode code = new UserCode();
            string numcode = string.Empty;
            bool flag=true;
            while (flag)
            {
               numcode = code.GetCode();
               var user = userBLL.GetModel(" userCode='" + numcode + "'");
               if (user == null)
               {
                   flag = false;
               }
            }
            txtUserCode.Value = numcode;
        }
    }
}