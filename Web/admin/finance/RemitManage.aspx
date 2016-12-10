<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemitManage.aspx.cs" Inherits="Web.admin.finance.RemitManage" %>


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
                    <legend class="legSearch">汇款查询</legend>
                    会员编号：<asp:TextBox ID="txtUserCode" runat="server" tip="输入会员编号" class="input_select"></asp:TextBox>
                    会员姓名：<asp:TextBox ID="txtTrueName" runat="server" tip="输入会员姓名" class="input_select"></asp:TextBox>
                    审核状态：<asp:DropDownList ID="dropState" runat="server">
                        <asp:ListItem Value="0" Text="请选择">请选择</asp:ListItem>
                        <asp:ListItem Value="1" Text="未审核">未审核</asp:ListItem>
                        <asp:ListItem Value="2" Text="已审核">已审核</asp:ListItem>
                    </asp:DropDownList>
                    申请日期：<asp:TextBox ID="txtStar" tip="输入申请日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                    至<asp:TextBox ID="txtEnd" tip="输入申请日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>

                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"
                        iconcls="icon-search" OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>会员编号</th>
                        <th>会员姓名</th>
                        <th>汇款金额</th>
                        <th>充值币种</th>
                        <th>汇款具体时间</th>
                        <th>汇出银行</th>
                        <th>汇出账户</th>
                        <th>汇款备注</th>
                        <th>汇入银行</th>
                        <th>汇入账户</th>
                        <th>汇入开户名</th>
                        <th>申请日期</th>
                        <th>审核状态</th>
                        <th>操作</th>
                    </tr>
                    <asp:Repeater ID="rpRemit" runat="server" OnItemCommand="rpRemit_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td align="center"><%#Eval("UserCode")%></td>
                                <td align="center"><%#Eval("Truename")%></td>
                                <td align="center"><%#Eval("RemitMoney")%></td>
                                <td align="center"><%#RechargeType(Convert.ToInt32(Eval("Remit001")))%></td>
                                <td align="center"><%#Eval("RechargeableDate")%></td>
                                <td align="center"><%#Eval("Remit003")%></td>
                                <td align="center"><%#Eval("Remit004")%></td>
                                <td align="center"><%#Eval("Remark")%></td>
                                <td align="center"><%#Eval("BankName")%></td>
                                <td align="center"><%#Eval("BankAccount")%></td>
                                <td align="center"><%#Eval("BankAccountUser")%></td>
                                <td align="center"><%#Eval("AddDate")%></td>
                                <td align="center"><%#Eval("State").ToString() == "0" ? "未审" : "已审"%></td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnVerify" runat="server" CommandArgument='<%# Eval("ID") %>' class="easyui-linkbutton"
                                        iconcls="icon-ok" CommandName="verify" OnClientClick="javascript:return confirm('确定审核？')" Visible='<%#Convert.ToInt32(Eval("State"))==0?true:false%>'>确认</asp:LinkButton>
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%# Eval("ID") %>' class="easyui-linkbutton"
                                        iconcls="icon-no" CommandName="Remove" OnClientClick="javascript:return confirm('确定要删除吗？')" Visible='<%#Convert.ToInt32(Eval("State"))==0?true:false%>'>删除</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="11">
                            <div id="divno" runat="server" class="NoData">
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
