<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusDetail.aspx.cs" Inherits="Web.user.finance.BonusDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <%--<meta http-equiv="x-ua-compatible" content="ie=7" />--%>
    <title>�ޱ����ĵ�</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="Form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("BonusDetails")%><%--������ϸ--%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("AwardName")%><!--��������-->��</label>
                        <span class="field">
                            <asp:DropDownList ID="dropBonus" runat="server">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" Text="�� ��" class="btn" OnClick="btnSearch_Click" />
                        &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="�� ��" class="btn" PostBackUrl="Bonus.aspx" />
                    </p>
                </div>
            </div>
            <table class="styled" style="font-size: inherit;">
                <thead>
                    <tr>
                        <th align="center">
                            <%=GetLanguage("AwardName")%><!--��������-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("BonusAmount")%><!--������-->
                        </th>
                        
                        <th align="center" style="display: none;">
                            <%=GetLanguage("Platform")%><!--ƽ̨����-->
                        </th>
                        <th>
                            <%=GetLanguage("SettlementDate")%><!--��������-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("State")%><!--״̬-->
                        </th>
                        <th align="center" style="display: none;">
                            <%=GetLanguage("Batch")%><!--����-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("Details")%><!--����-->
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
                                    <%--���--%>
                                </td>
                                
                                <td align="center" style="display: none;">
                                    <%#Eval("Bonus005")%>
                                    <%--���--%>
                                </td>
                                
                                <td align="center">
                                    <%#Eval("SttleTime")%><%--��������--%>
                                </td>
                                <td align="center">

                                    <%if (cnen == "zh-cn") %>
                                    <%{ %>
                                    <%#Convert.ToInt32(Eval("IsSettled")) == 1 ? "�ѷ���" : "δ����"%>
                                    <%}
                                      else
                                      { %>
                                    <%#Convert.ToInt32(Eval("IsSettled")) == 1 ? "Issue" : "Not issue"%>
                                    <%} %>

                                </td>
                                <th align="center" style="display: none;">
                                    <%#Eval("Batch")%><!--����-->
                                </th>
                                <td align="center">
                                    <%if (cnen == "zh-cn") %>
                                    <%{ %>
                                    <%#Eval("source")%><%-- ����--%>
                                    <%}
                                      else
                                      { %>
                                    <%#Eval("sourceen")%><%-- ����--%>
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
                                <%=GetLanguage("Manager")%><!--��Ǹ��Ŀǰ���ݿ�����������ʾ��--></span>
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
