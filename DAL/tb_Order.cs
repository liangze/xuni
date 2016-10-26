using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_Order
    /// </summary>
    public partial class tb_Order
    {
        public tb_Order()
        { }
        
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("OrderID", "tb_Order");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Order");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt,8)};
            parameters[0].Value = OrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Order(");
            strSql.Append("UserID,OrderCode,UserAddr,OrderSum,OrderTotal,PVTotal,OrderDate,IsSend,PayMethod,OrderType,Order1,Order2,Order3,Order4,Order5,Order6,Order7,TypeID,PareTopChild)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@OrderCode,@UserAddr,@OrderSum,@OrderTotal,@PVTotal,@OrderDate,@IsSend,@PayMethod,@OrderType,@Order1,@Order2,@Order3,@Order4,@Order5,@Order6,@Order7,@TypeID,@PareTopChild)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
					new SqlParameter("@UserAddr", SqlDbType.VarChar,100),
					new SqlParameter("@OrderSum", SqlDbType.Int,4),
					new SqlParameter("@OrderTotal", SqlDbType.Decimal,9),
					new SqlParameter("@PVTotal", SqlDbType.Decimal,9),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
					new SqlParameter("@IsSend", SqlDbType.Int,4),
					new SqlParameter("@PayMethod", SqlDbType.Int,4),
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@Order1", SqlDbType.Decimal,9),
					new SqlParameter("@Order2", SqlDbType.Decimal,9),
					new SqlParameter("@Order3", SqlDbType.VarChar,100),
					new SqlParameter("@Order4", SqlDbType.VarChar,100),
                    new SqlParameter("@Order5", SqlDbType.VarChar,100),
                    new SqlParameter("@Order6", SqlDbType.VarChar,100),
                    new SqlParameter("@Order7", SqlDbType.VarChar,100),
                    new SqlParameter("@TypeID", SqlDbType.Int,4),
                    new SqlParameter("@PareTopChild", SqlDbType.VarChar,100)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.UserAddr;
            parameters[3].Value = model.OrderSum;
            parameters[4].Value = model.OrderTotal;
            parameters[5].Value = model.PVTotal;
            parameters[6].Value = model.OrderDate;
            parameters[7].Value = model.IsSend;
            parameters[8].Value = model.PayMethod;
            parameters[9].Value = model.OrderType;
            parameters[10].Value = model.Order1;
            parameters[11].Value = model.Order2;
            parameters[12].Value = model.Order3;
            parameters[13].Value = model.Order4;
            parameters[14].Value = model.Order5;
            parameters[15].Value = model.Order6;
            parameters[16].Value = model.Order7;
            parameters[17].Value = model.TypeID;
            parameters[18].Value = model.PareTopChild;

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
        public bool Update(lgk.Model.tb_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Order set");
            strSql.Append(" UserID=@UserID,");
            strSql.Append(" OrderCode=@OrderCode,");
            strSql.Append(" UserAddr=@UserAddr,");
            strSql.Append(" OrderSum=@OrderSum,");
            strSql.Append(" OrderTotal=@OrderTotal,");
            strSql.Append(" PVTotal=@PVTotal,");
            strSql.Append(" OrderDate=@OrderDate,");
            strSql.Append(" IsSend=@IsSend,");
            strSql.Append(" PayMethod=@PayMethod,");
            strSql.Append(" OrderType=@OrderType,");
            strSql.Append(" Order1=@Order1,");
            strSql.Append(" Order2=@Order2,");
            strSql.Append(" Order3=@Order3,");
            strSql.Append(" Order4=@Order4,");
            strSql.Append(" Order5=@Order5,");
            strSql.Append(" Order6=@Order6,");
            strSql.Append(" Order7=@Order7,");
            strSql.Append(" TypeID=@TypeID,");
            strSql.Append(" PareTopChild=@PareTopChild");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
					new SqlParameter("@UserAddr", SqlDbType.VarChar,100),
					new SqlParameter("@OrderSum", SqlDbType.Int,4),
					new SqlParameter("@OrderTotal", SqlDbType.Decimal,9),
					new SqlParameter("@PVTotal", SqlDbType.Decimal,9),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
					new SqlParameter("@IsSend", SqlDbType.Int,4),
					new SqlParameter("@PayMethod", SqlDbType.Int,4),
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@Order1", SqlDbType.Decimal,9),
					new SqlParameter("@Order2", SqlDbType.Decimal,9),
					new SqlParameter("@Order3", SqlDbType.VarChar,100),
					new SqlParameter("@Order4", SqlDbType.VarChar,100),
                    new SqlParameter("@Order5", SqlDbType.VarChar,100),
                    new SqlParameter("@Order6", SqlDbType.VarChar,100),
                    new SqlParameter("@Order7", SqlDbType.VarChar,100),
                    new SqlParameter("@TypeID", SqlDbType.Int,4),
                    new SqlParameter("@PareTopChild", SqlDbType.VarChar,100),
					new SqlParameter("@OrderID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.UserAddr;
            parameters[3].Value = model.OrderSum;
            parameters[4].Value = model.OrderTotal;
            parameters[5].Value = model.PVTotal;
            parameters[6].Value = model.OrderDate;
            parameters[7].Value = model.IsSend;
            parameters[8].Value = model.PayMethod;
            parameters[9].Value = model.OrderType;
            parameters[10].Value = model.Order1;
            parameters[11].Value = model.Order2;
            parameters[12].Value = model.Order3;
            parameters[13].Value = model.Order4;
            parameters[14].Value = model.Order5;
            parameters[15].Value = model.Order6;
            parameters[16].Value = model.Order7;
            parameters[17].Value = model.TypeID;
            parameters[18].Value = model.PareTopChild;
            parameters[19].Value = model.OrderID;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Order ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string strOrderCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Order ");
            strSql.Append(" where OrderCode=@OrderCode");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50)};
            parameters[0].Value = strOrderCode;

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
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string OrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Order ");
            strSql.Append(" where OrderID in (" + OrderIDlist + ") ");
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
        public lgk.Model.tb_Order GetModel(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from tb_Order ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt,8)};
            parameters[0].Value = OrderID;

            lgk.Model.tb_Order model = new lgk.Model.tb_Order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = long.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderCode"] != null && ds.Tables[0].Rows[0]["OrderCode"].ToString() != "")
                {
                    model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserAddr"] != null && ds.Tables[0].Rows[0]["UserAddr"].ToString() != "")
                {
                    model.UserAddr = ds.Tables[0].Rows[0]["UserAddr"].ToString();
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
                    model.PVTotal = decimal.Parse(ds.Tables[0].Rows[0]["PVTotal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderDate"] != null && ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSend"] != null && ds.Tables[0].Rows[0]["IsSend"].ToString() != "")
                {
                    model.IsSend = int.Parse(ds.Tables[0].Rows[0]["IsSend"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayMethod"] != null && ds.Tables[0].Rows[0]["PayMethod"].ToString() != "")
                {
                    model.PayMethod = int.Parse(ds.Tables[0].Rows[0]["PayMethod"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderType"] != null && ds.Tables[0].Rows[0]["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(ds.Tables[0].Rows[0]["OrderType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Order1"] != null && ds.Tables[0].Rows[0]["Order1"].ToString() != "")
                {
                    model.Order1 = decimal.Parse(ds.Tables[0].Rows[0]["Order1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Order2"] != null && ds.Tables[0].Rows[0]["Order2"].ToString() != "")
                {
                    model.Order2 = decimal.Parse(ds.Tables[0].Rows[0]["Order2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Order3"] != null && ds.Tables[0].Rows[0]["Order3"].ToString() != "")
                {
                    model.Order3 = ds.Tables[0].Rows[0]["Order3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order4"] != null && ds.Tables[0].Rows[0]["Order4"].ToString() != "")
                {
                    model.Order4 = ds.Tables[0].Rows[0]["Order4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order5"] != null && ds.Tables[0].Rows[0]["Order5"].ToString() != "")
                {
                    model.Order5 = ds.Tables[0].Rows[0]["Order5"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order6"] != null && ds.Tables[0].Rows[0]["Order6"].ToString() != "")
                {
                    model.Order6 = ds.Tables[0].Rows[0]["Order6"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order7"] != null && ds.Tables[0].Rows[0]["Order7"].ToString() != "")
                {
                    model.Order7 = ds.Tables[0].Rows[0]["Order7"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Order GetModelByCode(string strOrderCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from tb_Order ");
            strSql.Append(" where OrderCode=@OrderCode");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50)};
            parameters[0].Value = strOrderCode;

            lgk.Model.tb_Order model = new lgk.Model.tb_Order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderCode"] != null && ds.Tables[0].Rows[0]["OrderCode"].ToString() != "")
                {
                    model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserAddr"] != null && ds.Tables[0].Rows[0]["UserAddr"].ToString() != "")
                {
                    model.UserAddr = ds.Tables[0].Rows[0]["UserAddr"].ToString();
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
                    model.PVTotal = decimal.Parse(ds.Tables[0].Rows[0]["PVTotal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderDate"] != null && ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSend"] != null && ds.Tables[0].Rows[0]["IsSend"].ToString() != "")
                {
                    model.IsSend = int.Parse(ds.Tables[0].Rows[0]["IsSend"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayMethod"] != null && ds.Tables[0].Rows[0]["PayMethod"].ToString() != "")
                {
                    model.PayMethod = int.Parse(ds.Tables[0].Rows[0]["PayMethod"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderType"] != null && ds.Tables[0].Rows[0]["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(ds.Tables[0].Rows[0]["OrderType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Order1"] != null && ds.Tables[0].Rows[0]["Order1"].ToString() != "")
                {
                    model.Order1 = decimal.Parse(ds.Tables[0].Rows[0]["Order1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Order2"] != null && ds.Tables[0].Rows[0]["Order2"].ToString() != "")
                {
                    model.Order2 = decimal.Parse(ds.Tables[0].Rows[0]["Order2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Order3"] != null && ds.Tables[0].Rows[0]["Order3"].ToString() != "")
                {
                    model.Order3 = ds.Tables[0].Rows[0]["Order3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order4"] != null && ds.Tables[0].Rows[0]["Order4"].ToString() != "")
                {
                    model.Order4 = ds.Tables[0].Rows[0]["Order4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order5"] != null && ds.Tables[0].Rows[0]["Order5"].ToString() != "")
                {
                    model.Order5 = ds.Tables[0].Rows[0]["Order5"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order6"] != null && ds.Tables[0].Rows[0]["Order6"].ToString() != "")
                {
                    model.Order6 = ds.Tables[0].Rows[0]["Order6"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order7"] != null && ds.Tables[0].Rows[0]["Order7"].ToString() != "")
                {
                    model.Order7 = ds.Tables[0].Rows[0]["Order7"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TypeID"] != null && ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PareTopChild"] != null && ds.Tables[0].Rows[0]["PareTopChild"].ToString() != "")
                {
                    model.PareTopChild = ds.Tables[0].Rows[0]["TypeID"].ToString();
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
            strSql.Append("select * FROM tb_Order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * FROM tb_Order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "tb_Order";
            parameters[1].Value = "OrderID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Order GetModel(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from tb_Order ");
            if (strwhere != null)
            {
                strSql.Append(" where " + strwhere);
            }

            lgk.Model.tb_Order model = new lgk.Model.tb_Order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderCode"] != null && ds.Tables[0].Rows[0]["OrderCode"].ToString() != "")
                {
                    model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserAddr"] != null && ds.Tables[0].Rows[0]["UserAddr"].ToString() != "")
                {
                    model.UserAddr = ds.Tables[0].Rows[0]["UserAddr"].ToString();
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
                    model.PVTotal = decimal.Parse(ds.Tables[0].Rows[0]["PVTotal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderDate"] != null && ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSend"] != null && ds.Tables[0].Rows[0]["IsSend"].ToString() != "")
                {
                    model.IsSend = int.Parse(ds.Tables[0].Rows[0]["IsSend"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayMethod"] != null && ds.Tables[0].Rows[0]["PayMethod"].ToString() != "")
                {
                    model.PayMethod = int.Parse(ds.Tables[0].Rows[0]["PayMethod"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderType"] != null && ds.Tables[0].Rows[0]["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(ds.Tables[0].Rows[0]["OrderType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Order1"] != null && ds.Tables[0].Rows[0]["Order1"].ToString() != "")
                {
                    model.Order1 = decimal.Parse(ds.Tables[0].Rows[0]["Order1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Order2"] != null && ds.Tables[0].Rows[0]["Order2"].ToString() != "")
                {
                    model.Order2 = decimal.Parse(ds.Tables[0].Rows[0]["Order2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Order3"] != null && ds.Tables[0].Rows[0]["Order3"].ToString() != "")
                {
                    model.Order3 = ds.Tables[0].Rows[0]["Order3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order4"] != null && ds.Tables[0].Rows[0]["Order4"].ToString() != "")
                {
                    model.Order4 = ds.Tables[0].Rows[0]["Order4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order5"] != null && ds.Tables[0].Rows[0]["Order5"].ToString() != "")
                {
                    model.Order5 = ds.Tables[0].Rows[0]["Order5"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order6"] != null && ds.Tables[0].Rows[0]["Order6"].ToString() != "")
                {
                    model.Order6 = ds.Tables[0].Rows[0]["Order6"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Order7"] != null && ds.Tables[0].Rows[0]["Order7"].ToString() != "")
                {
                    model.Order7 = ds.Tables[0].Rows[0]["Order7"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TypeID"] != null && ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PareTopChild"] != null && ds.Tables[0].Rows[0]["PareTopChild"].ToString() != "")
                {
                    model.PareTopChild = ds.Tables[0].Rows[0]["TypeID"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}

