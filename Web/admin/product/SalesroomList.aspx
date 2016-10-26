<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesroomList.aspx.cs" Inherits="web.admin.product.SalesroomList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>��Ʒ�б�</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../../SpryAssets/imgbox/jquery.min.js" type="text/javascript"></script>
    <script src="../../SpryAssets/imgbox/jquery.imgbox.pack.js" type="text/javascript"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <style type="text/css">
        
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

        });
    </script>
</head>
<body class="subBody">
    <form id="Form1" class="box_con" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="box box_width" id="div1">
            <div class="operation">
                <%--
            <fieldset class="fieldset">
                ѡ�����ͣ�<asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlType_SelectedIndexChanged">
                <asp:ListItem Value="0">���¼���Ʒ</asp:ListItem>
                <asp:ListItem Value="1">���ϼ���Ʒ</asp:ListItem>
                </asp:DropDownList>
            </fieldset>--%>
                <fieldset class="fieldset">
                    <legend class="legSearch">��ѯ</legend>��Ʒ��ţ�<input type="text" id="txtCode" tip="������Ʒ���"
                        name="textfield" runat="server" class="input_select" />
                    ��Ʒ���ƣ�<input type="text" id="txtName" name="textfield" runat="server" class="input_select" />
                    <asp:LinkButton ID="btn_s1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                        OnClick="btnChuSearch_Click"> �� �� </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-add"
                        OnClick="Button1_Click"> ������Ʒ </asp:LinkButton>
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>��Ʒ���
                        </th>
                        <th>��Ʒ����
                        </th>
                        <th>һ������
                        </th>
                        <th>��������
                        </th>
                        <th>��������
                        </th>
                        <th>�г���
                        </th>
                        <th>���ļ�
                        </th>
                        <th>���
                        </th>
                        <%-- <th>
                        �ص�
                    </th>--%>
                        <th>���Ĵ���
                        </th>
                        <th>���Ĵ���
                        </th>
                        <th class="style1">״̬
                        </th>
                        <th>����
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("GoodsCode")%>
                                </td>
                                <td align="center">
                                    <span title=' <%#Eval("GoodsName")%>'><%#Eval("GoodsName")%></span>
                                </td>
                                <td align="center">
                                    <span title=' <%#Eval("OneName")%>'><%#Eval("OneName")%></span>
                                </td>
                                <td align="center">
                                    <span title=' <%#Eval("TwoName")%>'><%#Eval("TwoName")%></span>
                                </td>
                                <td align="center">
                                    <span title=' <%#Eval("ThreeName")%>'><%#Eval("ThreeName")%></span>
                                </td>
                                <td align="center">
                                    <%#Eval("Price")%>
                                </td>
                                <td align="center">
                                    <%#Eval("RealityPrice")%>
                                </td>
                                <td align="center">
                                    <%# int.Parse(Eval("Goods006").ToString()) - int.Parse( Eval("SealCount").ToString()) %>
                                </td>
                                <%--  <td align="center">
                                <%#Eval("City")%>
                            </td>--%>
                                <td align="center">
                                    <%#Eval("Purchase")%>
                                </td>
                                <td align="center">
                                    <%#Eval("SealPurchase")%>
                                </td>
                                <td align="center">
                                    <%# Eval("StateType").ToString() == "1" ? "���ͨ��" : "�����"%>
                                </td>
                                <td align="center" width="30%">
                                    <asp:LinkButton ID="lbtnAudit" runat="server" CommandName="Audit" class="easyui-linkbutton"
                                        iconcls="icon-edit" CommandArgument='<%# Eval("ID") %>'> <%# Eval("StateType").ToString() == "0" ? "���ͨ��" : "��˲�ͨ��"%></asp:LinkButton>&nbsp;&nbsp;
                                <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="edit" class="easyui-linkbutton"
                                    iconcls="icon-edit" CommandArgument='<%# Eval("ID") %>'>�� ��</asp:LinkButton>&nbsp;&nbsp;
                                <asp:LinkButton ID="lbtnUp" runat="server" CommandName="up" Visible='<%#Eval("Goods001").ToString()=="0"?true:false %>'
                                    class="easyui-linkbutton" iconcls="icon-add" CommandArgument='<%# Eval("ID") %>'>�� ��</asp:LinkButton>
                                    <asp:LinkButton ID="lbtnDown" runat="server" CommandName="down" Visible='<%#Eval("Goods001").ToString()=="1"?true:false %>'
                                        class="easyui-linkbutton" iconcls="icon-remove" CommandArgument='<%# Eval("ID") %>'>�� ��</asp:LinkButton>
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" class="easyui-linkbutton" iconcls="icon-no" OnClientClick="return confirm('ȷ��Ҫɾ����')" CommandArgument='<%# Eval("ID") %>'>ɾ ��</asp:LinkButton>&nbsp;&nbsp;
                                <asp:LinkButton ID="lbtnLucky" runat="server" CommandName="lucky" class="easyui-linkbutton" iconcls="icon-ok" OnClientClick="return confirm('ȷ��Ҫ�齱��')" CommandArgument='<%# Eval("ID") %>'>�� ��</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr align="center" runat="server" id="tr1">
                        <td colspan="12" style="border: 0">
                            <div>
                                ��Ǹ��Ŀǰ���ݿ������޼�¼��ʾ��
                            </div>
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
