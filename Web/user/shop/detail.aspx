<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="Web.user.shop.detail" %>

<%@ Register Src="ShopHead.ascx" TagName="ShopHead" TagPrefix="uc1" %>
<%@ Register Src="shopSlider.ascx" TagName="shopSlider" TagPrefix="uc2" %>
<%@ Register Src="Foot.ascx" TagName="Foot" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <%-- <meta http-equiv="X-UA-Compatible" content="IE=7" />--%>
    <title>
        <%=GetLanguage("ProductDetailTitle")%><%-- 商品详情--%></title>
    <link href="../../style/Shop.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../js/jquery-1.7.1.min.js"></script>
    <link href="../../css/shop_indexcss.css" type="text/css" rel="stylesheet" />
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
        <div class="rightBox">
            <div style="clear: both;">
                <div class="Product_Search" id="div_no" runat="server" visible="false">
                    <div style="padding-bottom: 25px; line-height: 26px; padding-left: 40px; padding-right: 40px;
                        font-size: 14px; padding-top: 25px">
                        <%=GetLanguage("ProductDetailInvalidOperation")%>:
                        <%-- 无效的操作!--%>
                    </div>
                </div>
                <div class="Product_Search" id="div_yes" runat="server" visible="false">
                    <div class="product_con">
                        <div class="shopping">
                            <div class="shopping_left">
                                <img id="img1" runat="server" width="300" alt="" src="" />
                            </div>
                            <div class="shopping_right">
                                <%--<h1>
                                    ￥<asp:Label ID="Label1" runat="server" Text=""></asp:Label></h1>--%>
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="floatRight">
                                            <%=GetLanguage("ItemNumber")%>:
                                            <%-- 商品编号：--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                            <asp:Label ID="lbpId" runat="server" Text="" Style="display: none;"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="floatRight">
                                            <%=GetLanguage("CommodityName")%>:
                                            <%-- 商品名称：--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="floatRight">
                                            <%=GetLanguage("HasSold")%>:
                                            <%-- 已销售：--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="floatRight">
                                            <%=GetLanguage("Inventory")%>:
                                            <%-- 库存：--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="li1" runat="server" visible="false">
                                        <td class="floatRight">
                                            <%=GetLanguage("PurchaseQuantity")%>:
                                            <%-- 购买数量：--%>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgbtnCut" runat="server" ImageUrl="../../images/Reduce0.jpg"
                                                Width="11" Height="11" align="absmiddle" OnClick="imgbtnCut_Click" />
                                            <input id="txtNum" runat="server" style="width: 50px;" onkeydown="if(event.keyCode==13)event.keyCode=9;"
                                                value="1" onkeypress="if ((event.keyCode&lt;48 || event.keyCode&gt;57 ) &amp;&amp; event.keyCode!=46) event.returnValue=false;"
                                                type="text" />
                                            <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="../../images/add0.jpg" Width="11"
                                                Height="11" align="absmiddle" OnClick="imgbtnAdd_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="floatRight">
                                            <%=GetLanguage("MarketPrice")%>:
                                            <%-- 市场价：--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>&nbsp;$
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="floatRight">
                                            <%=GetLanguage("MemberPrice")%>:
                                            <%-- 会员价：--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>&nbsp;$
                                        </td>
                                    </tr>
                                    <tr <%=payment== 1?"":"style='display:none'" %>>
                                        <td class="floatRight">
                                            <%=GetLanguage("Score")%>:
                                            <%-- 积分：--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbScore" runat="server" Text=""></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="floatRight">
                                            <%=GetLanguage("TotalAmount")%>:
                                            <%-- 总额：--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>&nbsp;<%#payment== 1 ? "" : "$"%>
                                        </td>
                                    </tr>
                                    <tr id="li2" runat="server" visible="false">
                                        <td colspan="2">
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                              {%>
                                            <asp:Button ID="btn1" runat="server" Text="" class="buts" OnClick="btnSubmit_Click" />
                                            <%}
                                              else
                                              {%>
                                            <asp:Button ID="btnSubmit" runat="server" Text="" class="buts_en" OnClick="btnSubmit_Click" />
                                            <%} %>
                                        </td>
                                    </tr>
                                </table>
                                <%--<ul>
                                    <li>商品编号：<span><asp:Label ID="Label4" runat="server" Text=""></asp:Label></span></li>
                                    <li>商品名称：<span><asp:Label ID="Label2" runat="server" Text=""></asp:Label></span></li>
                                    <li>已销售：<span><asp:Label ID="Label5" runat="server" Text=""></asp:Label></span></li>
                                    <li>库存：<span><asp:Label ID="Label3" runat="server" Text=""></asp:Label></span></li>
                                    <li id="li1" runat="server" visible="false">购买数量：<asp:ImageButton ID="imgbtnCut"
                                        runat="server" ImageUrl="../../images/Reduce0.jpg" Width="11" Height="11" align="absmiddle"
                                        OnClick="imgbtnCut_Click" />
                                        <input id="txtNum" runat="server" style="width: 50px;" onkeydown="if(event.keyCode==13)event.keyCode=9;"
                                            value="0" onkeypress="if ((event.keyCode&lt;48 || event.keyCode&gt;57 ) &amp;&amp; event.keyCode!=46) event.returnValue=false;"
                                            type="text" />
                                        <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="../../images/add0.jpg" Width="11"
                                            Height="11" align="absmiddle" OnClick="imgbtnAdd_Click" />
                                    </li>
                                    <li>市场价：<span><asp:Label ID="Label6" runat="server" Text=""></asp:Label></span></li>
                                    <li>会员价：<span><asp:Label ID="Label7" runat="server" Text=""></asp:Label></span></li>
                                    <li>总额：<span><asp:Label ID="Label8" runat="server" Text=""></asp:Label></span></li>
                                    <li id="li2" runat="server" visible="false">
                                        <asp:Button ID="btnSubmit" runat="server" Text="" class="buts" OnClick="btnSubmit_Click" />
                                    </li>
                                </ul>--%>
                            </div>
                            <div style="clear: both; margin-top: 10px">
                            </div>
                        </div>
                    </div>
                    <div class="Product_top">
                        <%=GetLanguage("ProductDetails")%>
                        <%-- 商品详细信息--%></div>
                    <div style="clear: both">
                    </div>
                    <div class="product_con">
                        <div style="word-spacing: 3px; text-indent: 2em; margin-bottom: 10px; text-align: left">
                            <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc3:Foot ID="Foot1" runat="server" />
    </form>
</body>
</html>
