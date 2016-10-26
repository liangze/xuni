<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jiaoyijilu.aspx.cs" Inherits="Web.user.licai.jiaoyijilu" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>交易记录</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Tooltip.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../hdm/qtabs.css" rel="stylesheet" type="text/css" />
    <script src="../../hdm/mootools.js" type="text/javascript"></script>
    <script src="../../hdm/qtabs.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="box_con">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="box box_width">
            <div class="qtwrapper qtwrap-round1">
                <div class="qthead-basic">
                    <ul class="qtabs" id="qtabs-ex2">
                        <li><span>买入记录</span></li>
                        <li><span>卖出记录</span></li>
                        <li><span>拆分记录</span></li>
                    </ul>
                </div>
                <div class="qtcurrent current-basic" id="current-ex2">
                    <div class="qtcontent">
                        <div class="operation">
                            <fieldset class="fieldset">
                                <legend class="legSearch">查询</legend>
                                交易时间：<asp:TextBox ID="txtMairuStar" tip="输入交易时间" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                                至<asp:TextBox ID="txtMairuEnd" tip="输入交易时间" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                                <asp:Button ID="btnMairu" runat="server" Text="搜 索" class="btn"
                                    OnClick="btnMairu_Click" />
                            </fieldset>
                        </div>
                        <div class="dataTable">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                                <tr>
                                    <th>卖出人用户名
                                    </th>
                                    <th>交易时间
                                    </th>
                                    <th>交易数
                                    </th>
                                    <th>交易单价
                                    </th>
                                    <th>总价值
                                    </th>
                                    <th>扣除交易钱包金额
                                    </th>
                                </tr>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center">
                                                <%#Eval("FromUserCode")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("SucTime")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("BusinessAmount")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("BusinessPrice")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("SumMoney")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("SumMoney")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr id="tr1" runat="server">
                                    <td colspan="6" align="center">
                                        <div class="NoData">
                                            <span class="cBlack">
                                                <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                                抱歉！目前数据库暂无数据显示。</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center">
                                        <div class="nextpage cBlack">
                                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                                                SubmitButtonClass="pagebutton" UrlPaging="false"
                                                pageindexboxtype="TextBox" showpageindexbox="Always"
                                                SubmitButtonText="" textafterpageindexbox=" 页"
                                                textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                                            </webdiyer:AspNetPager>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="qtcontent">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="operation">
                                    <fieldset class="fieldset">
                                        <legend class="legSearch">查询</legend>
                                        交易时间：<asp:TextBox ID="txtMaichuStar" tip="输入交易时间" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                                        至<asp:TextBox ID="txtMaichuEnd" tip="输入交易时间" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                                        <asp:Button ID="btnMaichu" runat="server" Text="搜 索" class="btn"
                                            OnClick="btnMaichu_Click" />
                                    </fieldset>
                                </div>
                                <div class="dataTable">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                                        <tr>
                                            <th>购买人用户名
                                            </th>
                                            <th>交易时间
                                            </th>
                                            <th>交易数
                                            </th>
                                            <th>交易单价
                                            </th>
                                            <th>总价值
                                            </th>
                                            <th>手续费
                                            </th>
                                            <th>回购股票数
                                            </th>
                                            <th>进入现金金额
                                            </th>
                                            <th>交易类型
                                            </th>
                                        </tr>
                                        <asp:Repeater ID="Repeater2" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="center">
                                                        <%#Eval("FromUserCode")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("SucTime")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("BusinessAmount")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("BusinessPrice")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("SumMoney")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("Poundage")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("InBonusAccount")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("InStockAccount")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Convert.ToInt32(Eval("Notes01"))==1?"强制回购":"正常交易"%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr id="tr2" runat="server">
                                            <td colspan="9" align="center">
                                                <div class="NoData">
                                                    <span class="cBlack">
                                                        <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                                        抱歉！目前数据库暂无数据显示。</span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="9" align="center">
                                                <div class="nextpage cBlack">
                                                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                                        LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                                        NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                                                        SubmitButtonClass="pagebutton" UrlPaging="false"
                                                        pageindexboxtype="TextBox" showpageindexbox="Always"
                                                        SubmitButtonText="" textafterpageindexbox=" 页"
                                                        textbeforepageindexbox="转到 " OnPageChanged="AspNetPager2_PageChanged">
                                                    </webdiyer:AspNetPager>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <%--<div class="TabbedPanelsContent">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <div class="operation">
                    <fieldset class="fieldset">
                        <legend class="legSearch">查询</legend>
                        交易时间：<asp:TextBox ID="txtDaiStar" tip="输入交易时间" runat="server" Width="79px" onfocus="WdatePicker()"></asp:TextBox>
                        至<asp:TextBox ID="txtDaiEnd" tip="输入交易时间" runat="server" Width="79px" onfocus="WdatePicker()"></asp:TextBox>
                        <asp:Button ID="btnDai" runat="server" Text="搜索" Width="68px" class="btn" 
                            onclick="btnDai_Click" />
                    </fieldset>
                </div>
        <div class="dataTable">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th >
                            用户名
                        </th>
                        <th >
                            交易时间
                        </th>
                        <th>
                            交易类型
                        </th>
                        <th >
                            交易数
                        </th>
                        <th >
                            交易单价
                        </th>
                        <th >
                            总共价值
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BusinessTime")%>
                                </td>
                                <td align="center">
                                    <%# getType(Convert.ToInt32(Eval("BusinessType")))%>
                                </td>
                                <td align="center">
                                    <%#Eval("BusinessAmount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BusinessPrice")%>
                                </td>
                                <td align="center">
                                    <%#Eval("SumMoney")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr3" runat="server">
                        <td colspan="6" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库暂无数据显示。</span></div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                <div class="nextpage cBlack">
                    <ul>
                        <li style="float: right; width: 100%;">
                            <webdiyer:AspNetPager ID="AspNetPager3" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                                SubmitButtonClass="pagebutton" UrlPaging="false" 
                                pageindexboxtype="TextBox" showpageindexbox="Always"
                                SubmitButtonText="" textafterpageindexbox=" 页" 
                                textbeforepageindexbox="转到 " onpagechanged="AspNetPager3_PageChanged">
                            </webdiyer:AspNetPager>
                        </li>
                    </ul>
                </div>
                        </td>
                    </tr>
                </table>
                </div>
                </ContentTemplate></asp:UpdatePanel>
            </div>--%>
                    <div class="qtcontent">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="operation">
                                    <fieldset class="fieldset">
                                        <legend class="legSearch">查询</legend>
                                        拆分时间：<asp:TextBox ID="TextBox1" tip="输入拆分时间" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                                        至<asp:TextBox ID="TextBox2" tip="输入拆分时间" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                                        <asp:Button ID="Button1" runat="server" Text="搜 索" class="btn"
                                            OnClick="Button1_Click" />
                                    </fieldset>
                                </div>
                                <div class="dataTable">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                                        <tr>
                                            <th>拆分时间
                                            </th>
                                            <th>拆分前数量
                                            </th>
                                            <th>拆分后数量
                                            </th>
                                        </tr>
                                        <asp:Repeater ID="Repeater4" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="center">
                                                        <%#Eval("SplitStockTime")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("SplitQStock")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("SplitHStock")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr id="tr4" runat="server">
                                            <td colspan="3" align="center">
                                                <div class="NoData">
                                                    <span class="cBlack">
                                                        <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                                        抱歉！目前数据库暂无数据显示。</span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <div class="nextpage cBlack">
                                                    <webdiyer:AspNetPager ID="AspNetPager4" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                                        LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                                        NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                                                        SubmitButtonClass="pagebutton" UrlPaging="false"
                                                        pageindexboxtype="TextBox" showpageindexbox="Always"
                                                        SubmitButtonText="" textafterpageindexbox=" 页"
                                                        textbeforepageindexbox="转到 " OnPageChanged="AspNetPager4_PageChanged">
                                                    </webdiyer:AspNetPager>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <script type="text/javascript">
<!--
    window.addEvent('domready', function () {
        var opt = {
            flexHeight: true
        };
        var t2 = new QTabs('ex2', opt);
    })
    //-->
            </script>
        </div>
    </form>
</body>
</html>
