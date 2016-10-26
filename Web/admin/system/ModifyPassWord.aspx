<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPassWord.aspx.cs"
    Inherits="Web.admin.system.ModifyPassWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改密码</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

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
                修改密码</h2>
            <ul>
                <li><span style="margin-right: 10px; display: block; width: 300px; text-align: right;
                    float: left;"><font>*</font>旧登录密码：</span>
                    <input name="Add_sscFd7" id="textPassWord" class="input_second" runat="server" type="password"
                        tip="输入登录密码(必输入项)" />
                </li>
                <li><span style="margin-right: 10px; display: block; width: 300px; text-align: right;
                    float: left;"><font>*</font>新登录密码：</span>
                    <input name="Add_sscFd7" id="textNewPassWord" class="input_second" runat="server"
                        type="password" tip="输入新登录密码(必输入项)" />
                </li>
                <li><span style="margin-right: 10px; display: block; width: 300px; text-align: right;
                    float: left;"><font>*</font>确认登录密码：</span>
                    <input name="Add_sscFd7" id="textRPNewPassWord" class="input_second" runat="server"
                        type="password" tip="输入确认登录密码(必输入项)" />
                </li>
                <li style=" padding-left:310px;">
                    <asp:LinkButton ID="btn_s1" runat="server" class="easyui-linkbutton" iconcls="icon-save"
                        OnClick="btnPassWord_Click"> 保 存 </asp:LinkButton>
                </li>
                <li><span style="margin-right: 10px; display: block; width: 300px; text-align: right;
                    float: left;"><font>*</font>旧二级密码：</span>
                    <input name="Add_sscFd7" id="textSecondPass" class="input_second" runat="server"
                        type="password" tip="输入二级密码(必输入项)" />
                </li>
                <li><span style="margin-right: 10px; display: block; width: 300px; text-align: right;
                    float: left;"><font>*</font>新二级密码：</span>
                    <input name="Add_sscFd7" id="textNewSecondPass" class="input_second" runat="server"
                        type="password" tip="输入新二级密码(必输入项)" />
                </li>
                <li><span style="margin-right: 10px; display: block; width: 300px; text-align: right;
                    float: left;"><font>*</font>确认二级密码：</span>
                    <input name="Add_sscFd7" id="textRPSecondPass" class="input_second" runat="server"
                        type="password" tip="确认二级密码(必输入项)" />
                </li>
                <li style=" padding-left:310px;">
                    <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-save"
                        OnClick="btnSecondPass_Click"> 保 存 </asp:LinkButton>
                </li>
                <li><span style="margin-right: 10px; display: block; width: 300px; text-align: right;
                    float: left;"><font>*</font>旧三级密码：</span>
                    <input name="Add_sscFd7" id="Password1" class="input_second" runat="server" type="password"
                        tip="输入三级密码(必输入项)" />
                </li>
                <li><span style="margin-right: 10px; display: block; width: 300px; text-align: right;
                    float: left;"><font>*</font>新三级密码：</span>
                    <input name="Add_sscFd7" id="Password2" class="input_second" runat="server" type="password"
                        tip="输入新三级密码(必输入项)" />
                </li>
                <li><span style="margin-right: 10px; display: block; width: 300px; text-align: right;
                    float: left;"><font>*</font>确认三级密码：</span>
                    <input name="Add_sscFd7" id="Password3" class="input_second" runat="server" type="password"
                        tip="确认三级密码(必输入项)" />
                </li>
                <li style=" padding-left:310px;">
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-save"
                        OnClick="Button1_Click"> 保 存 </asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
