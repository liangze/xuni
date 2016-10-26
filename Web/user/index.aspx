<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.user.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=getParamVarchar("SystemName2")%></title>
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1" name="viewport" />
    <link href="../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/footable.core.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.ui.all.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/ui.fancytree.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.orgchart.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.steps.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.bxslider.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../static/js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../static/js/footable.js"></script>
    <script type="text/javascript" src="../static/js/footable.paginate.js"></script>
    <script type="text/javascript" src="../static/js/footable.sort.js"></script>
    <script type="text/javascript" src="../static/js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../static/js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../static/js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript" src="../static/js/jquery.fancytree.js"></script>
    <script type="text/javascript" src="../static/js/jquery.orgchart.js"></script>
    <script type="text/javascript" src="../static/js/jquery.steps.min.js"></script>
    <script type="text/javascript" src="../static/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../static/js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="../static/js/jquery.bxslider.min.js"></script>
    <script type="text/javascript" src="../static/js/jquery.idTabs.min.js"></script>
    <script type="text/javascript" src="../static/js/functions.js"></script>
    <script type="text/javascript">
        var _root = '';
    </script>

    <style type="text/css">
        .fancybox-margin {
            margin-right: 17px;
        }
    </style>
    <style type="text/css">
        .fancybox-margin {
            margin-right: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main_container">
            <div class="header clearfix">
                <div class="logo">
                    <a href="index.aspx">
                        <img alt="" src="../images/dlogo1.png" width="270px" height="104px" /></a>
                </div>
                <!--end of logo-->
                <div class="menu">
                    <ul>
                        <li><a class="toggle_menu">
                            <img alt="" src="static/img/ico_menu.png" />
                            Menu</a></li>
                        <li><a class="toggle_setting">
                            <img alt="" src="static/img/ico_setting.png" />
                            Setting</a></li>
                    </ul>
                </div>
                <!--end of menu-->
                <div class="right_header">
                    <ul>
                        <li class="parent"><a href="javascript:void(0);">
                            <img alt="" src="../static/img/ico_user.png" /><%=LoginUser.UserCode%></a>
                            <ul>
                                <li><a href="member/PersonalInfo.aspx" target="mainfrom"><%=GetLanguage("MemberInformation")%><!--会员资料--></a></li>
                                <li><a href="member/ModifyPassWord.aspx" target="mainfrom"><%=GetLanguage("ModifyPassword")%><!--修改密码--></a></li>
                                <%if (currentCulture == "en-us")
                                  {%>
                                <li><a href="../loginout.aspx" onclick="javascript:return confirm('Are you sure to exit?')" style="width: 120px;"><%=GetLanguage("Exit")%></a></li>
                                <%}
                                  else
                                  {%>
                                <li><a href="../loginout.aspx" onclick="javascript:return confirm('确定退出吗？')" style="width: 120px;"><%=GetLanguage("Exit")%></a></li>
                                <%} %>
                            </ul>
                        </li>
                    </ul>
                </div>
                <!--end of right header-->
            </div>
            <div class="center_content">
                <div class="left_content">
                    <div class="sidebarmenu">
                        <ul>
                            <li class="parent"><a class="active"><%=GetLanguage("UserCenter")%></a><%--用户中心--%>
                                <ul style="display: block;">
                                    <li><a href="index.aspx"><%=GetLanguage("index")%></a></li>
                                    <%--首页--%>
                                    <li><a href="member/PersonalInfo.aspx" target="mainfrom"><%=GetLanguage("MemberInformation")%></a></li>
                                    <!--会员资料-->
                                    <li><a href="member/ModifyPassWord.aspx" target="mainfrom"><%=GetLanguage("ModifyPassword")%></a></li>
                                    <!--修改密码-->
                                    <li><a href="member/Recast.aspx" target="mainfrom"><%=GetLanguage("Recast")%></a></li>
                                    <%--账号复投--%>
                                </ul>
                            </li>
                            <li class="parent"><a><%=GetLanguage("AccountManagement")%></a><%--帐号管理--%>
                                <ul style="display: none;">
                                    <li><a href="../Registers.aspx" target="mainfrom"><%=GetLanguage("Register")%></a></li>
                                    <%--会员注册--%>
                                    <li><a href="team/MemberList.aspx" target="mainfrom"><%=GetLanguage("MyMarket")%></a></li>
                                    <%--我的市场--%>
                                    <li><a href="team/TableTree.aspx" target="mainfrom"><%=GetLanguage("MemberList")%></a></li>
                                    <%--会员列表--%>
                                    <li><a href="team/RecommendTree.aspx" target="mainfrom"><%=GetLanguage("ThisFigure")%></a></li>
                                    <%--直接推荐图--%>
                                    <li><a href="team/Agent.aspx" target="mainfrom"><%=GetLanguage("ApplyCentre")%></a></li>
                                    <!--申请报单中心-->
                                </ul>
                            </li>
                            <li class="parent"><a><%=GetLanguage("FinanceCenter")%></a><%--财务中心--%>
                                <ul style="display: none;">
                                    <li><a href="finance/Bonus.aspx" target="mainfrom"><%=GetLanguage("BonusDetails")%></a></li>
                                    <%--奖金明细--%>
                                    <li><a href="finance/dl_JournalAccount.aspx" target="mainfrom"><%=GetLanguage("PersonalAccount")%></a></li>
                                    <%--个人账户--%>
                                    <li><a href="finance/TakeMoney.aspx" target="mainfrom"><%=GetLanguage("MembershipWithdrawal")%></a></li>
                                    <%--会员提现--%>
                                    <li><a href="finance/TransferToEmoney.aspx" target="mainfrom"><%=GetLanguage("TransferManagement")%></a></li>
                                    <%--转账管理--%>
                                    <%--<li><a href="finance/Remit.aspx" target="mainfrom"><%=GetLanguage("Rechargemanagement")%></a></li>--%>
                                    <%--汇款管理--%>
                                </ul>
                            </li>
                            <li class="parent"><a><%=GetLanguage("TradingHall")%></a><%--流通币交易大厅--%>
                                <ul style="display: none;">
                                    <li><a href="Cash/TradingFloor.aspx" target="mainfrom"><%=GetLanguage("TradingFloor")%></a></li>
                                    <%--交易大厅--%>
                                    <li><a href="Cash/CashOrderList.aspx" target="mainfrom"><%=GetLanguage("MyOrder")%></a></li>
                                    <%--我的订单--%>
                                </ul>
                            </li>
                            <li class="parent"><a><%=GetLanguage("MDDGoldTrading")%></a><%--MDD金币交易--%>
                                <ul style="display: none;">
                                    <li><a href="Stock/StockBuyList.aspx" target="mainfrom"><%=GetLanguage("MDDGoldFutures")%></a></li>
                                    <%--MDD金币预购--%>
                                    <li><a href="Stock/BuyList.aspx" target="mainfrom"><%=GetLanguage("PurchaseList")%></a></li>
                                    <%--已购列表--%>
                                    <li><a href="Stock/SellList.aspx" target="mainfrom"><%=GetLanguage("SoldList")%></a></li>
                                    <%--已卖列表--%>
                                    <li><a href="Stock/StockorderList.aspx" target="mainfrom"><%=GetLanguage("MyOrder")%></a></li>
                                    <%--我的订单--%>
                                </ul>
                            </li>
                            <li class="parent"><a><%=GetLanguage("ShoppingManagement")%></a><%--购物管理--%>
                                <ul style="display: none;">
                                    <li><a href="shop/Default.aspx" target="_blank"><%=GetLanguage("ShoppingMall")%></a></li>
                                    <%--商城购物--%>
                                    <li><a href="product/Address.aspx" target="mainfrom"><%=GetLanguage("AddressManage")%></a></li>
                                    <%--AddressManage--%>
                                    <li><a href="shop/order.aspx" target="mainfrom"><%=GetLanguage("MyOrder")%></a></li>
                                    <!--我的订单-->
                                </ul>
                            </li>
                            <li class="parent"><a><%=GetLanguage("InformationManaget")%></a><%--信息管理--%>
                                <ul style="display: none;">
                                    <li><a href="member/NoticeList.aspx" target="mainfrom"><%=GetLanguage("NewsInformation")%></a></li>
                                    <%--新闻公告--%>
                                    <li><a href="member/Leavewords.aspx" target="mainfrom"><%=GetLanguage("Sendmail")%></a></li>
                                    <%--发送邮件--%>
                                    <li><a href="member/LeaveMsg.aspx" target="mainfrom"><%=GetLanguage("Receivemail")%></a></li>
                                    <%--收取邮件--%>
                                    <li><a href="member/LeaveOut.aspx" target="mainfrom"><%=GetLanguage("HaveEmail")%></a></li>
                                    <%--已发信件--%>
                                    <li><a href="member/QQService.aspx" target="mainfrom"><%=GetLanguage("Customer")%></a></li>
                                    <%--公司客服--%>
                                </ul>
                            </li>
                            <%if (LoginUser.IsAgent == 1)
                            {%>
                            <li class="parent"><a><%=GetLanguage("Agent")%></a><%--报单中心--%>
                                <ul style="display: none;">
                                    <li><a href="team/Member.aspx" target="mainfrom"><%=GetLanguage("OpenMembership")%></a></li>
                                    <!--待开通会员-->
                                    <li><a href="team/MemberList.aspx" target="mainfrom"><%=GetLanguage("AvailableMembers")%></a></li>
                                    <!--已开通会员-->
                                </ul>
                            </li>
                            <%} %>
                        </ul>
                        <p class="footer">Copyright © 2015 CPM. All rights reserved.</p>
                    </div>
                    <!--end of sidebarmenu-->
                </div>
                <iframe name="mainfrom" id="mainfrom" marginwidth="0" marginheight="0" src="<%=strUrl%>"
                    onload="this.height=mainfrom.document.body.scrollHeight < 560 ? 675 : mainfrom.document.body.scrollHeight;"
                    frameborder="0" width="100%" scrolling="auto"></iframe>
            </div>
            <!--end of center content-->
        </div>
    </form>
</body>
</html>
