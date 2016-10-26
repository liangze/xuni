<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="Web.user.shop.order" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的订单</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("MyOrder")%><%--我的订单--%></h2>
            <div class="filter">
                <h2>
                    <a href="order.aspx?type=1" class="butSize btn"><%=GetLanguage("AllRecords")%><!--所有记录--></a>
                    <a href="order.aspx?type=2" class="butSize btn"><%=GetLanguage("Non-payment")%><!--未付款--></a>
                    <a href="order.aspx?type=3" class="butSize btn"><%=GetLanguage("ToBeShipped")%><!--待发货--></a>
                    <a href="order.aspx?type=4" class="butSize btn"><%=GetLanguage("Shipped")%><!--已发货--></a>
                    <a href="order.aspx?type=5" class="butSize btn"><%=GetLanguage("Completed")%><!--已完成--></a>
                </h2>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th align="center">
                            <%=GetLanguage("Time")%><!--时间-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("OrderNumber")%><!--订单号-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("LoginInformation")%><!--会员编号-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("PurchaseQuantity")%><!--购买数量-->
                        </th>
                        <th align="center"><%=GetLanguage("TheTotalAmount")%><!--总金额-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("ContactPhone")%><!--联系电话-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("Express")%><!--快递公司-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("ExpressOrder")%><!--快递单号-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("PaymentType")%><!--支付类型-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("State")%><!--状态-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("Operation")%><!--操作-->
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                        OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%#Convert.ToDateTime(Eval("OrderDate")).ToString("yyyy-MM-dd HH:mm:ss")%>
                                </td>
                                <td align="center">
                                    <%#Eval("OrderCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("OrderSum")%>
                                </td>
                                <td align="center">
                                    <%#Eval("OrderTotal")%>
                                </td>
                                <td align="center">
                                    <%#Eval("PhoneNum")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Order3")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Order4")%>
                                </td>
                                <td align="center">
                                    <% if (Language == "zh-cn")
                                       { %>
                                购物币
                            <% }
                                       else
                                       { %>
                              Shopping currency
                            <% }%>
                                
                                </td>
                                <td align="center">
                                    <%#GetState(Eval("IsSend").ToString())%>
                                </td>
                                <td align="center">&nbsp;
                                <asp:HiddenField ID="hft" runat="server" Value='<%# Eval("IsSend") %>' />
                                    <asp:LinkButton ID="lbtnPayment" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                        CommandName="Payment"></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnReceipt" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                        CommandName="Receipt" Visible="false"></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnDetail" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                        CommandName="Detail"><%=GetLanguage("OrderDetails")%><!--订单明细--></asp:LinkButton>&nbsp;/
                                <asp:LinkButton ID="lbtnCancel" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                    CommandName="cancel" OnClientClick="javascript:return confirm('确定删除订单？')" Visible='<%#Convert.ToInt32(Eval("IsSend")) < 2?true:false%>'><%=GetLanguage("Delete")%><!--删除--></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr runat="server" id="tr1">
                    <td colspan="11" align="center">
                        <div id="divno" runat="server" class="NoData">
                            <span class="cBlack"><%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" OnPageChanged="AspNetPager1_PageChanged"
                    AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                    PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                    UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>