using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:Cashorder
    /// </summary>
    public partial class Cashorder
    {
        public Cashorder()
		{ }

        #region Method

        public bool Exists(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cashorder where OrderID = @OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt,8)};
            parameters[0].Value = OrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cashorder(");
            strSql.Append("BRemark,SStatus,SendDate,SRemark,Status,CashbuyID,CashsellID,BUserID,SUserID,OrderCode,OrderDate,BStatus,PayDate");
            strSql.Append(") values (");
            strSql.Append("@BRemark,@SStatus,@SendDate,@SRemark,@Status,@CashbuyID,@CashsellID,@BUserID,@SUserID,@OrderCode,@OrderDate,@BStatus,@PayDate");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@CashbuyID", SqlDbType.BigInt,8),
                        new SqlParameter("@CashsellID", SqlDbType.BigInt,8),
                        new SqlParameter("@BUserID", SqlDbType.BigInt,8),
                        new SqlParameter("@SUserID", SqlDbType.BigInt,8),
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
                        new SqlParameter("@OrderDate", SqlDbType.DateTime),
                        new SqlParameter("@BStatus", SqlDbType.Int,4),
                        new SqlParameter("@PayDate", SqlDbType.DateTime),
                        new SqlParameter("@BRemark", SqlDbType.VarChar,500),
                        new SqlParameter("@SStatus", SqlDbType.Int,4),
                        new SqlParameter("@SendDate", SqlDbType.DateTime),
                        new SqlParameter("@SRemark", SqlDbType.VarChar,500),
                        new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.CashbuyID;
            parameters[1].Value = model.CashsellID;
            parameters[2].Value = model.BUserID;
            parameters[3].Value = model.SUserID;
            parameters[4].Value = model.OrderCode;
            parameters[5].Value = model.OrderDate;
            parameters[6].Value = model.BStatus;
            parameters[7].Value = model.PayDate;//DBNull.Value;
            parameters[8].Value = model.BRemark;
            parameters[9].Value = model.SStatus;
            parameters[10].Value = model.SendDate; //DBNull.Value;
            parameters[11].Value = model.SRemark;
            parameters[12].Value = model.Status;
      

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.Cashorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cashorder set");
            strSql.Append(" CashbuyID = @CashbuyID,");
            strSql.Append(" CashsellID = @CashsellID,");
            strSql.Append(" BUserID = @BUserID,");
            strSql.Append(" SUserID = @SUserID,");
            strSql.Append(" OrderCode = @OrderCode,");
            strSql.Append(" OrderDate = @OrderDate,");
            strSql.Append(" BStatus = @BStatus,");
            strSql.Append(" PayDate = @PayDate,  ");
            strSql.Append(" BRemark = @BRemark,");
            strSql.Append(" SStatus = @SStatus,");
            strSql.Append(" SendDate = @SendDate,");
            strSql.Append(" SRemark = @SRemark,");
            strSql.Append(" Status = @Status");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
			            new SqlParameter("@OrderID", SqlDbType.BigInt,8),
                        new SqlParameter("@CashbuyID", SqlDbType.BigInt,8),
                        new SqlParameter("@CashsellID", SqlDbType.BigInt,8),
                        new SqlParameter("@BUserID", SqlDbType.BigInt,8),
                        new SqlParameter("@SUserID", SqlDbType.BigInt,8),
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
                        new SqlParameter("@OrderDate", SqlDbType.DateTime),
                        new SqlParameter("@BStatus", SqlDbType.Int,4),
                        new SqlParameter("@PayDate", SqlDbType.DateTime),
                        new SqlParameter("@BRemark", SqlDbType.VarChar,500),
                        new SqlParameter("@SStatus", SqlDbType.Int,4),
                        new SqlParameter("@SendDate", SqlDbType.DateTime),
                        new SqlParameter("@SRemark", SqlDbType.VarChar,500),
                        new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.CashbuyID;
            parameters[2].Value = model.CashsellID;
            parameters[3].Value = model.BUserID;
            parameters[4].Value = model.SUserID;
            parameters[5].Value = model.OrderCode;
            parameters[6].Value = model.OrderDate;
            parameters[7].Value = model.BStatus;
            parameters[8].Value = model.PayDate;
            parameters[9].Value = model.BRemark;
            parameters[10].Value = model.SStatus;
            parameters[11].Value = model.SendDate;
            parameters[12].Value = model.SRemark;
            parameters[13].Value = model.Status;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 根据给定的用户ID和订单编号，修改订单状态（1付款，2确认已付款，3发货）。
        /// </summary>
        /// <param name="iUserID">给定的用户编号</param>
        /// <param name="iOrderID">给定的订单编号</param>
        /// <param name="dtDate">给定的时间</param>
        /// <param name="iActionID">1付款，2确认已付款，3发货，4撤销</param>
        /// <returns></returns>
        public int Update(long iUserID, long iOrderID, DateTime dtDate, int iActionID)
        {
            int iRows = 0;
            if (iActionID == 1)//付款
            {
                //strSql = "UPDATE [Cashorder] SET [PayDate]=" + dtDate + ",[BStatus]=1 WHERE [OrderID]=" + iOrderID + " AND [BUserID]=" + iUserID + "";
                StringBuilder strSqlOne = new StringBuilder();
                strSqlOne.Append("UPDATE Cashorder SET ");
                strSqlOne.Append(" BStatus = @BStatus,");
                strSqlOne.Append(" PayDate = @PayDate");
                strSqlOne.Append(" WHERE OrderID=@OrderID");
                strSqlOne.Append(" AND BUserID=@BUserID");
                SqlParameter[] paraOne = {
                            new SqlParameter("@OrderID", SqlDbType.BigInt,8),
                            new SqlParameter("@BUserID", SqlDbType.BigInt,8),
                            new SqlParameter("@BStatus", SqlDbType.Int,4),
                            new SqlParameter("@PayDate", SqlDbType.DateTime)};
                paraOne[0].Value = iOrderID;
                paraOne[1].Value = iUserID;
                paraOne[2].Value = 1;
                paraOne[3].Value = dtDate;

                iRows = DbHelperSQL.ExecuteSql(strSqlOne.ToString(), paraOne);
            }
            else if (iActionID == 2)//确认已付款
            {
                //strSql = "UPDATE [Cashorder] SET [SendDate]=" + dtDate + ",[SStatus]=1 WHERE [OrderID]=" + iOrderID + " AND [SUserID]=" + iUserID + "";
                StringBuilder strSqlTwo = new StringBuilder();
                strSqlTwo.Append("UPDATE Cashorder SET ");
                strSqlTwo.Append(" SStatus = @SStatus");
                strSqlTwo.Append(" WHERE OrderID=@OrderID");
                strSqlTwo.Append(" AND SUserID=@SUserID");
                SqlParameter[] paraTwo = {
                            new SqlParameter("@OrderID", SqlDbType.BigInt,8),
                            new SqlParameter("@SUserID", SqlDbType.BigInt,8),
                            new SqlParameter("@SStatus", SqlDbType.Int,4)};
                paraTwo[0].Value = iOrderID;
                paraTwo[1].Value = iUserID;
                paraTwo[2].Value = 1;

                iRows = DbHelperSQL.ExecuteSql(strSqlTwo.ToString(), paraTwo);
            }
            else if (iActionID == 3)//发货
            {
                //strSql = "UPDATE [Cashorder] SET [SendDate]=" + dtDate + ",[SStatus]=1 WHERE [OrderID]=" + iOrderID + " AND [SUserID]=" + iUserID + "";
                StringBuilder strSqlThree = new StringBuilder();
                strSqlThree.Append("UPDATE Cashorder SET ");
                strSqlThree.Append(" Status = @Status,");
                strSqlThree.Append(" SendDate = @SendDate");
                strSqlThree.Append(" WHERE OrderID=@OrderID");
                strSqlThree.Append(" AND SUserID=@SUserID");
                SqlParameter[] paraTwo = {
                            new SqlParameter("@OrderID", SqlDbType.BigInt,8),
                            new SqlParameter("@SUserID", SqlDbType.BigInt,8),
                            new SqlParameter("@Status", SqlDbType.Int,4),
                            new SqlParameter("@SendDate", SqlDbType.DateTime)};
                paraTwo[0].Value = iOrderID;
                paraTwo[1].Value = iUserID;
                paraTwo[2].Value = 1;
                paraTwo[3].Value = dtDate;

                iRows = DbHelperSQL.ExecuteSql(strSqlThree.ToString(), paraTwo);
            }

            return iRows;
        }

        /// <summary>
        /// 更新数据终止交易
        /// </summary>
        /// <param name="strFiled">更新的字段</param>
        /// <param name="iOrderID">订单编号</param>
        /// <param name="iUserID">给定用户编号</param>
        /// <param name="iStatus">状态</param>
        /// <param name="iActionID">1为买家终止,2为卖家终止</param>
        /// <returns></returns>
        public int Update(string strRemark, long iOrderID, long iUserID, int iActionID)
        {
            string strSQL = "";

            if (iActionID == 1)
            {
                strSQL = "UPDATE [Cashorder] SET [BRemark]='" + strRemark + "',[BStatus]=2 WHERE [OrderID]=" + iOrderID + " AND [BUserID]=" + iUserID;
            }
            else if (iActionID == 2)
            {
                strSQL = "UPDATE [Cashorder] SET [SRemark]='" + strRemark + "',[SStatus]=2 WHERE [OrderID]=" + iOrderID + " AND [SUserID]=" + iUserID;
            }
            return DbHelperSQL.ExecuteSql(strSQL);
        }

        /// <summary>
        /// 根据给定的订单ID，将订单撤销。
        /// </summary>
        /// <param name="iOrderID">给定的订单ID</param>
        /// <param name="strRemark">撤销备注</param>
        /// <returns></returns>
        public int UndoOrder(long iOrderID, string strRemark)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE Cashorder SET ");
            strSQL.Append(" SStatus = @SStatus,");
            strSQL.Append(" BStatus = @BStatus,");
            strSQL.Append(" [Status] = @Status,");
            strSQL.Append(" SRemark = @SRemark,");
            strSQL.Append(" BRemark = @BRemark");
            strSQL.Append(" WHERE OrderID=@OrderID");
            SqlParameter[] param = {
                            new SqlParameter("@OrderID", SqlDbType.BigInt,8),
                            new SqlParameter("@SStatus", SqlDbType.Int,4),
                            new SqlParameter("@BStatus", SqlDbType.Int,4),
                            new SqlParameter("@Status", SqlDbType.Int,4),
                            new SqlParameter("@SRemark", SqlDbType.VarChar,500),
                            new SqlParameter("@BRemark", SqlDbType.VarChar,500)};
            param[0].Value = iOrderID;
            param[1].Value = 2;
            param[2].Value = 2;
            param[3].Value = 2;
            param[4].Value = strRemark;
            param[5].Value = strRemark;

            return DbHelperSQL.ExecuteSql(strSQL.ToString(), param);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashorder ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt,8)};
            parameters[0].Value = OrderID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string OrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashorder ");
            strSql.Append(" where ID in (" + OrderIDlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashorder GetModel(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderID, CashbuyID, CashsellID, BUserID, SUserID, OrderCode, OrderDate, BStatus, PayDate, BRemark, SStatus, SendDate, SRemark, Status");
            strSql.Append(" from Cashorder ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt,8)};
            parameters[0].Value = OrderID;

            lgk.Model.Cashorder model = new lgk.Model.Cashorder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = long.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CashbuyID"].ToString() != "")
                {
                    model.CashbuyID = long.Parse(ds.Tables[0].Rows[0]["CashbuyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CashsellID"].ToString() != "")
                {
                    model.CashsellID = long.Parse(ds.Tables[0].Rows[0]["CashsellID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BUserID"].ToString() != "")
                {
                    model.BUserID = long.Parse(ds.Tables[0].Rows[0]["BUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SUserID"].ToString() != "")
                {
                    model.SUserID = long.Parse(ds.Tables[0].Rows[0]["SUserID"].ToString());
                }
                model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                if (ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BStatus"].ToString() != "")
                {
                    model.BStatus = int.Parse(ds.Tables[0].Rows[0]["BStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayDate"].ToString() != "")
                {
                    model.PayDate = DateTime.Parse(ds.Tables[0].Rows[0]["PayDate"].ToString());
                }
                model.BRemark = ds.Tables[0].Rows[0]["BRemark"].ToString();
                if (ds.Tables[0].Rows[0]["SStatus"].ToString() != "")
                {
                    model.SStatus = int.Parse(ds.Tables[0].Rows[0]["SStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SendDate"].ToString() != "")
                {
                    model.SendDate = DateTime.Parse(ds.Tables[0].Rows[0]["SendDate"].ToString());
                }
                model.SRemark = ds.Tables[0].Rows[0]["SRemark"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Cashorder");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Cashorder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据给定的条件，获取订单列表
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public DataSet GetOrderList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Cashorder.*,Cashbuy.* FROM Cashorder LEFT JOIN Cashbuy on Cashorder.CashbuyID = Cashbuy.CashbuyID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region 走势图
        public DataSet GetMimuteChart(int iMinute)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" declare @a int = " + iMinute + ";");
            strSql.Append(" SELECT cast(floor(cast(BuyDate as float)*24*60/@a)*@a/60/24 as smalldatetime) as showtime,Max(Price) maxprice,MIN(Price) minprice");
            strSql.Append(" from Cashbuy ");
            strSql.Append(" group by cast(floor(cast(BuyDate as float)*24*60/@a)*@a/60/24 as smalldatetime) ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetHourChart(int iHour)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" declare @a int = " + iHour + ";");
            strSql.Append(" SELECT cast(floor(cast(BuyDate as float)*24/@a)*@a/24 as smalldatetime) as showtime,Max(Price) maxprice,MIN(Price) minprice");
            strSql.Append(" from Cashbuy ");
            strSql.Append(" group by cast(floor(cast(BuyDate as float)*24/@a)*@a/24 as smalldatetime) ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetDayChart(int iHour)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" declare @a int = " + iHour + ";");
            strSql.Append(" SELECT cast(floor(cast(b.BuyDate as float)/@a)*@a as smalldatetime) as showtime,Max(b.Price) maxprice,MIN(b.Price) minprice ");
            strSql.Append(" from Cashorder as o right join Cashbuy as b on o.CashbuyID=b.CashbuyID ");
            strSql.Append(" group by cast(floor(cast(b.BuyDate as float)/@a)*@a as smalldatetime)  ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        #region 获取开盘价格
        /// <summary>
        /// 获取开盘价格
        /// </summary>
        /// <param name="dDtime">时间</param>
        /// <param name="a">查询的时间段</param>
        /// <param name="type">1：分钟，2：小时，3：天</param>
        /// <returns></returns>
        public decimal GetOpenPrice(string dDtime, int a, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top 1 b.Price from Cashorder as o right join Cashbuy as b on o.CashbuyID=b.CashbuyID ");
            if (type == 1)
            {
                strSql.Append(" where b.BuyDate between '" + dDtime + "' and dateAdd(minute," + a + ",'" + dDtime + "') order by b.BuyDate asc");
            }
            else if (type == 2)
            {
                strSql.Append(" where b.BuyDate between '" + dDtime + "' and dateAdd(hour," + a + ",'" + dDtime + "') order by b.BuyDate asc");
            }
            else if (type == 3)
            {
                strSql.Append(" where b.BuyDate between '" + dDtime + "' and dateAdd(day," + a + ",'" + dDtime + "') order by b.BuyDate asc");
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToDecimal(obj);
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 获取收盘价格
        /// <summary>
        /// 获取收盘价格
        /// </summary>
        /// <param name="dDtime">时间</param>
        /// <param name="a">查询的时间段</param>
        /// <param name="type">1：分钟，2：小时，3：天</param>
        /// <returns></returns>
        public decimal GetClosePrice(string dDtime, int a, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top 1 b.Price from Cashorder as o right join Cashbuy as b on o.CashbuyID=b.CashbuyID ");
            if (type == 1)
            {
                strSql.Append(" where b.BuyDate between '" + dDtime + "' and dateAdd(minute," + a + ",'" + dDtime + "') order by b.BuyDate desc");
            }
            else if (type == 2)
            {
                strSql.Append(" where b.BuyDate between '" + dDtime + "' and dateAdd(hour," + a + ",'" + dDtime + "') order by b.BuyDate desc");
            }
            else if (type == 3)
            {
                strSql.Append(" where b.BuyDate between '" + dDtime + "' and dateAdd(day," + a + ",'" + dDtime + "') order by b.BuyDate desc");
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToDecimal(obj);
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 获取总数量
        /// <summary>
        /// 获取收盘价格
        /// </summary>
        /// <param name="dDtime">时间</param>
        /// <param name="a">查询的时间段</param>
        /// <param name="type">1：分钟，2：小时，3：天</param>
        /// <returns></returns>
        public decimal GetSumAmount(string dDtime, int a, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select IsNull(sum(b.Amount),0) from Cashorder as o right join Cashbuy as b on o.CashbuyID=b.CashbuyID ");
            if (type == 1)
            {
                strSql.Append(" where b.BuyDate between '" + dDtime + "' and dateAdd(minute," + a + ",'" + dDtime + "') ");
            }
            else if (type == 2)
            {
                strSql.Append(" where b.BuyDate between '" + dDtime + "' and dateAdd(hour," + a + ",'" + dDtime + "') ");
            }
            else if (type == 3)
            {
                strSql.Append(" where b.BuyDate between '" + dDtime + "' and dateAdd(day," + a + ",'" + dDtime + "') ");
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToDecimal(obj);
            }
            else
            {
                return 0;
            }
        }
        #endregion 
        #endregion

    }
}
