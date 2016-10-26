<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Super.aspx.cs" Inherits="Web.admin.Super" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="update1" runat="server" Text="执行" OnClick="update_Click" />
        <asp:Button ID="update2" runat="server" Text="open" OnClick="update2_Click" />
        <asp:Button ID="update3" runat="server" Text="生产" OnClick="update3_Click" Visible="False" />
        <asp:Button ID="update4" runat="server" Text="更新4" OnClick="update4_Click" />
        <asp:Button ID="update5" runat="server" Text="更新5" OnClick="update5_Click" />
        <asp:Button ID="update6" runat="server" Text="更新6" OnClick="update6_Click" />
        <asp:Button ID="update7" runat="server" Text="更新7" OnClick="update7_Click" />
        <asp:Button ID="update8" runat="server" Text="更新8"  OnClick="update8_Click"/>
        <asp:Button ID="update9" runat="server" Text="更新9"  OnClick="update9_Click"/>
    </div>
        <table>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                  <tr>
                      <td><%#Eval("ID")%></td>
                            <td align="center"><%#Eval("URL")%></td>
                      <td align="center"><%#Eval("MenuName")%></td>
                      <td align="center"><%#Eval("ParentID")%></td>
                  </tr>
            </ItemTemplate>
        </asp:Repeater>
            </table>
        <asp:TextBox ID="TextBox1"  runat="server" Height="458px" Width="749px" TextMode="MultiLine"></asp:TextBox>
    </form>
</body>
</html>
