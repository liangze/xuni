<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelOrder.aspx.cs" Inherits="Web.user.Cash.CancelOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../JS/ValidateData.js" type="text/javascript"></script>
    <script src="../../JS/CreditLevel.js" type="text/javascript"></script>
</head>
<script language="javascript" type="text/javascript">

    function CheckData() {
        var strRemark = document.getElementById("txtRemark").value;

        if (Trim(strRemark) == "" || Trim(strRemark) == "0") {
            alert("终止原因不能为空！");
            return false;
        }
    }
</script>
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
                            订单编号：
                        </label>
                        <div class="field">
                            <asp:Literal ID="lblOrderCode" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            下订时间：
                        </label>
                        <div class="field">
                            <asp:Literal ID="lbOrderDate" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
            <h6>商品信息：</h6>
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
                            <%=GetLanguage("CommodityPrices")%><%--商品价格--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltAmount" runat="server"></asp:Literal>
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
                            <asp:Literal ID="ltPrice" runat="server"></asp:Literal>
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
            <h6>卖家信息：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            银行帐号：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankAccount" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            开户姓名：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankAccountUser" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            银行支行：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankBranch" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
            <h6>信用等级：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <asp:Literal ID="ltCredit" runat="server"></asp:Literal>：
                        </label>
                        <div class="field">
                            <span style="display: none;" id="userlevel">
                                <asp:Literal ID="ltGrade" runat="server"></asp:Literal>
                            </span>
                            <span id="star"></span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span class="cRed">*</span>终止原因：
                        </label>
                        <div class="field">
                            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="280px" Height="80px"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="action">
                <asp:Button ID="btnCancel" runat="server" Text="终止交易" class="btn" OnClick="btnCancel_Click" />&nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="返 回" class="btn" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
