<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agent.aspx.cs" Inherits="Web.admin.business.Agent" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员提现管理</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" class="box_con" runat="server">
    <div class="operation">
        <fieldset class="fieldset">
            <legend class="legSearch">查询</legend>会员编号：<input name="txtUserCode" id="txtUserCode"
                tip="输入会员编号" class="input_select" runat="server" type="text" />
            会员姓名：<input name="txtTrueName" id="txtTrueName" tip="输入会员姓名" class="input_select" runat="server"
                type="text" />
            <asp:LinkButton ID="lbtnSearch" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                OnClick="lbtnSearch_Click"> 搜 索 </asp:LinkButton>
        </fieldset>
    </div>
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <tr>
                <th align="center">
                    代理中心编号
                </th>
                <th align="center">
                    会员编号
                </th>
                <th align="center">
                    会员姓名
                </th>
                <th align="center">
                    会员级别
                </th>
                <th align="center">
                    代理区域
                </th>
                <th align="center">
                    申请日期
                </th>
                <th align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <%# Eval("AgentCode")%>
                        </td>
                        <td align="center">
                            <%# Eval("UserCode")%>
                        </td>
                        <td align="center">
                            <%#Eval("TrueName")%>
                        </td>
                        <td align="center">
                            <%#Eval("LevelName")%>
                        </td>
                        <td align="center">
                            <asp:Literal runat="server" ID="ltlArea"></asp:Literal>
                        </td>
                        <td align="center">
                            <%#Eval("AppliTime")%>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="lbtnOpen" runat="server" CommandArgument='<%# Eval("ID") %>'
                                class="easyui-linkbutton" iconcls="icon-ok" CommandName="Open" OnClientClick="javascript:return confirm('确定激活此代理商？')">激活</asp:LinkButton>
                            <asp:LinkButton ID="lbtnRemove" runat="server" CommandArgument='<%# Eval("ID") %>'
                                class="easyui-linkbutton" iconcls="icon-no" CommandName="Remove" OnClientClick="javascript:return confirm('确定要删除此代理商吗？')">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr id="divno" runat="server">
                <td colspan="11" align="center">
                    <div class="NoData">
                        <span class="cBlack">
                            <img src="../../images/ico_NoDate.gif" width="16" height="16" alt=""/>
                            抱歉！目前数据库暂无数据显示。</span></div>
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
    </form>
</body>
</html>
