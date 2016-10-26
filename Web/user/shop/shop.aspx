<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="Web.user.shop.shop" %>

    <%@ register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/shop_indexcss.css" type="text/css" rel="stylesheet" />
</head>
<body class="bg">
    <form id="form1" runat="server">
    <div class="default">
        <div class="clear">
            &nbsp;</div>
        <div class="default_top">
            当前位置：购物<span class="capositon"> &gt;&gt;<strong>商品列表</strong></span></div>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>商品名称：<input name="jd" type="text" id="txtGoodName"
                    runat="server" class=" input_select" />
                商品价格：<input name="jd" type="text" id="txtPriceStar" runat="server" class=" input_select1" />
                至<input name="jd" type="text" id="txtPriceEnd" runat="server" class=" input_select1" />
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" 
                    onclick="btnSearch_Click" />
            </fieldset>
        </div>
        <div class="shopping1">
            <ul>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li><span><img src='../../Upload/<%#Eval("Pic1")%>' width="150px" height="150px"></span><br />
                            <span class="shoppingtitle">【<%#Eval("typename2")%>】<%#getstring(Eval("GoodsName").ToString(),15)%></span>
                            <span class="shoppingm">￥<%#Eval("Price")%></span>
                            <span class="shoppingan"><asp:Button ID="btnGo" runat="server"  class="bbus" PostBackUrl='<%#Eval("ID","detail.aspx?type=1&id={0}") %>'/></span>
                            </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="clear">
            </div>
            <div class="yellow">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="16" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox"
                            showpageindexbox="Always" SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 "
                            OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                        </div>
            <div class="clear">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
