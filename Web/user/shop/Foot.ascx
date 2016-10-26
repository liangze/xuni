<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Foot.ascx.cs" Inherits="Web.user.shop.Foot" %>
<div id="Footer">
<div class="w footer-icon">
    <div class="order Left">
      <div class="orderInput">
        <input type="text" class="email" id="JS_subscribe" value="请输入您的电子邮箱" onfocus="if(this.value=='请输入您的电子邮箱')this.value=''" onblur="if(this.value=='')this.value='请输入您的电子邮箱'">
      </div>
      <a href="javascript:void(0);" title="订阅" class="orderBtn" onclick="subscribe();">订阅</a> </div>
    <div class="iconMap Right"><a><img class="ic1" src="images/blank.gif" width="149" height="30" alt=""></a>
        <a><img class="ic2" src="images/blank.gif" width="149" height="30" alt=""></a>
        <a><img class="ic3" src="images/blank.gif" width="149" height="30" alt=""></a>
        <a><img class="ic4" src="images/blank.gif" width="149" height="30" alt=""></a>
        <a><img class="ic5" src="images/blank.gif" width="149" height="30" alt=""></a>
	</div>
  </div>
    <div class="w footer-copy"> 
    <a href="http://vip.zshshop.cn" target="_blank">下载中心</a> |<a href="#">客服中心</a> | <a href="#">网站地图 </a> <a href="http://vip.zshshop.cn" target="_blank">客户系统</a>    
  <br>
    © 2010-<%=DateTime.Now.Year %>  MDD易购商城 版权所有，并保留所有权利。<br>
	<br>
	</div>
</div>