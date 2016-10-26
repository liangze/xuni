<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="channel.aspx.cs" Inherits="Web.user.shop.channel" %>

<%@ Register Src="ShopHead.ascx" TagName="ShopHead" TagPrefix="uc1" %>
<%@ Register Src="shopSlider.ascx" TagName="shopSlider" TagPrefix="uc2" %>
<%@ Register Src="Foot.ascx" TagName="Foot" TagPrefix="uc3" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%--<meta http-equiv="X-UA-Compatible" content="IE=7" />--%>
    <title><%=GetLanguage("ChannelTitle")%><%-- 商城网站--%></title>
    <link href="../../style/Shop.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../js/jquery-1.7.1.min.js"></script>
    <style type="text/css">
        .goodlist
        {
            margin: 0px;
            height: 100%;
            overflow: hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Header">
        <!--nav begin-->
        <uc1:ShopHead ID="ShopHead1" runat="server" />
        <!--nav end-->
    </div>
    <div class="ShopBody">
        <div class="slider">
            <!--slider begin-->
            <uc2:shopSlider ID="shopSlider1" runat="server" />
            <!--slider end-->
        </div>
        <!--right begin-->
        <div class="rightBox">
            <div class="searchBox">
                <div style="float:left"><%=GetLanguage("CommodityName")%>: <%-- 商品名称：--%></div><div style="float:left"><input name="jd" type="text" id="txtGoodName" runat="server" class=" input_select" /></div>
                <div style="float:left;width:20px;"></div>
                <div style="float:left"><%=GetLanguage("CommodityPrice")%>: <%-- 商品价格：--%></div><div style="float:left"><input name="jd" type="text" id="txtPriceStar" runat="server" size="3" class=" input_select" /></div>
                <div style="float:left"><%=GetLanguage("To")%><%-- 至--%></div><div style="float:left"><input name="jd" type="text" id="txtPriceEnd" runat="server" size="3" class=" input_select" /></div>
                <div style="float:left"><asp:Button ID="btnSearch" runat="server" Text="" class="btn" OnClick="btnSearch_Click" /></div>
            </div>
            <div class="goodlist">
                <div class="goodtitle">
                    <span class="title"><%=GetLanguage("ProductShow")%>: <%-- 商品展示--%></span>
                </div>
                <div class="good-ul">
                    <ul class="">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <li><a href="<%#Eval("ID","detail.aspx?type=1&id={0}&payment="+payment) %>">
                                    <img src="../../Upload/<%#Eval("Pic1")%>" width="120" height="100" alt="<%#getstring(cnen,Eval("GoodsName").ToString()+"-"+Eval("GoodsName_en").ToString(),50)%>" /></a><br />
                                    <a href="<%#Eval("ID","detail.aspx?type=1&id={0}") %>">
                                        <%#getstring(cnen,Eval("GoodsName").ToString()+"-"+Eval("GoodsName_en").ToString(),15)%></a><br />
                                    <%=GetLanguage("MarketPrice")%>: <%-- 市场价：--%><%#Eval("Price")%>
                                    <%=GetLanguage("USD")%><%-- 美元：--%><br />
                                    <%=GetLanguage("MemberPrice")%>: <%-- 会员价：--%><%#Eval("Goods006")%>
                                    <%=GetLanguage("USD")%><%-- 美元：--%>
                                    <%#payment== 1 ? "<br />" + GetLanguage("Score") +": "+ Eval("Goods002").ToString() : ""%></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="clear">
                    </div>
                    <div style="height:20px;"></div>
                    <div class="yellow">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="20" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--right end-->
    <uc3:Foot ID="Foot1" runat="server" />
    </form>
</body>
</html>