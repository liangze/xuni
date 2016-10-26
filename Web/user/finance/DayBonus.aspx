<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DayBonus.aspx.cs" Inherits="Web.user.finance.DayBonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>ÿ�ս���</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body class="">
    <form id="Form1" runat="server">
    <div class="box box_width">
        <div class="capositon">
            ��ǰλ�ã���������>><a href="javascript:void(0)">ÿ�ս���</a>
        </div>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">��ѯ</legend>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr>
                        <td>
                            �������ڣ�<asp:TextBox ID="txtStar" tip="�����������" runat="server" onfocus="WdatePicker()"
                                class="input_select"></asp:TextBox>
                            ��<asp:TextBox ID="txtEnd" tip="�����������" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="�� ��" class="btn" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="dataTable" align="center">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th colspan="10">
                        ÿ�ս�����ϸ
                    </th>
                </tr>
                <tr>
                    <th>
                        �������ͱ��
                    </th>
                    <th>
                        ������
                    </th>
                    <th>
                        ʵ��������
                    </th>
                    <th>
                        ��������ʱ��
                    </th>
                    <th>
                        �Ƿ����(0-δ��1-��)
                    </th>
                    <th>
                        ����ע
                    </th>
                    <th>
                        ����ʱ��
                    </th>
                    <th>
                        ������Դ�û�ID
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("TypeID")%><%--�������ͱ�� 1--%>
                            </td>
                            <td align="center">
                                <%#Eval("Amount")%><%--������ 2--%>
                            </td>
                            <td align="center">
                                <%#Eval("sf")%><%--ʵ�������� 3--%>
                            </td>
                            <td align="center">
                                <%#Eval("AddTime")%><%--��������ʱ�� 4--%>
                            </td>
                            <td align="center">
                                <%#Eval("IsSettled")%><%--�Ƿ����(0-δ���㣬1-�ѽ���) 5--%>
                            </td>
                            <td align="center">
                                <%#Eval("Source")%><%--����ע 6--%>
                            </td>
                            <td align="center">
                                <%#Eval("SttleTime")%><%--����ʱ�� 3--%>
                            </td>
                            <td align="center">
                                <%#Eval("FromUserID")%><%--������Դ�û�id 4--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="15" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                ��Ǹ��Ŀǰ���ݿ�����������ʾ��</span></div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="��ҳ"
                    LastPageText="βҳ" NextPageText="��һҳ" PrevPageText="��һҳ" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" ҳ" textbeforepageindexbox="ת�� " OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
