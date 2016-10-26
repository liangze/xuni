<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferSearch.aspx.cs"
    Inherits="Web.admin.finance.TransferSearch" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>账户转账查询</title>
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
                    <legend class="legSearch">转出查询</legend>会员编号:<input id="textChuUserCode" type="text"
                        runat="server" class="input_select" tip="输入转出会员编号" />
                    <%--转入会员编号:<input id="textRuUserCode" type="text" runat="server"  class="input_select" tip="输入转入会员编号" />--%>
                转账日期：<asp:TextBox ID="txtChuStar" tip="输入转账日期" runat="server" onfocus="WdatePicker()"
                    class="input_select"></asp:TextBox>
                    至<asp:TextBox ID="txtChuEnd" tip="输入转账日期" runat="server" onfocus="WdatePicker()"
                        class="input_select"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                        OnClick="btnChuSearch_Click"> 搜 索 </asp:LinkButton>
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>转出编号
                        </th>
                        <th>转入编号
                        </th>
                        <th>转账类型
                        </th>
                        <th>转账金额
                        </th>
                        <th>转账日期
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("tocode")%>
                                </td>
                                <td align="center">
                                    <%#ChangeType(Convert.ToInt32(Eval("ChangeType").ToString()))%>
                                </td>
                                <td align="center">
                                    <%#Eval("Amount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("ChangeDate")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="5" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库暂无数据显示。</span>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="nextpage cBlack">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                        NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                        SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
