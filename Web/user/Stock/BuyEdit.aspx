<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyEdit.aspx.cs" Inherits="Web.user.Stock.BuyEdit" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
    <script src="../../JS/ValidateData.js" type="text/javascript"></script>
    <link href="../../style/index.css" rel="stylesheet" type="text/css" />
    <link href="../../style/style.css" rel="stylesheet" type="text/css" />
    <link href="../../style/ny.css" rel="stylesheet" type="text/css" />
</head>
<script language="javascript" type="text/javascript">

    function CheckData() {
        var strBuyNum = document.getElementById("txtBuy").value;

        if (Trim(strBuyNum) == "" || Trim(strBuyNum) == "0") {
            alert("请输入现在购买的金额！");
            return false;
        }
    }
</script>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="main">
            <!--左侧菜单 star-->
            <div class="left">
                <div class="menu_t">股份交易</div>
                <div class="menu_x">
                    <ul>
                        <li><a href="BuyEdit.aspx" target="fMain" class="cur2">购买股份</a></li>
                        <%--<li><a href="BuyList.aspx" target="fMain">购买列表</a></li>--%>
                        <%--<li><a href="SellEdit.aspx" target="fMain">出售股份</a></li>
                        <li><a href="SellList.aspx" target="fMain">已售股份</a></li>--%>
                    </ul>
                </div>
            </div>
            <!--左侧菜单 end-->
            <div class="right">
                <div class="title">
                    <span>当前位置：<a href="../default.aspx" class="hui">首页</a> &gt; 股份交易</span><h2></h2>
                </div>
                <div class="right_nr">

        <div class="box box_width">
            <div class="capositon">
                <%=GetLanguage("CurrentPosition")%>：股份交易>><a href="javascript:void(0)">购买股份</a>
            </div>
            <div class="dataTable" align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>
                            股份类型
                        </th>
                        <th>
                            交易价格
                        </th>
                        <th>
                            股份总量
                        </th>
                        <th>
                            股份剩余
                        </th>
                        <th>
                            购买数量
                        </th>
                        <th>
                            状态
                        </th>
                        <th>
                            &nbsp;
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand" OnItemDataBound="Repeater2_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("ModeName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Price")%>
                                </td>
                                <td align="center">
                                    <%#Eval("TotalQuantity")%>
                                </td>
                                <td align="center">
                                    <%#Eval("sm001")%>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtbuyNum" CssClass="input_select"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltStatus" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnBuy" runat="server" class="btn" CommandName="buy" Visible='<%#Eval("Status").ToString() == "1" ? true : false%>'
                                        CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('确认购买吗？')">购买</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr2" runat="server">
                        <td colspan="6">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                    <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">购买股份</legend>
                    已购股份：<input name="txtAmount" type="text" id="txtAmount" runat="server" disabled="disabled" class=" input_select" />份
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    现有金额：<input name="txtEmoney" type="text" id="txtEmoney" runat="server" disabled="disabled" class=" input_select" />元
                    <br />
                    现在购买：<asp:TextBox runat="server" ID="txtBuy" CssClass="input_select" onkeydown="if(event.keyCode==13) event.keyCode=9" 
                        onKeyPress="if (!((event.keyCode>=48 && event.keyCode<=57) || (event.keyCode>=96 && event.keyCode<=105))) event.returnValue=false;"></asp:TextBox>份
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    当前价格：<input type="text" runat="server" id="txtPrice" disabled="disabled" class=" input_select"/>元
                    <%--所需金额：<input type="text" runat="server" id="txtNeedMoney" disabled="disabled" class=" input_select"/>元--%>
                    <br />
                    交易密码：<asp:TextBox runat="server" ID="txtAnswer" Text="" TextMode="Password" class="input_select"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Style="margin: 0px;" Text="提 交" class="btn" OnClick="btnSubmit_Click" OnClientClick="return confirm('确认购买吗？')" />
                    <asp:Literal ID="ltReminder" runat="server"></asp:Literal>
                </fieldset>
            </div>
            <div class="operation">
                <fieldset class="fieldset">
                    <%--<legend class="legSearch">股份购买审核</legend>审核状态：<asp:DropDownList ID="dropBuy" runat="server">
                        <asp:ListItem Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="1">未审</asp:ListItem>
                        <asp:ListItem Value="2">已审</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;--%>
                    购买日期：<asp:TextBox ID="txtStart" tip="输入购买日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                    &nbsp;至&nbsp;
                    <asp:TextBox ID="txtEnd" tip="输入购买日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Style="margin: 0px;" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
                </fieldset>
            </div>
            <div class="dataTable" align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>
                            购买数量
                        </th>
                        <th>
                            金额
                        </th>
                        <th>
                            购买方式
                        </th>
                        <th>
                            购买时间
                        </th>
                        <th>
                            状态
                        </th>
                        <%--<th align="center">
                            操作
                        </th>--%>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("BuyQuantity")%>
                                </td>
                                <td align="center">
                                    <%#Eval("sb002")%>
                                </td>
                                <td align="center">
                                    <%#Eval("sb003")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BuyTime")%>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltStatus" runat="server"></asp:Literal>
                                </td>
                                <%--<td align="center">
                                    <asp:LinkButton ID="lbtnCancel" runat="server" class="btn" CommandName="change" Visible='<%#Eval("S").ToString() == "0" ? true : false%>'
                                        CommandArgument='<%#Eval("StockBuyID")%>' OnClientClick="return confirm('确认取消购买吗？')">取消购买</asp:LinkButton>
                                </td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="5">
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
        </div>

                    </div>
                </div>
            </div>
    </form>
</body>
</html>
