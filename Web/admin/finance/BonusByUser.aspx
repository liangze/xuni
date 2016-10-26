<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusByUser.aspx.cs" Inherits="Web.admin.finance.BonusByUser" %>

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
</head>
<body class="subBody">
    <form class="box_con" runat="server">
    <div class="box box_width">
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        ֱ�����̽����ۼ�
                    </th>
                    <th>
                        ��������ۼ�
                    </th>
                    <th>
                        ��������ۼ�
                    </th>
                    <th>
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
            <fieldset class="fieldset">
                <legend class="legSearch">��ѯ</legend>�������ڣ�<asp:TextBox ID="txtStar" tip="�����������"
                    runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                ��<asp:TextBox ID="txtEnd" tip="�����������" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="btnSearch_Click"> �� �� </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>

                <th>
                        �û�
                    </th>


                    <th>
                        ֱ�����̽���
                    </th>
                    <th>
                        �������
                    </th>
                    <th>
                        �������
                    </th>
                    <th>
                        ���˽���
                    </th>
                    <%--
                    <th>
                        ѧϰ����
                    </th>--%>
                    <%-- <th>
                        ��г����
                    </th>--%>
                    <th>
                        Ӧ��
                    </th>
                    <th>
                        �ۺϷ����
                    </th>
                    <%--
                    <th>
                        ������
                    </th>--%>
                    <th>
                        ��������
                    </th>
                    <th>
                        �г�Ȩ��
                    </th>
                    <th>
                        ʵ��
                    </th>
                    <th>
                        ��������
                    </th>
                    <th>
                        ����
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" runat="server">
                    <ItemTemplate>
                        <tr>

                        <td align="center">
                           <%#Eval("yhm")%>    
                                <%--�û�--%>
                            </td>


                            <td align="center">
                                <%#Eval("tj")%>
                                <%--ֱ�����̽��� Amount 2--%>
                            </td>
                            <td align="center">
                                <%#Eval("dp")%><%--������� Amount 1--%>
                            </td>
                            <td align="center">
                                <%#Eval("gl")%><%--�������  Amount 4--%>
                            </td>
                            <td align="center">
                                <%#Eval("jd")%><%--���˽��� Amount 3--%>
                            </td>
                            <%--
                            <td align="center">
                                <%#Eval("xx")%>
                            </td>--%>
                            <%-- <td align="center">
                                <%#Eval("hx")%>
                            </td>--%>
                            <td align="center">
                                <%#Eval("yf")%><%--Ӧ�� Amount--%>
                            </td>
                            <td align="center">
                                <%#Eval("fwf")%><%--�ۺϷ���� Revenue--%>
                            </td>
                            <%--
                            <td align="center">
                                <%#Eval("fbf")%>
                            </td>--%>
                            <td align="center">
                                <%#Eval("cfxf")%><%--�������� Bonus006--%>
                            </td>
                            <td align="center">
                                <%#Eval("bd")%><%--�г�Ȩ�� bd --%>
                            </td>
                            <td align="center">
                                <%#Eval("sf")%><%--ʵ��sf --%>
                            </td>
                            <td align="center">
                                <%#Eval("SttleTime")%><%--��������--%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                                    PostBackUrl='<%#Eval("SttleTime","BonusDetail.aspx?SttleTime={0}") %>'>�鿴��ϸ</asp:LinkButton>
                                    |&nbsp;

                                    <a class="easyui-linkbutton"  href='BonusByUserDel.aspx?uid=<%#Eval("uid") %>&SttleTime= <%#Eval("SttleTime")%>'>ɾ��</a>
                                   
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="12" align="center">
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
