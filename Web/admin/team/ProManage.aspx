<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProManage.aspx.cs" Inherits="Web.admin.team.ProManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员升级</title>
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
    <form id="Form1" class="box_con" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">会员升级</legend>
                <table width="99%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="360px;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    会员编号:<asp:TextBox ID="TextBox1" runat="server" class="input_select" AutoPostBack="True"
                                        OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                                    当前级别:&nbsp;<input name="jb" type="text" id="txtLevel" runat="server" disabled="disabled"
                                        class="input_select" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            修改级别:<asp:DropDownList ID="ddlLevel" runat="server">
                            </asp:DropDownList>
                            <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                                OnClick="Button1_Click"> 提 交 </asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset class="fieldset">
                <legend class="legSearch">升级查询</legend>会员编号：<asp:TextBox ID="txtUserCode" tip="输入会员编号"
                    runat="server" class="input_select"></asp:TextBox>
                升级日期：<asp:TextBox ID="txtStar" tip="输入升级日期" runat="server" onfocus="WdatePicker()"
                    class="input_select"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="输入升级日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        会员编号
                    </th>
                    <th align="center">
                        升级前级别
                    </th>
                    <th align="center">
                        升级后级别
                    </th>
                    <th align="center">
                        缴纳现金币
                    </th>
                    <th align="center">
                        升级日期
                    </th>
                    <th align="center">
                        备注
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%# levelBLL.GetLevelName(Convert.ToInt32(Eval("LastLevel")))%>
                            </td>
                            <td align="center">
                                <%# levelBLL.GetLevelName(Convert.ToInt32(Eval("EndLevel")))%>
                            </td>
                            <td align="center">
                                <%#Eval("ProMoney")%>
                            </td>
                            <td align="center">
                                <%#Eval("AddDate")%>
                            </td>
                            <td align="center">
                                <%#Eval("Remark")%>
                            </td>
                            <td align="center">
                              <asp:LinkButton ID="LinkButton1" runat="server" CommandName="flag" class="easyui-linkbutton"
                                    iconcls="icon-ok" CommandArgument='<%#Eval("ID") %>' Visible='<%#Eval("Flag").ToString()=="0"?true:false %>'>审核</asp:LinkButton>
                                <asp:Label ID="Label1" runat="server" Text="已审核" Visible='<%#Eval("Flag").ToString()=="1"?true:false %>'></asp:Label>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" class="easyui-linkbutton"
                                    iconcls="icon-no" CommandArgument='<%#Eval("ID") %>' Visible='<%#Eval("Flag").ToString()=="0"?true:false %>'>删除</asp:LinkButton>
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
                    NumericButtonCount="3" PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
