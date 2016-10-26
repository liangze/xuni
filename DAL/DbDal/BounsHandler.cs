using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess;
using lgk.DAL.DbDal;

namespace lgk.DAL.DbDal
{
    public class BounsHandler
    {
        //广告分红
        public int HandleAdBouns()
        {
            DayOfWeek today = DateTime.Now.DayOfWeek;
            int weekday = (int)today;//今天星期几
            int balanceday = weekday - 1;//作为从今天推算星期一日期的基数
            DateTime monday = DateTime.Now.Date.AddDays(- balanceday);//星期一所在的日期
            int isadday = 0;//表示周一到周五
            if (weekday == 6 || weekday == 7)
            {
                isadday = 1;//表示周六，周日
            }

            IDataParameter[] param = {
                                       new SqlParameter ("@WeekDay",weekday),
                                       new SqlParameter ("@IsAdDay",isadday),
                                       new SqlParameter ("@Monday",monday),
                                       new SqlParameter ("@Today",DateTime.Now)
                                   };
            int n = SQLServerHelper.ExecuteSql("Proc_tb_AllUserAdBouns", param);
            return n;
        }

        //找出所有创业合伙人
        private List<TUser> GetAllPartner()
        {
            SqlParameter[] param = {};
            SqlDataReader reader = SQLServerHelper.ExecuteReader("tb_GetAllPartner", param);
            if (reader == null)
            {
                return null;
            }
            if (reader.HasRows == false)
            {
                reader.Close();
                return null;
            }
            List<TUser> partners = new List<TUser>();
            while (reader.Read())
            {
                TUser user = new TUser();
                user.UserID = Convert.ToInt32(reader["UserID"]);
                partners.Add(user);
            }
            reader.Close();
            return partners;
        }

        //创业合伙人分红：手动输入分红金额，系统自动平均分配
        public int HandlePartnerBouns(decimal bounsMoney)
        {
            IDataParameter[] param = {
                                       new SqlParameter ("@BounsMoney",bounsMoney)
                                   };
            int n = SQLServerHelper.ExecuteSql("Proc_tb_HandlePartnerBouns", param);
            return n;
        }

        //结算荣誉奖
        public int HandleHonoraryAward(string userId,decimal totalRegMoney)
        {
            IDataParameter[] param = {
                                       new SqlParameter ("@UserID",userId),
                                       new SqlParameter ("@TotalRegMoney",totalRegMoney)
                                   };
            int n = SQLServerHelper.ExecuteSql("tb_HandlePartnerBouns", param);
            return n;
        }

        //统计各种奖项的总额

    }
}