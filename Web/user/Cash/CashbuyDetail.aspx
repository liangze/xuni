<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashbuyDetail.aspx.cs" Inherits="Web.user.Cash.CashbuyDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../JS/CreditLevel.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="stdform">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="right_content">
            <h2><%=GetLanguage("CommodityInfo")%></h2>
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
                            发布件数：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltUnitNum" runat="server"></asp:Literal>件
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
                            <asp:Literal ID="ltUserCode" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Name")%><%--姓名--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltTrueName" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Depositary") %><%--开户银行--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankName" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("BankAccount")%><%--银行帐号--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankAccount" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("AccountName")%><%--开户姓名--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankAccountUser" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("BankBranch")%><%--开户网点--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankBranch" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("QQNumber")%><%--QQ号码--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltQQnumer" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("ContactPhone")%><%--手机号码--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltPhoneNum" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("CreditRating")%><%--信用等级--%>：
                        </label>
                        <div class="field">
                            &nbsp;
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("SellersRating")%><%--卖家信誉等级--%>：
                        </label>
                        <div class="field">
                            <span style="display: none;" id="userlevel">
                                <asp:Literal ID="ltGrade" runat="server"></asp:Literal>
                            </span>
                            <span id="star"></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="action">
                <asp:Button ID="btnBack" runat="server" Text="返 回" class="btn" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
