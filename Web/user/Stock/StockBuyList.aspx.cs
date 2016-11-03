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
            dropCurrency.Items.Add(new ListItem("电子积分", "1"));
            dropCurrency.Items.Add(new ListItem("注册积分", "2"));
            dropCurrency.Items.Add(new ListItem("奖金积分", "3"));
            dropCurrency.Items.Add(new ListItem("感恩积分", "4"));
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
        private string GetWhere()
        {
            string strWhere = "IsSell=1AND SurplusAmount>0";
            return strWhere;
        }
        /// <summary>
        ///查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere1()
        {
            decimal NewPrice = getParamAmount("Shares3");//当前价格
            string strWhere = "UserID=" + getLoginID()+"AND Price="+ NewPrice;
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

            lgk.Model.tb_StockIssue issueInfo = stockIssueBLL.GetModel(GetWhere());//获取当前出售的云商积分
            int BuyNumber = int.Parse(txtBuyNum.Text.ToString());//购买数量
            decimal NewPrice = getParamAmount("Shares3");//当前价格
            decimal talPrice = BuyNumber * NewPrice;//购买需要支付金额
            if (issueInfo == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('云商积分已售完');location.href='StockBuyList.aspx';", true);//云商积分已售完
                return;
            }
            if (issueInfo.SurplusAmount < BuyNumber)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('购买数量大于在售数量，请更改购买数量！');location.href='StockBuyList.aspx';", true);//云商积分已售完
                return;
            }

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
            cashbuyinfo.CashsellID = issueInfo.IssueID;//获取挂单ID
            cashbuyinfo.BuyNum = BuyNumber;//model.SaleNum;//购买数量
            cashbuyinfo.Number = BuyNumber;
            cashbuyinfo.UserID = getLoginID();//买家ID
            cashbuyinfo.Price = NewPrice;
            cashbuyinfo.BuyDate = DateTime.Now;
            cashbuyinfo.IsBuy = 1;
            cashbuyBLL.Add(cashbuyinfo);

            UpdateAccount("StockAccount", userInfo.UserID, BuyNumber, 1);//买家云商积分账户更新
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
                joadanInf1.JournalType = 3;//journalType : 1、注册积分，2、奖金积分，3、电子积分，4、云商积分，5、感恩积分，6、购物积分，7、消费积分，8、爱心基金，9、云购积分
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
            lgk.Model.tb_user userInfo = userBLL.GetModel(getLoginID());
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
            string strWhere = "UserID = " + LoginUser.UserID + " AND DATEDIFF (DAY, SellDate, GETDATE()) = 0";
            int a = cashsellBLL.Getalready(strWhere);
            if (a>=ciNum)
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

                    //加入交易记录                                                           
                    lgk.Model.Cashsell cashsellinfo = new lgk.Model.Cashsell();
                    cashsellinfo.UserID = getLoginID();
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

                    
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('卖出成功！');location.href='StockBuyList.aspx';", true);//云商积分已售完
                    return;
                }
            }
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