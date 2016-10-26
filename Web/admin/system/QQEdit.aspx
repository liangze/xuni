<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QQEdit.aspx.cs" Inherits="Web.admin.system.QQEdit" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑客服QQ</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>

    <script src="../../Js/jquery.provincesBank.js" type="text/javascript"></script>

    <script src="../../Js/provincesdata.js" type="text/javascript"></script>


    <style type="text/css">
        .red {
            color: Red;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server" class="box_con">
        <div class="box box_width">
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">客服QQ设置</legend>
                    <table width="100%">
                        <tr>
                            <td width="67px" align="right"><font class="red">*</font>客服名称：
                            </td>
                            <td width="210px">
                                <input id="txtName" type="text" runat="server" class="input_second" size="20" /></td>
                            <td width="67px" align="right">
                                <font class="red">*</font>号码：</td>
                            <td width="210px">
                                <input id="txtQQNumber" type="text" runat="server" class="input_second1" /></td>
                            <td width="310px" align="center">
                                <input id="chkGroup" type="checkbox" runat="server" />选中则是输入QQ群号码，不选为QQ号</td>
                            <td>
                                <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"
                                    iconcls="icon-ok" OnClick="btnSave_Click"> 设 置 </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>

