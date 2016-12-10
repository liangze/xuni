<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rongyu.aspx.cs" Inherits="Web.admin.team.Rongyu" %>

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
                    <th align="center">手机号
                    </th>
                        <th align="center">荣誉等级
                    </th>
    <%--                <th align="center">安置人编号
                    </th>
                    <th align="center">注册区域
                    </th>--%>
                   
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("RecommendCode")%>
                            </td>
                            <td align="center"> 
                                    <%# Eval("UserCode")%></a>
                            </td>
                            <td align="center">
                                <%#Eval("TrueName")%>
                            </td>
                            <td align="center">
                                <%#levelBLL.GetLevelName(Convert.ToInt32(Eval("LevelID")), currentCulture)%>
                            </td>
                            <td align="center">
                                <%#Eval("PhoneNum")%>
                            </td>
                             <td align="center">
                                 <asp:Label ID="Label1" runat="server" Text=' <%#decimal.Parse(Eval("RightScore").ToString()) >= decimal.Parse(Eval("LeftScore").ToString())? Rongyu(decimal.Parse(Eval("LeftScore").ToString())):Rongyu(decimal.Parse(Eval("RightScore").ToString()))%>'></asp:Label>
                        <%-- <%#decimal.Parse(Eval("RightNewScore").ToString())%> > <%#decimal.Parse(Eval("LeftNewScore").ToString())%>? <%# Rongyu(decimal.Parse(Eval("RightNewScore").ToString()))%>:<%#Rongyu(decimal.Parse(Eval("LeftNewScore").ToString()))%>--%>
                            </td>
     <%--                       <td align="center">
                                <%#Eval("ParentCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("Location").ToString()=="1"?"左区":"右区"%>
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
