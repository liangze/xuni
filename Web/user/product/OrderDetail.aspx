<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="web.user.product.OrderDetail" %>

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
                <asp:Button ID="btnSearch" runat="server" Text="返 回"  class="btn" OnClick="btnSearch_Click" />
            </fieldset>
        </div>
        <!--end operation 操作-->
        <div class="dataTable">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        商品编号
                    </th>
                    <th align="center">
                        商品名称
                    </th>
                    <th align="center">
                        成交价
                    </th>
                    <th align="center">
                        购买数量
                    </th>
                    <th align="center">
                        总金额
                    </th>
                    <th align="center">
                        购买日期
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr align="center">
        <td><%#Eval("ProcudeCode")%></td>
        <td><%#Eval("ProcudeName")%></td>
        <td><%#Eval("Price")%></td>
        <td ><%#Eval("OrderSum")%></td>
        <td ><%#Eval("OrderTotal")%></td>
        <td><%#Eval("OrderDate")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
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
