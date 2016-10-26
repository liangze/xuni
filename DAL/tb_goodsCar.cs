using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
using System.Data;
namespace lgk.DAL
{
  
    /// <summary>
    /// 数据访问类:tb_goodsCar
    /// </summary>
    public partial class tb_goodsCar
    {
        public tb_goodsCar()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "tb_goodsCar");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_goodsCar");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
         };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_goodsCar model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_goodsCar(");
            strSql.Append("GoodsID,GoodsCode,GoodsName,Price,RealityPrice,TypeID,TypeIDName,GoodsType,GoodsTypeName,Pic1,Remarks,AddTime,Goods002,Goods005,Goods006,BuyUser,TotalMoney,TotalGoods006,ShopPrice,gColor,gSize)");
            strSql.Append(" values (");
            strSql.Append("@GoodsID,@GoodsCode,@GoodsName,@Price,@RealityPrice,@TypeID,@TypeIDName,@GoodsType,@GoodsTypeName,@Pic1,@Remarks,@AddTime,@Goods002,@Goods005,@Goods006,@BuyUser,@TotalMoney,@TotalGoods006,@ShopPrice,@gColor,@gSize)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsID", SqlDbType.Int),
					new SqlParameter("@GoodsCode", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsName", SqlDbType.VarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@RealityPrice", SqlDbType.Decimal,9),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
                    new SqlParameter("@TypeIDName", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsType", SqlDbType.Int,4),
                    new SqlParameter("@GoodsTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@Pic1", SqlDbType.VarChar,100),
					new SqlParameter("@Remarks", SqlDbType.Text),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Goods002", SqlDbType.Int,4),
					new SqlParameter("@Goods005", SqlDbType.Decimal,9),
					new SqlParameter("@Goods006", SqlDbType.Int),
                    new SqlParameter("@BuyUser", SqlDbType.BigInt,8),
                    new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@TotalGoods006", SqlDbType.Int),
                   new SqlParameter("@ShopPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@gColor", SqlDbType.VarChar),
                   new SqlParameter("@gSize", SqlDbType.VarChar)
                                };
            parameters[0].Value = model.GoodsID;
            parameters[1].Value = model.GoodsCode;
            parameters[2].Value = model.GoodsName;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.RealityPrice;
            parameters[5].Value = model.TypeID;
            parameters[6].Value = model.TypeIDName;
            parameters[7].Value = model.GoodsType;
            parameters[8].Value = model.GoodsTypeName;
            parameters[9].Value = model.Pic1;
            parameters[10].Value = model.Remarks;
            parameters[11].Value = model.AddTime;
            parameters[12].Value = model.Goods002;
            parameters[13].Value = model.Goods005;
            parameters[14].Value = model.Goods006;
            parameters[15].Value = model.BuyUser;
            parameters[16].Value = model.TotalMoney;
            parameters[17].Value = model.TotalGoods006;
            parameters[18].Value = model.ShopPrice;
            parameters[19].Value = model.gColor;
            parameters[20].Value = model.gSize;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(lgk.Model.tb_goodsCar model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goodsCar set ");
            strSql.Append("GoodsID=@GoodsID,");
            strSql.Append("GoodsCode=@GoodsCode,");
            strSql.Append("GoodsName=@GoodsName,");
            strSql.Append("Price=@Price,");
            strSql.Append("RealityPrice=@RealityPrice,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("TypeIDName=@TypeIDName,");
            strSql.Append("GoodsType=@GoodsType,");
            strSql.Append("GoodsTypeName=@GoodsTypeName,");
            strSql.Append("Pic1=@Pic1,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Goods002=@Goods002,");
            strSql.Append("Goods005=@Goods005,");
            strSql.Append("Goods006=@Goods006,");
            strSql.Append("BuyUser=@BuyUser,");
            strSql.Append("TotalMoney=@TotalMoney,");
            strSql.Append("TotalGoods006=@TotalGoods006,");
            strSql.Append("ShopPrice=@ShopPrice,");
            strSql.Append("gColor=@gColor,");
            strSql.Append("gSize=@gSize");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsID", SqlDbType.Int),
					new SqlParameter("@GoodsCode", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsName", SqlDbType.VarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@RealityPrice", SqlDbType.Decimal,9),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
                    new SqlParameter("@TypeIDName", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsType", SqlDbType.Int,4),
                    new SqlParameter("@GoodsTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@Pic1", SqlDbType.VarChar,100),
					new SqlParameter("@Remarks", SqlDbType.Text),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Goods002", SqlDbType.Int,4),
					new SqlParameter("@Goods005", SqlDbType.Decimal,9),
					new SqlParameter("@Goods006", SqlDbType.Int),
                    new SqlParameter("@BuyUser", SqlDbType.BigInt,8),
                    new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@TotalGoods006", SqlDbType.Int),
                     new SqlParameter("@ID", SqlDbType.Int),
                    new SqlParameter("@ShopPrice", SqlDbType.Decimal,9),
                   new SqlParameter("@gColor", SqlDbType.VarChar),
                   new SqlParameter("@gSize", SqlDbType.VarChar)
                };
            parameters[0].Value = model.GoodsID;
            parameters[1].Value = model.GoodsCode;
            parameters[2].Value = model.GoodsName;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.RealityPrice;
            parameters[5].Value = model.TypeID;
            parameters[6].Value = model.TypeIDName;
            parameters[7].Value = model.GoodsType;
            parameters[8].Value = model.GoodsTypeName;
            parameters[9].Value = model.Pic1;
            parameters[10].Value = model.Remarks;
            parameters[11].Value = model.AddTime;
            parameters[12].Value = model.Goods002;
            parameters[13].Value = model.Goods005;
            parameters[14].Value = model.Goods006;
            parameters[15].Value = model.BuyUser;
            parameters[16].Value = model.TotalMoney;
            parameters[17].Value = model.TotalGoods006;
            parameters[18].Value = model.ID;
            parameters[19].Value = model.ShopPrice;
            parameters[20].Value = model.gColor;
            parameters[21].Value = model.gSize;

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
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goodsCar ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goodsCar ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public lgk.Model.tb_goodsCar GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_goodsCar ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int, 4) };
            parameters[0].Value = ID;

            lgk.Model.tb_goodsCar model = new lgk.Model.tb_goodsCar();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodsID"] != null && ds.Tables[0].Rows[0]["GoodsID"].ToString() != "")
                {
                    model.GoodsID = int.Parse(ds.Tables[0].Rows[0]["GoodsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodsCode"] != null && ds.Tables[0].Rows[0]["GoodsCode"].ToString() != "")
                {
                    model.GoodsCode = ds.Tables[0].Rows[0]["GoodsCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["GoodsName"] != null && ds.Tables[0].Rows[0]["GoodsName"].ToString() != "")
                {
                    model.GoodsName = ds.Tables[0].Rows[0]["GoodsName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RealityPrice"] != null && ds.Tables[0].Rows[0]["RealityPrice"].ToString() != "")
                {
                    model.RealityPrice = decimal.Parse(ds.Tables[0].Rows[0]["RealityPrice"].ToString());
                }

                if (ds.Tables[0].Rows[0]["TypeID"] != null && ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }

                if (ds.Tables[0].Rows[0]["TypeIDName"] != null && ds.Tables[0].Rows[0]["TypeIDName"].ToString() != "")
                {
                    model.TypeIDName = ds.Tables[0].Rows[0]["TypeIDName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["GoodsType"] != null && ds.Tables[0].Rows[0]["GoodsType"].ToString() != "")
                {
                    model.GoodsType = int.Parse(ds.Tables[0].Rows[0]["GoodsType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodsTypeName"] != null && ds.Tables[0].Rows[0]["GoodsTypeName"].ToString() != "")
                {
                    model.GoodsTypeName = ds.Tables[0].Rows[0]["GoodsTypeName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Pic1"] != null && ds.Tables[0].Rows[0]["Pic1"].ToString() != "")
                {
                    model.Pic1 = ds.Tables[0].Rows[0]["Pic1"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Remarks"] != null && ds.Tables[0].Rows[0]["Remarks"].ToString() != "")
                {
                    model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }

                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
               
                if (ds.Tables[0].Rows[0]["Goods002"] != null && ds.Tables[0].Rows[0]["Goods002"].ToString() != "")
                {
                    model.Goods002 = int.Parse(ds.Tables[0].Rows[0]["Goods002"].ToString());
                }
             
                if (ds.Tables[0].Rows[0]["Goods005"] != null && ds.Tables[0].Rows[0]["Goods005"].ToString() != "")
                {
                    model.Goods005 = decimal.Parse(ds.Tables[0].Rows[0]["Goods005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods006"] != null && ds.Tables[0].Rows[0]["Goods006"].ToString() != "")
                {
                    model.Goods006 = int.Parse(ds.Tables[0].Rows[0]["Goods006"].ToString());
                }

                if (ds.Tables[0].Rows[0]["BuyUser"] != null && ds.Tables[0].Rows[0]["BuyUser"].ToString() != "")
                {
                    model.BuyUser = Convert.ToInt64(ds.Tables[0].Rows[0]["BuyUser"].ToString());
                }

                if (ds.Tables[0].Rows[0]["TotalMoney"] != null && ds.Tables[0].Rows[0]["TotalMoney"].ToString() != "")
                {
                    model.TotalMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalGoods006"] != null && ds.Tables[0].Rows[0]["TotalGoods006"].ToString() != "")
                {
                    model.TotalGoods006 = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalGoods006"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShopPrice"] != null && ds.Tables[0].Rows[0]["ShopPrice"].ToString() != "")
                {
                    model.ShopPrice = decimal.Parse(ds.Tables[0].Rows[0]["ShopPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gSize"] != null && ds.Tables[0].Rows[0]["gSize"].ToString() != "")
                {
                    model.gSize = ds.Tables[0].Rows[0]["gSize"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gColor"] != null && ds.Tables[0].Rows[0]["gColor"].ToString() != "")
                {
                    model.gColor = ds.Tables[0].Rows[0]["gColor"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据条件得到一个对象实体
        /// </summary>
        public lgk.Model.tb_goodsCar GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from tb_goodsCar ");
            strSql.Append(" where " + where);

            lgk.Model.tb_goodsCar model = new lgk.Model.tb_goodsCar();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodsID"] != null && ds.Tables[0].Rows[0]["GoodsID"].ToString() != "")
                {
                    model.GoodsID = int.Parse(ds.Tables[0].Rows[0]["GoodsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodsCode"] != null && ds.Tables[0].Rows[0]["GoodsCode"].ToString() != "")
                {
                    model.GoodsCode = ds.Tables[0].Rows[0]["GoodsCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["GoodsName"] != null && ds.Tables[0].Rows[0]["GoodsName"].ToString() != "")
                {
                    model.GoodsName = ds.Tables[0].Rows[0]["GoodsName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RealityPrice"] != null && ds.Tables[0].Rows[0]["RealityPrice"].ToString() != "")
                {
                    model.RealityPrice = decimal.Parse(ds.Tables[0].Rows[0]["RealityPrice"].ToString());
                }

                if (ds.Tables[0].Rows[0]["TypeID"] != null && ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }

                if (ds.Tables[0].Rows[0]["TypeIDName"] != null && ds.Tables[0].Rows[0]["TypeIDName"].ToString() != "")
                {
                    model.TypeIDName = ds.Tables[0].Rows[0]["TypeIDName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["GoodsType"] != null && ds.Tables[0].Rows[0]["GoodsType"].ToString() != "")
                {
                    model.GoodsType = int.Parse(ds.Tables[0].Rows[0]["GoodsType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodsTypeName"] != null && ds.Tables[0].Rows[0]["GoodsTypeName"].ToString() != "")
                {
                    model.GoodsTypeName = ds.Tables[0].Rows[0]["GoodsTypeName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Pic1"] != null && ds.Tables[0].Rows[0]["Pic1"].ToString() != "")
                {
                    model.Pic1 = ds.Tables[0].Rows[0]["Pic1"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Remarks"] != null && ds.Tables[0].Rows[0]["Remarks"].ToString() != "")
                {
                    model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }

                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }

                if (ds.Tables[0].Rows[0]["Goods002"] != null && ds.Tables[0].Rows[0]["Goods002"].ToString() != "")
                {
                    model.Goods002 = int.Parse(ds.Tables[0].Rows[0]["Goods002"].ToString());
                }

                if (ds.Tables[0].Rows[0]["Goods005"] != null && ds.Tables[0].Rows[0]["Goods005"].ToString() != "")
                {
                    model.Goods005 = decimal.Parse(ds.Tables[0].Rows[0]["Goods005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods006"] != null && ds.Tables[0].Rows[0]["Goods006"].ToString() != "")
                {
                    model.Goods006 = int.Parse(ds.Tables[0].Rows[0]["Goods006"].ToString());
                }

                if (ds.Tables[0].Rows[0]["BuyUser"] != null && ds.Tables[0].Rows[0]["BuyUser"].ToString() != "")
                {
                    model.BuyUser = Convert.ToInt64(ds.Tables[0].Rows[0]["BuyUser"].ToString());
                }

                if (ds.Tables[0].Rows[0]["TotalMoney"] != null && ds.Tables[0].Rows[0]["TotalMoney"].ToString() != "")
                {
                    model.TotalMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalGoods006"] != null && ds.Tables[0].Rows[0]["TotalGoods006"].ToString() != "")
                {
                    model.TotalGoods006 = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalGoods006"].ToString());
                }

                if (ds.Tables[0].Rows[0]["ShopPrice"] != null && ds.Tables[0].Rows[0]["ShopPrice"].ToString() != "")
                {
                    model.ShopPrice = decimal.Parse(ds.Tables[0].Rows[0]["ShopPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gSize"] != null && ds.Tables[0].Rows[0]["gSize"].ToString() != "")
                {
                    model.gSize = ds.Tables[0].Rows[0]["gSize"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gColor"] != null && ds.Tables[0].Rows[0]["gColor"].ToString() != "")
                {
                    model.gColor = ds.Tables[0].Rows[0]["gColor"].ToString();
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
        public DataSet GetList( string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tb_goodsCar");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, int level)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,GoodsID,GoodsCode,GoodsName,Price,RealityPrice,TypeID,TypeIDName,GoodsType,GoodsTypeName,Pic1,Remarks,AddTime,Goods002,Goods005,Goods006,BuyUser,case when " + level + " >= 1 then Goods006 * RealityPrice else Goods006  * ShopPrice end as [TotalMoney1] ,TotalMoney  ,Goods006 * Goods002 as TotalGoods006,ShopPrice,gColor,gSize from tb_goodsCar");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
