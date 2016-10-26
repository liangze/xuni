<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Remit.aspx.cs" Inherits="Web.user.finance.Remit" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>充值E币</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link href="../../style/index.css" rel="stylesheet" type="text/css" />
    <link href="../../style/style.css" rel="stylesheet" type="text/css" />
    <link href="../../style/ny.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .inputLen {
            width: 160px;
        }
    </style>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" language="javascript" src="../../JS/jquery-1.7.1.min.js"></script>
</head>
<body>
    <form id="form1" class="box_con" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="main">
            <div class="right">
                <div class="title">
                    <span>当前位置：<a href="../default.aspx" class="hui">首页</a> &gt; 财务管理</span><h2>充值电子币</h2>
                </div>
                <div class="right_nr">

        <div class="box box_width">
            <div class="capositon">
                <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("Financial")%>>><a href="javascript:void(0)"><%=GetLanguage("Chongzhi")%></a>
            </div>
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">汇款单</legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                        <tr id="trBank">
                            <td>汇入银行：
                            <asp:DropDownList ID="dropBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropBank_SelectedIndexChanged">
                            </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;汇入账户：<a href="javascript:void(0)"><asp:Label ID="lblBankAccount" runat="server" Text=""></asp:Label></a>&nbsp;&nbsp;开户名：<a
                                href="javascript:void(0)"><asp:Label ID="lblBankAccountUser" runat="server" Text=""></asp:Label></a>
                            </td>
                        </tr>
                        <tr>
                            <td>录入信息：请核实您的会员编号：<a href="javascript:void(0)"><%=LoginUser.UserCode %></a>&nbsp;您的姓名：<a href="javascript:void(0)"><%=LoginUser.TrueName %></a>&nbsp;您的级别：<a href="javascript:void(0)"><%=levelBLL.GetModel(Convert.ToInt32(LoginUser.LevelID)).LevelName%></a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="param" type="hidden" runat="server" />
                                <span style="color: Red;">*</span>汇款金额：<input name="jd" type="text" id="txtMoney" runat="server" onkeydown="if(event.keyCode==13)event.keyCode=9"
                                    onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"
                                    class="input_select inputLen" />元&nbsp;&nbsp;
                            <span style="color: Red;">*</span>汇款具体时间：<asp:TextBox ID="txtTime" runat="server" class=" input_select inputLen" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="color: Red;">*</span>汇出银行：
                                <input type="text" id="txtOutBank" runat="server" class="input_select inputLen" />
                                &nbsp;&nbsp;&nbsp;
                                <span style="color: Red;">*</span>汇出账户：
                                <asp:TextBox ID="txtOutAccount" type="text" runat="server" class=" input_select inputLen" MaxLength="19"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>汇款备注：<asp:TextBox ID="txtRemark" class=" input_remark" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSubmit" runat="server" Style="margin: 0px;" Text="提 交" class="btn" OnClick="btnSubmit_Click" OnClientClick="javascript:return confirm('确定要充值吗？')" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" Style="margin: 0px;" Text="重 置" class="btn" OnClick="btnReset_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset class="fieldset">
                    <legend class="legSearch">汇款记录</legend>
                    申请日期：<asp:TextBox ID="txtStart" tip="输入申请日期" runat="server" onfocus="new WdatePicker()" class="input_select"></asp:TextBox>&nbsp;至&nbsp;<asp:TextBox ID="txtEnd" tip="输入申请日期" runat="server" onfocus="new WdatePicker()"
                        class="input_select"></asp:TextBox>
                    &nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
                </fieldset>
            </div>
            <div class="dataTable" align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">汇款金额
                        </th>
                        <th align="center">汇款具体时间
                        </th>
                        <th align="center">汇出银行
                        </th>
                        <th align="center">汇出账户
                        </th>
                        <th align="center">汇款备注
                        </th>
                        <th align="center">申请日期
                        </th>
                        <th align="center">状态
                        </th>
                    </tr>
                    <asp:Repeater ID="rpTake" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("RemitMoney")%>
                                </td>
                                <td align="center">
                                    <%#Eval("RechargeableDate")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Remit003")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Remit004")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Remark")%>
                                </td>
                                <td align="center">
                                    <%#Eval("AddDate")%>
                                </td>
                                <td align="center">
                                    <%#Eval("State").ToString() == "0" ?"未审" : "已审"%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="7">
                            <div id="divno" runat="server" class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                    <%=GetLanguage("Manager")%></span>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="yellow">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                        PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                        UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
                        textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
