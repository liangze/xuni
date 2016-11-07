using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;
using System.Net;
using System.IO;

namespace Web.admin.finance
{
    public partial class TakeMoney : AdminPageBase//System.Web.UI.Page
    {
        private string strWhere = "";
        string StarTime;
        string EndTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 16, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
            txtMoney.Value = GetTotalTake(0).ToString("0.00");
        }
        protected void lbtnApply_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeMoney.aspx");
        }

        protected void lbtnDraw_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeList.aspx");
        }
        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            StarTime = txtStar.Text.Trim();
            EndTime = txtEnd.Text.Trim();
            strWhere = " b.Flag=0";
            if (this.txtUserCode.Value != "")
            {
                strWhere += " and u.usercode like '%" + this.txtUserCode.Value.Trim() + "%'";
            }
            if (this.txtTrueName.Value != "")
            {
                strWhere += " and u.trueName like '%" + this.txtTrueName.Value.Trim() + "%'";
            }
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),b.TakeTime,120) >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),b.TakeTime,120) <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),b.TakeTime,120) between '" + StarTime + "' and '" + EndTime + "'");
            }
            return strWhere;
        }
        /// <summary>
        /// 填充申请记录
        /// </summary>
        private void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), Repeater1, "TakeTime desc", tr1, AspNetPager1);
        }
        /// <summary>
        /// 搜索申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        /// <summary>
        /// 导出申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            DataSet ds = GetTakeList(GetWhere());
            DataTable dt = ds.Tables[0];
            if (Repeater1.Items.Count == 0)
            {
                MessageBox.MyShow(this, "不能导出空表格");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.MyShow(this, "错误的操作");
                return;
            }
            string str = ToTakeExecl2(Server.MapPath("../../Upload"), dt);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }
        /// <summary>
        /// 审核分页申请记录
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long ID = Convert.ToInt64(e.CommandArgument); //ID
            lgk.Model.tb_takeMoney cModel = takeBLL.GetModel(ID);
            lgk.BLL.tb_systemMoney sy = new lgk.BLL.tb_systemMoney();
            //lgk.BLL.tb_rechargeable dotx = new lgk.BLL.tb_rechargeable();
            lgk.Model.tb_systemMoney system = sy.GetModel(1);
            lgk.Model.tb_user user1 = userBLL.GetModel(ID);//
            if (user1.PhoneNum == "")
            {
                MessageBox.ShowAndRedirect(this, "请填写手机号!", "TakeMoney.aspx");
                return;
            }
            if (cModel == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已删除,无法再进行此操作！');window.location.href='TakeMoney.aspx';", true);
            }
            else
            {

                if (cModel.Flag == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已审核,无法再进行此操作！');window.location.href='TakeMoney.aspx';", true);

                }
                else
                {
                    lgk.Model.tb_user user = userBLL.GetModel(Convert.ToInt32(cModel.UserID));
                    if (e.CommandName.Equals("Open"))//确认
                    {
                        cModel.Flag = 1;
                        cModel.Take006 = DateTime.Now;
                        if (takeBLL.Update(cModel) && UpdateSystemAccount("MoneyAccount", Convert.ToDecimal(cModel.RealityMoney), 0) > 0)
                        {
                            int dx = getParamInt("duanxin");
                            if (dx==1)
                            {
                                //短信
                                string DX = System.Configuration.ConfigurationManager.AppSettings["DX"];
                                string DXMM = System.Configuration.ConfigurationManager.AppSettings["DXMM"];
                                string uid = DX.ToString();
                                string auth = DXMM.ToString();
                                string mobile = user1.PhoneNum;
                                string url = "http://sms.10690221.com:9011/hy/?uid=" + uid + "&auth=" + auth + "&mobile=" + mobile + "&msg=";

                                //http://ip:port/hy/?uid=1234&auth=faea920f7412b5da7be0cf42b8c93759&mobile=13612345678&msg=hello&expid=0

                                string content = "尊敬的云商会员您好！你的申请提现已处理，请注意查收！";
                                string neirong = content;
                                System.Text.Encoding encode = System.Text.Encoding.GetEncoding("GBK");
                                content = HttpUtility.UrlEncode(content, encode);
                                url += content;
                                url += "&expid=0";
                                string jieguo = GetHtmlFromUrl(url);
                                string[] jiequ = jieguo.Split(',');
                                lgk.BLL.tb_message m = new lgk.BLL.tb_message();
                                lgk.Model.tb_message M_user = new lgk.Model.tb_message();
                                M_user.Flag = jiequ[0];
                                M_user.Mcontent = neirong;
                                M_user.MobileNum = user1.PhoneNum;
                                m.Add(M_user);

                            }
                            ////发送短信通知
                            // string content = GetLanguage("MessageTakeMoneyOK").Replace("{username}", user.UserCode).Replace("{time}", Convert.ToDateTime(cModel.TakeTime).ToString("yyyy年MM月dd日HH时mm分")).Replace("{timeEn}", Convert.ToDateTime(cModel.TakeTime).ToString("yyyy/MM/dd HH:mm"));
                            // SendMessage(Convert.ToInt32(cModel.UserID), user.PhoneNum, content);

                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='TakeMoney.aspx';", true);

                        }
                    }
                    if (e.CommandName.Equals("Remove"))//删除
                    {
                        //加入流水账表
                        lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                        model.UserID = cModel.UserID;
                        model.Remark = "取消提现";
                        model.InAmount = cModel.TakeMoney;
                        model.OutAmount = 0;
                        model.BalanceAmount = user.BonusAccount + cModel.TakeMoney;
                        model.JournalDate = DateTime.Now;
                        model.JournalType = 1;
                        model.Journal01 = cModel.UserID;
                        if (journalBLL.Add(model) > 0 && UpdateAccount("BonusAccount", user.UserID, cModel.TakeMoney, 1) > 0 && takeBLL.Delete(ID))
                        {
                            int dx = getParamInt("duanxin");
                            if (dx == 1)
                            {
                                //短信
                                string DX = System.Configuration.ConfigurationManager.AppSettings["DX"];
                                string DXMM = System.Configuration.ConfigurationManager.AppSettings["DXMM"];
                                string uid = DX.ToString();
                                string auth = DXMM.ToString();
                                string mobile = user1.PhoneNum;
                                string url = "http://sms.10690221.com:9011/hy/?uid=" + uid + "&auth=" + auth + "&mobile=" + mobile + "&msg=";

                                //http://ip:port/hy/?uid=1234&auth=faea920f7412b5da7be0cf42b8c93759&mobile=13612345678&msg=hello&expid=0

                                string content = "尊敬的云商会员您好！你的银行账号错误，请尽快修改完善个人资料，谢谢！";
                                string neirong = content;
                                System.Text.Encoding encode = System.Text.Encoding.GetEncoding("GBK");
                                content = HttpUtility.UrlEncode(content, encode);
                                url += content;
                                url += "&expid=0";
                                string jieguo = GetHtmlFromUrl(url);
                                string[] jiequ = jieguo.Split(',');
                                lgk.BLL.tb_message m = new lgk.BLL.tb_message();
                                lgk.Model.tb_message M_user = new lgk.Model.tb_message();
                                M_user.Flag = jiequ[0];
                                M_user.Mcontent = neirong;
                                M_user.MobileNum = user1.PhoneNum;
                                m.Add(M_user);
                            }

                            MessageBox.MyShow(this, "取消成功");
                            BindData();
                        }
                        else
                        {
                            MessageBox.MyShow(this, "取消失败");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 短信
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetHtmlFromUrl(string url)
        {
            string a = null;

            if (url == null || url.Trim().ToString() == "")
            {
                return a;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "Get";
                hr.Timeout = 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, System.Text.Encoding.Default);
                a = ser.ReadToEnd();
                Response.Write("<br/>resp=" + ser.ReadToEnd());

            }
            catch (Exception ex)
            {
                a = ex.Message;
            }
            return a;
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
