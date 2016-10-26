<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.user.shop.index" %>

<%@ Register Src="ShopHead.ascx" TagName="ShopHead" TagPrefix="uc1" %>
<%@ Register Src="shopSlider.ascx" TagName="shopSlider" TagPrefix="uc2" %>
<%@ Register Src="Foot.ascx" TagName="Foot" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <%-- <meta http-equiv="X-UA-Compatible" content="IE=7" />--%>
    <title><%=GetLanguage("shopindextitle")%></title>
    <link href="../../style/Shop.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../js/jquery-1.7.1.min.js"></script>
    <script src="../../css/swf/swfobject.js" type="text/javascript"></script>
    <script type="text/javascript">
        var xmlData = '<list><%=imgstr %></list>';
        var flashvars = { xmlData: xmlData };
        var params = { menu: false, wmode: "opaque" };
        var attributes = {};
        swfobject.embedSWF("../../css/swf/niu.swf", "inner", "810", "215", "5", "expressInstall.swf", flashvars, params, attributes);
  
    
    </script>
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
            <div class="rightBanner">
                <div id="inner">
                    <%-- <img src="../../images/shopbanner.png" width="810" height="215" alt="" />--%></div>
            </div>
            <div class="goodlist">
                <div class="goodtitle">
                    <span class="title">
                        <%=GetLanguage("ProductShow")%>
                        <%-- 商品展示--%></span><span class="more"><a href="channel.aspx"><%=GetLanguage("More")%>
                            <%-- 更多--%>>></a></span>
                </div>
                <ul class="good-ul">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <li><a href="<%#Eval("ID","detail.aspx?type=1&id={0}&payment=2") %>">
                                <img src="../../Upload/<%#Eval("Pic1")%>" width="120" height="100" alt="<%#getstring(cnen,Eval("GoodsName").ToString() + "-" + Eval("GoodsName_en").ToString(),15)%>" /></a><br />
                                <a href="<%#Eval("ID","detail.aspx?type=1&id={0}&payment=2") %>">
                                    <%#getstring(cnen, Eval("GoodsName").ToString() + "-" + Eval("GoodsName_en").ToString(), 8)%></a><br />
                                <%=GetLanguage("MarketPrice")%>:
                                <%-- 市场价：--%><%#Eval("Price")%>
                                <%=GetLanguage("USD")%>
                                <%-- 美元--%><br />
                                <%=GetLanguage("MemberPrice")%>:
                                <%-- 会员价：--%><%#Eval("Goods006")%>
                                <%=GetLanguage("USD")%>
                                <%-- 美元--%></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <!--right end-->
    </div>
    <div class="ShopBody">
        <div class="FriendBox">
            <div class="FriendTitle">
                <%if (GetLanguage("ShortLinksImg") == "links")
                  {%>
                <div class="titles">
                </div>
                <% }
                  else
                  {%>
                <div class="titles_en">
                </div>
                <%} %>
            </div>
            <%if (GetLanguage("LinksImg") == "link-ul")
              {%>
            <ul class="link-ul">
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(2)%>" class="a" title="公司简介"></a></li>
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(3)%>" class="a2" title="购买导航">
                </a></li>
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(4)%>" class="a3" title="商家联盟">
                </a></li>
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(5)%>" class="a4" title="官方网站">
                </a></li>
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(8)%>" class="a5" title="最新活动">
                </a></li>
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(6)%>" class="a6" title="联系我们">
                </a></li>
            </ul>
            <% }
              else
              {%>
            <ul class="link-ul-en">
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(2)%>" class="a" title="About Us"></a></li>
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(3)%>" class="a2" title="BuyNavigation">
                </a></li>
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(4)%>" class="a3" title="Business Union">
                </a></li>
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(5)%>" class="a4" title="Official Site">
                </a></li>
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(8)%>" class="a5" title="Latest Activity">
                </a></li>
                <li><a href="NoticeDetail.aspx?id=<%=GetNewIDByNewType(6)%>" class="a6" title="Contact Us">
                </a></li>
            </ul>
            <%} %>
        </div>
    </div>
    <uc3:Foot ID="Foot1" runat="server" />
    </form>
</body>
</html>