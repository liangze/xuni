<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashOrderList.aspx.cs" Inherits="Web.user.Cash.CashOrderList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" language="javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="right_content">
            <h2><%=GetLanguage("MyOrder")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("OrderNumber")%><%--订单编号--%>：</label>
                        <span class="field">
                            <asp:TextBox ID="txtOrderCode" runat="server" class="input_select"></asp:TextBox>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("OrderType")%><%--订单类型--%>：</label>
                        <span class="field">
                            <asp:DropDownList ID="dropOrderType" class="input_select" runat="server">
                            </asp:DropDownList></span>
                    </p>
                </div>
            </div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("ReleaseTime")%><!--发布时间-->：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" tip="下订日期" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtStartEn" tip="Set date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtEnd" tip="下订日期" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEndEn" tip="Set date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
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
                        <th align="center"><%=GetLanguage("OrderNumber")%><%--订单编号--%>
                        </th>
                        <th align="center"><%=GetLanguage("CommodityPrice")%><%--商品价格--%>
                        </th>
                        <th align="center"><%=GetLanguage("Quantity")%><%--商品数量--%>
                        </th>
                        <th align="center"><%=GetLanguage("QuantityPayment")%><%--付款数量--%>
                        </th>
                        <th align="center"><%=GetLanguage("QuantityArrival")%><%--到账数量--%>
                        </th>
                        <th align="center"><%=GetLanguage("OrderTime")%><%--下订时间--%>
                        </th>
                        <th align="center"><%=GetLanguage("State")%><%--订单状态--%>
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
                                    <a href="CashOrderDetail.aspx?OrderID=<%#Eval("OrderID")%>">
                                        <%# Eval("OrderCode")%></a>
                                </td>
                                <td align="center">
                                    <%#Eval("Amount")%>
                                </td>
                                <td align="center">
                                    <%#Convert.ToDecimal(Eval("Number")) + (Convert.ToDecimal(Eval("Number")) * getParamAmount("Gold2") / 100)%>
                                </td>
                                <td align="center">
                                    <%#Eval("Number")%>
                                </td>
                                <td align="center">
                                    <%#Convert.ToDecimal(Eval("Number")) + (Convert.ToDecimal(Eval("Number")) * getParamAmount("Gold3") / 100)%>
                                </td>
                                <td align="center">
                                    <%#Eval("OrderDate")%>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltStatus" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <%if (currentCulture == "en-us")
                                      {%>
                                    <asp:LinkButton ID="lbtnPayforEn" runat="server" CommandArgument='<%# Eval("OrderID") %>'
                                        Visible='true' CommandName="Payfor" OnClientClick="javascript:return confirm('Confirm payment?')" class="btn"><%=GetLanguage("Payment")%><!--付款--></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnSendoutEn" runat="server" class="btn" CommandName="Sendout" CommandArgument='<%#Eval("OrderID")%>' OnClientClick="return confirm('Has confirmed the payment?')"><%=GetLanguage("ConfirmPayment")%><%--确认已付款--%></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnUndoneEn" runat="server" CommandArgument='<%# Eval("OrderID") %>' CommandName="Undone" OnClientClick="javascript:return confirm('Confirmation revocation?')" class="btn">Revoke</asp:LinkButton>
                                    <%}
                                      else
                                      {%>
                                    <asp:LinkButton ID="lbtnPayfor" runat="server" CommandArgument='<%# Eval("OrderID") %>'
                                        Visible='true' CommandName="Payfor" OnClientClick="javascript:return confirm('确认付款吗？')" class="btn"><%=GetLanguage("Payment")%><!--付款--></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnSendout" runat="server" class="btn" CommandName="Sendout" CommandArgument='<%#Eval("OrderID")%>' OnClientClick="return confirm('已确认付款了吗？')"><%=GetLanguage("ConfirmPayment")%><%--确认已付款--%></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnUndone" runat="server" CommandArgument='<%# Eval("OrderID") %>' CommandName="Undone" OnClientClick="javascript:return confirm('确认撤销吗？')" class="btn">撤销</asp:LinkButton>
                                    <%} %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="6">
                        <div class="NoData">
                            <span class="cBlack">
                                <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
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
