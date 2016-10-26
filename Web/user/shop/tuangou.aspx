<%@ Page Title="" Language="C#" MasterPageFile="~/user/shop/Index.Master" AutoEventWireup="true"
    CodeBehind="tuangou.aspx.cs" Inherits="Web.user.shop.tuangou" ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/tuango.min.css?00" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!----商品团购------------------>
    <div id="tuan_container" class="w">
        <div class="tg_pos">
            <span class="pos_icon"></span><a href="default.aspx" class="pos_in">首页</a> <span
                style="font-family: 宋体;">&gt;<span> <a href="tuangou.aspx" style="color: Red;">竞拍区</a> </span>
                &gt;<span> <a href="xianshiqianggou.aspx">竞拍</a> </span>
                <%--&gt;<span> <a href="miaoshaList.aspx">秒杀</a> </span>--%>
            </span>
        </div>
        <%--<div class="tuan_serch">
            <div class="tuan_serch_t">
                <h3 class="Left">商品筛选：</h3>
                <a href="tuangou.aspx" class="Right">显示全部商品</a>
            </div>
            <div id="result">
            </div>
            <asp:HiddenField ID="hidd" runat="server" />
        </div>--%>
        <div id="tuan_list" class="tuan_list_container clearfix">
            <asp:Repeater ID="rptProduct" runat="server">
                <ItemTemplate>
                    <div class="tg_list">
                        <div class="tg_goods" onmouseover="this.className='tg_goods active';" onmouseout="this.className='tg_goods';">
                            <p class="name">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?pid=<%# Eval("PareTopId")%>&id=<%# Eval("ID")%>'>
                                    <%# Eval("GoodsName")%></a>
                            </p>
                            <p class="tg_pic">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?pid=<%# Eval("PareTopId")%>&id=<%# Eval("ID")%>'>
                                    <img width="266" height="176" alt='<%# Eval("GoodsName")%>' src='../../Upload/<%# Eval("Pic1")%>'></a>
                                <span class="tg_info"></span><span class="tg_info_1">
                                    <%--<倒计时>--%>
                                    <%--<span style=" display:none;">
                                        <%#Eval("Goods007")%></span>
                                    <span style=" display:none;" class="Goods008RTime">
                                        <%#Eval("Goods008")%></span>
                                    <span class="Left" id="JS_over_time_26308" title='<%#Eval("Goods008")%>'>
                                        </span>--%>
                                    <%--<倒计时end>--%>
                                    <span class="Right">已竞拍：<b id="JS_already_number_26308"><%#Eval("SealPurchase")%></b>次</span>
                                </span>
                            </p>
                            <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?pid=<%# Eval("PareTopId")%>&id=<%# Eval("ID")%>'
                                class="delstl gogo" id="JS_state_26308"><strong class="yen"><small>¥</small><%# Eval("RealityPrice")%></strong><span><br>
                                    <i>¥<%# Eval("Price")%>元</i></span></a></div>
                        <p class="foot">
                        </p>
                        <div class="icon">
                            <span class="text1"></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <tr align="center" runat="server" id="tr1">
                <td colspan="10" style="border: 0;">
                    <div style="display: none">
                        抱歉，目前数据库中暂无记录显示！
                    </div>
                </td>
            </tr>
        </div>

        <div class="cPager c w">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
