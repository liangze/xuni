<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addcishan.aspx.cs" Inherits="Web.admin.finance.Addcishan" %>

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
                    &nbsp;&nbsp;�����ܶ<asp:Label ID="Label_cishan" runat="server" Text="Label"></asp:Label>
                     &nbsp;&nbsp;������<asp:Label ID="Label_cishan2" runat="server" Text="Label"></asp:Label>
                    &nbsp;&nbsp;��ֵ���ͣ�<asp:DropDownList ID="dropRechargeStyle" runat="server">
                        <asp:ListItem Value="0" Text="�۳�" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="����"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp; ��<asp:TextBox ID="txtMoney" class="easyui-numberbox input_select" runat="server" min="0" precision="2" tip="�����ֵ���"></asp:TextBox>Ԫ
    <asp:LinkButton ID="lbtnSubmit" runat="server" class="easyui-linkbutton"
        iconcls="icon-ok" OnClientClick="javascript:return confirm('ȷ�ϸ��û�Ա��ֵ��')" OnClick="lbtnSubmit_Click"> �� �� </asp:LinkButton>
                    &nbsp;&nbsp;
                </fieldset>
                <fieldset class="fieldset">
                    <legend class="legSearch">��Ա����ѯ</legend>
                    ��Ա��ţ�
                    <asp:TextBox ID="txtCode" runat="server" tip="�����Ա���" class="input_select"></asp:TextBox>
                    &nbsp;&nbsp;������ڣ�<asp:TextBox ID="txtStart" tip="����������" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>&nbsp;��&nbsp;<asp:TextBox ID="txtEnd" tip="�����ֵ����" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                    <asp:LinkButton ID="lbtnSearch" runat="server" class="easyui-linkbutton"
                        iconcls="icon-search" OnClick="btnSearch_Click"> �� �� </asp:LinkButton>
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">��Ա���</th>
                        <th align="center">�����</th>
                        <th align="center">�������</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center"><%#Eval("UserCode")%></td>
                                <td align="center"><%#Eval("Amount")%></td>
                                <td align="center"><%#Eval("ChangeDate")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="trBonusNull" runat="server">
                        <td colspan="4" align="center">
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

