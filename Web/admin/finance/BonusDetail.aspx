<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusDetail.aspx.cs" Inherits="Web.admin.finance.BonusDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body class="subBody">
    <form id="Form1" class="box_con" runat="server">
        <div class="box box_width">
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">��ѯ</legend>��Ա���:<asp:TextBox ID="txtUserCode" tip="�����Ա���"
                        runat="server" class="input_select"></asp:TextBox>
                    ����:<asp:TextBox ID="txtTrueName" tip="��������" runat="server" class="input_select"></asp:TextBox>
                    <asp:LinkButton ID="lbtnSearch" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                        OnClick="lbtnSearch_Click"> �� �� </asp:LinkButton>
                    <asp:LinkButton ID="lbtnBack" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                        PostBackUrl="Bonus.aspx">�� �� </asp:LinkButton>
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>��Ա���
                        </th>
                        <th>��Ա����
                        </th>
                        <th>�������Ľ�    <%-- 1.�������Ľ�, 2.�Ƽ�����3.��̬�·ֺ콱��4.������)--%>
                        </th>
                        <th>�Ƽ���
                        </th>
                        <th>��̬�·ֺ콱
                        </th>
                        <th>������
                       
                        </th>
                        <th>ʵ��
                        </th>
                        <th>��������
                        </th>
                        <th>�鿴��ϸ
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("UserCode")%><%--��Ա���--%>
                                </td>
                                <td align="center">
                                    <%#Eval("TrueName")%><%--��Ա���--%>
                                </td>
                                <td align="center">
                                    <%#Eval("Entryprize")%><%--1.�������Ľ�--%><%-- 1.�������Ľ�, 2.�Ƽ�����3.��̬�·ֺ콱��4.������)--%>
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
                                    <%#Eval("sf")%><%--ʵ�� 6--%>
                                </td>
                                <td align="center">
                                    <%#Eval("SttleTime")%><%--��������--%>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnDetail" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                        class="easyui-linkbutton" iconcls="icon-search" CommandName="Open">�鿴��ϸ</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="trBonusNull" runat="server">
                        <td colspan="15" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    ��Ǹ��Ŀǰ���ݿ�����������ʾ��</span>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="nextpage cBlack">
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
