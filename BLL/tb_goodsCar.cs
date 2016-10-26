using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lgk.Model;
using System.Data;

namespace lgk.BLL
{
    /// <summary>
    /// tb_goodsCar
    /// </summary>
    public partial class tb_goodsCar
    {
        private readonly lgk.DAL.tb_goodsCar dal = new lgk.DAL.tb_goodsCar();
        public tb_goodsCar()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_goodsCar model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_goodsCar model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_goodsCar GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        public lgk.Model.tb_goodsCar GetModel(string where)
        {
            return dal.GetModel(where);
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
        public DataSet GetList(string strWhere, int level)
        {
            return dal.GetList(strWhere, level);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_goodsCar> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_goodsCar> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_goodsCar> modelList = new List<lgk.Model.tb_goodsCar>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_goodsCar model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_goodsCar();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.GoodsTypeName = dt.Rows[n]["GoodsTypeName"].ToString();
                    model.Pic1 = dt.Rows[n]["Pic1"].ToString();
                    model.Remarks = dt.Rows[n]["Remarks"].ToString();
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["Goods002"].ToString() != "")
                    {
                        model.Goods002 = int.Parse(dt.Rows[n]["Goods002"].ToString());
                    }
                    if (dt.Rows[n]["Goods005"].ToString() != "")
                    {
                        model.Goods005 = decimal.Parse(dt.Rows[n]["Goods005"].ToString());
                    }
                    if (dt.Rows[n]["Goods006"].ToString() != "")
                    {
                        model.Goods006 = int.Parse(dt.Rows[n]["Goods006"].ToString());
                    }
                    if (dt.Rows[n]["BuyUser"].ToString() != "")
                    {
                        model.BuyUser = long.Parse(dt.Rows[n]["BuyUser"].ToString());
                    }
                    if (dt.Rows[n]["TotalMoney"].ToString() != "")
                    {
                        model.TotalMoney = decimal.Parse(dt.Rows[n]["TotalMoney"].ToString());
                    }
                    if (dt.Rows[n]["TotalGoods006"].ToString() != "")
                    {
                        model.TotalGoods006 = int.Parse(dt.Rows[n]["TotalGoods006"].ToString());
                    }
                    if (dt.Rows[n]["GoodsID"].ToString() != "")
                    {
                        model.GoodsID = int.Parse(dt.Rows[n]["GoodsID"].ToString());
                    }
                    if (dt.Rows[n]["ShopPrice"].ToString() != "")
                    {
                        model.ShopPrice = decimal.Parse(dt.Rows[n]["ShopPrice"].ToString());
                    }
                    model.GoodsCode = dt.Rows[n]["GoodsCode"].ToString();
                    model.GoodsName = dt.Rows[n]["GoodsName"].ToString();
                    if (dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["RealityPrice"].ToString() != "")
                    {
                        model.RealityPrice = decimal.Parse(dt.Rows[n]["RealityPrice"].ToString());
                    }
                    if (dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = int.Parse(dt.Rows[n]["TypeID"].ToString());
                    }
                    model.TypeIDName = dt.Rows[n]["TypeIDName"].ToString();
                    if (dt.Rows[n]["GoodsType"].ToString() != "")
                    {
                        model.GoodsType = int.Parse(dt.Rows[n]["GoodsType"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion  Method
    }
}
