using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_bonus
	/// </summary>
	public partial class tb_bonus
	{
		private readonly lgk.DAL.tb_bonus dal=new lgk.DAL.tb_bonus();
		public tb_bonus()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			return dal.Exists(ID);
		}
              /// <summary>
        /// 导出用户奖金信息专用
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListByUser(string strWhere)
        {
            return dal.GetListByUser(strWhere);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.tb_bonus model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_bonus model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ID)
		{
			
			return dal.Delete(ID);
		}

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(string whereCondition)
        {
            return dal.Delete(whereCondition);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

        /// <summary>
        /// 删除综合服务费(清零)
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public bool DeleteRevenue(string whereCondition)
        {
            return dal.DeleteRevenue(whereCondition);
        }

        /// <summary>
        /// 删除重复消费(清零)
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public bool DeleteBonus006(string whereCondition)
        {
            return dal.DeleteBonus006(whereCondition);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_bonus GetModel(long ID)
		{
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 执行给定的存储过程。
        /// </summary>
        /// <param name="strProcName">给定的存储过程</param>
        /// <returns></returns>
        public int ExecProcedure(string strProcName)
        {
            return dal.ExecProcedure(strProcName);
        }

        /// <summary>
        /// 结算购物奖
        /// </summary>
        /// <param name="iUserID">购买者ID</param>
        /// <param name="dMoney">购买金额</param>
        /// <returns></returns>
        public int ShoppingAward(long iUserID, decimal dMoney)
        {
            return dal.ShoppingAward(iUserID, dMoney);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_bonus> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 计算总奖金
        /// </summary>
        public decimal CountAmount(string strWhere)
        {
            return dal.CountAmount(strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_bonus> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_bonus> modelList = new List<lgk.Model.tb_bonus>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_bonus model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_bonus();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=long.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["TypeID"]!=null && dt.Rows[n]["TypeID"].ToString()!="")
					{
						model.TypeID=int.Parse(dt.Rows[n]["TypeID"].ToString());
					}
					if(dt.Rows[n]["Amount"]!=null && dt.Rows[n]["Amount"].ToString()!="")
					{
						model.Amount=decimal.Parse(dt.Rows[n]["Amount"].ToString());
					}
					if(dt.Rows[n]["AddTime"]!=null && dt.Rows[n]["AddTime"].ToString()!="")
					{
						model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
					}
					if(dt.Rows[n]["IsSettled"]!=null && dt.Rows[n]["IsSettled"].ToString()!="")
					{
						model.IsSettled=int.Parse(dt.Rows[n]["IsSettled"].ToString());
					}
					if(dt.Rows[n]["Source"]!=null && dt.Rows[n]["Source"].ToString()!="")
					{
					model.Source=dt.Rows[n]["Source"].ToString();
					}
					if(dt.Rows[n]["SttleTime"]!=null && dt.Rows[n]["SttleTime"].ToString()!="")
					{
						model.SttleTime=DateTime.Parse(dt.Rows[n]["SttleTime"].ToString());
					}
					if(dt.Rows[n]["FromUserID"]!=null && dt.Rows[n]["FromUserID"].ToString()!="")
					{
						model.FromUserID=int.Parse(dt.Rows[n]["FromUserID"].ToString());
					}
					if(dt.Rows[n]["Bonus001"]!=null && dt.Rows[n]["Bonus001"].ToString()!="")
					{
						model.Bonus001=int.Parse(dt.Rows[n]["Bonus001"].ToString());
					}
					if(dt.Rows[n]["Bonus002"]!=null && dt.Rows[n]["Bonus002"].ToString()!="")
					{
						model.Bonus002=int.Parse(dt.Rows[n]["Bonus002"].ToString());
					}
					if(dt.Rows[n]["Bonus003"]!=null && dt.Rows[n]["Bonus003"].ToString()!="")
					{
					model.Bonus003=dt.Rows[n]["Bonus003"].ToString();
					}
					if(dt.Rows[n]["Bonus004"]!=null && dt.Rows[n]["Bonus004"].ToString()!="")
					{
					model.Bonus004=dt.Rows[n]["Bonus004"].ToString();
					}
					if(dt.Rows[n]["Bonus005"]!=null && dt.Rows[n]["Bonus005"].ToString()!="")
					{
						model.Bonus005=decimal.Parse(dt.Rows[n]["Bonus005"].ToString());
					}
					if(dt.Rows[n]["Bonus006"]!=null && dt.Rows[n]["Bonus006"].ToString()!="")
					{
						model.Bonus006=decimal.Parse(dt.Rows[n]["Bonus006"].ToString());
					}
					if(dt.Rows[n]["Bonus007"]!=null && dt.Rows[n]["Bonus007"].ToString()!="")
					{
						model.Bonus007=DateTime.Parse(dt.Rows[n]["Bonus007"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

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

		#endregion  Method
	}
}

