<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HonoraryAward.aspx.cs"
    Inherits="Web.user.finance.HonoraryAward" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>�����ѯ</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body class="">
    <form id="Form1" runat="server">
    <div class="box box_width">
        <div class="capositon">
        <%=GetLanguage("CurrentPosition")%>��<%=GetLanguage("Financial")%>>><a href="javascript:void(0)"><%=GetLanguage("AwardsQuery")%></a>
        </div>
        <div class="dataTable" align="center">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                       <%=GetLanguage("MembershipNumber")%> <!--��Ա���-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("LeftScore")%> <!--������ҵ������-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("RightScore")%> <!--������ҵ������-->
                    </th>
                    <th align="center">
                       <%=GetLanguage("HonoursLevel")%> <!--��������-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("HonorAward")%> <!--��������-->
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("LeftCount")%>
                            </td>
                            <td align="center">
                                <%#Eval("RightCount")%>
                            </td>
                            <td align="center">
                                <% if (Language == "zh-cn")
                               { %>
                                <%#Eval("AwardTitle")%>
                            <% }
                               else
                               { %>
                               <%#Eval("EnAwardTitle")%>
                            <% }%>
                                
                            </td>
                            <td align="center">
                            <% if (Language == "zh-cn")
                               { %>
                                <%#Eval("AwardDetail")%>
                            <% }
                               else
                               { %>
                              <%#Eval("EnAwardDetail")%>
                            <% }%>
                                
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="6">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                               <%=GetLanguage("NotHonor") %><!--����δ����κ�������--></span></div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin"  OnPageChanged="AspNetPager1_PageChanged"
                     AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                    PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                    UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
