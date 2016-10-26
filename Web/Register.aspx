<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.Register" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <%=GetLanguage("registration")%>
    </title>
    <script type="text/javascript" src="JS/jquery-1.7.1.min.js"></script>
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
    <script type="text/javascript">
        $(function () {
            $("#txtUserCode").val(" ");
            $("#txtUserCode").click(function () {
                $(this).val("");
            })
            $("#ddlQuestion").change(function () {
                $("#txtAnswer").val("");
            });
        })

        function hidd() {
            var value;
            var level = document.getElementById("dropLevel");
            //获取选中的城市名称
            for (i = 0; i < level.length; i++) {
                if (level[i].selected == true) {
                    value = level[i].value; //关键点
                }
            }
            if (value > 4) {
                $("#agentArea").show();
            } else {
                $("#agentArea").hide();
            }
            if (value > 1) {
                $("#Shop").show();
                $("#djq").hide();
            } else {
                $("#Shop").hide();
                $("#djq").show();
            }

        }
    </script>
    <style type="text/css">
        .style1 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server" class="stdform">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                    <a href="Login.aspx"><span style="font-size:16px;color:#fff;"><%=GetLanguage("Login")%></span></a>&nbsp;&nbsp;
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
                                    <li><a href="shop/Retail.aspx" target="mainfrom"><%=GetLanguage("ProductList")%></a></li>
                                    <%--产品列表--%>
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
                            <li class="parent"><a><%=GetLanguage("Agent")%></a><%--报单中心--%>
                                <ul style="display: none;">
                                    <li><a href="team/Member.aspx" target="mainfrom"><%=GetLanguage("OpenMembership")%></a></li>
                                    <!--待开通会员-->
                                    <li><a href="team/MemberList.aspx" target="mainfrom"><%=GetLanguage("AvailableMembers")%></a></li>
                                    <!--已开通会员-->
                                </ul>
                            </li>
                        </ul>
                        <p class="footer">Copyright © 2015 CPM. All rights reserved.</p>
                    </div>
                    <!--end of sidebarmenu-->
                </div>
                <div class="right_content">
                    <h6><%=GetLanguage("LoginInformation")%>：</h6>
                    <div class="row-fluid">
                        <div class="span6">
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("MembershipNumber")%><!--会员编号-->：
                                </label>
                                <div class="field">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="boxx" />&nbsp;<asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" class="btn" Width="80px" />&nbsp;&nbsp;
                                    <asp:Button ID="btnValidate" runat="server" OnClick="btnValidate_Click" class="btn" Width="80px" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("ShopPassword")%>：<!--登陆密码-->
                                </label>
                                <div class="field">
                                    <input name="txtPassword" type="password" id="txtPassword" runat="server" class="input_reg"
                                        value="1" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("ConfirmPass")%>：<!--确认密码-->
                                </label>
                                <div class="field">
                                    <input name="txtRegPassword" type="password" id="txtRegPassword" runat="server" class="input_reg"
                                        value="1" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("SecondPassword")%><!--二级密码-->：
                                </label>
                                <div class="field">
                                    <input name="txtSecondPassword" type="password" id="txtSecondPassword" runat="server" class="input_reg"
                                        value="1" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("ConfirmPass")%>：
                                </label>
                                <div class="field">
                                    <input name="txtRegSecondPassword" type="password" id="txtRegSecondPassword" runat="server" class="input_reg"
                                        value="1" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("ThreePassword")%><!--三级密码-->:
                                </label>
                                <div class="field">
                                    <input name="txtThreePassword" type="password" id="txtThreePassword" runat="server" class="input_reg"
                                        value="1" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("ConfirmPass")%>：
                                </label>
                                <div class="field">
                                    <input name="txtRegThreePassword" type="password" id="txtRegThreePassword" runat="server" class="input_reg"
                                        value="1" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <h6><%=GetLanguage("NetworkInformation")%>：</h6>
                    <div class="row-fluid">
                        <div class="span6">
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("MembershipLevels")%>：
                                </label>
                                <div class="field">
                                    <input name="txtLevel" type="text" id="txtLevel" runat="server" class="input_reg" disabled="disabled" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("RegistrationAmount")%>：
                                </label>
                                <div class="field">
                                    <input name="txtRegMoney" type="text" id="txtRegMoney" runat="server" disabled="disabled" class="input_reg1" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("Agent") %>：
                                </label>
                                <div class="field">
                                    <input name="txtAgentCode" type="text" id="txtAgentCode" runat="server" class="input_reg" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("ReferenceNumber")%>：
                                </label>
                                <div class="field">
                                    <input name="txtRecommendCode" type="text" id="txtRecommendCode" runat="server" class="input_reg" />
                                </div>
                            </div>
                            <div class="control-group" style="display: none;">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("Placement")%>：
                                </label>
                                <div class="field">
                                    <input name="txtParentCode" type="text" id="txtParentCode" runat="server" class="input_reg" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <h6><%=GetLanguage("Banking")%>：</h6>
                    <div class="row-fluid">
                        <div class="span6">
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("Depositary") %>：
                                </label>
                                <div class="field">
                                    <asp:DropDownList ID="dropBank" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="dropProvince" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("BankBranch")%>：
                                </label>
                                <div class="field">
                                    <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="input_reg" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("BankAccount")%>：
                                </label>
                                <div class="field">
                                    <input name="txtBankAccount" type="text" id="txtBankAccount" runat="server" class="input_reg" value="" maxlength="19" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("AccountName")%>：
                                </label>
                                <div class="field">
                                    <input name="txtBankAccountUser" type="text" id="txtBankAccountUser" runat="server" class="input_reg" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <h6><%=GetLanguage("Basic")%>：</h6>
                    <div class="row-fluid">
                        <div class="span6">
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("Name")%>：
                                </label>
                                <div class="field">
                                    <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="input_reg" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("IDNumber")%>：
                                </label>
                                <div class="field">
                                    <input name="txtIdenCode" type="text" id="txtIdenCode" runat="server" class="input_reg" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("ContactPhone")%>：
                                </label>
                                <div class="field">
                                    <input name="txtPhoneNum" type="text" id="txtPhoneNum" runat="server" class="input_reg" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("ContactAddress")%>：
                                </label>
                                <div class="field">
                                    <input name="txtAddress" type="text" id="txtAddress" runat="server" class="input_reg" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <%=GetLanguage("QQNumber")%>：
                                </label>
                                <div class="field">
                                    <input name="txtQQnumer" type="text" id="txtQQnumer" runat="server" class="input_reg" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <%=GetLanguage("Email")%>：
                                </label>
                                <div class="field">
                                    <input name="txtEmail" type="text" id="txtEmail" runat="server" class="input_reg" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="action">
                        <asp:Button ID="btnSubmit" runat="server" class="btn" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
