<%@ Page Title="" Language="C#" MasterPageFile="~/user/shop/Index.Master" AutoEventWireup="true" CodeBehind="tuangou_detail.aspx.cs" Inherits="Web.user.shop.tuangou_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/tuangou_detail.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .buy02 {
            position: absolute;
            top: -1px;
            left: 0;
            display: block;
            width: 349px;
            height: 79px;
            background: url(../../images/tuan_detail2.png) no-repeat;
            text-indent: 30px;
            line-height: 79px;
            color: #fff;
            font-size: 35px;
            font-weight: bolder;
            font-family: "微软雅黑";
        }
    </style>
    <%--<script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/CookieStorage.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        //$(function () {

        //    setInterval(RTime, 1000);

        //});
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
        //        $("#hiddeTime").val(0);//未开始
        //        return "开始时间：" + year + "年" + month + "月" + date + "日" + hours + ":" + minute + "";

        //    }
        //    var EndTime = new Date(etime); //截止时间 
        //    var t = EndTime.getTime() - NowTime.getTime();

        //    var d = Math.floor(t / 1000 / 60 / 60 / 24);
        //    var h = Math.floor(t / 1000 / 60 / 60 % 24);
        //    var m = Math.floor(t / 1000 / 60 % 60);
        //    var s = Math.floor(t / 1000 % 60);

        //    if (d < 0 || h < 0 || m < 0 || s < 0) {
        //        $("#hiddeTime").val(1); //结束
        //        return "已结束";
        //    } else {
        //        $("#hiddeTime").val(2);
        //        return d + "天" + h + "时" + m + "分" + s + "秒";
        //    }
        //}

        function addNum() { //加

            var count = parseInt($("#JS_buy_num").val());
            var haveCount = parseInt($("#JS_left_number").html());
            count += 1;
            purchase = $("#purchasehide").val();
            console.log(purchase);
            if (count > parseInt(purchase) && count < haveCount)
                $("#JS_buy_num").val(purchase);
                //             else if (count > haveCount)
                //                  $("#JS_buy_num").val(haveCount);
            else
                $("#JS_buy_num").val(count);
        }
        function jianNum() { //减

            var count = parseInt($("#JS_buy_num").val());
            var haveCount = parseInt($("#JS_left_number").html());
            count -= 1;
            if (count == 0)
                $("#JS_buy_num").val(1);
            else
                $("#JS_buy_num").val(count);
        }


        function SubObj() {
            var state = $("#hiddeTime").val();
            var count = $("#JS_left_number").html();
            //if (state == 0) {
            //    alert("时间未开始!");
            //    return;
            //}
            //if (state == 1) {
            //    alert("时间已经结束!");
            //    return;
            //}
            if (count == 0) {
                alert("该商品已售完!");
                return;
            }
            var gid = $("#hiddId").val();
            var pid = $("#hiddPId").val();
            var sl = $("#JS_buy_num").val();
            location.href = "cxjs.aspx?pid=" + pid + "&gid=" + gid + "&sl=" + sl;
        }

        //          function shengyuObj() {
        //              var count = $("#JS_left_number").val();
        //              if (count == 0) {
        //                  $("#JS_buy_num").val(0);
        //              }
        //          }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!----商品团购 详细------------------>
    <div class="tugouWrap w">
        <input id="hiddeTime" type="hidden" />

        <asp:Repeater ID="rptProduct" runat="server" OnItemCommand="rptProduct_ItemCommand">
            <ItemTemplate>
                <input id="purchasehide" name="purchasehide" type="hidden" value="<%#Eval("Purchase") %>" />
                <div class="tg_pos">
                    <span class="pos_icon"></span><a href="Default.aspx" class="pos_in">首页</a> <span class="pos_quote">&gt;<span> <a href="ChangeUrl.aspx?type=<%# Eval("TypeID")%>" style="color: Red;"><%=OneName()%></a> <span class="pos_quote">&gt;<span> <%# Eval("typename1")%> <span class="pos_quote">&gt;<span> <%# Eval("GoodsName")%>	</span></span></span></span>
                </div>
                <div class="tg_dtl_wrap w clearfix">

                    <div class="tg_dtl_Left Left" style="height: 800px;">
                        <div class="tg_dtl_main">
                            <div class="dtl_main_top clearfix">
                                <h1 class="Left"><a target="_blank" title='<%# Eval("GoodsName")%>' href="#"><%# Eval("GoodsName")%></a></h1>
                                <p class="Right">
                                    编号：<%# Eval("GoodsCode")%><%--产地：广东--%>
                                </p>
                                <input id="hiddId" type="hidden" value='<%# Eval("ID")%>' />
                                <input id="hiddPId" type="hidden" value='<%# Eval("PareTopId")%>' />
                            </div>

                            <p class="dtl_main_tishi mt15">
                                （温馨提示：此商品价格已调至最低，不再参与其他促销优惠活动。）
                            </p>
                            <div class="dtl_main_info clearfix">
                                <div class="main_infoL Left" id="JS_time" data-startime="1394776800" data-endtime="1401551940" data-remainnum="6">
                                    <a title="" style="cursor: pointer;" onclick="SubObj();" class="buy02" id="JS_bnr_state" runat="server">

                                        <b>¥</b><%# Eval("RealityPrice")%></a><div class="numbox">
                                            <span>我要买：</span><%--<a href="javascript:;" class="jian" onclick="jianNum();"><b></b></a>--%><input type="text" id="JS_buy_num" value="1" class="val" readonly="readonly">
                                            <%--<a href="javascript:;" onclick="addNum();" class="jia"><b></b></a>--%>
                                        </div>
                                    <div class="buyed">
                                        市场价：<b>¥<%# Eval("Price")%></b><span>元</span>
                                    </div>
                                    <div class="buyed">
                                        竞拍价：<b>¥<%# Eval("RealityPrice")%></b><span>元</span>
                                    </div>
                                    <div class="buyed">
                                        竞拍次数：<b id="JS_already_number"><%#Eval("Purchase")%></b><span>次</span>
                                        <br>
                                        <span class="" id="JS_only_limit">仅剩<strong id="JS_left_number"><%# Convert.ToInt32( Eval("Purchase").ToString()) -Convert.ToInt32( Eval("SealPurchase").ToString())%></strong>次，请尽快竞拍！</span>
                                    </div>
                                    <div class="btnbox">
                                        <%--<a class="send" title="免费发短信告诉好友" onclick="M.sendSms(99999,{type:'groupbuy',id:'26308'});return false;" href="javascript:;">免费发短信告诉好友</a>--%><%--<a title="查看商品详情"  href="javascript:void(0);" class="link">查看商品详情</a>--%>
                                    </div>
                                </div>
                                <div class="main_infoR Right">
                                    <p>
                                        <a title='<%# Eval("GoodsName")%>' target="_blank" href="#">
                                            <img width="600" height="400" src='../../Upload/<%# Eval("Pic1")%>'></a>
                                    </p>
                                    <div class="infoshare clearfix">
                                        <div class="Right">
                                            <div id="bdshare" class="bdshare_t bds_tools get-codes-bdshare">
                                                <a href="#" title="分享到QQ空间" class="bds_qzone"></a>
                                                <a href="#" title="分享到新浪微博" class="bds_tsina"></a>
                                                <a href="#" title="分享到腾讯微博" class="bds_tqq"></a>
                                                <a href="#" title="分享到人人网" class="bds_renren"></a>
                                                <a href="#" title="分享到复制网址" class="bds_copy"></a>
                                                <span class="bds_more"></span>
                                            </div>
                                        </div>
                                        <%--<p class="Right">
										分享到：
									</p>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tg_dtl_box" style="width: auto;">
                            <div class="title">
                                <b class="f14">本单详情</b>
                            </div>
                            <div class="content infos">
                                <dl>
                                    <dt><%# Eval("Remarks")%></dt>
                                </dl>

                                <div class="imgs">
                                </div>
                            </div>
                        </div>

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

</asp:Content>
