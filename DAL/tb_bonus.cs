using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_bonus
	/// </summary>
	public partial class tb_bonus
	{
		public tb_bonus()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_bonus ");
            strSql.Append(" where Bonus002=0 and ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.tb_bonus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_bonus(");
			strSql.Append("UserID,TypeID,Amount,AddTime,IsSettled,Source,SttleTime,FromUserID,Bonus001,Bonus002,Bonus003,Bonus004,Bonus005,Bonus006,Bonus007)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@TypeID,@Amount,@AddTime,@IsSettled,@Source,@SttleTime,@FromUserID,@Bonus001,@Bonus002,@Bonus003,@Bonus004,@Bonus005,@Bonus006,@Bonus007)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IsSettled", SqlDbType.Int,4),
					new SqlParameter("@Source", SqlDbType.VarChar,50),
					new SqlParameter("@SttleTime", SqlDbType.DateTime),
					new SqlParameter("@FromUserID", SqlDbType.Int,4),
					new SqlParameter("@Bonus001", SqlDbType.Int,4),
					new SqlParameter("@Bonus002", SqlDbType.Int,4),
					new SqlParameter("@Bonus003", SqlDbType.VarChar,50),
					new SqlParameter("@Bonus004", SqlDbType.VarChar,50),
					new SqlParameter("@Bonus005", SqlDbType.Decimal,9),
					new SqlParameter("@Bonus006", SqlDbType.Decimal,9),
					new SqlParameter("@Bonus007", SqlDbType.DateTime)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.TypeID;
			parameters[2].Value = model.Amount;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.IsSettled;
			parameters[5].Value = model.Source;
			parameters[6].Value = model.SttleTime;
			parameters[7].Value = model.FromUserID;
			parameters[8].Value = model.Bonus001;
			parameters[9].Value = model.Bonus002;
			parameters[10].Value = model.Bonus003;
			parameters[11].Value = model.Bonus004;
			parameters[12].Value = model.Bonus005;
			parameters[13].Value = model.Bonus006;
			parameters[14].Value = model.Bonus007;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}

        /// <summary>
        /// 计算总奖金
        /// </summary>
        public decimal CountAmount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ISNULL(SUM(Amount),0)AS zjj");
            strSql.Append(" FROM tb_bonus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            decimal money = 0;
            if (obj != null)
            {
                decimal.TryParse(obj.ToString(), out money);
            }
            return money;
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_bonus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_bonus set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("TypeID=@TypeID,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("IsSettled=@IsSettled,");
			strSql.Append("Source=@Source,");
			strSql.Append("SttleTime=@SttleTime,");
			strSql.Append("FromUserID=@FromUserID,");
			strSql.Append("Bonus001=@Bonus001,");
			strSql.Append("Bonus002=@Bonus002,");
			strSql.Append("Bonus003=@Bonus003,");
			strSql.Append("Bonus004=@Bonus004,");
			strSql.Append("Bonus005=@Bonus005,");
			strSql.Append("Bonus006=@Bonus006,");
			strSql.Append("Bonus007=@Bonus007");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@IsSettled", SqlDbType.Int,4),
					new SqlParameter("@Source", SqlDbType.VarChar,50),
					new SqlParameter("@SttleTime", SqlDbType.DateTime),
					new SqlParameter("@FromUserID", SqlDbType.Int,4),
					new SqlParameter("@Bonus001", SqlDbType.Int,4),
					new SqlParameter("@Bonus002", SqlDbType.Int,4),
					new SqlParameter("@Bonus003", SqlDbType.VarChar,50),
					new SqlParameter("@Bonus004", SqlDbType.VarChar,50),
					new SqlParameter("@Bonus005", SqlDbType.Decimal,9),
					new SqlParameter("@Bonus006", SqlDbType.Decimal,9),
					new SqlParameter("@Bonus007", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.TypeID;
			parameters[2].Value = model.Amount;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.IsSettled;
			parameters[5].Value = model.Source;
			parameters[6].Value = model.SttleTime;
			parameters[7].Value = model.FromUserID;
			parameters[8].Value = model.Bonus001;
			parameters[9].Value = model.Bonus002;
			parameters[10].Value = model.Bonus003;
			parameters[11].Value = model.Bonus004;
			parameters[12].Value = model.Bonus005;
			parameters[13].Value = model.Bonus006;
			parameters[14].Value = model.Bonus007;
			parameters[15].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_bonus ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// 删除数据(逻辑删除)
        /// </summary>
        public bool Delete(string whereCondition)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  tb_bonus set Bonus002=1");
            strSql.Append(" where " + whereCondition);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除综合服务费(清零)
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public bool DeleteRevenue(string whereCondition)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  tb_bonus set Revenue=0");
            strSql.Append(" where " + whereCondition);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除重复消费(清零)
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public bool DeleteBonus006(string whereCondition)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  tb_bonus set Bonus006=0");
            strSql.Append(" where " + whereCondition);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_bonus ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_bonus GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,TypeID,Amount,AddTime,IsSettled,Source,SttleTime,FromUserID,Bonus001,Bonus002,Bonus003,Bonus004,Bonus005,Bonus006,Bonus007 from tb_bonus ");
            strSql.Append(" where Bonus002=0 and  ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			lgk.Model.tb_bonus model=new lgk.Model.tb_bonus();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserID"]!=null && ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TypeID"]!=null && ds.Tables[0].Rows[0]["TypeID"].ToString()!="")
				{
					model.TypeID=int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Amount"]!=null && ds.Tables[0].Rows[0]["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddTime"]!=null && ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSettled"]!=null && ds.Tables[0].Rows[0]["IsSettled"].ToString()!="")
				{
					model.IsSettled=int.Parse(ds.Tables[0].Rows[0]["IsSettled"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Source"]!=null && ds.Tables[0].Rows[0]["Source"].ToString()!="")
				{
					model.Source=ds.Tables[0].Rows[0]["Source"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SttleTime"]!=null && ds.Tables[0].Rows[0]["SttleTime"].ToString()!="")
				{
					model.SttleTime=DateTime.Parse(ds.Tables[0].Rows[0]["SttleTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FromUserID"]!=null && ds.Tables[0].Rows[0]["FromUserID"].ToString()!="")
				{
					model.FromUserID=int.Parse(ds.Tables[0].Rows[0]["FromUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Bonus001"]!=null && ds.Tables[0].Rows[0]["Bonus001"].ToString()!="")
				{
					model.Bonus001=int.Parse(ds.Tables[0].Rows[0]["Bonus001"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Bonus002"]!=null && ds.Tables[0].Rows[0]["Bonus002"].ToString()!="")
				{
					model.Bonus002=int.Parse(ds.Tables[0].Rows[0]["Bonus002"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Bonus003"]!=null && ds.Tables[0].Rows[0]["Bonus003"].ToString()!="")
				{
					model.Bonus003=ds.Tables[0].Rows[0]["Bonus003"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Bonus004"]!=null && ds.Tables[0].Rows[0]["Bonus004"].ToString()!="")
				{
					model.Bonus004=ds.Tables[0].Rows[0]["Bonus004"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Bonus005"]!=null && ds.Tables[0].Rows[0]["Bonus005"].ToString()!="")
				{
					model.Bonus005=decimal.Parse(ds.Tables[0].Rows[0]["Bonus005"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Bonus006"]!=null && ds.Tables[0].Rows[0]["Bonus006"].ToString()!="")
				{
					model.Bonus006=decimal.Parse(ds.Tables[0].Rows[0]["Bonus006"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Bonus007"]!=null && ds.Tables[0].Rows[0]["Bonus007"].ToString()!="")
				{
					model.Bonus007=DateTime.Parse(ds.Tables[0].Rows[0]["Bonus007"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserID,TypeID,Amount,AddTime,IsSettled,Source,SttleTime,FromUserID,Bonus001,Bonus002,Bonus003,Bonus004,Bonus005,Bonus006,Bonus007 ");
			strSql.Append(" FROM tb_bonus ");
			if(strWhere.Trim()!="")
			{
                strSql.Append(" where " + strWhere + " and Bonus002=0");
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 导出用户奖金信息专用
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListByUser(string strWhere) 
        {
            StringBuilder strSql = null;
           


            if (strWhere.Trim() != "")
            {
                strSql = new StringBuilder();
                strSql.Append("select u.UserCode,u.BankAccount,u.BankAccountUser,u.BankBranch,b.sf from (select SUM(sf) as sf,userid from tb_bonus where 1=1 " + strWhere + " group by UserID )b inner join tb_user u on u.UserID=b.UserID");
                // strSql.Append(" where " + strWhere );
            }
            else 
            {
                strSql = new StringBuilder();
                strSql.Append("select u.UserCode,u.BankAccount,u.BankAccountUser,u.BankBranch,b.sf  from (select SUM(sf) as sf,userid from tb_bonus  group by UserID )b inner join tb_user u on u.UserID=b.UserID");
            }
            return DbHelperSQL.Query(strSql.ToString());

        }
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,UserID,TypeID,Amount,AddTime,IsSettled,Source,SttleTime,FromUserID,Bonus001,Bonus002,Bonus003,Bonus004,Bonus005,Bonus006,Bonus007 ");
			strSql.Append(" FROM tb_bonus ");
			if(strWhere.Trim()!="")
			{
                strSql.Append(" where " + strWhere + " and Bonus002=0");
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_bonus";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        /// <summary>
        /// 执行给定的存储过程。
        /// </summary>
        /// <param name="strProcName">给定的存储过程</param>
        /// <returns></returns>
        public int ExecProcedure(string strProcName)
        {
            int iResult = 0;

            try
            {
                iResult = SqlHelper.ExecuteNonQuery(SqlHelper.connStrs, CommandType.StoredProcedure, strProcName, null);

                if (iResult != -1)
                    return 1;
                else
                    return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 结算购物奖
        /// </summary>
        /// <param name="iUserID">购买者ID</param>
        /// <param name="dMoney">购买金额</param>
        /// <returns></returns>
        public int ShoppingAward(long iUserID, decimal dMoney)
        {
            int result;
            string prop = "proc_Award_Shopping";
            SqlParameter[] para = { new SqlParameter("@UserID", SqlDbType.BigInt,8),
                                    new SqlParameter("@Money ", SqlDbType.Decimal,9)};
            para[0].Value = iUserID;
            para[1].Value = dMoney;

            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }

		#endregion  Method
	}
}

