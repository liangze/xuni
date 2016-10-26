<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Web.admin.finance.Account" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
 <script type="text/javascript" src="../Scripts/Common.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>

</head>
<body>
        <form id="Form1"  runat="server">
        <div class="operation">
                <fieldset class="fieldset">
                <table width="60%" border="0" cellspacing="0" cellpadding="0" class="">
                <tr>
                <td>现有正式会员：<a href="../business/AgentList.aspx"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></a>个</td>
                <td>待激活会员：<a href="../business/Member.aspx"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></a>个</td>
                <td>未读邮件：<a href="../system/LeaveIn.aspx"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></a>条</td>
                <td>申请代理商：<a href="../business/Agent.aspx"><asp:Label ID="Label4" runat="server" Text=""></asp:Label></a>条</td>
                </tr>
                <tr>
                <td>今日申请提现：<a href="TakeMoney.aspx"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></a>条</td>
                <td>已提现金额：<a href="TakeList.aspx"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></a>元</td>
                <td>注册总金额：<a href="Account.aspx"><asp:Label ID="Label7" runat="server" Text=""></asp:Label></a>元</td>
                <td style="display:none;">E币充值：<a href="RemitManage.aspx"><asp:Label ID="Label8" runat="server" Text=""></asp:Label></a>条</td>
                </tr>
                </table>
                </fieldset>
                </div>
        <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">
                            
                        </th>
                        <th align="center">
                            总收入
                        </th>
                        <th align="center">
                            总支出
                        </th>
                        <th align="center">
                            总盈利
                        </th>
                        <th align="center">
                            拨出比率
                        </th>
                    </tr>
                    <tr>
                        <td align="center">
                            总计
                        </td>
                        <td align="center">
                            <%=GetIncomeTotal().ToString("0.00")%>
                        </td>
                        <td align="center">
                            <%=GetPayTotal().ToString("0.00")%>
                        </td>
                        <td align="center">
                            <%=(GetIncomeTotal() - GetPayTotal()).ToString("0.00")%>
                        </td>
                        <td align="center">
                            <%=GetIncomeTotal() == 0 ? "0" : (GetPayTotal() / GetIncomeTotal() * 100).ToString("0.00")%>%
                        </td>
                    </tr>
                </table>
                </div>
        <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">查詢</legend>
                       結算日期：<asp:TextBox ID="txtStar" tip="輸入日期" runat="server"  class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="輸入日期" runat="server"  class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search" onclick="LinkButton2_Click"  > 搜 索 </asp:LinkButton>
                </fieldset>
                </div>
        <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">
                            結算日期
                        </th>
                        <th align="center">
                            本日收入
                        </th>
                        <th align="center">
                            本日支出
                        </th>
                        <th align="center">
                            本日盈利
                        </th>
                        <th align="center">
                            拨出比率
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" >
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                              <%#Eval("recordTime")%>
                              
                                </td>
                                <td align="center">
                                 
                                    <%#  (float.Parse(Eval("sr").ToString())).ToString("0.00")%>
                                </td>
                                <td align="center">
                                   
                                     <%#  (float.Parse(Eval("zc").ToString())).ToString("0.00")%>
                                </td>
                                <td align="center">
                                  <%#  (float.Parse(Eval("yl").ToString())).ToString("0.00")%>
                                  
                                </td>
                                <td align="center">
                                  <%#MyBL(Eval("sr"),Eval("zc"))%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="5" align="center">
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
                        SubmitButtonClass="pagebutton" UrlPaging="false" 
                        pageindexboxtype="TextBox" showpageindexbox="Always"
                        SubmitButtonText="" textafterpageindexbox=" 页" 
                        textbeforepageindexbox="转到 " Direction="LeftToRight"
                        HorizontalAlign="Right" onpagechanged="AspNetPager1_PageChanged" >
                    </webdiyer:AspNetPager>
                </div>
                </div>
        </form>
</body>
</html>