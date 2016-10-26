/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-24 19:47:53 
 * 文 件 名：		zichan.cs 
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
using DataAccess;

namespace Web.user.licai
{
    public partial class zichan : PageCore//System.Web.UI.Page
    {
        protected string label1 = "";
        protected string label2 = "";
        protected string label3 = "";
        protected string label4 = "";
        protected string label5 = "";
        protected string label6 = "";
        protected string label7 = "";
        protected string all = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_zc();
            }
        }

        private void bind_zc()
        {
            lgk.Model.tb_user user = LoginUser;
            label1 = user.StockAccount.ToString();
            string kpj = gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)") == null ? "未设置" : gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)").OpenMoney.ToString();
            //string sql = "select top 1 id from gp_BusinessNotes where status = 2 order by BusinessTime desc ";
            //lgk.Model.gp_BusinessNotes note = bn.GetModel(Convert.ToInt32(DbHelperSQL.GetSingle(sql)));
            //if (note == null)
            //{
            //    label2 = (user.Lmoney * sp.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)").OpenMoney).ToString("0.00");
            //}
            //else
            //{
            //    label2 = (user.Lmoney * note.BusinessPrice).ToString("0.00");
            //}
            label2 = Convert.ToDecimal(user.StockAccount * Convert.ToDecimal(kpj == "未设置" ? "0" : kpj)).ToString("0.00");
            label3 = "0";// user.Jmoney.ToString();
            label4 = "0";// user.Gmoney.ToString();
            //long iUID = getLoginID();
            string mr = DbHelperSQL.GetSingle("select sum(BusinessAmount) from gp_BusinessNotes where status=2 and BusinessType=2 and UserType=1 and UserID=" + getLoginID()) == null ? "0" : DbHelperSQL.GetSingle("select sum(BusinessAmount) from gp_BusinessNotes where status=2 and BusinessType=2 and UserType=1 and UserID=" + getLoginID()).ToString();
            label5 = Convert.ToDecimal(mr).ToString("0.00");
            string mc = DbHelperSQL.GetSingle("select sum(BusinessAmount) from gp_BusinessNotes where status=2 and BusinessType=1 and BusinessType=1 and UserID=" + getLoginID()) == null ? "0" : DbHelperSQL.GetSingle("select sum(BusinessAmount) from gp_BusinessNotes where status=2 and BusinessType=1 and BusinessType=1 and UserID=" + getLoginID()).ToString();
            label6 = Convert.ToDecimal(mc).ToString("0.00");
            label7 = "0";// user.Dmoney.ToString();

            decimal dai = Convert.ToDecimal(DbHelperSQL.GetSingle("select sum(BusinessAmount) from gp_BusinessNotes where status=1 and BusinessType=1 and BusinessType=1 and UserID=" + getLoginID()) == null ? "0" : DbHelperSQL.GetSingle("select sum(BusinessAmount) from gp_BusinessNotes where status=1 and BusinessType=1 and BusinessType=1 and UserID=" + getLoginID()));
            all = (user.StockAccount + dai).ToString();
        }
    }
}
