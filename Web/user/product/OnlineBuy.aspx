<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineBuy.aspx.cs" Inherits="web.user.product.OnlineBuy" %>

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
    <form id="Form1" class="box_con" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class="operation">
        <fieldset class="fieldset">
        �ҵ�E����<input name="textMoney" type="text" id="textMoney" disabled="disabled" class=" input_select" readonly="readonly" runat="server"/>Ԫ
        </fieldset>
            <fieldset class="fieldset">
                <legend class="legSearch">��ѯ</legend>
                ��Ʒ��ţ�
                <input type="text" id="textCode" tip="������Ʒ���" class="input_select" name="textfield" runat="server" />
                ��Ʒ���ƣ�<input name="textfield2" type="text" class=" input_select" id="textName" tip="������Ʒ����" runat="server"/>
                ��Ʒ�۸�<input name="textfield3" type="text" class=" input_select" id="textMinPrice" tip="������Ʒ�۸�" runat="server"/>
                ��<input name="textfield4" type="text" class=" input_select" id="textMaxPrice" tip="������Ʒ�۸�" runat="server"/>
                ��Ŀ��<asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                &nbsp;&nbsp;<asp:Button ID="btnChuSearch" runat="server" Text="����" class="btn" OnClick="btnChuSearch_Click" />
      
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" >
                <tr>
                    <td>
                    <asp:DataList ID="dlGoods" runat="server" Width="100%" 
            onitemcommand="dlGoods_ItemCommand" BackColor="White" 
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            GridLines="Both">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <ItemTemplate>
         <table width="100%" border="0" style="margin-bottom:10px">
         <tr>
         <td align="center">
         
		<div id="images">
		
			<a id="example1-1" title="" href='<%# Eval("picture","../../Upload/{0}") %>'><img src='<%# Eval("picture","../../Upload/{0}") %>'   onload="AutoResizeImage(150,150,this)" alt="����鿴ԭͼ" /><asp:Image ID="Image1" Visible="false"  runat="server" ImageUrl='<%# Eval("picture","../../Upload/{0}") %>'  align="middle" /></a>

		</div>
         <%----%>
         </td>
         <td>
            <ul>
                <li><span>��Ʒ��ţ�</span>
                <asp:TextBox ID="txtGoodsCode" runat="server" Text='<%#Eval("ProcudeCode") %>' disabled="disabled" class=" input_second" ReadOnly="true"></asp:TextBox>
                <span style="margin-right:10px; display:block; width:70px; text-align:right; float:left;">
                ����������</span>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:TextBox ID="txtCount" runat="server" class=" input_second" tip="���빺������"
                  ontextchanged="txtCount_TextChanged"  AutoPostBack="true"></asp:TextBox>
                  </ContentTemplate>
                  <Triggers>
                  <asp:AsyncPostBackTrigger   ControlID="txtCount" />
                  </Triggers>
                    </asp:UpdatePanel>
                </li>
                <li><span>��Ʒ���ƣ�</span>
                <asp:TextBox ID="txtGoodsName" runat="server" Text='<%#Eval("procudeName") %>' disabled="disabled" class=" input_second" ReadOnly="true"></asp:TextBox>
                <span style="margin-right:10px; display:block; width:70px; text-align:right; float:left;">
                �ܽ�</span>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:TextBox ID="txtTotalMoneny" runat="server" ReadOnly="true" class=" input_second" disabled="disabled"></asp:TextBox>
                  </ContentTemplate>
                    </asp:UpdatePanel>
                </li>
                <li><span>�г��ۣ�</span>
                <asp:TextBox ID="txtMarketPrice" runat="server" Text='<%#Eval("MarketPrice") %>' disabled="disabled" class=" input_second" ReadOnly="true"></asp:TextBox>
                <span style="margin-right:10px; display:block; width:70px; text-align:right; float:left;">
                ��Ա�ۣ�</span>
                <asp:TextBox ID="txtMemberPrice" runat="server" Text='<%#Eval("MemberPrice") %>' disabled="disabled" class=" input_second" ReadOnly="true"></asp:TextBox>
                
                </li>
                <li><span>��Ʒ��Ŀ��</span>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <asp:TextBox ID="txtTypeName" runat="server" Text='<%#Eval("LinkURL") %>' disabled="disabled" class=" input_san" ReadOnly="true"></asp:TextBox>
                <span style=" display:block; width:30px; text-align:left; float:left;">&nbsp;&nbsp;</span><asp:LinkButton ID="LinkButton1" style="color:red;" runat="server" CommandName="buy" CommandArgument='<%#Eval("ProcudeID") %>'>[����]</asp:LinkButton>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="LinkButton1" />
                </Triggers>
                    </asp:UpdatePanel>
                </li>
                <li><span>˵����</span>
                    <asp:TextBox ID="txtNote" runat="server" Text='<%#Eval("Note") %>'  ReadOnly="true" class=" input_second2" TextMode="MultiLine"></asp:TextBox>
                
                </li>
                </ul>
         </td>
         </tr>
      </table>
            </ItemTemplate>
            <ItemStyle BackColor="White" ForeColor="#003399" />
            <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        </asp:DataList>
                    </td>
                </tr>
                <tr align="center" id="trGoodsNull" runat="server">
                    <td  style="border: 0">
                        <div >
                            <img src="../../images/ico_NoDate.gif" width="16" height="16" />��Ǹ��Ŀǰ���ݿ������޼�¼��ʾ��</div>
                    </td>
                </tr>
                <tr id="tr1" runat="server">
                    <td  align="center">
                        <div class="nextpage cBlack">
                            <webdiyer:AspNetPager ID="anpGoods" runat="server" SkinID="AspNetPagerSkin" FirstPageText="��ҳ"
                                        LastPageText="βҳ" NextPageText="��һҳ" PrevPageText="��һҳ" AlwaysShow="True" InputBoxClass="pageinput"
                                        NumericButtonCount="3" PageSize="4" ShowInputBox="Never" ShowNavigationToolTip="True"
                                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                                        SubmitButtonText="" textafterpageindexbox=" ҳ" textbeforepageindexbox="ת�� " OnPageChanged="anpGoods_PageChanged">
                                    </webdiyer:AspNetPager>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
