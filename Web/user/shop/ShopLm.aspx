<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopLm.aspx.cs" Inherits="Web.user.shop.ShopLm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
        <script language="javascript" type="text/javascript">
            function back() {
                window.history.go(-1);
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="box box_width">
    <div class="capositon">
        当前位置：信息中心>><a href="javascript:void(0)">商家联盟</a></div>
        <div class="dataTable">
<%--          <dl class="newsInfotitle">
    <dt class="wryh"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></dt>
    <dd><span>发布时间：<asp:Label ID="lblDate" runat="server" Text=""></asp:Label></span><span>发布者：</span><asp:Label ID="lbPublisher" runat="server" Text=""></asp:Label></dd>
  </dl>--%>
  <div class="infomoreText">
    <asp:Literal ID="lilContent" runat="server"></asp:Literal>
  </div>
            <div style="text-align: center; padding-bottom:20px;">
                <input type="button" name="button" id="btnBack" value="返回" class="btn" onclick=" back()" />
            </div><%--
  <ul class="upandnext">
    <li>上一篇：<a href="#">秋冬季节全面增强体质的全能大菜</a></li>
    <li>下一篇：<a href="#">大学生给父母打电话只为钱 男生为救病父</a></li>
  </ul>--%>
        </div>
    </div>
    </form>
</body>
</html>
