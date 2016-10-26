﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_buy.aspx.cs" Inherits="Web.admin.licai.admin_buy" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="operation">
        <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
            OnClick="LinkButton1_Click"> 买入记录 </asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
            OnClick="LinkButton2_Click"> 卖出记录 </asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-search"
            OnClick="LinkButton3_Click"> 待交易记录 </asp:LinkButton>
    </div>
    <div class="operation">
        <fieldset class="fieldset">
            <legend class="legSearch">查询</legend>用户名：
            <input name="Add_sscFd7" id="txtMairuCode" class="input_select" runat="server" type="text" />&nbsp;&nbsp;&nbsp;
            交易时间：<asp:TextBox ID="txtMairuStar" tip="输入交易时间" runat="server" class="input_select"
                onfocus="WdatePicker()"></asp:TextBox>
            至<asp:TextBox ID="txtMairuEnd" tip="输入交易时间" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
            <asp:LinkButton ID="LinkButton4" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                OnClick="btnMairu_Click"> 搜 索 </asp:LinkButton>
        </fieldset>
    </div>
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <tr>
                <th>
                    卖出人用户名
                </th>
                <th>
                    交易时间
                </th>
                <th>
                    交易数
                </th>
                <th>
                    交易单价
                </th>
                <th>
                    总价值
                </th>
                <th>
                    交易类型
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <%#Eval("FromUserCode")%>
                        </td>
                        <td align="center">
                            <%#Eval("SucTime")%>
                        </td>
                        <td align="center">
                            <%#Eval("BusinessAmount")%>
                        </td>
                        <td align="center">
                            <%#Eval("BusinessPrice")%>
                        </td>
                        <td align="center">
                            <%#Eval("SumMoney")%>
                        </td>
                        <td align="center">
                            <%#Convert.ToInt32(Eval("Notes01"))==1?"强制回购":"正常交易"%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr id="tr1" runat="server">
                <td colspan="6" align="center">
                    <div class="NoData">
                        <span class="cBlack">
                            <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                            抱歉！目前数据库暂无数据显示。</span></div>
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
