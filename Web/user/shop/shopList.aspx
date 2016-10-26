<%@ Page Title="" Language="C#" MasterPageFile="~/user/shop/Index.Master" AutoEventWireup="true" CodeBehind="shopList.aspx.cs" Inherits="Web.user.shop.shopList" ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/tuango.min.css?00" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            var t = $("#<%=hidd.ClientID %>").val();
            $("#result").append(t);
            var count = $("#<%=hiddCount.ClientID %>").val();
            $("#count").html(count);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!----商品团购------------------>
    <div id="tuan_container" class="w">
        <div class="tg_pos">
            <span class="pos_icon"></span><a href="Default.aspx" class="pos_in">首页</a>&gt; <span
                style="font-family: 宋体; color: Red;">
                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
            </span>

        </div>
        <div class="tuan_serch">
            <div class="tuan_serch_t">
                <h3 class="Left">商品筛选：</h3>
                <%--<a href="shopList.aspx" class="Right">显示全部商品</a>--%>
            </div>
            <div id="result">
            </div>
            <asp:HiddenField ID="hidd" runat="server" />
            <div class="tuan_menu">
                <dl>
                    <dt>排序： </dt>
                    <dd>
                        <asp:LinkButton ID="LinkButton1" class="kind mrdesc" runat="server" OnClick="LinkButton1_Click">最新</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" class="kind mrdesc" runat="server" OnClick="LinkButton2_Click">销量</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" class="kind mrdesc" runat="server" OnClick="LinkButton3_Click">价格</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" class="kind mrdesc" runat="server" OnClick="LinkButton4_Click">折扣</asp:LinkButton>

                    </dd>
                </dl>
                <div class="totalbox Right">
                    <asp:HiddenField ID="hiddCount" runat="server" />
                    <span class="total">共计<b id="count">0</b>件商品</span>

                </div>
            </div>
        </div>
        <div id="tuan_list" class="tuan_list_container clearfix">
            <asp:Repeater ID="rptProduct" runat="server">
                <ItemTemplate>
                    <div class="tg_list">
                        <div class="tg_goods" onmouseover="this.className='tg_goods active';" onmouseout="this.className='tg_goods';">
                            <p class="name">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='goodsdetail.aspx?pid=<%# Eval("TypeID")%>&gid=<%# Eval("ID")%>'>
                                    <%# Eval("GoodsName")%></a>
                            </p>
                            <p class="tg_pic">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='goodsdetail.aspx?pid=<%# Eval("TypeID")%>&gid=<%# Eval("ID")%>'>
                                    <img width="266" height="176" alt='<%# Eval("GoodsName")%>' src='../../Upload/<%# Eval("Pic1")%>'></a>
                                <span class="tg_info"></span>
                                <span class="tg_info_1">
                                    <%--<倒计时>--%>
                                    <span style="display: none;">
                                        <%#Eval("Goods007")%></span>
                                    <span style="display: none;" class="Goods008RTime">
                                        <%#Eval("Goods008")%></span>
                                    <span class="Left" id="JS_over_time_26308" title='<%#Eval("Goods008")%>'></span>
                                    <%--<倒计时end>--%>
                                    <%-- <span class="Right">已团购：<b id="JS_already_number_26308"><%#Eval("SealCount")%></b>张</span>--%>
                                </span>
                            </p>
                            <a title='<%# Eval("GoodsName")%>' target="_blank" href='goodsdetail.aspx?pid=<%# Eval("TypeID")%>&gid=<%# Eval("ID")%>'
                                class="delstl gogo" id="JS_state_26308"><strong class="yen"><small>¥</small><%# Eval("Price")%></strong><span><b><%# Eval("Price")%>元</b>
                                    <br>
                                    <i>¥<%# Eval("Price")%>元</i></span></a>
                        </div>
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
