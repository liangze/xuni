<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBaseManager.aspx.cs"
    Inherits="Web.admin.system.DataBaseManager" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>数据库管理</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form2" runat="server" class="box_con">
    <div class="box box_width">
        <div align="left" style="padding-left: 10px;">
            <ul style="width: 650px; float: left; margin: 0 auto; border: 1px solid #ccc; padding: 0px 15px 15px 45px;">
                <li style="float: none; line-height: 25px; color: Black; text-align: left">※ 此操作需在Master数据库添加清除连接的存储过程。如未添加还原备份可能会出问题！<br />
                    &nbsp;&nbsp;&nbsp;执行此操作前，请先关闭前台然后关闭其它网页窗口，断开FTP连接。</li>
                <li style="float: none; line-height: 25px; color: Black; text-align: left">※ 断开针对数据库的远程连接</li>
                <li style="float: none; line-height: 25px; color: Black; text-align: left">※ 提交后，请耐心等待（请不要重复点击上面的按钮），完成时间视网络状况而定。<br />
                    &nbsp;&nbsp;&nbsp;还原备份、请在网站浏览少时进行此操作，执行此操作可能导致网站变慢或不稳定。</li>
            </ul>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div>
                &nbsp;</div>
            <ul style="width: 650px; float: left; margin: 0 auto; border: 1px solid #ccc; padding: 0px 15px 15px 45px;">
                <li>&nbsp;</li>
                <li style="padding-left: 10px;">
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-save"
                        OnClick="btnBak_Click"> 备份数据库 </asp:LinkButton>
                        <%--<asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-save"
                        > 备份数据库 </asp:LinkButton>--%>
                    <asp:LinkButton ID="LinkButton1" Visible="true" runat="server" class="easyui-linkbutton" iconcls="icon-cancel" 
                        OnClick="btnClear_Click" OnClientClick="return confirm('确定要清空测试数据吗?')"> 清空测试数据 </asp:LinkButton>
                        <%--<asp:LinkButton ID="LinkButton3" Visible="true" runat="server" class="easyui-linkbutton" iconcls="icon-cancel" 
                         > 清空测试数据 </asp:LinkButton>--%>
                    <br />
                    <asp:LinkButton ID="btnAd" Visible="false" runat="server" class="easyui-linkbutton" OnClick="btnAd_Click" >今日结算和发放奖金</asp:LinkButton>
                </li>
                <li>&nbsp;</li>
                <li>
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="t1">
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <HeaderTemplate>
                                <tr>
                                    <th align="center">
                                        备份文件
                                    </th>
                                    <th align="center">
                                        备份日期
                                    </th>
                                    <th align="center">
                                        操作
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <%#Eval("name")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("time")%>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="lbtnH" Visible="false" runat="server" class="easyui-linkbutton" iconcls="icon-back"
                                            CommandName="close" CommandArgument='<%#Eval("name") %>'>还原</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnX" runat="server" class="easyui-linkbutton" iconcls="icon-print"
                                            CommandName="open" CommandArgument='<%#Eval("name") %>'>下载</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnB" runat="server" class="easyui-linkbutton" iconcls="icon-no"
                                            CommandArgument='<%# Eval("name") %>' CommandName="que">删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server">
                            <td colspan="3" align="center">
                                暂无备份
                            </td>
                        </tr>
                    </table>
                </li>
                <li>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上一页" ShowInputBox="Never" AlwaysShow="true" NumericButtonCount="3"
                        PageSize="12" HorizontalAlign="Right">
                    </webdiyer:AspNetPager>
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>