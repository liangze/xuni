<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Web.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ID：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        业绩：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
