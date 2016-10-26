<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManage.aspx.cs" Inherits="Web.admin.system.AdminManage" %>

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
<script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
         <a class="easyui-linkbutton"  iconcls="icon-add" href="AdminEdit.aspx" >添加管理员</a>
    <%-- <asp:Button ID="btnAdd" runat="server" Text="添加管理员" 
          onclick="btnAdd_Click" />--%>
                        <div class="dataTable">
          <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
          <tr>
              <th>管理员编号</th>
              <th>姓名</th>
              <th>注册日期</th>
              <th>操作</th>
           </tr>
    <asp:Repeater ID="rpAdmin" runat="server" onitemcommand="rpAdmin_ItemCommand" >
    <ItemTemplate>
          <tr>
          <td align="center"><%#Eval("UserName")%></td>
          <td align="center"><%#Eval("TrueName")%></td>
          <td align="center"><%#Eval("AddDate")%></td>
          <td align="center">
<asp:LinkButton ID="LinkButton1" class="easyui-linkbutton"  iconcls="icon-edit"  runat="server"  Enabled='<%#Eval("ID").ToString()==getLoginID().ToString()?false:true %>'   CommandName="modify" CommandArgument='<%#Eval("ID") %>'>编辑</asp:LinkButton><%--
           <a href="AdminEdit.aspx?id=<%# Eval("ID") %>&d='+Date()" class="easyui-linkbutton" iconcls="icon-edit">编辑</a>--%>
            <asp:LinkButton ID="LinkButton2" class="easyui-linkbutton"  iconcls="icon-remove"  runat="server"  Enabled='<%#Eval("ID").ToString()==getLoginID().ToString()?false:true %>' CommandName="del" CommandArgument='<%#Eval("ID") %>'>删除</asp:LinkButton></td>
        </tr>
          </ItemTemplate>
          </asp:Repeater>
        <tr id="trNull" runat="server">
          <td colspan="4" align="center"><div class="NoData"><span class="cBlack"> <img src="../../images/ico_NoDate.gif" width="16" height="16" /> 抱歉！目前数据库暂无数据。</span></div></td>
        </tr>
      </table>
      </div>
       <div class="nextpage cBlack">
          <webdiyer:AspNetPager ID="anpAdmin" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
             LastPageText="尾页" NextPageText="下一页" 
             PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
             PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
             UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
             textafterpageindexbox=" 页" textbeforepageindexbox="转到 " 
             onpagechanged="AspNetPager1_PageChanged" HorizontalAlign="Right">
         </webdiyer:AspNetPager>
    </div>
    </form>
</body>
</html>
