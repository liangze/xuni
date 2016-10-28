<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.user._default" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=getParamVarchar("SystemName2")%></title>
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
        <div class="container-fluid">
            <!--content start-->
            <div class="row-fluid">
                <div class="span12 clearfix subMId">
                    <div class="subMIdBlock fl">
                        <div class="subMIdTxt">
                            <div class="subMidTop_1">
                                <img src="../img/ico_user_white.png" />
                            </div>
                            <div class="subMidInfo subMidColor">
                                <dl>
                                    <dd>姓名：<%=LoginUser.TrueName%></dd>
                                    <dd>帐号：<%=LoginUser.UserCode%></dd>
                                    <dd>投资级别：<%=levelBLL.GetLevelName(LoginUser.LevelID)%></dd>
                                </dl>
                            </div>
                        </div>
                    </div>
                    <div class="subMIdBlock fl">
                        <div class="subMIdTxt">
                            <p><i class="fa fa-user"></i></p>
                            <p><span>注册积分</span></p>
                            <p><a href="goldcoin01.aspx" style="color:white"><b><%=LoginUser.Emoney%></b></a></></p>
                        </div>
                    </div>
                    <div class="subMIdBlock fl">
                        <div class="subMIdTxt">
                            <p><i class="fa fa-credit-card"></i></p>
                            <p><span>电子积分</span></p>
                            <p><a href="goldcoin02.aspx" style="color:white"><b><%=LoginUser.AllBonusAccount%></b></a></p>
                        </div>
                    </div>
                    <div class="subMIdBlock fl">
                        <div class="subMIdTxt">
                            <p><i class="fa fa-cloud"></i></p>
                            <p><span>云商积分</span></p>
                            <p><a href="goldcoin03.aspx" style="color:white"><b><%=LoginUser.StockAccount%></b></a></p>
                        </div>
                    </div>
                    <div class="subMIdBlock fl">
                        <div class="subMIdTxt">
                            <p><i class="fa fa-tags"></i></p>
                            <p><span>消费积分</span></p>
                            <p><a href="goldcoin04.aspx" style="color:white"><b><%=LoginUser.ShopAccount%></b></a></p>
                        </div>
                    </div>
                    <div class="subMIdBlock fl">
                        <div class="subMIdTxt">
                            <p><i class="fa fa-database"></i></p>
                            <p><span>奖金积分</span></p>
                            <p><a href="goldcoin05.aspx" style="color:white"><b><%=LoginUser.BonusAccount%></b></a></p>
                        </div>
                    </div>
                    <div class="subMIdBlock fl">
                        <div class="subMIdTxt">
                            <p><i class="fa fa-leanpub"></i></p>
                            <p><span>感恩积分</span></p>
                            <p><a href="goldcoin06.aspx" style="color:white"><b><%=LoginUser.StockMoney%></b></a></p>
                        </div>
                    </div>
                    <div class="subMIdBlock fl">
                        <div class="subMIdTxt">
                            <p><i class="fa fa-shopping-cart"></i></p>
                            <p><span>购物积分</span></p>
                            <p><a href="goldcoin07.aspx" style="color:white"><b><%=LoginUser.GLmoney%></b></a></p>
                        </div>
                    </div>
                    <div class="subMIdBlock fl">
                        <div class="subMIdTxt">
                            <p><i class="fa fa-money"></i></p>
                            <p><span>爱心基金</span></p>
                            <p><a href="goldcoin08.aspx" style="color:white"><b></b><%=LoginUser.User011%></a></p>
                        </div>
                    </div>
                    <div class="subMIdBlock fl">
                        <div class="subMIdTxt">
                            <p><i class="fa fa-cloud"></i></p>
                            <p><span>云购积分</span></p>
                            <p><a href="goldcoin09.aspx" style="color:white"><b><%=LoginUser.User012%></b></a></p>
                        </div>
                    </div>
                </div>
            </div>
            <h4>新闻中心</h4>
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-content nopadding">
                            <div id="DataTables_Table_0_wrapper" class="dataTables_wrapper" role="grid">
                                <div class=""></div>
                                <table class="table table-bordered data-table dataTable" id="DataTables_Table_0">
                                    <thead>
                                        <tr role="row">
                                            <th class="ui-state-default" style="width: 150px;">
                                                <div class="DataTables_sort_wrapper">序号<span class="DataTables_sort_icon css_right ui-icon ui-icon-triangle-1-n"></span></div>
                                            </th>
                                            <th class="ui-state-default">
                                                <div class="DataTables_sort_wrapper">标题<span class="DataTables_sort_icon css_right ui-icon ui-icon-carat-2-n-s"></span></div>
                                            </th>
                                            <th class="ui-state-default" style="width: 430px;">
                                                <div class="DataTables_sort_wrapper">时间<span class="DataTables_sort_icon css_right ui-icon ui-icon-carat-2-n-s"></span></div>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                    <td align="center">
                                                        <%# this.Repeater1.Items.Count + 1%> 
                                                    </td>
                                                    <td align="left">
                                                        <a href="member/NoticeDetail.aspx?ID=<%#Eval("ID") %>" style="color: Red;">» <%# getstring(Language,Eval("NewsTitle").ToString(),18)%></a>
                                                    </td>
                                                    <td align="center">
                                                        <%#Convert.ToDateTime(Eval("PublishTime")).ToString("")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                    <tr id="tr1" runat="server">
                                        <td colspan="3" align="center">
                                            <div class="NoData">
                                                <span class="cBlack">
                                                    <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                                            </div>
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </div>

                    </div>
                    <div class="yellow">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="5" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" Direction="LeftToRight"
                            OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
            <!--content over-->
        </div>

    </form>
</body>
</html>
