using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.shop
{
    public partial class JinpaiList : PageCore
    {
        public string cnen = "zh-cn";
        protected void Page_Load(object sender, EventArgs e)
        {
            cnen = GetLanguage("LoginLable");
            if (!IsPostBack)
            {
                bind();
            }
            //竞拍
            gp_opBLL.ExecProc("proc_salesroom");
        }
        void bind() 
        {
            bind_repeater(auctionBll.GetListWithSalesroom("SaState<>0"), rptProduct, "SaNumber asc,AuctionTime desc", tr1, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
        public string getStatus(string Status, string sBeginTime)
        { 
            //（0下架，1上架，2已成交，3已失败）
            DateTime BeginTime = Convert.ToDateTime(sBeginTime);
            string newStatus;
            switch (Status)
            {
                case "0": newStatus = GetLanguage("xiajia"); break;
                case "1":
                    if (BeginTime > DateTime.Now)
                    {
                        newStatus = GetLanguage("weikaishi");
                    }
                    else
                    {
                        newStatus = GetLanguage("jingpaizhong");
                    }
                    break;
                case "2": newStatus = GetLanguage("yichangjiao"); break;
                case "3": newStatus = GetLanguage("yishibai"); break;
                default: newStatus = GetLanguage("weizhi"); break;
            }
            return newStatus;
        }
    }
}