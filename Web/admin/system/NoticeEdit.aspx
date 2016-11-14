<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeEdit.aspx.cs" Inherits="web.admin.system.NoticeEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <div class="main_dt">
        <form id="Form1" class="main_neirong" runat="server">
        <h2 style="padding-left: 20px;">
            <asp:Label ID="lbltitle" runat="server" Text="" Font-Size="30px"></asp:Label></h2>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="8%" align="right">
                    <span style="color: Red;">*</span>主题：
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" tip="输入公告主题" class="input_san"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="8%" align="right">
                    <span style="color: Red;">*</span>类型：
                </td>
                <td>
                    <asp:DropDownList ID="dropNewType" runat="server">
                        <asp:ListItem Value="0">-请选择-</asp:ListItem>
                        <asp:ListItem Value="1">系统公告</asp:ListItem>
                        <asp:ListItem Value="2">公司简介</asp:ListItem>
                        <asp:ListItem Value="3">新闻中心</asp:ListItem>
                        <asp:ListItem Value="4">疑问解答</asp:ListItem>
                        <asp:ListItem Value="5">商城公告</asp:ListItem>
                        <asp:ListItem Value="6">关于故乡云商</asp:ListItem>
                        <asp:ListItem Value="7">新手指南</asp:ListItem>
                        <asp:ListItem Value="8">配送安装</asp:ListItem>
                        <asp:ListItem Value="9">售后服务</asp:ListItem>
                        <asp:ListItem Value="10">购物保障</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span style="color: Red;">*</span>内容：
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="textPubContext" runat="server"></CKEditor:CKEditorControl>
                   
                </td>
            </tr>
            <tr>
                <td>
                    <span style="color: Red;">*</span>发布时间：
                </td>
                <td>
                    <asp:TextBox ID="txtTime" tip="请输入发布时间" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="input_san"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span style="color: Red;">*</span>发布类型：
                </td>
                <td>
                    <input type="radio" id="rdoZH" runat="server" name="rdo" />中文公告
                    <input type="radio" id="rdoEn" runat="server" name="rdo" />英文公告
                </td>
            </tr>
        </table>
        <div class="neirong_button1" style="padding-left: 65px;">
            <asp:LinkButton ID="lbtnSubmit" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                OnClick="lbtnSubmit_Click"> 提 交 </asp:LinkButton>
            <asp:LinkButton ID="lbtnBack" runat="server" class="easyui-linkbutton" iconcls="icon-back"
                OnClick="lbtnBack_Click"> 返回 </asp:LinkButton>
        </div>
        </form>
    </div>
</body>
</html>
