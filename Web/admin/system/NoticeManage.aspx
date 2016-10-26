<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeManage.aspx.cs" Inherits="web.admin.system.NoticeManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="box_con">
        <div class="box box_width">
            <div class="operation">
                <asp:LinkButton ID="lbtnAdd" runat="server" class="easyui-linkbutton" iconcls="icon-add" OnClick="lbtnAdd_Click">发布信息</asp:LinkButton>
            </div>
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">ID</th>
                        <th align="center">主题</th>
                        <th align="center">类型</th>
                        <th align="center">日期</th>
                        <th align="center">操作</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td align="center"><%# this.Repeater1.Items.Count + 1%></td>
                                <td align="center"><a href="NoticeEdit.aspx?ID=<%# Eval("ID")%>"><%#Eval("NewsTitle")%></a></td>
                                <td align="center">
                                    <asp:Literal ID="ltTypeName" runat="server"></asp:Literal></td>
                                <td align="center"><%#Eval("PublishTime")%></td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" class="easyui-linkbutton"
                                        iconcls="icon-edit" CommandName="modify" CommandArgument='<%#Eval("ID") %>'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtnDel" runat="server" class="easyui-linkbutton" iconcls="icon-no" CommandName="del" OnClientClick="javascript:return confirm('确定要删除吗？')" CommandArgument='<%#Eval("ID") %>'>删除</asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server" style="border: 0">
                        <td colspan="4" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库暂无数据显示。</span>
                            </div>
                        </td>
                    </tr>
                </table>
                <div style="width: 99%;">
                    <br />
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页"
                        PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                        PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                        UrlPaging="false" pageindexboxtype="TextBox"
                        showpageindexbox="Always" SubmitButtonText=""
                        textafterpageindexbox=" 页" textbeforepageindexbox="转到 "
                        HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
