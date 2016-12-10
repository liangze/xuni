<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yungou.aspx.cs" Inherits="Web.admin.finance.yungou" %>

<!DOCTYPE html>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
                    <th>会员编号
                    </th>
                    <th>姓名
                    </th>
                    <th>级别
                    </th>
                    <th>状态
                    </th>
                    <th>冻结积分
                    </th>
                    <th>解冻积分(可查看明显)
                    </th>
                    <th>解冻金额
                    </th>
                    <th>操作
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <%--OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound"--%>
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%--<%#userBLL.GetUserCode(long.Parse(Eval("UserID").ToString()))%>--%>
                                <%#Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("TrueName")%>
                            </td>
                            <td align="center">
                                <%# levelBLL.GetLevelName(int.Parse(Eval("LevelID").ToString()))%>
                            </td>
                            <td align="center">
                                <%#Eval("IsOpend").ToString()=="2"?"已激活":"未开通"%>
                            </td>
                            <td align="center">
                                <%#Eval("User012")%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                    CommandName="detail"><%#Eval("User014")%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtGongsi" runat="server" Text=""></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lbtnEnter" runat="server" CommandName="enter" CommandArgument='<%# Eval("UserID") %>'
                                    class="easyui-linkbutton" iconcls="icon-ok" Visible='<%#Convert.ToInt32(Eval("User012"))>0 ?true:false%>' OnClientClick="javascript:return confirm('确认要解冻云商积分？')">积分解冻</asp:LinkButton>
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
