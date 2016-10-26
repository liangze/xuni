<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bonusff.aspx.cs" Inherits="Web.admin.finance.Bonusff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改密码</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.4.4.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>

    <script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" class="box_con" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class="main_dt">
            <h2>
                </h2>
            <ul>
                <li style=" padding-left:310px;">
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-save"  
                     OnClick="LinkButton2_Click"    OnClientClick="javascript:return confirm('确定要奖金发放吗？')">奖金结算</asp:LinkButton>
                <%--    <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-save"  
                     OnClick="LinkButton1_Click"    OnClientClick="javascript:return confirm('确定要发放分红吗？')">分红结算</asp:LinkButton>--%>
  <%--                   <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-save"  
                     OnClick="LinkButton3_Click"    OnClientClick="javascript:return confirm('确定要奖金发放吗？')">零售积分结算</asp:LinkButton>--%>
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>