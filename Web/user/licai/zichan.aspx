<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zichan.aspx.cs" Inherits="Web.user.licai.zichan" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>资产</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Tooltip.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/superValidator.js"></script>
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body class="subBody">
    <form id="form1" runat="server" class="box_con">

        <div class="box_width">
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">资产详情</legend>
                    <br />
                    可交易股票：<%=label1%>&nbsp;&nbsp;&nbsp;&nbsp;
          股票总价值：<%=label2%>&nbsp;&nbsp;&nbsp;&nbsp;
          交易钱包：<%=label3%>&nbsp;&nbsp;&nbsp;&nbsp;
          购物钱包：<%=label4%><br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          买入数量：<%=label5%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          卖出数量：<%=label6%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          贡献仓数：<%=label7%>&nbsp;&nbsp;&nbsp;&nbsp;
                </fieldset>
            </div>
            <div class=" dataTable">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <td align="right" width="15%">总价值：</td>
                        <td align="center"><%=label2%></td>
                        <td align="right" width="10%">股票数量：</td>
                        <td align="center"><%=all%></td>
                    </tr>
                    <tr>
                        <td align="right">买入总量：</td>
                        <td align="center"><%=label5%></td>
                        <td align="right">卖出总量：</td>
                        <td align="center"><%=label6%></td>
                    </tr>
                    <tr>
                        <td align="right">可交易股票数量：</td>
                        <td align="center"><%=label1%></td>
                        <td align="right">贡献仓：</td>
                        <td align="center"><%=label7%></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
