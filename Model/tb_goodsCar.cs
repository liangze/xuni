using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
 
    /// <summary>
    /// tb_goods:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_goodsCar
    {
        public tb_goodsCar()
        { }
        #region Model
        private int _id;
        private string _goodscode;
        private string _goodsname;

        private decimal _price;
        private decimal _realityprice;
        private decimal _ShopPrice;

        private int _typeid;
        private int _goodstype;
        private string _pic1;
        private string _gColor;
        private string _gSize;

        private string _remarks;

        private DateTime _addtime;
       
        private int _goods002;
        private decimal _goods005;


        public decimal ShopPrice
        {
            get { return _ShopPrice; }
            set { _ShopPrice = value; }
        }

        public decimal Goods005
        {
            get { return _goods005; }
            set { _goods005 = value; }
        }
        private int _goods006;

        private int _goodsID;

        public int GoodsID
        {
            get { return _goodsID; }
            set { _goodsID = value; }
        }

         private string _typeIDName;

         public string TypeIDName
         {
             get { return _typeIDName; }
             set { _typeIDName = value; }
         }

         private string _goodsTypeName;

         public string GoodsTypeName
         {
             get { return _goodsTypeName; }
             set { _goodsTypeName = value; }
         }

         private decimal _totalMoney;

         public decimal TotalMoney
         {
             get { return _totalMoney; }
             set { _totalMoney = value; }
         }

         private int _totalGoods006;

         public int TotalGoods006
         {
             get { return _totalGoods006; }
             set { _totalGoods006 = value; }
         }
    


        private long _buyUser;//上传用户

        public long BuyUser
        {
            get { return _buyUser; }
            set { _buyUser = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsCode
        {
            set { _goodscode = value; }
            get { return _goodscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsName
        {
            set { _goodsname = value; }
            get { return _goodsname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RealityPrice
        {
            set { _realityprice = value; }
            get { return _realityprice; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GoodsType
        {
            set { _goodstype = value; }
            get { return _goodstype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pic1
        {
            set { _pic1 = value; }
            get { return _pic1; }
        }
     

        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
  
        /// <summary>
        /// 
        /// </summary>
        public int Goods002
        {
            set { _goods002 = value; }
            get { return _goods002; }
        }
   
     
        /// <summary>
        /// 
        /// </summary>
        public int Goods006
        {
            set { _goods006 = value; }
            get { return _goods006; }
        }
        public string gColor
        {
            set { _gColor = value; }
            get { return _gColor; }
        }
        public string gSize
        {
            set { _gSize = value; }
            get { return _gSize; }
        }
        #endregion Model

    }
}
