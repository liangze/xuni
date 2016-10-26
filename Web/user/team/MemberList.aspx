<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="Web.user.team.MemberList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ѿ�ͨ��Ա</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("MyMarket")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("MembershipNumber")%><!--��Ա���-->��</label>
                        <span class="field">
                            <input name="txtUserCode" id="txtUserCode" runat="server" type="text" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("OpeningDate")%><!--��ͨ����-->��</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" tip="��ͨ����" runat="server" onfocus="WdatePicker()"></asp:TextBox>
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
                            <asp:TextBox ID="txtEnd" tip="��ͨ����" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
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
                        <th><%=GetLanguage("LoginInformation")%><!--��Ա���--></th>
                        <th><%=GetLanguage("MemberName")%><!--��Ա����--></th>
                        <th><%=GetLanguage("MembershipLevels")%><!--��Ա����--></th>
                        <th><%=GetLanguage("ReferenceNumber")%><!--�Ƽ��˱��--></th>
                        <th><%=GetLanguage("DeclarationNumber")%><!--�������ı��--></th>
                        <th><%=GetLanguage("RegistrationHours")%><!--ע������--></th>
                        <th><%=GetLanguage("OpeningDate")%><!--��ͨ����--></th>
                        <th><%=GetLanguage("WhetherOut")%><!--�Ƿ����--></th>
                        <th><%=GetLanguage("RecastNumber")%><!--��Ͷ����--></th>
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
                                <td align="left"><%#Eval("TrueName")%></td>
                                <td align="left">
                                    <% if (Language == "zh-cn")
                                       { %>
                                    <%#Eval("LevelName")%>
                                    <% }
                                       else
                                       { %>
                                    <%#Eval("Level03")%>
                                    <% }%></td>
                                <td align="left"><%#Eval("RecommendCode")%></td>
                                <td align="left"><%#Eval("User006")%></td>
                                <td align="left"><%#Eval("RegTime")%></td>
                                <td align="left"><%#Eval("OpenTime")%></td>
                                <td align="left">
                                    <% if (Language == "zh-cn")
                                       { %>
                                    <%#Eval("IsOut").ToString() == "1" ? "��" : "��"%>
                                    <% }
                                       else
                                       { %>
                                    <%#Eval("IsOut").ToString() == "1" ? "YES" : "NO"%>
                                    <% }%>
                                </td>
                                <td align="left"><%#Eval("Batch")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="12" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    <%=GetLanguage("Manager")%></span>
                            </div>
                        </td>
                    </tr>
                </tbody>
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
