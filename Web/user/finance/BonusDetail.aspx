<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusDetail.aspx.cs" Inherits="Web.user.finance.BonusDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <%--<meta http-equiv="x-ua-compatible" content="ie=7" />--%>
    <title>无标题文档</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="Form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("BonusDetails")%><%--奖金明细--%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("AwardName")%><!--奖项名称-->：</label>
                        <span class="field">
                            <asp:DropDownList ID="dropBonus" runat="server">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
                        &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="返 回" class="btn" PostBackUrl="Bonus.aspx" />
                    </p>
                </div>
            </div>
            <table class="styled" style="font-size: inherit;">
                <thead>
                    <tr>
                        <th align="center">
                            <%=GetLanguage("AwardName")%><!--奖项名称-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("BonusAmount")%><!--奖金金额-->
                        </th>
                        
                        <th align="center" style="display: none;">
                            <%=GetLanguage("Platform")%><!--平台费用-->
                        </th>
                        <th>
                            <%=GetLanguage("SettlementDate")%><!--结算日期-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("State")%><!--状态-->
                        </th>
                        <th align="center" style="display: none;">
                            <%=GetLanguage("Batch")%><!--批次-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("Details")%><!--详情-->
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%if (cnen == "zh-cn") %>
                                    <%{ %>
                                    <%#Eval("typename")%>
                                    <%}
                                      else
                                      { %>
                                    <%#Eval("typenameen")%>
                                    <%} %>

                                </td>
                                <td align="center">
                                    <%#Eval("amount")%>
                                    <%--金额--%>
                                </td>
                                
                                <td align="center" style="display: none;">
                                    <%#Eval("Bonus005")%>
                                    <%--金额--%>
                                </td>
                                
                                <td align="center">
                                    <%#Eval("SttleTime")%><%--结算日期--%>
                                </td>
                                <td align="center">

                                    <%if (cnen == "zh-cn") %>
                                    <%{ %>
                                    <%#Convert.ToInt32(Eval("IsSettled")) == 1 ? "已发放" : "未发放"%>
                                    <%}
                                      else
                                      { %>
                                    <%#Convert.ToInt32(Eval("IsSettled")) == 1 ? "Issue" : "Not issue"%>
                                    <%} %>

                                </td>
                                <th align="center" style="display: none;">
                                    <%#Eval("Batch")%><!--批次-->
                                </th>
                                <td align="center">
                                    <%if (cnen == "zh-cn") %>
                                    <%{ %>
                                    <%#Eval("source")%><%-- 详情--%>
                                    <%}
                                      else
                                      { %>
                                    <%#Eval("sourceen")%><%-- 详情--%>
                                    <%} %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="8" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
