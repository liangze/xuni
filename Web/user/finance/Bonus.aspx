<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bonus.aspx.cs" Inherits="Web.user.finance.Bonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�����ѯ</title>
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
                        <th>�������Ľ��ۼ�<%--1.�������Ľ�, 2.�Ƽ�����3.��̬�·ֺ콱��4.������--%>
                            <!--�������Ľ��ۼ�-->
                        </th>
                        <th>�Ƽ����ۼ�
                            <!--�Ƽ����ۼ�-->
                        </th>
                        <th>��̬�·ֺ콱�ۼ�
                            <!--��̬�·ֺ콱�ۼ�-->
                        </th>
                        <th>�������ۼ�
                            <!--�������ۼ�-->
                        </th>
                        
                        <th><%=GetLanguage("BonusCumulative")%>
                            <!--�����ۼ�-->
                        </th>
                        
                        <th style="display:none;"><%=GetLanguage("PlatformCumulative")%>
                            <!--ƽ̨�����ۼ�-->
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
                        <label><%=GetLanguage("SettlementDate")%><!--��������-->��</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" tip="�����������" runat="server" onfocus="WdatePicker()"></asp:TextBox>
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
                            <asp:TextBox ID="txtStartEn" tip="�����������" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEndEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" Text="�� ��" class="btn" OnClick="btnSearch_Click" />
                    </p>
                </div>
            </div>
            <table class="styled" style="font-size: inherit;">
                <thead>
                    <tr>
                        <th>�������Ľ�<%--1.�������Ľ�, 2.�Ƽ�����3.��̬�·ֺ콱��4.������--%>
                         
                        </th>
                        <th>
                            �Ƽ���
                            <!--2.�Ƽ���-->
                        </th>
                        <th>
                            ��̬�·ֺ콱
                            <!--3.��̬�·ֺ콱-->
                        </th>
                        <th>������
                            <!--4.������-->
                        </th>
                       
                        <th>
                            <%=GetLanguage("RealHair")%>
                            <!--ʵ��-->
                        </th>
                        <th>
                            <%=GetLanguage("SettlementDate")%>
                            <!--��������-->
                        </th>
                        <th>
                            <%=GetLanguage("ViewDetails")%>
                            <!--�鿴��ϸ-->
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%#Eval("Entryprize")%><%--1.�������Ľ�--%>
                                </td>
                                <td align="center">
                                    <%#Eval("Recommended")%><%--2.�Ƽ���--%>
                                </td>
                                <td align="center">
                                    <%#Eval("Shareout")%><%--3.��̬�·ֺ콱--%>
                                </td>
                                <td align="center">
                                    <%#Eval("ManagementAward")%><%--4.������--%>
                                </td>
                                
                                <td align="center">
                                    <%#Eval("sf")%><%--ʵ��--%>
                                </td>
                                <td align="center">
                                    <%#Eval("SttleTime")%><%--��������--%>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnDetail" runat="server"  PostBackUrl='<%#Eval("SttleTime","BonusDetail.aspx?SttleTime={0}") %>'><%=GetLanguage("ViewDetails")%><!--�鿴��ϸ--></asp:LinkButton>

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
