<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPayment.aspx.cs" Inherits="ThirdPartyPaymentExample.IPS.OrderPayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
    <title>环迅支付接口</title>
    <script type="hidden/javascript">
        function cancelOrder() {
            alert("取消交易啦!!!!!!");
            /*温馨提示:
              取消交易,可以跳转到任意页面,所需要的参数可以从input中取得*/
            var attachParam = document.getElementById("Attach").value;
            alert(attachParam);
            //location.href = "";
        }
    </script>

    <link href="../style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form" method="post" action="Redirect.aspx" >
    <div class="mainpage" style="padding:20px;">

 
  <!--end mainTop-->
  <div class="mainCon">
  	<div class="annoucement">
  	
        <div id="info" style=" text-align:center;">
 
	
            <div >
                <%=ConfirmHtml %>
            </div>
            <div>
                <input type="hidden" name="test" id="test" value="" runat="server" />
                <input type="hidden" name="Mer_code" id="Mer_code" value="" runat="server" />
                <input type="hidden" name="Mer_key" id="Mer_key" value=""   runat="server" />
                <input type="hidden" name="Billno" id="Billno" value=""  runat="server" />
                <input type="hidden" name="Amount" id="Amount" value=""  runat="server" />
                <input type="hidden" name="Date" id="Date" value=""  runat="server" />
                <input type="hidden" name="Currency_Type" id="Currency_Type" value="" runat="server" />
                <input type="hidden" name="Gateway_Type" id="Gateway_Type" value="" runat="server" />
                <input type="hidden" name="Lang" value="" id="Lang" runat="server"/>
                <input type="hidden" name="Merchanturl" id="Merchanturl" value="" runat="server" />
                <input type="hidden" name="FailUrl" id="FailUrl" value="" runat="server" />
                <input type="hidden" name="ErrorUrl" id="ErrorUrl" value="" runat="server" />
                <input type="hidden" name="Attach" id="Attach" value="" runat="server" />
                <input type="hidden" name="DispAmount" id="DispAmount" value="" runat="server" />
                <input type="hidden" name="OrderEncodeType" id="OrderEncodeType" value="" runat="server" />
                <input type="hidden" name="RetEncodeType" id="RetEncodeType" value="" runat="server" />
                <input type="hidden" name="Rettype" id="Rettype" value="" runat="server" />
                <input type="hidden" name="ServerUrl" id="ServerUrl" value="" runat="server" />
            </div>
            <div>
               <input type="submit" class="btn" value="确认" />
               <%--<input type="button" value="取消" onclick="cancelOrder()" />--%>
            </div>            
        </div>
        </div></div></div>
    </form>
</body>
</html>
