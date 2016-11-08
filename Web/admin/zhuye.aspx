<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhuye.aspx.cs" Inherits="Web.admin.zhuye" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
        <div align="center" style=" font-size:40px;">
            <b>
                <asp:Label ID="Label1" runat="server" Text="欢迎进入后台管理系统" ></asp:Label>
            </b>
        </div>
        <div align="center" style="height: 40px;">
            &nbsp;
        </div>
        <div>
            <asp:LinkButton ID="lbtnShareOut" runat="server" class="easyui-linkbutton" iconcls="icon-ok" OnClick="lbtnShareOut_Click"> 发放静态月分红 </asp:LinkButton>
           <%-- &nbsp;&nbsp;<asp:LinkButton ID="lbtnSettle" runat="server" class="easyui-linkbutton" iconcls="icon-ok" OnClick="lbtnSettle_Click"> 发放推荐奖 </asp:LinkButton>--%>
            &nbsp;&nbsp;<asp:LinkButton ID="lbtnBuy" runat="server" class="easyui-linkbutton" iconcls="icon-ok" OnClick="lbtnBuy_Click"> 发放对碰奖 </asp:LinkButton>
            &nbsp;&nbsp;<asp:LinkButton ID="lbtnBonusPayOne" runat="server" class="easyui-linkbutton" iconcls="icon-ok" OnClick="lbtnBonusPayOne_Click"> 日结奖金发放（推荐奖/对碰奖） </asp:LinkButton>
            &nbsp;&nbsp;<asp:LinkButton ID="lbtnSplit" runat="server" class="easyui-linkbutton" iconcls="icon-ok" OnClick="lbtnSplit_Click"> 拆分 </asp:LinkButton>
        </div>
    </form>
</body>
</html>
