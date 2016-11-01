<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferToEmoney.aspx.cs"
    Inherits="Web.user.finance.TransferToEmoney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtMoney").val(" ");
            $("#txtMoney").click(function () {
                $(this).val("");
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="right_content">
            <h2><%=GetLanguage("Transfer")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("CirculatingGold")%><%--奖金币--%>(￥)：</label>
                        <span class="field">
                            <input name="txtBonusAccount" id="txtBonusAccount" runat="server" type="text" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("Registeredcurrency")%><%--注册币--%>(￥)：</label>
                        <span class="field">
                            <input name="txtEmoney" id="Emoney" runat="server" type="text" disabled="disabled" />
                        </span>
                    </p>
                </div>
            </div>
            <div>&nbsp;</div>
            <h6><%=GetLanguage("MemberTransfer")%><%--会员转账--%></h6>
            <div>&nbsp;</div>
            <div class="filter">
                <div class="row-fluid">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                        <ContentTemplate>
                            <p class="span3">
                                <label><%=GetLanguage("TransferType")%><!--转账类型-->：</label>
                                <span class="field">
                                    <asp:DropDownList ID="dropCurrency" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropCurrency_SelectedIndexChanged"></asp:DropDownList>
                                </span>
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                            <p class="span3">
                                <label><%=GetLanguage("MembershipNumber")%><!--会员编号-->：</label>
                                <span class="field">

                                    <asp:TextBox runat="server" ID="txtUserCode" class="input_select" Text="" AutoPostBack="true"
                                        OnTextChanged="txtUserCode_TextChanged"></asp:TextBox>
                                </span>
                            </p>
                            <p class="span3">
                                <label><%=GetLanguage("MemberName")%><!--会员姓名-->：</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtTrueName" class="input_select" Text="" Enabled="false"></asp:TextBox>

                                </span>
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="row-fluid">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                        <ContentTemplate>
                            <p class="span3">
                                <label><%=GetLanguage("TheTransferAmount")%><!--转账金额-->：</label>
                                <span class="field">
                                    <asp:TextBox ID="txtMoney" class="input_select" runat="server" type="text"
                                        onkeydown="if(event.keyCode==13)event.keyCode=9" onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"
                                        AutoPostBack="True" OnTextChanged="txtMoney_TextChanged" /><%=GetLanguage("USD")%><!--元-->
                                </span>
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                        <ContentTemplate>
                            <p class="span3">
                                <label><%=GetLanguage("ActualAmount")%><%--到账金额--%>：</label>
                                <span class="field">
                                    <input type="text" id="txtActualAmount" runat="server" disabled="disabled" class="input_select" name="txtActualAmount" />
                                </span>
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <p class="span3">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" class="btn" OnClick="btnSubmit_Click" />
                    </p>
                </div>
            </div>
            <div>&nbsp;</div>
            <h6><%=GetLanguage("TransferQuery")%><%--转账查询--%></h6>
            <div>&nbsp;</div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("CurrencyType")%><!--币种-->：</label>
                        <span class="field">
                            <asp:DropDownList ID="dropType" runat="server"></asp:DropDownList>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("DateTransfer")%><!--转账日期-->：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtStartEn" runat="server" class="input_select" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtEnd" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEndEn" runat="server" class="input_select" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" class="btn" OnClick="btnSearch_Click" />
                    </p>
                </div>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th>
                            <%=GetLanguage("MembershipNumber")%>
                            <!--会员编号-->
                        </th>
                        <th>
                            <%=GetLanguage("MemberName")%>
                            <!--会员姓名-->
                        </th>
                        <th>
                            <%=GetLanguage("TransferType")%>
                            <!--转账类型-->
                        </th>
                        <th>
                            <%=GetLanguage("TheTransferAmount")%>
                            <!--转账金额-->
                        </th>
                        <th>
                            <%=GetLanguage("ActualAmount")%>
                            <!--到账金额-->
                        </th>
                        <th>
                            <%=GetLanguage("DateTransfer")%>
                            <!--转账日期-->
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("TrueName")%>
                                </td>
                                <td align="center">
                                    <%#ChangeType(Convert.ToInt32(Eval("ChangeType")))%>
                                </td>
                                <td align="center">
                                    <%#Eval("Amount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Change005")%>
                                </td>
                                <td align="center">
                                    <%#Eval("ChangeDate")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="5" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True"
                    InputBoxClass="pageinput" NumericButtonCount="3" PageSize="10" ShowInputBox="Never"
                    ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"
                    pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
