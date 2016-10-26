<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fenhongList.aspx.cs" Inherits="Web.admin.business.fenhongList" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>奖金查询</title>
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
                <legend class="legSearch">分红利润</legend>利润金额：<asp:TextBox ID="txtmoney" tip="输入利润金额"
                    runat="server" class="input_select"></asp:TextBox>
                分红比例(%)：<asp:TextBox ID="txtrate" tip="输入分红比例" runat="server"  class="input_select"></asp:TextBox>
                <asp:LinkButton ID="btnjiesuan" runat="server" class="easyui-linkbutton" 
                    iconcls="icon-search" onclick="btnjiesuan_Click"> 结算 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        利润金额
                    </th>
                    <th>
                        分红比例
                    </th>
                    <th>
                        分红日期
                    </th>
                    <th>
                        查看纪录
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("BonusMoney")%><%--推荐 1--%>
                            </td>
                            <td align="center">
                                <%#Eval("FhRate")%><%--广告分红 4--%>
                            </td>
                            <td align="center">
                                <%#Eval("FhTime")%><%--结算日期--%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#Eval("FhTime","fenhongDetail.aspx?FhTime={0}") %>'>查看明细</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="15" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt=""/>
                                抱歉！目前数据库暂无数据显示。</span></div>
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
