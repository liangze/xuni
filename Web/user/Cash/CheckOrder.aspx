<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckOrder.aspx.cs" Inherits="Web.user.Cash.CheckOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server" class="stdform">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="right_content">
            <h2><%=GetLanguage("OrderDetails")%><%--订单明细--%></h2>
            <h6><%=GetLanguage("OrderInformation")%><%--订单信息--%>：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("OrderNumber")%><%--订单编号--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltOrderCode" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("OrderTime")%><%--下订时间--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltOrderDate" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("BuyNote")%><%--购买备注--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBRemark" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("SalesNote")%><%--销售备注--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltSRemark" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group" style="display: none;">
                        <label for="memid">
                            发布件数：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltUnitNum" runat="server"></asp:Literal>件
                        </div>
                    </div>
                </div>
            </div>
            <h6><%=GetLanguage("CommodityInfo")%><%--商品信息--%>：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("TitleGoods")%><%--商品标题--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Quantity")%><%--商品数量--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltNumber" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("CommodityPrices")%><%--商品价格--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltPrice" runat="server"></asp:Literal>RMB
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("GoodsAmount")%><%--商品金额--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltAmount" runat="server"></asp:Literal>RMB
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("QuantityPayment")%><%--付款数量--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltPayment" runat="server"></asp:Literal>个
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("QuantityArrival")%><%--到账数量--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltArrival" runat="server"></asp:Literal>个
                        </div>
                    </div>
                    <div class="control-group" style="display: none;">
                        <label for="memid">
                            购买件数：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBuyNum" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
            <h6><%=GetLanguage("SellerInfo")%><%--卖家信息--%>：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("MembershipNumber")%><%--会员编号--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltSUserCode" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Name")%><%--卖家银行姓名--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltSTrueName" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Depositary")%><%--卖家开户银行--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltSBankName" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("BankAccount")%><%--卖家银行帐号--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltSBankAccount" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("AccountName")%><%--卖家银行姓名--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltSBankAccountUser" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("BankBranch")%><%--卖家开户网点--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltSBankBranch" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("QQNumber")%><%--卖家QQ号码--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltSQQnumer" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("ContactPhone")%><%--卖家手机号码--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltSPhoneNum" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <asp:Literal ID="ltCredit" runat="server"></asp:Literal>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltGrade" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
            <div class="action">
                <asp:Button ID="btnCheck" runat="server" class="btn" OnClick="btnCheck_Click" />&nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="返 回" class="btn" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
