<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentList.aspx.cs" Inherits="Web.admin.business.AgentList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <form id="form1" runat="server">
    <div class="operation">
        <%--<asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search"  PostBackUrl="Agent.aspx"> 待开通服务中心 </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search"  PostBackUrl="AgentList.aspx"  > 已开通服务中心 </asp:LinkButton>
    </div>--%>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>
                会员编号：<input name="Add_sscFd7" id="txtUserCode" tip="输入会员编号" class="input_select" runat="server" type="text" />
                &nbsp;
                会员姓名：<input name="Add_sscFd7" id="txtTrueName" tip="输入会员姓名" class="input_select" runat="server" type="text" />
                &nbsp;
                会员级别：<asp:DropDownList runat="server" ID="dropLevel"></asp:DropDownList>
                <br />
                开通日期：<asp:TextBox ID="textStar" tip="输入开通日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                至<asp:TextBox ID="textEnd" tip="输入开通日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                &nbsp;
                <asp:LinkButton ID="LinkButton5" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="btnSearch2_Click"> 搜 索 </asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-search" 
                    OnClick="LinkButton1_Click" OnClientClick="return confirm('确定要导出数据吗?')"> 导 出 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        代理中心编号
                    </th>
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
                        代理区域
                    </th>
                    <th align="center">
                        申请日期
                    </th>
                    <th align="center">
                        确认日期
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand" OnItemDataBound="Repeater2_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%# Eval("AgentCode")%>
                            </td>
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
                                <asp:Literal runat="server" ID="ltlArea"></asp:Literal>
                            </td>
                            <td align="center">
                                <%#Eval("AppliTime")%>
                            </td>
                            <td align="center">
                                <%#Eval("OpenTime")%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="close" CommandArgument='<%#Eval("ID") %>'
                                    class="easyui-linkbutton" iconcls="icon-no" Visible='<%#Eval("Flag").ToString()=="1"?true:false %>'>冻结</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="open" CommandArgument='<%#Eval("ID") %>'
                                    class="easyui-linkbutton" iconcls="icon-ok" Visible='<%#Eval("Flag").ToString()=="2"?true:false %>'>解冻</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("ID") %>'
                                    class="easyui-linkbutton" iconcls="icon-search" CommandName="list">会员列表</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="11" align="center">
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
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                    HorizontalAlign="Right" OnPageChanged="AspNetPager2_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
