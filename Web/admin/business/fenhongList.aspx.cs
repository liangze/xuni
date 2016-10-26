using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;
using System.Collections;
using System.IO;
using DataAccess;

namespace Web.admin.business
{
    public partial class fenhongList : AdminPageBase
    {
        lgk.BLL.tb_LirunFenhong fenhongBll = new lgk.BLL.tb_LirunFenhong();
        lgk.BLL.tb_globeParam globeParamBll = new lgk.BLL.tb_globeParam();
        protected void Page_Load(object sender, EventArgs e)
        {

            jumpMain(this, 55, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                bind();
            }
        }
        private void bind()
        {
            bind_repeater(lf.GetAllList(), Repeater1, "FhTime desc", trBonusNull, AspNetPager1);
        }


        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }


        //结算分红
        protected void btnjiesuan_Click(object sender, EventArgs e)
        {
            decimal de = 0;
            if (txtmoney.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入利润金额");
                return;
            }
            if (!decimal.TryParse(txtmoney.Text.Trim(), out de))
            {
                MessageBox.Show(this, "利润金额必须输入数字");
                return;
            }

            if (Convert.ToDecimal(txtmoney.Text.Trim()) <= 0)
            {
                MessageBox.Show(this, "利润金额必须大于0");
                return;
            }
          
            if (txtrate.Text.Trim() == "")
            {
                MessageBox.Show(this,"请输入分红比例");
                return;
            }
            if (!decimal.TryParse(txtrate.Text.Trim(), out de))
            {
                MessageBox.Show(this, "分红比例必须输入数字");
                return;
            }
            if (Convert.ToDecimal(txtrate.Text.Trim()) > 100 || Convert.ToDecimal(txtrate.Text.Trim()) <= 0)
            {
                MessageBox.Show(this, "输入分红比例不能大于100,小于0");
                return;
            }
            //增加一条分红纪录
            lgk.Model.tb_LirunFenhong fenhong = new lgk.Model.tb_LirunFenhong();
            fenhong.BonusMoney = Convert.ToDecimal(txtmoney.Text.Trim());
            fenhong.FhRate = Convert.ToDecimal(txtrate.Text.Trim());
            fenhong.FhTime = DateTime.Now;
            string sql = "update tb_globeParam set ParamVarchar=" + fenhong.FhRate + " where ParamName = 'fh_rete' ";
            //添加一条分红纪录
            if (fenhongBll.Add(fenhong) > 0 )
            { 
                //更新参数表
                if (DbHelperSQL.ExecuteSql(sql) >0)
                {
                    //执行分红
                    if (flag_fenhong(Convert.ToDecimal(txtmoney.Text.Trim())) > 0)
                    {
                        MessageBox.ShowAndRedirect(this, "结算成功", "fenhongList.aspx");
                        return;
                    }
                    else
                    {
                        MessageBox.ShowAndRedirect(this, "结算失败", "fenhongList.aspx");
                        return;
                    }
                }
            }
        }
    }
}