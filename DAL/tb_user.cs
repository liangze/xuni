using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_user
    /// </summary>
    public partial class tb_user
    {
        /// <summary>
        /// 全局变量
        /// </summary>
        string strSunID = "";

        /// <summary>
        /// 全局变量
        /// </summary>
        string strRecommendID = "";

        public tb_user()
        { }
        #region  Method

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_user");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)};
            parameters[0].Value = UserID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="strUserCode"></param>
        /// <returns></returns>
        public bool Exists(string strUserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM tb_user");
            strSql.Append(" WHERE UserCode=@UserCode");
            SqlParameter[] parameters = {
					new SqlParameter("@UserCode", SqlDbType.VarChar,20)};
            parameters[0].Value = strUserCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region 是否有子会员
        /// <summary>
        /// 是否有子会员
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool HasChildren(long userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_user");
            strSql.Append(" where parentID=@parentID");
            SqlParameter[] parameters = {
					new SqlParameter("@parentID", SqlDbType.BigInt)};
            parameters[0].Value = userID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        /// <summary>
        /// 判断给定的用户是否为报单中心
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public bool IsAgent(long iUserID)
        {
            int iIsAgent = 0;
            bool bFlag = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [IsAgent] FROM tb_user");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                iIsAgent = 0;
            }
            else
            {
                iIsAgent = int.Parse(obj.ToString());
            }

            if (iIsAgent == 0)
                bFlag = false;
            else
                bFlag = true;

            return bFlag;
        }

        /// <summary>
        /// 根据给定的用户ID，获取用户编号。
        /// </summary>
        /// <param name="iUserID">给定的用户ID</param>
        /// <returns></returns>
        public string GetUserCode(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserCode] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 根据给定额用户编号，获取用户ID
        /// </summary>
        /// <param name="strUserCode">给定额用户编号</param>
        /// <returns></returns>
        public long GetUserID(string strUserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserID] FROM tb_user");
            strSql.Append(" WHERE UserCode=@UserCode");
            SqlParameter[] parameters = {
					new SqlParameter("@UserCode", SqlDbType.VarChar,20)};
            parameters[0].Value = strUserCode;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return long.Parse(obj.ToString());
            }
        }

        /// <summary>
        /// 获取给定会员ID的注册币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetEMoney(long iUserID)
        {
            decimal dEMoney = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [Emoney] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if (obj != null)
            {
                dEMoney = decimal.Parse(obj.ToString());
            }

            return dEMoney;
        }

        /// <summary>
        /// 判断给定的推荐人和安置人是否在同一条线上。
        /// </summary>
        /// <param name="iRecommendID">给定的推荐人</param>
        /// <param name="iParentID">给定的安置人</param>
        /// <returns></returns>
        public bool OnSameLine(long iRecommendID, long iParentID)
        {
            bool bFlag = false;

            string strRecommendUserPath = GetUserPath(iRecommendID);//推荐人路径
            string strParentUserPath = GetUserPath(iParentID);//安置人路径

            if (strParentUserPath.Contains(strRecommendUserPath) || strRecommendUserPath.Contains(strParentUserPath))
                bFlag = true;
            else
                bFlag = false;

            return bFlag;
        }

        /// <summary>
        /// 获取给定会员的路径
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public string GetUserPath(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserPath] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 获取给定会员ID的金币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetMoney(long iUserID, string strFieldName)
        {
            decimal dMoney = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [" + strFieldName + "] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if (obj != null)
            {
                dMoney = decimal.Parse(obj.ToString());
            }

            return dMoney;
        }

        /// <summary>
        /// 获取给定会员ID的金币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetBonusAccount(long iUserID)
        {
            decimal dAccount = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [BonusAccount] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if (obj != null)
            {
                dAccount = decimal.Parse(obj.ToString());
            }

            return dAccount;
        }

        /// <summary>
        /// 根据给定的条件，统计会员数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(UserID) FROM tb_user");

            if (!string.IsNullOrEmpty(strWhere))
                strSql.Append(" WHERE " + strWhere + "");

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Add(lgk.Model.tb_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user(");
            strSql.Append("UserCode,LevelID,RecommendID,RecommendCode,RecommendPath,RecommendGenera,ParentID,ParentCode,UserPath,Layer,Location,IsOpend,IsLock,IsAgent,AgentsID,Emoney,BonusAccount,AllBonusAccount,StockAccount,StockMoney,ShopAccount,RegTime,RegMoney,BillCount,GLmoney,Password,SecondPassword,ThreePassword,SafetyCodeQuestion,SafetyCodeAnswer,LeftScore,CenterScore,RightScore,LeftBalance,CenterBalance,RightBalance,LeftNewScore,CenterNewScore,RightNewScore,LeftZT,CenterZT,RightZT,BankAccount,BankAccountUser,BankName,BankBranch,BankInProvince,BankInCity,Address,TrueName,NiceName,IdenCode,PhoneNum,Gender,QQnumer,User001,User002,User003,User004,User005,User006,User007,User008,User009,User010,User011,User012,User013,User014,User015,User016,User017,User018,Email,IsOut,Batch )");
            strSql.Append(" values (");
            strSql.Append("@UserCode,@LevelID,@RecommendID,@RecommendCode,@RecommendPath,@RecommendGenera,@ParentID,@ParentCode,@UserPath,@Layer,@Location,@IsOpend,@IsLock,@IsAgent,@AgentsID,@Emoney,@BonusAccount,@AllBonusAccount,@StockAccount,@StockMoney,@ShopAccount,@RegTime,@RegMoney,@BillCount,@GLmoney,@Password,@SecondPassword,@ThreePassword,@SafetyCodeQuestion,@SafetyCodeAnswer,@LeftScore,@CenterScore,@RightScore,@LeftBalance,@CenterBalance,@RightBalance,@LeftNewScore,@CenterNewScore,@RightNewScore,@LeftZT,@CenterZT,@RightZT,@BankAccount,@BankAccountUser,@BankName,@BankBranch,@BankInProvince,@BankInCity,@Address,@TrueName,@NiceName,@IdenCode,@PhoneNum,@Gender,@QQnumer,@User001,@User002,@User003,@User004,@User005,@User006,@User007,@User008,@User009,@User010,@User011,@User012,@User013,@User014,@User015,@User016,@User017,@User018,@Email,@IsOut,@Batch )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserCode", SqlDbType.VarChar,20),
					new SqlParameter("@LevelID", SqlDbType.Int,4),
					new SqlParameter("@RecommendID", SqlDbType.BigInt,8),
					new SqlParameter("@RecommendCode", SqlDbType.VarChar,50),
					new SqlParameter("@RecommendPath", SqlDbType.Text),
					new SqlParameter("@RecommendGenera", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@ParentCode", SqlDbType.VarChar,50),
					new SqlParameter("@UserPath", SqlDbType.Text),
					new SqlParameter("@Layer", SqlDbType.Int,4),
					new SqlParameter("@Location", SqlDbType.Int,4),
					new SqlParameter("@IsOpend", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@IsAgent", SqlDbType.Int,4),
					new SqlParameter("@AgentsID", SqlDbType.BigInt,8),
					new SqlParameter("@Emoney", SqlDbType.Decimal,9),
					new SqlParameter("@BonusAccount", SqlDbType.Decimal,9),
					new SqlParameter("@AllBonusAccount", SqlDbType.Decimal,9),
					new SqlParameter("@StockAccount", SqlDbType.Decimal,9),
					new SqlParameter("@StockMoney", SqlDbType.Decimal,9),
					new SqlParameter("@ShopAccount", SqlDbType.Decimal,9),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@RegMoney", SqlDbType.Decimal,9),
					new SqlParameter("@BillCount", SqlDbType.Int,4),
                    new SqlParameter("@GLmoney", SqlDbType.Decimal,9),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@SecondPassword", SqlDbType.VarChar,50),
					new SqlParameter("@ThreePassword", SqlDbType.VarChar,50),
					new SqlParameter("@SafetyCodeQuestion", SqlDbType.VarChar,200),
					new SqlParameter("@SafetyCodeAnswer", SqlDbType.VarChar,200),
					new SqlParameter("@LeftScore", SqlDbType.Decimal,9),
					new SqlParameter("@CenterScore", SqlDbType.Decimal,9),
					new SqlParameter("@RightScore", SqlDbType.Decimal,9),
					new SqlParameter("@LeftBalance", SqlDbType.Decimal,9),
					new SqlParameter("@CenterBalance", SqlDbType.Decimal,9),
					new SqlParameter("@RightBalance", SqlDbType.Decimal,9),
					new SqlParameter("@LeftNewScore", SqlDbType.Decimal,9),
					new SqlParameter("@CenterNewScore", SqlDbType.Decimal,9),
					new SqlParameter("@RightNewScore", SqlDbType.Decimal,9),
					new SqlParameter("@LeftZT", SqlDbType.Decimal,9),
					new SqlParameter("@CenterZT", SqlDbType.Decimal,9),
					new SqlParameter("@RightZT", SqlDbType.Decimal,9),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@BankBranch", SqlDbType.VarChar,50),
					new SqlParameter("@BankInProvince", SqlDbType.VarChar,50),
					new SqlParameter("@BankInCity", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@NiceName", SqlDbType.VarChar,50),
					new SqlParameter("@IdenCode", SqlDbType.VarChar,50),
					new SqlParameter("@PhoneNum", SqlDbType.VarChar,50),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@QQnumer", SqlDbType.VarChar,50),
					new SqlParameter("@User001", SqlDbType.Int,4),
					new SqlParameter("@User002", SqlDbType.BigInt,8),
					new SqlParameter("@User003", SqlDbType.Int,4),
					new SqlParameter("@User004", SqlDbType.Int,4),
					new SqlParameter("@User005", SqlDbType.VarChar,200),
					new SqlParameter("@User006", SqlDbType.VarChar,200),
					new SqlParameter("@User007", SqlDbType.VarChar,200),
					new SqlParameter("@User008", SqlDbType.VarChar,200),
					new SqlParameter("@User009", SqlDbType.VarChar,200),
					new SqlParameter("@User010", SqlDbType.VarChar,200),
					new SqlParameter("@User011", SqlDbType.Decimal,9),
					new SqlParameter("@User012", SqlDbType.Decimal,9),
					new SqlParameter("@User013", SqlDbType.Decimal,9),
					new SqlParameter("@User014", SqlDbType.Decimal,9),
					new SqlParameter("@User015", SqlDbType.Decimal,9),
					new SqlParameter("@User016", SqlDbType.Decimal,9),
					new SqlParameter("@User017", SqlDbType.Decimal,9),
					new SqlParameter("@User018", SqlDbType.Decimal,9),
                    new SqlParameter("@Email", SqlDbType.VarChar,180),
                    new SqlParameter("@IsOut", SqlDbType.Int,4),
                    new SqlParameter("@Batch", SqlDbType.Int,4)};
            parameters[0].Value = model.UserCode;
            parameters[1].Value = model.LevelID;
            parameters[2].Value = model.RecommendID;
            parameters[3].Value = model.RecommendCode;
            parameters[4].Value = model.RecommendPath;
            parameters[5].Value = model.RecommendGenera;
            parameters[6].Value = model.ParentID;
            parameters[7].Value = model.ParentCode;
            parameters[8].Value = model.UserPath;
            parameters[9].Value = model.Layer;
            parameters[10].Value = model.Location;
            parameters[11].Value = model.IsOpend;
            parameters[12].Value = model.IsLock;
            parameters[13].Value = model.IsAgent;
            parameters[14].Value = model.AgentsID;
            parameters[15].Value = model.Emoney;
            parameters[16].Value = model.BonusAccount;
            parameters[17].Value = model.AllBonusAccount;
            parameters[18].Value = model.StockAccount;
            parameters[19].Value = model.StockMoney;
            parameters[20].Value = model.ShopAccount;
            parameters[21].Value = model.RegTime;
            parameters[22].Value = model.RegMoney;
            parameters[23].Value = model.BillCount;
            parameters[24].Value = model.GLmoney;
            parameters[25].Value = model.Password;
            parameters[26].Value = model.SecondPassword;
            parameters[27].Value = model.ThreePassword;
            parameters[28].Value = model.SafetyCodeQuestion;
            parameters[29].Value = model.SafetyCodeAnswer;
            parameters[30].Value = model.LeftScore;
            parameters[31].Value = model.CenterScore;
            parameters[32].Value = model.RightScore;
            parameters[33].Value = model.LeftBalance;
            parameters[34].Value = model.CenterBalance;
            parameters[35].Value = model.RightBalance;
            parameters[36].Value = model.LeftNewScore;
            parameters[37].Value = model.CenterNewScore;
            parameters[38].Value = model.RightNewScore;
            parameters[39].Value = model.LeftZT;
            parameters[40].Value = model.CenterZT;
            parameters[41].Value = model.RightZT;
            parameters[42].Value = model.BankAccount;
            parameters[43].Value = model.BankAccountUser;
            parameters[44].Value = model.BankName;
            parameters[45].Value = model.BankBranch;
            parameters[46].Value = model.BankInProvince;
            parameters[47].Value = model.BankInCity;
            parameters[48].Value = model.Address;
            parameters[49].Value = model.TrueName;
            parameters[50].Value = model.NiceName;
            parameters[51].Value = model.IdenCode;
            parameters[52].Value = model.PhoneNum;
            parameters[53].Value = model.Gender;
            parameters[54].Value = model.QQnumer;
            parameters[55].Value = model.User001;
            parameters[56].Value = model.User002;
            parameters[57].Value = model.User003;
            parameters[58].Value = model.User004;
            parameters[59].Value = model.User005;
            parameters[60].Value = model.User006;
            parameters[61].Value = model.User007;
            parameters[62].Value = model.User008;
            parameters[63].Value = model.User009;
            parameters[64].Value = model.User010;
            parameters[65].Value = model.User011;
            parameters[66].Value = model.User012;
            parameters[67].Value = model.User013;
            parameters[68].Value = model.User014;
            parameters[69].Value = model.User015;
            parameters[70].Value = model.User016;
            parameters[71].Value = model.User017;
            parameters[72].Value = model.User018;
            parameters[73].Value = model.Email;
            parameters[74].Value = model.IsOut;
            parameters[75].Value = model.Batch;

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
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(lgk.Model.tb_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user set ");
            strSql.Append("UserCode=@UserCode,");
            strSql.Append("LevelID=@LevelID,");
            strSql.Append("RecommendID=@RecommendID,");
            strSql.Append("RecommendCode=@RecommendCode,");
            strSql.Append("RecommendPath=@RecommendPath,");
            strSql.Append("RecommendGenera=@RecommendGenera,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("ParentCode=@ParentCode,");
            strSql.Append("UserPath=@UserPath,");
            strSql.Append("Layer=@Layer,");
            strSql.Append("Location=@Location,");
            strSql.Append("IsOpend=@IsOpend,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("IsAgent=@IsAgent,");
            strSql.Append("AgentsID=@AgentsID,");
            strSql.Append("Emoney=@Emoney,");
            strSql.Append("BonusAccount=@BonusAccount,");
            strSql.Append("AllBonusAccount=@AllBonusAccount,");
            strSql.Append("StockAccount=@StockAccount,");
            strSql.Append("StockMoney=@StockMoney,");
            strSql.Append("ShopAccount=@ShopAccount,");
            strSql.Append("RegTime=@RegTime,");
            strSql.Append("RegMoney=@RegMoney,");
            strSql.Append("BillCount=@BillCount,");
            strSql.Append("GLmoney=@GLmoney,");
            strSql.Append("Password=@Password,");
            strSql.Append("SecondPassword=@SecondPassword,");
            strSql.Append("ThreePassword=@ThreePassword,");
            strSql.Append("SafetyCodeQuestion=@SafetyCodeQuestion,");
            strSql.Append("SafetyCodeAnswer=@SafetyCodeAnswer,");
            strSql.Append("LeftScore=@LeftScore,");
            strSql.Append("CenterScore=@CenterScore,");
            strSql.Append("RightScore=@RightScore,");
            strSql.Append("LeftBalance=@LeftBalance,");
            strSql.Append("CenterBalance=@CenterBalance,");
            strSql.Append("RightBalance=@RightBalance,");
            strSql.Append("LeftNewScore=@LeftNewScore,");
            strSql.Append("CenterNewScore=@CenterNewScore,");
            strSql.Append("RightNewScore=@RightNewScore,");
            strSql.Append("LeftZT=@LeftZT,");
            strSql.Append("CenterZT=@CenterZT,");
            strSql.Append("RightZT=@RightZT,");
            strSql.Append("BankAccount=@BankAccount,");
            strSql.Append("BankAccountUser=@BankAccountUser,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankBranch=@BankBranch,");
            strSql.Append("BankInProvince=@BankInProvince,");
            strSql.Append("BankInCity=@BankInCity,");
            strSql.Append("Address=@Address,");
            strSql.Append("TrueName=@TrueName,");
            strSql.Append("NiceName=@NiceName,");
            strSql.Append("IdenCode=@IdenCode,");
            strSql.Append("PhoneNum=@PhoneNum,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("QQnumer=@QQnumer,");
            strSql.Append("User001=@User001,");
            strSql.Append("User002=@User002,");
            strSql.Append("User003=@User003,");
            strSql.Append("User004=@User004,");
            strSql.Append("User005=@User005,");
            strSql.Append("User006=@User006,");
            strSql.Append("User007=@User007,");
            strSql.Append("User008=@User008,");
            strSql.Append("User009=@User009,");
            strSql.Append("User010=@User010,");
            strSql.Append("User011=@User011,");
            strSql.Append("User012=@User012,");
            strSql.Append("User013=@User013,");
            strSql.Append("User014=@User014,");
            strSql.Append("User015=@User015,");
            strSql.Append("User016=@User016,");
            strSql.Append("User017=@User017,");
            strSql.Append("User018=@User018,");
            strSql.Append("Email=@Email,");
            strSql.Append("IsOut=@IsOut,");
            strSql.Append("Batch=@Batch");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserCode", SqlDbType.VarChar,20),
					new SqlParameter("@LevelID", SqlDbType.Int,4),
					new SqlParameter("@RecommendID", SqlDbType.BigInt,8),
					new SqlParameter("@RecommendCode", SqlDbType.VarChar,50),
					new SqlParameter("@RecommendPath", SqlDbType.Text),
					new SqlParameter("@RecommendGenera", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@ParentCode", SqlDbType.VarChar,50),
					new SqlParameter("@UserPath", SqlDbType.Text),
					new SqlParameter("@Layer", SqlDbType.Int,4),
					new SqlParameter("@Location", SqlDbType.Int,4),
					new SqlParameter("@IsOpend", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@IsAgent", SqlDbType.Int,4),
					new SqlParameter("@AgentsID", SqlDbType.BigInt,8),
					new SqlParameter("@Emoney", SqlDbType.Decimal,9),
					new SqlParameter("@BonusAccount", SqlDbType.Decimal,9),
					new SqlParameter("@AllBonusAccount", SqlDbType.Decimal,9),
					new SqlParameter("@StockAccount", SqlDbType.Decimal,9),
					new SqlParameter("@StockMoney", SqlDbType.Decimal,9),
					new SqlParameter("@ShopAccount", SqlDbType.Decimal,9),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@RegMoney", SqlDbType.Decimal,9),
					new SqlParameter("@BillCount", SqlDbType.Int,4),
                    new SqlParameter("@GLmoney", SqlDbType.Decimal,9),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@SecondPassword", SqlDbType.VarChar,50),
					new SqlParameter("@ThreePassword", SqlDbType.VarChar,50),
					new SqlParameter("@SafetyCodeQuestion", SqlDbType.VarChar,200),
					new SqlParameter("@SafetyCodeAnswer", SqlDbType.VarChar,200),
					new SqlParameter("@LeftScore", SqlDbType.Decimal,9),
					new SqlParameter("@CenterScore", SqlDbType.Decimal,9),
					new SqlParameter("@RightScore", SqlDbType.Decimal,9),
					new SqlParameter("@LeftBalance", SqlDbType.Decimal,9),
					new SqlParameter("@CenterBalance", SqlDbType.Decimal,9),
					new SqlParameter("@RightBalance", SqlDbType.Decimal,9),
					new SqlParameter("@LeftNewScore", SqlDbType.Decimal,9),
					new SqlParameter("@CenterNewScore", SqlDbType.Decimal,9),
					new SqlParameter("@RightNewScore", SqlDbType.Decimal,9),
					new SqlParameter("@LeftZT", SqlDbType.Decimal,9),
					new SqlParameter("@CenterZT", SqlDbType.Decimal,9),
					new SqlParameter("@RightZT", SqlDbType.Decimal,9),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@BankBranch", SqlDbType.VarChar,50),
					new SqlParameter("@BankInProvince", SqlDbType.VarChar,50),
					new SqlParameter("@BankInCity", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@NiceName", SqlDbType.VarChar,50),
					new SqlParameter("@IdenCode", SqlDbType.VarChar,50),
					new SqlParameter("@PhoneNum", SqlDbType.VarChar,50),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@QQnumer", SqlDbType.VarChar,50),
					new SqlParameter("@User001", SqlDbType.Int,4),
					new SqlParameter("@User002", SqlDbType.BigInt,8),
					new SqlParameter("@User003", SqlDbType.Int,4),
					new SqlParameter("@User004", SqlDbType.Int,4),
					new SqlParameter("@User005", SqlDbType.VarChar,200),
					new SqlParameter("@User006", SqlDbType.VarChar,200),
					new SqlParameter("@User007", SqlDbType.VarChar,200),
					new SqlParameter("@User008", SqlDbType.VarChar,200),
					new SqlParameter("@User009", SqlDbType.VarChar,200),
					new SqlParameter("@User010", SqlDbType.VarChar,200),
					new SqlParameter("@User011", SqlDbType.Decimal,9),
					new SqlParameter("@User012", SqlDbType.Decimal,9),
					new SqlParameter("@User013", SqlDbType.Decimal,9),
					new SqlParameter("@User014", SqlDbType.Decimal,9),
					new SqlParameter("@User015", SqlDbType.Decimal,9),
					new SqlParameter("@User016", SqlDbType.Decimal,9),
					new SqlParameter("@User017", SqlDbType.Decimal,9),
					new SqlParameter("@User018", SqlDbType.Decimal,9),
                    new SqlParameter("@Email", SqlDbType.VarChar,200),
                    new SqlParameter("@IsOut", SqlDbType.Int,4),
                    new SqlParameter("@Batch", SqlDbType.Int,4),
                    new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserCode;
            parameters[1].Value = model.LevelID;
            parameters[2].Value = model.RecommendID;
            parameters[3].Value = model.RecommendCode;
            parameters[4].Value = model.RecommendPath;
            parameters[5].Value = model.RecommendGenera;
            parameters[6].Value = model.ParentID;
            parameters[7].Value = model.ParentCode;
            parameters[8].Value = model.UserPath;
            parameters[9].Value = model.Layer;
            parameters[10].Value = model.Location;
            parameters[11].Value = model.IsOpend;
            parameters[12].Value = model.IsLock;
            parameters[13].Value = model.IsAgent;
            parameters[14].Value = model.AgentsID;
            parameters[15].Value = model.Emoney;
            parameters[16].Value = model.BonusAccount;
            parameters[17].Value = model.AllBonusAccount;
            parameters[18].Value = model.StockAccount;
            parameters[19].Value = model.StockMoney;
            parameters[20].Value = model.ShopAccount;
            parameters[21].Value = model.RegTime;
            parameters[22].Value = model.RegMoney;
            parameters[23].Value = model.BillCount;
            parameters[24].Value = model.GLmoney;
            parameters[25].Value = model.Password;
            parameters[26].Value = model.SecondPassword;
            parameters[27].Value = model.ThreePassword;
            parameters[28].Value = model.SafetyCodeQuestion;
            parameters[29].Value = model.SafetyCodeAnswer;
            parameters[30].Value = model.LeftScore;
            parameters[31].Value = model.CenterScore;
            parameters[32].Value = model.RightScore;
            parameters[33].Value = model.LeftBalance;
            parameters[34].Value = model.CenterBalance;
            parameters[35].Value = model.RightBalance;
            parameters[36].Value = model.LeftNewScore;
            parameters[37].Value = model.CenterNewScore;
            parameters[38].Value = model.RightNewScore;
            parameters[39].Value = model.LeftZT;
            parameters[40].Value = model.CenterZT;
            parameters[41].Value = model.RightZT;
            parameters[42].Value = model.BankAccount;
            parameters[43].Value = model.BankAccountUser;
            parameters[44].Value = model.BankName;
            parameters[45].Value = model.BankBranch;
            parameters[46].Value = model.BankInProvince;
            parameters[47].Value = model.BankInCity;
            parameters[48].Value = model.Address;
            parameters[49].Value = model.TrueName;
            parameters[50].Value = model.NiceName;
            parameters[51].Value = model.IdenCode;
            parameters[52].Value = model.PhoneNum;
            parameters[53].Value = model.Gender;
            parameters[54].Value = model.QQnumer;
            parameters[55].Value = model.User001;
            parameters[56].Value = model.User002;
            parameters[57].Value = model.User003;
            parameters[58].Value = model.User004;
            parameters[59].Value = model.User005;
            parameters[60].Value = model.User006;
            parameters[61].Value = model.User007;
            parameters[62].Value = model.User008;
            parameters[63].Value = model.User009;
            parameters[64].Value = model.User010;
            parameters[65].Value = model.User011;
            parameters[66].Value = model.User012;
            parameters[67].Value = model.User013;
            parameters[68].Value = model.User014;
            parameters[69].Value = model.User015;
            parameters[70].Value = model.User016;
            parameters[71].Value = model.User017;
            parameters[72].Value = model.User018;
            parameters[73].Value = model.Email;
            parameters[74].Value = model.IsOut;
            parameters[75].Value = model.Batch;
            parameters[76].Value = model.UserID;

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
        #endregion

        /// <summary>
        /// 更新给定账号ID的复投次数(iTypeID:0减少，1增加)
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="iTypeID"></param>
        /// <returns></returns>
        public bool UpdateBatch(long iUserID, int iTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_user SET");
            strSql.Append(" IsOut = 0,");
            if (iTypeID == 0)
                strSql.Append(" Batch -= 1");
            else
                strSql.Append(" Batch += 1");
            strSql.Append(" WHERE UserID=" + iUserID + "");

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
        /// 开通空单
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public bool UpdateEmpty(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_user SET IsOpend = 3");
            strSql.Append(" WHERE UserID=" + iUserID + "");

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
        /// 将给定的用户ID更新成报单中心
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
        public bool UpdateAgent(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user set ");
            strSql.Append("IsAgent=@IsAgent");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@IsAgent", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = 1;
            parameters[1].Value = iUserID;

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
        /// 修改下线的报单中心信息
        /// </summary>
        public bool UpdateAgent(long iAgentsID, long iUserID, string strUserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user set ");
            strSql.Append("AgentsID=@AgentsID,");
            strSql.Append("User006=@User006");
            strSql.Append(" where RecommendID=@RecommendID");
            SqlParameter[] parameters = {
					new SqlParameter("@AgentsID", SqlDbType.Int,4),
					new SqlParameter("@User006", SqlDbType.VarChar,200),
					new SqlParameter("@RecommendID", SqlDbType.BigInt,8)};
            parameters[0].Value = iAgentsID;
            parameters[1].Value = strUserCode;
            parameters[2].Value = iUserID;

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

        #region 获取推荐人节点
        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员。
        /// </summary>
        /// <param name="iUserID">根据给定的会员编号</param>
        /// <returns></returns>
        public string GetAllRecommendID(long iUserID)
        {
            strRecommendID = "";//全局变量，上面有定义

            strRecommendID = GetRecommend(iUserID);

            strRecommendID = strRecommendID.Substring(0, strRecommendID.Length - 1);

            return strRecommendID;
        }

        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员ID。
        /// </summary>
        /// <param name="iUserID">给定的会员编号</param>
        /// <returns></returns>
        public string GetRecommend(long iRecommendID)
        {
            string strChildeeID = "", strRecomID = "";

            strChildeeID = GetRecommendID(iRecommendID);
            strRecommendID += strChildeeID + ",";

            string[] strChildID = strChildeeID.Split(',');

            int iLength = strChildID.Length;

            for (int i = 0; i < iLength; i++)
            {
                if (strChildID[i] != "")
                {
                    long m = Convert.ToInt64(strChildID[i]);
                    strRecomID = GetRecommendID(m);
                    if (strRecomID != "")
                    {
                        GetRecommend(m);
                    }
                }
            }
            return strRecommendID;
        }

        /// <summary>
        /// 获取下级推荐编号
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public string GetRecommendID(long iRecommendID)
        {
            int iCount = 0;
            string strRecommendID = "";

            SortedList<string, lgk.Model.tb_user> myUser = new SortedList<string, lgk.Model.tb_user>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT [UserID] FROM [tb_user]");
            strSql.Append(" WHERE RecommendID=@RecommendID");
            SqlParameter[] parameters = {
                        new SqlParameter("@RecommendID", SqlDbType.BigInt,8)};
            parameters[0].Value = iRecommendID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lgk.Model.tb_user model = new lgk.Model.tb_user();

                    if (ds.Tables[0].Rows[i]["UserID"] != null && ds.Tables[0].Rows[i]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(ds.Tables[0].Rows[i]["UserID"].ToString());
                        myUser.Add(Convert.ToString(iCount), model);
                        iCount++;
                    }
                }
            }

            iCount = myUser.Count;

            if (iCount > 0)
            {
                for (int i = 0; i < iCount; i++)
                {
                    if (i == iCount - 1)
                    {
                        strRecommendID += myUser.Values[i].UserID;
                    }
                    else
                    {
                        strRecommendID += myUser.Values[i].UserID + ",";
                    }
                }
            }
            else
            {
                strRecommendID = "";
            }

            return strRecommendID;
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = UserID;

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
        #endregion

        #region 删除多条数据
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM tb_user ");
            strSql.Append(" WHERE UserID IN (" + UserIDlist + ")  ");
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
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModel(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = UserID;

            lgk.Model.tb_user model = new lgk.Model.tb_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserCode"] != null && ds.Tables[0].Rows[0]["UserCode"].ToString() != "")
                {
                    model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LevelID"] != null && ds.Tables[0].Rows[0]["LevelID"].ToString() != "")
                {
                    model.LevelID = int.Parse(ds.Tables[0].Rows[0]["LevelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecommendID"] != null && ds.Tables[0].Rows[0]["RecommendID"].ToString() != "")
                {
                    model.RecommendID = long.Parse(ds.Tables[0].Rows[0]["RecommendID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecommendCode"] != null && ds.Tables[0].Rows[0]["RecommendCode"].ToString() != "")
                {
                    model.RecommendCode = ds.Tables[0].Rows[0]["RecommendCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RecommendPath"] != null && ds.Tables[0].Rows[0]["RecommendPath"].ToString() != "")
                {
                    model.RecommendPath = ds.Tables[0].Rows[0]["RecommendPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RecommendGenera"] != null && ds.Tables[0].Rows[0]["RecommendGenera"].ToString() != "")
                {
                    model.RecommendGenera = int.Parse(ds.Tables[0].Rows[0]["RecommendGenera"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentCode"] != null && ds.Tables[0].Rows[0]["ParentCode"].ToString() != "")
                {
                    model.ParentCode = ds.Tables[0].Rows[0]["ParentCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserPath"] != null && ds.Tables[0].Rows[0]["UserPath"].ToString() != "")
                {
                    model.UserPath = ds.Tables[0].Rows[0]["UserPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Layer"] != null && ds.Tables[0].Rows[0]["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(ds.Tables[0].Rows[0]["Layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Location"] != null && ds.Tables[0].Rows[0]["Location"].ToString() != "")
                {
                    model.Location = int.Parse(ds.Tables[0].Rows[0]["Location"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOpend"] != null && ds.Tables[0].Rows[0]["IsOpend"].ToString() != "")
                {
                    model.IsOpend = int.Parse(ds.Tables[0].Rows[0]["IsOpend"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"] != null && ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsAgent"] != null && ds.Tables[0].Rows[0]["IsAgent"].ToString() != "")
                {
                    model.IsAgent = int.Parse(ds.Tables[0].Rows[0]["IsAgent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AgentsID"] != null && ds.Tables[0].Rows[0]["AgentsID"].ToString() != "")
                {
                    model.AgentsID = long.Parse(ds.Tables[0].Rows[0]["AgentsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Emoney"] != null && ds.Tables[0].Rows[0]["Emoney"].ToString() != "")
                {
                    model.Emoney = decimal.Parse(ds.Tables[0].Rows[0]["Emoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BonusAccount"] != null && ds.Tables[0].Rows[0]["BonusAccount"].ToString() != "")
                {
                    model.BonusAccount = decimal.Parse(ds.Tables[0].Rows[0]["BonusAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllBonusAccount"] != null && ds.Tables[0].Rows[0]["AllBonusAccount"].ToString() != "")
                {
                    model.AllBonusAccount = decimal.Parse(ds.Tables[0].Rows[0]["AllBonusAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockAccount"] != null && ds.Tables[0].Rows[0]["StockAccount"].ToString() != "")
                {
                    model.StockAccount = decimal.Parse(ds.Tables[0].Rows[0]["StockAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockMoney"] != null && ds.Tables[0].Rows[0]["StockMoney"].ToString() != "")
                {
                    model.StockMoney = decimal.Parse(ds.Tables[0].Rows[0]["StockMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShopAccount"] != null && ds.Tables[0].Rows[0]["ShopAccount"].ToString() != "")
                {
                    model.ShopAccount = decimal.Parse(ds.Tables[0].Rows[0]["ShopAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegTime"] != null && ds.Tables[0].Rows[0]["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(ds.Tables[0].Rows[0]["RegTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OpenTime"] != null && ds.Tables[0].Rows[0]["OpenTime"].ToString() != "")
                {
                    model.OpenTime = DateTime.Parse(ds.Tables[0].Rows[0]["OpenTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegMoney"] != null && ds.Tables[0].Rows[0]["RegMoney"].ToString() != "")
                {
                    model.RegMoney = decimal.Parse(ds.Tables[0].Rows[0]["RegMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BillCount"] != null && ds.Tables[0].Rows[0]["BillCount"].ToString() != "")
                {
                    model.BillCount = int.Parse(ds.Tables[0].Rows[0]["BillCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GLmoney"] != null && ds.Tables[0].Rows[0]["GLmoney"].ToString() != "")
                {
                    model.GLmoney = decimal.Parse(ds.Tables[0].Rows[0]["GLmoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddGLTime"] != null && ds.Tables[0].Rows[0]["AddGLTime"].ToString() != "")
                {
                    model.AddGLTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddGLTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SecondPassword"] != null && ds.Tables[0].Rows[0]["SecondPassword"].ToString() != "")
                {
                    model.SecondPassword = ds.Tables[0].Rows[0]["SecondPassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ThreePassword"] != null && ds.Tables[0].Rows[0]["ThreePassword"].ToString() != "")
                {
                    model.ThreePassword = ds.Tables[0].Rows[0]["ThreePassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SafetyCodeQuestion"] != null && ds.Tables[0].Rows[0]["SafetyCodeQuestion"].ToString() != "")
                {
                    model.SafetyCodeQuestion = ds.Tables[0].Rows[0]["SafetyCodeQuestion"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SafetyCodeAnswer"] != null && ds.Tables[0].Rows[0]["SafetyCodeAnswer"].ToString() != "")
                {
                    model.SafetyCodeAnswer = ds.Tables[0].Rows[0]["SafetyCodeAnswer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LeftScore"] != null && ds.Tables[0].Rows[0]["LeftScore"].ToString() != "")
                {
                    model.LeftScore = decimal.Parse(ds.Tables[0].Rows[0]["LeftScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterScore"] != null && ds.Tables[0].Rows[0]["CenterScore"].ToString() != "")
                {
                    model.CenterScore = decimal.Parse(ds.Tables[0].Rows[0]["CenterScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightScore"] != null && ds.Tables[0].Rows[0]["RightScore"].ToString() != "")
                {
                    model.RightScore = decimal.Parse(ds.Tables[0].Rows[0]["RightScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LeftBalance"] != null && ds.Tables[0].Rows[0]["LeftBalance"].ToString() != "")
                {
                    model.LeftBalance = decimal.Parse(ds.Tables[0].Rows[0]["LeftBalance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterBalance"] != null && ds.Tables[0].Rows[0]["CenterBalance"].ToString() != "")
                {
                    model.CenterBalance = decimal.Parse(ds.Tables[0].Rows[0]["CenterBalance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightBalance"] != null && ds.Tables[0].Rows[0]["RightBalance"].ToString() != "")
                {
                    model.RightBalance = decimal.Parse(ds.Tables[0].Rows[0]["RightBalance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LeftNewScore"] != null && ds.Tables[0].Rows[0]["LeftNewScore"].ToString() != "")
                {
                    model.LeftNewScore = decimal.Parse(ds.Tables[0].Rows[0]["LeftNewScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterNewScore"] != null && ds.Tables[0].Rows[0]["CenterNewScore"].ToString() != "")
                {
                    model.CenterNewScore = decimal.Parse(ds.Tables[0].Rows[0]["CenterNewScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightNewScore"] != null && ds.Tables[0].Rows[0]["RightNewScore"].ToString() != "")
                {
                    model.RightNewScore = decimal.Parse(ds.Tables[0].Rows[0]["RightNewScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LeftZT"] != null && ds.Tables[0].Rows[0]["LeftZT"].ToString() != "")
                {
                    model.LeftZT = decimal.Parse(ds.Tables[0].Rows[0]["LeftZT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterZT"] != null && ds.Tables[0].Rows[0]["CenterZT"].ToString() != "")
                {
                    model.CenterZT = decimal.Parse(ds.Tables[0].Rows[0]["CenterZT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightZT"] != null && ds.Tables[0].Rows[0]["RightZT"].ToString() != "")
                {
                    model.RightZT = decimal.Parse(ds.Tables[0].Rows[0]["RightZT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankAccount"] != null && ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccountUser"] != null && ds.Tables[0].Rows[0]["BankAccountUser"].ToString() != "")
                {
                    model.BankAccountUser = ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankName"] != null && ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankBranch"] != null && ds.Tables[0].Rows[0]["BankBranch"].ToString() != "")
                {
                    model.BankBranch = ds.Tables[0].Rows[0]["BankBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankInProvince"] != null && ds.Tables[0].Rows[0]["BankInProvince"].ToString() != "")
                {
                    model.BankInProvince = ds.Tables[0].Rows[0]["BankInProvince"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankInCity"] != null && ds.Tables[0].Rows[0]["BankInCity"].ToString() != "")
                {
                    model.BankInCity = ds.Tables[0].Rows[0]["BankInCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TrueName"] != null && ds.Tables[0].Rows[0]["TrueName"].ToString() != "")
                {
                    model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NiceName"] != null && ds.Tables[0].Rows[0]["NiceName"].ToString() != "")
                {
                    model.NiceName = ds.Tables[0].Rows[0]["NiceName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IdenCode"] != null && ds.Tables[0].Rows[0]["IdenCode"].ToString() != "")
                {
                    model.IdenCode = ds.Tables[0].Rows[0]["IdenCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PhoneNum"] != null && ds.Tables[0].Rows[0]["PhoneNum"].ToString() != "")
                {
                    model.PhoneNum = ds.Tables[0].Rows[0]["PhoneNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Gender"] != null && ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(ds.Tables[0].Rows[0]["Gender"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QQnumer"] != null && ds.Tables[0].Rows[0]["QQnumer"].ToString() != "")
                {
                    model.QQnumer = ds.Tables[0].Rows[0]["QQnumer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User001"] != null && ds.Tables[0].Rows[0]["User001"].ToString() != "")
                {
                    model.User001 = int.Parse(ds.Tables[0].Rows[0]["User001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User002"] != null && ds.Tables[0].Rows[0]["User002"].ToString() != "")
                {
                    model.User002 = long.Parse(ds.Tables[0].Rows[0]["User002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User003"] != null && ds.Tables[0].Rows[0]["User003"].ToString() != "")
                {
                    model.User003 = int.Parse(ds.Tables[0].Rows[0]["User003"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User004"] != null && ds.Tables[0].Rows[0]["User004"].ToString() != "")
                {
                    model.User004 = int.Parse(ds.Tables[0].Rows[0]["User004"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User005"] != null && ds.Tables[0].Rows[0]["User005"].ToString() != "")
                {
                    model.User005 = ds.Tables[0].Rows[0]["User005"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User006"] != null && ds.Tables[0].Rows[0]["User006"].ToString() != "")
                {
                    model.User006 = ds.Tables[0].Rows[0]["User006"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User007"] != null && ds.Tables[0].Rows[0]["User007"].ToString() != "")
                {
                    model.User007 = ds.Tables[0].Rows[0]["User007"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User008"] != null && ds.Tables[0].Rows[0]["User008"].ToString() != "")
                {
                    model.User008 = ds.Tables[0].Rows[0]["User008"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User009"] != null && ds.Tables[0].Rows[0]["User009"].ToString() != "")
                {
                    model.User009 = ds.Tables[0].Rows[0]["User009"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User010"] != null && ds.Tables[0].Rows[0]["User010"].ToString() != "")
                {
                    model.User010 = ds.Tables[0].Rows[0]["User010"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User011"] != null && ds.Tables[0].Rows[0]["User011"].ToString() != "")
                {
                    model.User011 = decimal.Parse(ds.Tables[0].Rows[0]["User011"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User012"] != null && ds.Tables[0].Rows[0]["User012"].ToString() != "")
                {
                    model.User012 = decimal.Parse(ds.Tables[0].Rows[0]["User012"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User013"] != null && ds.Tables[0].Rows[0]["User013"].ToString() != "")
                {
                    model.User013 = decimal.Parse(ds.Tables[0].Rows[0]["User013"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User014"] != null && ds.Tables[0].Rows[0]["User014"].ToString() != "")
                {
                    model.User014 = decimal.Parse(ds.Tables[0].Rows[0]["User014"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User015"] != null && ds.Tables[0].Rows[0]["User015"].ToString() != "")
                {
                    model.User015 = decimal.Parse(ds.Tables[0].Rows[0]["User015"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User016"] != null && ds.Tables[0].Rows[0]["User016"].ToString() != "")
                {
                    model.User016 = decimal.Parse(ds.Tables[0].Rows[0]["User016"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User017"] != null && ds.Tables[0].Rows[0]["User017"].ToString() != "")
                {
                    model.User017 = decimal.Parse(ds.Tables[0].Rows[0]["User017"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User018"] != null && ds.Tables[0].Rows[0]["User018"].ToString() != "")
                {
                    model.User018 = decimal.Parse(ds.Tables[0].Rows[0]["User018"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsOut"].ToString() != "")
                {
                    model.IsOut = int.Parse(ds.Tables[0].Rows[0]["IsOut"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Batch"].ToString() != "")
                {
                    model.Batch = int.Parse(ds.Tables[0].Rows[0]["Batch"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 得到一个对象实体（用于商城用户注册）
        /// <summary>
        /// 得到一个对象实体（用于商城用户注册）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModelForShop(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM tb_user");
            strSql.Append(" WHERE " + strWhere);
            lgk.Model.tb_user model = new lgk.Model.tb_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserCode"] != null && ds.Tables[0].Rows[0]["UserCode"].ToString() != "")
                {
                    model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LevelID"] != null && ds.Tables[0].Rows[0]["LevelID"].ToString() != "")
                {
                    model.LevelID = int.Parse(ds.Tables[0].Rows[0]["LevelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecommendID"] != null && ds.Tables[0].Rows[0]["RecommendID"].ToString() != "")
                {
                    model.RecommendID = long.Parse(ds.Tables[0].Rows[0]["RecommendID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecommendCode"] != null && ds.Tables[0].Rows[0]["RecommendCode"].ToString() != "")
                {
                    model.RecommendCode = ds.Tables[0].Rows[0]["RecommendCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RecommendPath"] != null && ds.Tables[0].Rows[0]["RecommendPath"].ToString() != "")
                {
                    model.RecommendPath = ds.Tables[0].Rows[0]["RecommendPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RecommendGenera"] != null && ds.Tables[0].Rows[0]["RecommendGenera"].ToString() != "")
                {
                    model.RecommendGenera = int.Parse(ds.Tables[0].Rows[0]["RecommendGenera"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentCode"] != null && ds.Tables[0].Rows[0]["ParentCode"].ToString() != "")
                {
                    model.ParentCode = ds.Tables[0].Rows[0]["ParentCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserPath"] != null && ds.Tables[0].Rows[0]["UserPath"].ToString() != "")
                {
                    model.UserPath = ds.Tables[0].Rows[0]["UserPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Layer"] != null && ds.Tables[0].Rows[0]["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(ds.Tables[0].Rows[0]["Layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Location"] != null && ds.Tables[0].Rows[0]["Location"].ToString() != "")
                {
                    model.Location = int.Parse(ds.Tables[0].Rows[0]["Location"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOpend"] != null && ds.Tables[0].Rows[0]["IsOpend"].ToString() != "")
                {
                    model.IsOpend = int.Parse(ds.Tables[0].Rows[0]["IsOpend"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"] != null && ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsAgent"] != null && ds.Tables[0].Rows[0]["IsAgent"].ToString() != "")
                {
                    model.IsAgent = int.Parse(ds.Tables[0].Rows[0]["IsAgent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AgentsID"] != null && ds.Tables[0].Rows[0]["AgentsID"].ToString() != "")
                {
                    model.AgentsID = int.Parse(ds.Tables[0].Rows[0]["AgentsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Emoney"] != null && ds.Tables[0].Rows[0]["Emoney"].ToString() != "")
                {
                    model.Emoney = decimal.Parse(ds.Tables[0].Rows[0]["Emoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BonusAccount"] != null && ds.Tables[0].Rows[0]["BonusAccount"].ToString() != "")
                {
                    model.BonusAccount = decimal.Parse(ds.Tables[0].Rows[0]["BonusAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllBonusAccount"] != null && ds.Tables[0].Rows[0]["AllBonusAccount"].ToString() != "")
                {
                    model.AllBonusAccount = decimal.Parse(ds.Tables[0].Rows[0]["AllBonusAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockAccount"] != null && ds.Tables[0].Rows[0]["StockAccount"].ToString() != "")
                {
                    model.StockAccount = decimal.Parse(ds.Tables[0].Rows[0]["StockAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockMoney"] != null && ds.Tables[0].Rows[0]["StockMoney"].ToString() != "")
                {
                    model.StockMoney = decimal.Parse(ds.Tables[0].Rows[0]["StockMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShopAccount"] != null && ds.Tables[0].Rows[0]["ShopAccount"].ToString() != "")
                {
                    model.ShopAccount = decimal.Parse(ds.Tables[0].Rows[0]["ShopAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegTime"] != null && ds.Tables[0].Rows[0]["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(ds.Tables[0].Rows[0]["RegTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OpenTime"] != null && ds.Tables[0].Rows[0]["OpenTime"].ToString() != "")
                {
                    model.OpenTime = DateTime.Parse(ds.Tables[0].Rows[0]["OpenTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegMoney"] != null && ds.Tables[0].Rows[0]["RegMoney"].ToString() != "")
                {
                    model.RegMoney = decimal.Parse(ds.Tables[0].Rows[0]["RegMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BillCount"] != null && ds.Tables[0].Rows[0]["BillCount"].ToString() != "")
                {
                    model.BillCount = int.Parse(ds.Tables[0].Rows[0]["BillCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GLmoney"] != null && ds.Tables[0].Rows[0]["GLmoney"].ToString() != "")
                {
                    model.GLmoney = decimal.Parse(ds.Tables[0].Rows[0]["GLmoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddGLTime"] != null && ds.Tables[0].Rows[0]["AddGLTime"].ToString() != "")
                {
                    model.AddGLTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddGLTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SecondPassword"] != null && ds.Tables[0].Rows[0]["SecondPassword"].ToString() != "")
                {
                    model.SecondPassword = ds.Tables[0].Rows[0]["SecondPassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ThreePassword"] != null && ds.Tables[0].Rows[0]["ThreePassword"].ToString() != "")
                {
                    model.ThreePassword = ds.Tables[0].Rows[0]["ThreePassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SafetyCodeQuestion"] != null && ds.Tables[0].Rows[0]["SafetyCodeQuestion"].ToString() != "")
                {
                    model.SafetyCodeQuestion = ds.Tables[0].Rows[0]["SafetyCodeQuestion"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SafetyCodeAnswer"] != null && ds.Tables[0].Rows[0]["SafetyCodeAnswer"].ToString() != "")
                {
                    model.SafetyCodeAnswer = ds.Tables[0].Rows[0]["SafetyCodeAnswer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LeftScore"] != null && ds.Tables[0].Rows[0]["LeftScore"].ToString() != "")
                {
                    model.LeftScore = decimal.Parse(ds.Tables[0].Rows[0]["LeftScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterScore"] != null && ds.Tables[0].Rows[0]["CenterScore"].ToString() != "")
                {
                    model.CenterScore = decimal.Parse(ds.Tables[0].Rows[0]["CenterScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightScore"] != null && ds.Tables[0].Rows[0]["RightScore"].ToString() != "")
                {
                    model.RightScore = decimal.Parse(ds.Tables[0].Rows[0]["RightScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LeftBalance"] != null && ds.Tables[0].Rows[0]["LeftBalance"].ToString() != "")
                {
                    model.LeftBalance = decimal.Parse(ds.Tables[0].Rows[0]["LeftBalance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterBalance"] != null && ds.Tables[0].Rows[0]["CenterBalance"].ToString() != "")
                {
                    model.CenterBalance = decimal.Parse(ds.Tables[0].Rows[0]["CenterBalance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightBalance"] != null && ds.Tables[0].Rows[0]["RightBalance"].ToString() != "")
                {
                    model.RightBalance = decimal.Parse(ds.Tables[0].Rows[0]["RightBalance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LeftNewScore"] != null && ds.Tables[0].Rows[0]["LeftNewScore"].ToString() != "")
                {
                    model.LeftNewScore = decimal.Parse(ds.Tables[0].Rows[0]["LeftNewScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterNewScore"] != null && ds.Tables[0].Rows[0]["CenterNewScore"].ToString() != "")
                {
                    model.CenterNewScore = decimal.Parse(ds.Tables[0].Rows[0]["CenterNewScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightNewScore"] != null && ds.Tables[0].Rows[0]["RightNewScore"].ToString() != "")
                {
                    model.RightNewScore = decimal.Parse(ds.Tables[0].Rows[0]["RightNewScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LeftZT"] != null && ds.Tables[0].Rows[0]["LeftZT"].ToString() != "")
                {
                    model.LeftZT = decimal.Parse(ds.Tables[0].Rows[0]["LeftZT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterZT"] != null && ds.Tables[0].Rows[0]["CenterZT"].ToString() != "")
                {
                    model.CenterZT = decimal.Parse(ds.Tables[0].Rows[0]["CenterZT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightZT"] != null && ds.Tables[0].Rows[0]["RightZT"].ToString() != "")
                {
                    model.RightZT = decimal.Parse(ds.Tables[0].Rows[0]["RightZT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankAccount"] != null && ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccountUser"] != null && ds.Tables[0].Rows[0]["BankAccountUser"].ToString() != "")
                {
                    model.BankAccountUser = ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankName"] != null && ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankBranch"] != null && ds.Tables[0].Rows[0]["BankBranch"].ToString() != "")
                {
                    model.BankBranch = ds.Tables[0].Rows[0]["BankBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankInProvince"] != null && ds.Tables[0].Rows[0]["BankInProvince"].ToString() != "")
                {
                    model.BankInProvince = ds.Tables[0].Rows[0]["BankInProvince"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankInCity"] != null && ds.Tables[0].Rows[0]["BankInCity"].ToString() != "")
                {
                    model.BankInCity = ds.Tables[0].Rows[0]["BankInCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TrueName"] != null && ds.Tables[0].Rows[0]["TrueName"].ToString() != "")
                {
                    model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NiceName"] != null && ds.Tables[0].Rows[0]["NiceName"].ToString() != "")
                {
                    model.NiceName = ds.Tables[0].Rows[0]["NiceName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IdenCode"] != null && ds.Tables[0].Rows[0]["IdenCode"].ToString() != "")
                {
                    model.IdenCode = ds.Tables[0].Rows[0]["IdenCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PhoneNum"] != null && ds.Tables[0].Rows[0]["PhoneNum"].ToString() != "")
                {
                    model.PhoneNum = ds.Tables[0].Rows[0]["PhoneNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Gender"] != null && ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(ds.Tables[0].Rows[0]["Gender"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QQnumer"] != null && ds.Tables[0].Rows[0]["QQnumer"].ToString() != "")
                {
                    model.QQnumer = ds.Tables[0].Rows[0]["QQnumer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User001"] != null && ds.Tables[0].Rows[0]["User001"].ToString() != "")
                {
                    model.User001 = int.Parse(ds.Tables[0].Rows[0]["User001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User002"] != null && ds.Tables[0].Rows[0]["User002"].ToString() != "")
                {
                    model.User002 = long.Parse(ds.Tables[0].Rows[0]["User002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User003"] != null && ds.Tables[0].Rows[0]["User003"].ToString() != "")
                {
                    model.User003 = int.Parse(ds.Tables[0].Rows[0]["User003"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User004"] != null && ds.Tables[0].Rows[0]["User004"].ToString() != "")
                {
                    model.User004 = int.Parse(ds.Tables[0].Rows[0]["User004"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User005"] != null && ds.Tables[0].Rows[0]["User005"].ToString() != "")
                {
                    model.User005 = ds.Tables[0].Rows[0]["User005"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User006"] != null && ds.Tables[0].Rows[0]["User006"].ToString() != "")
                {
                    model.User006 = ds.Tables[0].Rows[0]["User006"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User007"] != null && ds.Tables[0].Rows[0]["User007"].ToString() != "")
                {
                    model.User007 = ds.Tables[0].Rows[0]["User007"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User008"] != null && ds.Tables[0].Rows[0]["User008"].ToString() != "")
                {
                    model.User008 = ds.Tables[0].Rows[0]["User008"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User009"] != null && ds.Tables[0].Rows[0]["User009"].ToString() != "")
                {
                    model.User009 = ds.Tables[0].Rows[0]["User009"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User010"] != null && ds.Tables[0].Rows[0]["User010"].ToString() != "")
                {
                    model.User010 = ds.Tables[0].Rows[0]["User010"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User011"] != null && ds.Tables[0].Rows[0]["User011"].ToString() != "")
                {
                    model.User011 = decimal.Parse(ds.Tables[0].Rows[0]["User011"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User012"] != null && ds.Tables[0].Rows[0]["User012"].ToString() != "")
                {
                    model.User012 = decimal.Parse(ds.Tables[0].Rows[0]["User012"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User013"] != null && ds.Tables[0].Rows[0]["User013"].ToString() != "")
                {
                    model.User013 = decimal.Parse(ds.Tables[0].Rows[0]["User013"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User014"] != null && ds.Tables[0].Rows[0]["User014"].ToString() != "")
                {
                    model.User014 = decimal.Parse(ds.Tables[0].Rows[0]["User014"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User015"] != null && ds.Tables[0].Rows[0]["User015"].ToString() != "")
                {
                    model.User015 = decimal.Parse(ds.Tables[0].Rows[0]["User015"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User016"] != null && ds.Tables[0].Rows[0]["User016"].ToString() != "")
                {
                    model.User016 = decimal.Parse(ds.Tables[0].Rows[0]["User016"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User017"] != null && ds.Tables[0].Rows[0]["User017"].ToString() != "")
                {
                    model.User017 = decimal.Parse(ds.Tables[0].Rows[0]["User017"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User018"] != null && ds.Tables[0].Rows[0]["User018"].ToString() != "")
                {
                    model.User018 = decimal.Parse(ds.Tables[0].Rows[0]["User018"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsOut"].ToString() != "")
                {
                    model.IsOut = int.Parse(ds.Tables[0].Rows[0]["IsOut"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Batch"].ToString() != "")
                {
                    model.Batch = int.Parse(ds.Tables[0].Rows[0]["Batch"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM tb_user");
            strSql.Append(" WHERE " + strWhere);
            lgk.Model.tb_user model = new lgk.Model.tb_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserCode"] != null && ds.Tables[0].Rows[0]["UserCode"].ToString() != "")
                {
                    model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LevelID"] != null && ds.Tables[0].Rows[0]["LevelID"].ToString() != "")
                {
                    model.LevelID = int.Parse(ds.Tables[0].Rows[0]["LevelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecommendID"] != null && ds.Tables[0].Rows[0]["RecommendID"].ToString() != "")
                {
                    model.RecommendID = long.Parse(ds.Tables[0].Rows[0]["RecommendID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecommendCode"] != null && ds.Tables[0].Rows[0]["RecommendCode"].ToString() != "")
                {
                    model.RecommendCode = ds.Tables[0].Rows[0]["RecommendCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RecommendPath"] != null && ds.Tables[0].Rows[0]["RecommendPath"].ToString() != "")
                {
                    model.RecommendPath = ds.Tables[0].Rows[0]["RecommendPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RecommendGenera"] != null && ds.Tables[0].Rows[0]["RecommendGenera"].ToString() != "")
                {
                    model.RecommendGenera = int.Parse(ds.Tables[0].Rows[0]["RecommendGenera"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentCode"] != null && ds.Tables[0].Rows[0]["ParentCode"].ToString() != "")
                {
                    model.ParentCode = ds.Tables[0].Rows[0]["ParentCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserPath"] != null && ds.Tables[0].Rows[0]["UserPath"].ToString() != "")
                {
                    model.UserPath = ds.Tables[0].Rows[0]["UserPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Layer"] != null && ds.Tables[0].Rows[0]["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(ds.Tables[0].Rows[0]["Layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Location"] != null && ds.Tables[0].Rows[0]["Location"].ToString() != "")
                {
                    model.Location = int.Parse(ds.Tables[0].Rows[0]["Location"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOpend"] != null && ds.Tables[0].Rows[0]["IsOpend"].ToString() != "")
                {
                    model.IsOpend = int.Parse(ds.Tables[0].Rows[0]["IsOpend"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"] != null && ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsAgent"] != null && ds.Tables[0].Rows[0]["IsAgent"].ToString() != "")
                {
                    model.IsAgent = int.Parse(ds.Tables[0].Rows[0]["IsAgent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AgentsID"] != null && ds.Tables[0].Rows[0]["AgentsID"].ToString() != "")
                {
                    model.AgentsID = int.Parse(ds.Tables[0].Rows[0]["AgentsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Emoney"] != null && ds.Tables[0].Rows[0]["Emoney"].ToString() != "")
                {
                    model.Emoney = decimal.Parse(ds.Tables[0].Rows[0]["Emoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BonusAccount"] != null && ds.Tables[0].Rows[0]["BonusAccount"].ToString() != "")
                {
                    model.BonusAccount = decimal.Parse(ds.Tables[0].Rows[0]["BonusAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllBonusAccount"] != null && ds.Tables[0].Rows[0]["AllBonusAccount"].ToString() != "")
                {
                    model.AllBonusAccount = decimal.Parse(ds.Tables[0].Rows[0]["AllBonusAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockAccount"] != null && ds.Tables[0].Rows[0]["StockAccount"].ToString() != "")
                {
                    model.StockAccount = decimal.Parse(ds.Tables[0].Rows[0]["StockAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockMoney"] != null && ds.Tables[0].Rows[0]["StockMoney"].ToString() != "")
                {
                    model.StockMoney = decimal.Parse(ds.Tables[0].Rows[0]["StockMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShopAccount"] != null && ds.Tables[0].Rows[0]["ShopAccount"].ToString() != "")
                {
                    model.ShopAccount = decimal.Parse(ds.Tables[0].Rows[0]["ShopAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegTime"] != null && ds.Tables[0].Rows[0]["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(ds.Tables[0].Rows[0]["RegTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OpenTime"] != null && ds.Tables[0].Rows[0]["OpenTime"].ToString() != "")
                {
                    model.OpenTime = DateTime.Parse(ds.Tables[0].Rows[0]["OpenTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegMoney"] != null && ds.Tables[0].Rows[0]["RegMoney"].ToString() != "")
                {
                    model.RegMoney = decimal.Parse(ds.Tables[0].Rows[0]["RegMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BillCount"] != null && ds.Tables[0].Rows[0]["BillCount"].ToString() != "")
                {
                    model.BillCount = int.Parse(ds.Tables[0].Rows[0]["BillCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GLmoney"] != null && ds.Tables[0].Rows[0]["GLmoney"].ToString() != "")
                {
                    model.GLmoney = decimal.Parse(ds.Tables[0].Rows[0]["GLmoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddGLTime"] != null && ds.Tables[0].Rows[0]["AddGLTime"].ToString() != "")
                {
                    model.AddGLTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddGLTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SecondPassword"] != null && ds.Tables[0].Rows[0]["SecondPassword"].ToString() != "")
                {
                    model.SecondPassword = ds.Tables[0].Rows[0]["SecondPassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ThreePassword"] != null && ds.Tables[0].Rows[0]["ThreePassword"].ToString() != "")
                {
                    model.ThreePassword = ds.Tables[0].Rows[0]["ThreePassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SafetyCodeQuestion"] != null && ds.Tables[0].Rows[0]["SafetyCodeQuestion"].ToString() != "")
                {
                    model.SafetyCodeQuestion = ds.Tables[0].Rows[0]["SafetyCodeQuestion"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SafetyCodeAnswer"] != null && ds.Tables[0].Rows[0]["SafetyCodeAnswer"].ToString() != "")
                {
                    model.SafetyCodeAnswer = ds.Tables[0].Rows[0]["SafetyCodeAnswer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LeftScore"] != null && ds.Tables[0].Rows[0]["LeftScore"].ToString() != "")
                {
                    model.LeftScore = decimal.Parse(ds.Tables[0].Rows[0]["LeftScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterScore"] != null && ds.Tables[0].Rows[0]["CenterScore"].ToString() != "")
                {
                    model.CenterScore = decimal.Parse(ds.Tables[0].Rows[0]["CenterScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightScore"] != null && ds.Tables[0].Rows[0]["RightScore"].ToString() != "")
                {
                    model.RightScore = decimal.Parse(ds.Tables[0].Rows[0]["RightScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LeftBalance"] != null && ds.Tables[0].Rows[0]["LeftBalance"].ToString() != "")
                {
                    model.LeftBalance = decimal.Parse(ds.Tables[0].Rows[0]["LeftBalance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterBalance"] != null && ds.Tables[0].Rows[0]["CenterBalance"].ToString() != "")
                {
                    model.CenterBalance = decimal.Parse(ds.Tables[0].Rows[0]["CenterBalance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightBalance"] != null && ds.Tables[0].Rows[0]["RightBalance"].ToString() != "")
                {
                    model.RightBalance = decimal.Parse(ds.Tables[0].Rows[0]["RightBalance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LeftNewScore"] != null && ds.Tables[0].Rows[0]["LeftNewScore"].ToString() != "")
                {
                    model.LeftNewScore = decimal.Parse(ds.Tables[0].Rows[0]["LeftNewScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterNewScore"] != null && ds.Tables[0].Rows[0]["CenterNewScore"].ToString() != "")
                {
                    model.CenterNewScore = decimal.Parse(ds.Tables[0].Rows[0]["CenterNewScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightNewScore"] != null && ds.Tables[0].Rows[0]["RightNewScore"].ToString() != "")
                {
                    model.RightNewScore = decimal.Parse(ds.Tables[0].Rows[0]["RightNewScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LeftZT"] != null && ds.Tables[0].Rows[0]["LeftZT"].ToString() != "")
                {
                    model.LeftZT = decimal.Parse(ds.Tables[0].Rows[0]["LeftZT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CenterZT"] != null && ds.Tables[0].Rows[0]["CenterZT"].ToString() != "")
                {
                    model.CenterZT = decimal.Parse(ds.Tables[0].Rows[0]["CenterZT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RightZT"] != null && ds.Tables[0].Rows[0]["RightZT"].ToString() != "")
                {
                    model.RightZT = decimal.Parse(ds.Tables[0].Rows[0]["RightZT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankAccount"] != null && ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccountUser"] != null && ds.Tables[0].Rows[0]["BankAccountUser"].ToString() != "")
                {
                    model.BankAccountUser = ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankName"] != null && ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankBranch"] != null && ds.Tables[0].Rows[0]["BankBranch"].ToString() != "")
                {
                    model.BankBranch = ds.Tables[0].Rows[0]["BankBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankInProvince"] != null && ds.Tables[0].Rows[0]["BankInProvince"].ToString() != "")
                {
                    model.BankInProvince = ds.Tables[0].Rows[0]["BankInProvince"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankInCity"] != null && ds.Tables[0].Rows[0]["BankInCity"].ToString() != "")
                {
                    model.BankInCity = ds.Tables[0].Rows[0]["BankInCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TrueName"] != null && ds.Tables[0].Rows[0]["TrueName"].ToString() != "")
                {
                    model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NiceName"] != null && ds.Tables[0].Rows[0]["NiceName"].ToString() != "")
                {
                    model.NiceName = ds.Tables[0].Rows[0]["NiceName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IdenCode"] != null && ds.Tables[0].Rows[0]["IdenCode"].ToString() != "")
                {
                    model.IdenCode = ds.Tables[0].Rows[0]["IdenCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PhoneNum"] != null && ds.Tables[0].Rows[0]["PhoneNum"].ToString() != "")
                {
                    model.PhoneNum = ds.Tables[0].Rows[0]["PhoneNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Gender"] != null && ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(ds.Tables[0].Rows[0]["Gender"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QQnumer"] != null && ds.Tables[0].Rows[0]["QQnumer"].ToString() != "")
                {
                    model.QQnumer = ds.Tables[0].Rows[0]["QQnumer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User001"] != null && ds.Tables[0].Rows[0]["User001"].ToString() != "")
                {
                    model.User001 = int.Parse(ds.Tables[0].Rows[0]["User001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User002"] != null && ds.Tables[0].Rows[0]["User002"].ToString() != "")
                {
                    model.User002 = long.Parse(ds.Tables[0].Rows[0]["User002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User003"] != null && ds.Tables[0].Rows[0]["User003"].ToString() != "")
                {
                    model.User003 = int.Parse(ds.Tables[0].Rows[0]["User003"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User004"] != null && ds.Tables[0].Rows[0]["User004"].ToString() != "")
                {
                    model.User004 = int.Parse(ds.Tables[0].Rows[0]["User004"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User005"] != null && ds.Tables[0].Rows[0]["User005"].ToString() != "")
                {
                    model.User005 = ds.Tables[0].Rows[0]["User005"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User006"] != null && ds.Tables[0].Rows[0]["User006"].ToString() != "")
                {
                    model.User006 = ds.Tables[0].Rows[0]["User006"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User007"] != null && ds.Tables[0].Rows[0]["User007"].ToString() != "")
                {
                    model.User007 = ds.Tables[0].Rows[0]["User007"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User008"] != null && ds.Tables[0].Rows[0]["User008"].ToString() != "")
                {
                    model.User008 = ds.Tables[0].Rows[0]["User008"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User009"] != null && ds.Tables[0].Rows[0]["User009"].ToString() != "")
                {
                    model.User009 = ds.Tables[0].Rows[0]["User009"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User010"] != null && ds.Tables[0].Rows[0]["User010"].ToString() != "")
                {
                    model.User010 = ds.Tables[0].Rows[0]["User010"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User011"] != null && ds.Tables[0].Rows[0]["User011"].ToString() != "")
                {
                    model.User011 = decimal.Parse(ds.Tables[0].Rows[0]["User011"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User012"] != null && ds.Tables[0].Rows[0]["User012"].ToString() != "")
                {
                    model.User012 = decimal.Parse(ds.Tables[0].Rows[0]["User012"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User013"] != null && ds.Tables[0].Rows[0]["User013"].ToString() != "")
                {
                    model.User013 = decimal.Parse(ds.Tables[0].Rows[0]["User013"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User014"] != null && ds.Tables[0].Rows[0]["User014"].ToString() != "")
                {
                    model.User014 = decimal.Parse(ds.Tables[0].Rows[0]["User014"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User015"] != null && ds.Tables[0].Rows[0]["User015"].ToString() != "")
                {
                    model.User015 = decimal.Parse(ds.Tables[0].Rows[0]["User015"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User016"] != null && ds.Tables[0].Rows[0]["User016"].ToString() != "")
                {
                    model.User016 = decimal.Parse(ds.Tables[0].Rows[0]["User016"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User017"] != null && ds.Tables[0].Rows[0]["User017"].ToString() != "")
                {
                    model.User017 = decimal.Parse(ds.Tables[0].Rows[0]["User017"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User018"] != null && ds.Tables[0].Rows[0]["User018"].ToString() != "")
                {
                    model.User018 = decimal.Parse(ds.Tables[0].Rows[0]["User018"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsOut"].ToString() != "")
                {
                    model.IsOut = int.Parse(ds.Tables[0].Rows[0]["IsOut"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Batch"].ToString() != "")
                {
                    model.Batch = int.Parse(ds.Tables[0].Rows[0]["Batch"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 根据给定的会员编号，获取其下面的所有会员。
        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员。
        /// </summary>
        /// <param name="iUserID">根据给定的会员编号</param>
        /// <returns></returns>
        public string GetAllChildrenID(long iUserID)
        {
            strSunID = "";//全局变量，上面有定义

            strSunID = GetChildID(iUserID);

            strSunID = strSunID.Substring(0, strSunID.Length - 1);

            return strSunID;
        }
        #endregion

        #region 根据给定的会员编号，获取其下面的所有会员。
        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员。
        /// </summary>
        /// <param name="iUserID">给定的会员编号</param>
        /// <returns></returns>
        public string GetChildID(long iUserID)
        {
            string strChildeeID = "", strSunsID = "";

            strChildeeID = GetSunID(iUserID);
            strSunID += strChildeeID + ",";

            string[] strChildID = strChildeeID.Split(',');

            int iLength = strChildID.Length;

            for (int i = 0; i < iLength; i++)
            {
                if (strChildID[i] != "")
                {
                    int m = Convert.ToInt32(strChildID[i]);
                    strSunsID = GetSunID(m);
                    if (strSunsID != "")
                    {
                        GetChildID(m);
                    }
                }
            }
            return strSunID;
        }
        #endregion

        #region 根据给定的栏目编号，获取其下面的子栏目（一级子栏目）。
        /// <summary>
        /// 根据给定的栏目编号，获取其下面的子栏目（一级子栏目）。
        /// </summary>
        /// <param name="iColumnID">给定的栏目编号</param>
        /// <returns></returns>
        public string GetSunID(long iUserID)
        {
            int iCount = 0;
            string strSunID = "";

            SortedList<string, lgk.Model.tb_user> myUser = new SortedList<string, lgk.Model.tb_user>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT [UserID] FROM [tb_user]");
            strSql.Append(" WHERE ParentID=@ParentID");
            SqlParameter[] parameters = {
                        new SqlParameter("@ParentID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lgk.Model.tb_user model = new lgk.Model.tb_user();

                    if (ds.Tables[0].Rows[i]["UserID"] != null && ds.Tables[0].Rows[i]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(ds.Tables[0].Rows[i]["UserID"].ToString());
                        myUser.Add(Convert.ToString(iCount), model);
                        iCount++;
                    }
                }
            }

            iCount = myUser.Count;

            if (iCount > 0)
            {
                for (int i = 0; i < iCount; i++)
                {
                    if (i == iCount - 1)
                    {
                        strSunID += myUser.Values[i].UserID;
                    }
                    else
                    {
                        strSunID += myUser.Values[i].UserID + ",";
                    }
                }
            }
            else
            {
                strSunID = "";
            }

            return strSunID;
        }
        #endregion

        #region 根据给定的会员编号，获取能安置会员的会员编号
        /// <summary>
        /// 根据给定的会员编号，获取能安置会员的会员编号
        /// </summary>
        /// <param name="iParentID"></param>
        /// <returns></returns>
        public long GetPlacementID(long iParentID)
        {
            long iUserID = 0;

            string strUserID = GetAllChildrenID(iParentID);
            if (strUserID != "")
            {
                lgk.Model.tb_user model = new lgk.Model.tb_user();

                string[] arryID = strUserID.Split(',');
                for (int i = 0; i < arryID.Length; i++)
                {
                    model = GetModel(long.Parse(arryID[i]));
                    if (FlagLoc(model.UserID, 1))
                        iUserID = 0;//左区域已有会员
                    else
                    {
                        iUserID = model.UserID;
                        break;
                    }
                }
            }
            else
            {
                iUserID = iParentID;
            }

            return Convert.ToInt64(iUserID);
        }
        #endregion

        public bool FlagLoc(long iParentID, int iLoc)
        {
            bool bFlag = false;
            string strSql = "";
            strSql = @"SELECT COUNT(0) FROM tb_user WHERE UserID =" + iParentID + " AND Location>=8";

            if (Convert.ToInt32(DbHelperSQL.GetSingle(strSql)) > 0)
                bFlag = true;
            else
                bFlag = false;

            return bFlag;
        }

        #region 根据给定的用户编号，获取其能安置下线的位置。
        /// <summary>
        /// 根据给定的用户编号，获取其能安置下线的位置。
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public int GetLocation(long iUserID)
        {
            int iLoc = 0;

            int reNum = Convert.ToInt32(DbHelperSQL.GetSingle("select count(*) from tb_user where RecommendID=" + iUserID + ""));
            if (reNum == 0)
                iLoc = 1;
            else
                iLoc = 2;

            return iLoc;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM tb_user");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 获得前几行字段
        /// <summary>
        /// 获得前几行字段
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strField"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListField(int Top, string strField, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString() + " ");
            }
            strSql.Append(strField);
            strSql.Append(" FROM tb_user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        /// <summary>
        /// 计算注册金额
        /// </summary>
        public decimal CountRegMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ISNULL(SUM(RegMoney),0) AS RegMoney");
            strSql.Append(" FROM tb_user");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            decimal dRegMoney = 0;
            if (obj != null)
            {
                decimal.TryParse(obj.ToString(), out dRegMoney);
            }
            return dRegMoney;
        }

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetOpenList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select tb_user.UserID,tb_user.RecommendCode,tb_user.UserCode,tb_user.TrueName,tb_user.LevelID,tb_user.Location,tb_user.GLmoney,");
            strSql.Append(@"tb_user.RegMoney,tb_Level.LevelName,tb_user.User006,tb_user.ParentCode,tb_user.User007,tb_user.IsOpend,");
            strSql.Append(@"tb_user.IsLock,tb_user.User002,tb_Level.Level03,tb_user.User008,User004,tb_user.RegTime,tb_user.OpenTime,");
            strSql.Append(@"tb_user.Email,tb_user.IsOut,tb_user.Batch from tb_user join tb_Level on tb_user.LevelID=tb_Level.LevelID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDetailList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select tb_user.UserID,tb_user.UserCode,tb_user.TrueName,tb_user.LevelID,tb_Level.LevelName,tb_user.GLmoney,");
            strSql.Append(@"tb_user.RegMoney,tb_user.BankName,tb_user.BankAccount,tb_user.BankAccountUser,tb_user.IdenCode,tb_user.PhoneNum,");
            strSql.Append(@"tb_user.Address,tb_user.User005,tb_user.NiceName,tb_user.BonusAccount,tb_user.Emoney,tb_user.IsLock,tb_user.IsOpend,");
            strSql.Append(@"tb_user.Email,tb_user.IsOut,tb_user.Batch from tb_user join tb_Level on tb_user.LevelID=tb_Level.LevelID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" *");
            strSql.Append(" FROM tb_user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" ORDER BY " + filedOrder);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 判断给定的会员是否已开通
        /// <summary>
        /// 判断给定的会员是否已开通
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool ExistsIsOpend(long UserID)
        {
            bool bFlag = false;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [IsOpend] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = UserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                bFlag = false;
            }
            else
            {
                int iIsOpend = int.Parse(obj.ToString());
                if (iIsOpend == 2)
                    bFlag = true;
                else
                    bFlag = false;
            }

            return bFlag;
        }
        #endregion

        /// <summary>
        /// 判断给定的父节点和区域是否已有开通的会员
        /// </summary>
        /// <param name="iParentID"></param>
        /// <param name="iLoc"></param>
        /// <returns></returns>
        //public bool FlagLoc(long iParentID, int iLoc)
        //{
        //    bool bFlag = false;
        //    string strSql = "";
        //    strSql = @"SELECT COUNT(0) FROM tb_user WHERE LevelID<8 and G_ParentID=" + iParentID + " AND G_Loaction=" + iLoc;

        //    if (Convert.ToInt32(DbHelperSQL.GetSingle(strSql)) > 0)
        //        bFlag = true;
        //    else
        //        bFlag = false;

        //    return bFlag;
        //}

        #region 获取已开通的父接点
        /// <summary>
        /// 获取已开通的父接点
        /// </summary>
        /// <returns></returns>
        public long GetParentID(long iUserID)
        {
            long iParentID = 0;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RecommendID] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                iParentID = 0;
            }
            else
            {
                iParentID = long.Parse(obj.ToString());
            }

            if (!ExistsIsOpend(iParentID))
                iParentID = GetParentID(iParentID);

            return iParentID;
        }
        #endregion

        #region 根据用户ID获取用户编号
        /// <summary>
        /// 根据用户ID获取用户编号
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string GetUserCodeByUserID(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT UserCode FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        /// <summary>
        /// 判断给定的推荐人和安置人是否在同一条线上。
        /// </summary>
        /// <param name="iRecommendID">给定的推荐人</param>
        /// <param name="iParentID">给定的安置人</param>
        /// <returns></returns>
        public bool OnRecommendSameLine(long iRecommendID, long iUserID)
        {
            bool bFlag = false;

            string strRecommendPathOne = GetRecommendPath(iRecommendID);
            string strRecommendPathTow = GetRecommendPath(iUserID);

            if (strRecommendPathTow.Contains(strRecommendPathOne) || strRecommendPathOne.Contains(strRecommendPathTow))
                bFlag = true;
            else
                bFlag = false;

            return bFlag;
        }

        /// <summary>
        /// 根据给定的用户ID，获取用户路径。
        /// </summary>
        /// <param name="iUserID">给定的用户ID</param>
        /// <returns></returns>
        public string GetRecommendPath(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RecommendPath] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 查询语句
        /// </summary>
        /// <param name="pTable"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet getData_Chaxun(string pTable, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"" + pTable + "");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        ///  更新现金数据
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int UpdataData_Chaxun(string sql, string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("" + sql + " ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.VarChar)};
            parameters[0].Value = UserID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        #endregion  Method
    }
}

