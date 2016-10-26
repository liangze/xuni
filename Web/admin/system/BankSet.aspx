<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankSet.aspx.cs" Inherits="Web.admin.system.BankSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>注册账户设置</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body>
    <form id="form2" runat="server" class="box_con">
<div class="box box_width">
                        <div class="main_dt">
                            <h2>
                                    注册账户设置</h2>
                                <ul>
                                    
                                    <li><span style="display:block; width:180px; text-align:right; float:left;"><font>*</font>开户银行：</span>
                                     <asp:TextBox ID="txtBank" runat="server"  class="input_second2" TextMode="MultiLine"></asp:TextBox>
                                    </li><li></li>
                                    <div class="dt_button" style=" padding-left:190px;">
                                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" 
                    iconcls="icon-ok" onclick="btnSave_Click"  > 设 置 </asp:LinkButton>
                                        (填写银行名称用，隔开，如农业银行，建设银行)
                                        </div>
                                    </ul>
                        </div>
                        
    </div>
    </form>
</body>
</html>
