<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveOut.aspx.cs" Inherits="Web.admin.system.LeaveOut" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
 <script type="text/javascript" src="../Scripts/Common.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="box_con">
    <div class="box box_width">
        <div class="operation">
            <asp:LinkButton ID="btn_s1" runat="server" class="easyui-linkbutton"   
                iconcls="icon-print" onclick="btn_s1_Click"   > 收件箱 </asp:LinkButton>
            <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                iconcls="icon-print" onclick="LinkButton1_Click"  > 发件箱 </asp:LinkButton>
      </div>
        <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">查询</legend>
                     收件人：
          <input id="textInCode" type="text" runat="server"  tip="输入收件人" class="input_select"/>
            <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                iconcls="icon-search" onclick="btnSendSearch_Click"   > 搜 索 </asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton"   
                iconcls="icon-no" onclick="btnDelSend_Click"    OnClientClick="return confirm('确定删除吗？')"> 删 除 </asp:LinkButton>
            <asp:LinkButton ID="LinkButton4" runat="server" class="easyui-linkbutton"   
                iconcls="icon-print" onclick="btnSendLeave_Click"  > 留 言 </asp:LinkButton>
                </fieldset>
                </div>
        <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr >
          <th width="6%" align="center">
          <asp:CheckBox ID="ckAllSend" runat="server"  AutoPostBack="True" Text="全选" 
                  oncheckedchanged="ckAllSend_CheckedChanged" />
          <th width="12%" align="center"><span class="ico_mail">收件人</span></th>
          <th width="50%" align="center">主题内容</td>
          <th width="18%" align="center"><span class="ico_mailSendTime">发送日期</span></th>
          <th width="14%" align="center"><span class="ico_mailReTime">状态</span></th>
        </tr>
          <asp:Repeater ID="rpSendBox" runat="server">
            <ItemTemplate>
                <tr>
          <td align="center"><input type="checkbox" name="CheckBoxSend" id="CheckBoxSend" value='<%#Eval("ID") %>' runat="server"/></td>
          <td align="center"><%#GetUserCode(Eval("ToUserID").ToString(), Eval("ToUserType").ToString())%></td>
          <td align="center" ><a href="LeaveWordsDetail.aspx?id=<%#Eval("ID") %>&type=2" target="_self"><%#Eval("MsgTitle")%></a></td>
          <td align="center"><%#Convert.ToDateTime(Eval("LeaveTime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
          <td align="center"><%#Eval("IsReply").ToString() == "0" ? "未回复" : "已回复"%></td>
        </tr>
            </ItemTemplate>
          </asp:Repeater>
        <tr id="trSendNull" runat="server">
          <td colspan="5" style="border:0" align="center"><div class="NoData  ico_warning"><img src="../../images/ico_NoDate.gif" width="16" height="16" />抱歉，目前数据库中暂无记录显示！</div></td>
        </tr>
                </table>
                <div class="nextpage cBlack" style=" width:99%;">
                    <webdiyer:AspNetPager ID="anpSendMail" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
             LastPageText="尾页" NextPageText="下一页" OnPageChanged="anpsendMail_PageChanged"
             PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
             PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
             UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
             textafterpageindexbox=" 页" textbeforepageindexbox="转到 " HorizontalAlign="Right">
         </webdiyer:AspNetPager>
                </div>
                </div>
    </div>
    </form>
</body>
</html>
