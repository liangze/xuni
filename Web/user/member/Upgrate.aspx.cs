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