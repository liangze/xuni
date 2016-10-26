<%@ Page Title="" Language="C#" MasterPageFile="~/user/shop/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.user.shop.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_week_recommend" runat="server">
    <asp:DataList ID="DataList_week_recommend" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
        <ItemTemplate>
            <div class="pic_box" style="padding-left: 13px">
                <a href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>">
                    <img alt="" style="width: 292px; height: 192px; border: 0px" src="../../Upload/<%# Eval("Pic1")%>" data-src2="../../Upload/<%# Eval("Pic1") %>">
                </a>
            </div>
            <div style="text-align: center; padding-left: 20px;" class="info">
                <a title="<%# Eval("GoodsName") %>" target="_blank" href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>"><%# Eval("GoodsName") %></a>
                </br>
                <label>本站价</label>
                <span class="yen red">￥</span>
                <strong class="pr red"><%# Eval("Price") %></strong>
                &nbsp<label>市场价</label>
                <span class="yen grey">￥</span>
                <strong class="pr grey"><%# Eval("Price") %></strong>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cph_week_quanggou" runat="server">
    <asp:DataList ID="DataList_quanggou" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
        <ItemTemplate>
            <div class="pic_box">
                <a href="tuangou_detail.aspx?pid=<%# Eval("TypeID") %>&id=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>">
                    <img alt="" style="width: 292px; height: 192px; border: 0px" src="../../Upload/<%# Eval("Pic1")%>" data-src2="../../Upload/<%# Eval("Pic1") %>">
                </a>
            </div>
            <div style="text-align: center; padding-left: 13px;" class="info">
                <a title="<%# Eval("GoodsName") %>" target="_blank" href="tuangou_detail.aspx?pid=<%# Eval("TypeID") %>&id=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>"><%# Eval("GoodsName") %></a>
                </br>
                <label>市场价</label>
                <span class="yen red">￥</span>
                <strong class="pr red"><%# Eval("Price") %></strong>
                &nbsp<label>竞拍价</label>
                <span class="yen grey">￥</span>
                <strong class="pr grey"><%# Eval("RealityPrice") %></strong>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--第一层 --%>
    <div class="w mt20 floor1 floor1_2">
        <div class="header clearfix">
            <div class="Left">
                <strong class="name">
                    <asp:HiddenField runat="server" ID="HiddenField1" />
                    <a class="title" href="shopList.aspx?layer=1" target="_blank"></a>
                </strong>
            </div>
        </div>
        <div class="main_new" id="JS_hover_img_box_1">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div class="pic_box">
                        <a href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>">
                            <img alt="" style="width: 292px; height: 192px; border: 0px" src="../../Upload/<%# Eval("Pic1")%>" data-src2="../../Upload/<%# Eval("Pic1") %>">
                        </a>
                    </div>
                    <div style="text-align: center;" class="info">
                        <a title="<%# Eval("GoodsName") %>" target="_blank" href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>"><%# Eval("GoodsName") %></a>
                        </br>
                <label>本站价</label>
                        <span class="yen red">￥</span>
                        <strong class="pr red"><%# Eval("Price") %></strong>
                        &nbsp<label>市场价</label>
                        <span class="yen grey">￥</span>
                        <strong class="pr grey"><%# Eval("Price") %></strong>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>

    <%--第二层 --%>
    <div class="w mt20 floor1">
        <div class="header clearfix">
            <div class="Left">
                <strong class="name">
                    <asp:HiddenField runat="server" ID="HiddenField2" />
                    <a class="title" href="shopList.aspx?layer=2" target="_blank"></a>
                </strong>
            </div>
        </div>
        <div class="main_new" id="JS_hover_img_box_2">
            <asp:DataList ID="DataList2" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div class="pic_box">
                        <a href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>">
                            <img alt="" style="width: 292px; height: 192px; border: 0px" src="../../Upload/<%# Eval("Pic1")%>" data-src2="../../Upload/<%# Eval("Pic1") %>"></a>
                    </div>
                    <div style="text-align: center;" class="info">
                        <a title="<%# Eval("GoodsName") %>" target="_blank" style="text-align: center;" href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>"><%# Eval("GoodsName") %></a>
                        <br>
                        <label>本站价</label>
                        <span class="yen red">￥</span>
                        <strong class="pr red"><%# Eval("Price") %></strong>
                        &nbsp<label>市场价</label>
                        <span class="yen grey">￥</span>
                        <strong class="pr #CCCCCC"><%# Eval("Price") %></strong>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>

    </div>

    <%--第三层--%>
    <div class="w mt20 floor1 floor2 cat_floor floor2_1">
        <div class="header clearfix">
            <div class="Left">
                <strong class="name">
                    <asp:HiddenField runat="server" ID="HiddenField3" />
                    <a class="title" href="shopList.aspx?layer=4" target="_blank"></a>
                </strong>
            </div>
        </div>
        <div class="main_new" id="JS_hover_img_box_3">
            <asp:DataList ID="DataList3" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div class="pic_box">
                        <a href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>">
                            <img alt="" style="width: 292px; height: 192px; border: 0px" src="../../Upload/<%# Eval("Pic1")%>" data-src2="../../Upload/<%# Eval("Pic1") %>"></a>
                    </div>
                    <div style="text-align: center;" class="info">
                        <a title="<%# Eval("GoodsName") %>" target="_blank" style="text-align: center;" href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>"><%# Eval("GoodsName") %></a>
                        <br>
                        <label>本站价</label>
                        <span class="yen red" style="text-align: center;">￥</span>
                        <strong class="pr red"><%# Eval("Price") %></strong>
                        &nbsp<label>市场价</label>
                        <span class="yen grey">￥</span>
                        <strong class="pr #CCCCCC"><%# Eval("Price") %></strong>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>

    <%--第四层--%>
    <div class="w mt20 floor1 floor2 cat_floor floor2_2">
        <div class="header clearfix">
            <div class="Left">
                <strong class="name">
                    <asp:HiddenField runat="server" ID="HiddenField4" />
                    <a class="title" href="shopList.aspx?layer=5" target="_blank"></a>
                </strong>
            </div>
        </div>
        <div class="main_new" id="JS_hover_img_box_4">
            <asp:DataList ID="DataList4" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div class="pic_box">
                        <a href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>">
                            <img alt="" style="width: 292px; height: 192px; border: 0px" src="../../Upload/<%# Eval("Pic1")%>" data-src2="../../Upload/<%# Eval("Pic1") %>"></a>
                    </div>
                    <div style="text-align: center;" class="info">
                        <a title="<%# Eval("GoodsName") %>" target="_blank" style="text-align: center;" href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>"><%# Eval("GoodsName") %></a>
                        <br>
                        <label>本站价</label>
                        <span class="yen red">￥</span>
                        <strong class="pr red"><%# Eval("Price") %></strong>
                        &nbsp<label>市场价</label>
                        <span class="yen grey">￥</span>
                        <strong class="pr #CCCCCC"><%# Eval("Price") %></strong>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>

    <%--第五层--%>
    <div class="w mt20 floor1 floor2 cat_floor floor2_3">
        <div class="header clearfix">
            <div class="Left">
                <strong class="name">
                    <asp:HiddenField runat="server" ID="HiddenField5" />
                    <a class="title" href="shopList.aspx?layer=6" target="_blank"></a>
                </strong>
            </div>
        </div>
        <div class="main_new" id="JS_hover_img_box_5">
            <asp:DataList ID="DataList5" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div class="pic_box">
                        <a href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>">
                            <img alt="" style="width: 292px; height: 192px; border: 0px" src="../../Upload/<%# Eval("Pic1")%>" data-src2="../../Upload/<%# Eval("Pic1") %>"></a>
                    </div>
                    <div style="text-align: center;" class="info">
                        <a title="<%# Eval("GoodsName") %>" target="_blank" style="text-align: center;" href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>"><%# Eval("GoodsName") %></a>
                        <br>
                        <label>本站价：</label>
                        <span class="yen red">￥</span>
                        <strong class="pr red"><%# Eval("Price") %></strong>
                        &nbsp<label>市场价</label>
                        <span class="yen #CCCCCC">￥</span>
                        <strong class="pr grey"><%# Eval("Price") %></strong>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>


</asp:Content>
