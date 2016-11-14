using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using lgk.Model;
using System.Data;
using DataAccess;
using System.Data.SqlClient;

namespace Web.user.Stock
{
    public partial class StockBuyList : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCurrency();
                BindData();
            }
        }
        /// <summary>
        /// 可卖数量
        /// </summary>
        protected void BindData()
        {
            decimal strbeis = getParamAmount("Integraltra");//可卖超额倍数
            decimal NewPrice = getParamAmount("Shares3");//当前价格
            decimal NewNum = LoginUser.StockAccount;//当前持有云商积分

            string LeveId = LoginUser.LevelID.ToString();
            string Leve = "VIP" + LeveId;
            decimal zhuPrice = getParamAmount(Leve);//会员投资金额
            decimal beizhi = strbeis * zhuPrice;//
            decimal NewNumPrice = Math.Round(NewNum * NewPrice, 4);//当前持有云商积分总价值
            Label2.Text = NewPrice.ToString();//当前价格
            Label3.Text = NewNumPrice.ToString();//市值
            Label4.Text = NewPrice.ToString();//当前价格
            Label5.Text = NewPrice.ToString();//当前价格
            if (NewNumPrice > beizhi)
            {
                decimal sellNum = (NewNumPrice - beizhi) / NewPrice;//可卖数量
                decimal tal = Math.Round(sellNum, 3);//可卖数量
                Label1.Text = tal.ToString();
            }
            else
            {
                Label1.Text = "0.000";
            }
        }


        private void BindCurrency()
        {
            dropCurrency.Items.Add(new ListItem("-请选择-", "0"));
            var iOpen1 = getParamInt("PayTransfer0");
            if (iOpen1 == 1)//电子积分支付功能是否开启
            {
                dropCurrency.Items.Add(new ListItem("电子积分", "1"));
                 
            }
            var iOpen2 = getParamAmount("PayTransfer1");
            if (iOpen2 == 1)//注册积分支付功能是否开启
            {
                dropCurrency.Items.Add(new ListItem("注册积分", "2"));
            }

            var iOpen3 = getParamAmount("PayTransfer2");
            if (iOpen3 == 1)//奖金积分支付是否开启
            {
                dropCurrency.Items.Add(new ListItem("奖金积分", "3"));
            }

            var iOpen4 = getParamAmount("PayTransfer3");
            if (iOpen4 == 1)//感恩积分支付功能是否开启
            {
                dropCurrency.Items.Add(new ListItem("感恩积分", "4"));
            }
        }
        private bool CheckOpen(string value)
        {
            switch (value)
            {
                case "1":
                    var iOpen1 = getParamInt("PayTransfer0");
                    if (iOpen1 != 1)//电子积分支付功能是否开启
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该功能未开放');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "2":
                    var iOpen2 = getParamAmount("PayTransfer1");
                    if (iOpen2 != 1)//注册积分支付功能是否开启
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该功能未开放');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "3":
                    var iOpen3 = getParamAmount("PayTransfer2");
                    if (iOpen3 != 1)//奖金积分支付是否开启
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该功能未开放');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "4":
                    var iOpen4 = getParamAmount("PayTransfer3");
                    if (iOpen4 != 1)//感恩积分支付功能是否开启
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该功能未开放');", true);//该功能未开放
                        return false;
                    }
                    break;
                default://请选择支付类型
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择支付类型');", true);
                    return false;
            }
            return true;
        }

        /// <summary>
        ///查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere1()
        {
            decimal NewPrice = getParamAmount("Shares3");//当前价格
            string strWhere = "UserID=" + getLoginID() + "AND Price=" + NewPrice;
            strWhere += string.Format("AND datediff(day,SellDate,getdate())=0");
            return strWhere;
        }
        /// <summary>
        /// 购买云商积分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            lgk.Model.tb_user userInfo = userBLL.GetModel(getLoginID());
            if (txtBuyNum.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入购买数量');location.href='StockBuyList.aspx';", true);//云商积分已售完
                return;
            }
            if (dropCurrency.SelectedValue == "0")
            {
                MessageBox.Show(this, "" + GetLanguage("ChooseTransfer") + "");//请选择转账类型
                return;
            }
            if (!CheckOpen(dropCurrency.SelectedValue))
            {
                MessageBox.Show(this, "该功能未开放");//该功能未开放
                return;
            }

            string strWhere = "IsSell=1AND SurplusAmount>0";
            lgk.Model.tb_StockIssue issueInfo = stockIssueBLL.GetModel(strWhere);//获取当前出售的云商积分
            int BuyNumber = int.Parse(txtBuyNum.Text.ToString());//购买数量
            decimal NewPrice = getParamAmount("Shares3");//当前价格
            decimal talPrice = BuyNumber * NewPrice;//购买需要支付金额
            lgk.Model.tb_user user = userBLL.GetModel(1);//system作为公司账户，获取公司账户信息

            #region 判断支付账户余额
            int iTypeID = int.Parse(dropCurrency.SelectedValue);//支付类型
            if (iTypeID != 0)
            {
                //判断账户余额是否足够支付
                if (iTypeID == 1 && talPrice > userInfo.AllBonusAccount)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('电子积分账户余额不足');", true);
                    //电子积分账户余额不足
                    return;
                }
                //Emoney = 0;// 注册积分         写流水类型：1
                //BonusAccount = 0;// 奖金积分 	 2
                //AllBonusAccount = 0;// 电子积分	 3
                //StockAccount = 0;// 云商积分	 4
                //StockMoney = 0;// 感恩积分	 5
                //GLmoney = 0;// 购物积分	 6
                //ShopAccount = 0;// 消费积分	 7
                //User011// 爱心基金	 8
                //User012// 云购积分	 9
                //User013//云商积分成本价

                else if (iTypeID == 2 && talPrice > userInfo.Emoney)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('注册积分账户余额不足');", true);
                    return;
                }
                else if (iTypeID == 3 && talPrice > userInfo.BonusAccount)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('奖金积分账户余额不足');", true);
                    return;
                }
                else if (iTypeID == 4 && talPrice > userInfo.StockMoney)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('感恩积分账户余额不足');", true);
                    return;
                }
            }
            #endregion

            #region 判断云商积分是否已经售完
            if (issueInfo == null)//发行云商积分已售完
            {
                bonusBLL.ExecProcedure("proc_Split", 0);
            }
            #endregion

            #region 更新发行数量或者公司账户云商积分剩余量
            if (issueInfo != null)
            {
                if (issueInfo.SurplusAmount > BuyNumber)
                {
                    issueInfo.SurplusAmount = issueInfo.SurplusAmount - BuyNumber;//更新挂售云商积分剩余量
                    stockIssueBLL.Update(issueInfo);
                }
                if (issueInfo.SurplusAmount <= BuyNumber)
                {

                    decimal Number = BuyNumber - issueInfo.SurplusAmount;//需要从公司账户购买的数量
                    lgk.Model.tb_systemMoney systemMoney = systemBll.GetModel(1);
                    if (systemMoney == null)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('云商积分已售完');location.href='StockBuyList.aspx';", true);//云商积分已售完
                        return;
                    }
                    if (systemMoney.MoneyAccount < Number)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('平台云商积分出售数量不足');location.href='StockBuyList.aspx';", true);//云商积分已售完
                        return;
                    }
                    else
                    {
                        issueInfo.SurplusAmount = 0;//更新挂售云商积分剩余量,发行数量
                        issueInfo.IsSell = 0;//0，是卖完，1是挂售中
                        stockIssueBLL.Update(issueInfo);

                        #region 购买云商积分,公司账户云商积分减少
                        systemMoney.MoneyAccount -= Number;//需要从公司账户购买的数量
                        systemBll.Update(systemMoney);
                        #endregion
                    }
                }
            }
            if (issueInfo == null)
            {
                #region 购买云商积分,公司账户云商积分减少
                lgk.Model.tb_systemMoney systemMoney = systemBll.GetModel(1);
                if (systemMoney == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('云商积分已售完');location.href='StockBuyList.aspx';", true);//云商积分已售完
                    return;
                }
                if (systemMoney.MoneyAccount < BuyNumber)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('平台云商积分出售数量不足');location.href='StockBuyList.aspx';", true);//云商积分已售完
                    return;
                }
                else
                {
                    #region 购买云商积分,公司账户云商积分减少
                    systemMoney.MoneyAccount -= BuyNumber;//
                    systemBll.Update(systemMoney);
                    #endregion
                }
                #endregion
            }
            #endregion
            #region 统计交易总量，当达到一定交易流执行涨价
            decimal jiaoyiNum = getParamAmount("Shares4");//达到某交易数量执行升价
            decimal shenPrice = getParamAmount("Shares5");//涨幅价格
            decimal jiaoNumber = getParamAmount("Tal") + BuyNumber;//累计交易总量
            if (jiaoNumber < jiaoyiNum)
            {
                UpdateParamVarchar("ParamVarchar", jiaoNumber.ToString(), "Tal");
            }

            if (jiaoNumber >= jiaoyiNum)
            {
                int beishu = (int)(jiaoNumber / jiaoyiNum);

                bonusBLL.ExecProcedure("proc_Split", beishu * shenPrice);
                decimal yueNum = jiaoNumber - jiaoyiNum * beishu;
                UpdateParamVarchar("ParamVarchar", yueNum.ToString(), "Tal");
            }
            #endregion
            #region 交易密码
            string strBuyPwd = PayPassword.Value.Trim();
            if (string.IsNullOrEmpty(strBuyPwd))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入交易密码！');", true);
                return;
            }
            lgk.Model.tb_user buyUserModel = LoginUser;
            if (!PageValidate.GetMd5(strBuyPwd).Equals(buyUserModel.SecondPassword))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('支付密码输入错误！');", true);
                return;
            }
            #endregion
            //加入交易记录                                                           
            lgk.Model.Cashbuy cashbuyinfo = new lgk.Model.Cashbuy();
            cashbuyinfo.Amount = talPrice;//购买支付的金额
            cashbuyinfo.CashsellID = 0;//
            cashbuyinfo.BuyNum = BuyNumber;//model.SaleNum;//购买数量
            cashbuyinfo.Number = BuyNumber;
            cashbuyinfo.UserID = getLoginID();//买家ID
            cashbuyinfo.Price = NewPrice;
            cashbuyinfo.BuyDate = DateTime.Now;
            cashbuyinfo.IsBuy = 1;
            cashbuyBLL.Add(cashbuyinfo);

            #region 计算云商积分成本价格
            decimal chenbePrice = userInfo.User013;//获取会员当前云商积分成本价格
            decimal stockAcont = userInfo.StockAccount;//获取当前会有云商积分余额
            decimal talMoney = chenbePrice * stockAcont;//计算购买前总的成本价格
            decimal dangPrice = Math.Round((talPrice + talMoney) / (stockAcont + BuyNumber), 4);//计算购买后单价成本价格
            userInfo.User013 = dangPrice;
            userBLL.Update(userInfo);//更新成本价格
            #endregion
            UpdateAccount("StockAccount", userInfo.UserID, BuyNumber, 1);//买家云商积分账户更新

            #region  解冻推荐会员的云购积分
            long UserID = getLoginID();//登陆会员Id
            if (UserID != 1)
            {
                long RecommendID = userInfo.RecommendID;//获取推荐人ID
                lgk.Model.tb_user orUerser = userBLL.GetModel(RecommendID);
                if (orUerser != null)
                {
                    string Remark = "会员" + GetUserCode(UserID) + "购买云商积分，解冻云购积分";
                    if (orUerser.User012 >= BuyNumber)
                    {
                        UpdateAccount("User012", RecommendID, BuyNumber, 0);//云购积分解冻更新
                        UpdateAccount("User014", RecommendID, BuyNumber, 1);//
                        UpdateAccount("StockAccount", RecommendID, BuyNumber, 1);//获得云商积分

                        decimal balanceAmount = orUerser.User012 - BuyNumber;//云购积分账户结余金额
                        add_journal(RecommendID, 0, BuyNumber, balanceAmount, 9, Remark, "", RecommendID);//云购积分加入流水线

                        decimal balanceAmount2 = orUerser.StockAccount + BuyNumber;//云商积分账户结余金额
                        add_journal(RecommendID, BuyNumber, 0, balanceAmount2, 4, Remark, "", RecommendID);//云商积分加入流水线
                    }
                    else if (orUerser.User012 > 0)
                    {
                        UpdateAccount("User012", RecommendID, orUerser.User012, 0);//云购积分解冻更新
                        UpdateAccount("User014", RecommendID, orUerser.User012, 1);//
                        UpdateAccount("StockAccount", RecommendID, orUerser.User012, 1);//获得云商积分

                        decimal balanceAmount = 0;//orUerser.User012 - BuyNumber;//云购积分账户结余金额
                        add_journal(RecommendID, 0, BuyNumber, balanceAmount, 9, Remark, "", RecommendID);//云购积分加入流水线

                        decimal balanceAmount2 = orUerser.StockAccount + orUerser.User012;//云商积分账户结余金额
                        add_journal(RecommendID, orUerser.User012, 0, balanceAmount2, 4, Remark, "", RecommendID);//云商积分加入流水线
                    }

                }
            }
            #endregion

            //云商积分加入流水线
            lgk.Model.tb_journal joadanInfo = new lgk.Model.tb_journal();
            joadanInfo.UserID = getLoginID();
            joadanInfo.Remark = "购买云商积分";
            joadanInfo.InAmount = BuyNumber;
            joadanInfo.OutAmount = 0;
            joadanInfo.BalanceAmount = userInfo.StockAccount + BuyNumber;//结余账户余额;
            joadanInfo.JournalDate = DateTime.Now;
            joadanInfo.JournalType = 4;//journalType : 1、注册积分，2、奖金积分，3、电子积分，4、云商积分，5、感恩积分，6、购物积分，7、消费积分，8、爱心基金，9、云购积分

            journalBLL.Add(joadanInfo);//增加一条数据

            lgk.Model.tb_journal joadanInf1 = new lgk.Model.tb_journal();
            joadanInf1.UserID = getLoginID();
            joadanInf1.Remark = "购买云商积分";
            joadanInf1.InAmount = 0;
            joadanInf1.OutAmount = talPrice;
            joadanInf1.JournalDate = DateTime.Now;
            //买家支付币种账户更新
            if (iTypeID == 1)
            {
                //买家账户余额更新
                UpdateAccount("AllBonusAccount", userInfo.UserID, talPrice, 0);
                joadanInf1.BalanceAmount = userInfo.AllBonusAccount - talPrice;//结余账户余额;
                joadanInf1.JournalType = 3;//journalType : 1、注册积分，2、奖金积分，3、电子积分，4、云商积分，5、感恩积分，6、购物积分，7、消费积分，8、爱心基金，9、云购积分
                journalBLL.Add(joadanInf1);//增加一条数据
            }
            else if (iTypeID == 2)
            {
                //买家账户余额更新
                UpdateAccount("Emoney", userInfo.UserID, talPrice, 0);
                joadanInf1.BalanceAmount = userInfo.Emoney - talPrice;//结余账户余额;
                joadanInf1.JournalType = 1;//journalType : 1、注册积分，2、奖金积分，3、电子积分，4、云商积分，5、感恩积分，6、购物积分，7、消费积分，8、爱心基金，9、云购积分
                journalBLL.Add(joadanInf1);//增加一条数据
            }
            else if (iTypeID == 3)
            {
                //买家账户余额更新
                UpdateAccount("BonusAccount", userInfo.UserID, talPrice, 0);
                joadanInf1.BalanceAmount = userInfo.BonusAccount - talPrice;//结余账户余额;
                joadanInf1.JournalType = 2;//journalType : 1、注册积分，2、奖金积分，3、电子积分，4、云商积分，5、感恩积分，6、购物积分，7、消费积分，8、爱心基金，9、云购积分
                journalBLL.Add(joadanInf1);//增加一条数据
            }
            else if (iTypeID == 4)
            {
                //买家账户余额更新
                UpdateAccount("StockMoney", userInfo.UserID, talPrice, 0);
                joadanInf1.BalanceAmount = userInfo.StockMoney - talPrice;//结余账户余额;
                joadanInf1.JournalType = 5;//journalType : 1、注册积分，2、奖金积分，3、电子积分，4、云商积分，5、感恩积分，6、购物积分，7、消费积分，8、爱心基金，9、云购积分
                journalBLL.Add(joadanInf1);//增加一条数据
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('购买成功');location.href='StockBuyList.aspx';", true);
            return;
        }

        protected void txtBuyNum_TextChanged1(object sender, EventArgs e)
        {
            decimal NewPrice = getParamAmount("Shares3");//当前价格
            if (txtBuyNum.Text.Trim() != "")
            {
                int Number = 0;//购买数量
                if (!int.TryParse(txtBuyNum.Text.Trim(), out Number))
                {
                    MessageBox.MyShow(this, "请输入有效数据");//请输入有效数据
                    return;
                }
                decimal tal = Math.Round(NewPrice * Number, 4);//购买商品总价格
                Label6.Text = tal.ToString();
            }

        }
        /// <summary>
        /// 卖出云商积分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            long UserID = getLoginID();//登陆会员Id
            lgk.Model.tb_user userInfo = userBLL.GetModel(UserID);
            if (txtSellNum.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入卖出数量');location.href='StockBuyList.aspx';", true);//云商积分已售完
                return;
            }
            #region 交易密码
            string strBuyPwd = PayPass.Value.Trim();
            if (string.IsNullOrEmpty(strBuyPwd))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入交易密码！');", true);
                return;
            }
            lgk.Model.tb_user buyUserModel = LoginUser;
            if (!PageValidate.GetMd5(strBuyPwd).Equals(buyUserModel.SecondPassword))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('支付密码输入错误！');", true);
                return;
            }
            #endregion
            decimal CanSellNum = decimal.Parse(Label1.Text.ToString());//可卖数量
            decimal NewPrice = getParamAmount("Shares3");//当前价格
            decimal bilijine = getParamAmount("Integraltra0");//可卖金额比例参数
            decimal ciNum = getParamAmount("Integraltra1");//每天可以卖出次数
            int SellNumber = int.Parse(txtSellNum.Text.ToString());//卖出数量
            decimal SellPrice = NewPrice * SellNumber;//卖出总价格
            string LeveId = LoginUser.LevelID.ToString();//会员等级ID
            string Leve = "VIP" + LeveId;
            decimal zhuPrice = getParamAmount(Leve);//会员投资金额，即注册金额
            decimal keSellAuPrice = bilijine * zhuPrice / 100;//每次最多可卖出金额数
            string strWhere = "UserID = " + LoginUser.UserID + " AND DATEDIFF (DAY, SellDate, GETDATE()) = 0";
            int a = cashsellBLL.Getalready(strWhere);//查询当天卖出次数
            decimal bilicashu1 = getParamAmount("Integraltra2");//卖出云商积分获得奖金积分比例参数
            decimal bilicashu2 = getParamAmount("Integraltra3");//卖出云商积分获得感恩积分比例参数
            decimal bilicashu3 = getParamAmount("Integraltra4");//卖出云商积分获得购物积分比例参数
            decimal bilicashu4 = getParamAmount("Integraltra5");//卖出云商积分获得爱心基金比例参数
            if (SellPrice > keSellAuPrice)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('卖出总金额大于你每次可卖最大金额" + keSellAuPrice + ",请更改卖出金额！');location.href='StockBuyList.aspx';", true);//云商积分已售完
                return;
            }
            #region system账户可卖出云商积分判断
            if (CanSellNum < SellNumber)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('可卖出数量不足！');location.href='StockBuyList.aspx';", true);//云商积分已售完
                return;
            }
            #endregion
            #region system账户卖出云商积分
            if (UserID == 1)
            {

                //加入交易记录                                                           
                lgk.Model.Cashsell cashsellinfo = new lgk.Model.Cashsell();
                cashsellinfo.UserID = UserID;
                cashsellinfo.Title = "云商积分卖出";
                cashsellinfo.Amount = SellPrice;//商品价格
                cashsellinfo.Number = SellNumber;//卖出数量
                cashsellinfo.Price = NewPrice;//商品单价
                cashsellinfo.SaleNum = SellNumber;
                cashsellinfo.UnitNum = 1;//发布件数
                cashsellinfo.Charge = 0; //Convert.ToDecimal(sellNum.Value.Trim());//每件所需手续费
                cashsellinfo.SellDate = DateTime.Now;//提交时间
                cashsellinfo.Remark = "";
                cashsellinfo.PurchaseID = 0;
                cashsellinfo.IsSell = 1;//0是挂单中，1是已完成
                cashsellBLL.Add(cashsellinfo);

                UpdateAccount("StockAccount", userInfo.UserID, SellNumber, 0);//买家云商积分账户更新

                //#region 判断交易总量是否达到涨价要求
                //decimal jiaoyiNum = getParamAmount("Shares4");//执行升价的某交易数量
                //decimal shenPrice = getParamAmount("Shares5");//涨幅价格
                //decimal jiaoNumber = getParamAmount("Tal") + SellNumber;//累计交易总量
                ////UpdateParamVarchar("ParamVarchar", jiaoNumber.ToString(), "Tal");//更新交易总量

                //if (jiaoNumber < jiaoyiNum)
                //{
                //    UpdateParamVarchar("ParamVarchar", jiaoNumber.ToString(), "Tal");
                //}

                //if (jiaoNumber >= jiaoyiNum)
                //{
                //    int beishu = (int)(jiaoNumber / jiaoyiNum);

                //    bonusBLL.ExecProcedure("proc_Split", beishu * shenPrice);
                //    decimal yueNum = jiaoNumber - jiaoyiNum * beishu;
                //    UpdateParamVarchar("ParamVarchar", yueNum.ToString(), "Tal");
                //}
                //#endregion

                #region 卖出云商积分,公司账户云商积分增加
                lgk.Model.tb_systemMoney systemMoney = systemBll.GetModel(1);
                systemMoney.MoneyAccount += SellNumber;
                systemBll.Update(systemMoney);
                #endregion
                //云商积分加入流水线
                string Remark = "卖出云商积分";
                decimal BalanceAmount = userInfo.StockAccount - SellNumber;//结余账户余额;
                                                                           //journalType : 1、注册积分，2、奖金积分，3、电子积分，4、云商积分，5、感恩积分，6、购物积分，7、消费积分，8、爱心基金，9、云购积分

                add_journal(UserID, 0, SellNumber, BalanceAmount, 4, Remark, "", UserID);

                //卖出云商积分后，奖金积分增加并添加流水线
                decimal jiangjin = bilicashu1 * SellPrice / 100;//获得奖金金额
                UpdateAccount("BonusAccount", UserID, jiangjin, 1);
                decimal balanceAmount = userInfo.BonusAccount + jiangjin;//账户结余金额
                add_journal(UserID, jiangjin, 0, balanceAmount, 2, Remark, "", UserID);

                //卖出云商积分后，感恩积分增加并添加流水线
                decimal ganen = bilicashu2 * SellPrice / 100;//获得感恩积分金额
                decimal balanAmont = userInfo.StockMoney + ganen;//账户结余金额
                UpdateAccount("StockMoney", UserID, ganen, 1);
                add_journal(UserID, ganen, 0, balanAmont, 5, Remark, "", UserID);

                //卖出云商积分后，购物积分增加并添加流水线
                decimal gouwu = bilicashu3 * SellPrice / 100;//获得感恩积分金额
                decimal balanAmont1 = userInfo.GLmoney + gouwu;//账户结余金额
                UpdateAccount("GLmoney", UserID, gouwu, 1);
                add_journal(UserID, gouwu, 0, balanAmont1, 6, Remark, "", UserID);

                //卖出云商积分后，爱心基金增加并添加流水线
                decimal aixin = bilicashu4 * SellPrice / 100;//获得感恩积分金额
                decimal balanAmont2 = userInfo.User011 + aixin;//账户结余金额
                UpdateAccount("User011", UserID, aixin, 1);
                add_journal(UserID, aixin, 0, balanAmont2, 8, Remark, "", UserID);

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('卖出成功！');location.href='StockBuyList.aspx';", true);//云商积分已售完
                return;

            }
            #endregion
            #region 其他账户卖出云商积分
            else
            {
                if (a >= ciNum)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('今天卖出次数已用完');location.href='StockBuyList.aspx';", true);//云商积分已售完
                    return;
                }
                if (a < ciNum)

                {
                    lgk.Model.Cashsell sellINd = cashsellBLL.GetModel(GetWhere1());
                    if (sellINd != null)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('当前价格已卖出一次，不可再次卖出！');location.href='StockBuyList.aspx';", true);//云商积分已售完
                        return;
                    }
                    else
                    {
                        //#region 判断交易总量是否达到涨价要求
                        //decimal jiaoyiNum = getParamAmount("Shares4");//执行升价的某交易数量
                        //decimal shenPrice = getParamAmount("Shares5");//涨幅价格
                        //decimal jiaoNumber = getParamAmount("Tal") + SellNumber;//累计交易总量
                        ////UpdateParamVarchar("ParamVarchar", jiaoNumber.ToString(), "Tal");//更新交易总量
                        //if (jiaoNumber < jiaoyiNum)
                        //{
                        //    UpdateParamVarchar("ParamVarchar", jiaoNumber.ToString(), "Tal");
                        //}

                        //if (jiaoNumber >= jiaoyiNum)
                        //{
                        //    int beishu = (int)(jiaoNumber / jiaoyiNum);

                        //    bonusBLL.ExecProcedure("proc_Split", beishu * shenPrice);
                        //    decimal yueNum = jiaoNumber - jiaoyiNum * beishu;
                        //    UpdateParamVarchar("ParamVarchar", yueNum.ToString(), "Tal");
                        //}
                        //#endregion

                        # region 卖出云商积分,公司账户云商积分增加
                        lgk.Model.tb_systemMoney systemMoney = systemBll.GetModel(1);
                        systemMoney.MoneyAccount += SellNumber;
                        systemBll.Update(systemMoney);
                        //UpdateAccount("StockAccount", 1, SellNumber, 1);//公司云商积分账户更新
                        //string RemaUser = "会员卖出云商积分";
                        //lgk.Model.tb_user useradmin = userBLL.GetModel(UserID);
                        //decimal balanAm = useradmin.StockAccount;//账户结余金额
                        //add_journal(1, SellNumber, 0, balanAm, 4, RemaUser, "", UserID);
                        #endregion
                        //加入交易记录                                                           
                        lgk.Model.Cashsell cashsellinfo = new lgk.Model.Cashsell();
                        cashsellinfo.UserID = UserID;
                        cashsellinfo.Title = "云商积分卖出";
                        cashsellinfo.Amount = SellPrice;//商品价格
                        cashsellinfo.Number = SellNumber;//卖出数量
                        cashsellinfo.Price = NewPrice;//商品单价
                        cashsellinfo.SaleNum = SellNumber;
                        cashsellinfo.UnitNum = 1;//发布件数
                        cashsellinfo.Charge = 0; //Convert.ToDecimal(sellNum.Value.Trim());//每件所需手续费
                        cashsellinfo.SellDate = DateTime.Now;//提交时间
                        cashsellinfo.Remark = "";
                        cashsellinfo.PurchaseID = 0;
                        cashsellinfo.IsSell = 1;//0是挂单中，1是已完成
                        cashsellBLL.Add(cashsellinfo);

                        #region 计算云商积分成本价格
                        decimal chenbePrice = userInfo.User013;//获取会员当前云商积分成本价格
                        decimal stockAcont = userInfo.StockAccount;//获取当前会有云商积分余额
                        decimal talMoney = chenbePrice * stockAcont;//计算卖出前总的成本价格
                        decimal dangPrice = Math.Round((talMoney - SellPrice) / (stockAcont - SellNumber), 4);//计算卖出后单价成本价格
                        userInfo.User013 = dangPrice;
                        userBLL.Update(userInfo);//更新成本价格
                        #endregion

                        UpdateAccount("StockAccount", userInfo.UserID, SellNumber, 0);//买家云商积分账户更新
                                                                                      //云商积分加入流水线
                        lgk.Model.tb_journal joadanInfo = new lgk.Model.tb_journal();
                        joadanInfo.UserID = getLoginID();
                        joadanInfo.Remark = "卖出云商积分";
                        joadanInfo.InAmount = 0;
                        joadanInfo.OutAmount = SellNumber;
                        joadanInfo.BalanceAmount = userInfo.StockAccount - SellNumber;//结余账户余额;
                        joadanInfo.JournalDate = DateTime.Now;
                        joadanInfo.JournalType = 4;//journalType : 1、注册积分，2、奖金积分，3、电子积分，4、云商积分，5、感恩积分，6、购物积分，7、消费积分，8、爱心基金，9、云购积分
                        journalBLL.Add(joadanInfo);//增加一条数据

                        string Remark = "卖出云商积分";

                        //卖出云商积分后，奖金积分增加并添加流水线
                        decimal jiangjin = bilicashu1 * SellPrice / 100;//获得奖金金额
                        UpdateAccount("BonusAccount", UserID, jiangjin, 1);
                        decimal balanceAmount = userInfo.BonusAccount + jiangjin;//账户结余金额
                        add_journal(UserID, jiangjin, 0, balanceAmount, 2, Remark, "", UserID);

                        //卖出云商积分后，感恩积分增加并添加流水线
                        decimal ganen = bilicashu2 * SellPrice / 100;//获得感恩积分金额
                        decimal balanAmont = userInfo.StockMoney + ganen;//账户结余金额
                        UpdateAccount("StockMoney", UserID, ganen, 1);
                        add_journal(UserID, ganen, 0, balanAmont, 5, Remark, "", UserID);

                        //卖出云商积分后，购物积分增加并添加流水线
                        decimal gouwu = bilicashu3 * SellPrice / 100;//获得感恩积分金额
                        decimal balanAmont1 = userInfo.GLmoney + gouwu;//账户结余金额
                        UpdateAccount("GLmoney", UserID, gouwu, 1);
                        add_journal(UserID, gouwu, 0, balanAmont1, 6, Remark, "", UserID);

                        //卖出云商积分后，爱心基金增加并添加流水线
                        decimal aixin = bilicashu4 * SellPrice / 100;//获得感恩积分金额
                        decimal balanAmont2 = userInfo.User011 + aixin;//账户结余金额
                        UpdateAccount("User011", UserID, aixin, 1);
                        add_journal(UserID, aixin, 0, balanAmont2, 8, Remark, "", UserID);

                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('卖出成功！');location.href='StockBuyList.aspx';", true);//云商积分已售完
                        return;
                    }
                }
            }
            #endregion
        }

        protected void txtSellNum_TextChanged(object sender, EventArgs e)
        {
            decimal NewPrice = getParamAmount("Shares3");//当前价格
            if (txtSellNum.Text.Trim() != "")
            {
                int sellNumber = 0;//购买数量
                if (!int.TryParse(txtSellNum.Text.Trim(), out sellNumber))
                {
                    MessageBox.MyShow(this, "请输入有效数据");//请输入有效数据
                    return;
                }
                decimal tal = Math.Round(NewPrice * sellNumber, 4);//购买商品总价格
                Label7.Text = tal.ToString();
            }
        }
    }
}