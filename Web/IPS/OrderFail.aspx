<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderFail.aspx.cs" Inherits="ThirdPartyPaymentExample.IPS.OrderFail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>交易失败</title>
</head>
<body>
    <form id="form" runat="server">
        <div>
            <h1>交易失败啦</h1>
            <div>
                <%=ErrorResult%>
            </div>
        </div>
    </form>
</body>
</html>
