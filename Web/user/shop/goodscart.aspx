<%@ Page Title="" Language="C#" MasterPageFile="~/user/shop/Index.Master" AutoEventWireup="true"
    CodeBehind="goodscart.aspx.cs" Inherits="Web.user.shop.goodscart" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/flow2.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(function () {
            var money = 0;
            $(".JS_goods_subtotal").each(function () {
                money += parseFloat($(this).html());
            });
            $("#JS_after").html(money);


            var jf = 0;
            $(".yenCount").each(function () {
                jf += parseFloat($(this).html());
            });
            $("#Span1").html(jf);


            //----------
            var i = $(".goods_select:checked").length;
            $("#JS_selected_num").html(i);
            $(".goods_select").change(function () {
                var j = $(".goods_select:checked").length;
                $("#JS_selected_num").html(j);

                var id = $(this).val();
                var m = $("#JS_goods_subtotal_" + id).html();

                var jf = $(this).val();
                var j = $("#JS_goods006_" + jf).html();
                if ($(this).prop("checked") == true) {

                    var objMoney = $("#JS_after").html();
                    var total = parseFloat(objMoney) + parseFloat(m);
                    $("#JS_after").html(total);

                    var objJf = $("#Span1").html();
                    var totalJf = parseFloat(objJf) + parseFloat(j);
                    $("#Span1").html(totalJf);
                } else {

                    var objMoney = $("#JS_after").html();
                    var total = parseFloat(objMoney) - parseFloat(m);
                    $("#JS_after").html(total);

                    var objJf = $("#Span1").html();
                    var totalJf = parseFloat(objJf) - parseFloat(j);
                    $("#Span1").html(totalJf);
                }
            });

        })

        function selectAll(obj) {
            var total = 0;
            var jifen = 0;
            if ($("#chk:checked").length > 0) {

                $(".goods_select").each(function () {
                    $(this).prop("checked", true);

                    var id = $(this).val();
                    var m = $("#JS_goods_subtotal_" + id).html();
                    total += parseFloat(m);

                    var jf = $(this).val();
                    var j = $("#JS_goods006_" + jf).html();
                    jifen += parseFloat(j);

                });
                var j = $(".goods_select:checked").length;
                $("#JS_selected_num").html(j);

                $("#JS_after").html(total);
                $("#Span1").html(jifen);
            }
            else {
                $(".goods_select").each(function () {
                    $(this).prop("checked", false);
                });
                var j = $(".goods_select:checked").length;
                $("#JS_selected_num").html(j);
                $("#JS_after").html(0);
                $("#Span1").html(0);
            }
        }

        function selectAll1(obj) {
            var total = 0;
            var jifen = 0;
            if ($("#chkAll:checked").length > 0) {

                $(".goods_select").each(function () {
                    $(this).prop("checked", true);

                    var id = $(this).val();
                    var m = $("#JS_goods_subtotal_" + id).html();
                    total += parseFloat(m);

                    var jf = $(this).val();
                    var j = $("#JS_goods006_" + jf).html();
                    jifen += parseFloat(j);

                });
                var j = $(".goods_select:checked").length;
                $("#JS_selected_num").html(j);

                $("#JS_after").html(total);
                $("#Span1").html(jifen);
            }
            else {
                $(".goods_select").each(function () {
                    $(this).prop("checked", false);
                });
                var j = $(".goods_select:checked").length;
                $("#JS_selected_num").html(j);
                $("#JS_after").html(0);
                $("#Span1").html(0);

            }
        }

        function Settlement() {
            var ids = "";
            $(".goods_select").each(function () {
                if ($(this).prop("checked") == true) {
                    var id = $(this).val();
                    ids += id + ",";
                }
            });
            if (ids != "") {
                location.href = "Settlement.aspx?IDS=" + encodeURI(ids);
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="w fl_header clearfix">
        &nbsp;<div class="Right fl_step fl_step_cart">
        </div>
    </div>
    <div class="flow_h2 w mt20 clearfix">
        <div class="Left text">
            我的购物车
        </div>
        <div class="Left select_num">
            已经选择<strong id="JS_selected_num" class="red">1</strong>件商品
        </div>
    </div>
    <table class="w mt20 cart_table" id="JS_list_table_cb">
        <tbody>
            <tr>
                <th class="first">
                    <input type="checkbox" class="JS_checkall_cb" id="chk" checked="checked" onclick="selectAll(this);"
                        title="全选" />
                </th>
                <th style="width: 36px" class="lbn l">全选
                </th>
                <th style="">商品
                </th>
                <th style="">名称
                </th>
                <th style="width: 8%">产品价格
                </th>
                <th style="width: 15%">数量
                </th>
                <th style="width: 8%">总价格
                </th>
                <th style="width: 10%">操作
                </th>
            </tr>
        </tbody>
        <tbody id="JS_cart_body_1">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="rptProduct" runat="server" OnItemCommand="rptProduct_ItemCommand">
                        <ItemTemplate>
                            <tr id="JS_cart_tr_11081797" class="goods_item JS_cart_act_0" data-act_id="0" data-rec_id="11081797">
                                <td>
                                    <input type="checkbox" checked="checked" id="JS_delete_checkbox_11081797" value='<%# Eval("ID")%>'
                                        class="goods_select" name="rec_id[]" data-auction_id="0">
                                </td>
                                <td colspan="2">
                                    <a href='goodsdetail.aspx?pid=<%# Eval("TypeID")%>&gid=<%# Eval("GoodsID")%>' target="_blank">
                                        <img class="img" src='../../Upload/<%# Eval("Pic1")%>' alt='<%# Eval("GoodsName")%> '
                                            width="90" height="58"></a>
                                </td>
                                <td class="l" style="line-height: 1.5; padding-left: 10px;">
                                    <a href='goodsdetail.aspx?pid=<%# Eval("TypeID")%>&gid=<%# Eval("GoodsID")%>' target="_blank">
                                        <%# Eval("GoodsName")%></a>
                                    <br />
                                <span>尺码：<%# Eval("gSize") %></span>
                                <br />
                                <span>颜色：<%# Eval("gColor") %></span>
                                </td>
                                <td class="yen">¥<%# Eval("Price")%></td>
                                <td>
                                    <div class="clearfix number">
                                        <asp:LinkButton ID="LinkButton1" class="Left sub" title="减少数量" runat="server" CommandName="subtract"
                                            CommandArgument='<%# Eval("ID")%>'></asp:LinkButton>
                                        <asp:TextBox runat="server" Text='<%# Eval("Goods006")%>' ID="JS_goods_number_11081797"
                                            class="Left num JS_cart_num_0" data-show_price="2499" data-shop_price="2899"
                                            data-rec_id="11081797"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton2" class="Left add" title="增加数量" runat="server" CommandName="add"
                                            CommandArgument='<%# Eval("ID")%>'></asp:LinkButton>
                                    </div>
                                </td>
                                <td>
                                    <span id='JS_goods006_<%# Eval("ID")%>' class="yenCount"><%# Eval("TotalMoney")%> </span>
                                    
                                </td>
                                <td>
                                    <asp:Button ID="btnDel" class="orange" CommandName="Del" CommandArgument='<%# Eval("ID")%>'
                                        OnClientClick="return confirm('您确认要删除吗?')" runat="server" Text="删除" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
            <tr align="center" runat="server" id="tr1">
                <td colspan="8" style="border: 0;">
                    <div>
                        抱歉，目前数据库中暂无记录显示！
                    </div>
                </td>
            </tr>
        </tbody>
        <tbody class="pt_box">
            <tr>
                <td colspan="8" class="pt_name"></td>
            </tr>
        </tbody>
        <tbody class="cart_extra">
            <tr>
                <th class="first rbn">
                    <input type="checkbox" class="JS_checkall_cb" id="chkAll" checked="checked" onclick="selectAll1(this);"
                        title="全选" />
                </th>
                <th class="lbn l">全选
                </th>
                <th class="lbn l">
                    <%-- <a href="javascript:;" onclick="flow_confirm(this,&#39;您确认要删除选中的商品吗?&#39;,deleteSelect);"
                        class="delete_cart_goods" title="删除选中商品">删除选中商品</a>--%>
                </th>
                <th colspan="5" class="lbn r">
                    <span class="f14"><b>总价格</b>：<span class="red yen total_price f16"><span id="Span1"
                        class="f24">6000</span></span></span>
                </th>
                <%--<th colspan="3" class="lbn r">
                    <span class="f14"><b>商品总价</b>(不含运费)：<span class="red yen total_price f16">¥<span
                        id="JS_after" class="f24">2499</span></span></span>
                </th>--%>
            </tr>
        </tbody>
    </table>
    <div style="margin: 0 auto; width: 600px; padding-left: 500px; padding-top: 5px;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
            NumericButtonCount="3" PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True"
            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
            SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
    </div>
    <div class="cart_button w r mt20">
        <a href="" class="back" title="继续购物"></a>
        <a style="cursor: pointer" class="check" id="js" title="去结算" onclick="Settlement()"></a>
    </div>

    <div class="height15">
    </div>

</asp:Content>
