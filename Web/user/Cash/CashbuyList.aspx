﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashbuyList.aspx.cs" Inherits="Web.user.Cash.CashbuyList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="right_content">
            <h2><%=GetLanguage("BuyRecords")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("ReleaseTime")%><!--发布时间-->：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" tip="发布时间" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtStartEn" tip="Release time" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtEnd" tip="" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEndEn" tip="Release time" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn" />
                    </p>
                </div>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th align="center"><%=GetLanguage("Buyers")%><%--买家--%>
                        </th>
                        <th align="center"><%=GetLanguage("Seller")%><%--卖家--%>
                        </th>
                        <th align="center"><%=GetLanguage("SellerRatings")%><%--卖家评分--%>
                        </th>
                        <th align="center"><%=GetLanguage("CommodityInfo")%><%--商品信息--%>
                        </th>
                        <th align="center"><%=GetLanguage("SellCount")%><%--卖出数量--%>
                        </th>
                        <th align="center"><%=GetLanguage("CommodityPrices")%><%--商品单价--%>
                        </th>
                        <th align="center"><%=GetLanguage("AmountOfPurchase")%><%--购买金额--%>
                        </th>
                        <th align="center"><%=GetLanguage("QuantityPayment")%><%--付款数量--%>
                        </th>
                        <th align="center"><%=GetLanguage("QuantityArrival")%><%--到账数量--%>
                        </th>
                        <th align="center"><%=GetLanguage("PurchaseTime")%><%--购买时间--%>
                        </th>
                        <th align="center"><%=GetLanguage("State")%><%--状态--%>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <asp:Literal ID="ltBUserCode" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltSUserCode" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltSValues" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <a href="CashbuyDetail.aspx?CashsellID=<%#Eval("CashsellID")%>">
                                        <%=GetLanguage("DetailsView")%></a>
                                </td>
                                <td align="center">
                                    <%#Convert.ToDecimal(Eval("Number")) + (Convert.ToDecimal(Eval("Number")) * getParamAmount("Gold2") / 100)%>
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
                                    <%#Eval("BuyDate")%>
                                </td>
                                <td>
                                    <asp:Literal ID="ltIsBuy" runat="server"></asp:Literal></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="11">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" OnPageChanged="AspNetPager1_PageChanged"
                    AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3" PageSize="10"
                    ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                    UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
