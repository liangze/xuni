/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-5-23 11:51:51 
 * 文 件 名：		RemitManage.cs 
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

namespace Web.admin.finance
{
    public partial class RemitManage : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 34, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼
            if (!IsPostBack)
            {
                bind();
            }
        }

        private void bind()
        {
            bind_repeater(GetRemitList(GetWhere()), rpRemit, "AddDate desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "";

            string strStartTime = this.txtStar.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();

            strWhere = string.Format(" 1=1");

            if (this.dropState.SelectedValue == "1")
            {
                strWhere += " and r.State=0";
            }
            else if (this.dropState.SelectedValue == "2")
            {
                strWhere += " and r.State=1";
            }

            if (this.txtUserCode.Text != "")
            {
                strWhere += " and u.UserCode like '%" + this.txtUserCode.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtTrueName.Text))
            {
                strWhere += " and u.TrueName like '%" + this.txtTrueName.Text.Trim() + "%'";
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void rpRemit_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long id = Convert.ToInt64(e.CommandArgument);
            lgk.Model.tb_remit remit = remitBLL.GetModel(id);
            int bix = remit.Remit001;//获取充值币种
            if (remit == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已删除，无法再进行此操作!');window.location.href='RemitManage.aspx';", true);
            }
            else
            {
                if (remit.State == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已审核，无法再进行此操作!');window.location.href='RemitManage.aspx';", true);
                }
                else
                {
                    if (e.CommandName.Equals("verify"))//确认
                    {
                        remit.State = 1;
                        //加入流水账表
                        lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                        jmodel.UserID = remit.UserID;
                        jmodel.Remark = "汇款充值";
                        jmodel.InAmount = remit.RemitMoney;
                        jmodel.OutAmount = 0;
                        jmodel.JournalDate = DateTime.Now;
                        jmodel.JournalType = bix;//充值币种
                        jmodel.Journal01 = remit.UserID;
                        //更新会员账户
                        //journalType : 1、注册积分，2、奖金积分，3、电子积分，4、云商积分，5、感恩积分，6、购物积分，7、消费积分，8、爱心基金，9、云购积分
                        if(bix==1)
                        {
                            jmodel.BalanceAmount = userBLL.GetModel(remit.UserID).Emoney + remit.RemitMoney;
                            journalBLL.Add(jmodel);
                            UpdateAccount("Emoney", remit.UserID, remit.RemitMoney, 1);
                        }
                        if (bix == 2)
                        {
                            jmodel.BalanceAmount = userBLL.GetModel(remit.UserID).BonusAccount + remit.RemitMoney;
                            UpdateAccount("BonusAccount", remit.UserID, remit.RemitMoney, 1);
                        }
                        if (bix == 3)
                        {
                            jmodel.BalanceAmount = userBLL.GetModel(remit.UserID).AllBonusAccount + remit.RemitMoney;
                            UpdateAccount("AllBonusAccount", remit.UserID, remit.RemitMoney, 1);
                        }
                        if (bix == 4)
                        {
                            jmodel.BalanceAmount = userBLL.GetModel(remit.UserID).StockAccount + remit.RemitMoney;
                            UpdateAccount("StockAccount", remit.UserID, remit.RemitMoney, 1);
                        }
                        if (bix == 5)
                        {
                            jmodel.BalanceAmount = userBLL.GetModel(remit.UserID).StockMoney + remit.RemitMoney;
                            UpdateAccount("StockMoney", remit.UserID, remit.RemitMoney, 1);
                        }
                        if (bix == 6)
                        {
                            jmodel.BalanceAmount = userBLL.GetModel(remit.UserID).GLmoney + remit.RemitMoney;
                            UpdateAccount("GLmoney", remit.UserID, remit.RemitMoney, 1);
                        }
                        if (bix == 7)
                        {
                            jmodel.BalanceAmount = userBLL.GetModel(remit.UserID).ShopAccount + remit.RemitMoney;
                            UpdateAccount("ShopAccount", remit.UserID, remit.RemitMoney, 1);
                        }
                        if (bix == 8)
                        {
                            jmodel.BalanceAmount = userBLL.GetModel(remit.UserID).User011 + remit.RemitMoney;
                            UpdateAccount("User011", remit.UserID, remit.RemitMoney, 1);
                        }
                        if (bix == 9)
                        {
                            jmodel.BalanceAmount = userBLL.GetModel(remit.UserID).User012 + remit.RemitMoney;
                            UpdateAccount("User012", remit.UserID, remit.RemitMoney, 1);
                        }
                       
                        if (remitBLL.Update(remit) && UpdateSystemAccount("MoneyAccount", remit.RemitMoney, 1) > 0 )
                        {
                            //UpdateFiled("IsReport", "1", Convert.ToInt32(remit.UserID));
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('确认成功!');", true);
                            bind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('确认失败!');", true);
                        }
                    }
                    if (e.CommandName.Equals("Remove"))//删除  
                    {
                        if (remitBLL.Delete(id))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除成功!');", true);
                            bind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除失败!');", true);
                        }
                    }
                }
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
    }
}
