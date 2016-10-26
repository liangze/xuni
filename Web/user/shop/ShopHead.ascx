<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShopHead.ascx.cs" Inherits="Web.user.shop.ShopHead" %>
<%@ Import Namespace="Library" %>
<%--<link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />--%>
<style type="text/css">
    .btn
    {
        border-style: none;
        border-color: inherit;
        border-width: medium;
        padding: 2px 0;
        cursor: pointer;
        min-width: 60px;
        font-size: 12px;
        background: url(../../images/btnbg.png) repeat-x center;
        cursor: hand;
        color: #fff;
        line-height: 20px;
        margin: 0px 5px;
    }
</style>
<script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("#divCenter").hide();
        $.getJSON(
               "Login.ashx?t=" + (new Date().valueOf()),
               function (data) {
                   if (data == 0) {
                       $("#divCenter").show();
                       $("#divLogin").hide();
                   }
               }
            );
        $("#btnLogin").click(function () {
            var userCode = $("#ucode").val();
            var pwd = $("#pwd").val();
            if (userCode == "") {
                <%if (loginbtn == "zh-cn"){%> 
                alert("请输入用户名！");
                <%}else{%>
                alert("Please enter user name!");
                <%} %>
                return;
            }
            if (pwd == "") {
                <%if (loginbtn == "zh-cn"){%> 
                alert("请输入密码！");
                <%}else{%>
                alert("Please enter password!");
                <%} %>
                return;
            }
            //登录会员中心
            document.getElementById("forVipLogin").src = "http://vip.<%=Domain %>/?name=" + userCode + "&pwd=" + pwd + "&lan=<%=loginbtn %>";
            $.getJSON(
               "Login.ashx?t=" + (new Date().valueOf()) + "&ucode=" + userCode + "&pwd=" + pwd,
                <%if (loginbtn == "zh-cn"){%> 
                function (data) {
                   switch (data) {
                       case 1: alert("用户不存在!"); break;
                       case 2: alert("用户名密码错误!"); break;
                       case 3: alert("账号未开通或已冻结不能登录!"); break;
                       case 0: alert("登录成功！"); $("#divCenter").show(); $("#divLogin").hide(); break;
                       case 4:
                           window.location.href = "../../Login.aspx";
                           break;
                           }
                   }
                <%}else{%>
                function (data) {
                   switch (data) {
                       case 1: alert("The user is not exists!"); break;
                       case 2: alert("UserName or Password wrong!"); break;
                       case 3: alert("Account is not opened or has been locked!"); break;
                       case 0: alert("Login success!"); $("#divCenter").show(); $("#divLogin").hide(); break;
                       case 4:
                           window.location.href = "../../Login.aspx";
                           break;
                           }
                   }
                <%} %>

            );
        });
    });
</script>
<iframe style="display:none" id="forVipLogin" src=""></iframe>
<div class="head">
    <div id="logo" class="shop">
        <a href="/user/shop/index.aspx" class="logo">
            <%if (loginbtn == "zh-cn")
              {%>商城<%}
              else
              {%>
            Shopping Mall
            <%} %>
        </a>
    </div>
    <div class="right login">
        <div class="right" style="margin: 5px 10px 0 10px;display:none;">
            <a href="registers.aspx" style="color: #ed8a00;">
                <asp:Label ID="Label1" runat="server" Text="我要注册" Style="color: #ed8a00;"></asp:Label><%--<%=GetLanguage("Register")%> 我要注册：--%></a></div>
        <div class="right" id="divLogin" style="margin: 5px 10px 0 10px;">
            <div style="float: left">
                <asp:Label ID="Label4" runat="server" Text="用户名"></asp:Label>：</div>
            <div style="float: left">
                <input id="ucode" type="text" value="" /></div>
            <div style="float: left; width: 20px;">
            </div>
            <div style="float: left">
                <asp:Label ID="Label5" runat="server" Text="密码"></asp:Label>：</div>
            <div style="float: left">
                <input id="pwd" type="password" value="" /></div>
            <div style="float: left">
                <%if (loginbtn == "zh-cn")
                  {%><input id="btnLogin" type="button" class="btn" value="登录" /><a href="http://www.<%=Domain %>/user/shop/index.aspx?lan=en-us">English</a><%}
                  else
                  {%>
                <input id="btnLogin" type="button" class="btn" value="Login" /><a href="http://www.<%=Domain %>/user/shop/index.aspx?lan=zh-cn">中文</a>
                <%} %>
            </div>
        </div>
        <div class="right" id="divCenter" style="margin: 5px 10px 0 10px;">
            <%--<a href="http://vip.<%=Domain%>/user/index.aspx" style="color: #ed8a00; margin-right: 20px;">--%>
            <a href="/user/index.aspx" style="color: #ed8a00; margin-right: 20px;">
                <asp:Label ID="MemberLab" runat="server" Text="会员中心" Style="color: #ed8a00;"></asp:Label></a>
            <a href="../../loginout.aspx?t=12" style="color: #ed8a00;">
                <asp:Label ID="LogOutLab" runat="server" Text="安全退出" Style="color: #ed8a00;"></asp:Label></a>
        </div>
    </div>
</div>
<%if (loginbtn == "zh-cn")
  {%>
<ul class="shopnav" id='<%=Url %>'>
    <li class="index"><a href="index.aspx">首页</a></li>
    <li class="man"><a href="channel.aspx?type=1&payment=2">男士</a></li>
    <li class="woman"><a href="channel.aspx?type=36&payment=2">女士</a></li>
    <li class="east"><a href="channel.aspx?type=37&payment=2">东方奢侈品</a></li>
    <li class="auction"><a href="Salesroom.aspx?payment=2">竞拍区</a></li>
    <li class="swap"><a href="channel.aspx?type=38&payment=1">积分换购</a></li>
    <li class="car right"><a href="shoppingcar.aspx">购物车</a></li>
</ul>
<%}
  else
  {%>
<ul class="shopnav" id='<%=Url %>'>
    <li class="index"><a href="index.aspx">Home</a></li>
    <li class="man"><a href="channel.aspx?type=1&payment=2">Man</a></li>
    <li class="woman"><a href="channel.aspx?type=36&payment=2">Lady</a></li>
    <li class="east"><a href="channel.aspx?type=37&payment=2">East Luxury</a></li>
    <li class="auction"><a href="Salesroom.aspx?payment=2">Auction Area</a></li>
    <li class="swap"><a href="channel.aspx?type=38&payment=1">Integration Redemption</a></li>
    <li class="car right"><a href="shoppingcar.aspx">Shopping Cart</a></li>
</ul>
<%} %>