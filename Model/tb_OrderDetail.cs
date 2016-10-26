using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_OrderDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_OrderDetail
	{
		public tb_OrderDetail()
		{}
		#region Model
		private int _id;
		private string _ordercode;
		private int _procudeid;
		private string _procudename;
		private decimal? _price;
		private int? _pv;
		private int _ordersum;
		private decimal? _ordertotal;
		private int? _pvtotal;
		private DateTime _orderdate;
        private string _gColor;
        private string _gSize;
        /// <summary>
        /// 
        /// </summary>
        public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderCode
		{
			set{ _ordercode=value;}
			get{return _ordercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProcudeID
		{
			set{ _procudeid=value;}
			get{return _procudeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProcudeName
		{
			set{ _procudename=value;}
			get{return _procudename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PV
		{
			set{ _pv=value;}
			get{return _pv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderSum
		{
			set{ _ordersum=value;}
			get{return _ordersum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OrderTotal
		{
			set{ _ordertotal=value;}
			get{return _ordertotal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PVTotal
		{
			set{ _pvtotal=value;}
			get{return _pvtotal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime OrderDate
		{
			set{ _orderdate=value;}
			get{return _orderdate;}
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
        private int _procudeTypeID;
        public int ProcudeTypeID
        {
            get { return _procudeTypeID; }
            set { _procudeTypeID = value; }
        }
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        #endregion Model

    }
}

