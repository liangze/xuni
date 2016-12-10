<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockBuyList.aspx.cs" Inherits="Web.user.Stock.StockBuyList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" href="../images/favicon.ico" type="images/x-icon" />
    <link href="../../static/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../static/css/footable.core.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../static/css/jquery.ui.all.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../static/css/ui.fancytree.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../static/css/jquery.orgchart.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../static/css/jquery.steps.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../static/css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../static/css/jquery.bxslider.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../static/css/style1.css" rel="stylesheet" type="text/css" />
    <link href="../../static/css/add.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../../static/js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../../static/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../../static/js/footable.js"></script>
    <script type="text/javascript" src="../../static/js/footable.paginate.js"></script>

    <script type="text/javascript" src="../../static/js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../../static/js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../../static/js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript" src="../../static/js/jquery.fancytree.js"></script>
    <script type="text/javascript" src="../../static/js/jquery.orgchart.js"></script>
    <script type="text/javascript" src="../../static/js/jquery.steps.min.js"></script>
    <script type="text/javascript" src="../../static/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../static/js/jquery.lightbox-0.5.pack.js"></script>
    <script type="text/javascript" src="../../static/js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="../../static/js/jquery.bxslider.min.js"></script>
    <script type="text/javascript" src="../../static/js/jquery.idtabs.min.js"></script>
    <script type="text/javascript" src="../../static/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../static/js/echarts.js"></script>
    <script type="text/javascript" src="../../static/js/functions.js"></script>
    <script type="text/javascript">
        function focusAndSelect(obj) {
            obj.focus();
            obj.select();
        }
    </script>
    <link rel="stylesheet" href="../../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="../../css/datepicker.css" />
    <link rel="stylesheet" href="../../css/uniform.css" />
    <link rel="stylesheet" href="../../css/maruti-style.css" />
    <link rel="stylesheet" href="../../css/maruti-media.css" class="skin-color" />
    <link rel="stylesheet" href="../../css/font-awesome.min.css" />
    <script src="../../JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../JS/echarts/esl.js" type="text/javascript"></script>


</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div id="content">
            <div class="container-fluid">
                <div class="row-fluid">
                    <div class="span12">
                        <h2>走势图
                        </h2>
                        <p />
                        <p></p>
                        <div class="criteriaTable">
                        </div>
                        <br>
                        <!--内容-->
                        <div class="row" style="background-color: black; color: white;">
                            <div class="col-sm-9 boright" style="width: 100%">
                                <div class="main-right">
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-sm-12">
                                            <span>Interval:</span>&nbsp;&nbsp;
                                        <a href="javascript:void(0)" onclick="hiddenput(1)" style="color: green;">5m</a>&nbsp;&nbsp;
                                        <a href="javascript:void(0)" onclick="hiddenput(2)" style="color: green;">15m</a>&nbsp;&nbsp;
                                        <a href="javascript:void(0)" onclick="hiddenput(3)" style="color: red;">30m</a>&nbsp;&nbsp;
                                        <a href="javascript:void(0)" onclick="hiddenput(4)" style="color: red;">1h</a>&nbsp;&nbsp;
                                        <a href="javascript:void(0)" onclick="hiddenput(5)" style="color: white;">1d</a>&nbsp;&nbsp;
                                        <a href="javascript:void(0)" onclick="hiddenput(6)" style="color: white;">1M</a>&nbsp;&nbsp;
                                        </div>
                                        <div class="col-sm-12">
                                            <div style="border: 1px solid #CCCCCA; width: 100%;">
                                                <div id="main1" style="border: 0px solid rgb(204, 204, 202); width: 100%; margin-bottom: 20px; height: 350px; -webkit-tap-highlight-color: transparent; -webkit-user-select: none; position: relative; background-color: rgb(0, 0, 0);" _echarts_instance_="ec_1467333958695">
                                                    <div style="position: relative; overflow: hidden; width: 771px; height: 350px; cursor: default;">
                                                        <canvas width="771" height="350" data-zr-dom-id="zr_0" style="-webkit-user-select: none; -webkit-tap-highlight-color: rgba(0, 0, 0, 0);" class="auto-style1"></canvas>
                                                    </div>
                                                    <div style="position: absolute; display: none; border: 0px solid rgb(51, 51, 51); white-space: nowrap; z-index: 9999999; transition: left 0.4s cubic-bezier(0.23, 1, 0.32, 1), top 0.4s cubic-bezier(0.23, 1, 0.32, 1); border-radius: 4px; color: rgb(255, 255, 255); font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: 'Microsoft YaHei'; line-height: 21px; text-decoration: none; padding: 5px; left: 122.8px; top: 81px; background-color: rgba(50, 50, 50, 0.701961);">
                                                        2016-07-01 08:45:06<br>
                                                        Amount : 36489<br>
                                                        Opening : 0.23  High : 0.23<br>
                                                        Closing : 0.22  Low : 0.21
                                                    </div>
                                                </div>
                                                <div id="main2" style="border: 0px solid rgb(204, 204, 202); width: 100%; margin-bottom: 20px; height: 250px; -webkit-tap-highlight-color: transparent; -webkit-user-select: none; position: relative; background-color: rgb(0, 0, 0);" _echarts_instance_="ec_1467333958696">
                                                    <div style="position: relative; overflow: hidden; width: 771px; height: 250px; cursor: default;">
                                                        <canvas width="771" height="250" data-zr-dom-id="zr_0" style="position: absolute; left: 0px; top: 0px; width: 771px; height: 250px; -webkit-user-select: none; -webkit-tap-highlight-color: rgba(0, 0, 0, 0);"></canvas>
                                                    </div>
                                                    <div style="position: absolute; display: none; border: 0px solid rgb(51, 51, 51); white-space: nowrap; z-index: 9999999; transition: left 0.4s cubic-bezier(0.23, 1, 0.32, 1), top 0.4s cubic-bezier(0.23, 1, 0.32, 1); border-radius: 4px; color: rgb(255, 255, 255); font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Arial, Verdana, sans-serif; line-height: 21px; text-decoration: none; padding: 5px; left: 122.8px; top: 187.412px; background-color: rgba(50, 50, 50, 0.701961);">
                                                        2016-07-01 08:45:06<br>
                                                        <span style="display: inline-block; margin-right: 5px; border-radius: 10px; width: 9px; height: 9px; background-color: #CD0000"></span>Amount : 36,489
                                                    </div>
                                                </div>
                                            </div>

                                            <div id="foot_order" style="height: 30px; text-align: center; display: none;">
                                                <input type="button" class="btn btn-primary" value="停止刷新" onclick="Ecarts.BtnStopRefresh()" />&nbsp;
                                            <input type="button" class="btn btn-primary" value="手动刷新" onclick="Ecarts.BtnHandRefresh()" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>

                        <input type="hidden" runat="server" id="hdmoney" />
                        <input type="hidden" runat="server" id="hdprice" />
                        <!--content start-->
                        
                        <div class="widget-box">
                            <div class="widget-title">
                                <span class="icon"><i class="icon-align-right"></i></span>
                            </div>
                            <div class="widget-content nopadding dataTables_wrapper">
                                <table class="table table-bordered data-table">
                                    <thead>
                                        <tr>
                                            <th style="min-width: 80px">持仓数量</th>
                                            <th style="min-width: 80px">成本价</th>
                                            <th style="min-width: 60px">可卖数量</th>
                                            <th style="min-width: 60px">当前价</th>
                                            <th style="min-width: 80px">市值</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td align="center"><%=LoginUser.StockAccount%></td>
                                            <td align="center"><%=LoginUser.User013%></td>
                                            <td align="center">
                                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label><%--可卖数量--%>

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                                            <td align="center">
                                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="widget-box">
                                    <div class="widget-title" align="center">
                                        <span class="icon">
                                            <i class="icon-align-right"></i>
                                        </span>

                                        <h5 align="center">买入云商积分</h5>

                                    </div>
                                    <div class="widget-content nopadding">
                                        <table class="table table-bordered data-table">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                <ContentTemplate>
                                                    <tbody>
                                                        <tr style="height: 50px;">
                                                            <td style="width: 30.9%; text-align: right;">当前价格：
                                                            <td align="left">
                                                                <asp:Label ID="Label4" class="span5" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 50px;">
                                                            <td style="width: 30.9%; text-align: right;">购买数量：
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtBuyNum" class="span5" runat="server" AutoPostBack="true" OnTextChanged="txtBuyNum_TextChanged1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 50px;">
                                                            <td style="width: 30.9%; text-align: right;">购买总价：
                                                            </td>
                                                            <td align="left">
                                                                <%--<asp:Label ID="Label6" runat="server" Text="" class="span5"></asp:Label>--%>
                                                                <asp:TextBox ID="TextTolPrice" class="span5" runat="server" AutoPostBack="true" OnTextChanged="TextTolPrice_TextChanged"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 50px;">
                                                            <td style="width: 30.9%; text-align: right;">选择支付：
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="dropCurrency" runat="server" class="span5">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 50px;">
                                                            <td style="width: 30.9%; text-align: right;">交易密码：
                                                            </td>
                                                            <td align="left">
                                                                <input runat="server" type="password" class="span5" name="PayPassword" id="PayPassword" value="" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </table>
                                        <div class="form-actions">

                                            <asp:Button ID="btnSubmit" runat="server" Text="确认提交" class="btn btn-success" OnClick="btnSubmit_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="widget-box">
                                    <div class="widget-title">
                                        <span class="icon">
                                            <i class="icon-align-right"></i>
                                        </span>
                                        <h5>卖出云商积分</h5>
                                    </div>
                                    <div class="widget-content nopadding">
                                        <table class="table table-bordered data-table">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                                <ContentTemplate>
                                                    <tbody>
                                                        <tr style="height: 50px;">
                                                            <td style="width: 30.9%; text-align: right;">当前价格：
                                                            <td align="left">
                                                                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 50px;">
                                                            <td style="width: 30.9%; text-align: right;">卖出数量：
                                                            </td>
                                                            <td align="left">
                                                                <%--<input runat="server" type="text" class="span6" name="SellNum" id="SellNum" value="" />--%>
                                                                <asp:TextBox ID="txtSellNum" runat="server" class="span6" AutoPostBack="true" OnTextChanged="txtSellNum_TextChanged"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 50px;">
                                                            <td style="width: 30.9%; text-align: right;">卖出总价：
                                                            </td>
                                                            <td align="left">
                                                               <%-- <asp:Label ID="Label7" runat="server" Text="" class="span5"></asp:Label>--%>
                                                                <asp:TextBox ID="TextStoalPri" runat="server" class="span6" AutoPostBack="true" OnTextChanged="TextStoalPri_TextChanged"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr style="height: 50px;">
                                                            <td style="width: 30.9%; text-align: right;">交易密码：
                                                            </td>
                                                            <td align="left">
                                                                <input runat="server" type="password" class="span6" name="PayPass" id="PayPass" value="" />
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 50px;">
                                                           <%-- <td style="width: 30.9%; text-align: right;">
                                                            </td>
                                                            <td align="left">
                                                                <input runat="server" type="password" class="span6" name="PayPass"  value="" />
                                                            </td>--%>
                                                        </tr>
                                                    </tbody>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </table>
                                        <div class="form-actions">
                                            <asp:Button ID="Button1" runat="server" Text="确认提交" class="btn btn-success" OnClick="Button1_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--content over-->
                    </div>
                </div>
            </div>
        </div>
    </form>
    
</body>
<script type="text/javascript">
    function getMaxDate() {
        var curDate = new Date();
        curDate.setMonth(curDate.getMonth());
        curDate.setDate(0);
        //alert(curDate.getDate());
        return curDate.getDate();
    }

    function hiddenput(a) {
        document.cookie = "selected_stTime=" + escape("" + a + "");
        TcStock();
    }

    function getCookie(cookieName) {
        var strCookie = document.cookie;
        var arrCookie = strCookie.split("; ");
        for (var i = 0; i < arrCookie.length; i++) {
            var arr = arrCookie[i].split("=");
            if (cookieName == arr[0]) {
                return arr[1];
            }
        }
        return 0;
    }

</script>
<script type="text/javascript">
    var iHdMoney = $("#hdmoney").val();
    var iHdPrice = $("#hdprice").val();

    var nowDate = new Date();
    var arry = new Array();
    var brry = new Array();
    var m = nowDate.toLocaleDateString();

    var myChart = echarts.init(document.getElementById("main1"));
    var myChart2 = echarts.init(document.getElementById("main2"));

    myChart.showLoading();
    myChart2.showLoading();

    var option = {
        backgroundColor: '#000000',//背景色
        //color: ['#32CD32', '#CD0000'],
        title: {
            show: true,
            text: '',
            textStyle: {
                color: 'white',
                fontStyle: 'normal',
                fontWeight: 'normal',
                fontFamily: 'sans-serif',
                fontSize: 12
            }
        },
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'line'
            },
            formatter: function (params) {
                var res = params[0].name;
                for (var i = params.length - 1; i >= 0; i--) {
                    if (params[i].value instanceof Array) {
                        res += '<br/>  Opening : ' + params[i].value[0] + '  High : ' + params[i].value[3];
                        res += '<br/>  Closing : ' + params[i].value[1] + '  Low : ' + params[i].value[2];
                    }
                    else {
                        res += '<br/>' + params[i].seriesName;
                        res += ' : ' + params[i].value;
                    }
                }
                return res;
            }
        },
        legend: {
            //orient: 'horizontal',
            //borderWidth: 0,
            //textStyle: {
            //    color: 'white'          // 图例文字颜色
            //}
            //data: ['上证指数', '成交金额(万)']
        },
        toolbox: {
            show: false
        },
        dataZoom: {
            show: true,
            realtime: true,
            start: 0,
            end: 100
        },
        grid: {
            show: true,
            borderWidth: 1,
            opacity: 0.3
            //borderColor: ''
        },
        textStyle: {
            decoration: 'none',
            //fontFamily: 'Arial, Verdana, sans-serif',
            //fontFamily2: '微软雅黑',    // IE8- 字体模糊并且不支持不同字体混排，额外指定一份
            fontSize: 12,
            fontStyle: 'normal',
            fontWeight: 'normal',
            color: 'white'
        },
        calculable: false,
        xAxis: [
            {
                type: 'category',
                position: 'right',
                boundaryGap: true,
                axisTick: { onGap: false },
                splitLine: { show: false },
                axisLine: {            // 坐标轴线
                    show: false       // 默认显示，属性show控制显示与否
                },
                axisLabel: {           // 坐标轴文本标签，详见axis.axisLabel
                    show: true,
                    rotate: 0,
                    margin: 8,
                    formatter: function (value) {
                        return value.substr(9, 19);
                    },
                    textStyle: {       // 其余属性默认使用全局文本样式，详见TEXTSTYLE
                        color: 'white'
                    }
                },
                splitLine: {            // 分隔线
                    show: false,
                },
                data: []
            }
        ],
        yAxis: [
            {
                type: 'value',
                name: 'Price',
                scale: true,
                splitNumber: 5,
                boundaryGap: [0.01, 0.01],
                position: 'right',
                axisLabel: {           // 坐标轴文本标签，详见axis.axisLabel
                    show: true,
                    rotate: 0,
                    margin: 8,
                    textStyle: {       // 其余属性默认使用全局文本样式，详见TEXTSTYLE
                        color: 'white'
                    }
                },
                splitLine: {            // 分隔线
                    show: true,
                    type: 'solid',
                    lineStyle: {       // 属性lineStyle控制线条样式
                        color: 'white',
                        type: 'solid',
                        opacity: 0.3
                    }
                }
            },
            {
                type: 'value',
                show: false
            }
        ],
        series: [
            {
                type: 'candlestick',
                symbol: 'none',
                itemStyle: {
                    normal: {
                        color: '#32CD32',          // 阳线填充颜色
                        color0: '#CD0000',      // 阴线填充颜色
                        lineStyle: {
                            width: 1,
                            color: '#32CD32',   // 阳线边框颜色
                            color0: '#CD0000'   // 阴线边框颜色
                        },
                        borderColor: '#32CD32',
                        borderColor0: '#CD0000',
                    },
                    emphasis: {
                        // color: 各异,
                        // color0: 各异
                    }
                }
                //data: []
            },
            {
                name: 'Amount',
                type: 'line',
                yAxisIndex: 1,
                symbol: 'none',

                itemStyle: {
                    normal: {
                        color: 'white',
                        lineStyle: {
                            width: 2,
                            color: 'white',
                            opacity: 0.5
                        }
                    },
                    emphasis: {
                        color: 'white'
                    }
                },
                data: []
            }
        ]

    };

    var option2 = {
        backgroundColor: '#000000',//背景色

        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'line'
            }
        },
        //legend: {
        //    show: true,
        //    data: ['上证指数', '成交金额(万)']
        //},
        toolbox: {
            show: true,
            feature: {
                mark: { show: false },
                dataView: { show: false, readOnly: false },
                magicType: { show: false, type: ['line', 'bar'] },
                restore: { show: false },
                saveAsImage: { show: false }
            }
        },
        dataZoom: {
            show: true,
            realtime: true,
            start: 0,
            end: 100
        },
        textStyle: {
            decoration: 'none',
            fontFamily: 'Arial, Verdana, sans-serif',
            fontFamily2: '微软雅黑',    // IE8- 字体模糊并且不支持不同字体混排，额外指定一份
            fontSize: 12,
            fontStyle: 'normal',
            fontWeight: 'normal',
            color: 'white'
        },
        grid: {
            show: true,
            borderWidth: 1,
            opacity: 0.3
        },
        calculable: true,
        xAxis: [
            {
                type: 'category',
                position: 'bottom',
                boundaryGap: true,
                axisTick: { onGap: false },
                axisLine: {            // 坐标轴线
                    show: false,        // 默认显示，属性show控制显示与否
                },
                axisLabel: {           // 坐标轴文本标签，详见axis.axisLabel
                    show: true,
                    rotate: 0,
                    margin: 8,
                    formatter: '{value}',
                    // 使用函数模板，函数参数分别为刻度数值（类目），刻度的索引
                    formatter: function (value) {
                        // 格式化成月/日，只在第一个刻度显示年份
                        return value.substr(9, 19);
                    },
                    textStyle: {       // 其余属性默认使用全局文本样式，详见TEXTSTYLE
                        color: 'white'
                    }
                },
                splitLine: {            // 分隔线
                    show: false
                },
                data: []
            }
        ],
        yAxis: [
            {
                type: 'value',
                scale: true,
                splitNumber: 5,
                boundaryGap: [0.05, 0.05],

                splitArea: { show: false },
                axisLine: {            // 坐标轴线
                    show: false
                },
                axisLabel: {           // 坐标轴文本标签，详见axis.axisLabel
                    show: true,
                    rotate: 0,
                    //margin: 5,
                    textStyle: {       // 其余属性默认使用全局文本样式，详见TEXTSTYLE
                        color: 'white'
                    }
                },
                splitLine: {            // 分隔线
                    show: true,
                    color: 'black',
                    width: 0,
                    type: 'solid',
                    lineStyle: {       // 属性lineStyle控制线条样式
                        color: 'white',
                        type: 'solid',
                        opacity: 0.3
                    }
                }
            }
        ],
        series: [
            {
                name: 'Amount',
                type: 'bar',
                //symbol: 'none',
                itemStyle: {
                    normal: {
                        color: function (params) {
                            if (params.value > iHdMoney) {
                                return '#32CD32';
                            }
                            else {
                                return '#CD0000';
                            }
                        },
                        lineStyle: {
                            width: 1,
                            opacity: 0.5
                        }
                    }
                },
                data: [],
            }
        ]

    };

    function TcStock() {
        a = getCookie("selected_stTime");
        $.ajax({
            type: "post",
            async: false, //同步执行
            url: "Kcharts.ashx?type=k&need=" + a,
            dataType: "json", //返回数据形式为json
            success: function (result) {
                if (result) {
                    if (result.length == 0) {
                        option.series[0].data = [];
                        option.xAxis[0].data = [m];

                        option2.series[0].data = [];
                        option2.xAxis[0].data = [m];
                    } else {
                        var arr = new Array();//价格
                        var brr = new Array();//时间（横坐标）
                        var crr = new Array();//成交金额
                        for (var i = 0; i < result.length; i++) {
                            crr[i] = result[i].mvalue;
                            brr[i] = result[i].name;
                            arr[i] = result[i].value;
                        }
                        option.xAxis[0].data = brr;
                        option.series[0].data = arr;
                        option.series[1].data = crr;

                        option2.xAxis[0].data = brr;
                        option2.series[0].data = crr;
                    }
                    myChart.hideLoading();
                    myChart.setOption(option);
                    myChart2.hideLoading();
                    myChart2.setOption(option2);

                    echarts.connect([myChart, myChart2]);
                }
            },
            error: function (errorMsg) {
                alert("图表请求数据错误!");
            }
        });
    }

    TcStock();
    window.setInterval(function () {
        TcStock();
    }, 10000);

    //鼠标移动数据 mouseover
    myChart.on('mouseover', function (params) {
        var iopen = params.value[0];
        var iclose = params.value[2];
        var ihigh = params.value[3];
        var ilow = params.value[1];
        var ichange = 0;
        var irange = 0;
        if (iopen > iclose) {
            ichange = 0 - (iopen - iclose) / iopen
        }
        else if (iclose > iopen) {
            ichange = (iclose - iopen) / iopen
        }
        irange = (ihigh - ilow) / iclose;
        myChart.setOption({
            title: {
                show: true,
                textstyle: {
                    color: 'white',
                    fontstyle: 'normal',
                    fontweight: 'normal',
                    fontfamily: 'sans-serif',
                    fontsize: 12
                },
                text: params.name.substr(0, 11) + ':  opening：' + iopen + '  high：' + ihigh
                    + '  low：' + ilow + '  closing：' + iclose + '  change：' + ichange.toFixed(3)
                    + '  range：' + irange.toFixed(3)
            }
        });
    });
</script>
</html>
