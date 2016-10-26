<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="shopSlider.ascx.cs"
    Inherits="Web.user.shop.shopSlider" %>
<div class="slidertitle">
    <asp:Label ID="Label1" runat="server" Text="商品分类" class="slidertitle"></asp:Label>
</div>
<ul class="slider-ul ">
    <asp:Repeater ID="Repeater_ProductParent" runat="server" OnItemDataBound="Repeater_ProductParent_ItemDataBound">
        <ItemTemplate>
            <li class="cat"><a href="<%#Eval("url")%>" class="ta">
                <%#Eval("TypeName")%></a>
                <div id="cat<%# Container.ItemIndex %>" class="catlist">
                    <dl>
                        <dt><a href="<%#Eval("url")%>">
                        <%#Eval("TypeName") %>
<%--                        <%if(cnen == "zh-cn") {%>
                        <%#Eval("TypeName").ToString().Split('-')[0] %>
                        <% } else {%>
                        <%#Eval("TypeName").ToString().Split('-')[1] %>
                        <%} %>--%>
                            <%--<%#Eval("TypeName").ToString().Contains("-") == true ? Eval("TypeName").ToString().Split('-')[1]:Eval("TypeName") }%>--%>
                        </a></dt>
                        <dd>
                            <asp:Repeater ID="Repeater_ProductChild" runat="server">
                                <ItemTemplate>
                                    <em><a href="<%#Eval("url")%>">
                                        <%#Eval("TypeName")%></a></em>
                                </ItemTemplate>
                            </asp:Repeater>
                        </dd>
                    </dl>
                </div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
<script type="text/javascript">
    $(document).ready(function () {
        resetActivity();
    });
    function resetActivity() {
        var aindex = 0;
        $(".slider-ul .cat").mouseover(function () {
            aindex = $(".slider-ul .cat").index(this); //  
            $("#cat" + aindex).show();
        });
        $(".slider-ul .cat").mouseout(function () {
            aindex = $(".slider-ul .cat").index(this); //  
            $("#cat" + aindex).hide();
        });
    }
</script>
