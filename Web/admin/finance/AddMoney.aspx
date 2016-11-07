<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMoney.aspx.cs" Inherits="Web.admin.finance.AddMoney" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body class="subBody">
    <form id="Form1" class="box_con" runat="server">
        <div class="box box_width">
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">操作</legend>
                    会员编号：<asp:TextBox ID="txtUserCode" class="input_select" runat="server" tip="输入会员编号"></asp:TextBox>
                    &nbsp;&nbsp;金币类型：<asp:DropDownList ID="dropMoneyType" runat="server">
                        <%--  Emoney = 0;// 注册积分         写流水类型：1
                              BonusAccount = 0;// 奖金积分 	 2
                              AllBonusAccount = 0;// 电子积分	 3
                              StockAccount = 0;// 云商积分	 4
                              StockMoney = 0;// 感恩积分	 5
                              GLmoney = 0;// 购物积分	 6
                              ShopAccount = 0;// 消费积分	 7
                              User011// 爱心基金	 8
                              User012// 云购积分	 9--%>
                        <asp:ListItem Value="0" Text="请选择"></asp:ListItem>
                        <asp:ListItem Value="1" Text="注册积分"></asp:ListItem>
                        <asp:ListItem Value="2" Text="奖金积分"></asp:ListItem>
                        <asp:ListItem Value="3" Text="电子积分"></asp:ListItem>
                        <asp:ListItem Value="4" Text="云商积分"></asp:ListItem>
                        <asp:ListItem Value="5" Text="感恩积分"></asp:ListItem>
                        <asp:ListItem Value="6" Text="购物积分"></asp:ListItem>
                        <asp:ListItem Value="7" Text="消费积分"></asp:ListItem>
                        <asp:ListItem Value="8" Text="爱心基金"></asp:ListItem>
                        <asp:ListItem Value="9" Text="云购积分"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;充值类型：<asp:DropDownList ID="dropRechargeStyle" runat="server">
                        <asp:ListItem Value="0" Text="请选择"></asp:ListItem>
                        <asp:ListItem Value="1" Text="增加"></asp:ListItem>
                        <asp:ListItem Value="2" Text="扣除"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp; 充值金额：<asp:TextBox ID="txtMoney" class="easyui-numberbox input_select" runat="server" min="0" precision="2" tip="输入充值金额"></asp:TextBox>元
    <asp:LinkButton ID="lbtnSubmit" runat="server" class="easyui-linkbutton"
        iconcls="icon-ok" OnClientClick="javascript:return confirm('确认给该会员充值？')" OnClick="lbtnSubmit_Click"> 提 交 </asp:LinkButton>
                    &nbsp;&nbsp;
                </fieldset>
                <fieldset class="fieldset">
                    <legend class="legSearch">会员查询</legend>
                    会员编号：
                    <asp:TextBox ID="txtCode" runat="server" tip="输入会员编号" class="input_select"></asp:TextBox>
                    &nbsp;&nbsp;充值类型:<asp:DropDownList ID="dropType" runat="server">
                        <asp:ListItem Value="0" Text="请选择"></asp:ListItem>
                        <asp:ListItem Value="1" Text="增加"></asp:ListItem>
                        <asp:ListItem Value="2" Text="扣除"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;充值日期：<asp:TextBox ID="txtStart" tip="输入充值日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>&nbsp;至&nbsp;<asp:TextBox ID="txtEnd" tip="输入充值日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                    <asp:LinkButton ID="lbtnSearch" runat="server" class="easyui-linkbutton"
                        iconcls="icon-search" OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">会员编号</th>
                        <th align="center">充值金额</th>
                        <th align="center">充值类型</th>
                        <th align="center">金币类型</th>
                        <th align="center">充值方式</th>
                        <th align="center">充值结果</th>
                        <th align="center">充值日期</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("RechargeableMoney")%>
                                </td>
                                <td align="center">
                                    <%#Eval("RechargeStyle").ToString() == "1" ? "增加" : "减少"%>
                                </td>
                                <td align="center">
                                    <%#RechargeType(Convert.ToInt32(Eval("RechargeType")))%>
                                </td>
                                <td align="center">
                                    <%#Eval("Recharge001").ToString() == "1" ? "后台" :"支付宝"%>
                                </td>
                                <td align="center">
                                    <%#Eval("Flag").ToString() == "1" ? "<font style='color:green'>成功</font>" :"<font style='color:red'>失败</font>"%>
                                </td>
                                <td align="center">
                                    <%#Eval("RechargeDate")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="7" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
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

