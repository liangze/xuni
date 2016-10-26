<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dl_JournalEmoney.aspx.cs" Inherits="Web.user.finance.dl_JournalEmoney" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=GetLanguage("Electronic")%></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("PersonalAccount")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("CurrencyType")%><!--币种-->：</label>
                        <span class="field">
                            <asp:DropDownList ID="dropCurrency" runat="server"></asp:DropDownList>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("Date")%>：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtStartEn" runat="server" class="input_select" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtEnd" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEndEn" runat="server" class="input_select" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" class="btn" OnClick="btnSearch_Click" />&nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" class="btn" Text="返回" OnClick="btnBack_Click" />
                    </p>
                </div>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th><%=GetLanguage("BusinessSummary")%></th>
                        <th><%=GetLanguage("AccountTypes")%></th>
                        <th><%=GetLanguage("CurrencyType")%><!--币种--></th>
                        <th><%=GetLanguage("AccountAmount")%></th>
                        <th><%=GetLanguage("TheBalanceOf")%></th>
                        <th><%=GetLanguage("Date")%></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="left">
                                    <%if (Language == "zh-cn") %>
                                    <%{ %>
                                    <%#Eval("Remark")%><%-- 详情--%>
                                    <%}
                                      else
                                      { %>
                                    <%#Eval("Remarken")%><%-- 详情--%>
                                    <%} %>
                                </td>
                                <td align="left"><%#AccountType(Eval("InAmount").ToString())%></td>
                                <td align="left"><%#GoldType(Eval("JournalType").ToString())%></td>
                                <td align="left">
                                    <%#AccountType(Eval("InAmount").ToString()) == "支出" ? Eval("OutAmount") : Eval("InAmount")%>
                                </td>
                                <td align="left">
                                    <%#Eval("BalanceAmount")%>
                                </td>
                                <td align="left">
                                    <%#Eval("JournalDate")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="12" align="center">
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
