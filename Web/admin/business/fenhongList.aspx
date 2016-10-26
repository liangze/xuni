<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fenhongList.aspx.cs" Inherits="Web.admin.business.fenhongList" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>�����ѯ</title>
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
                <legend class="legSearch">�ֺ�����</legend>�����<asp:TextBox ID="txtmoney" tip="����������"
                    runat="server" class="input_select"></asp:TextBox>
                �ֺ����(%)��<asp:TextBox ID="txtrate" tip="����ֺ����" runat="server"  class="input_select"></asp:TextBox>
                <asp:LinkButton ID="btnjiesuan" runat="server" class="easyui-linkbutton" 
                    iconcls="icon-search" onclick="btnjiesuan_Click"> ���� </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        ������
                    </th>
                    <th>
                        �ֺ����
                    </th>
                    <th>
                        �ֺ�����
                    </th>
                    <th>
                        �鿴��¼
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("BonusMoney")%><%--�Ƽ� 1--%>
                            </td>
                            <td align="center">
                                <%#Eval("FhRate")%><%--���ֺ� 4--%>
                            </td>
                            <td align="center">
                                <%#Eval("FhTime")%><%--��������--%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#Eval("FhTime","fenhongDetail.aspx?FhTime={0}") %>'>�鿴��ϸ</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="15" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt=""/>
                                ��Ǹ��Ŀǰ���ݿ�����������ʾ��</span></div>
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
