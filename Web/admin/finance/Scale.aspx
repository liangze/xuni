<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scale.aspx.cs" Inherits="Web.admin.finance.Scale" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>拨出比例</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <tbody>
                <tr>
                    <th align="center">
                        总收入
                    </th>
                    <th align="center">
                        总支出
                    </th>
                    <th align="center">
                        拨出比
                    </th>
                </tr>
                <tr>
                    <td align="center">
                        <%= AllIn%>
                    </td>
                    <td align="center">
                        <%= AllOut%>
                    </td>
                    <td align="center">
                        <%= AllScale%>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="operation">
        <fieldset class="fieldset">
            <legend class="legSearch">查询</legend>转账日期：<asp:TextBox ID="txtChuStar" tip="输入转账日期"
                runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
            <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                OnClick="btnChuSearch_Click"> 搜 索 </asp:LinkButton>
        </fieldset>
    </div>
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <tbody>
                <tr>
                    <th align="center">
                        收入
                    </th>
                    <th align="center">
                        支出
                    </th>
                    <th align="center">
                        拨出比
                    </th>
                </tr>
                <tr>
                    <td align="center">
                        <%= In%>
                    </td>
                    <td align="center">
                        <%= Out%>
                    </td>
                    <td align="center">
                        <%= Scal%>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
