<%@ Page Title="" Language="C#" MasterPageFile="~/user/shop/Index.Master" AutoEventWireup="true" CodeBehind="goodsdetail.aspx.cs" Inherits="Web.user.shop.goodsdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/goods_wide.css" rel="stylesheet" type="text/css" />

    <style>
        #bd .tb-clearfix, #bd .tb-key dl, #bd .tb-other, #bd .combo ul, #bd .scrolling-promo-content, .tb-popup-share .tb-tab-hd {
        }

        .clear, .tb-clear, .tb-clearfix {
        }

        ol, ul {
            list-style: outside none none;
        }

        ul {
            margin: 0px;
            padding: 0px;
        }

        .tb-prop li {
            float: left;
            position: relative;
            margin: 0px 5px 10px 0px;
            vertical-align: middle;
            line-height: 20px;
            background: #FFF none repeat scroll 0% 0%;
        }

            .tb-prop li a {
                display: inline-block;
                white-space: nowrap;
                text-decoration: none;
                padding: 3px 6px;
                min-width: 10px;
                text-align: center;
                border: 1px solid #DCDCDC;
                background: #FFF none repeat scroll 0% 0%;
                transition-property: border-color, background;
                transition-duration: 0.2s;
            }

        .tb-prop .tb-selected a, .tb-prop .tb-selected a:hover {
            padding: 2px 5px;
            color: #F40;
            border: 2px solid #F40;
            background: #FFF none repeat scroll 0% 0%;
        }
    </style>

    <script language="javascript">
        $(function () {
            var navH = $(".buttons").offset().top;
            $(window).scroll(function () {
                var scroH = $(this).scrollTop();
                if (scroH >= navH) {
                    $(".buttons").css({ "position": "fixed", "top": "-10px", "left": "50%", "margin-left": "-150px" });
                } else if (scroH < navH) {
                    $(".buttons").css({ "position": "static", "margin": "0 auto" });
                }
            })

            $(".J_TMySizeProp li").click(function () {
                $("#hsize").val(1);
                $(".J_TMySizeProp li").removeClass("tb-selected");
                $(this).addClass("tb-selected");
                $('#ctl00_ContentPlaceHolder1_hhsize').val($(".J_TMySizeProp .tb-selected a").html());
            });

            $(".J_TMyColorProp li").click(function () {
                $("#hsize").val(1);
                $(".J_TMyColorProp li").removeClass("tb-selected");
                $(this).addClass("tb-selected");
                $('#ctl00_ContentPlaceHolder1_hhcolor').val($(".J_TMyColorProp .tb-selected a").html());
            });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!----商品详细开始------------------>

    <asp:HiddenField ID="hiddConfirm" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="count" runat="server"></asp:HiddenField>
    <asp:Repeater runat="server" ID="rptProduct" OnItemCommand="rptProduct_ItemCommand" OnItemDataBound="rptProduct_ItemDataBound">
        <ItemTemplate>
            <script type="text/javascript">
                $(function () {
                    var navH = $(".buttons").offset().top;
                    $(window).scroll(function () {
                        var scroH = $(this).scrollTop();
                        if (scroH >= navH) {
                            $(".buttons").css({ "position": "fixed", "top": "-10px", "left": "50%", "margin-left": "-150px" });
                        } else if (scroH < navH) {
                            $(".buttons").css({ "position": "static", "margin": "0 auto" });
                        }
                    })
                })
            </script>

            <div id="JS_nav_guide" class="nav_guide w">
                <a href="Default.aspx">首页</a> <span>&gt;</span> <a href="shopList.aspx?ptype=<%# Eval("TypeID")%>"><%# Eval("typename1")%>  </a><span>&gt;</span>
                <span>&gt;</span> <%# Eval("GoodsName")%>
            </div>

            <div class="goods_title w" id="JS_goods_title_69904">
                <h1 class="goods_name">
                    <a id="JS_attr_title_brand" href="#" target="_blank" title='<%# Eval("GoodsName")%> '><%# Eval("GoodsName")%> </a>

                    <a id="JS_attr_title_material" href="#" target="_blank" title="皮艺"></a>
                    <span class="goods_sn" id="JS_attr_title_sn">编号：<%# Eval("GoodsCode")%></span><strong id="JS_attr_title_event" class="red f14"></strong></h1>

            </div>

            <div class="w clearfix">

                <div class="big_img Left">
                    <div>
                        <div class="img">
                            <div id="JS_attr_limit_buy" class="img_tags limit_buy" style="display: none"></div>
                            <div class="img_tags float_green" id="JS_attr_float_green" style="display: none">
                                <span class="text1">直降</span>
                                <span class="text2">5000</span>
                            </div>
                            <a id="JS_goods_img_panel_left" title='<%# Eval("GoodsName")%>' href="javascript:void(0);">
                                <img src='../../Upload/<%# Eval("Pic1")%>' alt='<%# Eval("GoodsName")%> ' height="374" width="565">
                            </a>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>

                    </div>
                    <div class="extra clearfix">
                        <div id="bdshare" class="Left bdshare_t bds_tools get-codes-bdshare">
                            <div class="bds_more extra_field share_bd">
                                <span class="extra_icon"></span><span class="extra_text">分享</span>
                            </div>
                        </div>
                        <div id="JS_collect_2" class="Left extra_field collect">
                            <span class="extra_icon"></span><span class="extra_text co red">收藏</span><span class="extra_text cd">已收藏</span>
                        </div>
                        <div id="JS_view_expr_online_video" class="Left extra_field online_video" title="体验馆在线视频" style="display: none">
                            <span class="extra_icon"></span><span class="extra_text co red">在线视频</span>
                        </div>
                        <span class="gray Right share_text"><a class="pays gray" target="_blank" title="" href="#"></a></span>

                    </div>
                </div>

                <div id="JS_panel_69904" class="panel Right current">
                    <div class="sale_price">
                        <p id="JS_panel_row_price_69904" class="gray"><span id="JS_panel_shop_price_69904" class=" none">产品价格：<span class="yen">¥<del><%# Eval("Price")%></del></span></span></p>
                        <div class="p_left">
                            <span class="gray" id="JS_panel_price_type_69905">产品价格：</span><span id="JS_panel_show_price_69905" class="red f24 yen bold">¥<%# Eval("Price")%></span>
                        </div>
                    </div>
                    <div class="infos clearfix">
                        <ul>
                            <li class="gray first" style="display: none;" id="JS_panel_activity_69904"><span class="active"><span id="JS_panel_active_type_69904" class="active_type"></span><span class="time none" id="JS_panel_time_69904">剩余：--天--小时--分</span></span></li>
                            <li class="gray" style="" id="Li1"><span class="">库 存</span>：<span class="red" id="kcun"><%# Eval("Pic5")%></span></li>
                            <li class="gray" style="" id="Li2"><span class="">类 型：</span><span class="red"><%# Eval("typename2")%></span></li>
                            <%--<li class="gray">已 售：<a href="javascript:void(0);" id="JS_boughts_notes_69904" class="red"><span id="JS_boughts_number_69904"><%# Eval("Pic4")%></span></a> 			
			</li>--%>

                            <li id="JS_panel_gift_69904" class="gray none"></li>

                        </ul>
                    </div>
                    <div id="JS_join_list" class="choose">
                        <asp:Panel ID="PanelProperty" runat="server">
                            <div id="detail" class="tb-skin">
                                <dl class="J_Prop J_TMySizeProp tb-prop tb-clear  J_Prop_measurement ">
                                    <dt>尺码：</dt>
                                    <dd>
                                        <ul class="J_TSaleProp tb-clearfix tb-prop">
                                            <asp:Repeater ID="rpSize" runat="server">
                                                <ItemTemplate>
                                                    <li><a><%#Eval("SizeName") %></a></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </dd>
                                </dl>
                                <dl class="J_Prop J_TMyColorProp tb-prop tb-clear  J_Prop_measurement ">
                                    <dt>颜色：</dt>
                                    <dd>
                                        <ul class="J_TSaleProp tb-img tb-clearfix tb-prop">
                                            <asp:Repeater ID="rpColor" runat="server">
                                                <ItemTemplate>
                                                    <li><a><%#Eval("ColorName") %></a></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </dd>

                                </dl>
                            </div>
                        </asp:Panel>
                            <dl class="clearfix">
                                <dt>数 量：</dt>
                                <dd>
                                    <input readonly="readonly" class="number" id="JS_goods_number_69904" value="1">
                                    <strong class="number_panel">
                                        <a href="javascript:;" id="JS_goods_number_add_69904" onclick="Add()"></a>
                                        <a href="javascript:;" id="JS_goods_number_del_69904" onclick="Del()"></a>
                                    </strong>
                                    （商品数量） </dd>
                            </dl>
                            <script type="text/javascript">
                                $(function () {
                                    var kc = $("#kcun").html();
                                    if (kc == "0") {
                                        var count = $("#JS_goods_number_69904").val(0);
                                    }
                                });
                                function Add() {
                                    var count = $("#JS_goods_number_69904").val();
                                    var kc = $("#kcun").html();
                                    var total = parseInt(count) + 1;

                                    if (total > parseInt(kc)) {
                                        total = parseInt(kc);
                                    }
                                    $("#JS_goods_number_69904").val(total);
                                    $("#<%=count.ClientID %>").val(total);
                                }

                                function Del() {
                                    var count = $("#JS_goods_number_69904").val(); //0
                                    var kc = $("#kcun").html(); //0
                                    if (kc != "0") {
                                        var total = parseInt(count) - 1;
                                        if (total < 1) {
                                            total = 1;
                                        }
                                        $("#JS_goods_number_69904").val(total);
                                        $("#<%=count.ClientID %>").val(total);
                                    }
                                }
                            </script>

                            <div class="buttons">
                                <asp:Button class="buy" ID="btnAdd" Style="cursor: pointer;" runat="server" ToolTip='<%# Eval("GoodsName")%> ' CommandName="btnAdd" />
                            </div>
                    </div>
            </div>
            </div>
            <div id="JS_float_anzhuang_2" class="float_anzhuang_2">
            </div>
            <div class="w clearfix mt10">
                <div class="main_right Left">
                    <a id="pj" name="pj"></a>
                    <div class="navs mt10">
                        <div style="height: 0px; position: absolute;" id="JS_float_navs_position"></div>
                        <div class="float_navs" id="JS_float_navs">
                            <a data-key="xinxi" class="current first" href="javascript:;" id="JS_Tab_nav_xinxi">商品详情</a>

                        </div>
                    </div>
                    <div class="xinxi clearfix mt10" id="JS_Tab_body_xinxi">
                        <div class="basic_info">
                            <dl>
                                <dt><%# Eval("Remarks")%></dt>
                            </dl>
                        </div>
                        <div class="sheji mt10 heihei" id="JS_Tab_body_sheji">
                        </div>
        </ItemTemplate>
    </asp:Repeater>
    <input type="hidden" id="hhcolor" runat="server" />
    <input type="hidden" id="hhsize" runat="server" />

    <tr align="center" runat="server" id="tr1">
        <td colspan="10" style="border: 0;">
            <div style="display: none">
                抱歉，目前数据库中暂无记录显示！
            </div>
        </td>
    </tr>


</asp:Content>
