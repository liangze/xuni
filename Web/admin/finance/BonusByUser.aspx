<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusByUser.aspx.cs" Inherits="Web.admin.finance.BonusByUser" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
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
    <form class="box_con" runat="server">
    <div class="box box_width">
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        直接招商津贴累计
                    </th>
                    <th>
                        区域津贴累计
                    </th>
                    <th>
                        管理津贴累计
                    </th>
                    <th>
                        幸运津贴累计
                    </th>
                    <%--
                    <th>
                        学习津贴累计
                    </th>--%>
                    <%-- <th>
                        和谐津贴累计
                    </th>--%>
                    <th>
                        应发累计
                    </th>
                    <th>
                        综合服务费累计
                    </th>
                    <%--
                    <th>
                        返本费累计
                    </th>--%>
                    <th>
                        责任消费累计
                    </th>
                    <th>
                        市场权益累计
                    </th>
                    <th>
                        实发累计
                    </th>
                </tr>
                <tr>
                    <td align="center">
                        <%=getBonus(0,2) %><%--直接招商津贴累计 2--%>
                    </td>
                    <td align="center">
                        <%=getBonus(0,1) %>
                        <%--区域津贴累计 1--%>
                    </td>
                    <td align="center">
                        <%--管理津贴累计 4--%>
                        <%=getBonus(0,4) %>
                    </td>
                    <td align="center">
                        <%=getBonus(0,3) %>
                        <%--幸运津贴累计 3--%>
                    </td>
                    <%--
                    <td align="center">
                        <%=getBonus(0,5) %>
                    </td>--%>
                    <%--   <td align="center">
                        <%=getBonus(0,6) %>
                    </td>--%>
                    <td align="center">
                        <%=getBonusYF(0,1) %><%--应发累计 Amount--%>
                    </td>
                    <td align="center">
                        <%=getBonusFWF(0) %><%--综合服务费累计 Revenue--%>
                    </td>
                    <%--
                    <td align="center">
                        <%=getBonusFBF(0) %>
                    </td>--%>
                    <td align="center">
                        <%=getBonusCFXF(0) %><%--责任消费累计 Bonus006--%>
                    </td>
                    <td align="center">
                        <%=getBonus(0,7) %><%--市场权益累计 7--%>
                    </td>
                    <td align="center">
                        <%=getBonusSF(0) %><%--实发累计 sf--%>
                    </td>
                </tr>
            </table>
        </div>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>结算日期：<asp:TextBox ID="txtStar" tip="输入结算日期"
                    runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>

                <th>
                        用户
                    </th>


                    <th>
                        直接招商津贴
                    </th>
                    <th>
                        区域津贴
                    </th>
                    <th>
                        管理津贴
                    </th>
                    <th>
                        幸运津贴
                    </th>
                    <%--
                    <th>
                        学习津贴
                    </th>--%>
                    <%-- <th>
                        和谐津贴
                    </th>--%>
                    <th>
                        应发
                    </th>
                    <th>
                        综合服务费
                    </th>
                    <%--
                    <th>
                        返本费
                    </th>--%>
                    <th>
                        责任消费
                    </th>
                    <th>
                        市场权益
                    </th>
                    <th>
                        实发
                    </th>
                    <th>
                        结算日期
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" runat="server">
                    <ItemTemplate>
                        <tr>

                        <td align="center">
                           <%#Eval("yhm")%>    
                                <%--用户--%>
                            </td>


                            <td align="center">
                                <%#Eval("tj")%>
                                <%--直接招商津贴 Amount 2--%>
                            </td>
                            <td align="center">
                                <%#Eval("dp")%><%--区域津贴 Amount 1--%>
                            </td>
                            <td align="center">
                                <%#Eval("gl")%><%--管理津贴  Amount 4--%>
                            </td>
                            <td align="center">
                                <%#Eval("jd")%><%--幸运津贴 Amount 3--%>
                            </td>
                            <%--
                            <td align="center">
                                <%#Eval("xx")%>
                            </td>--%>
                            <%-- <td align="center">
                                <%#Eval("hx")%>
                            </td>--%>
                            <td align="center">
                                <%#Eval("yf")%><%--应发 Amount--%>
                            </td>
                            <td align="center">
                                <%#Eval("fwf")%><%--综合服务费 Revenue--%>
                            </td>
                            <%--
                            <td align="center">
                                <%#Eval("fbf")%>
                            </td>--%>
                            <td align="center">
                                <%#Eval("cfxf")%><%--责任消费 Bonus006--%>
                            </td>
                            <td align="center">
                                <%#Eval("bd")%><%--市场权益 bd --%>
                            </td>
                            <td align="center">
                                <%#Eval("sf")%><%--实发sf --%>
                            </td>
                            <td align="center">
                                <%#Eval("SttleTime")%><%--结算日期--%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                                    PostBackUrl='<%#Eval("SttleTime","BonusDetail.aspx?SttleTime={0}") %>'>查看明细</asp:LinkButton>
                                    |&nbsp;

                                    <a class="easyui-linkbutton"  href='BonusByUserDel.aspx?uid=<%#Eval("uid") %>&SttleTime= <%#Eval("SttleTime")%>'>删除</a>
                                   
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="12" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" />
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
