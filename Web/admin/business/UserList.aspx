<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Web.admin.business.UserList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
 <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" class="box_con" runat="server">
    <div class="box box_width">
        <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">查询</legend>
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr>
                    <td>
                                会员编号：<input name="Add_sscFd7" id="txtUserCode" 
                         class="input_select" runat="server" type="text" />
                                会员姓名：<input name="Add_sscFd7" id="txtTreuName" 
                         class="input_select" runat="server" type="text" />
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton4" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search"    OnClick="btnSearch1_Click"  > 搜 索 </asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-print" onclick="daochu_Click"  style=" display:none;" > 导出Excel </asp:LinkButton>
                    </td>
                    </tr>
                    </table>
                </fieldset>
                </div>
        <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">
                            会员编号
                        </th>
                        <th align="center">
                            会员姓名
                        </th>
                        <th align="center">
                            会员级别
                        </th>
                        <th align="center">
                            注册金额
                        </th>
<%--                        <th align="center">
                            开户行
                        </th>
                        <th align="center">
                            开户账号
                        </th>
                        <th align="center">
                            开户姓名
                        </th>--%>
                        <th align="center">
                            身份证号
                        </th>
                        <th align="center">
                            联系电话
                        </th>
<%--                        <th align="center">
                            联系地址
                        </th>
                        <th align="center">
                            Email
                        </th>--%>
                        <th align="center">
                            昵称
                        </th>
                        <th align="center">
                            奖金余额
                        </th>
                        <th align="center">
                            E币余额
                        </th>
                        <th align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater2" runat="server" 
                        onitemcommand="Repeater2_ItemCommand">
                        <ItemTemplate>
                            <tr>
                            <td align="center">
                            <%# Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("TrueName")%>
                            </td>
                            <td align="center">
                                <%#Eval("LevelName")%>
                            </td>
                            <td align="center">
                                <%#Eval("RegMoney")%>
                            </td>
<%--                            <td align="center">
                                <%#Eval("BankName")%>
                            </td>
                            <td align="center">
                                <%#Eval("BankAccount")%>
                            </td>
                            <td align="center">
                                <%#Eval("BankAccountUser")%>
                            </td>--%>
                            <td align="center">
                                <%#Eval("IdenCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("PhoneNum")%>
                            </td>
                            <%-- <td align="center">
                                <%#Eval("Address")%>
                            </td>--%>
<%--                            <td align="center">
                                <%#Eval("User005")%>
                            </td>--%>
                            <td align="center">
                                <%#Eval("NiceName")%>
                            </td>
                            <td align="center">
                                <%#Eval("BonusAccount")%>
                            </td>
                            <td align="center">
                                <%#Eval("Emoney")%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton6" runat="server" CommandName="edit" CommandArgument='<%#Eval("UserID") %>'
                                   class="easyui-linkbutton"     iconcls="icon-ok"  >编辑</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="close" CommandArgument='<%#Eval("UserID") %>'
                                   class="easyui-linkbutton"     iconcls="icon-no"    Visible='<%#Eval("IsLock").ToString()=="0"?true:false %>'>冻结</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="open" CommandArgument='<%#Eval("UserID") %>'
                                   class="easyui-linkbutton"     iconcls="icon-ok"   Visible='<%#Eval("IsLock").ToString()=="1"?true:false %>'>解冻</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton5" runat="server" CommandName="goto" CommandArgument='<%#Eval("UserID") %>'
                                   class="easyui-linkbutton"     iconcls="icon-ok"  >进入前台</asp:LinkButton>
                            </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="15" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库暂无数据显示。</span></div>
                        </td>
                    </tr>
                </table>
                <div class="nextpage cBlack">
                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                        NumericButtonCount="3" PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True"
                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                        SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                        HorizontalAlign="Right" OnPageChanged="AspNetPager2_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
                </div>
            </div>
    </div>
    </form>
</body>
</html>
