<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jiaoyidating.aspx.cs" Inherits="Web.user.licai.jiaoyidating" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        td img {
            display: block;
        }

        .btn {
            background-image: url(images/anniu.jpg);
            background-repeat: no-repeat;
        }

        body, td, th {
            font-size: 12px;
        }

        body {
            background-color: #FFF;
        }
    </style>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Tooltip.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery1.2.js"></script>
    <script type="text/javascript" src="../../js/superValidator.js"></script>
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../../JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../JS/excanvas.js" type="text/javascript"></script>
    <script src="../../JS/jquery.jqChart.min.js" type="text/javascript"></script>
</head>
<body>
    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            $('#pic').jqChart({
                //                title: { text: '股票成交价格/成交量' },
                title: { text: '股票行情图' },
                series: [
                            {
                                type: 'line',
                                //                                data:[['0.1', 5310], ['0.1', 320], ['0.1', 29250]],
                                data: <%=DynamicData %>,
                                title: '开盘价'
                            },{
                                type: 'line',
                                //                                data:[['0.1', 5310], ['0.1', 320], ['0.1', 29250]],
                                data: <%=Days %>,
                                title: '成交量'
                            }
                ]
            });
            $('#Div1').jqChart({
                title: { text: '股票成交价格/成交量' },
                series: [
                            {
                                type: 'line',
                                //                                data:[['0.1', 5310], ['0.1', 320], ['0.1', 29250]],
                                data: <%=BunessData %>,
                                title: '成交量'
                            }
                ]
            });
        });
    </script>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="900" height="500" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="500" height="465">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                                    <tr>
                                        <th>开盘价</th>
                                        <th>现价</th>
                                        <th runat="server" visible="false">交易范围</th>
                                        <th>今日成交</th>
                                    </tr>
                                    <tr>
                                        <td align="center"><%=kpj %></td>
                                        <td align="center">
                                            <asp:Label ID="lbl_amount" runat="server" Text=""></asp:Label></td>
                                        <td align="center" runat="server" visible="false">
                                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                                        <td align="center"><%=cjl %></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="t1">
                                    <tr>
                                        <td>
                                            <div class="box_title ">当天行情</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="220">
                                            <div id="Div1" style="height: 210px; width: 660px;"></div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="t1">
                                    <tr>
                                        <td>
                                            <div class="box_title ">行情图</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="220">
                                            <div id="pic" style="height: 210px; width: 660px;"></div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="box_title ">待交易记录</div>
                                <div class="dataTable">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                                        <tr>
                                            <th>交易时间
                                            </th>
                                            <th>交易类型
                                            </th>
                                            <th>交易数
                                            </th>
                                            <th>交易单价
                                            </th>
                                            <th>总共价值
                                            </th>
                                            <th>操作
                                            </th>
                                        </tr>
                                        <asp:Repeater ID="Repeater3" runat="server"
                                            OnItemCommand="Repeater3_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="center">
                                                        <%#Eval("BusinessTime")%>
                                                    </td>
                                                    <td align="center">
                                                        <%# getType(Convert.ToInt32(Eval("BusinessType")))%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("BusinessAmount")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("BusinessPrice")%>
                                                    </td>
                                                    <td align="center">
                                                        <%#Eval("SumMoney")%>
                                                    </td>
                                                    <td align="center">
                                                        <asp:LinkButton ID="lbtnOpen" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Open"
                                                            OnClientClick="javascript:return confirm('确定撤单？')">撤单</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr id="tr3" runat="server">
                                            <td colspan="6" align="center">
                                                <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" />抱歉！目前数据库暂无数据显示。
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="center">
                                                <div class="nextpage cBlack">
                                                    <webdiyer:AspNetPager ID="AspNetPager3" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                                        LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                                        NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                                                        SubmitButtonClass="pagebutton" UrlPaging="false"
                                                        pageindexboxtype="TextBox" showpageindexbox="Always"
                                                        SubmitButtonText="" textafterpageindexbox=" 页"
                                                        textbeforepageindexbox="转到 " OnPageChanged="AspNetPager3_PageChanged">
                                                    </webdiyer:AspNetPager>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="360" height="465" valign="top">
                    <table width="229" height="453" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="146">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table width="90%" height="133" border="1" align="center" cellpadding="0" cellspacing="0" class="t1">
                                            <th align="center" colspan="2">买入
                                            </th>
                                            <tr>
                                                <td align="center">购买股票数</td>
                                                <td align="center">
                                                    <asp:TextBox ID="txt_num1" runat="server" Width="70px"
                                                        AutoPostBack="True" OnTextChanged="txt_num1_TextChanged"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="center">买入单价</td>
                                                <td align="center">
                                                    <asp:TextBox ID="txt_amount1" runat="server" Width="70px"
                                                        AutoPostBack="True" OnTextChanged="txt_amount1_TextChanged"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="center">总共价值</td>
                                                <td align="center">
                                                    <asp:TextBox ID="txt_allamount1" runat="server" Width="70px" Enabled="False"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:Button ID="bt_in" runat="server" Text="提交"
                                                        OnClick="bt_in_Click" /><span style="color: Red;"><asp:Label ID="lbl_mairumsg" runat="server"
                                                            Text=""></asp:Label></span></td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td height="146">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <table width="90%" height="133" border="1" align="center" cellpadding="0" cellspacing="0" class="t1">
                                            <tr>
                                                <th align="center" colspan="2">卖出 
                                                </th>
                                            </tr>
                                            <tr>
                                                <td align="center">卖出股票数</td>
                                                <td align="center">
                                                    <asp:TextBox ID="txt_num2" runat="server" AutoPostBack="True"
                                                        OnTextChanged="txt_num2_TextChanged" Width="70px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">卖出单价</td>
                                                <td align="center">
                                                    <asp:TextBox ID="txt_amount2" runat="server" AutoPostBack="True"
                                                        OnTextChanged="txt_amount2_TextChanged" Width="70px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">总共价值</td>
                                                <td align="center">
                                                    <asp:TextBox ID="txt_allamount2" runat="server" Enabled="False" Width="70px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:Button ID="bt_out" runat="server" OnClick="bt_out_Click" Text="提交" />
                                                    <span style="color: Red;">
                                                        <asp:Label ID="lbl_maichumsg" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>

                        </tr>
                        <tr>

                            <td height="60">


                                <table width="90%" height="60" border="1" align="center" cellpadding="0" cellspacing="0" class="t1">
                                    <tr>
                                        <th>购买价
                                        </th>
                                        <th align="center">总量
                                        </th>
                                    </tr>
                                    <asp:Repeater ID="Repeater2" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td align="center">
                                                    <%#Eval("price")%>
                                                </td>
                                                <td align="center">
                                                    <%#Eval("num")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr id="tr2" runat="server">
                                        <td colspan="2" align="center">
                                            <span style="color: Red;">暂无数据显示。</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="60">
                                <table width="90%" height="60" border="1" align="center" cellpadding="0" cellspacing="0" class="t1">
                                    <tr>
                                        <th>卖出价
                                        </th>
                                        <th align="center">总量
                                        </th>
                                    </tr>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td align="center">
                                                    <%#Eval("price")%>
                                                </td>
                                                <td align="center">
                                                    <%#Eval("num")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr id="tr1" runat="server">
                                        <td colspan="2" align="center">
                                            <span style="color: Red;">暂无数据显示。</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
