<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bonus.aspx.cs" Inherits="Web.user.finance.Bonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>奖金查询</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("MemberBonus")%></h2>
            <table class="styled" style="font-size: inherit;">
                <thead>
                    <tr>
                        <th>代理中心奖累计<%--1.代理中心奖, 2.推荐奖，3.静态月分红奖，4.对碰奖--%>
                            <!--代理中心奖累计-->
                        </th>
                        <th>推荐奖累计
                            <!--推荐奖累计-->
                        </th>
                        <th>静态月分红奖累计
                            <!--静态月分红奖累计-->
                        </th>
                        <th>对碰奖累计
                            <!--对碰奖累计-->
                        </th>
                        
                        <th><%=GetLanguage("BonusCumulative")%>
                            <!--奖金累计-->
                        </th>
                        
                        <th style="display:none;"><%=GetLanguage("PlatformCumulative")%>
                            <!--平台费用累计-->
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="odd">
                        <td align="center">
                            <%=GetBonus(getLoginID(), 1)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(getLoginID(), 2)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(getLoginID(), 3)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(getLoginID(), 4)%>
                        </td>
                       
                        <td align="center">
                            <%=GetBonusAllTotal(getLoginID(), "Amount")%>
                        </td>
                        
                        <td align="center" style="display:none;">
                            <%=GetBonusAllTotal(getLoginID(), "Bonus005")%>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div>&nbsp;</div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("SettlementDate")%><!--结算日期-->：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" tip="输入结算日期" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEnd" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStartEn" tip="输入结算日期" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEndEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
                    </p>
                </div>
            </div>
            <table class="styled" style="font-size: inherit;">
                <thead>
                    <tr>
                        <th>代理中心奖<%--1.代理中心奖, 2.推荐奖，3.静态月分红奖，4.对碰奖--%>
                         
                        </th>
                        <th>
                            推荐奖
                            <!--2.推荐奖-->
                        </th>
                        <th>
                            静态月分红奖
                            <!--3.静态月分红奖-->
                        </th>
                        <th>对碰奖
                            <!--4.对碰奖-->
                        </th>
                       
                        <th>
                            <%=GetLanguage("RealHair")%>
                            <!--实发-->
                        </th>
                        <th>
                            <%=GetLanguage("SettlementDate")%>
                            <!--结算日期-->
                        </th>
                        <th>
                            <%=GetLanguage("ViewDetails")%>
                            <!--查看明细-->
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%#Eval("Entryprize")%><%--1.代理中心奖--%>
                                </td>
                                <td align="center">
                                    <%#Eval("Recommended")%><%--2.推荐奖--%>
                                </td>
                                <td align="center">
                                    <%#Eval("Shareout")%><%--3.静态月分红奖--%>
                                </td>
                                <td align="center">
                                    <%#Eval("ManagementAward")%><%--4.对碰奖--%>
                                </td>
                                
                                <td align="center">
                                    <%#Eval("sf")%><%--实发--%>
                                </td>
                                <td align="center">
                                    <%#Eval("SttleTime")%><%--结算日期--%>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnDetail" runat="server"  PostBackUrl='<%#Eval("SttleTime","BonusDetail.aspx?SttleTime={0}") %>'><%=GetLanguage("ViewDetails")%><!--查看明细--></asp:LinkButton>

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
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True"
                    InputBoxClass="pageinput" NumericButtonCount="3" PageSize="12" ShowInputBox="Never"
                    ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"
                    pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
