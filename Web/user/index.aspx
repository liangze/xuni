<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.user.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=getParamVarchar("SystemName2")%></title>
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1" name="viewport" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="../css/datepicker.css" />
    <link rel="stylesheet" href="../css/uniform.css" />
    <link rel="stylesheet" href="../css/maruti-style.css" />
    <link rel="stylesheet" href="../css/maruti-media.css" class="skin-color" />
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery.uniform.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../js/maruti.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div id="top"></div>
        <div id="sidebar">
            <a href="#" class="visible-phone"><i class="icon icon-align-center"></i>导航</a>
            <ul class="clearfix">
                <li class="submenu"><a href="JavaScript:;"><span><i class="icon icon-home"></i>账户首页</span></a>
                    <ul>
                        <li><a href="index.aspx">首页</a></li>
                        <li><a href="member/PersonalInfo.aspx" target="mainfrom">会员资料</a></li>
                        <li><a href="member/ModifyPassWord.aspx" target="mainfrom">修改密码</a></li>
                        <li><a href="member/Upgrate.aspx" target="mainfrom">会员升级</a></li>
                    </ul>
                </li>
                <li class="submenu"><a href="JavaScript:;"><span><i class="icon icon-tasks"></i>业务管理</span></a>
                    <ul>
                        <li><a href="../Registers.aspx" target="mainfrom">会员注册</a></li>
                        <%--<li><a href="team/MemberList.aspx" target="mainfrom">我的市场</a></li>--%>
                        <li><a href="team/Member.aspx" target="mainfrom">待开通会员</a></li>
                        <li><a href="team/TableTree.aspx" target="mainfrom">会员列表</a></li>
                       
                       <%if (zhitui.ToString()=="1")%>
                        <%{ %>
                           <li><a href="team/RecommendTree.aspx" target="mainfrom" >直接推荐图</a></li>
                        <% };%>
                     
                       <%if (shuanggui.ToString()=="1")%>
                        <%{ %>
                        <li><a href="team/RecommendTree_1.aspx" target="mainfrom">系谱图</a></li>
                             <% };%>
                        <li><a href="team/Agent.aspx" target="mainfrom">申请报单中心</a></li>
                    </ul>
                </li>
                <li class="submenu"><a href="JavaScript:;"><span><i class="icon icon-list-alt"></i>财务管理</span></a>
                    <ul>
                        <li><a href="finance/Bonus.aspx" target="mainfrom">奖金明细</a></li>
                        <li><a href="finance/dl_JournalAccount.aspx" target="mainfrom">个人账户</a></li>
                          <%if (tixian.ToString()=="1")%>
                        <%{ %>
                         <li><a href="finance/TakeMoney.aspx" target="mainfrom">会员提现</a></li>
                           <% };%>
                        <li><a href="finance/TransferToEmoney.aspx" target="mainfrom">转账管理</a></li>
                        <%if (chongzhi.ToString()=="1")%>
                         <%{ %>
                          <li><a href="finance/Remit.aspx" target="mainfrom">充值申请</a></li>
                           <% };%>
                    </ul>
                </li>
                <li class="submenu"><a href="JavaScript:;"><span><i class="icon icon-briefcase"></i>交易管理</span></a>
                    <ul>
                        <%--<li><a href="Cash/TradingFloor.aspx" target="mainfrom">交易大厅</a></li>--%>
                        <li><a href="Stock/StockBuyList.aspx" target="mainfrom">交易大厅</a></li>
                       <%-- <li><a href="Cash/CashOrderList.aspx" target="mainfrom">我的订单</a></li>--%>
                        <%--<li><a href="Stock/StockBuyList.aspx" target="mainfrom">走势图</a></li>--%>
                        <li><a href="Cash/CashbuyList.aspx" target="mainfrom">已购列表</a></li>
                        <li><a href="Cash/CashsellList.aspx" target="mainfrom">已卖列表</a></li>
                       <%-- <li><a href="Stock/StockorderList.aspx" target="mainfrom">我的订单</a></li>--%>
                    </ul>
                </li>
                <li class="submenu"><a href="JavaScript:;"><span><i class="icon icon-shopping-cart"></i>购物管理</span></a>
                    <ul>
                        <li><a href="shop/Retail.aspx" target="mainfrom">商城购物</a></li>
                        <li><a href="product/Address.aspx" target="mainfrom">地址管理</a></li>
                        <li><a href="shop/order.aspx" target="mainfrom">我的订单</a></li>
                    </ul>
                </li>
                <li class="submenu"><a href="JavaScript:;"><span><i class="icon icon-file"></i>新闻公告</span></a>
                    <ul>
                        <li><a href="member/NoticeList.aspx" target="mainfrom">新闻中心</a></li>
                        <li><a href="member/QQService.aspx" target="mainfrom">公司客服</a></li>
                    </ul>
                </li>
                <li class="submenu"><a href="JavaScript:;"><span><i class="icon icon-edit"></i>信息管理</span></a>
                    <ul>
                        <li><a href="member/Leavewords.aspx" target="mainfrom">我要留言</a></li>
                        <li><a href="member/LeaveMsg.aspx" target="mainfrom">收取邮件</a></li>
                    </ul>
                </li>
                <li><a href="../loginout.aspx" onclick="javascript:return confirm('确定退出吗？')"><span><i class="icon icon-off"></i>退出</span></a></li>
            </ul>
        </div>

        <div id="content-header">
            <div id="breadcrumb">
                <div class="breadcrumb-content"><a href="index.aspx" title="返回首页" class="tip-bottom">账户首页</a></div>
            </div>
        </div>
        <div id="content">
            <iframe name="mainfrom" id="mainfrom" marginwidth="0" marginheight="0" src="<%=strUrl%>"
                onload="this.height=mainfrom.document.body.scrollHeight < 560 ? 675 : mainfrom.document.body.scrollHeight;"
                frameborder="0" width="100%" scrolling="auto"></iframe>
        </div>
        <div class="row-fluid">
            <div id="footer" class="span12">Copyright © 2016 All Rights Reserved</div>
        </div>

    </form>
</body>
</html>
