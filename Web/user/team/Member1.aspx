<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member1.aspx.cs" Inherits="Web.user.team.Member1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        业绩查询</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2>业绩查询 </h2>
            <div class="filter"  style="display:none">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("select")%><!--选择下拉-->：</label>
                        <span class="field">
                            <asp:DropDownList ID="dropType" runat="server">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <p class="span3">
                        <span class="field">
                            <input name="txtInput" id="txtInput" class="input_select" runat="server" type="text" />
                        </span>
                    </p>
                </div>
            </div>
            <div class="filter" style="display:none">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("RegistrationHours")%><!--注册时间-->：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtStartEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtEnd" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEndEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn" Text="搜索" />
                    </p>
                </div>
            </div>
            <table class="styled" style="font-size:12px;">
                <thead>
                    <tr>
                        <th align="center">
                            <%=GetLanguage("MembershipNumber")%><!--会员编号-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("MemberName")%><!--会员姓名-->
                        </th>
                        <th align="center">
                         1市场业绩
                        </th>
                        <th align="center">
                          2市场业绩
                        </th>
                        <th align="center">
                         1市场新业绩
                        </th>
                        <th align="center">
                         2市场新业绩
                        </th>
                       
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server"  >
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center"> 
                                        <%# Eval("UserCode")%></a>
                                </td>
                                <td align="center">
                                    <%#Eval("TrueName")%>
                                </td>
                                <td align="center">
                                     <%#Eval("LeftScore")%>
                                </td>
                                <td align="center">
                                   <%#Eval("RightScore")%>
                                </td>
                                <td align="center">
                                 <%#Eval("LeftNewScore")%>
                                </td>
                                <td align="center">
                                    <%#Eval("RightNewScore")%>
                                </td>
                                
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="10" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="nextpage cBlack">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True"
                    InputBoxClass="pageinput" NumericButtonCount="3" PageSize="12" ShowInputBox="Never"
                    ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"
                    pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="" Direction="LeftToRight"
                    HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
