<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dl_JournalAccount.aspx.cs"
    Inherits="Web.user.finance.dl_JournalAccount" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>账户明细</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("AccountsQueries")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <asp:Button ID="btnDetail" runat="server" Text="搜 索" class="btn" OnClick="btnDetail_Click" />
                    </p>
                </div>
            </div>
            <div>&nbsp;</div>
            <table class="styled">
                <thead>
                    <tr>
                        <th align="center">
                            <%=GetLanguage("BusinessSummary")%>
                        </th>
                        <th align="center">
                            <%=GetLanguage("AccountTypes")%>
                        </th>
                        <th align="center"><%=GetLanguage("CurrencyType")%><%--币种--%>
                        </th>
                        <th align="center">
                            <%=GetLanguage("AccountAmount")%>
                        </th>
                        <th align="center">
                            <%=GetLanguage("TheBalanceOf")%>
                        </th>
                        <th align="center">
                            <%=GetLanguage("Date")%>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                   
                                    <%#Eval("Remark")%><%-- 详情--%>
                                   
                                </td>
                                <td align="center">
                                    <%#AccountType(Eval("InAmount").ToString())%>
                                </td>
                                <td align="center">
                                    <%#GoldType(Eval("JournalType").ToString())%>
                                </td>
                                <td align="center">
                                    <%#AccountType(Eval("InAmount").ToString()) == "支出" ? Eval("OutAmount") : Eval("InAmount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BalanceAmount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("JournalDate")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="6" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%></span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True"
                    InputBoxClass="pageinput" NumericButtonCount="3" PageSize="12" ShowInputBox="Never"
                    ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"
                    pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="" Direction="LeftToRight"
                    OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
