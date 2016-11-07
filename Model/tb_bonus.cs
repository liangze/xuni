using System;
namespace lgk.Model
{
    /// <summary>
    /// tb_bonus:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_bonus
    {
        public tb_bonus()
        { }
        #region Model
        /// <summary>
        /// ID
        /// </summary>		
        private long _id;
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>		
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// TypeID
        /// </summary>		
        private int _typeid;
        public int TypeID
        {
            get { return _typeid; }
            set { _typeid = value; }
        }
        /// <summary>
        /// Amount
        /// </summary>		
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// Revenue
        /// </summary>		
        private decimal _revenue;
        public decimal Revenue
        {
            get { return _revenue; }
            set { _revenue = value; }
        }
        /// <summary>
        /// sf
        /// </summary>		
        private decimal _sf;
        public decimal sf
        {
            get { return _sf; }
            set { _sf = value; }
        }
        /// <summary>
        /// AddTime
        /// </summary>		
        private DateTime _addtime;
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// IsSettled
        /// </summary>		
        private int _issettled;
        public int IsSettled
        {
            get { return _issettled; }
            set { _issettled = value; }
        }
        /// <summary>
        /// Source
        /// </summary>		
        private string _source;
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }
        /// <summary>
        /// SourceEn
        /// </summary>		
        private string _sourceen;
        public string SourceEn
        {
            get { return _sourceen; }
            set { _sourceen = value; }
        }
        /// <summary>
        /// SttleTime
        /// </summary>		
        private DateTime _sttletime;
        public DateTime SttleTime
        {
            get { return _sttletime; }
            set { _sttletime = value; }
        }
        /// <summary>
        /// FromUserID
        /// </summary>		
        private long _fromuserid;
        public long FromUserID
        {
            get { return _fromuserid; }
            set { _fromuserid = value; }
        }
        /// <summary>
        /// Bonus001
        /// </summary>		
        private int _bonus001;
        public int Bonus001
        {
            get { return _bonus001; }
            set { _bonus001 = value; }
        }
        /// <summary>
        /// Bonus002
        /// </summary>		
        private int _bonus002;
        public int Bonus002
        {
            get { return _bonus002; }
            set { _bonus002 = value; }
        }
        /// <summary>
        /// Bonus003
        /// </summary>		
        private string _bonus003;
        public string Bonus003
        {
            get { return _bonus003; }
            set { _bonus003 = value; }
        }
        /// <summary>
        /// Bonus004
        /// </summary>		
        private string _bonus004;
        public string Bonus004
        {
            get { return _bonus004; }
            set { _bonus004 = value; }
        }
        /// <summary>
        /// Bonus005
        /// </summary>		
        private decimal _bonus005;
        public decimal Bonus005
        {
            get { return _bonus005; }
            set { _bonus005 = value; }
        }
        /// <summary>
        /// Bonus006
        /// </summary>		
        private decimal _bonus006;
        public decimal Bonus006
        {
            get { return _bonus006; }
            set { _bonus006 = value; }
        }
        /// <summary>
        /// Bonus007
        /// </summary>		
        private DateTime _bonus007;
        public DateTime Bonus007
        {
            get { return _bonus007; }
            set { _bonus007 = value; }
        }
        /// <summary>
        /// 获奖批次
        /// </summary>		
        private int _batch;
        public int Batch
        {
            get { return _batch; }
            set { _batch = value; }
        }



        #endregion Model

    }
}

