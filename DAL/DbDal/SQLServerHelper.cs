using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;
using System.IO;

namespace DataAccess
{
    public class SQLServerHelper
    {
        //读取配置文件中的数据库连接
        //需添加对System.Configuration.dll文件的引用
        private static readonly string conStr = PubConstant.ConnectionString;

        //数据库连接字符串属性
        private static string connectionString
        {
            get { return conStr; }
        }

        // 数据库连接，打开
        public static SqlConnection Connection
        {
            get
            {
                var connection = new SqlConnection(connectionString);
                if (connection == null || connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                if (connection.State == ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }

        public static void AddParamInCmd(SqlCommand cmd, string paramName, SqlDbType type, int size, object value)
        {
            var parameter = new SqlParameter();
            parameter.ParameterName = paramName;
            parameter.SqlDbType = type;
            parameter.Size = size;
            parameter.Value = value;
            cmd.Parameters.Add(parameter);
        }

        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName,
                                                  IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                                                    false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName,
                                                    IDataParameter[] parameters)
        {
            var command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        public static int ExecuteNonQuery(SqlTransaction transaction, string commandText,
                                          params SqlParameter[] commandParameters)
        {
            var cmd = new SqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandText, commandParameters);
            int num = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return num;
        }

        /// <summary>
        /// 依据查询语句,获取SqlDataReader对象
        /// 参数:
        /// sqlString: 查询语句
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sqlString)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(sqlString, connection);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException exception)
            {
                connection.Close();
            }
            finally
            {
                if (reader == null)
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return reader;
        }

        /// <summary>
        /// 依据查询语句和参数数组,获取SqlDataReader对象
        /// 参数:
        /// sqlString: 查询语句
        /// cmdParms: 参数数组
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string procedurename, params SqlParameter[] cmdParms)
        {
            var conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(procedurename, conn);
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(cmdParms);
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                SQLServerHelper.RecordeError(ex.Message, "");
                conn.Close();
            }
            finally
            {
                if (reader == null)
                {
                    cmd.Dispose();
                    conn.Dispose();
                }
            }
            return reader;
        }

        /// <summary>
        /// 返回执行sql语句受影响的行数,成功:返回>0的数;失败:返回0
        /// 包括: Insert , Update , Delete , Select
        /// 参数:
        /// sqlString: sql语句
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sqlString)
        {
            int num2;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sqlString, connection))
                {
                    try
                    {
                        connection.Open();
                        num2 = command.ExecuteNonQuery();
                    }
                    catch (SqlException exception)
                    {
                        num2 = 0;
                        connection.Close();
                    }
                    finally
                    {
                        command.Dispose();
                        connection.Close();
                    }
                }
            }
            return num2;
        }


        public static int ExecuteSql(string sqlString, string content)
        {
            int result;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sqlString, connection);
                var parameter = new SqlParameter("@content", SqlDbType.NText);
                parameter.Value = content;
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    result = 0;
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 用于非存储过程，即使用SQL语句
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sqlString, params SqlParameter[] cmdParms)
        {
            int num;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(command, connection, null, sqlString, cmdParms);
                        //指定ReturnValue的值为sql语句的返回值
                        command.Parameters.Add(new SqlParameter("@ReturnValue", SqlDbType.Int));
                        command.Parameters["@ReturnValue"].Direction = ParameterDirection.ReturnValue;
                        command.ExecuteNonQuery();
                        num = Convert.ToInt32(command.Parameters["@ReturnValue"].Value);
                        command.Parameters.Clear();
                    }
                    catch (SqlException exception)
                    {
                        num = 0;
                    }
                    finally
                    {
                        command.Dispose();
                        connection.Close();
                    }
                }
            }
            return num;
        }

        /// <summary>
        /// 执行存储过程，返回受影响行数
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">IDataParameter参数</param>
        /// <returns>返回受影响行数</returns>
        public static int ExecuteSql(string storedProcName, IDataParameter[] parameters)
        {
            int num;
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = null;
                try
                {
                    connection.Open();
                    command = BuildQueryCommand(connection, storedProcName, parameters);
                    command.CommandType = CommandType.StoredProcedure;
                    //指定ReturnValue的值为存储过程的返回值
                    command.Parameters.Add(new SqlParameter("@ReturnValue", SqlDbType.Int));
                    command.Parameters["@ReturnValue"].Direction = ParameterDirection.ReturnValue;
                    command.ExecuteNonQuery();
                    num = Convert.ToInt32(command.Parameters["@ReturnValue"].Value);
                    command.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    RecordeError("ExecuteSql", ex.Message);
                    num = -1;
                    connection.Close();
                }
                finally
                {
                    command.Dispose();
                    connection.Dispose();
                }
            }
            return num;
        }

        public static void RecordeError(string fanfa,string ex)
        {
            StreamWriter writer = new StreamWriter(@"C:\erros.txt");
            writer.WriteLine(fanfa);
            writer.WriteLine(ex);
            writer.WriteLine(DateTime.Now.ToString());
            writer.WriteLine("----------");
            writer.Close();
        }

        public static int ExecuteSqlOutParameter(string sqlString, params SqlParameter[] cmdParms)
        {
            int result;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(command, connection, null, sqlString, cmdParms);
                        command.ExecuteNonQuery();
                        result = (int)command.Parameters["@RETURN_VALUE "].Value;
                    }
                    catch (SqlException exception)
                    {
                        result = 0;
                    }
                    finally
                    {
                        command.Dispose();
                        connection.Close();
                    }
                }
            }
            return result;
        }

        public static int ExecuteSqlInsertImg(string sqlString, byte[] fs)
        {
            int result;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sqlString, connection);
                var parameter = new SqlParameter("@fs", SqlDbType.Image);
                parameter.Value = fs;
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    result = 0;
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return result;
        }

        public static void ExecuteSqlTran(ArrayList sqlStringList)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand();
                command.Connection = connection;
                SqlTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    for (int i = 0; i < sqlStringList.Count; i++)
                    {
                        string str = sqlStringList[i].ToString();
                        if (str.Trim().Length > 1)
                        {
                            command.CommandText = str;
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                catch (SqlException exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
        }

        public static void ExecuteSqlTran(Hashtable sqlStringList)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    var cmd = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry entry in sqlStringList)
                        {
                            string cmdText = entry.Key.ToString();
                            var cmdParms = (SqlParameter[])entry.Value;
                            PrepareCommand(cmd, connection, transaction, cmdText, cmdParms);
                            int num = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            transaction.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static bool Exists(string sqlString)
        {
            int num;
            object single = GetSingle(sqlString);
            if (Equals(single, null) || Equals(single, DBNull.Value))
            {
                num = 0;
            }
            else
            {
                num = int.Parse(single.ToString());
            }
            if (num == 0)
            {
                return false;
            }
            return true;
        }

        public static bool Exists(string sqlString, params SqlParameter[] cmdParms)
        {
            int num;
            object single = GetSingle(sqlString, cmdParms);
            if (Equals(single, null) || Equals(single, DBNull.Value))
            {
                num = 0;
            }
            else
            {
                num = int.Parse(single.ToString());
            }
            if (num == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取数据表中最大的id
        /// </summary>
        /// <param name="fieldName">Id字段名</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static int GetMaxID(string fieldName, string tableName)
        {
            object single = GetSingle("select max(" + fieldName + ") from " + tableName);
            if (single == null)
            {
                return 1;
            }
            return int.Parse(single.ToString());
        }

        public static object GetSingle(string sqlString)
        {
            object objA = null;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sqlString, connection))
                {
                    try
                    {
                        connection.Open();
                        objA = command.ExecuteScalar();
                        if (Equals(objA, null) || Equals(objA, DBNull.Value))
                        {
                            objA = null;
                        }
                    }
                    catch (SqlException exception)
                    {
                        connection.Close();
                    }
                    finally
                    {
                        command.Dispose();
                        connection.Close();
                    }
                }
            }
            return objA;
        }

        public static object GetSingle(string sqlString, params SqlParameter[] cmdParms)
        {
            object objA = null;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(command, connection, null, sqlString, cmdParms);
                        objA = command.ExecuteScalar();
                        command.Parameters.Clear();
                        if (Equals(objA, null) || Equals(objA, DBNull.Value))
                        {
                            objA = null;
                        }
                    }
                    catch (SqlException exception)
                    {

                    }
                    finally
                    {
                        command.Dispose();
                        connection.Close();
                    }
                }
            }
            return objA;
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText,
                                           SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        /// <summary>
        /// 依据查询语句获取一个DataSet对象
        /// 参数:
        /// sqlString: 查询语句
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static DataSet Query(string sqlString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new SqlDataAdapter(sqlString, connection).Fill(dataSet, "ds");
                }
                catch (SqlException exception)
                {

                }
                finally
                {
                    connection.Close();
                }
                return dataSet;
            }
        }

        /// <summary>
        /// 依据查询语句和参数数组,获取一个DataSet对象
        /// 参数:
        /// sqlString: 查询语句
        /// cmdParms: 参数数组
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static DataSet Query(string sqlString, params SqlParameter[] cmdParms)
        {
            DataSet set2;
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    var dataSet = new DataSet();
                    try
                    {
                        adapter.Fill(dataSet, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException exception)
                    {

                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                    set2 = dataSet;
                }
            }
            return set2;
        }

        /// <summary>
        /// 运行存储过程,返回SqlDataReader对象
        /// 参数:
        /// storedProcName: 存储过程名
        /// parameters: 供存储过程使用的参数数组
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlDataReader reader2;
            SqlDataReader reader = null;
            var connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                reader2 = command.ExecuteReader(CommandBehavior.CloseConnection);
                reader = reader2;
            }
            catch (SqlException exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return reader;
        }

        /// <summary>
        /// 运行存储过程,返回DataSet对象
        /// 参数:
        /// storedProcName: 存储过程名
        /// parameters: 供存储过程使用的参数数组
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var dataSet = new DataSet();
                connection.Open();
                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                adapter.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// 依据查询语句,获取DataTable对象
        /// 参数:
        /// safeSql: 查询语句
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string safeSql)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(safeSql, Connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                connection.Close();
                connection.Dispose();
                return ds.Tables[0];
            }
        }

        /// <summary>
        /// 依据查询语句和参数数组,获取DataTable对象
        /// 参数:
        /// sql: 查询语句
        /// values: 参数数组
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] values)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.Parameters.AddRange(values);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                connection.Close();
                connection.Dispose();
                return ds.Tables[0];
            }
        }
    }
}
