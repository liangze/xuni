<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesDetail.aspx.cs" Inherits="Web.user.shop.SalesDetail" %>

<%@ Register Src="ShopHead.ascx" TagName="ShopHead" TagPrefix="uc1" %>
<%@ Register Src="shopSlider.ascx" TagName="shopSlider" TagPrefix="uc2" %>
<%@ Register Src="Foot.ascx" TagName="Foot" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <%-- <meta http-equiv="X-UA-Compatible" content="IE=7" />--%>
    <title>商品详情</title>
    <link href="../../style/Shop.css" rel="stylesheet" type="text/css" />
    <link href="../../css/shop_indexcss.css" type="text/css" rel="stylesheet" />
    <%--    <script type="text/javascript" charset="utf-8" src="../../js/jquery-1.7.1.min.js"></script>--%>
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var tYear = "";        //输入的年份
            var tMonth = "";    //输入的月份
            var tDate = "";        //输入的日期
            var tHour = "";        //时
            var tMinute = "";     //分
            var tSecond = "";    //秒

            var iRemain = "";    //开始和结束之间相差的毫秒数
            var sDate = "";        //倒计的天数
            var sHour = "";        //倒计时的小时
            var sMin = "";        //倒计时的分钟
            var sSec = "";        //倒计时的秒数
            var sMsec = "";        //毫秒数

            //通用工具函数，在个位数上加零，根据传的N的参数，来设前面加几个零
            function setDig(num, n) {
                var str = "" + num;
                while (str.length < n) {
                    str = "0" + str
                }
                return str;
            }

            //获得相差的天，小时，分钟，秒
            function getdate() {

                //创建开始时间和结束时间的日期对象
                var oStartDate = new Date();
                var oEndDate = new Date();

                //获取文本框的值
                tYear = $("#tyear").val();
                tMonth = $("#tmonth").val();
                tDate = $("#tdate").val();
                tHour = $("#tHour").val();
                tMinute = $("#tMinute").val();
                tSecond = $("#tSecond").val();

                //设置结束时间
                oEndDate.setFullYear(parseInt(tYear));
                oEndDate.setMonth(parseInt(tMonth) - 1);
                oEndDate.setDate(parseInt(tDate));
                oEndDate.setHours(parseInt(tHour));
                oEndDate.setMinutes(parseInt(tMinute));
                oEndDate.setSeconds(parseInt(tSecond));

                //求出开始和结束时间的秒数(除以1000)
                iRemain = (oEndDate.getTime() - oStartDate.getTime()) / 1000;

                //总的秒数除以一天的秒数，再取出整数部分，就得出有多少天。
                sDate = setDig(parseInt(iRemain / (60 * 60 * 24)), 2);
                //总的秒数除以一天的秒数，然后取其中的余数，就是把整数天扣除之后，剩下的总秒数。
                iRemain %= 60 * 60 * 24;

                //剩下的总秒数除以一个小时的秒数，再取整数部分，就是有多少小时。
                sHour = setDig(parseInt(iRemain / (60 * 60)), 2)

                //剩下的总秒数除以一个小时的秒数，再取其余数，这个余数，就是扣除小时这后，剩下的总秒数。
                iRemain %= 60 * 60;

                //剩下的总秒数除以一分钟的秒数，再取其整数部分，就是有多少分钟。
                sMin = setDig(parseInt(iRemain / 60), 2)

                //剩下的总秒数除以一分钟的秒数，再取其余数，这个余数，就是扣除分钟之后，剩下的总秒数。
                iRemain %= 60;

                //剩下的秒数
                sSec = setDig(iRemain, 2);

                //毫秒数
                sMsec = sSec * 100;
            }

            //更改显示的时间
            function updateShow() {
                $(".count span").each(function (index, element) {
                    if (index == 0) {
                        $(this).text(sDate);
                    } else if (index == 1) {
                        $(this).text(sHour);
                    } else if (index == 2) {
                        $(this).text(sMin);
                    } else if (index == 3) {
                        $(this).text(sSec);
                    } 
//                    else if (index == 4) {
//                        $(this).text(sMsec);
//                    }
                });
            }

            //每一秒执行一次时间更新
            function autoTime() {
                getdate();
                //如果小于零，清除调用自己，并且返回
                if (iRemain < 0) {
                    clearTimeout(setT);
                    return;
                }
                updateShow();
                var setT = setTimeout(autoTime, 1000);

            }

            autoTime();
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Header">
        <!--nav begin-->
        <uc1:ShopHead ID="ShopHead1" runat="server" />
        <!--nav end-->
    </div>
    <div class="ShopBody">
        <div class="slider">
            <!--slider begin-->
            <uc2:shopSlider ID="shopSlider1" runat="server" />
            <!--slider end-->
        </div>
        <!--right begin-->
        <div class="rightBox">
            <div style="clear: both;">
                <div class="Product_Search" id="div_no" runat="server" visible="false">
                    <div style="padding-bottom: 25px; line-height: 26px; padding-left: 40px; padding-right: 40px;
                        font-size: 14px; padding-top: 25px">
                        无效的操作!
                    </div>
                </div>
                <div class="Product_Search" id="div_yes" runat="server" visible="false">
                    <div class="product_con">
                        <div class="shopping">
                            <div class="shopping_left">
                                <img id="img1" runat="server" width="300">
                            </div>
                            <div class="shopping_right">
                                <%--<h1>
                                    ￥<asp:Label ID="Label1" runat="server" Text=""></asp:Label></h1>--%>
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="floatRight">
                                            商品名称：
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <%--                                    <tr id="li1" runat="server" visible="false">
                                        <td class="floatRight">
                                            购买数量：
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgbtnCut" runat="server" ImageUrl="../../images/Reduce0.jpg"
                                                Width="11" Height="11" align="absmiddle" OnClick="imgbtnCut_Click" />
                                            <input id="txtNum" runat="server" style="width: 50px;" onkeydown="if(event.keyCode==13)event.keyCode=9;"
                                                value="1" onkeypress="if ((event.keyCode&lt;48 || event.keyCode&gt;57 ) &amp;&amp; event.keyCode!=46) event.returnValue=false;"
                                                type="text" />
                                            <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="../../images/add0.jpg" Width="11"
                                                Height="11" align="absmiddle" OnClick="imgbtnAdd_Click" />
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="floatRight">
                                            市场价：
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>&nbsp;$
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="floatRight">
                                            竞拍价：
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>&nbsp;$
                                        </td>
                                    </tr>
                                    <%if (SaState == 1)
                                      {//未成交 %>
                                    <tr>
                                        <td class="floatRight">
                                            竞拍倒计时：
                                        </td>
                                        <td colspan="2">
                                            <div class="setdate" style="display: none;">
                                                <input type="text" runat="server" name="" id="tyear" />
                                                <input type="text" runat="server" name="" id="tmonth" />
                                                <input type="text" runat="server" name="" id="tdate" />
                                                <input type="text" runat="server" name="" id="tHour" />
                                                <input type="text" runat="server" name="" id="tMinute" />
                                                <input type="text" runat="server" name="" id="tSecond" />
                                            </div>
                                            <div class="count">
                                                <span></span>天<span></span>时<span></span>分<span></span>秒<%--<span></span>毫秒--%>
                                            </div>
                                        </td>
                                    </tr>
                                    <%}
                                      else if (SaState==2)//成交
                                      { %>
                                    <tr>
                                        <td class="floatRight">
                                            成交者：
                                        </td>
                                        <td colspan="2">
                                           <%=UserCode%>&nbsp;
                                        </td>
                                    </tr>
                                   <%} %>
                                    <%--                                    <tr>
                                        <td class="floatRight">
                                            总额：
                                        </td>
                                        <td>
                                                <asp:Label ID="Label8" runat="server" Text=""></asp:Label>&nbsp;$
                                        </td>
                                    </tr>--%>
                                    <%--                                    <tr id="li2" runat="server" visible="false">
                                        <td colspan="2">
                                            <asp:Button ID="btnSubmit" runat="server" Text="" class="buts" OnClick="btnSubmit_Click" />
                                        </td>
                                    </tr>--%>
                                </table>
                                <%--<ul>
                                    <li>商品编号：<span><asp:Label ID="Label4" runat="server" Text=""></asp:Label></span></li>
                                    <li>商品名称：<span><asp:Label ID="Label2" runat="server" Text=""></asp:Label></span></li>
                                    <li>已销售：<span><asp:Label ID="Label5" runat="server" Text=""></asp:Label></span></li>
                                    <li>库存：<span><asp:Label ID="Label3" runat="server" Text=""></asp:Label></span></li>
                                    <li id="li1" runat="server" visible="false">购买数量：<asp:ImageButton ID="imgbtnCut"
                                        runat="server" ImageUrl="../../images/Reduce0.jpg" Width="11" Height="11" align="absmiddle"
                                        OnClick="imgbtnCut_Click" />
                                        <input id="txtNum" runat="server" style="width: 50px;" onkeydown="if(event.keyCode==13)event.keyCode=9;"
                                            value="0" onkeypress="if ((event.keyCode&lt;48 || event.keyCode&gt;57 ) &amp;&amp; event.keyCode!=46) event.returnValue=false;"
                                            type="text" />
                                        <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="../../images/add0.jpg" Width="11"
                                            Height="11" align="absmiddle" OnClick="imgbtnAdd_Click" />
                                    </li>
                                    <li>市场价：<span><asp:Label ID="Label6" runat="server" Text=""></asp:Label></span></li>
                                    <li>会员价：<span><asp:Label ID="Label7" runat="server" Text=""></asp:Label></span></li>
                                    <li>总额：<span><asp:Label ID="Label8" runat="server" Text=""></asp:Label></span></li>
                                    <li id="li2" runat="server" visible="false">
                                        <asp:Button ID="btnSubmit" runat="server" Text="" class="buts" OnClick="btnSubmit_Click" />
                                    </li>
                                </ul>--%>
                            </div>
                            <div style="clear: both; margin-top: 10px">
                            </div>
                        </div>
                    </div>
                    <div class="Product_top">
                        拍品描述</div>
                    <div style="clear: both">
                    </div>
                    <div class="product_con">
                        <div style="word-spacing: 3px; text-indent: 2em; margin-bottom: 10px; text-align: left">
                            <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal></div>
                    </div>
                </div>
            </div>
        </div>
        <!--right end-->
        <uc3:Foot ID="Foot1" runat="server" />
    </form>
</body>
</html>
