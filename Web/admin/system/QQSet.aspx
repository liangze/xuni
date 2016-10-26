<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QQSet.aspx.cs" Inherits="Web.admin.system.QQSet" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>QQ客服設置</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>

    <script type="text/javascript" src="../../js/superValidator.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>

    <style type="text/css">
        .red {
            color: Red;
        }
    </style>

</head>
<body>
    <form id="form2" runat="server" class="box_con">
        <div class="box box_width">
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">QQ客服设置</legend>
                    <table width="100%">
                        <tr>
                            <td width="67px" align="right"><font class="red">*</font>客服名称：
                            </td>
                            <td width="150px">
                                <input id="txtName" type="text" runat="server" class="input_second" size="20" /></td>
                            <td width="67px" align="right">
                                <font class="red">*</font>号码：</td>
                            <td width="250px">
                                <input id="txtQQnumber" type="text" runat="server" class="input_second1" /></td>
                            <td width="250px" align="center">
                                <input id="chkGroup" type="checkbox" runat="server" />选中则是输入QQ群号码，不选为QQ号</td>
                            <td>
                                <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"
                                    iconcls="icon-ok" OnClick="btnSave_Click"> 设 置 </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <!--end operation 操作-->
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">客服名称
                        </th>
                        <th align="center">号码
                        </th>
                        <th align="center">类型
                        </th>
                        <th align="center">操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rpBank" runat="server" OnItemCommand="rpBank_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("ServiceName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("QQnum")%>
                                </td>
                                <td align="center">
                                    <%#Convert.ToInt32(Eval("QQType"))==1? "QQ群":"QQ号"%>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="modify" class="easyui-linkbutton"
                                        iconcls="icon-edit" CommandArgument='<%#Eval("ID") %>'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="del" class="easyui-linkbutton"
                                        iconcls="icon-no" CommandArgument='<%#Eval("ID") %>'>删除</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="trNull" runat="server">
                        <td colspan="3" align="center">
                            <div class="NoData">
                                <span class="cBlack" style="display: block">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库中暂无记录显示。</span>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="nextpage cBlack">
                    <webdiyer:AspNetPager ID="anpBank" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" OnPageChanged="anpBank_PageChanged" PrevPageText="上一页"
                        AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3" PageSize="12"
                        ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                        UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
                        textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

