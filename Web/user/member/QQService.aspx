<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QQService.aspx.cs" Inherits="Web.user.member.QQService" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("Customer")%></h2>
            <table class="styled">
                <thead>
                    <tr>
                        <th colspan="3"><%=GetLanguage("CustomerQQ")%></th>
                        <!--客服QQ-->
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <td>
                                    <a target="_blank" href='<%#Eval("qqnum","http://wpa.qq.com/msgrd?v=3&uin={0}&site=qq&menu=yes")%>'>
                                        <img border="0" src='<%#Eval("qqnum","http://wpa.qq.com/pa?p=2:{0}:51")%>' alt="点击这里给我发消息" title="点击这里给我发消息" /></a>
                                </td>
                                <td><%#Eval("ServiceName") %></td>
                                <td>&nbsp;&nbsp;</td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="3" align="center"><%=GetLanguage("Manager")%></td>
                </tr>
            </table>
            <div>&nbsp;</div>
            <table class="styled">
                <thead>
                    <tr>
                        <th colspan="3"><%=GetLanguage("CustomerQQGroup")%></th>
                        <!--客服QQ群-->
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <td>
                                <a target="_blank" href='<%#Eval("qqnum","http://shang.qq.com/wpa/qunwpa?idkey={0}")%>'>
                                    <img border="0" src="http://pub.idqqimg.com/wpa/images/group.png" alt="<%#Eval("ServiceName") %>" title="<%#Eval("ServiceName") %>" /></a>
                            </td>
                            <td><%#Eval("ServiceName") %></td>
                            <td>&nbsp;&nbsp;</td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr2" runat="server">
                    <td colspan="3" align="center"><%=GetLanguage("Manager")%></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
