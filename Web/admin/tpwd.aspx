<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tpwd.aspx.cs" Inherits="Web.admin.tpwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>三级密码</title>
    <link rel="stylesheet" type="text/css" href="Content/base.css" />
    <link rel="stylesheet" type="text/css" href="Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="Content/themes/icon.css" />
    <script type="text/javascript" src="Scripts/jquery.js"></script>
    <script type="text/javascript" src="Scripts/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="Scripts/easyui-lang-zh_CN.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="operation">
        <fieldset class="fieldset">
            <legend class="legSearch">三级密码</legend>请输入三级密码：<asp:TextBox ID="txtsecondPassword"
                runat="server" class="input_select" TextMode="Password"></asp:TextBox>
            <a id="btn_s" runat="server" class="easyui-linkbutton" iconcls="icon-ok" onserverclick="btn_s_Click">
                确 定 </a>
        </fieldset>
    </div>
    </form>
</body>
</html>
