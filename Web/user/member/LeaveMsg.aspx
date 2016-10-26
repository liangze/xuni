<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveMsg.aspx.cs" Inherits="Web.user.member.LeaveMsg" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>收件箱</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="Form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("TheInbox")%></h2>
            <div class="filter">
                <h2>
                    <a href="LeaveMsg.aspx" class="btn"><%=GetLanguage("TheInbox")%><%--收件箱--%></a>
                    <a href="LeaveOut.aspx" class="btn"><%=GetLanguage("TheOutbox")%><%--发件箱--%></a>
                    <a href="Leavewords.aspx" class="btn"><%=GetLanguage("message")%><%--留言--%></a>
                </h2>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th><%=GetLanguage("sender")%></th>
                        <!--收件人-->
                        <th><%=GetLanguage("SubjectContent")%></th>
                        <!--主题内容-->
                        <th><%=GetLanguage("TheOutboxDate")%></th>
                        <!--发件日期-->
                        <th><%=GetLanguage("Operation")%></th>
                        <!--操作-->
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#GetUserCode(Eval("UserID").ToString(), Eval("FromUserType").ToString())%>
                                </td>
                                <td align="center">
                                    <a href='LeaveWordsDetail.aspx?type=in&id=<%#Eval("ID") %>&type=1' target="_self"><%#Eval("MsgTitle")%></a>
                                </td>
                                <td align="center">
                                    <%#Convert.ToDateTime(Eval("LeaveTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                                </td>
                                <td align="center">
                                    <%#Eval("IsReply").ToString() == "0" ? "未回复" : "已回复"%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="4" align="center"><%=GetLanguage("Manager")%></td>
                </tr>
            </table>
            <div class="yellow" id="pages_pg_2">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" Direction="LeftToRight"
                    OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
