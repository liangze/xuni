using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.member
{
    public partial class Pro : PageCore//System.Web.UI.Page
    {
        lgk.BLL.tb_level levbll = new lgk.BLL.tb_level();
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转2级密码
            if (!IsPostBack)
            {
                lblUserCode.Text = GetUserCode(getLoginID());
                lblTrueName.Text = LoginUser.TrueName;
                if (currentCulture == "en-us")
                {
                    lblLevel.Text = levelBLL.GetModel(LoginUser.LevelID).level03;
                }
                else
                {
                    lblLevel.Text = levelBLL.GetModel(LoginUser.LevelID).LevelName;
                }
               
                ddlL();
                bind_pro();
                heightClassHand();
                Button1.Text = GetLanguage("AccountsQueries");//账户查询
                //Button3.Text = GetLanguage("recharge");//我要充值
                //Button4.Text = GetLanguage("Transfer");//账户转账
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        #region 判断用户是否为最高级别
        public void heightClassHand()
        {
            int levlId = 6;//levbll.GetMaxId();
            if (levlId != 0)
            {
                if (LoginUser.LevelID >= levlId)
                {
                    Literal1.Text = GetLanguage("highestLevel");//您当前已是最高级别
                    btnSubmit.Visible = false;
                }
            }
        }
        #endregion

        private void ddlL()
        {
            //string regtype = "";
            IList<lgk.Model.tb_level> ddlList = new lgk.BLL.tb_level().GetModelList(" LevelID<6 ");
            int i = LoginUser.LevelID;//当前会员等级
            ddlList=ddlList.Where(o => o.LevelID > i).ToList();
            //var closeLevels = paramBLL.GetModelList(" ParamName LIKE '%Leve_open%' AND ParamVarchar='0'");//查询关闭的用户级别
            //foreach (var item in closeLevels)
            //{
            //    int leveId = 0;
            //    int.TryParse(closeLevels.First().ParamName.Replace("Leve_open", ""), out leveId);
            //    var model = ddlList.Where(o => o.LevelID == leveId);
            //    if (model.Count() > 0)
            //    {
            //        ddlList.Remove(model.First());
            //    }
            //}

            ddlLevel.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = GetLanguage("PleaseSselect");//"-请选择-"
            ddlLevel.Items.Add(li);
            foreach (lgk.Model.tb_level item in ddlList)
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
                ddlLevel.Items.Add(items);
            }
        }

        protected string getLastLevel(int lastLevel)
        {
            return levelBLL.GetModel(lastLevel).LevelName;
        }

        private void bind_pro()
        {
            LoginUser = new lgk.BLL.tb_user().GetModel(LoginUser.UserID);
            lbEmoney.Text = "0";
            if (LoginUser != null)
            {
                lbEmoney.Text = LoginUser.Emoney + "";
            }

            bind_repeater(proBLL.GetList(" UserID=" + getLoginID()), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(LoginUser.UserID);
            if (userInfo != null)
            {
                if (ddlLevel.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Pleasepromotions") + "');", true);//请选择晋升级别
                }
                else
                {
                    //判断会员级别是否开启
                    //var leveOpen = getParamAmount("Leve_open" + ddlLevel.SelectedValue);
                    //if (leveOpen == 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("membershipClosed") + "');", true);//该会员级别已关闭
                    //    return;
                    //}
                    var billMoney = getParamAmount("billMoney");
                    decimal money = getParamAmount("Level" + ddlLevel.SelectedValue) * billMoney;
                    if (userInfo.Emoney < money)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您的现金币不足，无法晋升');", true);//E币不足，无法晋升
                        return;
                    }
                    if (proBLL.GetModelByUserID(Convert.ToInt32(userInfo.UserID)) != null)
                    {
                        if (proBLL.GetModelByUserID(Convert.ToInt32(userInfo.UserID)).Flag == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("audit") + "');", true);//您已提交申请，请等待审核
                            return;
                        }
                    }
                    int endLevl = Convert.ToInt32(ddlLevel.SelectedValue);
                    //加入用户升级表
                    lgk.Model.tb_userPro upModel = new lgk.Model.tb_userPro();
                    upModel.UserID = userInfo.UserID;
                    upModel.AddDate = DateTime.Now;
                    upModel.ProMoney = money;//晋级所需的金额
                    upModel.LastLevel = userInfo.LevelID;
                    upModel.EndLevel = endLevl;
                    upModel.Pro003 = userInfo.Emoney - upModel.ProMoney;//所剩E币
                    upModel.Remark = "自身晋升";
                    upModel.AddDate = DateTime.Now;
                    upModel.Flag = 0;

                    if (proBLL.Add(upModel) > 0 && flag_pro(Convert.ToInt32(userInfo.UserID), 1))
                    {
                        add_userRecord(LoginUser.UserCode, DateTime.Now, upModel.ProMoney, 2);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('升级成功！');window.location.href='Pro.aspx';", true);//
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("checkPage") + "');", true);//操作失败!请检查页面!
                    }
                   
                    bind_pro();
                }
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("checkPage") + "');", true);
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind_pro();
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            int level = Convert.ToInt32(ddlLevel.SelectedValue);
            if (level != 0)
            {
                //全额升级
                var billMoney = getParamAmount("billMoney");
                txtMoney.Value = (getParamAmount("Level" + ddlLevel.SelectedValue) * billMoney).ToString();
            }
            else
            {
                txtMoney.Value = "";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Pleasepromotions") + "');", true);//请选择晋升级别
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind_pro();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session["reg_usercode"] = LoginUser.UserCode;
            Response.Redirect("/Registers.aspx");
        }
    }
}
