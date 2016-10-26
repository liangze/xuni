using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_OrderDetail
	/// </summary>
	public partial class tb_OrderDetail
	{
		public tb_OrderDetail()
        { }
        /// <summary>
        /// 通过订单编号得到一个对象实体
        /// <param name="orderID">订单编号</param>
        /// </summary>
        public lgk.Model.tb_OrderDetail GetModelByOrderCode(string strOrderCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,OrderCode,ProcudeID,ProcudeName,Price,PV,OrderSum,OrderTotal,PVTotal,OrderDate from tb_OrderDetail ");
            strSql.Append(" where OrderCode=@OrderCode");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50)};
            parameters[0].Value = strOrderCode;

            lgk.Model.tb_OrderDetail model = new lgk.Model.tb_OrderDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderCode"] != null && ds.Tables[0].Rows[0]["OrderCode"].ToString() != "")
                {
                    model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProcudeID"] != null && ds.Tables[0].Rows[0]["ProcudeID"].ToString() != "")
                {
                    model.ProcudeID = int.Parse(ds.Tables[0].Rows[0]["ProcudeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProcudeName"] != null && ds.Tables[0].Rows[0]["ProcudeName"].ToString() != "")
                {
                    model.ProcudeName = ds.Tables[0].Rows[0]["ProcudeName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PV"] != null && ds.Tables[0].Rows[0]["PV"].ToString() != "")
                {
                    model.PV = int.Parse(ds.Tables[0].Rows[0]["PV"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderSum"] != null && ds.Tables[0].Rows[0]["OrderSum"].ToString() != "")
                {
                    model.OrderSum = int.Parse(ds.Tables[0].Rows[0]["OrderSum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderTotal"] != null && ds.Tables[0].Rows[0]["OrderTotal"].ToString() != "")
                {
                    model.OrderTotal = decimal.Parse(ds.Tables[0].Rows[0]["OrderTotal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PVTotal"] != null && ds.Tables[0].Rows[0]["PVTotal"].ToString() != "")
                {
                    model.PVTotal = int.Parse(ds.Tables[0].Rows[0]["PVTotal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderDate"] != null && ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "tb_OrderDetail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_OrderDetail");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lgk.Model.tb_OrderDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_OrderDetail(");
			strSql.Append("OrderCode,ProcudeID,ProcudeName,Price,PV,OrderSum,OrderTotal,PVTotal,OrderDate,gColor,gSize)");
			strSql.Append(" values (");
			strSql.Append("@OrderCode,@ProcudeID,@ProcudeName,@Price,@PV,@OrderSum,@OrderTotal,@PVTotal,@OrderDate,@gColor,@gSize)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
					new SqlParameter("@ProcudeID", SqlDbType.Int,4),
					new SqlParameter("@ProcudeName", SqlDbType.VarChar,50),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@PV", SqlDbType.Int,4),
					new SqlParameter("@OrderSum", SqlDbType.Int,4),
					new SqlParameter("@OrderTotal", SqlDbType.Decimal,9),
					new SqlParameter("@PVTotal", SqlDbType.Int,4),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
                                new SqlParameter("@gColor", SqlDbType.VarChar),
                   new SqlParameter("@gSize", SqlDbType.VarChar)};
			parameters[0].Value = model.OrderCode;
			parameters[1].Value = model.ProcudeID;
			parameters[2].Value = model.ProcudeName;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.PV;
			parameters[5].Value = model.OrderSum;
			parameters[6].Value = model.OrderTotal;
            parameters[7].Value = model.PVTotal;
            parameters[8].Value = model.OrderDate;
            parameters[9].Value = model.gColor;
            parameters[10].Value = model.gSize;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_OrderDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_OrderDetail set ");
			strSql.Append("OrderCode=@OrderCode,");
			strSql.Append("ProcudeID=@ProcudeID,");
			strSql.Append("ProcudeName=@ProcudeName,");
			strSql.Append("Price=@Price,");
			strSql.Append("PV=@PV,");
			strSql.Append("OrderSum=@OrderSum,");
			strSql.Append("OrderTotal=@OrderTotal,");
			strSql.Append("PVTotal=@PVTotal,");
			strSql.Append("OrderDate=@OrderDate");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
					new SqlParameter("@ProcudeID", SqlDbType.Int,4),
					new SqlParameter("@ProcudeName", SqlDbType.VarChar,50),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@PV", SqlDbType.Int,4),
					new SqlParameter("@OrderSum", SqlDbType.Int,4),
					new SqlParameter("@OrderTotal", SqlDbType.Decimal,9),
					new SqlParameter("@PVTotal", SqlDbType.Int,4),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.OrderCode;
			parameters[1].Value = model.ProcudeID;
			parameters[2].Value = model.ProcudeName;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.PV;
			parameters[5].Value = model.OrderSum;
			parameters[6].Value = model.OrderTotal;
			parameters[7].Value = model.PVTotal;
			parameters[8].Value = model.OrderDate;
			parameters[9].Value = model.ID;

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
		public bool Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_OrderDetail ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
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
		/// 删除一条数据
		/// </summary>
        public bool Delete(string strOrderCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_OrderDetail ");
            strSql.Append(" where OrderCode=@OrderCode");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50)};
            parameters[0].Value = strOrderCode;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_OrderDetail ");
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
		public lgk.Model.tb_OrderDetail GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OrderCode,ProcudeID,ProcudeName,Price,PV,OrderSum,OrderTotal,PVTotal,OrderDate from tb_OrderDetail ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			lgk.Model.tb_OrderDetail model=new lgk.Model.tb_OrderDetail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderCode"]!=null && ds.Tables[0].Rows[0]["OrderCode"].ToString()!="")
				{
					model.OrderCode=ds.Tables[0].Rows[0]["OrderCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProcudeID"]!=null && ds.Tables[0].Rows[0]["ProcudeID"].ToString()!="")
				{
					model.ProcudeID=int.Parse(ds.Tables[0].Rows[0]["ProcudeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProcudeName"]!=null && ds.Tables[0].Rows[0]["ProcudeName"].ToString()!="")
				{
					model.ProcudeName=ds.Tables[0].Rows[0]["ProcudeName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Price"]!=null && ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PV"]!=null && ds.Tables[0].Rows[0]["PV"].ToString()!="")
				{
					model.PV=int.Parse(ds.Tables[0].Rows[0]["PV"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderSum"]!=null && ds.Tables[0].Rows[0]["OrderSum"].ToString()!="")
				{
					model.OrderSum=int.Parse(ds.Tables[0].Rows[0]["OrderSum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderTotal"]!=null && ds.Tables[0].Rows[0]["OrderTotal"].ToString()!="")
				{
					model.OrderTotal=decimal.Parse(ds.Tables[0].Rows[0]["OrderTotal"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PVTotal"]!=null && ds.Tables[0].Rows[0]["PVTotal"].ToString()!="")
				{
					model.PVTotal=int.Parse(ds.Tables[0].Rows[0]["PVTotal"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderDate"]!=null && ds.Tables[0].Rows[0]["OrderDate"].ToString()!="")
				{
					model.OrderDate=DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
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
			strSql.Append("select ID,OrderCode,ProcudeID,ProcudeName,Price,PV,OrderSum,OrderTotal,PVTotal,OrderDate ");
			strSql.Append(" FROM tb_OrderDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetJoinList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 d.*,o.*");
            strSql.Append(" FROM [tb_OrderDetail] d JOIN tb_Order AS o ON o.OrderCode = d.OrderCode WHERE " + strWhere + "");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetJoinListAll(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT d.*,o.* FROM [tb_OrderDetail] d JOIN tb_Order AS o ON o.OrderCode = d.OrderCode WHERE " + strWhere + "");
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
			strSql.Append(" ID,OrderCode,ProcudeID,ProcudeName,Price,PV,OrderSum,OrderTotal,PVTotal,OrderDate ");
			strSql.Append(" FROM tb_OrderDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "tb_OrderDetail";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

