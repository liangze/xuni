using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Library;
using IPSVERIFYLib;
using Web.user.shop;

/// <summary>
/// ���׳ɹ�����ҳ��
/// </summary>
public partial class OrderReturn : System.Web.UI.Page
{
    AllCore ac = new AllCore();
    lgk.Model.tb_user LoginUser = null;
    int payment = 3;//֧����ʽ��1-����֧����2-E��֧��

    private void Page_Load(object sender, System.EventArgs e)
    {
        int loginid = getLoginID();
        LoginUser = ac.userBLL.GetModel(long.Parse(loginid.ToString()));

        //��������
        string billno = Request["billno"];
        string amount = Request["amount"];
        string currency_type = Request["Currency_type"];
        string mydate = Request["date"];
        string succ = Request["succ"];
        string msg = Request["msg"];
        string attach = Request["attach"];
        string ipsbillno = Request["ipsbillno"];
        string retEncodeType = Request["retencodetype"];
        string signature = Request["signature"];
        string bankbillno = Request["bankbillno"];

        //ǩ��ԭ��
        //billno+��������š�+currencytype+�����֡�+amount+��������+date+���������ڡ�+succ+���ɹ���־��+ipsbillno+��IPS������š�+retencodetype +�����׷���ǩ����ʽ��
        string content = "billno" + billno + "currencytype" + currency_type + "amount" + amount + "date" + mydate + "succ" + succ + "ipsbillno" + ipsbillno + "retencodetype" + retEncodeType;

        //ǩ���Ƿ���ȷ
        Boolean verify = false;

        //��֤��ʽ��16-md5withRSA  17-md5
        if (retEncodeType == "16")
        {
            string pubfilename = "C:\\PubKey\\publickey.txt";
            RSAMD5Class m_RSAMD5Class = new RSAMD5Class();
            int result = m_RSAMD5Class.VerifyMessage(pubfilename, content, signature);

            //result=0   ��ʾǩ����֤�ɹ�
            //result=-1  ��ʾϵͳ����
            //result=-2  ��ʾ�ļ��󶨴���
            //result=-3  ��ʾ��ȡ��Կʧ��
            //result=-4  ��ʾǩ�����ȴ�
            //result=-5  ��ʾǩ����֤ʧ��
            //result=-99 ��ʾϵͳ����ʧ��
            if (result == 0)
            {
                verify = true;
            }
        }
        else if (retEncodeType == "17")
        {
            //��½http://merchant.ips.com.cn/�̻���̨���ص��̻�֤������
            string merchant_key = "40301353982421808762056564364329661849129129580266796478374708865375995863383797310863218357532035320426083319557639800106764832";
            //string merchant_key = "GDgLwwdK270Qj1w4xho8lyTpRQZV9Jm5x4NwWOTThUa4fMhEBK9jOXFrKRT6xhlJuU2FEa89ov0ryyjfJuuPkcGzO5CeVx5ZIrkkt1aBlZV36ySvHOMcNv8rncRiy3DQ";
            //Md5ժҪ
            string signature1 = FormsAuthentication.HashPasswordForStoringInConfigFile(content + merchant_key, "MD5").ToLower();

            if (signature1 == signature)
            {
                verify = true;
            }

        }

        //�ж�ǩ����֤�Ƿ�ͨ��
        if (verify == true)
        {
            //�жϽ����Ƿ�ɹ�
            if (succ != "Y")
            {
                Response.Write("����ʧ�ܣ�");
                Response.End();
            }
            else
            {
                /****************************************************************
				//�ȽϷ��صĶ����źͽ���������ݿ��еĽ���Ƿ����			
				if(����)
                {
                    Response.Write("��IPS���ص����ݺͱ��ؼ�¼�Ĳ����ϣ�ʧ�ܣ�");
					Response.End(); 
                }
                else
                {
					Reponse.Write("���׳ɹ��������������ݿ⣡");
				}
                ****************************************************************/
                if (attach == "remit")
                {
                    string dt = billno.Substring(0, 14);
                    string id = billno.Substring(19);
                    DateTime addTime = DateTime.Now;
                    DateTime.TryParse(dt, out addTime);
                    long remitID = 0;
                    long.TryParse(id, out remitID);
                    lgk.BLL.tb_remit remitBLL = new lgk.BLL.tb_remit();
                    lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
                    lgk.BLL.tb_journal journalBLL = new lgk.BLL.tb_journal();

                    var remit = remitBLL.GetModel(remitID);
                    if (remit != null && remit.State == 0)
                    {
                        AllCore allCoreBLL = new AllCore();
                        remit.State = 1;
                        //������ˮ�˱�
                        lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                        jmodel.UserID = remit.UserID;
                        jmodel.Remark = "���߳�ֵE��";
                        jmodel.InAmount = remit.RemitMoney;
                        jmodel.OutAmount = 0;
                        jmodel.BalanceAmount = userBLL.GetModel(Convert.ToInt32(remit.UserID)).Emoney + remit.RemitMoney;
                        jmodel.JournalDate = DateTime.Now;
                        jmodel.JournalType = 2;
                        jmodel.Journal01 = remit.UserID;
                        if (remitBLL.Update(remit) && journalBLL.Add(jmodel) > 0 && allCoreBLL.UpdateSystemAccount("MoneyAccount", remit.RemitMoney, 1) > 0 && allCoreBLL.UpdateAccount("Emoney", remit.UserID, remit.RemitMoney, 1) > 0)
                        {
                            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('ȷ�ϳɹ�!');", true);
                            Response.Write("���׳ɹ���");
                        }
                        else
                        {
                            Response.Write("��ֵ��¼����ʧ�ܣ�");
                            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('ȷ��ʧ��!');", true);
                        }
                    }
                    else
                    {
                        Response.Write("��ֵ��¼�����ڻ���Ϣ�쳣��");
                    }
                }
                else if (attach == "shoppingcar")
                {
                    PayOnline(true);
                }
                Response.End();
            }
        }
        else
        {
            Response.Write("ǩ������ȷ��");
        }
    }

    protected string GetOrderID()
    {
        while (1 == 1)
        {
            string code = DateTime.Now.ToString("yyyyMMdd");
            Random rad = new Random();//ʵ���������������rad��
            int codeValue = rad.Next(1000, 10000);//��rad���ɴ��ڵ���1000��С�ڵ���9999���������
            code += codeValue.ToString();

            if (ac.GetOrderID(code) == 0)
            {
                return code;
            }
        }
    }

    /// <summary>
    /// ��ȡ��ǰ��¼������ID
    /// </summary>
    /// <returns></returns>
    public int getLoginID()
    {
        if (Request.Cookies["A128076_user"] != null)
        {
            return Convert.ToInt32(Request.Cookies["A128076_user"]["Id"]);
        }
        else
        {
            return 0;
        }
    }

    //����֧���ɹ���ʧ�ܺ󣬶�ϵͳ�Ĳ���
    protected void PayOnline(bool bresult)
    {
        decimal money = 0;
        decimal jifen = 0;

        DataTable car = (DataTable)Session["A128076_" + getLoginID() + "_ShoppingCar"];

        int rows = car.Rows.Count;
        int count = 0;
        for (int i = 0; i < rows; i++)
        {
            if (Convert.ToInt32(car.Rows[i]["payMent"]) == payment)
            {
                count += Convert.ToInt32(car.Rows[i]["count"]);
                money += Convert.ToDecimal(car.Rows[i]["totalMoney"]);
                jifen += Convert.ToDecimal(car.Rows[i]["totalPV"]);
            }
        }

        bool b = true;
        string orderID = GetOrderID();//�γ�һ��������¼�����붩����
        for (int i = 0; i < rows; i++)
        {
            if (Convert.ToInt32(car.Rows[i]["payMent"]) == payment)
            {
                lgk.Model.tb_goods model_goods = ac.goodsBLL.GetModel(Convert.ToInt32(car.Rows[i]["ProcudeID"]));
                if (model_goods.RealityPrice < Convert.ToInt32(car.Rows[i]["count"]))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('��" + model_goods.GoodsName + "��" + ac.GetLanguage("LowStock") + "!');", true);//��治��
                    b = false;
                    break;
                }
                else
                {
                    lgk.Model.tb_OrderDetail detail = new lgk.Model.tb_OrderDetail()
                    {
                        OrderCode = orderID,
                        ProcudeID = Convert.ToInt32(car.Rows[i]["ProcudeID"]),
                        ProcudeName = car.Rows[i]["procudeName"].ToString(),
                        Price = Convert.ToDecimal(car.Rows[i]["Goods006"]),
                        PV = Convert.ToInt32(car.Rows[i]["Goods002"]),
                        OrderSum = Convert.ToInt32(car.Rows[i]["count"]),
                        OrderTotal = Convert.ToDecimal(car.Rows[i]["totalMoney"]),
                        PVTotal = Convert.ToInt32(car.Rows[i]["totalPV"]),
                        OrderDate = DateTime.Now
                    };
                    if (ac.orderDetailBLL.Add(detail) == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + ac.GetLanguage("AddFailed") + "');", true);//���ʧ��
                        b = false;
                        break;
                    }
                }
            }
        }
        if (b)
        {
            int OrderType = 5;

            lgk.Model.tb_Order order = new lgk.Model.tb_Order()
            {
                UserID = LoginUser.UserID,
                UserAddr = LoginUser.Address,
                OrderCode = orderID,
                OrderSum = count,
                OrderTotal = money,
                PVTotal = jifen,
                OrderDate = DateTime.Now,
                IsSend = 1,
                PayMethod = 2,
                OrderType = OrderType,
            };
            if (bresult == true)//����֧���ɹ�����Ӷ��������ݿ⣻���ع��ﳵ����գ�
            {
                long id = ac.orderBLL.Add(order);//��������¼���붩����
                if (id == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + ac.GetLanguage("OrderToFailed") + "');", true);//��Ӷ���ʧ��
                    b = false;
                    return;
                }
                new lgk.BLL.tb_user().Update(LoginUser);

                ac.add_journal(getLoginID(), 0, jifen, Convert.ToDecimal(LoginUser.Emoney), 5, "�����ύ����", "Submit shopping order", getLoginID());

                Session["NN1405501_" + getLoginID() + "_ShoppingCar"] = null;

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + ac.GetLanguage("TradesSuccessfully") + "');", true);

                //Response.Write("<script>window.open('../../user/shop/shoppingcar.aspx?payment=" + payment + ")</script>");
                Response.Redirect("../user/shop/shoppingcar.aspx?payment=" + payment);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + ac.GetLanguage("TradesFailed") + "');", true);

                Response.Redirect("../user/shop/shoppingcar.aspx?payment=" + payment);//֧��ʧ�ܣ�����Ӷ��������ݿ⣻���ع��ﳵ������գ�
            }

        }
    }

}