<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhuye.aspx.cs" Inherits="Web.admin.zhuye" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Content/Base.css" />
    <link rel="stylesheet" type="text/css" href="Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="Content/themes/icon.css" />
    <script type="text/javascript" src="Scripts/jquery.js"></script>
    <script type="text/javascript" src="Scripts/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../js/cuntom.js"></script>
    <script src="Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div align="center" style="font-size: 40px;">
            <b>
                <asp:Label ID="Label1" runat="server" Text="欢迎进入后台管理系统"></asp:Label>
            </b>
        </div>
        <div align="center" style="height: 40px;">
            &nbsp;
        </div>
        <div>
            <%--<asp:LinkButton ID="lbtnShareOut" runat="server" class="easyui-linkbutton" iconcls="icon-ok" OnClick="lbtnShareOut_Click"> 发放静态月分红 </asp:LinkButton>--%>
            <%-- &nbsp;&nbsp;<asp:LinkButton ID="lbtnSettle" runat="server" class="easyui-linkbutton" iconcls="icon-ok" OnClick="lbtnSettle_Click"> 发放推荐奖 </asp:LinkButton>--%>
            <%--&nbsp;&nbsp;<asp:LinkButton ID="lbtnBuy" runat="server" class="easyui-linkbutton" iconcls="icon-ok" OnClick="lbtnBuy_Click"> 发放对碰奖 </asp:LinkButton>
            &nbsp;&nbsp;<asp:LinkButton ID="lbtnBonusPayOne" runat="server" class="easyui-linkbutton" iconcls="icon-ok" OnClick="lbtnBonusPayOne_Click"> 日结奖金发放（推荐奖/对碰奖） </asp:LinkButton>
            &nbsp;&nbsp;<asp:LinkButton ID="lbtnSplit" runat="server" class="easyui-linkbutton" iconcls="icon-ok" OnClick="lbtnSplit_Click"> 拆分 </asp:LinkButton>--%>
        </div>
        <div>
            &nbsp;
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tbody>
                    <tr>
                        <th align="center">今日会员注册数量
                        </th>
                        <th align="center">会员累计注册数量
                        </th>
                        <th align="center">今日积分购买数量
                        </th>
                        <th align="center">积分累计购买数量
                        </th>
                        
                    </tr>
                    <tr>
                        <td align="center"><%=shuliang %></td>
                        <td align="center"><%=leiji %></td>
                        <td align="center"><%=jifen%></td>
                        <td align="center"><%=jifenleiji%></td>
                        
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tbody>
                    <tr>
                        <th align="center">今日积分卖出数量
                        </th>
                        <th align="center">积分累计卖出数量
                        </th>
                        <th align="center">今日奖金结算金额
                        </th>
                        <th align="center">奖金累计结算金额
                        </th>
                        
                    </tr>
                    <tr>
                        <td align="center"><%= AllIn%></td>
                        <td align="center"><%= Allyu %></td>
                        <td align="center"><%=jiangjin %></td>
                        <td align="center"><%=jiangjinleiji %></td>
                        
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tbody>
                    <tr>
                        <%--<th align="center">会员持有积分数
                        </th>--%>
                        <th align="center">积分拆分总数量
                        </th>
                        <th align="center">爱心基金总数量
                        </th>
                        <th align="center">公司总业绩金额
                        </th>
                        <th align="center">今日邮件总数量
                        </th>
                    </tr>
                    <tr>
                        <%--<td align="center"><%=all %></td>--%>
                        <td align="center"> <%=caifen %></td>
                        <td align="center"><%=aixing %></td>
                        <td align="center"><%=zongyeji %></td>
                        <td align="center"><%=youjian %></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tbody>
                    <tr>
                        <th align="center">会员商品购买量
                        </th>
                        <th align="center">商品已发货数量
                        </th>
                        <th align="center">会员提现总数量
                        </th>
                        <th align="center">提现已处理数量
                        </th>
                        
                    </tr>
                    <tr>
                        <td align="center"><%=goumai %></td>
                        <td align="center"><%=fahuo %></td>  
                         <td align="center"><%=tixian %></td>
                        <td align="center"><%=tixianchuli %></td>  
                    </tr>
                </tbody>
            </table>
        </div>
        
    </form>
</body>
</html>
