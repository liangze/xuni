using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_user
	{
		public tb_user()
		{}
		#region Model

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
        /// UserCode
        /// </summary>		
        private string _usercode;
        public string UserCode
        {
            get { return _usercode; }
            set { _usercode = value; }
        }
        /// <summary>
        /// LevelID
        /// </summary>		
        private int _levelid;
        public int LevelID
        {
            get { return _levelid; }
            set { _levelid = value; }
        }
        /// <summary>
        /// RecommendID
        /// </summary>		
        private long _recommendid;
        public long RecommendID
        {
            get { return _recommendid; }
            set { _recommendid = value; }
        }
        /// <summary>
        /// RecommendCode
        /// </summary>		
        private string _recommendcode;
        public string RecommendCode
        {
            get { return _recommendcode; }
            set { _recommendcode = value; }
        }
        /// <summary>
        /// RecommendPath
        /// </summary>		
        private string _recommendpath;
        public string RecommendPath
        {
            get { return _recommendpath; }
            set { _recommendpath = value; }
        }
        /// <summary>
        /// RecommendGenera
        /// </summary>		
        private int _recommendgenera;
        public int RecommendGenera
        {
            get { return _recommendgenera; }
            set { _recommendgenera = value; }
        }
        /// <summary>
        /// ParentID
        /// </summary>		
        private long _parentid;
        public long ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// ParentCode
        /// </summary>		
        private string _parentcode;
        public string ParentCode
        {
            get { return _parentcode; }
            set { _parentcode = value; }
        }
        /// <summary>
        /// UserPath
        /// </summary>		
        private string _userpath;
        public string UserPath
        {
            get { return _userpath; }
            set { _userpath = value; }
        }
        /// <summary>
        /// Layer
        /// </summary>		
        private int _layer;
        public int Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }
        /// <summary>
        /// Location
        /// </summary>		
        private int _location;
        public int Location
        {
            get { return _location; }
            set { _location = value; }
        }
        /// <summary>
        /// IsOpend
        /// </summary>		
        private int _isopend;
        public int IsOpend
        {
            get { return _isopend; }
            set { _isopend = value; }
        }
        /// <summary>
        /// IsLock
        /// </summary>		
        private int _islock;
        public int IsLock
        {
            get { return _islock; }
            set { _islock = value; }
        }
        /// <summary>
        /// IsAgent
        /// </summary>		
        private int _isagent;
        public int IsAgent
        {
            get { return _isagent; }
            set { _isagent = value; }
        }
        /// <summary>
        /// AgentsID
        /// </summary>		
        private long _agentsid;
        public long AgentsID
        {
            get { return _agentsid; }
            set { _agentsid = value; }
        }
        /// <summary>
        /// Emoney
        /// </summary>		
        private decimal _emoney;
        public decimal Emoney
        {
            get { return _emoney; }
            set { _emoney = value; }
        }
        /// <summary>
        /// BonusAccount
        /// </summary>		
        private decimal _bonusaccount;
        public decimal BonusAccount
        {
            get { return _bonusaccount; }
            set { _bonusaccount = value; }
        }
        /// <summary>
        /// AllBonusAccount
        /// </summary>		
        private decimal _allbonusaccount;
        public decimal AllBonusAccount
        {
            get { return _allbonusaccount; }
            set { _allbonusaccount = value; }
        }
        /// <summary>
        /// StockAccount
        /// </summary>		
        private decimal _stockaccount;
        public decimal StockAccount
        {
            get { return _stockaccount; }
            set { _stockaccount = value; }
        }
        /// <summary>
        /// StockMoney
        /// </summary>		
        private decimal _stockmoney;
        public decimal StockMoney
        {
            get { return _stockmoney; }
            set { _stockmoney = value; }
        }
        /// <summary>
        /// User003
        /// </summary>		
        private int _user003;
        public int User003
        {
            get { return _user003; }
            set { _user003 = value; }
        }
        /// <summary>
        /// ShopAccount
        /// </summary>		
        private decimal _shopaccount;
        public decimal ShopAccount
        {
            get { return _shopaccount; }
            set { _shopaccount = value; }
        }
        /// <summary>
        /// RegTime
        /// </summary>		
        private DateTime _regtime;
        public DateTime RegTime
        {
            get { return _regtime; }
            set { _regtime = value; }
        }
        /// <summary>
        /// OpenTime
        /// </summary>		
        private DateTime _opentime;
        public DateTime OpenTime
        {
            get { return _opentime; }
            set { _opentime = value; }
        }
        /// <summary>
        /// RegMoney
        /// </summary>		
        private decimal _regmoney;
        public decimal RegMoney
        {
            get { return _regmoney; }
            set { _regmoney = value; }
        }
        /// <summary>
        /// BillCount
        /// </summary>		
        private int _billcount;
        public int BillCount
        {
            get { return _billcount; }
            set { _billcount = value; }
        }
        /// <summary>
        /// GLmoney
        /// </summary>		
        private decimal _glmoney;
        public decimal GLmoney
        {
            get { return _glmoney; }
            set { _glmoney = value; }
        }
        /// <summary>
        /// AddGLTime
        /// </summary>		
        private DateTime _addgltime;
        public DateTime AddGLTime
        {
            get { return _addgltime; }
            set { _addgltime = value; }
        }
        /// <summary>
        /// Password
        /// </summary>		
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// SecondPassword
        /// </summary>		
        private string _secondpassword;
        public string SecondPassword
        {
            get { return _secondpassword; }
            set { _secondpassword = value; }
        }
        /// <summary>
        /// ThreePassword
        /// </summary>		
        private string _threepassword;
        public string ThreePassword
        {
            get { return _threepassword; }
            set { _threepassword = value; }
        }
        /// <summary>
        /// SafetyCodeQuestion
        /// </summary>		
        private string _safetycodequestion;
        public string SafetyCodeQuestion
        {
            get { return _safetycodequestion; }
            set { _safetycodequestion = value; }
        }
        /// <summary>
        /// SafetyCodeAnswer
        /// </summary>		
        private string _safetycodeanswer;
        public string SafetyCodeAnswer
        {
            get { return _safetycodeanswer; }
            set { _safetycodeanswer = value; }
        }
        /// <summary>
        /// LeftScore
        /// </summary>		
        private decimal _leftscore;
        public decimal LeftScore
        {
            get { return _leftscore; }
            set { _leftscore = value; }
        }
        /// <summary>
        /// CenterScore
        /// </summary>		
        private decimal _centerscore;
        public decimal CenterScore
        {
            get { return _centerscore; }
            set { _centerscore = value; }
        }
        /// <summary>
        /// RightScore
        /// </summary>		
        private decimal _rightscore;
        public decimal RightScore
        {
            get { return _rightscore; }
            set { _rightscore = value; }
        }
        /// <summary>
        /// LeftBalance
        /// </summary>		
        private decimal _leftbalance;
        public decimal LeftBalance
        {
            get { return _leftbalance; }
            set { _leftbalance = value; }
        }
        /// <summary>
        /// CenterBalance
        /// </summary>		
        private decimal _centerbalance;
        public decimal CenterBalance
        {
            get { return _centerbalance; }
            set { _centerbalance = value; }
        }
        /// <summary>
        /// RightBalance
        /// </summary>		
        private decimal _rightbalance;
        public decimal RightBalance
        {
            get { return _rightbalance; }
            set { _rightbalance = value; }
        }
        /// <summary>
        /// LeftNewScore
        /// </summary>		
        private decimal _leftnewscore;
        public decimal LeftNewScore
        {
            get { return _leftnewscore; }
            set { _leftnewscore = value; }
        }
        /// <summary>
        /// CenterNewScore
        /// </summary>		
        private decimal _centernewscore;
        public decimal CenterNewScore
        {
            get { return _centernewscore; }
            set { _centernewscore = value; }
        }
        /// <summary>
        /// RightNewScore
        /// </summary>		
        private decimal _rightnewscore;
        public decimal RightNewScore
        {
            get { return _rightnewscore; }
            set { _rightnewscore = value; }
        }
        /// <summary>
        /// LeftZT
        /// </summary>		
        private decimal _leftzt;
        public decimal LeftZT
        {
            get { return _leftzt; }
            set { _leftzt = value; }
        }
        /// <summary>
        /// CenterZT
        /// </summary>		
        private decimal _centerzt;
        public decimal CenterZT
        {
            get { return _centerzt; }
            set { _centerzt = value; }
        }
        /// <summary>
        /// RightZT
        /// </summary>		
        private decimal _rightzt;
        public decimal RightZT
        {
            get { return _rightzt; }
            set { _rightzt = value; }
        }
        /// <summary>
        /// BankAccount
        /// </summary>		
        private string _bankaccount;
        public string BankAccount
        {
            get { return _bankaccount; }
            set { _bankaccount = value; }
        }
        /// <summary>
        /// BankAccountUser
        /// </summary>		
        private string _bankaccountuser;
        public string BankAccountUser
        {
            get { return _bankaccountuser; }
            set { _bankaccountuser = value; }
        }
        /// <summary>
        /// BankName
        /// </summary>		
        private string _bankname;
        public string BankName
        {
            get { return _bankname; }
            set { _bankname = value; }
        }
        /// <summary>
        /// BankBranch
        /// </summary>		
        private string _bankbranch;
        public string BankBranch
        {
            get { return _bankbranch; }
            set { _bankbranch = value; }
        }
        /// <summary>
        /// BankInProvince
        /// </summary>		
        private string _bankinprovince;
        public string BankInProvince
        {
            get { return _bankinprovince; }
            set { _bankinprovince = value; }
        }
        /// <summary>
        /// BankInCity
        /// </summary>		
        private string _bankincity;
        public string BankInCity
        {
            get { return _bankincity; }
            set { _bankincity = value; }
        }
        /// <summary>
        /// Address
        /// </summary>		
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// TrueName
        /// </summary>		
        private string _truename;
        public string TrueName
        {
            get { return _truename; }
            set { _truename = value; }
        }
        /// <summary>
        /// NiceName
        /// </summary>		
        private string _nicename;
        public string NiceName
        {
            get { return _nicename; }
            set { _nicename = value; }
        }
        /// <summary>
        /// IdenCode
        /// </summary>		
        private string _idencode;
        public string IdenCode
        {
            get { return _idencode; }
            set { _idencode = value; }
        }
        /// <summary>
        /// PhoneNum
        /// </summary>		
        private string _phonenum;
        public string PhoneNum
        {
            get { return _phonenum; }
            set { _phonenum = value; }
        }
        /// <summary>
        /// Gender
        /// </summary>		
        private int _gender;
        public int Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        /// <summary>
        /// QQnumer
        /// </summary>		
        private string _qqnumer;
        public string QQnumer
        {
            get { return _qqnumer; }
            set { _qqnumer = value; }
        }
        /// <summary>
        /// User001
        /// </summary>		
        private int _user001;
        public int User001
        {
            get { return _user001; }
            set { _user001 = value; }
        }
        /// <summary>
        /// User002
        /// </summary>		
        private long _user002;
        public long User002
        {
            get { return _user002; }
            set { _user002 = value; }
        }
        /// <summary>
        /// User004
        /// </summary>		
        private int _user004;
        public int User004
        {
            get { return _user004; }
            set { _user004 = value; }
        }
        /// <summary>
        /// User005
        /// </summary>		
        private string _user005;
        public string User005
        {
            get { return _user005; }
            set { _user005 = value; }
        }
        /// <summary>
        /// User006
        /// </summary>		
        private string _user006;
        public string User006
        {
            get { return _user006; }
            set { _user006 = value; }
        }
        /// <summary>
        /// User007
        /// </summary>		
        private string _user007;
        public string User007
        {
            get { return _user007; }
            set { _user007 = value; }
        }
        /// <summary>
        /// User008
        /// </summary>		
        private string _user008;
        public string User008
        {
            get { return _user008; }
            set { _user008 = value; }
        }
        /// <summary>
        /// User009
        /// </summary>		
        private string _user009;
        public string User009
        {
            get { return _user009; }
            set { _user009 = value; }
        }
        /// <summary>
        /// User010
        /// </summary>		
        private string _user010;
        public string User010
        {
            get { return _user010; }
            set { _user010 = value; }
        }
        /// <summary>
        /// User011
        /// </summary>		
        private decimal _user011;
        public decimal User011
        {
            get { return _user011; }
            set { _user011 = value; }
        }
        /// <summary>
        /// User012
        /// </summary>		
        private decimal _user012;
        public decimal User012
        {
            get { return _user012; }
            set { _user012 = value; }
        }
        /// <summary>
        /// User013
        /// </summary>		
        private decimal _user013;
        public decimal User013
        {
            get { return _user013; }
            set { _user013 = value; }
        }
        /// <summary>
        /// User014
        /// </summary>		
        private decimal _user014;
        public decimal User014
        {
            get { return _user014; }
            set { _user014 = value; }
        }
        /// <summary>
        /// User015
        /// </summary>		
        private decimal _user015;
        public decimal User015
        {
            get { return _user015; }
            set { _user015 = value; }
        }
        /// <summary>
        /// User016
        /// </summary>		
        private decimal _user016;
        public decimal User016
        {
            get { return _user016; }
            set { _user016 = value; }
        }
        /// <summary>
        /// User017
        /// </summary>		
        private decimal _user017;
        public decimal User017
        {
            get { return _user017; }
            set { _user017 = value; }
        }
        /// <summary>
        /// User018
        /// </summary>		
        private decimal _user018;
        public decimal User018
        {
            get { return _user018; }
            set { _user018 = value; }
        }
        /// <summary>
        /// Email
        /// </summary>		
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// 是否出局(0否，1是)
        /// </summary>		
        private int _isout;
        public int IsOut
        {
            get { return _isout; }
            set { _isout = value; }
        }
        /// <summary>
        /// 复投次数
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

