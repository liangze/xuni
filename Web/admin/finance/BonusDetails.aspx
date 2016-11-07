<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusDetails.aspx.cs" Inherits="Web.admin.finance.BonusDetails" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>�鿴������ϸ</title>
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
                    <legend class="legSearch">��ѯ</legend>��������:<asp:DropDownList ID="ddlBonus" runat="server">
                    </asp:DropDownList>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                        OnClick="btnSearch_Click"> �� �� </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                        OnClick="Button1_Click">�� �� </asp:LinkButton>
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">��������
                        </th>
                        <th align="center">������
                        </th>
                        <%--<th align="center">��ͨ���
                        </th>
                        <th align="center">MDD���
                        </th>--%>
                        <th align="center">ƽ̨����
                        </th>
                        <%--<th align="center">�����
                        </th>--%>
                        <th align="center">��������
                        </th>
                        <th align="center">����״̬
                        </th>
                        <%--<th align="center">����
                        </th>--%>
                        <th align="center">����
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("typename")%>
                                </td>
                                <td align="center">
                                    <%#Eval("amount")%>
                                    <%--���--%>
                                </td>
                             
                               
                                <td align="center">
                                    <%#Eval("Bonus005")%>
                                    <%--ƽ̨����--%>
                                </td>
                                
                                <td align="center">
                                    <%#Eval("SttleTime")%>
                                </td>
                                <td align="center">
                                    <%#Convert.ToInt32(Eval("IsSettled")) == 1 ? "�ѷ���" : "δ����"%>
                                </td>
                               <%-- <td align="center">
                                    <%#Eval("Batch")%>
                                </td>--%>
                                <td align="center">
                                    <%#Eval("source")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="8" align="center">
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
