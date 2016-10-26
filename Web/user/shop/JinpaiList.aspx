<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JinpaiList.aspx.cs" Inherits="Web.user.shop.JinpaiList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>竞拍记录</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" class="box_con" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class="capositon">
        <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("ShopManagement")%>>><a href="javascript:void(0)"><%=GetLanguage("AuctionRecords")%></a>
            <!--竞拍记录-->
        </div>
            <div class="dataTable">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <tr>
                <th>
                    <%=GetLanguage("MembershipNumber")%><!--会员编号-->
                </th>
                <th>
                    <%=GetLanguage("AuctionGoods")%><!--竞拍商品-->
                </th>
                <th>
                    <%=GetLanguage("Time")%><!--时间-->
                </th>
                <th>
                    <%=GetLanguage("BidPrice")%><!--竞拍价-->
                </th>
                <th>
                     <%=GetLanguage("State")%><!--状态-->
                </th>
            </tr>
            <asp:Repeater ID="rptProduct" runat="server">
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <%#Eval("UserCode").ToString() == "" ? "&nbsp" : Eval("UserCode")%>
                        </td>
                        <td align="center">
                            <%#getstring(cnen,Eval("SaPrName").ToString() + "-" + Eval("SaPrName").ToString(),15)%>
                        </td>
                        <td align="center">
                            <%#Eval("SaAddTime")%>
                        </td>
                        <td align="center">
                            <%#Eval("SaPrUsually")%>
                        </td>
                        <td align="center">
                            <%#getStatus(Eval("SaState").ToString(), Eval("SaBeginTime").ToString())%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr align="center" runat="server" id="tr1">
                <td colspan="10" style="border: 0">
                    <div>
                        <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></div>
                </td>
            </tr>
        </table>
        <div class="yellow">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True" InputBoxClass="pageinput"
                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                SubmitButtonText="" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
    </div>
    </div>
    </form>
</body>
</html>