<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetState.aspx.cs" Inherits="Web.admin.system.SetState" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>前台设置</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>

    <script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body>
    <form id="form2" runat="server" class="box_con">
    <div class="box box_width">
        <div class="main_dt">
            <h2>
                前台设置</h2>
            <ul>
                <li><span style="display: block; width: 180px; text-align: right; float: left;"><font>
                    *</font>服务中心结算系统前台状态：</span>
                    <asp:RadioButton ID="rdoEnabled" runat="server" Text="启用" GroupName="state" Checked="True" />
                    <asp:RadioButton ID="rdoClose" runat="server" GroupName="state" Text="关闭" />
                </li>
                <li><span style="display: block; width: 180px; text-align: right; float: left;"><font>
                    *</font>关闭提示信息：</span>
                    <asp:TextBox ID="txtMsgContent" runat="server" class="input_second2" TextMode="MultiLine"></asp:TextBox>
                </li>
                <li style=" height:20px;"></li>
                <li><span style="display: block; width: 180px; text-align: right; float: left;"></span>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                        OnClick="btnSave_Click"> 设 置 </asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
