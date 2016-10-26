<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JournalAccount.aspx.cs"
    Inherits="Web.admin.finance.JournalAccount" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>流水账管理</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" class="box_con" runat="server">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>会员编号:<input id="textUserCode" type="text" runat="server"
                    class="input_select" tip="输入会员编号" />
                姓名:<asp:TextBox ID="txtTrueName" tip="输入姓名" runat="server" class="input_select"></asp:TextBox>
                <asp:LinkButton ID="lbtnSearch" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="lbtnSearch_Click"> 搜 索 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">会员编号
                    </th>
                    <th align="center">会员姓名
                    </th>
                    <th align="center">流通币账户余额
                    </th>
                    <th align="center">MDD钻币账户余额
                    </th>
                    <th align="center">平台费用
                    </th>
                    <th align="center">购物币
                    </th>
                    <th align="center">注册币
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("TrueName")%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                    CommandName="b_detail"><%#Eval("BonusAccount")%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                    CommandName="e_detail"><%#Eval("Emoney")%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                    CommandName="s_detail"><%#Eval("StockMoney")%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                    CommandName="h_detail"><%#Eval("ShopAccount")%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                    CommandName="a_detail"><%#Eval("StockAccount")%></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="5" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                抱歉！目前数据库暂无数据显示。</span>
                        </div>
                    </td>
                    <td align="center">&nbsp;</td>
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
    </form>
</body>
</html>
