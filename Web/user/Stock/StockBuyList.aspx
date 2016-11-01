<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockBuyList.aspx.cs" Inherits="Web.user.Stock.StockBuyList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="../../css/datepicker.css" />
    <link rel="stylesheet" href="../../css/uniform.css" />
    <link rel="stylesheet" href="../../css/maruti-style.css" />
    <link rel="stylesheet" href="../../css/maruti-media.css" class="skin-color" />
    <link rel="stylesheet" href="../../css/font-awesome.min.css" />
    <script src="../../JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../JS/echarts/esl.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="content">
            <div class="container-fluid">
                <div class="row-fluid">
                    <div class="span12">
                        <!--content start-->
                        <div class="widget-box">
                            <div class="widget-title">
                                <span class="icon">
                                    <i class="icon-align-right"></i>
                                </span>
                            </div>
                            <div class="widget-content nopadding">
                                <form action="#" method="get" class="form-horizontal">
                                    <div style="float: left; margin-left: 2px; height: 360px; width: 100%; border: 1px solid #ccc; padding: 5px;" id="main">
                                        <!-- 走势图位置 -->

                                    </div>
                                </form>
                            </div>
                        </div>
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
                                            <td>2225</td>
                                            <td>135</td>
                                            <td>256</td>
                                            <td>225</td>
                                            <td>250</td>
                                        </tr>
                                        <tr>
                                            <td>2225</td>
                                            <td>135</td>
                                            <td>256</td>
                                            <td>225</td>
                                            <td>250</td>
                                        </tr>
                                        <tr>
                                            <td>2225</td>
                                            <td>135</td>
                                            <td>256</td>
                                            <td>225</td>
                                            <td>250</td>
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
                                        <form action="#" method="get" class="form-horizontal">
                                            <div class="control-group">
                                                <label class="control-label">当前价格：</label>
                                                <div class="controls">999.00</div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">购买数量：</label>
                                                <div class="controls">
                                                    <input type="text" class="span6" name="" id="" value="" />
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">购买总价：</label>
                                                <div class="controls">0.00</div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">选择支付：</label>
                                                <div class="controls">
                                                    <select name="" class="span5">
                                                        <option value="">请选择</option>
                                                        <option value="">农业银行</option>
                                                        <option value="">建设银行</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">交易密码：</label>
                                                <div class="controls">
                                                    <input type="text" class="span6" name="" id="" value="" />
                                                </div>
                                            </div>
                                            <div class="form-actions">
                                                <button type="submit" class="btn btn-success">确认提交</button>
                                            </div>
                                        </form>
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
                                        <form action="#" method="get" class="form-horizontal">
                                            <div class="control-group">
                                                <label class="control-label">当前价格：</label>
                                                <div class="controls">99998850.00</div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">卖出数量：</label>
                                                <div class="controls">
                                                    <input type="text" class="span6" name="" id="" value="" />
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">卖出总价：</label>
                                                <div class="controls">0.00</div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">交易密码：</label>
                                                <div class="controls">
                                                    <input type="text" class="span6" name="" id="" value="" />
                                                </div>
                                            </div>
                                            <div class="form-actions">
                                                <button type="submit" class="btn btn-success">确认提交</button>
                                            </div>
                                        </form>
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
    <script type="text/javascript">
        function getMaxDate() {
            var curDate = new Date();
            curDate.setMonth(curDate.getMonth());
            curDate.setDate(0);
            //alert(curDate.getDate());
            return curDate.getDate();
        }

        require.config({
            paths: {
                //'echarts': '../JS/echarts/echarts', //echarts.js的路径
                //'line': '../JS/echarts/line'
                'echarts': 'http://echarts.baidu.com/build/echarts',
                'echarts/chart/line': 'http://echarts.baidu.com/build/echarts'
            }
        });

        // Step:4 require echarts and use it in the callback.
        // Step:4 动态加载echarts然后在回调函数中开始使用，注意保持按需加载结构定义图表路径
        require(
        [
        //'echarts',
        //'line'
          'echarts',
          'echarts/chart/line'
        ],
        //回调函数
        DrawEChart
        );

        //渲染ECharts图表
        function DrawEChart(ec) {
            var chartContainer = document.getElementById("main");
            var nowDate = new Date();
            var arry = new Array();
            var brry = new Array();
            var m = nowDate.toLocaleDateString();

            var myChart = ec.init(chartContainer);
            myChart.showLoading({
                text: "图表数据正在努力加载..."
            });

            var opition = {
                title: {
                    text: '价格走势图',
                    subtext: '',
                },
                tooltip: {
                    trigger: 'axis',
                },
                legend: {
                    data: ['积分价格']
                },
                toolbox: {
                    show: true,
                    feature: {
                        mark: { show: true },
                        dataView: { show: true, readOnly: false },
                        magicType: { show: true, type: ['line', 'bar'] },
                        restore: { show: true },
                        saveAsImage: { show: true }
                    }
                },
                dataZoom: {
                    show: true,
                    realtime: true,
                    start: 0,
                    end: 100
                },
                calculable: true,
                xAxis: [
                    {
                        type: 'category',
                        name: '日期',
                        boundaryGap: false,
                        axisLine: { onZero: false },
                        data: []
                    }
                ],
                yAxis: [
                    {
                        type: 'value',
                        name: '积分价格（$/个）',
                        //splitArea: { show: true },
                        min: 1.68,
                        max: 1.70,
                        splitNumber: 0.01,
                        precision: 0.01,
                        scal: false,
                        //axisLabel: { show: true },

                    }
                ],
                series: [{
                    name: "积分价格",
                    type: 'line',
                    data: [],
                    markPoint: {
                        data: [
                            { type: 'max', name: '最大值' },
                            { type: 'min', name: '最小值' }
                        ]
                    },
                    markLine: {
                        data: [
                            { type: 'average', name: '平均值' }
                        ]
                    }
                }
                ]
            };
            $.ajax({
                type: "post",
                async: false, //同步执行
                url: "HandlerLine.ashx?type=line",
                dataType: "json", //返回数据形式为json
                success: function (result) {
                    if (result) {
                        if (result.length == 0) {
                            opition.series[0].data = [];
                            opition.xAxis[0].data = [m];
                        } else {
                            var arr = new Array();
                            var brr = new Array();
                            for (var i = 0; i < result.length; i++) {

                                brr[i] = result[i].name;//.substr(5, 9)
                                arr[i] = result[i].value;
                            }
                            opition.xAxis[0].data = brr;
                            opition.series[0].data = arr;
                        }
                        myChart.hideLoading();
                        myChart.setOption(opition);
                    }
                },
                error: function (errorMsg) {
                    alert("不好意思，图表请求数据错误!");
                }
            });
        }
    </script>
</body>
</html>
