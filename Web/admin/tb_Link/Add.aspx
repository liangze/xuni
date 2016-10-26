<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="lgk.Web.tb_Link.Add"
    Title="增加页" %>

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
    <style type="text/css">
        .tbs tr
        {
            border: 1px solid #A4BED4;
        }
    </style>
</head>
<body>
    <form runat="server">
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" class=" tbs">
                    <tr>
                        <td height="25" width="30%" align="right">
                            图片展示 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <div style="width: 150px; height: 90px; overflow: hidden;">
                                <asp:Image ID="Image1" runat="server" Width="150" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            选择图片 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnupimg_Click" class="easyui-linkbutton">上传</asp:LinkButton>
                            <%--<asp:TextBox id="txtLinkImage" runat="server" Width="200px"></asp:TextBox>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            链接名称 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtLinkName" runat="server" Width="200px" class="input_select"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            链接地址 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtLinkUrl" runat="server" Width="200px" class="input_select"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            排序号 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtSort" runat="server" Width="200px" class="input_select"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;排号越大排名越前
                        </td>
                    </tr>
                    <%--<tr>
	<td height="25" width="30%" align="right">
		链接状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtStatus" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		备用字段1
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLink001" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		备用字段2
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLink002" runat="server" Width="200px"></asp:TextBox>
	</td></tr>--%>
                    <tr>
                      <td height="25" width="30%" align="right">
                            &nbsp;&nbsp; </td>
                        <td class="tdbg" align="left" valign="bottom">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnSave_Click" class="easyui-linkbutton">保存</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="javascript:history.go(-1);"
                                class="easyui-linkbutton">返回</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    </form>
</body>
</html>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
