<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashsellList.aspx.cs" Inherits="Web.user.Cash.CashsellList" %>

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
            <h2><%=GetLanguage("SellRecords")%></h2>
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
                        <th align="center"><%=GetLanguage("ReleaseTime")%><%--发布时间--%>
                        </th>
                        <th align="center"><%=GetLanguage("State")%><%--状态--%>
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
                                <td><asp:Literal ID="ltStatus" runat="server"></asp:Literal></td>
                                <td align="center">
                                    <%if (currentCulture != "en-us")
                                      {%>
                                    <asp:LinkButton ID="lbtnCancel" class="btn" runat="server" CommandArgument='<%# Eval("CashsellID") %>'
                                        CommandName="cancel" OnClientClick="javascript:return confirm('确认取消吗？')"><%=GetLanguage("Cancel")%><!--取消--></asp:LinkButton>
                                    <%}
                                      else
                                      {%>
                                    <asp:LinkButton ID="lbtnCancelEn" runat="server" class="btn" CommandArgument='<%# Eval("CashsellID") %>'
                                        CommandName="cancel" OnClientClick="javascript:return confirm('Confirm to cancel?')"><%=GetLanguage("Cancel")%><!--取消--></asp:LinkButton>
                                    <%} %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="9">
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
