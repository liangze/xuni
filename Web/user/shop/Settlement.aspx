<%@ Page Language="C#" MasterPageFile="~/user/shop/Index.Master" AutoEventWireup="true" CodeBehind="Settlement.aspx.cs" Inherits="Web.user.shop.Settlement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <link href="http://localhost:2431/css/flow2.min.css" rel="stylesheet" type="text/css" />--%>
    <link href="css/flow2.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w mt10">
        <h1 class="fl_h1">确认订单信息</h1>
    </div>
    <div class="pre_box w">
        <a id="address_md" name="address_md"></a>
        <div id="JS_address_box__" class="currentBox">
            <div class="title" name="address_box" id="address_box" runat="server">
                <div class="text">收货人信息<a href="/user/index.aspx" onclick="edit_address();" name="JS_edit_address_nav" id="JS_edit_address_nav" class="orange" target="_blank">[ 管理收货地址 ]</a></div>
            </div>
            <div class="body" id="JS_edit_address_edit" runat="server">
                <script type="text/javascript">
                    function address_onclick(addr) {
                        addr.parent().parent().siblings().removeClass("error");
                        addr.parent().parent().addClass("error");
                    }
                </script>
                <table id="JS_address_input_table">
                    <tbody>
                        <asp:Repeater ID="address" runat="server">
                            <ItemTemplate>
                                <tr id='tr_<%#Eval("ID")%>' <%#Eval("Address01").ToString()=="1"?" class=\"error\"":""%>>
                                    <td>
                                        <input type="radio" value="<%#Eval("ID")%>" onclick="address_onclick($(this))" name="address" <%#Eval("Address01").ToString()=="1"?"checked":""%> /></td>
                                    <td align="left"><%#Eval("AreaInProvince")%> <%#Eval("Address")%> (<%#Eval("MemberName")%>收) <%#Eval("PhoneNum")%> <%#Eval("Phone").ToString()!=""?"、"+Eval("Phone"):""%></td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="trNoData" runat="server">
                            <td colspan="2" align="center">
                                <div class="NoData">
                                    <span class="cBlack">
                                        <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                        抱歉！目前数据库暂无数据。</span>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="body" id="JS_edit_address_show" style="display: none"></div>
        </div>
        <div class="title">
            <div class="text Left">商品清单</div>
            <div class="more Right"><a href="goodscart.aspx" class="back_to_crat orange"><span class="icon"></span>返回购物车修改</a></div>
        </div>
        <div class="body">
            <div style="border-bottom: 1px solid #ddd">
                <table id="JS_cart_table" class="cart_table">
                    <tbody>
                        <tr>
                            <th colspan="2">商品</th>
                            <th style="width: 8%">单价</th>
                            <th style="width: 14%">数量</th>
                            <th style="width: 8%">总金额</th>
                        </tr>
                    </tbody>
                    <asp:Repeater ID="rptProduct" runat="server">
                        <ItemTemplate>
                            <tbody id="JS_shop_list_1" class="shop_list" data-shop_id="1">
                                <tr id="JS_goods_list_11131779" data-rec="11131779" class="goods_list" data-goods_id="24189" data-act_id="0" data-goods_type="0" data-auction_id="0">
                                    <td class="first" style="line-height: 1.5; width: 110px; text-align: center;">
                                        <a href='goodsdetail.aspx?pid=<%# Eval("TypeID")%>&gid=<%# Eval("GoodsID")%>' target="_blank">
                                            <img class="img" src='../../Upload/<%# Eval("Pic1")%>' alt='<%# Eval("GoodsName")%> ' height="58" width="90"></a>
                                    </td>
                                    <td style="text-align: left;">
                                        <a href='goodsdetail.aspx?pid=<%# Eval("TypeID")%>&gid=<%# Eval("GoodsID")%>' target="_blank"><%# Eval("GoodsName")%></a>
                                        <p class="gray">编号：<%# Eval("GoodsCode")%></p>
                                       
                                        <span>尺码：<%# Eval("gSize") %></span>
                                        <br />
                                        <span>颜色：<%# Eval("gColor") %></span>
                                    </td>
                                    <td class="yen">¥<%# Eval("Price")%><div class="goods_install_fee goods_install_single" style="display: none;"></div>
                                    </td>
                                    <td class="yen"><span class="goods_number"><%# Eval("Goods006")%></span></td>
                                    <td>
                                        <div class="yen" id="goods_subtotal_11131779">¥<span class="show_price"><%# Eval("TotalMoney")%></span></div>
                                    </td>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr align="center" runat="server" id="tr1">
                        <td colspan="5" style="border: 0;">
                            <div style="display: none">
                                抱歉，目前数据库中暂无记录显示！
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="title">
            <div class="text Left">结算信息</div>
        </div>
        <div class="cart_extra" style="border: none; width: 1130px;">
            <div class="clearfix">
                <div class="Right r">
                    <span class="gray f14">产品金额共计：¥<asp:Label class="yen" ID="lblTotal" runat="server" Text=""></asp:Label>
                    </span>
                    <br />
                    <div id="JS_gift_goods" class="r red"></div>
                    <span class="f14 bt mt10"><b>应付总额</b>： ¥<asp:Label class="red yen total_price" ID="lblTotalPayable" runat="server" Text=""></asp:Label>
                    </span>
                </div>
            </div>
        </div>
    </div>
    <div style="width: 600px; margin: 0 auto; padding-top: 8px;">
        <span>支付方式:</span>&nbsp;&nbsp;<asp:RadioButtonList ID="rbtnPaymentMethod" runat="server"
            RepeatDirection="Horizontal">
        </asp:RadioButtonList>
    </div>
    <div class="mt20 r w">
        <div id="JS_submit_captcha" style="margin-bottom: 15px; display: none"></div>

        <span id="JS_submit_msg" style="color: #555">请先选择<a class="orange">支付方式</a>后再提交订单。</span>
        <%--<a href="javascript:;" id="JS_submit_form" style="vertical-align:middle;" onclick="checkAllForm();return false;" class="pre_submit pre_submit_no" title="提交订单"></a>--%>
        <asp:LinkButton ID="lbtnSubmit" runat="server"
            Style="vertical-align: middle;" class="pre_submit" title="提交订单" OnClientClick="return chkPayMode(this.form);"
            OnClick="lbtnSubmit_Click"></asp:LinkButton>
        <span id="JS_submit_wait" style="display: none" class="gray">正在提交订单，请耐心等候。</span>
    </div>
    <script type="text/javascript">
        function chkPayMode(f) {
            var chks = document.getElementsByName("ctl00$ContentPlaceHolder1$RadioButtonList1");
            if (chks[0].checked == false && chks[1].checked == false && chks[2].checked == false && chks[3].checked == false) {
                window.alert("请先选择 支付方式 后再提交订单！");
                return false;
            }
            $("#<%=lbtnSubmit.ClientID%>").css({ "display": "none" });
            $("#JS_submit_wait").css({ "display": "" });

            return true;
        }
    </script>
</asp:Content>
