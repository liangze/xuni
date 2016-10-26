<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecommendBonus.aspx.cs"
    Inherits="Web.user.finance.RecommendBonus" %>

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
            <%=GetLanguage("CurrentPosition")%>��<%=GetLanguage("FinancialQueries")%>>><a href="javascript:void(0)"><%=GetLanguage("RecommendInfo")%></a>
            <asp:Button ID="Button1" runat="server" Text="�˻���ѯ" class="btn" PostBackUrl="dl_JournalAccount.aspx" />
            <%--<asp:Button ID="Button4" runat="server" Text="�˻�ת��" class="btn" PostBackUrl="TransferToEmoney.aspx" />--%>
        </div>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">
                    <%=GetLanguage("Query")%>
                    <!--��ѯ-->
                </legend>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr>
                        <td>
                            <%=GetLanguage("SettlementDate")%>
                            <!--��������-->
                            ��
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStar" tip="�����������" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                            <%=GetLanguage("To")%><!--��-->
                            <asp:TextBox ID="txtEnd" tip="�����������" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtStarEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"
                                class="input_select"></asp:TextBox>
                            <%=GetLanguage("To")%><!--��-->
                            <asp:TextBox ID="txtEndEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"
                                class="input_select"></asp:TextBox>
                            <%} %>
                            <asp:Button ID="btnSearch" runat="server" Text="�� ��" class="btn" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="dataTable" align="center">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <td>
                        �û�����
                    </td>
                    <td>
                        <%=getColumn(0,"TrueName","tb_user","UserID="+getLoginID(),"") %>
                    </td>
                    <td>
                        �ʽ��ܶ
                    </td>
                    <td>
                        <%=getColumn(0,"BonusAccount","tb_user","UserID="+getLoginID(),"") %>
                    </td>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <th>
                        �Ƽ����û���
                    </th>
                    <th>
                        �Ƽ�����
                    </th>
                    <th>
                        �û����
                    </th>
                    <th>
                        ��Ա�ȼ�
                    </th>
                    <th>
                        <%=GetLanguage("LeadershipAward")%>
                        <!--�Ƽ���-->
                    </th>
                    <th>
                        <%=GetLanguage("ToTouch")%>
                        <!-- ������-->
                    </th>
                    <th>
                        <%=GetLanguage("BReturns")%>
                        <!-- B�̷���-->
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
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("xm")%><%--�û�����--%>
                                <span style="color: #ff0000;">
                                    <%#Convert.ToInt32(Eval("il"))==0?"":"(������)"%></span>
                            </td>
                            <td>
                                <%#Convert.ToInt32(Eval("at"))==0?"�Ƽ��û�":"����û�"%>
                                <%--ֱ���Ƽ�--%>
                            </td>
                            <td>
                                <%#Eval("yhm")%><%--�û����--%>
                            </td>
                            <td>
                                <%#Eval("li")%><%--�û����--%>
                            </td>
                            <td align="center">
                                <%#Eval("tj")%><%--�Ƽ� 1--%>
                            </td>
                            <td align="center">
                                <%#Eval("dp")%><%--���� 2--%>
                            </td>
                            <td align="center">
                                <%#Eval("fl")%><%--B�̷���--%>
                            </td>
                            <%if (getBonus(getLoginID(), 0) > getOutMoney(getLoginID()))
                              { %>
                            <td align="center">
                                <%=getOutMoney(getLoginID())%>
                            </td>
                            <%}
                              else
                              { %>
                            <td align="center">
                                <%#Eval("am")%><%--ʵ�� 7--%>
                            </td>
                            <%} %>
                            <td align="center">
                                <%#Eval("SttleTime")%><%--��������--%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#Eval("jj","RecommendBonusDetail.aspx?{0}") %>'><%=GetLanguage("ViewDetails")%><!--�鿴��ϸ--></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="15" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--��Ǹ��Ŀǰ���ݿ�����������ʾ��--></span></div>
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
    </div>
    </form>
</body>
</html>
