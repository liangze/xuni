<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SplitStock.aspx.cs" Inherits="Web.admin.Stock.SplitStock" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="box_con">
        <div class="operation">
            <asp:LinkButton ID="lbtnIssue" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                OnClick="lbtnIssue_Click"> MDD金币发行 </asp:LinkButton>
            <asp:LinkButton ID="lbtnSplit" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                OnClick="lbtnSplit_Click"> 拆分管理 </asp:LinkButton>
        </div>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">拆分</legend><legend class="legSearch"></legend>当前MDD金币价:<b><span
                    style="color: #aa0000; font-size: 14px;"><asp:Literal ID="ltSplitPriceB" runat="server"></asp:Literal></span></b>&nbsp;&nbsp;&nbsp;&nbsp;MDD金币拆分价:<b><span
                        style="color: #aa0000; font-size: 14px;"><asp:Literal ID="ltSplitPriceL" runat="server"></asp:Literal></span></b>&nbsp;&nbsp;&nbsp;&nbsp;拆分后MDD金币价格:<b><span
                            style="color: #aa0000; font-size: 14px;"><asp:Literal ID="ltSplitPrice" runat="server"></asp:Literal></span></b>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="ltSplitRateOne" runat="server"></asp:Literal><b><span
                                style="color: #aa0000; font-size: 14px;"><asp:Literal ID="ltSplitRate" runat="server"></asp:Literal></span></b>&nbsp;&nbsp;&nbsp;&nbsp;本次是第<b><span
                                    style="color: #aa0000; font-size: 14px;"><asp:Literal ID="ltSplitTimes" runat="server"></asp:Literal></span></b>次拆分&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                        ID="lbtnSubmit" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                                        OnClick="lbtnSubmit_Click"> 提 交 </asp:LinkButton>&nbsp;&nbsp;<b><span
                                            style="color: #aa0000;"><asp:Literal ID="ltltSplit" Visible="false" runat="server"></asp:Literal></span></b>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>拆分前MDD金币价
                    </th>
                    <th>拆分后MDD金币价
                    </th>
                    <th>拆分比例
                    </th>
                    <th>拆分次数
                    </th>
                    <th>拆分时间
                    </th>
                    <th>操作
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("SplitPriceB")%>
                            </td>
                            <td align="center">
                                <%#Eval("SplitPriceL")%>
                            </td>
                            <td align="center">
                                <%#Eval("SplitRate")%>
                            </td>
                            <td align="center">
                                <%#Eval("SplitTimes")%>
                            </td>
                            <td align="center">
                                <%#Eval("SplitDate")%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lbtnDetail" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                                    PostBackUrl='<%#Eval("SplitID","SplitStockDetail.aspx?SplitID={0}") %>'>拆分明细</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="6" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" />
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
    </form>
</body>
</html>
