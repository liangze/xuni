<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TableTree.aspx.cs" Inherits="Web.user.team.TableTree" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("MemberList")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("MembershipNumber")%><!--会员编号-->：</label>
                        <span class="field">
                            <input name="txtUserCode" id="txtUserCode" runat="server" type="text" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("OpeningDate")%><!--开通日期-->：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" tip="开通日期" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtStartEn" tip="Opening date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtEnd" tip="开通日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEndEn" tip="Opening date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn" />
                    </p>
                </div>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th align="center">
                            <%=GetLanguage("LoginInformation")%><!--会员编号-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("MemberName")%><!--会员姓名-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("MembershipLevels")%><!--会员级别-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("ReferenceNumber")%><!--推荐人编号-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("RegistrationHours")%><!--注册日期-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("OpeningDate")%><!--开通日期-->
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <a href="../member/PersonalInfo.aspx?UserID=<%# Eval("UserID")%>">
                                        <%# Eval("UserCode")%></a>
                                </td>
                                <td align="center">
                                    <%#Eval("TrueName")%>
                                </td>
                                <td align="center">
                                    <% if (Language == "zh-cn")
                                       { %>
                                    <%#Eval("LevelName")%>
                                    <% }
                                       else
                                       { %>
                                    <%#Eval("Level03")%>
                                    <% }%>
                                </td>
                                <td align="center">
                                    <%#Eval("RecommendCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("RegTime")%>
                                </td>
                                <td align="center">
                                    <%#Eval("OpenTime")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="6" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" />
                                抱歉！目前数据库暂无数据显示。</span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="nextpage cBlack">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True"
                    InputBoxClass="pageinput" NumericButtonCount="3" PageSize="12" ShowInputBox="Never"
                    ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"
                    pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="" Direction="LeftToRight"
                    HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
