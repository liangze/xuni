<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Business.aspx.cs" Inherits="web.user.member.Business" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>�˻�ת�˲�ѯ</title>
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
	    $("#div1 a").imgbox();
	    });
	</script>
    <script type="text/javascript">
    ///����ʱ��������СͼƬ
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
    <div class="box box_width" id="div1">
        <div class=" dataTable">
        <asp:Repeater ID="rpBusiness" runat="server">
            <ItemTemplate>
                <div class="shop_car" >
                
            <table width="100%" border="0" cellspacing="0" cellpadding="0" >
        <tr>
            <td colspan="2">
                <b><span style="color:Red; font-size:25px;"><%# (this.anpBusiness.CurrentPageIndex - 1) * this.anpBusiness.PageSize + Container.ItemIndex + 1%></span>&nbsp;&nbsp;<span style=" color:#00CCFF;"><%#Eval("NewsTitle")%></span></b></td>
        </tr>
        <tr>
            <td colspan="2" >
                ���ߣ�<%#Eval("Publisher")%>&nbsp;&nbsp;�����ڣ�<%#Convert.ToDateTime(Eval("PublishTime")).ToString("yyyy��MM��dd�� HH:mm")%>&nbsp;&nbsp;���ࣺ<span style=" color:#00CCFF;"><%#Eval("Classify")%></span>&nbsp;&nbsp;�������<%#Eval("Click")%></td>
        </tr>
        <tr>
            <td>
		<div id="images">
		
			<a id="example1" title="" href='<%# Eval("ImageURL","../../Upload/{0}") %>'><img   alt="����鿴ԭͼ"   onload="AutoResizeImage(120,120,this)"  src='<%# Eval("ImageURL","../../Upload/{0}") %>' /></a>

		</div>
                <%--<asp:Image ID="Image1" Width="150px" Height="100px" runat="server" ImageUrl='<%# Eval("ImageURL","../../Upload/{0}") %>'/>--%></td>
            <td align="left">
                <%# getstring(Eval("NewsContent").ToString(), 200)%></td>
        </tr>
        <tr>
            <td colspan="2">
                tags��<%#Eval("Tags")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='BusinessDetail.aspx?id=<%#Eval("ID")%>'><span style=" color:#00CCFF;">�Ķ�ȫ��</span></a></td>
        </tr>
    </table>
                 </div><br />
            </ItemTemplate>
        </asp:Repeater>
           <div id="divNull" runat="server" style=" width:99%;" align="center"><span class="cBlack"> <img src="../../images/ico_NoDate.gif" width="16" height="16" /> ��Ǹ��Ŀǰ���ݿ������޼�¼��ʾ</span></div>
           <div style=" width:99%;">
        <webdiyer:AspNetPager ID="anpBusiness" runat="server" SkinID="AspNetPagerSkin" FirstPageText="��ҳ"
                            LastPageText="βҳ" NextPageText="��һҳ" OnPageChanged="anpGoods_PageChanged"
                            PrevPageText="��һҳ" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                            PageSize="5" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                            UrlPaging="false" pageindexboxtype="TextBox" 
                showpageindexbox="Always" SubmitButtonText=""
                            textafterpageindexbox=" ҳ" textbeforepageindexbox="ת�� " 
                HorizontalAlign="Right">
                        </webdiyer:AspNetPager>
           </div>
        </div>
    </div>
    </form>
</body>
</html>
