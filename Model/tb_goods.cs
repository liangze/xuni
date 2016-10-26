using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_goods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_goods
	{
		public tb_goods()
		{}
		#region Model
		private int _id;
		private string _goodscode;
		private string _goodsname;
        private string _goodsname_en;
		private decimal _price;
		private decimal _realityprice;
        private decimal _ShopPrice;
		private string _standard;
		private int _ishave;
		private int _typeid;
		private int _goodstype;
		private string _pic1;
		private string _pic2;
		private string _pic3;
		private string _pic4;
		private string _pic5;
		private string _summary;
		private string _remarks;
        private string _remarks_en;
		private DateTime _addtime;
		private int _goods001;
		private int _goods002;
		private string _goods003;
		private string _goods004;
		private decimal? _goods005;
		private decimal? _goods006;
		private DateTime? _goods007;
		private DateTime? _goods008;
        private int _uploadUser;//上传用户
        private int _stateType;//审核状态
        private string _czCard;//充值卡号
        private string _czPwd;//充值密码
        private string _typeIDName;//一级名称
        private string _city;
        private string _usercode;


 /// <summary>
 /// 本站价
 /// </summary>
        public decimal ShopPrice
        {
            get { return _ShopPrice; }
            set { _ShopPrice = value; }
        }
        /// <summary>
        /// 推荐会员编号
        /// </summary>
        public string UserCode
        {
            set { _usercode = value; }
            get { return _usercode; }
        }


        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string TypeIDName
        {
            get { return _typeIDName; }
            set { _typeIDName = value; }
        }
        private string _goodsTypeName;//二级名称

        public string GoodsTypeName
        {
            get { return _goodsTypeName; }
            set { _goodsTypeName = value; }
        }

        public string CzPwd
        {
            get { return _czPwd; }
            set { _czPwd = value; }
        }
     

        public string CzCard
        {
            get { return _czCard; }
            set { _czCard = value; }
        }
       
        public int StateType
        {
            get { return _stateType; }
            set { _stateType = value; }
        }

        public int UploadUser
        {
            get { return _uploadUser; }
            set { _uploadUser = value; }
        }
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
		public string GoodsCode
		{
			set{ _goodscode=value;}
			get{return _goodscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GoodsName
		{
			set{ _goodsname=value;}
			get{return _goodsname;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string GoodsName_en
        {
            set { _goodsname_en = value; }
            get { return _goodsname_en; }
        }
		/// <summary>
		/// 
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal RealityPrice
		{
			set{ _realityprice=value;}
			get{return _realityprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Standard
		{
			set{ _standard=value;}
			get{return _standard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsHave
		{
			set{ _ishave=value;}
			get{return _ishave;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TypeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GoodsType
		{
			set{ _goodstype=value;}
			get{return _goodstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pic1
		{
			set{ _pic1=value;}
			get{return _pic1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pic2
		{
			set{ _pic2=value;}
			get{return _pic2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pic3
		{
			set{ _pic3=value;}
			get{return _pic3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pic4
		{
			set{ _pic4=value;}
			get{return _pic4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pic5
		{
			set{ _pic5=value;}
			get{return _pic5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Summary
		{
			set{ _summary=value;}
			get{return _summary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string Remarks_en
        {
            set { _remarks_en = value; }
            get { return _remarks_en; }
        }
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Goods001
		{
			set{ _goods001=value;}
			get{return _goods001;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Goods002
		{
			set{ _goods002=value;}
			get{return _goods002;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Goods003
		{
			set{ _goods003=value;}
			get{return _goods003;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Goods004
		{
			set{ _goods004=value;}
			get{return _goods004;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Goods005
		{
			set{ _goods005=value;}
			get{return _goods005;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Goods006
		{
			set{ _goods006=value;}
			get{return _goods006;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Goods007
		{
			set{ _goods007=value;}
			get{return _goods007;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Goods008
		{
			set{ _goods008=value;}
			get{return _goods008;}
		}
		#endregion Model

	}
}

