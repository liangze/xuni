<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartDetail.aspx.cs" Inherits="Web.user.shop.CartDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <%-- <meta http-equiv="X-UA-Compatible" content="IE=7" />--%>
    <title>购物车</title>
    <link href="../../css/shop_indexcss.css" type="text/css" rel="stylesheet" />
    <link href="../../style/Shop.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../js/jquery-1.7.1.min.js"></script>
</head>
<body class="bg">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div style="height:20px;"></div>
        <div class="capositon">
            <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("ShopManagement")%>>><a href="javascript:void(0)"><%=GetLanguage("ShoppingCart")%></a>
            <!--我的购物车-->
        </div>


                <div class="cowrieArea">
                    <div class="cowrHead">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cowrHeaddate">
                            <tr>
                                <td width="11%">
                                    <%=GetLanguage("Image")%><%-- 图片--%>
                                </td>
                                <td width="13%">
                                    <%=GetLanguage("CommodityName")%><%-- 商品名称--%>
                                </td>
                                <td width="9%">
                                    <%=GetLanguage("Price")%><%-- 单价--%>
                                </td>
                                <td width="10%">
                                    <%=GetLanguage("Score")%><%-- 积分--%>
                                </td>
                                <td width="9%">
                                    <%=GetLanguage("Number")%><%-- 数量--%>
                                </td>
                                <td width="12%">
                                    <%=GetLanguage("TheTotalAmount")%><%-- 总金额--%>
                                </td>
                                <td width="10%">
                                    <%=GetLanguage("TotalScore")%><%-- 总积分--%>
                                </td>
                                <td width="16%">
                                    <%=GetLanguage("PaymentMethod")%><%-- 操作--%>
                                </td>
                                <td width="10%">
                                    <%=GetLanguage("Operation")%><%-- 操作--%>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- 店铺 -->
                    <div class="store">
                        <div class="storedear">
                            <!-- 产品 -->
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="storedate">
                                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td width="11%">
                                                        <a href='<%#Eval("Url") %>'>
                                                            <img src='../../Upload/<%# Eval("img") %>' width="50" height="50" alt="" /></a>
                                                    </td>
                                                    <td width="13%">
                                                        <a href='<%#Eval("Url") %>'>
                                                            <%# Eval("procudeName")%></a>
                                                    </td>
                                                    <td width="9%">
                                                        ￥<%# Eval("Goods006")%>
                                                    </td>
                                                    <td width="10%">
                                                        <%# Eval("Goods002")%>PV
                                                    </td>
                                                    <td width="9%">
                                                        <asp:HiddenField ID="hidid" runat="server" Value='<%# Eval("ProcudeID")%>' />
                                                        <ul class="numberchange">
                                                            <li class="lower">
                                                                <asp:ImageButton ID="imgbtnCut" runat="server" ImageUrl="../../images/Reduce0.jpg"
                                                                    Width="11" Height="11" align="absmiddle" OnClick="imgbtnCut_Click" />
                                                            </li>
                                                            <li class="intuo">
                                                                <asp:TextBox ID="txtCount" runat="server" class="input_num" onkeydown="if(event.keyCode==13)event.keyCode=9;"
                                                                    onKeyPress="if ((event.keyCode&lt;48 || event.keyCode&gt;57 ) &amp;&amp; event.keyCode!=46) event.returnValue=false;"
                                                                    Text='<%# Eval("count")%>' OnTextChanged="txtCount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                            </li>
                                                            <li class="add">
                                                                <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="../../images/add0.jpg" Width="11"
                                                                    Height="11" align="absmiddle" OnClick="imgbtnAdd_Click" />
                                                            </li>
                                                        </ul>
                                                    </td>
                                                    <td width="12%" class="red">
                                                        ￥<asp:Label ID="Label1" runat="server" Text='<%# Eval("totalMoney")%>'></asp:Label>
                                                    </td>
                                                    <td width="10%" class="red">
                                                        <asp:Label ID="lable1" runat="server" Text='<%# Eval("totalPV")%>'></asp:Label>PV
                                                    </td>
                                                    <td width="16%" class="red">
                                                        <asp:Label ID="Label2" runat="server" Text='<%#Convert.ToInt32(Eval("payMent")) == 1 ? GetLanguage("IntegrationRedemption"):GetLanguage("OtherPay")%>'></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                        <%if (GetLanguage("LoginLable") == "zh-cn")
                                                          {%>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument='<%# Eval("ProcudeID")%>'
                                                            OnClientClick="return confirm('确定删除吗？')">[删除]</asp:LinkButton>
                                                        <%}
                                                          else
                                                          { %>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="del" CommandArgument='<%# Eval("ProcudeID")%>'
                                                            OnClientClick="return confirm('Make sure delete ?')">[Delete]</asp:LinkButton>
                                                        <%} %>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="storedate">
                                <tr>
                                    <td colspan="6">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <!-- 产品 end -->
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="operating">
                                <div style="height: 30px;">
                                    <%=GetLanguage("OrderMoney")%>:
                                    <%-- 订货总金额：--%><strong><asp:Label ID="lilMoney" ForeColor="Red" runat="server" Text=""></asp:Label></strong>&nbsp;<%=GetLanguage("Yuan")%><%=GetLanguage("OrderScores")%>:
                                    <%-- 订货总积分：--%><strong><asp:Label ID="liJinfen" ForeColor="Red" runat="server" Text=""></asp:Label></strong>&nbsp;PV&nbsp;
                                    <%=GetLanguage("PaymentMethod")%>:
                                    <%--积分支付：--%>&nbsp;
                                    <%if (JfPayShow == true)
                                      {%>
                                    <input type="radio" id="rdoPv" name="rdo" runat="server" />
                                    <%=GetLanguage("ScorePay")%>
                                    <%}
                                      else
                                      {%>
                                    <input type="radio" id="rdoMoney" name="rdo" runat="server" />
                                    <%=GetLanguage("EmoneyPay")%>
                                    <input type="radio" id="rdoZX" name="rdo" runat="server" />
                                    <%=GetLanguage("OnlinePay")%><!--在线充值-->
                                    <%-- 拍币支付：--%>
                                    <%} %>
                                </div>
                                <%if (GetLanguage("LoginLable") == "zh-cn")
                                  {%>
                                <div class="clearing" style="">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/clearing1.jpg"
                                        OnClick="ImageButton1_Click" />
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../../images/clearing.jpg"
                                        OnClick="ImageButton2_Click" />
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../../images/tijiaodingdan.jpg"
                                        OnClick="ImageButton3_Click" />
                                </div>
                                <%}
                                  else
                                  { %>
                                <div class="clearing" style="">
                                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="../../images/clearing1_en.jpg"
                                        OnClick="ImageButton1_Click" />
                                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="../../images/clearing_en.jpg"
                                        OnClick="ImageButton2_Click" />
                                    <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="../../images/tijiaodingdan_en.jpg"
                                        OnClick="ImageButton3_Click" />
                                </div>
                                <%} %>
                                <p>
                                </p>
                                <div class="clear">
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- 删除或结单 end -->
                </div>

    </div>
    </form>
</body>
</html>
