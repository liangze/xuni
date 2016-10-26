<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusByUserDel.aspx.cs"
    Inherits="Web.admin.finance.BonusByUserDel" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
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

    <style type="text/css">
     .th
     {
         text-align:left;
         padding-left:10px;
         }
    </style>
</head>
<body class="subBody">
    <form id="Form1" class="box_con" runat="server">
    <div class="box box_width">
        <div class="dataTable">

         <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-search" style="padding-left:20px;"
                    PostBackUrl="Bonus.aspx">�� �� </asp:LinkButton>


            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1" style="display: none">
                <tr>
                    <th class="th">
                        ֱ�����̽����ۼ�
                    </th>
                    <th class="th">
                        ��������ۼ�
                    </th>
                    <th class="th">
                        ��������ۼ�
                    </th>
                    <th class="th">
                        ���˽����ۼ�
                    </th>
                    <%--
                    <th>
                        ѧϰ�����ۼ�
                    </th>--%>
                    <%-- <th>
                        ��г�����ۼ�
                    </th>--%>
                    <th>
                        Ӧ���ۼ�
                    </th>
                    <th>
                        �ۺϷ�����ۼ�
                    </th>
                    <%--
                    <th>
                        �������ۼ�
                    </th>--%>
                    <th>
                        ���������ۼ�
                    </th>
                    <th>
                        �г�Ȩ���ۼ�
                    </th>
                    <th>
                        ʵ���ۼ�
                    </th>
                </tr>
                <tr>
                    <td align="center">
                        <%=getBonus(0,2) %><%--ֱ�����̽����ۼ� 2--%>
                    </td>
                    <td align="center">
                        <%=getBonus(0,1) %>
                        <%--��������ۼ� 1--%>
                    </td>
                    <td align="center">
                        <%--��������ۼ� 4--%>
                        <%=getBonus(0,4) %>
                    </td>
                    <td align="center">
                        <%=getBonus(0,3) %>
                        <%--���˽����ۼ� 3--%>
                    </td>
                    <%--
                    <td align="center">
                        <%=getBonus(0,5) %>
                    </td>--%>
                    <%--   <td align="center">
                        <%=getBonus(0,6) %>
                    </td>--%>
                    <td align="center">
                        <%=getBonusYF(0,1) %><%--Ӧ���ۼ� Amount--%>
                    </td>
                    <td align="center">
                        <%=getBonusFWF(0) %><%--�ۺϷ�����ۼ� Revenue--%>
                    </td>
                    <%--
                    <td align="center">
                        <%=getBonusFBF(0) %>
                    </td>--%>
                    <td align="center">
                        <%=getBonusCFXF(0) %><%--���������ۼ� Bonus006--%>
                    </td>
                    <td align="center">
                        <%=getBonus(0,7) %><%--�г�Ȩ���ۼ� 7--%>
                    </td>
                    <td align="center">
                        <%=getBonusSF(0) %><%--ʵ���ۼ� sf--%>
                    </td>
                </tr>
            </table>
        </div>
    <div class="operation">
        <fieldset class="fieldset" style="display: none">
            <legend class="legSearch">��ѯ</legend>�������ڣ�<asp:TextBox ID="txtStar" tip="�����������"
                runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
            ��<asp:TextBox ID="txtEnd" tip="�����������" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
            <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                OnClick="btnSearch_Click"> �� �� </asp:LinkButton>
        </fieldset>
    </div>
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <asp:Repeater ID="Repeater1" runat="server" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <th colspan="3">
                            <div style=" float:left;">�û���<%#Eval("yhm")%></div> <div style=" float:right;">���ڣ�<%#Eval("SttleTime")%></div>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            ֱ�����̽���
                        </td>
                        <td align="center">
                            <%#Eval("tj")%>
                            <%--ֱ�����̽��� Amount 2--%>
                        </td>
                        <td>
                         <%#double.Parse(Eval("tj").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="linkBtnDel" runat="server" Visible=' <%#double.Parse(Eval("tj").ToString()) > 0 ? true : false%>' CommandArgument="2" CommandName="delete" OnClientClick="return confirm('��ȷ��ɾ���ý�����');">ɾ��</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            �������
                        </td>
                        <td align="center">
                            <%#Eval("dp")%><%--������� Amount 1--%>
                        </td>
                        <td>
                            <%#double.Parse(Eval("dp").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton1" Visible='<%#double.Parse(Eval("dp").ToString()) > 0 ? true : false%>' runat="server" CommandArgument="1" CommandName="delete" OnClientClick="return confirm('��ȷ��ɾ���ý�����');">ɾ��</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            �������
                        </td>
                        <td align="center">
                            <%#Eval("gl")%><%--�������  Amount 4--%>
                        </td>
                        <td>
                        <%#double.Parse(Eval("gl").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton3" runat="server" Visible='<%#double.Parse(Eval("gl").ToString()) > 0 ? true : false%>' CommandArgument="4" CommandName="delete" OnClientClick="return confirm('��ȷ��ɾ���ý�����');">ɾ��</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ���˽���
                        </td>
                        <td align="center">
                            <%#Eval("jd")%><%--���˽��� Amount 3--%>
                        </td>
                        <td>
                        <%#double.Parse(Eval("jd").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton4" Visible='<%#double.Parse(Eval("jd").ToString()) > 0 ? true : false%>' runat="server" CommandArgument="3" CommandName="delete" OnClientClick="return confirm('��ȷ��ɾ���ý�����');">ɾ��</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            �ۺϷ����
                        </td>
                        <td align="center">
                            <%#Eval("fwf")%><%--�ۺϷ���� Revenue--%>
                        </td>
                        <td>
                        <%#double.Parse(Eval("fwf").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton6" runat="server" Visible='<%#double.Parse(Eval("fwf").ToString()) > 0 ? true : false%>' CommandArgument="Revenue" CommandName="delete" OnClientClick="return confirm('��ȷ��ɾ���ý�����');">ɾ��</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ��������
                        </td>
                        <td align="center">
                            <%#Eval("cfxf")%><%--�������� Bonus006--%>
                        </td>
                        <td>
                             <%#double.Parse(Eval("cfxf").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton7" runat="server" Visible=' <%#double.Parse(Eval("cfxf").ToString()) > 0 ? true:false%>' CommandArgument="Bonus006" CommandName="delete" OnClientClick="return confirm('��ȷ��ɾ���ý�����');">ɾ��</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            �г�Ȩ��
                        </td>
                        <td align="center">
                            <%#Eval("bd")%><%--�г�Ȩ�� 7 --%>
                        </td>
                        <td>
                        <%#double.Parse(Eval("bd").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton8" runat="server" Visible='<%#double.Parse(Eval("bd").ToString())>0?true:false %>' CommandArgument="7" CommandName="delete" OnClientClick="return confirm('��ȷ��ɾ���ý�����');">ɾ��</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr id="trBonusNull" runat="server">
                <td colspan="3" align="center">
                    <div class="NoData">
                        <span class="cBlack">
                            <img src="../../images/ico_NoDate.gif" width="16" height="16" />
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
