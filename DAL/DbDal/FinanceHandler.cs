using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace lgk.DAL.DbDal
{
    public class FinanceHandler
    {
        //广告分红总览与明细
        public DataTable GetAdBonusRs(int userid)
        {
            string sql = "select * from tb_bonus where UserID = " + userid.ToString();
            DataTable table = SQLServerHelper.GetDataTable(sql);
            return table;
        }

        //荣誉奖项查询
        //public DataTable Get

    }
}