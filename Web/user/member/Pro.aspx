<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pro.aspx.cs" Inherits="Web.user.member.Pro" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员升级</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link href="../../style/index.css" rel="stylesheet" type="text/css" />
    <link href="../../style/style.css" rel="stylesheet" type="text/css" />
    <link href="../../style/ny.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" class="box_con" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div id="main">
        <!--左侧菜单 star-->
        <div class="left">
            <div class="menu_t">会员管理</div>
            <div class="menu_x">
                <ul>
                    <li><a href="../team/RecommendTree.aspx" target="fMain">推荐网络</a></li>
                    <%--<li><a href="user/team/MemberTree.aspx" target="fMain">系谱图</a></li>--%>
                    <li><a href="../../Registers.aspx" target="fMain">会员注册</a></li>
                    <li><a href="PersonalInfo.aspx" target="fMain">会员资料</a></li>
                    <li><a href="ModifyPassWord.aspx" target="fMain">修改密码</a></li>
                    <li><a href="Pro.aspx" target="fMain" class="cur2">会员升级</a></li>
                    <%if (LoginUser.LevelID > 4)
                      { %>
                        <li><a href="../team/Agent.aspx" target="fMain">区域申请</a></li>
                    <%} %>
                </ul>
            </div>
        </div>
        <!--左侧菜单 end-->
        <div class="right">
            <div class="title">
                <span>当前位置：<a href="user/default.aspx" class="hui">首页</a> &gt; 会员管理</span><h2>会员注册</h2>
            </div>
            <div class="right_nr">

    <div class="box box_width">
        <div class="capositon">
            <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("Member")%>>><a href="javascript:void(0)"><%=GetLanguage("MembershipUpgrade")%></a>
            <asp:Button ID="Button1" runat="server" Text="账户查询" class="btn" PostBackUrl="../finance/dl_JournalAccount.aspx" />
            <%--<%if (Loginagent != null && Loginagent.Flag == 1)
              {%>
            <asp:Button ID="Button3" runat="server" Text="我要充值" class="btn" PostBackUrl="../finance/Remit.aspx" />
            <%
          } %>--%>
            <%--<asp:Button ID="Button4" runat="server" Text="账户转账" class="btn" PostBackUrl="../finance/TransferToEmoney.aspx" />--%>
        </div>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch"><%=GetLanguage("MembershipUpgrade")%><!--会员升级--></legend>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr>
                        <td colspan="2">
                            <%=GetLanguage("MembershipNumber")%><!--会员编号-->：<a><asp:Label ID="lblUserCode" runat="server" Text=""></asp:Label></a>，
                             <%=GetLanguage("MemberName")%><!--会员姓名-->：<a><asp:Label ID="lblTrueName" runat="server" Text=""></asp:Label></a>， 
                             <%=GetLanguage("MembershipLevels")%><!--会员级别-->：<a><asp:Label ID="lblLevel" runat="server" Text=""></asp:Label></a>
                            ， 现金币余额：<a><asp:Label ID="lbEmoney" runat="server" Text=""></asp:Label></a>
                        </td>
                    </tr>
                    <tr>
                        <td width="350px">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <%=GetLanguage("UpgradeLevels")%><!--升级级别-->：<asp:DropDownList ID="ddlLevel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <%=GetLanguage("PaidAmount")%><!--缴纳金额-->：<input name="jd" type="text" id="txtMoney" runat="server" disabled="disabled"
                                        class="input_select" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" class="btn" Text="提 交" OnClick="btnSubmit_Click" />
                            <font color="red">
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal></font>
                            </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="dataTable" align="center">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        <%=GetLanguage("UpgradeBeforeLevels")%><!--升级前级别-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("TheUpgradeLevels")%><!--升级后级别-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("PaidAmount")%><!--缴纳金额-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("Shenqing")%><!--申请日期-->
                    </th>
                    <th align="center">
                        审核日期
                    </th>
                    <th align="center">
                        <%=GetLanguage("State")%><!--状态-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("Notes")%><!--备注-->
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%# getLastLevel(Convert.ToInt32(Eval("LastLevel")))%>
                            </td>
                            <td align="center">
                                <%# getLastLevel(Convert.ToInt32(Eval("EndLevel")))%>
                            </td>
                            <td align="center">
                                <%#Eval("ProMoney")%>
                            </td>
                            <td align="center">
                                <%#Eval("AddDate")%>
                            </td>
                            <td align="center">
                                <%#Eval("FlagDate")%>
                            </td>
                            <td align="center">
                            <% if (Language == "zh-cn")
                               { %>
                                <%#Eval("Flag").ToString() == "0" ? "未审核" : "已审核"%>
                            <% }
                               else
                               { %>
                              <%#Eval("Flag").ToString() == "0" ? "Not audited" : "Has been approved"%>
                            <% }%>
                                
                            </td>
                            <td align="center">
                                <%#Eval("Remark")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="6">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                <%=GetLanguage("Manager")%></span></div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin"  OnPageChanged="AspNetPager1_PageChanged"
                     AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                    PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                    UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="">
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
