﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockAudit.aspx.cs" Inherits="Web.admin.Stock.StockAudit" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">云商积分卖出</legend>会员编号：<asp:TextBox
                    ID="txtUserCode" tip="输入购买日期" runat="server" class="input_select"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;购买日期：<asp:TextBox
                    ID="txtStart" tip="输入购买日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="输入购买日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                &nbsp;&nbsp;<asp:LinkButton ID="btnSearch" runat="server" class="easyui-linkbutton" iconcls="icon-search" OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        会员编号
                    </th>
                    <th>
                        总出售金额
                    </th>
                    <th>
                        卖出单价
                    </th>
                    <th>
                        卖出数量
                    </th>
                    <th>
                        卖出时间
                    </th>
                    <th>
                        状态
                    </th>
                    <%--<th>
                        操作
                    </th>--%>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                 <%#userBLL.GetUserCode(long.Parse(Eval("UserID").ToString()))%>
                            </td>
                            <td align="center">
                                <%#Eval("Amount")%>
                            </td>
                            <td align="center">
                                <%#Eval("Price")%>
                            </td>
                            <td align="center">
                                <%#Eval("SaleNum")%>
                            </td>
                            <td align="center">
                                <%#Eval("SellDate")%>
                            </td>
                            <td align="center">
                                <%#Eval("IsSell").ToString()=="1"?"已完成":"挂单中"%>
                            </td>
                           
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="6" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" />
                                抱歉！目前数据库暂无数据显示。</span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="nextpage cBlack">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                    LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
