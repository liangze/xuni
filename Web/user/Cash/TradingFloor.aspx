<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TradingFloor.aspx.cs" Inherits="Web.user.Cash.TradingFloor" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("TradingFloor")%></h2>
            <div class="filter">
                <h2>
                    <a href="Cashsell.aspx" class="btn"><%=GetLanguage("CommissionedSell")%><%--委托卖出--%></a>
                    <a href="CashsellList.aspx" class="btn"><%=GetLanguage("SellRecords")%><%--卖出记录--%></a>
                    <a href="CashbuyList.aspx" class="btn"><%=GetLanguage("BuyRecords")%><%--购买记录--%></a>
                    <a href="Cashbuy.aspx" class="btn"><%=GetLanguage("More")%><%--更多--%></a>
                </h2>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th align="center"><%=GetLanguage("Seller")%><%--卖家--%>
                        </th>
                        <th align="center"><%=GetLanguage("SellerRatings")%><%--卖家评分--%>
                        </th>
                        <th align="center"><%=GetLanguage("CommodityInfo")%><%--商品信息--%>
                        </th>
                        <th align="center"><%=GetLanguage("Quantity")%><%--商品数量--%>
                        </th>
                        <th align="center"><%=GetLanguage("CommodityPrices")%><%--商品单价--%>
                        </th>
                        <th align="center"><%=GetLanguage("GoodsAmount")%><%--商品金额--%>
                        </th>
                        <th align="center"><%=GetLanguage("QuantityPayment")%><%--付款数量--%>
                        </th>
                        <th align="center"><%=GetLanguage("QuantityArrival")%><%--到账数量--%>
                        </th>
                        <th align="center"><%=GetLanguage("EntrustmentDate")%><%--委托日期--%>
                        </th>
                        <th align="center"><%=GetLanguage("Operation")%><%--操作--%>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%# Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltSValues" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <a href="CashbuyDetail.aspx?CashsellID=<%#Eval("CashsellID")%>">
                                        <%=GetLanguage("DetailsView")%></a>
                                </td>
                                <td align="center">
                                    <%#Convert.ToDecimal(Eval("Number")) + Convert.ToDecimal(Eval("Charge"))%>
                                </td>
                                <td align="center">
                                    <%#Eval("Price")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Amount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Number")%>
                                </td>
                                <td align="center">
                                    <%#Convert.ToDecimal(Eval("Number")) + (Convert.ToDecimal(Eval("Number")) * getParamAmount("Gold3") / 100)%>
                                </td>
                                <td align="center">
                                    <%#Eval("SellDate")%>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnBuy" runat="server" CommandName="Buyinto" CommandArgument='<%#Eval("CashsellID") %>'
                                        class="btn" iconcls="icon-ok"><%=GetLanguage("Buy")%><%--购买--%></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="10" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    <%=GetLanguage("Manager")%></span>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="nextpage cBlack">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True"
                    InputBoxClass="pageinput" NumericButtonCount="3" PageSize="12" ShowInputBox="Never"
                    ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"
                    pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="" Direction="LeftToRight"
                    HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
