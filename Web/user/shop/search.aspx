<%@ Page Title="" Language="C#" MasterPageFile="~/user/shop/Index.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Web.user.shop.search" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../../css/tuango.min.css?00" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
//            var t = $("#<=hidd.ClientID >").val();
//            $("#result").append(t);
//            var count = $("#<=hiddCount.ClientID >").val();
//            $("#count").html(count);

            setInterval(RTime, 1000);

        });
        function RTime() {
            $.each($(".Goods008RTime"), function (i, val) {
                var stime = $(this).prev().html();
                var etime = $(this).html();
                var rTime = GetRTime(stime, etime);
                $(this).next().html(rTime);

            });

        }

        function GetRTime(stime, etime) {
            var NowTime = new Date();
            var sTime = new Date(stime); //开始时间 
            var t1 = sTime.getTime() - NowTime.getTime();
            if (t1 > 0) {
                var year = sTime.getFullYear();
                var month = sTime.getMonth() + 1;
                var date = sTime.getDate();
                var hours = sTime.getHours() < 10 ? "0" + sTime.getHours() : sTime.getHours();
                var minute = sTime.getMinutes() < 10 ? "0" + sTime.getMinutes() : sTime.getMinutes();
                return "开始时间：" + year + "年" + month + "月" + date + "日" + hours + ":" + minute + "";

            }
            var EndTime = new Date(etime); //截止时间 
            var t = EndTime.getTime() - NowTime.getTime();

            var d = Math.floor(t / 1000 / 60 / 60 / 24);
            var h = Math.floor(t / 1000 / 60 / 60 % 24);
            var m = Math.floor(t / 1000 / 60 % 60);
            var s = Math.floor(t / 1000 % 60);

            if (d < 0 || h < 0 || m < 0 || s < 0) {
                return "已结束";
            } else {
                return d + "天" + h + "时" + m + "分" + s + "秒";
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div id="tuan_list" class="tuan_list_container clearfix" style=" margin:0 auto;margin-top:10px;">
            <asp:Repeater ID="rptProduct" runat="server">
                <ItemTemplate>
                    <div class="tg_list">
                        <div class="tg_goods" onmouseover="this.className='tg_goods active';" onmouseout="this.className='tg_goods';">
                            <p class="name">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?id=<%# Eval("ID")%>' >
                                    <%# Eval("GoodsName")%></a>
                            </p>
                            <p class="tg_pic">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?pid=<%# Eval("PareTopChild")%>&id=<%# Eval("ID")%>' >
                                    <img width="266" height="176" alt='<%# Eval("GoodsName")%>' src='../../Upload/<%# Eval("Pic1")%>'></a>
                                <span class="tg_info"></span><span class="tg_info_1">
                                    <%--<倒计时>--%>
                                    <span style=" display:none;">
                                        <%#Eval("Goods007")%></span>
                                    <span style=" display:none;" class="Goods008RTime">
                                        <%#Eval("Goods008")%></span>
                                    <span class="Left" id="JS_over_time_26308" title='<%#Eval("Goods008")%>'>
                                        </span>
                                    <%--<倒计时end>--%>
                                    <span class="Right">已团购：<b id="JS_already_number_26308"><%#Eval("SealCount")%></b>张</span>
                                </span>
                            </p>
                            <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?id=<%# Eval("ID")%>' 
                                class="delstl gogo" id="JS_state_26308"><strong class="yen"><small>¥</small><%# Eval("RealityPrice")%></strong><span><b><%# Eval("Goods005")%></b>折
                                    <br>
                                    <i>¥<%# Eval("Price")%>元</i></span></a></div>
                        <p class="foot">
                        </p>
                        <div class="icon">
                            <span class="text1"></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
          <%--  <tr align="center" runat="server" id="tr1">
                <td colspan="10" style="border: 0;">
                    <div style="display: none">
                        抱歉，目前数据库中暂无记录显示！</div>
                </td>
            </tr>--%>
        </div>
       
       <%-- <div class="cPager c w">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>--%>



         <div id="Div1" class="tuan_list_container clearfix" style=" margin:0 auto;margin-top:10px;">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="tg_list">
                        <div class="tg_goods" onmouseover="this.className='tg_goods active';" onmouseout="this.className='tg_goods';">
                            <p class="name">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='goodsdetail.aspx?pid=<%# Eval("TypeID")%>&gid=<%# Eval("ID")%>'  >
                                    <%# Eval("GoodsName")%></a>
                            </p>
                            <p class="tg_pic">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='goodsdetail.aspx?pid=<%# Eval("TypeID")%>&gid=<%# Eval("ID")%>'  >
                                    <img width="266" height="176" alt='<%# Eval("GoodsName")%>' src='../../Upload/<%# Eval("Pic1")%>'></a>
                                <span class="tg_info"></span>
                                <span class="tg_info_1">
                                    <%--<倒计时>--%>
                                  <%--  <span style=" display:none;">
                                        <%#Eval("Goods007")%></span>
                                    <span style=" display:none;" class="Goods008RTime">
                                        <%#Eval("Goods008")%></span>
                                    <span class="Left" id="JS_over_time_26308" title='<%#Eval("Goods008")%>'>
                                        </span>--%>
                                    <%--<倒计时end>--%>
                                   <%-- <span class="Right">已团购：<b id="JS_already_number_26308"><%#Eval("SealCount")%></b>张</span>--%>
                                </span>
                            </p>
                            <a title='<%# Eval("GoodsName")%>' target="_blank" href='goodsdetail.aspx?pid=<%# Eval("TypeID")%>&gid=<%# Eval("ID")%>' 
                                class="delstl gogo" id="JS_state_26308"><strong class="yen"><small>¥</small><%# Eval("RealityPrice")%></strong><span><b><%# Eval("Goods005")%></b>折
                                    <br>
                                    <i>¥<%# Eval("Price")%>元</i></span></a></div>
                        <p class="foot">
                        </p>
                        <div class="icon">
                            <span class="text1"></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Panel runat="server" ID="NotingPanle" Visible="false">
            <tr align="center" runat="server" id="tr2">
                <td colspan="10" style="border: 0;">
                    <div style="display:block; margin-top:50px;">
                        抱歉，目前数据库中暂无记录显示！</div>
                </td>
            </tr>
            </asp:Panel>
        </div>


         <%--  <div class="cPager c w">
            <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>--%>
           <div id="Div3" class="tuan_list_container clearfix" style=" margin:0 auto;margin-top:10px;">
            <asp:Repeater ID="Repeater3" runat="server">
                <ItemTemplate>
                    <div class="tg_list">
                        <div class="tg_goods" onmouseover="this.className='tg_goods active';" onmouseout="this.className='tg_goods';">
                            <p class="name">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?pid=<%# Eval("PareTopChild")%>&id=<%# Eval("ID")%>' >
                                    <%# Eval("GoodsName")%></a>
                            </p>
                            <p class="tg_pic">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?pid=<%# Eval("PareTopChild")%>&id=<%# Eval("ID")%>' >
                                    <img width="266" height="176" alt='<%# Eval("GoodsName")%>' src='../../Upload/<%# Eval("Pic1")%>'></a>
                                <span class="tg_info"></span><span class="tg_info_1">
                                    <%--<倒计时>--%>
                                    <span style=" display:none;">
                                        <%#Eval("Goods007")%></span>
                                    <span style=" display:none;" class="Goods008RTime">
                                        <%#Eval("Goods008")%></span>
                                    <span class="Left" id="JS_over_time_26308" title='<%#Eval("Goods008")%>'>
                                        </span>
                                    <%--<倒计时end>--%>
                                    <span class="Right">已抢购：<b id="JS_already_number_26308"><%#Eval("SealCount")%></b>张</span>
                                </span>
                            </p>
                            <a title='<%# Eval("GoodsName")%>' target="_blank" href='tuangou_detail.aspx?pid=<%# Eval("PareTopChild")%>&id=<%# Eval("ID")%>' 
                                class="delstl gogo" id="JS_state_26308"><strong class="yen"><small>¥</small><%# Eval("RealityPrice")%></strong><span><b><%# Eval("Goods005")%></b>折
                                    <br>
                                    <i>¥<%# Eval("Price")%>元</i></span></a></div>
                        <p class="foot">
                        </p>
                        <div class="icon">
                            <span class="text1"></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <tr align="center" runat="server" id="tr3">
                <td colspan="10" style="border: 0;">
                    <div style="display: none">
                        抱歉，目前数据库中暂无记录显示！</div>
                </td>
            </tr>
        </div>

  <div id="Div2" class="tuan_list_container clearfix" style=" margin:0 auto ; margin-top:10px;">
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <div class="tg_list">
                        <div class="tg_goods" onmouseover="this.className='tg_goods active';" onmouseout="this.className='tg_goods';">
                            <p class="name">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='miaoshao.aspx?pid=<%# Eval("PareTopChild")%>&id=<%# Eval("ID")%>' >
                                    <%# Eval("GoodsName")%></a>
                            </p>
                            <p class="tg_pic">
                                <a title='<%# Eval("GoodsName")%>' target="_blank" href='miaoshao.aspx?pid=<%# Eval("PareTopChild")%>&id=<%# Eval("ID")%>' >
                                    <img width="266" height="176" alt='<%# Eval("GoodsName")%>' src='../../Upload/<%# Eval("Pic1")%>'></a>
                                <span class="tg_info"></span><span class="tg_info_1">
                                    <%--<倒计时>--%>
                                    <span style=" display:none;">
                                        <%#Eval("Goods007")%></span>
                                    <span style=" display:none;" class="Goods008RTime">
                                        <%#Eval("Goods008")%></span>
                                    <span class="Left" id="JS_over_time_26308" title='<%#Eval("Goods008")%>'>
                                        </span>
                                    <%--<倒计时end>--%>
                                    <span class="Right">已秒杀：<b id="JS_already_number_26308"><%#Eval("SealCount")%></b>张</span>
                                </span>
                            </p>
                            <a title='<%# Eval("GoodsName")%>' target="_blank" href='miaoshao.aspx?pid=<%# Eval("PareTopChild")%>&id=<%# Eval("ID")%>' 
                                class="delstl gogo" id="JS_state_26308"><strong class="yen"><small>¥</small><%# Eval("RealityPrice")%></strong><span><b><%# Eval("Goods005")%></b>折
                                    <br>
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
                        抱歉，目前数据库中暂无记录显示！</div>
                </td>
            </tr>
        </div>

</asp:Content>
