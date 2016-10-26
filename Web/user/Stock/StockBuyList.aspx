<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockBuyList.aspx.cs" Inherits="Web.user.Stock.StockBuyList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../JS/echarts/esl.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("MDDGoldFutures")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <div class="span3 graph" style="width:100%;">
                        <div id="main" style="float: left; margin-left: 2px; height: 360px; width: 100%; border: 1px solid #ccc; padding: 5px;">
                        </div>
                        <%--<div id="chartdiv" style="width:100%; height:240px;"></div>--%>
                    </div>
                </div>
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("PurchaseTime")%><!--发布时间-->：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtStartEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtEnd" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEndEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn" Text="搜索" />
                    </p>
                </div>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <td align="center" style="color:#fff"><%=GetLanguage("SerialNumber")%><%--序号--%></td>
                        <td align="center" style="color:#fff"><%=GetLanguage("MembershipNumber")%><%--会员编号--%></td>
                        <td align="center" style="color:#fff"><%=GetLanguage("AmountOfPurchase")%><%--购买金额--%></td>
                        <td align="center" style="color:#fff"><%=GetLanguage("NoAmount")%><%--未购金额--%></td>
                        <td align="center" style="color:#fff"><%=GetLanguage("PurchaseTime")%><%--购买时间--%></td>
                        <td align="center" style="color:#fff"><%=GetLanguage("PurchaseStatus")%><%--购买状态--%></td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%# this.Repeater1.Items.Count + 1%> 
                                </td>
                                <td align="left">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="left">
                                    <%#Eval("Amount")%>
                                </td>
                                <td align="left">
                                    <%#Eval("SurplusSum")%>
                                </td>
                                <td align="center">
                                    <%#Convert.ToDateTime(Eval("BuyDate")).ToString("")%>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltIsBuy" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="6" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" Direction="LeftToRight"
                    OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
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
                    text: 'MDD钻股币走势图',
                    subtext: '',
                },
                tooltip: {
                    trigger: 'axis',
                },
                legend: {
                    data: ['MDD钻股币价格']
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
                        name: 'MDD钻股币价格（元/个）',
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
                    name: "MDD钻股币价格",
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