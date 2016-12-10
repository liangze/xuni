/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-5-17 15:59:27 
 * 文 件 名：		zhuye.cs 
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

namespace Web.admin
{
    public partial class zhuye : AdminPageBase//System.Web.UI.Page
    {
        public string AllIn = string.Empty;
        lgk.BLL.tb_user u = new lgk.BLL.tb_user();
        public int shuliang { get; set; }
        public int leiji { get; set; }
        public string jifen { get; set; }
        public string jifenleiji { get; set; }
        public string Allyu = string.Empty;
        public string jiangjin { get; set; }
        public string jiangjinleiji { get; set; }
        public string aixing { get; set; }
        public string zongyeji { get; set; }
        public string fahuo { get; set; }
        public string goumai { get; set; }
        public string youjian { get; set; }
        public string tixian { get; set; }
        public string tixianchuli { get; set; }
        public string caifen { get; set; }
        public string all { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataBing();
                DataBing();
                Total();
                jifen1();
                jiangjin1();
                gouwu();
                tixian1();
                //
            }
        }

        protected void lbtnSettle_Click(object sender, EventArgs e) // 发放推荐奖
        {
            int iResult = bonusBLL.ExecProcedure("proc_Award_Recommended");

            if (iResult == 1)
            {
                MessageBox.Show(this, "推荐奖奖金发放成功！");
            }
            else if (iResult == 0)
            {
                MessageBox.Show(this, "所有奖金已发放！");
            }
            else if (iResult == -1)
            {
                MessageBox.Show(this, "奖金发放失败！");
            }
        }

        protected void lbtnShareOut_Click(object sender, EventArgs e) // 发放静态月分红
        {
            int iResult = bonusBLL.ExecProcedure("proc_Award_ShareOutBonus");

            if (iResult == 1)
            {
                MessageBox.Show(this, "发放静态月分红成功！");
            }
            else if (iResult == 0)
            {
                MessageBox.Show(this, "未到发奖日期！");
            }
            else if (iResult == -1)
            {
                MessageBox.Show(this, "发放静态月分红失败！");
            }
        }

        protected void lbtnBuy_Click(object sender, EventArgs e) // 发放对碰奖
        {
            int iResult = bonusBLL.ExecProcedure("proc_Dateduipeng");

            if (iResult >= 0)
            {
                MessageBox.Show(this, "发放对碰奖成功！");
            }
            else
            {
                MessageBox.Show(this, "发放对碰奖失败！");
            }
        }

        protected void lbtnBonusPayOne_Click(object sender, EventArgs e) // 日结奖金发放（推荐奖/对碰奖）
        {
            int iResult = bonusBLL.ExecProcedure("proc_bonusPayOne");

            if (iResult >= 0)
            {
                MessageBox.Show(this, "日结成功！");
            }
            else if (iResult == 0)
            {
                MessageBox.Show(this, "所有奖金已发放！");
            }
            else
            {
                MessageBox.Show(this, "日结失败！");
            }
        }

        protected void lbtnSplit_Click(object sender, EventArgs e) // 拆分
        {
            int iResult = bonusBLL.ExecProcedure("proc_PresentPrice");

            if (iResult >= 0)
            {
                MessageBox.Show(this, "拆分成功");
            }
            else
            {
                MessageBox.Show(this, "拆分失败！");
            }
        }

        private void DataBing()
        {
            string strWhere = "UserID<>1 AND DATEDIFF (DAY, SellDate, GETDATE()) = 0";
            string strWhere1 = "UserID<>1";
            decimal zsy = cashsellBLL.GetAlready(strWhere);
            decimal zsy1 = cashsellBLL.GetAlready(strWhere1);
            AllIn = zsy.ToString();
            Allyu = zsy1.ToString();

        }

        protected void Total() // 
        {

            DateTime time = DateTime.Now.Date;
            string sql = "select *from  tb_user where RegTime>= '" + time + "';select * from tb_user ;select sum(User011)a from tb_user where userid<>1 ; select sum(LeftScore +RightScore)a from tb_user where userid=1; select sum(StockAccount)a FROM[tb_user];";
            

           DataSet ds = u.getData_Chaxun(sql, "");
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            DataTable dt2 = ds.Tables[2];
            DataTable dt3 = ds.Tables[3];
            DataTable dt4 = ds.Tables[4];
            zongyeji = dt3.Rows[0]["a"].ToString();
            aixing = dt2.Rows[0]["a"].ToString();
            shuliang = dt.Rows.Count;
            leiji = dt1.Rows.Count;
            all = dt4.Rows[0]["a"].ToString();
        }

        protected void jifen1() // 
        {
            DateTime time = DateTime.Now.Date;
            string sql = "select sum(Number)a from  Cashbuy where BuyDate>= '" + time + "' and UserID<>1  ;select sum(Number)a from Cashbuy  ";
            DataSet ds = u.getData_Chaxun(sql, "");
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            jifen = dt.Rows[0]["a"].ToString();
            jifenleiji = dt1.Rows[0]["a"].ToString();


        }

        protected void jiangjin1() // 
        {
            DateTime time = DateTime.Now.Date;
            string sql = "select sum(sf)a from  tb_bonus where AddTime>= '" + time + "'and UserID<>1  ;select sum(sf)a from tb_bonus  ";
            DataSet ds = u.getData_Chaxun(sql, "");
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            jiangjin = dt.Rows[0]["a"].ToString();
            jiangjinleiji = dt1.Rows[0]["a"].ToString();


        }
        protected void gouwu() // 
        {
            string sql = "select count(*)a from  tb_Order  ;select count(*)a from tb_Order where IsSend=2 ;  select SUM(InAmount)a   FROM[SZ1610231023].[dbo].[tb_journal] where Remark like '拆分%' and UserID<>1";
            DataSet ds = u.getData_Chaxun(sql, "");
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            DataTable dt2 = ds.Tables[2];
            goumai = dt.Rows[0]["a"].ToString();
            fahuo = dt1.Rows[0]["a"].ToString();
            caifen= dt2.Rows[0]["a"].ToString();
        }
        protected void tixian1() // 
        {
            DateTime time = DateTime.Now.Date;
            string sql = "select count(*)a from  tb_takeMoney  ;select count(*)a from tb_takeMoney where Flag=1; select count(*)a from [tb_leaveMsg] where LeaveTime>='" + time + "' ";
            DataSet ds = u.getData_Chaxun(sql, "");
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            DataTable dt2 = ds.Tables[2];
            youjian = dt2.Rows[0]["a"].ToString();
            tixian = dt.Rows[0]["a"].ToString();
            tixianchuli = dt1.Rows[0]["a"].ToString();
        }
      
   

      

    }
}
