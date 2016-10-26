<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leavewords.aspx.cs" Inherits="web.user.member.Leavewords" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>留言</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="Form1" runat="server" class="stdform">
        <div class="right_content">
            <h2><%=GetLanguage("Sendmail")%><%--我要留言--%></h2>
            <h6 style="text-align: center;">
                <span style="font-size:21px;"><%=GetLanguage("message")%></span></h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("Theme")%>：
                        </label>
                        <div class="field">
                            <input type="text" name="txtTitle" id="txtTitle" tip="输入主題" runat="server" width="360px" class="input_title" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("MessageContent")%>：
                        </label>
                        <div class="field">
                            <asp:TextBox ID="txtPubContext" runat="server" tip="输入内容" class="input_neirong" Width="360px" Height="180px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="action">
                <asp:Button ID="btnSubmit" runat="server" class="btn" OnClick="btnSubmit_Click" Text="提 交" />&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" class="btn" Text="返 回" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
