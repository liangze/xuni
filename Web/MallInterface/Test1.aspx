<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="Web.MallInterface.Test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" language="javascript" src="../Js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../JS/jquery-1.7.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        测试
    </div>
        <table>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="UserCode"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TjUserCode"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="JfAmount"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="JhAmount"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="SellAmount"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="BuyTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="Sub" Text="提交" OnClick="Sub_Click"/>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
