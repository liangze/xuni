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
            txtPresentLevel.Value = levelBLL.GetLevelName(LoginUser.LevelID);
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int nlevel = Convert.ToInt32(DropDownList1.SelectedValue);
            lgk.Model.tb_user model = new lgk.Model.tb_user();
            model = userBLL.GetModel(getLoginID());
            if (model.LevelID < nlevel)
            {
                int newLevelID = int.Parse(DropDownList1.SelectedValue);
                if (newLevelID <= 0)
                {
                    DropDownList1.SelectedIndex = 0;
                    Response.Write("<script>alert('请选择升级等级');location.href=Upgrade.aspx;</script>");
                    return;
                }
                // decimal pay = PayFor();
                decimal pay = levelBLL.GetModel(nlevel).RegMoney - levelBLL.GetModel(model.LevelID).RegMoney;
                if (newLevelID >= 0 && (LoginUser.Emoney >= pay)) // 扣除100%注册币
                {
                    // 存储过程，传入UID,pay,selectedValue,type1(1.100%;2.50%)

                    if (bonusBLL.Upgrade(LoginUser.UserID, pay, newLevelID) > 0)
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
        // 付款=升级至某等级的投资额-当前等级的投资额
        private decimal PayFor()
        {
            decimal payFor = getParamAmount("VIP" + DropDownList1.SelectedValue.ToString()) - getParamAmount("VIP" + LoginUser.LevelID.ToString());
            txtPayFor.Value = "注册币：" + payFor;
            return payFor;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(DropDownList1.SelectedValue) > LoginUser.LevelID)
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
    }
}