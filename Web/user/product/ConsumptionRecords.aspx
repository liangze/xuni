<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumptionRecords.aspx.cs" Inherits="web.user.product.ConsumptionRecords" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>激活</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Tooltip.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../../js/jquery1.2.js"></script>

    <script type="text/javascript" src="../../js/superValidator.js"></script>

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>

</head>
<body>
    <form id="form1" runat="server" class="box_con">
    <div class="box box_width">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">搜索</legend>
                订单号:<input name="textfield" type="text" id="textOrderID" tip="输入订单号" class="input_select" runat="server"/>
                购买日期：
      <input name="textfield4" type="text" id="textStart"  class="input_select" tip="输入购买日期" runat="server" onClick="WdatePicker()"/>
至
<input name="textfield4" type="text" id="textEnd"  class="input_select" runat="server" tip="输入购买日期" onClick="WdatePicker()"/>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
            </fieldset>
        </div>
        <!--end operation 操作-->
        <div class="dataTable">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        订单号
                    </th>
                    <th align="center">
                        购买数量
                    </th>
                    <th align="center">
                        总金额
                    </th>
                    <th align="center">
                        状态
                    </th>
                    <th align="center">
                        购买日期
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
        <tr align="center">
        <td><%#Eval("OrderCode")%></td>
        <td><%#Eval("OrderSum")%></td>
        <td><%#Eval("OrderTotal")%></td>
        <td ><%#GetState(Eval("IsSend").ToString())%></td>
        <td><%#Eval("OrderDate")%></td>
        <td >
        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                CommandName="show">查看</asp:LinkButton>
        </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr runat="server" id="trNull">
                    <td colspan="6" align="center">
                        <div id="divno" runat="server" class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                抱歉！目前数据库暂无数据显示。</span></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        <div class="nextpage cBlack">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                        LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                        PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                                        PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                                        UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
                                        textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                                    </webdiyer:AspNetPager>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <!--end data 表格数据-->
    </div>
    </form>
</body>
</html>
