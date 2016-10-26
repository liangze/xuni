using Library;
using System;
using System.Data;
using System.IO;


/*
收款啦配置参数，官方网站：pay.chonty.com
方式：POST
参数：
title：标题(网站订单号)
order：订单号
money：金额
sign：密钥
user：姓名
time：时间

$out_trade_no=trim($_POST['title']);//商户订单号
$total_fee   =trim($_POST['money']);//收款金额
$trade_no    =trim($_POST['order']);//支付宝订单号
$sign        =trim($_POST['sign']);//回调签名 
*/
namespace Web.Pay
{
    public partial class OrderReturn : AllCore//System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            //接收数据
            string out_trade_no = Request["title"];//商户订单号
            string total_fee = Request["money"];//收款金额
            string trade_no = Request["order"];//支付宝订单号
            string sign = Request["sign"];//回调签名 

            //签名是否正确
            Boolean verify = false;

            //通讯秘钥
            string SecretKey = getParamVarchar("SecretKey");

            //验证方式：12-md5
            if (sign == SecretKey)
            {
                verify = true;
            }

            string fileorder = AppDomain.CurrentDomain.BaseDirectory + "\\order.txt";

            FileStream file = new FileStream(fileorder, File.Exists(fileorder) ? FileMode.Append : FileMode.OpenOrCreate);

            //判断签名验证是否通过
            if (verify == true)
            {

                /****************************************************************
                //比较返回的订单号和金额与您数据库中的金额是否相符			
                if(不等)
                {
                    Response.Write("从IPS返回的数据和本地记录的不符合，失败！");
                    Response.End(); 
                }
                else
                {
                    Reponse.Write("交易成功，处理您的数据库！");
                }
                ****************************************************************/

                StreamWriter writer = new StreamWriter(file);

                writer.WriteLine("浏览器,交易成功," + "商户订单号：" + out_trade_no + "， IPS订单号：" + trade_no + "，  金额：" + total_fee + "， 记录时间：" + DateTime.Now.ToString());
                writer.Close();

                //lgk.BLL.tb_remit remitBLL = new lgk.BLL.tb_remit();
                //lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
                //lgk.BLL.tb_journal journalBLL = new lgk.BLL.tb_journal();

                //在线充值记录  用订单号查
                DataSet remitOnline = rechargeBLL.GetList(1, string.Format(" Recharge003 ='{0}'", out_trade_no), "Recharge003");

                if (remitOnline.Tables[0].Rows.Count > 0)
                {
                    int id = int.Parse(remitOnline.Tables[0].Rows[0]["ID"].ToString());
                    int state = int.Parse(remitOnline.Tables[0].Rows[0]["Flag"].ToString());  //状态  是否成功 0：正在充值状态  1:成功

                    if (state == 0)
                    {
                        //获取在线充值订单实体
                        lgk.Model.tb_recharge recharge = rechargeBLL.GetModel(id);

                        //标记 为在线充值成功。
                        recharge.Flag = 1;
                        //加入流水账表
                        lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                        jmodel.UserID = recharge.UserID;
                        jmodel.Remark = "在线充值电子币";
                        jmodel.InAmount = recharge.RechargeableMoney;
                        jmodel.OutAmount = 0;
                        jmodel.BalanceAmount = userBLL.GetModel(recharge.UserID).Emoney + recharge.RechargeableMoney;
                        jmodel.JournalDate = DateTime.Now;
                        jmodel.JournalType = 2;
                        jmodel.Journal01 = recharge.UserID;
                        if (rechargeBLL.Update(recharge) && journalBLL.Add(jmodel) > 0 && UpdateSystemAccount("MoneyAccount", recharge.RechargeableMoney, 1) > 0 && UpdateAccount("Emoney", recharge.UserID, recharge.RechargeableMoney, 1) > 0)
                        {
                            file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\order.txt", FileMode.OpenOrCreate);
                            writer = new StreamWriter(file);
                            writer.WriteLine("浏览器,数据更新成功," + "商户订单号：" + out_trade_no + "， IPS订单号：" + trade_no + "，  金额：" + total_fee + "， 记录时间：" + DateTime.Now.ToString());
                            writer.Close();

                           // InfoImg.ImageUrl = "/images/agt_action_success.png";
                           // message.Text = "交易成功！";
                            Response.Write("success");
                        }
                        else
                        {
                            writer = new StreamWriter(file);
                            writer.WriteLine("浏览器,数据更新失败！," + "商户订单号：" + out_trade_no + "， IPS订单号：" + trade_no + "， 金额：" + total_fee + "， 记录时间：" + DateTime.Now.ToString());
                            writer.Close();

                           // InfoImg.ImageUrl = "/images/error64.png";
                          //  message.Text = "交易失败！#2";
                             Response.Write("交易失败！");
                        }
                    }
                    else
                    {
                        writer = new StreamWriter(file);
                        writer.WriteLine("浏览器,已更新成功！," + "商户订单号：" + out_trade_no + "， IPS订单号：" + trade_no + "， 金额：" + total_fee + "，记录时间：" + DateTime.Now.ToString());
                        writer.Close();
                        Response.Write("success");
                        //InfoImg.ImageUrl = "/images/agt_action_success.png";
                        //message.Text = "交易成功！";
                    }

                }
                else
                {
                    writer = new StreamWriter(file);
                    writer.WriteLine("浏览器,订单不匹配，交易失败！," + "商户订单号：" + out_trade_no + "， IPS订单号：" + trade_no + "，  金额：" + total_fee + "，记录时间：" + DateTime.Now.ToString());
                    writer.Close();
                    Response.Write("交易失败!");
                    //InfoImg.ImageUrl = "/images/error64.png";
                    //message.Text = "交易失败！";
                }

                Response.End();

                //#############################################################
                //以上代码仅作参考，此处可增加商户逻辑
                //#############################################################

            }
            else
            {
                StreamWriter writer = new StreamWriter(file);
                writer.WriteLine("浏览器,签名不正确!," + "商户订单号：" + out_trade_no + "， IPS订单号：" + trade_no + "，  金额：" + total_fee + "，  记录时间：" + DateTime.Now.ToString());
                writer.Close();
                Response.Write("签名不正确");
                Response.End();
                // Response.Write("签名不正确！");
                //InfoImg.ImageUrl = "/images/error64.png";
               // message.Text = "签名不正确！";
            }
        }
    }
}