<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salesroom.aspx.cs" Inherits="Web.user.shop.Salesroom" %>

<%@ Register Src="ShopHead.ascx" TagName="ShopHead" TagPrefix="uc1" %>
<%@ Register Src="shopSlider.ascx" TagName="shopSlider" TagPrefix="uc2" %>
<%@ Register Src="Foot.ascx" TagName="Foot" TagPrefix="uc3" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <%--  <meta http-equiv="X-UA-Compatible" content="IE=7" />--%>
    <title>
        <%=GetLanguage("ChannelTitle")%></title>
    <link href="../../style/Shop.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .goodlist
        {
            margin: 0px;
            height: 100%;
            overflow: hidden;
        }
        .countDown span{ width:100px;color:#e84800; font-weight:bold; }
    </style>
    <script type="text/javascript" charset="utf-8" src="../../js/jquery-1.7.1.min.js"></script>
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
            <div class="goodlist">
                <div class="goodtitle">
                    <span class="title">
                        <%=GetLanguage("AuctionGoods")%>
                        <%-- 竞拍商品--%></span>
                </div>
                <div class="good-ul">
                    <ul class="">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <li><a href="<%#Eval("SaID","SalesDetail.aspx?type=1&said={0}&payment=2") %>">
                                    <img src="../../Upload/<%#Eval("SaPrImage")%>" width="120" height="100" alt="<%#getstring(cnen,Eval("SaPrName").ToString()+"-"+Eval("SaPrName_en").ToString(),15)%>" /></a><br />
                                    <a href="<%#Eval("SaID","SalesDetail.aspx?type=1&said={0}") %>">
                                        <%#getstring(cnen, Eval("SaPrName").ToString() + "-" + Eval("SaPrName_en").ToString(), 15)%></a><br />
                                    <%=GetLanguage("MarketPrice")%>:
                                    <%-- 市场价：--%><%#Eval("SaPrice")%>
                                    <%=GetLanguage("USD")%>
                                    <%-- 美元：--%><br />
                                    <%=GetLanguage("BidPrice")%>:
                                    <%-- 竞拍价：--%><%#Eval("SaPrUsually")%>
                                    <%=GetLanguage("USD") %><!--美元-->
                                    <%#CountDown(Convert.ToInt32(Eval("SaID").ToString()), Convert.ToDateTime(Eval("SaBeginTime").ToString()))%>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="clear">
                    </div>
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
