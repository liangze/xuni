<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegSuccess2.aspx.cs" Inherits="Web.RegSuccess2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>注册成功</title>
    <link href="css/indexcss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="box box_width">
        <div class="capositon">
            当前位置：首页>><a href="javascript:void(0)">注册</a></div>
        <div class="dataTable">
            <fieldset class="fieldset">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr>
                        <td align="left" style="height: 60px;">
                            <span style="font-size: 25px; color: #008000; font-weight: bold;">恭喜您注册成功！</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            您的会员编号为：<span style="color: #008000;"><%=usercode %></span>&nbsp;&nbsp;注册级别：<span
                                style="color: #008000;"><%=levelname%></span>&nbsp;&nbsp;注册资金：<span style="color: #008000;"><%=RegMoney%>元</span>&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
