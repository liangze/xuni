<%@ Page Title="" Language="C#" MasterPageFile="~/user/shop/Index.Master" AutoEventWireup="true" CodeBehind="xianshiqianggou.aspx.cs" Inherits="Web.user.shop.xianshiqianggou" ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/tuango.min.css?00" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .buy01 {
            background: url(../../images/tuangou_list_bg2.png) no-repeat scroll 0 -255px;
            color: #fff;
            display: inline-block;
            height: 46px;
            line-height: 46px;
            margin-top: 14px;
            padding-left: 10px;
            text-align: left;
            width: 256px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            var t = $("#<%=hidd.ClientID %>").val();
            $("#result").append(t);
            var count = $("#<%=hiddCount.ClientID %>").val();
            $("#count").html(count);

            //setInterval(RTime, 1000);

        });
        //function RTime() {
        //    $.each($(".Goods008RTime"), function (i, val) {
        //        var stime = $(this).prev().html();
        //        var etime = $(this).html();
        //        var rTime = GetRTime(stime, etime);
        //        $(this).next().html(rTime);

        //    });
        //}

        //function GetRTime(stime, etime) {
        //    var NowTime = new Date();
        //    var sTime = new Date(stime); //开始时间 
        //    var t1 = sTime.getTime() - NowTime.getTime();
        //    if (t1 > 0) {
        //        var year = sTime.getFullYear();
        //        var month = sTime.getMonth() + 1;
        //        var date = sTime.getDate();
        //        var hours = sTime.getHours() < 10 ? "0" + sTime.getHours() : sTime.getHours();
        //        var minute = sTime.getMinutes() < 10 ? "0" + sTime.getMinutes() : sTime.getMinutes();
        //        return "开始时间：" + year + "年" + month + "月" + date + "日" + hours + ":" + minute + "";

        //    }
        //    var EndTime = new Date(etime); //截止时间 
        //    var t = EndTime.getTime() - NowTime.getTime();

        //    var d = Math.floor(t / 1000 / 60 / 60 / 24);
        //    var h = Math.floor(t / 1000 / 60 / 60 % 24);
        //    var m = Math.floor(t / 1000 / 60 % 60);
        //    var s = Math.floor(t / 1000 % 60);

        //    if (d < 0 || h < 0 || m < 0 || s < 0) {
        //        return "已结束";
        //    } else {
        //        return d + "天" + h + "时" + m + "分" + s + "秒";
        //    }
        //}

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!----商品团购------------------>
    <div id="tuan_container" class="w">
        <div class="tg_pos">
            <span class="pos_icon"></span><a href="default.aspx" class="pos_in">首页</a> <span
                style="font-family: 宋体;">&gt;<span> <a href="tuangou.aspx">团购</a> </span>
                &gt;<span> <a href="xianshiqianggou.aspx" style="color: Red;">商品竞拍</a> </span></span>
        </div>
        <div class="tuan_serch">
            <div class="tuan_serch_t">
                <h3 class="Left">商品筛选：</h3>
                <a href="xianshiqianggou.aspx" class="Right">显示全部商品</a>
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
                        <%--<asp:LinkButton ID="LinkButton4" class="kind mrdesc" runat="server" OnClick="LinkButton4_Click">折扣</asp:LinkButton>--%>
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
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?pid=<%# Eval("PareTopId")%>&id=<%# Eval("ID")%>'>
                                    <%# Eval("GoodsName")%></a>
                            </p>
                            <p class="tg_pic">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?pid=<%# Eval("PareTopId")%>&id=<%# Eval("ID")%>'>
                                    <img width="266" height="176" alt='<%# Eval("GoodsName")%>' src='../../Upload/<%# Eval("Pic1")%>'></a>
                                <span class="tg_info"></span><span class="tg_info_1">
                                    <%--<倒计时>--%>
                                    <%--<span style="display: none;">
                                        <%#Eval("Goods007")%></span>
                                    <span style="display: none;" class="Goods008RTime">
                                        <%#Eval("Goods008")%></span>
                                    <span class="Left" id="JS_over_time_26308" title='<%#Eval("Goods008")%>'></span>--%>
                                    <%--<倒计时end>--%>
                                    <span class="Left">总竞拍：<b><%#Eval("Purchase")%></b>次</span>
                                    <span class="Right">已竞拍：<b id="JS_already_number_26308"><%#Eval("SealPurchase")%></b>次</span>
                                </span>
                            </p>
                            <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?pid=<%# Eval("PareTopId")%>&id=<%# Eval("ID")%>'
                                class="buy01" id="JS_state_26308"><strong class="yen"><small>¥</small><%# Eval("RealityPrice")%></strong><span>
                                    <i>原价：¥<%# Eval("Price")%>元</i></span></a>
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
