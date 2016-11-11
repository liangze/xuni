<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Web.admin.business.Member" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员开通管理</title>
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
                <legend class="legSearch">查询</legend>选择下拉：<asp:DropDownList ID="dropType" runat="server">
                    <asp:ListItem Value="0">请选择</asp:ListItem>
                    <asp:ListItem Value="1">会员编号</asp:ListItem>
                    <asp:ListItem Value="2">会员姓名</asp:ListItem>
                    <asp:ListItem Value="3">推荐人编号</asp:ListItem>
                    <asp:ListItem Value="4">报单人编号</asp:ListItem>
                </asp:DropDownList>
                <input name="txtInput" id="txtInput" class="input_select" runat="server" type="text" />
                <%--会员级别：<asp:DropDownList ID="dropLevel" runat="server">
                </asp:DropDownList>--%>
                注册日期：<asp:TextBox ID="txtStar" tip="输入注册日期" runat="server" onfocus="WdatePicker()"
                    class="input_select"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="输入注册日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                <asp:LinkButton ID="btnSearch" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
                <asp:LinkButton ID="lbtnExport" runat="server" class="easyui-linkbutton" iconcls="icon-print"
                    OnClick="lbtnExport_Click"> 导出Excel </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">推荐人编号
                    </th>
                    <th align="center">会员编号
                    </th>
                    <th align="center">会员姓名
                    </th>
                    <th align="center">会员级别
                    </th>
                    <th align="center">报单中心编号
                    </th>
    <%--                <th align="center">安置人编号
                    </th>
                    <th align="center">注册区域
                    </th>--%>
                    <th align="center">注册日期
                    </th>
                    <%--<th align="center">操作
                    </th>--%>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("RecommendCode")%>
                            </td>
                            <td align="center">
                                <a href="UserDetail.aspx?UserID=<%# Eval("UserID")%>">
                                    <%# Eval("UserCode")%></a>
                            </td>
                            <td align="center">
                                <%#Eval("TrueName")%>
                            </td>
                            <td align="center">
                                <%#levelBLL.GetLevelName(Convert.ToInt32(Eval("LevelID")), currentCulture)%>
                            </td>
                            <td align="center">
                                <%#Eval("user006")%>
                            </td>
     <%--                       <td align="center">
                                <%#Eval("ParentCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("Location").ToString()=="1"?"左区":"右区"%>
                            </td>--%>
                            <td align="center">
                                <%#Eval("RegTime")%>
                            </td>
                            <%--<td align="center">
                                <asp:LinkButton ID="lbtnOpend" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                    class="easyui-linkbutton" iconcls="icon-ok" Visible='true' CommandName="open"
                                    OnClientClick="javascript:return confirm('确定要开通会员吗？')">开通</asp:LinkButton>
                                <asp:LinkButton ID="lbtnEmpty" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                    class="easyui-linkbutton" iconcls="icon-ok" Visible="true" CommandName="Empty"
                                    OnClientClick="javascript:return confirm('确定要开通会员吗？')">开通空单</asp:LinkButton>
                                <asp:LinkButton ID="lbtnRemove" runat="server" CommandArgument='<%# Eval("UserID") %>' class="easyui-linkbutton"
                                    iconcls="icon-no" Visible='<%#Eval("IsOpend").ToString()=="0"?true:false %>'
                                    CommandName="Remove" OnClientClick="javascript:return confirm('确定要删除此会员吗？')">删除</asp:LinkButton>
                            </td>--%>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="divno" runat="server">
                    <td colspan="10" align="center">
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
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                    HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
