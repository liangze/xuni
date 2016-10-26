using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.Stock
{
    public partial class Putinto : PageCore
    {
        protected string YuAmount = "0.00";//奖金余额
        protected string total = "0.00";//已提现
        protected string hkMoney = "0.00";//实际金额
        public int asd = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转3级密码

            if (!IsPostBack)
            {
                BindData();
                ShowData();
                btnSearch.Text = GetLanguage("Search");//搜索
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        /// <summary>
        /// 填充
        /// </summary>
        protected void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), rpTake, "TakeTime desc", tr1, AspNetPager1);
            lblQuestion.Text = GoldDdlQuest(LoginUser.User009);
        }

        private void ShowData()
        {
            decimal dProfit = Convert.ToDecimal(0.00);
            lgk.Model.Stock stockInfo = stockBLL.GetModel("UserID=" + getLoginID() + "");

            if (stockInfo != null)
                dProfit = stockInfo.Number * (getParamAmount("shares5") - stockInfo.Price);//可提现余额

            txtMoney.Value = dProfit.ToString("0.00");

            if (dProfit > 200)
                btnSubmit.Enabled = true;
            else
                btnSubmit.Enabled = false;

            this.txtBalance.Value = GetTotalTake(getLoginID(), 2).ToString("0.00");//以提现金
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = " u.UserID=" + getLoginID() + " and TakeType=2";

            if (GetLanguage("LoginLable") == "zh-cn")
            {
                if (this.txtStar.Text != "")
                {
                    strWhere += " and convert(varchar(10),TakeTime,120) >='" + this.txtStar.Text + "'";
                }
                if (this.txtEnd.Text != "")
                {
                    strWhere += " and convert(varchar(10),TakeTime,120) <='" + this.txtEnd.Text + "'";
                }
            }
            else
            {
                if (this.txtStarEn.Text != "")
                {
                    strWhere += " and convert(varchar(10),TakeTime,120) >='" + this.txtStarEn.Text + "'";
                }
                if (this.txtEndEn.Text != "")
                {
                    strWhere += " and convert(varchar(10),TakeTime,120) <='" + this.txtEndEn.Text + "'";
                }
            }
            return strWhere;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            decimal resultNum = 0;
            decimal tx_min = getParamAmount("tx_min");//最低提现额
            decimal tx_bs = getParamAmount("tx_bs");//倍数基数
            decimal tx_dh = getParamAmount("tx_dh");//兑换比例 1元多少人民币

            lgk.Model.Stock stockInfo = new lgk.Model.Stock();
            lgk.Model.tb_takeMoney takeMoneyInfo = new lgk.Model.tb_takeMoney();

            stockInfo = stockBLL.GetModel("UserID=" + getLoginID() + "");
            decimal dProfit = stockInfo.Number * (getParamAmount("shares5") - stockInfo.Price);

            #region 数据验证
            if (txtTake.Text.Trim() == "")
            {
                MessageBox.MyShow(this, "转盘金额不能为空");//转盘金额不能为空
                return;
            }

            if (decimal.TryParse(txtTake.Text.Trim(), out resultNum))
            {
                if (resultNum < tx_min)
                {
                    MessageBox.MyShow(this, GetLanguage("AmountThan") + tx_min + GetLanguage("TheInteger"));//提现金额必须是大于等于XX的整数!
                    return;
                }
                if (resultNum % tx_bs != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("amountMust") + tx_bs + GetLanguage("Multiples") + "');", true);//提现金额必须是" + tx_bs + "的倍数!
                    return;
                }
            }
            else
            {
                MessageBox.MyShow(this, GetLanguage("AmountErrors"));//金额格式输入错误
                return;
            }
            if (Convert.ToDecimal(txtTake.Text.Trim()) < tx_min)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AmountThan") + tx_min + "!');", true);//提现金额必须是大于等于XX
                return;
            }
            if (Convert.ToDecimal(txtTake.Text) > dProfit)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AmountBalance") + "');", true);//提现金额不能大于奖金余额
                return;
            }
            if (LoginUser.User010 != txtAnswer.Text.Trim())
            {
                MessageBox.Show(this, GetLanguage("answerErrors"));//密保答案错误
                return;
            }

            #endregion

            #region 转盘申请
            takeMoneyInfo.TakeTime = DateTime.Now;
            takeMoneyInfo.TakeMoney = Convert.ToDecimal(txtTake.Text);//转盘金额
            takeMoneyInfo.TakePoundage = Convert.ToDecimal(txtTake.Text.Trim()) * getParamAmount("tx_rete") / 100;//转盘手续费
            takeMoneyInfo.RealityMoney = Convert.ToDecimal(txtTake.Text.Trim()) - takeMoneyInfo.TakePoundage;//实际转盘到账金额
            takeMoneyInfo.Flag = 1;
            takeMoneyInfo.UserID = getLoginID();
            takeMoneyInfo.BonusBalance = dProfit - takeMoneyInfo.TakeMoney;//转盘后余额
            takeMoneyInfo.BankName = LoginUser.BankName;
            takeMoneyInfo.Take003 = LoginUser.BankBranch;
            takeMoneyInfo.BankAccount = LoginUser.BankAccount;
            takeMoneyInfo.BankAccountUser = LoginUser.BankAccountUser;
            takeMoneyInfo.TakeType = 2;
            #endregion

            #region 加入流水账表
            lgk.Model.tb_journal model = new lgk.Model.tb_journal();
            model.UserID = takeMoneyInfo.UserID;
            model.Remark = "转盘申请";
            model.RemarkEn = "Cash withdrawal";
            model.InAmount = 0;
            model.OutAmount = takeMoneyInfo.TakeMoney;
            model.BalanceAmount = takeMoneyInfo.BonusBalance;
            model.JournalDate = DateTime.Now;
            model.JournalType = 1;
            model.Journal01 = takeMoneyInfo.UserID;
            #endregion

            long iPlacementID = GetPlacementID();

            if (iPlacementID == 0)
            {
                //没有可安置位置，请开通会员再试！
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('没有可安置位置，请开通会员再试！');", true);
                return;
            }

            //转B盘
            bool bCreate = CreateUser(takeMoneyInfo.TakeMoney, iPlacementID);

            int iTake = takeBLL.Add(takeMoneyInfo);
            long lJour = journalBLL.Add(model);

            bool bFalg = stockBLL.UpdateStockNumber(stockInfo.StockID, Convert.ToDecimal(takeMoneyInfo.TakeMoney), getParamAmount("shares5"), 0);

            if (bCreate && iTake > 0 && lJour > 0 && bFalg)
            {
                string ss = (GetLanguage("PutintoTable").Replace("{username}", LoginUser.UserCode)).Replace("{time}", Convert.ToDateTime(model.JournalDate).ToString("yyyy年MM月dd日HH时mm分")).Replace("{timeEn}", Convert.ToDateTime(model.JournalDate).ToString("yyyy/MM/dd HH:mm"));//添加短信内容
                SendMessage((int)LoginUser.UserID, LoginUser.PhoneNum, ss);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("successful") + "');window.location.href='Putinto.aspx';", true);//申请提现成功
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');", true);//操作失败
            }
        }

        /// <summary>
        /// 创建见点
        /// </summary>
        private bool CreateUser(decimal dTakeMoney,long iUserID)
        {
            bool bFlag = false;
            lgk.Model.tb_user model = new lgk.Model.tb_user();
            lgk.Model.tb_user myModel = new lgk.Model.tb_user();
            lgk.Model.tb_user myModelParent = new lgk.Model.tb_user();

            myModel = userBLL.GetModel(getLoginID());
            myModelParent = userBLL.GetModel(iUserID);//推荐用户

            #region 初始化转盘数据
            model.UserCode = GetUserCode();//会员编号
            model.LevelID = myModel.LevelID;//会员级别
            model.RecommendID = myModel.UserID;//推荐人ID
            model.RecommendCode = myModel.UserCode;//推荐人编号
            model.RecommendPath = myModel.RecommendPath; //路径
            model.RecommendGenera = Convert.ToInt32(myModel.RecommendGenera + 1);//（推荐代数）第几代
            model.User001 = 0;//

            model.ParentID = myModelParent.UserID;//父节点ID
            model.ParentCode = myModelParent.UserCode;//父节点编号
            model.UserPath = myModelParent.UserPath; //路径
            model.Layer = myModelParent.Layer + 1;//属于多少层
            model.LeftBalance = 0;
            model.LeftNewScore = 0;
            model.RightBalance = 0;
            model.RightNewScore = 0;
            model.LeftScore = 0;
            model.RightScore = 0;
            model.Location = userBLL.GetLocation(myModel.UserID);
            model.User007 = model.Location == 1 ? "左区" : "右区";
            model.IsOpend = 2;//是否启用 0-未激活, 2-已激活,3-已激活成空单。
            model.IsLock = 0;//是否被冻結(0-否,1-冻結)

            model.IsAgent = 0;//是否报單中心(0-否，1-是)
            model.User006 = myModel.User006;//代理中心编号
            model.AgentsID = agentBLL.GetAgentsIDByUserCode(myModel.User006);//

            model.Emoney = 0;//C幣賬戶
            model.BonusAccount = 0;//獎金賬戶
            model.AllBonusAccount = 0;//累计獎金賬戶
            model.StockAccount = 0;//可交易期權
            model.StockMoney = 0;//期權賬戶

            model.RegTime = DateTime.Now;//注册時間
            model.RegMoney = getParamAmount("billMoney") * getParamAmount("Leve" + myModel.LevelID);
            model.OpenTime = DateTime.Now;//开通时间
            model.BillCount = 0;//注册单数
            model.Password = "";//一级密码
            model.SecondPassword = "";//二级密码
            model.ThreePassword = "";//三级密码

            model.BankAccount = myModel.BankAccount;// "银行帐号";
            model.BankAccountUser = myModel.BankAccountUser;// "开户姓名";
            model.BankName = myModel.BankName;// "开户银行";
            model.BankBranch = myModel.BankBranch;// "支行名称";
            model.BankInProvince = myModel.BankInProvince;// "银行所在省份";
            model.BankInCity = "";//DropDownList1.SelectedItem.Text;// "银行所在城市";

            model.NiceName = string.Empty;//txtNickName.Value.Trim();//昵称
            model.TrueName = myModel.TrueName;// "姓名";
            model.IdenCode = myModel.IdenCode;// "身份证号";
            model.PhoneNum = myModel.PhoneNum;// "手机号码";
            model.Address = myModel.Address;//联系地址
            model.User002 = 0;
            int jihuo = 0;

            model.User004 = jihuo;//激活方式
            model.User009 = myModel.User009;//密保问题
            model.User010 = myModel.User010;//密保答案
            model.User011 = 0;
            model.User018 = 0;//--用户竞拍该扣未扣的奖金币
            #endregion

            long iUID = GetUserID(model.UserCode);
            if (iUID > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("转盘失败，数据已回滚，请重试！") + "');", true);//转盘失败，数据已回滚，请重试！
                bFlag = false;
            }
            else
            {
                if (userBLL.Add(model) > 0)
                {
                    lgk.Model.tb_user modelinfo = userBLL.GetModel(GetUserID(model.UserCode));
                    model.UserPath = modelinfo.UserPath + "-" + modelinfo.UserID.ToString();
                    model.RecommendPath = modelinfo.RecommendPath + "-" + modelinfo.UserID.ToString();
                    userBLL.Update(modelinfo);
                    bFlag = true;
                }
            }

            return bFlag;
        }

        /// <summary>
        /// 获取能安置下线的会员编号
        /// </summary>
        /// <returns></returns>
        private long GetPlacementID()
        {
            return userBLL.GetPlacementID(getLoginID());
        }

        /// <summary>
        /// 获取UserCode
        /// </summary>
        /// <returns></returns>
        private string GetUserCode()
        {
            string strUserCode = string.Empty;

            UserCode code = new UserCode();

            strUserCode = code.GetCode();

            bool bFlag = true;

            while (bFlag)
            {
                strUserCode = code.GetCode();
                bFlag = userBLL.Exists(strUserCode);
            }

            return strUserCode;
        }

        protected void txtTake_TextChanged(object sender, EventArgs e)
        {
            if (txtTake.Text.Trim() != "")
            {
                decimal value = (Convert.ToDecimal(txtTake.Text) * (1 - getParamAmount("tx_rete") / 100));//转换人民币的倍数getParamAmount("tx_dh")
                txtExtMoney.Value = value.ToString();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void rpTake_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "change")
            {
                long id = Convert.ToInt64(e.CommandArgument);
                lgk.Model.tb_takeMoney takeInfo = takeBLL.GetModel(id);
                if (takeInfo == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordDeleted") + "');", true);//该记录已删除，无法再进行此操作
                    return;
                }
                if (takeInfo.Flag != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordApproved") + "');", true);//该记录已审核，无法再进行此操作
                    return;
                }
                lgk.Model.Stock stockInfo = stockBLL.GetModel("UserID=" + takeInfo.UserID);
                decimal dProfit = stockInfo.Number * (getParamAmount("shares5") - stockInfo.Price);
                //加入流水账表
                lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                model.UserID = takeInfo.UserID;
                model.Remark = "取消转盘";
                model.InAmount = takeInfo.TakeMoney;
                model.OutAmount = 0;
                model.BalanceAmount = dProfit + takeInfo.TakeMoney;
                model.JournalDate = DateTime.Now;
                model.JournalType = 1;
                model.Journal01 = takeInfo.UserID;

                bool bFalg = stockBLL.UpdateStockNumber(stockInfo.StockID, Convert.ToDecimal(takeInfo.TakeMoney), getParamAmount("shares5"), 1);

                if (journalBLL.Add(model) > 0 && bFalg && takeBLL.Delete(id) && flag_delete(Convert.ToInt32(takeInfo.UserID)) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("CancellationSuccess") + "');window.location.href='TakeMoney.aspx';", true);//取消成功
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("FailedToCancel") + "');", true);//取消失败
                }
            }
        }
    }
}