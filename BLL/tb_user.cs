using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_user
	/// </summary>
	public partial class tb_user
	{
		private readonly lgk.DAL.tb_user dal=new lgk.DAL.tb_user();
		public tb_user()
        { }
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long UserID)
		{
			return dal.Exists(UserID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strUserCode)
        {
            return dal.Exists(strUserCode);
        }

        /// <summary>
        /// 是否有子会员
        /// </summary>
        public bool HasChildren(long userID)
        {
            return dal.HasChildren(userID);
        }

        /// <summary>
        /// 判断给定的用户是否为报单中心
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public bool IsAgent(long iUserID)
        {
            return dal.IsAgent(iUserID);
        }

        /// <summary>
        /// 根据给定的用户ID，获取用户编号。
        /// </summary>
        /// <param name="iUserID">给定的用户ID</param>
        /// <returns></returns>
        public string GetUserCode(long iUserID)
        {
            return dal.GetUserCode(iUserID);
        }

        /// <summary>
        /// 根据给定额用户编号，获取用户ID
        /// </summary>
        /// <param name="strUserCode">给定额用户编号</param>
        /// <returns></returns>
        public long GetUserID(string strUserCode)
        {
            return dal.GetUserID(strUserCode);
        }

        /// <summary>
        /// 获取给定会员ID的注册币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetEMoney(long iUserID)
        {
            return dal.GetEMoney(iUserID);
        }

        /// <summary>
        /// 判断给定的推荐人和安置人是否在同一条线上。
        /// </summary>
        /// <param name="iRecommendID">给定的推荐人</param>
        /// <param name="iParentID">给定的安置人</param>
        /// <returns></returns>
        public bool OnSameLine(long iRecommendID, long iParentID)
        {
            return dal.OnSameLine(iRecommendID, iParentID);
        }

        /// <summary>
        /// 获取给定会员的路径
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public string GetUserPath(long iUserID)
        {
            return dal.GetUserPath(iUserID);
        }

        /// <summary>
        /// 获取给定会员ID的金币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetMoney(long iUserID, string strFieldName)
        {
            return dal.GetMoney(iUserID, strFieldName);
        }

        /// <summary>
        /// 获取给定会员ID的金币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetBonusAccount(long iUserID)
        {
            return dal.GetBonusAccount(iUserID);
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.tb_user model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_user model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 更新给定账号ID的复投次数(iTypeID:0减少，1增加)
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="iTypeID"></param>
        /// <returns></returns>
        public bool UpdateBatch(long iUserID, int iTypeID)
        {
            return dal.UpdateBatch(iUserID, iTypeID);
        }

        /// <summary>
        /// 开通空单
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public bool UpdateEmpty(long iUserID)
        {
            return dal.UpdateEmpty(iUserID);
        }

        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员。
        /// </summary>
        /// <param name="iUserID">根据给定的会员编号</param>
        /// <returns></returns>
        public string GetAllRecommendID(long iUserID)
        {
            return dal.GetAllRecommendID(iUserID);
        }

        /// <summary>
        /// 将给定的用户ID更新成报单中心
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
        public bool UpdateAgent(long iUserID)
        {
            return dal.UpdateAgent(iUserID);
        }

        /// <summary>
        /// 修改下线的报单中心信息
        /// </summary>
        public void UpdateAgent(long iID, long iUserID, string strUserCode)
        {
            string strRecom = "";
            dal.UpdateAgent(iID, iUserID, strUserCode);//更新直接推荐的会员

            //更新下线会员
            string strRecommendID = dal.GetAllRecommendID(iUserID);

            if (!string.IsNullOrEmpty(strRecommendID))
            {
                string[] arrayRecommendID = strRecommendID.Split(',');

                foreach (string strRecID in arrayRecommendID)
                {
                    if (dal.IsAgent(long.Parse(strRecID)) && long.Parse(strRecID) != iUserID)
                    {
                        strRecom = dal.GetAllRecommendID(long.Parse(strRecID));

                        if (!string.IsNullOrEmpty(strRecom))
                        {
                            string[] arrayRecom = strRecom.Split(',');
                            foreach (string strRecomID in arrayRecom)
                            {
                                strRecommendID = strRecommendID.Replace(strRecomID, "");
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(strRecommendID))
            {
                string[] arrayRecommendID = strRecommendID.Split(',');

                foreach (string strRecID in arrayRecommendID)
                {
                    if (!string.IsNullOrEmpty(strRecID))
                    {
                        if (!dal.IsAgent(long.Parse(strRecID)))
                        {
                            dal.UpdateAgent(iID, long.Parse(strRecID), strUserCode);
                        }
                    }
                }
            }
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long UserID)
		{
			return dal.Delete(UserID);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIDlist )
		{
			return dal.DeleteList(UserIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_user GetModel(long UserID)
		{
			return dal.GetModel(UserID);
		}

        /// <summary>
        /// 根据条件获得会员实体(用户商城用户注册)
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModelForShop(string strWhere)
        {
            return dal.GetModelForShop(strWhere);
        }

        /// <summary>
        /// 根据条件获得会员实体
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModel(string strWhere)
        {
            return dal.GetModel(strWhere);
        }

        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员
        /// </summary>
        /// <param name="iUserID">根据给定的会员编号</param>
        /// <returns></returns>
        public string GetAllChildrenID(long iUserID)
        {
            return dal.GetAllChildrenID(iUserID);
        }

        /// <summary>
        /// 根据给定的会员编号，获取能安置会员的会员编号
        /// </summary>
        /// <param name="iParentID"></param>
        /// <returns></returns>
        public long GetPlacementID(long iParentID)
        {
            return dal.GetPlacementID(iParentID);
        }

        /// <summary>
        /// 根据给定的用户编号，获取其能安置下线的位置。
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public int GetLocation(long iUserID)
        {
            return dal.GetLocation(iUserID);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetOpenList(string strWhere)
        {
            return dal.GetOpenList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDetailList(string strWhere)
        {
            return dal.GetDetailList(strWhere);
        }

        /// <summary>
        /// 计算注册金额
        /// </summary>
        public decimal CountRegMoney(string strWhere)
        {
            return dal.CountRegMoney(strWhere);
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

        /// <summary>
        /// 获得前几行字段
        /// </summary>
        public DataSet GetListField(int Top, string strField, string strWhere)
        {
            return dal.GetListField(Top, strField, strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_user> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_user> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_user> modelList = new List<lgk.Model.tb_user>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_user model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_user();
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["UserCode"] != null && dt.Rows[n]["UserCode"].ToString() != "")
                    {
                        model.UserCode = dt.Rows[n]["UserCode"].ToString();
                    }
                    if (dt.Rows[n]["LevelID"] != null && dt.Rows[n]["LevelID"].ToString() != "")
                    {
                        model.LevelID = int.Parse(dt.Rows[n]["LevelID"].ToString());
                    }
                    if (dt.Rows[n]["RecommendID"] != null && dt.Rows[n]["RecommendID"].ToString() != "")
                    {
                        model.RecommendID = long.Parse(dt.Rows[n]["RecommendID"].ToString());
                    }
                    if (dt.Rows[n]["RecommendCode"] != null && dt.Rows[n]["RecommendCode"].ToString() != "")
                    {
                        model.RecommendCode = dt.Rows[n]["RecommendCode"].ToString();
                    }
                    if (dt.Rows[n]["RecommendPath"] != null && dt.Rows[n]["RecommendPath"].ToString() != "")
                    {
                        model.RecommendPath = dt.Rows[n]["RecommendPath"].ToString();
                    }
                    if (dt.Rows[n]["RecommendGenera"] != null && dt.Rows[n]["RecommendGenera"].ToString() != "")
                    {
                        model.RecommendGenera = int.Parse(dt.Rows[n]["RecommendGenera"].ToString());
                    }
                    if (dt.Rows[n]["ParentID"] != null && dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = long.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    if (dt.Rows[n]["ParentCode"] != null && dt.Rows[n]["ParentCode"].ToString() != "")
                    {
                        model.ParentCode = dt.Rows[n]["ParentCode"].ToString();
                    }
                    if (dt.Rows[n]["UserPath"] != null && dt.Rows[n]["UserPath"].ToString() != "")
                    {
                        model.UserPath = dt.Rows[n]["UserPath"].ToString();
                    }
                    if (dt.Rows[n]["Layer"] != null && dt.Rows[n]["Layer"].ToString() != "")
                    {
                        model.Layer = int.Parse(dt.Rows[n]["Layer"].ToString());
                    }
                    if (dt.Rows[n]["Location"] != null && dt.Rows[n]["Location"].ToString() != "")
                    {
                        model.Location = int.Parse(dt.Rows[n]["Location"].ToString());
                    }
                    if (dt.Rows[n]["IsOpend"] != null && dt.Rows[n]["IsOpend"].ToString() != "")
                    {
                        model.IsOpend = int.Parse(dt.Rows[n]["IsOpend"].ToString());
                    }
                    if (dt.Rows[n]["IsLock"] != null && dt.Rows[n]["IsLock"].ToString() != "")
                    {
                        model.IsLock = int.Parse(dt.Rows[n]["IsLock"].ToString());
                    }
                    if (dt.Rows[n]["IsAgent"] != null && dt.Rows[n]["IsAgent"].ToString() != "")
                    {
                        model.IsAgent = int.Parse(dt.Rows[n]["IsAgent"].ToString());
                    }
                    if (dt.Rows[n]["AgentsID"] != null && dt.Rows[n]["AgentsID"].ToString() != "")
                    {
                        model.AgentsID = long.Parse(dt.Rows[n]["AgentsID"].ToString());
                    }
                    if (dt.Rows[n]["Emoney"] != null && dt.Rows[n]["Emoney"].ToString() != "")
                    {
                        model.Emoney = decimal.Parse(dt.Rows[n]["Emoney"].ToString());
                    }
                    if (dt.Rows[n]["BonusAccount"] != null && dt.Rows[n]["BonusAccount"].ToString() != "")
                    {
                        model.BonusAccount = decimal.Parse(dt.Rows[n]["BonusAccount"].ToString());
                    }
                    if (dt.Rows[n]["AllBonusAccount"] != null && dt.Rows[n]["AllBonusAccount"].ToString() != "")
                    {
                        model.AllBonusAccount = decimal.Parse(dt.Rows[n]["AllBonusAccount"].ToString());
                    }
                    if (dt.Rows[n]["StockAccount"] != null && dt.Rows[n]["StockAccount"].ToString() != "")
                    {
                        model.StockAccount = decimal.Parse(dt.Rows[n]["StockAccount"].ToString());
                    }
                    if (dt.Rows[n]["StockMoney"] != null && dt.Rows[n]["StockMoney"].ToString() != "")
                    {
                        model.StockMoney = decimal.Parse(dt.Rows[n]["StockMoney"].ToString());
                    }
                    if (dt.Rows[n]["ShopAccount"] != null && dt.Rows[n]["ShopAccount"].ToString() != "")
                    {
                        model.ShopAccount = decimal.Parse(dt.Rows[n]["ShopAccount"].ToString());
                    }
                    if (dt.Rows[n]["RegTime"] != null && dt.Rows[n]["RegTime"].ToString() != "")
                    {
                        model.RegTime = DateTime.Parse(dt.Rows[n]["RegTime"].ToString());
                    }
                    if (dt.Rows[n]["OpenTime"] != null && dt.Rows[n]["OpenTime"].ToString() != "")
                    {
                        model.OpenTime = DateTime.Parse(dt.Rows[n]["OpenTime"].ToString());
                    }
                    if (dt.Rows[n]["RegMoney"] != null && dt.Rows[n]["RegMoney"].ToString() != "")
                    {
                        model.RegMoney = decimal.Parse(dt.Rows[n]["RegMoney"].ToString());
                    }
                    if (dt.Rows[n]["BillCount"] != null && dt.Rows[n]["BillCount"].ToString() != "")
                    {
                        model.BillCount = int.Parse(dt.Rows[n]["BillCount"].ToString());
                    }
                    if (dt.Rows[n]["GLmoney"] != null && dt.Rows[n]["GLmoney"].ToString() != "")
                    {
                        model.GLmoney = decimal.Parse(dt.Rows[n]["GLmoney"].ToString());
                    }
                    if (dt.Rows[n]["AddGLTime"] != null && dt.Rows[n]["AddGLTime"].ToString() != "")
                    {
                        model.AddGLTime = DateTime.Parse(dt.Rows[n]["AddGLTime"].ToString());
                    }
                    if (dt.Rows[n]["Password"] != null && dt.Rows[n]["Password"].ToString() != "")
                    {
                        model.Password = dt.Rows[n]["Password"].ToString();
                    }
                    if (dt.Rows[n]["SecondPassword"] != null && dt.Rows[n]["SecondPassword"].ToString() != "")
                    {
                        model.SecondPassword = dt.Rows[n]["SecondPassword"].ToString();
                    }
                    if (dt.Rows[n]["ThreePassword"] != null && dt.Rows[n]["ThreePassword"].ToString() != "")
                    {
                        model.ThreePassword = dt.Rows[n]["ThreePassword"].ToString();
                    }
                    if (dt.Rows[n]["SafetyCodeQuestion"] != null && dt.Rows[n]["SafetyCodeQuestion"].ToString() != "")
                    {
                        model.SafetyCodeQuestion = dt.Rows[n]["SafetyCodeQuestion"].ToString();
                    }
                    if (dt.Rows[n]["SafetyCodeAnswer"] != null && dt.Rows[n]["SafetyCodeAnswer"].ToString() != "")
                    {
                        model.SafetyCodeAnswer = dt.Rows[n]["SafetyCodeAnswer"].ToString();
                    }
                    if (dt.Rows[n]["LeftScore"] != null && dt.Rows[n]["LeftScore"].ToString() != "")
                    {
                        model.LeftScore = decimal.Parse(dt.Rows[n]["LeftScore"].ToString());
                    }
                    if (dt.Rows[n]["CenterScore"] != null && dt.Rows[n]["CenterScore"].ToString() != "")
                    {
                        model.CenterScore = decimal.Parse(dt.Rows[n]["CenterScore"].ToString());
                    }
                    if (dt.Rows[n]["RightScore"] != null && dt.Rows[n]["RightScore"].ToString() != "")
                    {
                        model.RightScore = decimal.Parse(dt.Rows[n]["RightScore"].ToString());
                    }
                    if (dt.Rows[n]["LeftBalance"] != null && dt.Rows[n]["LeftBalance"].ToString() != "")
                    {
                        model.LeftBalance = decimal.Parse(dt.Rows[n]["LeftBalance"].ToString());
                    }
                    if (dt.Rows[n]["CenterBalance"] != null && dt.Rows[n]["CenterBalance"].ToString() != "")
                    {
                        model.CenterBalance = decimal.Parse(dt.Rows[n]["CenterBalance"].ToString());
                    }
                    if (dt.Rows[n]["RightBalance"] != null && dt.Rows[n]["RightBalance"].ToString() != "")
                    {
                        model.RightBalance = decimal.Parse(dt.Rows[n]["RightBalance"].ToString());
                    }
                    if (dt.Rows[n]["LeftNewScore"] != null && dt.Rows[n]["LeftNewScore"].ToString() != "")
                    {
                        model.LeftNewScore = decimal.Parse(dt.Rows[n]["LeftNewScore"].ToString());
                    }
                    if (dt.Rows[n]["CenterNewScore"] != null && dt.Rows[n]["CenterNewScore"].ToString() != "")
                    {
                        model.CenterNewScore = decimal.Parse(dt.Rows[n]["CenterNewScore"].ToString());
                    }
                    if (dt.Rows[n]["RightNewScore"] != null && dt.Rows[n]["RightNewScore"].ToString() != "")
                    {
                        model.RightNewScore = decimal.Parse(dt.Rows[n]["RightNewScore"].ToString());
                    }
                    if (dt.Rows[n]["LeftZT"] != null && dt.Rows[n]["LeftZT"].ToString() != "")
                    {
                        model.LeftZT = decimal.Parse(dt.Rows[n]["LeftZT"].ToString());
                    }
                    if (dt.Rows[n]["CenterZT"] != null && dt.Rows[n]["CenterZT"].ToString() != "")
                    {
                        model.CenterZT = decimal.Parse(dt.Rows[n]["CenterZT"].ToString());
                    }
                    if (dt.Rows[n]["RightZT"] != null && dt.Rows[n]["RightZT"].ToString() != "")
                    {
                        model.RightZT = decimal.Parse(dt.Rows[n]["RightZT"].ToString());
                    }
                    if (dt.Rows[n]["BankAccount"] != null && dt.Rows[n]["BankAccount"].ToString() != "")
                    {
                        model.BankAccount = dt.Rows[n]["BankAccount"].ToString();
                    }
                    if (dt.Rows[n]["BankAccountUser"] != null && dt.Rows[n]["BankAccountUser"].ToString() != "")
                    {
                        model.BankAccountUser = dt.Rows[n]["BankAccountUser"].ToString();
                    }
                    if (dt.Rows[n]["BankName"] != null && dt.Rows[n]["BankName"].ToString() != "")
                    {
                        model.BankName = dt.Rows[n]["BankName"].ToString();
                    }
                    if (dt.Rows[n]["BankBranch"] != null && dt.Rows[n]["BankBranch"].ToString() != "")
                    {
                        model.BankBranch = dt.Rows[n]["BankBranch"].ToString();
                    }
                    if (dt.Rows[n]["BankInProvince"] != null && dt.Rows[n]["BankInProvince"].ToString() != "")
                    {
                        model.BankInProvince = dt.Rows[n]["BankInProvince"].ToString();
                    }
                    if (dt.Rows[n]["BankInCity"] != null && dt.Rows[n]["BankInCity"].ToString() != "")
                    {
                        model.BankInCity = dt.Rows[n]["BankInCity"].ToString();
                    }
                    if (dt.Rows[n]["Address"] != null && dt.Rows[n]["Address"].ToString() != "")
                    {
                        model.Address = dt.Rows[n]["Address"].ToString();
                    }
                    if (dt.Rows[n]["TrueName"] != null && dt.Rows[n]["TrueName"].ToString() != "")
                    {
                        model.TrueName = dt.Rows[n]["TrueName"].ToString();
                    }
                    if (dt.Rows[n]["NiceName"] != null && dt.Rows[n]["NiceName"].ToString() != "")
                    {
                        model.NiceName = dt.Rows[n]["NiceName"].ToString();
                    }
                    if (dt.Rows[n]["IdenCode"] != null && dt.Rows[n]["IdenCode"].ToString() != "")
                    {
                        model.IdenCode = dt.Rows[n]["IdenCode"].ToString();
                    }
                    if (dt.Rows[n]["PhoneNum"] != null && dt.Rows[n]["PhoneNum"].ToString() != "")
                    {
                        model.PhoneNum = dt.Rows[n]["PhoneNum"].ToString();
                    }
                    if (dt.Rows[n]["Gender"] != null && dt.Rows[n]["Gender"].ToString() != "")
                    {
                        model.Gender = int.Parse(dt.Rows[n]["Gender"].ToString());
                    }
                    if (dt.Rows[n]["QQnumer"] != null && dt.Rows[n]["QQnumer"].ToString() != "")
                    {
                        model.QQnumer = dt.Rows[n]["QQnumer"].ToString();
                    }
                    if (dt.Rows[n]["User001"] != null && dt.Rows[n]["User001"].ToString() != "")
                    {
                        model.User001 = int.Parse(dt.Rows[n]["User001"].ToString());
                    }
                    if (dt.Rows[n]["User002"] != null && dt.Rows[n]["User002"].ToString() != "")
                    {
                        model.User002 = long.Parse(dt.Rows[n]["User002"].ToString());
                    }
                    if (dt.Rows[n]["User003"] != null && dt.Rows[n]["User003"].ToString() != "")
                    {
                        model.User003 = int.Parse(dt.Rows[n]["User003"].ToString());
                    }
                    if (dt.Rows[n]["User004"] != null && dt.Rows[n]["User004"].ToString() != "")
                    {
                        model.User004 = int.Parse(dt.Rows[n]["User004"].ToString());
                    }
                    if (dt.Rows[n]["User005"] != null && dt.Rows[n]["User005"].ToString() != "")
                    {
                        model.User005 = dt.Rows[n]["User005"].ToString();
                    }
                    if (dt.Rows[n]["User006"] != null && dt.Rows[n]["User006"].ToString() != "")
                    {
                        model.User006 = dt.Rows[n]["User006"].ToString();
                    }
                    if (dt.Rows[n]["User007"] != null && dt.Rows[n]["User007"].ToString() != "")
                    {
                        model.User007 = dt.Rows[n]["User007"].ToString();
                    }
                    if (dt.Rows[n]["User008"] != null && dt.Rows[n]["User008"].ToString() != "")
                    {
                        model.User008 = dt.Rows[n]["User008"].ToString();
                    }
                    if (dt.Rows[n]["User009"] != null && dt.Rows[n]["User009"].ToString() != "")
                    {
                        model.User009 = dt.Rows[n]["User009"].ToString();
                    }
                    if (dt.Rows[n]["User010"] != null && dt.Rows[n]["User010"].ToString() != "")
                    {
                        model.User010 = dt.Rows[n]["User010"].ToString();
                    }
                    if (dt.Rows[n]["User011"] != null && dt.Rows[n]["User011"].ToString() != "")
                    {
                        model.User011 = decimal.Parse(dt.Rows[n]["User011"].ToString());
                    }
                    if (dt.Rows[n]["User012"] != null && dt.Rows[n]["User012"].ToString() != "")
                    {
                        model.User012 = decimal.Parse(dt.Rows[n]["User012"].ToString());
                    }
                    if (dt.Rows[n]["User013"] != null && dt.Rows[n]["User013"].ToString() != "")
                    {
                        model.User013 = decimal.Parse(dt.Rows[n]["User013"].ToString());
                    }
                    if (dt.Rows[n]["User014"] != null && dt.Rows[n]["User014"].ToString() != "")
                    {
                        model.User014 = decimal.Parse(dt.Rows[n]["User014"].ToString());
                    }
                    if (dt.Rows[n]["User015"] != null && dt.Rows[n]["User015"].ToString() != "")
                    {
                        model.User015 = decimal.Parse(dt.Rows[n]["User015"].ToString());
                    }
                    if (dt.Rows[n]["User016"] != null && dt.Rows[n]["User016"].ToString() != "")
                    {
                        model.User016 = decimal.Parse(dt.Rows[n]["User016"].ToString());
                    }
                    if (dt.Rows[n]["User017"] != null && dt.Rows[n]["User017"].ToString() != "")
                    {
                        model.User017 = decimal.Parse(dt.Rows[n]["User017"].ToString());
                    }
                    if (dt.Rows[n]["User018"] != null && dt.Rows[n]["User018"].ToString() != "")
                    {
                        model.User018 = decimal.Parse(dt.Rows[n]["User018"].ToString());
                    }
                    if (dt.Rows[n]["IsOut"] != null && dt.Rows[n]["IsOut"].ToString() != "")
                    {
                        model.IsOut = int.Parse(dt.Rows[n]["IsOut"].ToString());
                    }
                    if (dt.Rows[n]["Batch"] != null && dt.Rows[n]["Batch"].ToString() != "")
                    {
                        model.Batch = int.Parse(dt.Rows[n]["Batch"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        } 
        #endregion

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// 判断给定的会员是否已开通
        /// </summary>
        public bool ExistsIsOpend(long UserID)
        {
            return dal.ExistsIsOpend(UserID);
        }
        /// <summary>
        /// 判断给定的父节点和区域是否已有开通的会员
        /// </summary>
        /// <param name="iParentID"></param>
        /// <param name="iLoc"></param>
        /// <returns></returns>
        public bool FlagLoc(long iParentID, int iLoc)
        {
            return dal.FlagLoc(iParentID, iLoc);
        }
        /// <summary>
        /// 获取已开通的父接点
        /// </summary>
        /// <returns></returns>
        public long GetParentID(long iUserID)
        {
            return dal.GetParentID(iUserID);
        }

        /// <summary>
        /// 根据用户ID获取用户编号
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string GetUserCodeByUserID(long iUserID)
        {
            return dal.GetUserCodeByUserID(iUserID);
        }

        /// <summary>
        /// 判断给定的推荐人和安置人是否在同一条线上。
        /// </summary>
        /// <param name="iRecommendID">给定的推荐人</param>
        /// <param name="iUserID">给定的会员</param>
        /// <returns></returns>
        public bool OnRecommendSameLine(long iRecommendID, long iUserID)
        {
            return dal.OnRecommendSameLine(iRecommendID, iUserID);
        }
        /// <summary>
        /// 查询语句
        /// </summary>
        /// <param name="pTable"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet getData_Chaxun(string pTable, string strWhere)
        {
            return dal.getData_Chaxun(pTable, strWhere);
        }
        /// <summary>
        ///  更新现金数据
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int UpdataData_Chaxun(string sql, string UserID)
        {
            return dal.UpdataData_Chaxun(sql, UserID);
        }

        /// <summary>
        /// 存储过程
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList_Excel(int Userid, string pTable)
        {

            return dal.GetList_Excel(Userid, pTable);
        }
        #endregion  Method
    }
}

