<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.admin.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=getParamVarchar("SystemName1")%></title>
<link rel="stylesheet" type="text/css" href="Content/Base.css" />
<link rel="stylesheet" type="text/css" href="Content/themes/default/easyui.css" />
<link rel="stylesheet" type="text/css" href="Content/themes/icon.css" />
<script type="text/javascript" src="Scripts/jquery.js"></script>
<script type="text/javascript" src="Scripts/jquery.easyui.min.js"></script>
<script type="text/javascript" src="../js/cuntom.js"></script>
<script src="Scripts/main-layout.js" type="text/javascript"></script>
<script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body class="easyui-layout"> 
  <!--头部s-->
  <div region="north" style=" overflow:hidden;">
   <div class="index_logo">
     <div class="index_logo_top"></div>
     <div class="index_logo_bottom">
      <p><a href="../manageloginout.aspx">[退出系统]</a></p>
      <p>您的级别：<%=strTrueName %></p>
      <p>欢迎 <span><%=strUserName %></span>登录后台管理</p>
     </div>
   </div>
  </div>
  <!--头部e-->

  <!--导航s-->
   <div region="west" split="true" title="系统菜单" style="width: 200px; padding: 1px;
        overflow: hidden;">
        <div class="easyui-accordion" fit="true" border="false">
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
                    <div title="<%#Eval("menuname") %>" style="padding: 10px; overflow: auto;">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <p>
                                    <a class="h30" href="#" onclick="addTab('<%#Eval("menuname") %>','<%#Eval("URL") %>',<%#Eval("ID") %>)">
                                        <%#Eval("menuname") %></a></p>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>
    </div>
  <!--导航e-->
   
  <!--中间内容s-->
    <div id="main-panel" region="center" style="background: #eee; overflow-y:hidden">
        <div id="tabs" class="easyui-tabs"  fit="true" border="false" >
			<div title="首页" style="padding:20px;overflow:hidden; color:red; " >
				<iframe scrolling="auto" id="ifr我的工作台" frameborder="0" src="zhuye.aspx" style="width: 100%;
                    height: 100%;"></iframe>
			</div>
		</div>
    </div>
    <!--中间内容e-->
  
  <!--版权-->
  <%--<div class="index_footer"> CopyRight@2010-2012 QDCCAP 版权所有AllRirghtReservice </div>--%>
<%-- START right menu --%>
	<div id="mm" class="easyui-menu" style="width:150px;">
		<div id="mm-tabupdate">刷新</div>
		<div class="menu-sep"></div>
		<div id="mm-tabclose">关闭</div>
		<div id="mm-tabcloseall">全部关闭</div>
		<div id="mm-tabcloseother">除此之外全部关闭</div>
		<div class="menu-sep"></div>
		<div id="mm-tabcloseright">当前页右侧全部关闭</div>
		<div id="mm-tabcloseleft">当前页左侧全部关闭</div>
		<div class="menu-sep"></div>
		<div id="mm-exit">退出</div>
	</div>
    <%-- END right menu --%>
</body>
</html>
