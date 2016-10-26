<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.user._default" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=getParamVarchar("SystemName2")%></title>
    <link href="../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2>&nbsp;&nbsp;<%=GetLanguage("Welcome")%><%--欢迎--%>&nbsp;&nbsp;<%=LoginUser.UserCode%>
            </h2>
            <table width="100%" cellpadding="10">
                <tbody>
                    <tr valign="top">
                        <td width="80%">
                            <div class="ico_body row-fluid collapse">
                                <div class="span2 ico_head collapse_head">
                                    <img alt="" src="../static/img/ico_user_white.png" /><br />
                                    <%=GetLanguage("MemberInfo")%><!--会员信息-->
                                </div>
                                <!--end of span2-->
                                <div class="span10 collapse_body">
                                    <div class="row-fluid">
                                        <div class="span3">
                                            <%=GetLanguage("Language")%><%--语言--%><p class="figure">
                                                <asp:DropDownList ID="dropLanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropLanguage_SelectedIndexChanged" CssClass="valid">
                                                    <%--<asp:ListItem Value="0">请选择</asp:ListItem>
                                                    <asp:ListItem Value="1">中文</asp:ListItem>
                                                    <asp:ListItem Value="2">English</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </p>
                                        </div>
                                        <div class="span3">
                                            <%=GetLanguage("TotalBonus")%><%--总奖金--%>(￥)<p class="figure"><%=GetBonusAllTotal(getLoginID(), "Amount")%></p>
                                        </div>
                                        <div class="span3">
                                            <%=GetLanguage("CirculatingGold")%><%--流通币--%>(￥)<p class="figure"><%=LoginUser.BonusAccount%></p>
                                        </div>
                                    </div>
                                    <!--end of row fluid-->
                                    <div class="row-fluid">
                                        <div class="span3">
                                            <%=GetLanguage("MDDDrill")%><%--MDD钻币--%>(￥)<p class="figure"><%=LoginUser.Emoney%></p>
                                        </div>
                                        <div class="span3" style="display:none;">
                                            <%=GetLanguage("Platform")%><%--平台费用--%>(￥)<p class="figure"><%=LoginUser.StockMoney%></p>
                                        </div>
                                        <div class="span3">
                                            <%=GetLanguage("Shoppingcurrency")%><%--购物币--%>(￥)<p class="figure"><%=LoginUser.ShopAccount%></p>
                                        </div>
                                        <div class="span3">
                                            <%=GetLanguage("Registeredcurrency")%><%--注册币--%>(￥)<p class="figure"><%=LoginUser.StockAccount%></p>
                                        </div>
                                        <div class="span4">
                                            <%=GetLanguage("PromotionLink")%><%--推广链接--%>：<p class="figure"><%="http://"+HttpContext.Current.Request.Url.Host+"/Register.aspx?UserID="+LoginUser.UserID%></p>
                                        </div>
                                        <!--end of span2-->
                                    </div>
                                    <!--end of row fluid-->
                                </div>
                                <!--end of span10-->
                            </div>
                            <!--end of ico body-->
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="row-fluid">
                <div style="margin-bottom: 10px;" class="row-fluid">
                    <div class="announce">
                        <%=GetLanguage("NewsInformation")%><%--新闻公告--%>
                    </div>
                </div>
            </div>
            <table class="styled">
                <tr>
                    <td align="center"><%=GetLanguage("SerialNumber")%><%--序号--%></td>
                    <td align="center"><%=GetLanguage("Title")%><%--标题--%></td>
                    <td align="center"><%=GetLanguage("Time")%><%--时间--%></td>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                            <td align="center">
                                <%# this.Repeater1.Items.Count + 1%> 
                            </td>
                            <td align="left">
                                <a href="member/NoticeDetail.aspx?ID=<%#Eval("ID") %>" style="color: Red;">» <%# getstring(Language,Eval("NewsTitle").ToString(),18)%></a>
                            </td>
                            <td align="center">
                                <%#Convert.ToDateTime(Eval("PublishTime")).ToString("")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="3" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
                    </td>
                </tr>
            </table>
            <div style="min-height: 130px;">&nbsp;</div>
        </div>
    </form>
</body>
</html>
