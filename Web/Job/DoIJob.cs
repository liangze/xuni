using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Quartz;
using System.Text;
using Library;
//using Web.sync;

/// <summary>
/// 实现了IJob接口的类，功能是配合InsertKeyWordsAuto类实现定时触发向数据库插入搜索关键字次数
/// </summary>
public class DoIJob : IJob
{
    public void Execute(IJobExecutionContext context)
    {
        #region 写入日志
        String path = AppDomain.CurrentDomain.BaseDirectory;// +"Job\\";

        string s = "启动作业" + DateTime.Now.ToString() + "\r\n";
        System.IO.File.AppendAllText(path + "log.txt", s);
        #endregion

        DateTime startDate, endDate;
        int syncid;
        if (!GetDate(out startDate, out endDate)) return;

        //MallPoints msync = new MallPoints();
        //s = "导入商城积分" + DateTime.Now.ToString() + "\r\n";
        //System.IO.File.AppendAllText(path + "log.txt", s);
        ////导入商城积分
        //if (msync.Import(startDate, endDate,out syncid))
        //{
        //    s = "计算推广佣金" + DateTime.Now.ToString() + "\r\n";
        //    System.IO.File.AppendAllText(path + "log.txt", s);
        //    //计算推广佣金
        //    if (msync.Calc(syncid))
        //    {
        //        msync.AddUserBounsAccount(syncid);
        //        //s = "将计算好的虚拟币（亿币）写回商城" + DateTime.Now.ToString() + "\r\n";
        //        //System.IO.File.AppendAllText(path + "log.txt", s); 
        //        ////将计算好的虚拟币（亿币）写回商城
        //        //msync.Sync();

        //        //s = "将计算好的佣金写到佣金管理系统" + DateTime.Now.ToString() + "\r\n";
        //        //System.IO.File.AppendAllText(path + "log.txt", s);
        //        ////将计算好的佣金写到佣金管理系统
        //        //yongjin yj = new yongjin();
        //        //yj.SyncYongjin();
        //    }
        //}
    }

    private bool GetDate(out DateTime startDate,out DateTime endDate)
    {
        DateTime dt = DateTime.Now;  //当前时间
        startDate = dt;
        endDate = dt;

        if (dt.Day == 15)
        {
            //取上个月 16日 至 31日
            startDate = dt.AddMonths(-1);

            startDate = Convert.ToDateTime(startDate.ToShortDateString());

            startDate = startDate.AddDays(1 - startDate.Day); //本月月初
            endDate = startDate.AddMonths(1).AddDays(-1);//本月月末
            endDate = Convert.ToDateTime(endDate.ToString("yyyy-MM-dd 23:59:59"));

            startDate = startDate.AddDays(15); //本月16日

        }
        else if (dt.Day == 1)
        {
            //取上个月 1日 至 15日
            startDate = dt.AddMonths(-1);

            startDate = Convert.ToDateTime(startDate.ToShortDateString());

            startDate = startDate.AddDays(1 - startDate.Day); //本月月初

            endDate = startDate.AddDays(14);//本月15日
            endDate = Convert.ToDateTime(endDate.ToString("yyyy-MM-dd 23:59:59"));
        }
        else
            return false;

        return true;
    }
}