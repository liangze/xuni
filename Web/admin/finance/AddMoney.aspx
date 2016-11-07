<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMoney.aspx.cs" Inherits="Web.admin.finance.AddMoney" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>�˻�ת�˲�ѯ</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body class="subBody">
    <form id="Form1" class="box_con" runat="server">
        <div class="box box_width">
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">����</legend>
                    ��Ա��ţ�<asp:TextBox ID="txtUserCode" class="input_select" runat="server" tip="�����Ա���"></asp:TextBox>
                    &nbsp;&nbsp;������ͣ�<asp:DropDownList ID="dropMoneyType" runat="server">
                        <%--  Emoney = 0;// ע�����         д��ˮ���ͣ�1
                              BonusAccount = 0;// ������� 	 2
                              AllBonusAccount = 0;// ���ӻ���	 3
                              StockAccount = 0;// ���̻���	 4
                              StockMoney = 0;// �ж�����	 5
                              GLmoney = 0;// �������	 6
                              ShopAccount = 0;// ���ѻ���	 7
                              User011// ���Ļ���	 8
                              User012// �ƹ�����	 9--%>
                        <asp:ListItem Value="0" Text="��ѡ��"></asp:ListItem>
                        <asp:ListItem Value="1" Text="ע�����"></asp:ListItem>
                        <asp:ListItem Value="2" Text="�������"></asp:ListItem>
                        <asp:ListItem Value="3" Text="���ӻ���"></asp:ListItem>
                        <asp:ListItem Value="4" Text="���̻���"></asp:ListItem>
                        <asp:ListItem Value="5" Text="�ж�����"></asp:ListItem>
                        <asp:ListItem Value="6" Text="�������"></asp:ListItem>
                        <asp:ListItem Value="7" Text="���ѻ���"></asp:ListItem>
                        <asp:ListItem Value="8" Text="���Ļ���"></asp:ListItem>
                        <asp:ListItem Value="9" Text="�ƹ�����"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;��ֵ���ͣ�<asp:DropDownList ID="dropRechargeStyle" runat="server">
                        <asp:ListItem Value="0" Text="��ѡ��"></asp:ListItem>
                        <asp:ListItem Value="1" Text="����"></asp:ListItem>
                        <asp:ListItem Value="2" Text="�۳�"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp; ��ֵ��<asp:TextBox ID="txtMoney" class="easyui-numberbox input_select" runat="server" min="0" precision="2" tip="�����ֵ���"></asp:TextBox>Ԫ
    <asp:LinkButton ID="lbtnSubmit" runat="server" class="easyui-linkbutton"
        iconcls="icon-ok" OnClientClick="javascript:return confirm('ȷ�ϸ��û�Ա��ֵ��')" OnClick="lbtnSubmit_Click"> �� �� </asp:LinkButton>
                    &nbsp;&nbsp;
                </fieldset>
                <fieldset class="fieldset">
                    <legend class="legSearch">��Ա��ѯ</legend>
                    ��Ա��ţ�
                    <asp:TextBox ID="txtCode" runat="server" tip="�����Ա���" class="input_select"></asp:TextBox>
                    &nbsp;&nbsp;��ֵ����:<asp:DropDownList ID="dropType" runat="server">
                        <asp:ListItem Value="0" Text="��ѡ��"></asp:ListItem>
                        <asp:ListItem Value="1" Text="����"></asp:ListItem>
                        <asp:ListItem Value="2" Text="�۳�"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;��ֵ���ڣ�<asp:TextBox ID="txtStart" tip="�����ֵ����" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>&nbsp;��&nbsp;<asp:TextBox ID="txtEnd" tip="�����ֵ����" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                    <asp:LinkButton ID="lbtnSearch" runat="server" class="easyui-linkbutton"
                        iconcls="icon-search" OnClick="btnSearch_Click"> �� �� </asp:LinkButton>
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">��Ա���</th>
                        <th align="center">��ֵ���</th>
                        <th align="center">��ֵ����</th>
                        <th align="center">�������</th>
                        <th align="center">��ֵ��ʽ</th>
                        <th align="center">��ֵ���</th>
                        <th align="center">��ֵ����</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("RechargeableMoney")%>
                                </td>
                                <td align="center">
                                    <%#Eval("RechargeStyle").ToString() == "1" ? "����" : "����"%>
                                </td>
                                <td align="center">
                                    <%#RechargeType(Convert.ToInt32(Eval("RechargeType")))%>
                                </td>
                                <td align="center">
                                    <%#Eval("Recharge001").ToString() == "1" ? "��̨" :"֧����"%>
                                </td>
                                <td align="center">
                                    <%#Eval("Flag").ToString() == "1" ? "<font style='color:green'>�ɹ�</font>" :"<font style='color:red'>ʧ��</font>"%>
                                </td>
                                <td align="center">
                                    <%#Eval("RechargeDate")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="7" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
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

