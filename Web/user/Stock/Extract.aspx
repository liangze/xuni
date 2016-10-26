<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Extract.aspx.cs" Inherits="Web.user.Stock.Extract" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>A盘提现</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" class="box_con" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class="capositon">
            <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("Financial")%>>><a href="javascript:void(0)"><%=GetLanguage("Extract")%></a>
        </div>
        <div class="operation">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <fieldset class="fieldset">
                        <legend class="legSearch">提现金额</legend>奖金余额：<input name="txtMoney" type="text" id="txtMoney"
                            runat="server" disabled="disabled" class=" input_select" />&nbsp;&nbsp;&nbsp;&nbsp;提现金额：<asp:TextBox
                                ID="txtTake" class="easyui-numberbox input_select" precision="2" runat="server"
                                AutoPostBack="True" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"
                                OnTextChanged="txtTake_TextChanged"></asp:TextBox><%=GetLanguage("USD")%><!--元-->&nbsp;&nbsp;&nbsp;&nbsp;到账金额：<input
                                    name="txtExtMoney" type="text" id="txtExtMoney" runat="server" disabled="disabled"
                                    class="input_select" /><%=GetLanguage("USD")%><!--元--><br />
                        <br />
                        密保问题：<input name="txtQuestion" type="text" id="txtQuestion" runat="server" disabled="disabled"
                            class=" input_select" />&nbsp;&nbsp;&nbsp;&nbsp;密保答案：<asp:TextBox runat="server"
                                ID="txtAnswer" Text="" TextMode="Password" class="input_select"></asp:TextBox><br />
                    </fieldset>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <fieldset class="fieldset">
                <legend class="legSearch">提现选项</legend>是否自定义提现：<asp:RadioButton ID="radOurselfOne"
                    runat="server" GroupName="Our" />是&nbsp;&nbsp;<asp:RadioButton ID="radOurselfTwo"
                        runat="server" Checked="true" GroupName="Our" />否<br />
                <br />
                开户银行：<asp:DropDownList ID="dropBank" runat="server" class="input_select2">
                </asp:DropDownList>
                &nbsp;&nbsp;银行支行：<asp:TextBox ID="txtBankBranch" runat="server" class="input_reg"></asp:TextBox><br />
                <br />
                银行账户：<asp:TextBox ID="txtBankAccount" runat="server" class="input_reg"></asp:TextBox>&nbsp;&nbsp;开户姓名：<asp:TextBox
                    ID="txtBankAccountUser" runat="server" class="input_reg"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                        ID="btnSubmit" runat="server" Style="margin: 0px;" Text="提 交" class="btn" OnClick="btnSubmit_Click" /><span
                            style="color: #aa0000;"><asp:Literal ID="ltReminder" runat="server"></asp:Literal></span>
            </fieldset>
            <br />
            <fieldset class="fieldset">
                <legend class="legSearch">A盘提现记录</legend>
                <br />
                <%=GetLanguage("Withdrawal")%><!--已提现金额-->：<input name="jd" type="text" id="txtBalance"
                    runat="server" disabled="disabled" class=" input_select" />&nbsp;&nbsp;&nbsp;&nbsp;
                <%=GetLanguage("DateWithdrawal")%>
                <!--提现日期-->
                ：
                <%if (GetLanguage("LoginLable") == "zh-cn")
                  {%>
                <asp:TextBox ID="txtStar" tip="输入提现日期" runat="server" onfocus="new WdatePicker();"
                    class="input_select"></asp:TextBox>
                <%=GetLanguage("To")%>
                <!--至-->
                <asp:TextBox ID="txtEnd" tip="输入提现日期" class="input_select" runat="server" onfocus="new WdatePicker();"></asp:TextBox>
                <%}
                  else
                  {%>
                <asp:TextBox ID="txtStarEn" tip="input withdraw deposits date" runat="server" onfocus="new WdatePicker({lang:'en'});"
                    class="input_select"></asp:TextBox>
                <%=GetLanguage("To")%>
                <!--至-->
                <asp:TextBox ID="txtEndEn" tip="input withdraw deposits date" class="input_select"
                    runat="server" onfocus="new WdatePicker({lang:'en'});"></asp:TextBox>
                <%} %>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
            </fieldset>
        </div>
        <div class="dataTable" align="center">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        <%=GetLanguage("WithdrawalAmount")%><!--提现金额-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("WithdrawalFee")%><!--提现手续费-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("TheActualAmount")%><!--实际金额-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("DateWithdrawal")%><!--提现日期-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("state")%><!--状态-->
                    </th>
                    <th>
                        <%=GetLanguage("Operation")%><!--操作-->
                    </th>
                </tr>
                <asp:Repeater ID="rpTake" runat="server" OnItemCommand="rpTake_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("TakeMoney")%>
                            </td>
                            <td align="center">
                                <%#Eval("TakePoundage")%>
                            </td>
                            <td align="center">
                                <%#Eval("RealityMoney")%>
                            </td>
                            <td align="center">
                                <%#Eval("TakeTime")%>
                            </td>
                            <td align="center">
                                <% if (Language == "zh-cn")
                                   { %>
                                <%#Eval("Flag").ToString() == "0" ? "未发放" : "已发放"%>
                                <% }
                                   else
                                   { %>
                                <%#Eval("Flag").ToString() == "0" ? "Not released" : "Has been released"%>
                                <% }%>
                            </td>
                            <td>
                                &nbsp<asp:LinkButton ID="lbtnCancel" runat="server" class="btn" CommandName="change" Visible='<%#Eval("Flag").ToString() == "0" ? true : false%>'
                                    CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('确认取消提现吗？')"><%=GetLanguage("CancelWithdrawal")%><!--取消提现--></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="6">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span></div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" OnPageChanged="AspNetPager1_PageChanged"
                    AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3" PageSize="10"
                    ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                    UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
