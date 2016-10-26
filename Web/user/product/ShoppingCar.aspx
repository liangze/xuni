<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCar.aspx.cs" Inherits="web.user.product.ShoppingCar" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>账户转账查询</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />

    <script src="../../SpryAssets/SpryTabbedPanels.js" type="text/javascript"></script>

    <link href="../../SpryAssets/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Tooltip.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../../js/jquery1.2.js"></script>

    <script type="text/javascript" src="../../js/superValidator.js"></script>

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>

    <link href="../../imgbox/imgbox.css" rel="stylesheet" type="text/css" />

    <script src="../../imgbox/jquery.min.js" type="text/javascript"></script>
    <script src="../../imgbox/jquery.imgbox.pack.js" type="text/javascript"></script>

	<style type="text/css">
		#images a {
			margin-right: 14px;
		}

		#images a img {
			border: 1px solid #888;	
			padding: 3px;
			vertical-align: top;
		}

		#credit {
			clear: both;	
			margin-top: 50px;
			padding-top: 20px;
			font-size: 10px;
			border-top: 1px solid #BBB;
			font-family: Verdana;
		}
	</style>
	<script type="text/javascript">
	    $(document).ready(function() {
	        $("#images a").imgbox();

	        //	        $("#example1-2").imgbox({
	        //	            'zoomOpacity': true,
	        //	            'alignment': 'center'
	        //	        });

	        //	        $("#example1-3").imgbox({
	        //	            'speedIn': 0,
	        //	            'speedOut': 0
	        //	        });

	        //	        $("#example2-1, #example2-2").imgbox({
	        //	            'speedIn': 0,
	        //	            'speedOut': 0,
	        //	            'alignment': 'center',
	        //	            'overlayShow': true,
	        //	            'allowMultiple': false
	        //	        });
	    });
	</script>
    <script type="text/javascript">
    ///加载时按比例缩小图片
        function AutoResizeImage(maxWidth, maxHeight, objImg) {
var img = new Image();
img.src = objImg.src;
var hRatio;
var wRatio;
var Ratio = 1;
var w = img.width;
var h = img.height;
wRatio = maxWidth / w;
hRatio = maxHeight / h;
if (maxWidth ==0 && maxHeight==0){
Ratio = 1;
}else if (maxWidth==0){//
if (hRatio<1) Ratio = hRatio;
}else if (maxHeight==0){
if (wRatio<1) Ratio = wRatio;
}else if (wRatio<1 || hRatio<1){
Ratio = (wRatio<=hRatio?wRatio:hRatio);
}
if (Ratio<1){
w = w * Ratio;
h = h * Ratio;
}
objImg.height = h;
objImg.width = w;
}
</script>
</head>
<body class="subBody">
    <form id="form1" class="box_con" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class=" dataTable">
           <asp:Repeater ID="Repeater1" runat="server" 
               onitemcommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div class="shop_car" >
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
            <td width="100px">
                <div id="images">
		
			<a id="example1-1" title="" href='<%# Eval("img") %>'><img id="Img1" src='<%# Eval("img") %>' alt="点击查看原图"   onload="AutoResizeImage(100,100,this)"   class="img2" align="absmiddle" /></a>

		</div></td>
            <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;商品名称：<span class="mc"><%# Eval("procudeName")%></span>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;市场价：￥<asp:Label ID="lblMarketPrice" runat="server" Text='<%# Eval("MarketPrice")%>'></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;会员价：￥<asp:Label ID="lblMemberPrice" runat="server" Text='<%# Eval("MemberPrice")%>'></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;购买数量：<asp:ImageButton ID="imgbtnCut" runat="server" ImageUrl="../../images/jian_btn_03.jpg" width="9" height="9" align="absmiddle" onclick="imgbtnCut_Click"/>
<label>
    <asp:TextBox ID="txtCount" runat="server" size="3" Text='<%# Eval("count")%>' class=" input_first1" ontextchanged="txtCount_TextChanged" AutoPostBack="true"></asp:TextBox>
    <asp:HiddenField ID="hidid" runat="server" Value='<%# Eval("ProcudeID")%>'/>
            </label>
            <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="../../images/jia_btn_03.jpg" width="9" height="9" align="absmiddle" onclick="imgbtnAdd_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;总金额：<asp:Label ID="lblTotal" runat="server" Text='<%# Eval("totalMoney")%>'></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="删除" class="btn" CommandName="del"  CommandArgument='<%# Eval("ProcudeID")%>' OnClientClick="return confirm('确定删除吗？')"/>
            </td>
            </tr>
            </table>
                
                
            <%--<asp:ImageButton ID="imgbtnDel" runat="server" ImageUrl="../../images/btn22_15.jpg" width="72" height="26" align="absmiddle" CommandName="del"  CommandArgument='<%# Eval("ProcudeID")%>' OnClientClick="return confirm('确定删除吗？')"/>--%>
                </div><br />
            </ItemTemplate>
           </asp:Repeater>  
           <div id="divno" runat="server" style=" width:99%;" align="center"><span class="cBlack"> <img src="../../images/ico_NoDate.gif" width="16" height="16" /> 购物车没有货物</span></div>
           <div style=" width:99%;">
           <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                        LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                        NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True" HorizontalAlign="Right"
                                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                                        SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                                    </webdiyer:AspNetPager>
           </div>
           <div class="shop_car">
                <ul>
                <li style=" padding-left:120px;"><span>商品总数：</span>
                <input name="textfield7" type="text" id="txtCount" class=" input_select1" disabled="disabled" runat="server"/> 
                <span style="margin-right:10px; display:block; width:70px; text-align:right; float:left;">订货金额：</span>
                <input name="txtTotalMoney" type="text" id="txtTotalMoney" class=" input_select1"  disabled="disabled" runat="server"/>
                <span style="margin-right:10px; display:block; width:80px; text-align:right; float:left;">E币余额：</span>
                <input name="textfield7" type="text" id="txtMoney"  class=" input_select1"  disabled="disabled" runat="server"/>
                &nbsp;&nbsp;&nbsp;
                </li>
                <li>
                    <asp:Button ID="Button1" runat="server" Text="提交订单" class="btn" 
                        onclick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="继续购物" class="btn" 
                        onclick="Button2_Click" />
                    <asp:Button ID="Button3" runat="server" Text="清空购物车" class="btn" 
                        onclick="Button3_Click" />
                <%--<asp:ImageButton ID="imgbtnSubmit" runat="server" ImageUrl="../../images/btn24_15.jpg" 
               width="72" height="26" align="absmiddle" onclick="imgbtnSubmit_Click"/>
  <asp:ImageButton ID="imgbtnBack" runat="server" ImageUrl="../../images/btn25_15.jpg" 
               width="72" height="26" align="absmiddle" onclick="imgbtnBack_Click"/>
 <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/btn26_13.jpg" 
               width="72" height="26" align="absmiddle" onclick="ImageButton1_Click"/>--%></li>
                </ul>
        </div>
        </div>
    </div>
    </form>
</body>
</html>

