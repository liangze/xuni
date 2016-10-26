using System;
namespace lgk.Model
{
    /// <summary>
    /// tb_Order:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_Order
    {
        public tb_Order()
        { }
        #region Model
        private long _orderid;
        private long _userid;
        private string _ordercode;
        private string _useraddr;
        private int _ordersum;
        private decimal _ordertotal;
        private decimal _pvtotal;
        private DateTime _orderdate;
        private int _issend;
        private int _paymethod;
        private int? _ordertype;
        private decimal? _order1;
        private decimal? _order2;
        private string _order3;
        private string _order4;
        private string _order5;
        private string _order6;
        private string _order7;
        private int _isdel;
        /// <summary>
        /// 
        /// </summary>
        public long OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderCode
        {
            set { _ordercode = value; }
            get { return _ordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserAddr
        {
            set { _useraddr = value; }
            get { return _useraddr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderSum
        {
            set { _ordersum = value; }
            get { return _ordersum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OrderTotal
        {
            set { _ordertotal = value; }
            get { return _ordertotal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PVTotal
        {
            set { _pvtotal = value; }
            get { return _pvtotal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 0、未付款1、待发货2、已发货3、已完成
        /// </summary>
        public int IsSend
        {
            set { _issend = value; }
            get { return _issend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PayMethod
        {
            set { _paymethod = value; }
            get { return _paymethod; }
        }
        /// <summary>
        /// 支付类型0、积分 1、E币 2、奖金币
        /// </summary>
        public int? OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Order1
        {
            set { _order1 = value; }
            get { return _order1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Order2
        {
            set { _order2 = value; }
            get { return _order2; }
        }
        /// <summary>
        /// 快递公司
        /// </summary>
        public string Order3
        {
            set { _order3 = value; }
            get { return _order3; }
        }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string Order4
        {
            set { _order4 = value; }
            get { return _order4; }
        }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string Order5
        {
            set { _order5 = value; }
            get { return _order5; }
        }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string Order6
        {
            set { _order6 = value; }
            get { return _order6; }
        }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string Order7
        {
            set { _order7 = value; }
            get { return _order7; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        private DateTime? _senddate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SendDate
        {
            set { _senddate = value; }
            get { return _senddate; }
        }
        private int _typeID;
        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }
        private string _pareTopChild;
        public string PareTopChild
        {
            get { return _pareTopChild; }
            set { _pareTopChild = value; }
        }
        #endregion Model

    }
}

