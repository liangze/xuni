<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bonusa.aspx.cs" Inherits="Web.user.Stock.Bonusa" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>股票奖金结算</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class="capositon">
            <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("Financial")%>>><a href="javascript:void(0)"><%=GetLanguage("BonusSettlement")%></a>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        会员编号
                    </th>
                    <th align="center">
                        A盘资金
                    </th>
                    <th align="center">
                        当前持股数
                    </th>
                    <th align="center">
                        购进价格
                    </th>
                    <th align="center">
                        当前股价
                    </th>
                    <th align="center">
                        可提现余额
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <asp:Literal ID="ltUserName" runat="server"></asp:Literal>
                            </td>
                            <td align="center">
                                <%#Eval("Amount")%>
                            </td>
                            <td align="center">
                                <%#Eval("Number")%>
                            </td>
                            <td align="center">
                                <%#Eval("Price")%>
                            </td>
                            <td align="center">
                                <asp:Literal ID="ltCurrentPrice" runat="server"></asp:Literal>
                            </td>
                            <td align="center">
                                <asp:Literal ID="ltBalance" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="6">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span></div>
                    </td>
                </tr>
            </table>
            <div class="nextpage cBlack">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                    LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                    HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
