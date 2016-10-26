<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegSuccess.aspx.cs" Inherits="Web.user.shop.RegSuccess" %>

<%@ Register Src="ShopHead.ascx" TagName="ShopHead" TagPrefix="uc1" %>
<%@ Register Src="shopSlider.ascx" TagName="shopSlider" TagPrefix="uc2" %>
<%@ Register Src="Foot.ascx" TagName="Foot" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>注册成功</title>
    <link href="../../style/Shop.css" rel="stylesheet" type="text/css" />
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
    <div id="Header">
        <!--nav begin-->
        <uc1:shophead id="ShopHead1" runat="server" />
        <!--nav end-->
    </div>
    <div class="ShopBody">
        <div class="slider">
            <!--slider begin-->
            <uc2:shopslider id="shopSlider1" runat="server" />
            <!--slider end-->
        </div>
        <div class="rightBox">
            <div class="box box_width">
                <div class="dataTable">
                    <fieldset class="fieldset">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                            <tr>
                                <td align="left" style="height: 60px;">
                                    <span style="font-size: 25px; color: Green; font-weight: bold;">恭喜您注册成功！</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    您的会员编号为：<span style="color: Green;"><%=usercode %></span>&nbsp;&nbsp;&nbsp;&nbsp;
                                    注册级别：<span style="color: Green;"><%=levelname%></span>&nbsp;&nbsp;&nbsp;&nbsp; 注册金额：<span
                                        style="color: Green;"><%=money%>元</span>
                                </td>
                            </tr>
                            <%--                <tr>
                    <td align="left">
                        <span style="font-weight: bold;">请您选择以下功能操作：</span>
                    </td>
                </tr>--%>
                            <%if (getIntRequest("asd") == 1)
                              {%>
                            <%--                <tr>
                    <td align="left">
                        <span style="padding-left:80px;">您要开通会员请点击>> <a href="admin/business/Member.aspx">待开通会员</a></span>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span style="padding-left:80px;">您要充值E币请点击>> <a href="admin/finance/AddMoney.aspx">我要充值</a></span>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <span style="padding-left:80px;">您要继续注册新会员请点击>> <a href="admin/team/MemberTree.aspx?tt=1">系谱图</a></span>
                    </td>
                </tr>--%>
                            <%} %>
                            <%if (getIntRequest("asd") == 0)
                              {%>
                            <%--  <tr>
                    <td align="left">
                        <span style="padding-left:80px;">您要充值E币请点击>> <a href="user/finance/Remit.aspx">我要充值</a></span>
                    </td>
                </tr>
              <tr>
                    <td align="left">
                        <span style="padding-left:80px;">您要继续注册新会员请点击>> <a href="user/team/MemberTree.aspx?tt=<%=getLoginID() %>">系谱图</a></span>
                    </td>
                </tr>--%>
                            <%} %>
                        </table>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <uc3:Foot ID="Foot1" runat="server" />
    </form>
</body>
</html>
