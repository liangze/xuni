<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellEdit.aspx.cs" Inherits="Web.user.Stock.SellEdit" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="box box_width">
            <div class="capositon">
                <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("Financial")%>>><a href="javascript:void(0)">卖出股票</a>
            </div>
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">等待卖出的股票</legend>购买时间：<asp:TextBox ID="txtStart" tip="输入购买日期" runat="server" onfocus="new WdatePicker();"
                        class="input_select"></asp:TextBox>&nbsp;至&nbsp;<asp:TextBox ID="txtEnd" tip="输入购买日期" class="input_select" runat="server" onfocus="new WdatePicker();"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="ltReminder" runat="server"></asp:Literal>
                </fieldset>
            </div>
            <div class="dataTable" align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">购买金额
                        </th>
                        <th align="center">购进价格
                        </th>
                        <th align="center">当前持股数
                        </th>
                        <th align="center">购进时拆分次数
                        </th>
                        <th align="center">购买时间
                        </th>
                        <th align="center">状态
                        </th>
                        <th align="center">操作
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("Amount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BuyPrice")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Number")%>
                                </td>
                                <td align="center">
                                    <%#Eval("SplitNum")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BuyDate")%>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltIsSell" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnBuy" runat="server" class="btn" CommandName="Buy" CommandArgument='<%#Eval("StockID")%>' OnClientClick="return confirm('确认卖出吗？')">卖出</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="4">
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
        </div>
    </form>
</body>
</html>
