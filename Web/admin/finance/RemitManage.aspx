<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemitManage.aspx.cs" Inherits="Web.admin.finance.RemitManage" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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

    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body class="subBody">
    <form id="Form1" class="box_con" runat="server">
        <div class="box box_width">
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">����ѯ</legend>
                    ��Ա��ţ�<asp:TextBox ID="txtUserCode" runat="server" tip="�����Ա���" class="input_select"></asp:TextBox>
                    ��Ա������<asp:TextBox ID="txtTrueName" runat="server" tip="�����Ա����" class="input_select"></asp:TextBox>
                    ���״̬��<asp:DropDownList ID="dropState" runat="server">
                        <asp:ListItem Value="0" Text="��ѡ��">��ѡ��</asp:ListItem>
                        <asp:ListItem Value="1" Text="δ���">δ���</asp:ListItem>
                        <asp:ListItem Value="2" Text="�����">�����</asp:ListItem>
                    </asp:DropDownList>
                    �������ڣ�<asp:TextBox ID="txtStar" tip="������������" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                    ��<asp:TextBox ID="txtEnd" tip="������������" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>

                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"
                        iconcls="icon-search" OnClick="btnSearch_Click"> �� �� </asp:LinkButton>
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>��Ա���</th>
                        <th>��Ա����</th>
                        <th>�����</th>
                        <th>��ֵ����</th>
                        <th>������ʱ��</th>
                        <th>�������</th>
                        <th>����˻�</th>
                        <th>��ע</th>
                        <th>��������</th>
                        <th>�����˻�</th>
                        <th>���뿪����</th>
                        <th>��������</th>
                        <th>���״̬</th>
                        <th>����</th>
                    </tr>
                    <asp:Repeater ID="rpRemit" runat="server" OnItemCommand="rpRemit_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td align="center"><%#Eval("UserCode")%></td>
                                <td align="center"><%#Eval("Truename")%></td>
                                <td align="center"><%#Eval("RemitMoney")%></td>
                                <td align="center"><%#RechargeType(Convert.ToInt32(Eval("Remit001")))%></td>
                                <td align="center"><%#Eval("RechargeableDate")%></td>
                                <td align="center"><%#Eval("Remit003")%></td>
                                <td align="center"><%#Eval("Remit004")%></td>
                                <td align="center"><%#Eval("Remark")%></td>
                                <td align="center"><%#Eval("BankName")%></td>
                                <td align="center"><%#Eval("BankAccount")%></td>
                                <td align="center"><%#Eval("BankAccountUser")%></td>
                                <td align="center"><%#Eval("AddDate")%></td>
                                <td align="center"><%#Eval("State").ToString() == "0" ? "δ��" : "����"%></td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnVerify" runat="server" CommandArgument='<%# Eval("ID") %>' class="easyui-linkbutton"
                                        iconcls="icon-ok" CommandName="verify" OnClientClick="javascript:return confirm('ȷ����ˣ�')" Visible='<%#Convert.ToInt32(Eval("State"))==0?true:false%>'>ȷ��</asp:LinkButton>
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%# Eval("ID") %>' class="easyui-linkbutton"
                                        iconcls="icon-no" CommandName="Remove" OnClientClick="javascript:return confirm('ȷ��Ҫɾ����')" Visible='<%#Convert.ToInt32(Eval("State"))==0?true:false%>'>ɾ��</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="11">
                            <div id="divno" runat="server" class="NoData">
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
