/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-19 11:43:24 
 * 文 件 名：		jiaoyidating.cs 
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
using System.Data;
using System.Text;
using Library;
using DataAccess;

namespace Web.user.licai
{
    public partial class jiaoyidating : PageCore//System.Web.UI.Page
    {
        public string DynamicData { get; set; }

        public string BunessData { get; set; }
        public string Days { get; set; }
        protected string dyb = "";
        protected string deb = "";
        protected string dsb = "";
        protected string total = "";
        protected string sxf = "";
        protected string xjqb = "";
        protected string jyqb = "";
        protected string kpj = "";
        protected string cjl = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            BindPic();//行情图
            BindDateStock();
            BindLoginMessage();
            if (!IsPostBack)
            {
                bindMyDai();
                bindDaiMaichuNum();
                bindDaiMairuNum();
            }
        }

        /// <summary>
        /// 欢迎信息
        /// </summary>
        public void BindLoginMessage()
        {
            //this.lbl_uname.Text = us.GetUserCode(getLoginID());
            //this.lbl_times.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Today.ToString("dddd", new System.Globalization.CultureInfo("zh-CN"));
            //this.lbl_ip.Text = Page.Request.UserHostAddress;
            lgk.Model.tb_user user = LoginUser;
            //Label2.Text = user.StockAccount.ToString();
            //Label3.Text = user.Dmoney.ToString();
            //Label4.Text = user.Jmoney.ToString();
            //string one_str = "select top 1 BusinessPrice from gp_BusinessNotes where status = 2 and BusinessType=2 and UserType=1 and userid=" + getLoginID() + " order by BusinessTime asc";
            //lblOne.Text = DbHelperSQL.GetSingle(one_str) == null ? "" : Convert.ToDecimal(DbHelperSQL.GetSingle(one_str)).ToString();
            kpj = gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)") == null ? "0" : gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)").OpenMoney.ToString();
            string sql = "select top 1 id from gp_BusinessNotes where status = 2 order by BusinessTime desc ";
            lgk.Model.gp_BusinessNotes note = gp_notesBLL.GetModel(Convert.ToInt32(DbHelperSQL.GetSingle(sql)));
            if (note == null)
            {
                this.lbl_amount.Text = "0.00";
            }
            else
            {
                this.lbl_amount.Text = note.BusinessPrice.ToString();
            }
            string jsql = "select BusinessAmount from gp_BusinessAmount where Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120) ";
            cjl = DbHelperSQL.GetSingle(jsql) == null ? "暂无" : DbHelperSQL.GetSingle(jsql).ToString();
            string min = DbHelperSQL.GetSingle("select top(1) isnull(BusinessPrice,0) from gp_BusinessNotes where Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120) and status = 2 order by BusinessPrice asc") == null ? kpj : DbHelperSQL.GetSingle("select top(1) isnull(BusinessPrice,0) from gp_BusinessNotes where Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120) and status = 2 order by BusinessPrice asc").ToString();
            string max = DbHelperSQL.GetSingle("select top(1) isnull(BusinessPrice,0) from gp_BusinessNotes where Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120) and status = 2 order by BusinessPrice desc") == null ? kpj : DbHelperSQL.GetSingle("select top(1) isnull(BusinessPrice,0) from gp_BusinessNotes where Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120) and status = 2 order by BusinessPrice desc").ToString();
            Label1.Text = (Convert.ToDecimal(min) > Convert.ToDecimal(kpj) ? kpj : min) + "-" + (Convert.ToDecimal(max) < Convert.ToDecimal(kpj) ? kpj : max);
        }
        /// <summary>
        /// 当前行情
        /// </summary>
        public void BindDateStock()
        {
            StringBuilder dataBuilder = new StringBuilder(); //字符串拼接对象实例化
            dataBuilder.Append("["); //拼接开始符号
            int day = 10; //默认显示10数据
            DataTable dt = gp_opBLL.GetPic(day); //取得交易记录表

            if (dt.Rows.Count > 0)  // 当价格表中数据量大于0时
            {

                for (int i = dt.Rows.Count - 1; i >= 0; i--) //添加真实数据
                {
                    string date = dt.Rows[i]["BusinessPrice"].ToString(); //获取表格中的列值，dt   .    Rows[i]     ["DayTime"]
                    string price = dt.Rows[i]["BusinessAmount"].ToString();//                数据视图  行[ 行数 ]  [该行的列名]
                    dataBuilder.Append(string.Format("['{0}',{1}]", date, price));
                    if (i > 0)
                    {
                        dataBuilder.Append(",");
                    }
                }
            }
            else //===========================全部添加示例数据=============================================
            {
                for (int i = 0; i < 10; i++)
                {
                    dataBuilder.Append(string.Format("['{0}',{1}]", 0, 0));
                    if (i < (10 - 1))
                    {
                        dataBuilder.Append(",");
                    }
                }
            }

            dataBuilder.Append("]");////拼接结束符号，已经加了分号，在前台不需要再加

            BunessData = dataBuilder.ToString();
            //最后拼接成的数据格式示例
            //[['2012-1-5',0.1],['2012-1-6',0.1],['2012-1-7',0.1],['2012-1-8',0.1]];
        }
        //走势图
        public void BindPic()
        {
            StringBuilder dataBuilder = new StringBuilder(); //字符串拼接对象实例化
            StringBuilder dataBuilder1 = new StringBuilder(); //字符串拼接对象实例化
            dataBuilder.Append("["); //拼接开始符号
            dataBuilder1.Append("["); //拼接开始符号
            int day = 10; //默认显示10数据
            //DataTable dt = gp_opBLL.GetPic(day); //取得交易记录表
            DataTable dt = gp_opBLL.GetDtForPic(day); //取得价格表

            if (dt.Rows.Count > 0)  // 当价格表中数据量大于0时
            {

                for (int i = dt.Rows.Count - 1; i >= 0; i--) //添加真实数据
                {
                    //string date = dt.Rows[i]["BusinessPrice"].ToString(); //获取表格中的列值，dt   .    Rows[i]     ["DayTime"]
                    //string price = dt.Rows[i]["BusinessAmount"].ToString();//                数据视图  行[ 行数 ]  [该行的列名]
                    string date = dt.Rows[i]["DayTime"].ToString(); //获取表格中的列值，dt   .    Rows[i]     ["DayTime"]
                    string price = dt.Rows[i]["OpenMoney"].ToString();//                数据视图  行[ 行数 ]  [该行的列名]
                    string amount = dt.Rows[i]["BusinessAmount"].ToString();//                数据视图  行[ 行数 ]  [该行的列名]
                    dataBuilder.Append(string.Format("['{0}',{1}]", date, price));
                    dataBuilder1.Append(string.Format("['{0}',{1}]", date, amount));
                    if (i > 0)
                    {
                        dataBuilder.Append(",");
                        dataBuilder1.Append(",");
                    }
                }
            }
            else //===========================全部添加示例数据=============================================
            {
                for (int i = 0; i < 10; i++)
                {
                    dataBuilder.Append(string.Format("['{0}',{1}]", 0, 0));
                    dataBuilder1.Append(string.Format("['{0}',{1}]", 0, 0));
                    if (i < (10 - 1))
                    {
                        dataBuilder.Append(",");
                        dataBuilder1.Append(",");
                    }
                }
            }

            dataBuilder.Append("]");////拼接结束符号，已经加了分号，在前台不需要再加
            dataBuilder1.Append("]");////拼接结束符号，已经加了分号，在前台不需要再加

            DynamicData = dataBuilder.ToString();
            Days = dataBuilder1.ToString();
            //最后拼接成的数据格式示例
            //[['2012-1-5',0.1],['2012-1-6',0.1],['2012-1-7',0.1],['2012-1-8',0.1]];
        }
        public void GetAmount()
        {
            if (this.txt_num1.Text.Trim().Equals(""))
            {
                return;
            }
            if (this.txt_amount1.Text.Trim().Equals(""))
            {
                return;
            }
            if (!PageValidate.IsInt(this.txt_num1.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票数只能输入正整数!');", true);
                return;
            }
            if (!PageValidate.IsDecimalTwo(this.txt_amount1.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格输入格式有误!');", true);
                return;
            }
            int num = Convert.ToInt32(this.txt_num1.Text.Trim());
            decimal amount = Convert.ToDecimal(this.txt_amount1.Text.Trim());
            this.txt_allamount1.Text = (num * amount).ToString();
        }

        public void GetAmount2()
        {
            if (this.txt_num2.Text.Trim().Equals(""))
            {
                return;
            }
            if (this.txt_amount2.Text.Trim().Equals(""))
            {
                return;
            }
            if (!PageValidate.IsInt(this.txt_num2.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票数只能输入正整数!');", true);
                return;
            }
            if (!PageValidate.IsDecimalTwo(this.txt_amount2.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格输入格式有误!');", true);
                return;
            }
            int num = Convert.ToInt32(this.txt_num2.Text.Trim());
            decimal amount = Convert.ToDecimal(this.txt_amount2.Text.Trim());
            this.txt_allamount2.Text = (num * amount).ToString();
        }
        //格式验证
        bool CheckModeIn()
        {
            //==============================================买入
            //if (si.GetModel() == null)//股票发行管理表
            //{
            //    MessageBox.Show(this, "暂时不能进行此操作");
            //    return false;
            //}
            if (gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)") == null)//股票价格表
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格未发布，不能进行此操作!');", true);
                return false;
            }
            //if (sv.GetModel(1) == null)//股票价格临时变动表
            //{
            //    MessageBox.Show(this, "股票价格未发布，不能进行此操作");
            //    return false;
            //}
            if (this.txt_num1.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入购买的股票数!');", true);
                return false;
            }
            if (!PageValidate.IsInt(this.txt_num1.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('只能输入正整数!');", true);
                return false;
            }
            if (Convert.ToDecimal(this.txt_num1.Text.Trim()) < getGPAmount("buy_min_money"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('最低交易股票数不能少于:" + getGPAmount("buy_min_money").ToString() + "!');", true);
                return false;
            }
            //if (!PageValidate.IsMultiple(100, this.txt_num1.Text.Trim()))
            //{
            //    MessageBox.Show(this, "股票数必须为100的倍数");
            //    return false;
            //}
            if (this.txt_amount1.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入每股的单价!');", true);
                return false;
            }
            if (!PageValidate.IsDecimalTwo(this.txt_amount1.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格输入格式有误!');", true);
                return false;
            }
            if (Convert.ToDecimal(this.txt_amount1.Text.Trim()) <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格不能小于零!');", true);
                return false;
            }
            //卖出价格不能高于当前发布交易价格的
            //卖出价格不能低于当前发布交易价格
            if (!CheckAmount(Convert.ToDecimal(this.txt_amount1.Text.Trim())))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('买入价格不能高于系统发布价格的百分" + getGPAmount("kp_max_rate").ToString() + "；也不能低于发布价格的百分" + getGPAmount("kp_min_rate").ToString() + "!');", true);
                return false;
            }
            decimal account = Convert.ToDecimal(LoginUser.StockMoney);
            if (Convert.ToDecimal(this.txt_allamount1.Text.Trim()) > account)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('账户余额不足!');", true);
                return false;
            }
            if (LoginUser.User003==1)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您已被锁定，不能进行此操作!');", true);
                return false;
            }

            return true;
        }

        bool CheckModeOut()
        {
            //==============================================卖出
            //if (si.GetModel() == null)//股票发行管理表
            //{
            //    MessageBox.Show(this, "暂时不能进行此操作");
            //    return false;
            //}
            if (gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)") == null)//股票价格表
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格未发布，不能进行此操作!');", true);
                return false;
            }
            //if (sv.GetModel(1) == null)//股票价格临时变动表
            //{
            //    MessageBox.Show(this, "股票价格未发布，不能进行此操作");
            //    return false;
            //}
            if (LoginUser.StockAccount < getGPAmount("minStockAccount"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您的可交易股票少于" + getGPAmount("minStockAccount") + "，禁止卖出!');", true);
                return false;
            }
            //if (ddlMaichu.SelectedValue == "1")
            //{
            //    if (LoginUser.StockAccount < getGPAmount("minStockAccount"))
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您的可交易股票少于" + getGPAmount("minStockAccount") + "，禁止卖出!');", true);
            //        return false;
            //    }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('禁止卖出!');", true);
            //    return false;
            //    //if (LoginUser.Dmoney < getGPAmount("minStockAccount"))
            //    //{
            //    //    MessageBox.Show(this, "您的贡献仓钱包少于" + getGPAmount("minStockAccount") + "，禁止卖出");
            //    //    return false;
            //    //}
            //}
            if (this.txt_num2.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入要卖出的股票数!');", true);
                return false;
            }
            if (!PageValidate.IsInt(this.txt_num2.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('只能输入正整数,且和100成倍数关系!');", true);
                return false;
            }
            if (Convert.ToDecimal(this.txt_num2.Text.Trim()) < getGPAmount("sell_min_money"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('最低交易股票数不能少于:" + getGPAmount("sell_min_money").ToString() + "!');", true);
                return false;
            }
            if (Convert.ToDecimal(this.txt_num2.Text.Trim()) > getGPAmount("sell_max_money"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('最高交易股票数不能少于:" + getGPAmount("sell_ax_money").ToString() + "!');", true);
                return false;
            }
            if (!PageValidate.IsDecimalTwo(this.txt_amount2.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格输入格式有误!');", true);
                return false;
            }
            if (this.txt_amount2.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入每股的单价!');", true);
                return false;
            }
            if (Convert.ToDecimal(this.txt_amount2.Text.Trim()) <=0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格不能小于零!');", true);
                return false;
            }
            //卖出价格不能高于当前发布交易价格的
            //卖出价格不能低于当前发布交易价格
            if (!CheckAmount(Convert.ToDecimal(this.txt_amount2.Text.Trim())))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('当前卖出价格不能高于系统发布价格的百分" + getGPAmount("kp_max_rate").ToString() + "；也不能低于发布价格的百分" + getGPAmount("kp_min_rate").ToString()+"!');", true);
                return false;
            }

            //卖出股票判断
            //if (Convert.ToDecimal(DbHelperSQL.GetSingle("select top(1)isnull(SurplusAmount,0) from gp_StockIssue order by AddTime asc")) < Convert.ToDecimal(this.txt_num2.Text.Trim()))
            //{
            //    MessageBox.Show(this, "卖出股票数大于系统剩余的股票数");
            //    return false;
            //}
            decimal account = 0;
            account = Convert.ToDecimal(LoginUser.StockAccount);
            //if (ddlMaichu.SelectedValue=="1")
            //{
            //    account = Convert.ToDecimal(LoginUser.StockAccount);
            //}
            //else
            //{
            //    account = 0;// LoginUser.Dmoney;
            //}
            if (Convert.ToDecimal(this.txt_allamount2.Text.Trim()) > account)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('账户余额不足!');", true);
                return false;
            }
            if (LoginUser.User003 == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您已被锁定，不能进行此操作!');", true);
                return false;
            }

            //==================================================================================
            return true;
        }

        public bool CheckAmount(decimal amount)
        {
            decimal hig = getGPAmount("kp_max_rate");
            decimal dow = getGPAmount("kp_min_rate");

            lgk.Model.gp_StockPrice vary = gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)");
            decimal varyAmount = Convert.ToDecimal(vary.OpenMoney);
            decimal higAmount = varyAmount * hig / 100 + varyAmount;
            decimal dowAmount = varyAmount - varyAmount * dow / 100;

            if (amount > higAmount)
            {
                return false;
            }
            else if (amount < dowAmount)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        protected void txt_num1_TextChanged(object sender, EventArgs e)
        {
            GetAmount();
            if (txt_amount1.Text.Trim() == "")
            {
                this.txt_amount1.Focus();
            }
        }

        protected void txt_amount1_TextChanged(object sender, EventArgs e)
        {
            GetAmount();
            if (txt_num1.Text.Trim() == "")
            {
                this.txt_num1.Focus();
            }
        }

        protected void bt_in_Click(object sender, EventArgs e)
        {
            if (CheckModeIn())
            {
                int num = Convert.ToInt32(this.txt_num1.Text);
                decimal amount = Convert.ToDecimal(this.txt_amount1.Text);
                if (gp_opBLL.U_MaiGuOut(num, amount,getLoginID(),GetUserCode(getLoginID())))//调用存储过程买股票
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='jiaoyidating.aspx'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作失败!');", true);
                }
            }
        }

        protected void txt_num2_TextChanged(object sender, EventArgs e)
        {
            GetAmount2();
            if (this.txt_amount2.Text.Trim() == "")
            {
                this.txt_amount2.Focus();
            }
        }

        protected void txt_amount2_TextChanged(object sender, EventArgs e)
        {
            GetAmount2();
            if (this.txt_num2.Text.Trim() == "")
            {
                this.txt_num2.Focus();
            }
        }

        protected void bt_out_Click(object sender, EventArgs e)
        {
            if (CheckModeOut())
            {
                int num = Convert.ToInt32(this.txt_num2.Text);
                decimal amount = Convert.ToDecimal(this.txt_amount2.Text);
                //if (gp_opBLL.U_MaiGu(num, amount, getLoginID(), GetUserCode(getLoginID()),Convert.ToInt32(ddlMaichu.SelectedValue)))//调用存储过程卖股票
                if (gp_opBLL.U_MaiGu(num, amount, getLoginID(), GetUserCode(getLoginID()), 1))//调用存储过程卖股票
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='jiaoyidating.aspx'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作失败!');", true);
                }
            }
        }

        /// <summary>
        /// 我的待交易记录
        /// </summary>
        private void bindMyDai()
        {
            string strWhere = string.Format("  status = 1 and UserType=1 and UserID=" + getLoginID());
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater3, "BusinessTime desc", tr3, AspNetPager3);
        }
        /// <summary>
        /// 待卖出数量
        /// </summary>
        private void bindDaiMaichuNum()
        {
            DataSet ds = DbHelperSQL.Query("select BusinessPrice price,sum(BusinessAmount) num from gp_BusinessNotes where Status=1 and BusinessType=1 group by BusinessPrice");
            bind_repeater(ds, Repeater1, "price asc", tr1);
        }
        /// <summary>
        /// 待买入数量
        /// </summary>
        private void bindDaiMairuNum()
        {
            DataSet ds = DbHelperSQL.Query("select BusinessPrice price,sum(BusinessAmount) num from gp_BusinessNotes where Status=1 and BusinessType=2 group by BusinessPrice");
            bind_repeater(ds, Repeater2, "price asc", tr2);
        }
        protected string getType(int BusinessType)
        {
            if (BusinessType == 2)
            {
                return "买入交易";
            }
            return "卖出交易";
        }
        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            bindMyDai();
        }

        protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            lgk.Model.gp_BusinessNotes model = gp_notesBLL.GetModel(ID);
            if (model == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('已撤单,无法再进行此操作！');window.location.href='jiaoyidating.aspx'", true);
            }
            else
            {
                if (e.CommandName.Equals("Open"))//
                {
                    model.Status = 4;
                    if (model.BusinessType==1)
                    {
                        if (gp_notesBLL.Update(model) && UpdateAccount("StockAccount", model.UserID, Convert.ToDecimal(model.BusinessAmount), 1) > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('撤单成功！');window.location.href='jiaoyidating.aspx'", true);
                        }
                    }
                    else
                    {

                        if (gp_notesBLL.Update(model) && UpdateAccount("StockMoney", model.UserID, Convert.ToDecimal(model.SumMoney), 1) > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('撤单成功！');window.location.href='jiaoyidating.aspx'", true);
                        }
                    }
                }
            }
        }
    }
}
