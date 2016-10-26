<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Address.aspx.cs" Inherits="Web.user.product.Address" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server" class="stdform">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="right_content">
            <h2><%=GetLanguage("AddressManage")%><%--地址管理--%></h2>
            <h6><%=GetLanguage("ShopAddress") %><%--收货地址--%>：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("DetailedAddress")%><%--详细地址--%>：
                        </label>
                        <div class="field">
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="SingleLine" class="input_select" Height="21px" Width="95%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("ConsigneeName")%><%--收货人姓名--%>：
                        </label>
                        <div class="field">
                            <asp:TextBox ID="txtMemberName" runat="server" class="input_reg" Width="180px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("CommonPhone")%><%--常用手机号--%>：
                        </label>
                        <div class="field">
                            <asp:TextBox ID="txtPhoneNum" runat="server" class="input_reg" Width="180px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("StandbyPhone")%><%--备用手机号--%>：
                        </label>
                        <div class="field">
                            <asp:TextBox ID="txtPhone" runat="server" class="input_reg" Width="180px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("SetDefault")%><%--设为默认地址--%>：
                        </label>
                        <div class="field">
                            <asp:CheckBox ID="chkDefault"  Checked="false" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="action">
                <asp:Button ID="btnSubmit" runat="server" Text="提 交" class="btn btn-submit" OnClick="btnSubmit_Click" />
            </div>
            <div>&nbsp;</div>
            <h6><%=GetLanguage("AddressList")%><%--地址列表--%></h6>
            <table class="styled">
                <thead>
                    <tr>
                        <th align="center"><%=GetLanguage("DetailedAddress")%><%--详细地址--%>
                        </th>
                        <th align="center"><%=GetLanguage("ConsigneeName")%><%--收货人姓名--%>
                        </th>
                        <th align="center"><%=GetLanguage("CommonPhone")%><%--常用手机号--%>
                        </th>
                        <th align="center"><%=GetLanguage("StandbyPhone")%><%--备用手机号--%>
                        </th>
                        <th align="center"><%=GetLanguage("SetDefault")%><%--默认地址--%>
                        </th>
                        <th align="center"><%=GetLanguage("Operation")%><%--操作--%>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%# Eval("Address")%>
                                </td>
                                <td align="center">
                                    <%# Eval("MemberName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("PhoneNum")%>
                                </td>
                                <td align="center">
                                    <%# Eval("Phone")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Address01").ToString()=="0" ? GetLanguage("NoCast") : GetLanguage("YesCast") %>
                                </td>
                                <td align="center">
                                    <%if (currentCulture != "en-us")
                                      {%>
                                    <asp:LinkButton ID="lbtnDefault" class="btn" runat="server" CommandArgument='<%# Eval("ID") %>' Visible='<%#Eval("Address01").ToString()=="0" ? true:false %>'
                                        CommandName="Default" OnClientClick="javascript:return confirm('设定默认地址吗？')"><%=GetLanguage("Default")%><!--默认--></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnEdit" class="btn" runat="server" CommandName="Edit" CommandArgument='<%#Eval("ID") %>'><%=GetLanguage("Edit")%><%--编辑--%></asp:LinkButton>
                                    <%}
                                      else
                                      {%>
                                    <asp:LinkButton ID="lbtnDefaultEn" class="btn" runat="server" CommandArgument='<%# Eval("ID") %>' Visible='<%#Eval("Address01").ToString()=="0" ? true:false %>'
                                        CommandName="Default" OnClientClick="javascript:return confirm('Set default address?')"><%=GetLanguage("Default")%><!--默认--></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnEditEn" class="btn" runat="server" CommandName="Edit" CommandArgument='<%#Eval("ID") %>'><%=GetLanguage("Edit")%><%--编辑--%></asp:LinkButton>
                                    <%} %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="9">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
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
    </form>
</body>
</html>
