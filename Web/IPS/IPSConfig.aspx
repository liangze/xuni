<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IPSConfig.aspx.cs" Inherits="ThirdPartyPaymentExample.IPS.IPSConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>环迅接口配置</title>
    <style type="text/css">
        #info
        {
            width:450px;
            margin:auto auto;
        }         
    </style>
</head>
<body>
    <form id="configform" runat="server">

        <div id="info">
            <table id="config-table">
                <th>
                    <td colspan="2"> 
                        环迅接口设置                   
                    </td>
                </th>
                <tr>
                    <td colspan="2">                        
                        <asp:RadioButton ID="rdbTesting" AutoPostBack="true" Text="测试环境"  GroupName="Environment" 
                            Checked="true"  runat="server" oncheckedchanged="rdbTesting_CheckedChanged" />                                              
                        <asp:RadioButton ID="rdbOfficial" AutoPostBack="true" Text="正式环境"  
                            GroupName="Environment" runat="server" 
                            oncheckedchanged="rdbOfficial_CheckedChanged" />                        
                    </td>
                </tr>
                <tr>
                    <td>
                        商户帐号:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAccount" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        商户证书:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCertificate" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>  
                <tr>
                    <td>
                        支持币种:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCurrencyType" AutoPostBack="true" Width="120" runat="server">                     
                            <asp:ListItem Value="RMB" Selected="True">人民币</asp:ListItem>
                            <asp:ListItem Value="HKD">港币</asp:ListItem>
                            <asp:ListItem Value="MYR" >马币</asp:ListItem>
                            <asp:ListItem Value="USD">USD</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>   
                <tr>
                    <td>
                        支付方式:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGatewayType" AutoPostBack="true" Width="120" runat="server">
                            <asp:ListItem Value="01" Selected="True">借记卡</asp:ListItem>
                            <asp:ListItem Value="04">IPS账户支付</asp:ListItem>
                            <asp:ListItem Value="08" >IB支付</asp:ListItem>
                            <asp:ListItem Value="16">电话支付</asp:ListItem>		
                            <asp:ListItem Value="64">储值卡支付</asp:ListItem>		                     
                        </asp:DropDownList>
                    </td>
                </tr> 
                <tr>
                    <td>
                        界面语言:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLang" AutoPostBack="true" Width="120" runat="server">                    
                            <asp:ListItem Value="GB" Selected="True">GB中文</asp:ListItem>
                            <asp:ListItem Value="EN">英语</asp:ListItem>
                            <asp:ListItem Value="BIG5" >BIG中文</asp:ListItem>
                            <asp:ListItem Value="JP">日文</asp:ListItem>		
                            <asp:ListItem Value="FR">法文</asp:ListItem>                        
                        </asp:DropDownList>
                    </td>
                </tr> 
                <tr>
                    <td>
                        成功返回页面:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderReturn" Text="" Width="250" runat="server"></asp:TextBox>
                    </td>
                </tr>                
                <tr>
                    <td>
                        失败返回页面:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderFail" Text="" Width="250" runat="server"></asp:TextBox>
                    </td>
                </tr>  
                <tr>
                    <td>
                        错误返回页面:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderError" Text="" Width="250"  runat="server"></asp:TextBox>
                    </td>
                </tr>  
                <tr>
                    <td>
                        订单支付加密方式:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOrderEncodeType" AutoPostBack="true" Width="120" runat="server">
                            <asp:ListItem Value="0" >不加密</asp:ListItem>  
                            <asp:ListItem Value="2" Selected="True" >MD5摘要</asp:ListItem>  
                            <asp:ListItem Value="9" >错误</asp:ListItem>                          
                        </asp:DropDownList>
                    </td>
                </tr>  
                <tr>
                    <td>
                        交易返回加密方式:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRetEncodeType" AutoPostBack="true" Width="120" runat="server"> 
                            <asp:ListItem Value="10" >老接口</asp:ListItem>  
                            <asp:ListItem Value="11" >MD5WithRsa</asp:ListItem>  
                            <asp:ListItem Value="12" Selected="True" >MD5摘要</asp:ListItem>     
                            <asp:ListItem Value="9" >错误</asp:ListItem>                      
                        </asp:DropDownList>
                    </td>
                </tr>    
                <tr>
                    <td>
                        Server返回方式:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRettype" AutoPostBack="true" Width="120" runat="server">
                            <asp:ListItem Value="0" Selected="True">无Server to Server</asp:ListItem>       
                            <asp:ListItem Value="1">有Server to Server</asp:ListItem>   
                            <asp:ListItem Value="9">错误</asp:ListItem>                     
                        </asp:DropDownList>
                    </td>
                </tr>  
                <tr>
                    <td>
                        Server返回页面:
                    </td>
                    <td>
                        <asp:TextBox ID="txtServerUrl" Width="250px" runat="server"></asp:TextBox>
                    </td>
                </tr>                                                                                                                            
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="重置" onclick="btnReset_Click" />
                    </td>
                </tr>                                 
            </table>
        </div>
    </form>
</body>
</html>
