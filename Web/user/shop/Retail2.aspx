<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Retail2.aspx.cs" Inherits="Web.user.shop.Retail2" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品明细</title>
    <link href="../../css/indexcss.css" type="text/css" rel="stylesheet" />
    <link href="../../style/index.css" rel="stylesheet" type="text/css" />
    <link href="../../style/style.css" rel="stylesheet" type="text/css" />
    <link href="../../style/ny.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
     <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script> 
    <style type="text/css">
        .fieldset a
        {
            color: #fff;
        }
        .butSize
        {
            background-color: #F87E03;
            padding: 5px;
            font-size: 12px;
            font-weight: bold;
            color: #FFF;
        }
        .auto-style3 {
            width: 90%;
            height: 312px;
        }
        .auto-style4 {
            width: 211px;
        }
    </style>
</head>
<body class="bg">
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div id="main">
        <!--左侧菜单 star-->
        <div class="left">
            <div class="menu_t">产品管理</div>
            <div class="menu_x">
                <ul>
                    <li><a href="Rail.aspx" target="fMain" class="cur2">产品列表</a></li>
                    <li><a href="order.aspx" target="fMain">我的订单</a></li>
                </ul>
            </div>
        </div>
        <!--左侧菜单 end-->
        <div class="right">
            <div class="title">
                <span>当前位置：<a href="../default.aspx" class="hui">首页</a> &gt; 产品管理</span><h2>产品明细</h2>
            </div>
            <div class="right_nr">

    <div class="box">

        <div class="operation2" style="height:350px;">
            <fieldset class="fieldset2" style="height:291px">

                <table cellpadding="0" cellspacing="0" class="auto-style3">
                    <tr>
                        <td align="left" class="auto-style4">&nbsp;商品编号：</td>
                        <td>
                           <asp:label id="goodscode" runat="server" Text="商品编号" ForeColor="#ff0000"></asp:label>
                         </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style4">&nbsp;商品名称(中文)：</td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="商品名称" ForeColor="#ff0000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style4">&nbsp;商品名称(英文)：</td>
                        <td>
                             <asp:Label ID="Label2" runat="server" Text="商品名称" ForeColor="#ff0000"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style4">&nbsp;库存数量：</td>
                        <td>
                             <asp:Label ID="Label3" runat="server" Text="库存数量" ForeColor="#ff0000"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style4">&nbsp;市场价：</td>
                        <td>
                           <asp:Label ID="Label4" runat="server" Text="市场价" ForeColor="#ff0000"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style4">&nbsp;会员价：</td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="会员价" ForeColor="#ff0000"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style4">&nbsp;积分：</td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="积分" ForeColor="#ff0000"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style4">&nbsp;商品详情：</td>
                        <td rowspan="2" valign="top">
                           <asp:Label ID="Label7" runat="server" Text="商品详情" ForeColor="#ff0000"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style4">&nbsp;</td>
                    </tr>
                    </table>

            </fieldset>
        </div>
        <!--end operation 操作-->
        <div class="dataTable">
        </div>
    </div>
                </div>
            </div>
            </div>
    </form>
</body>
</html>
