<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tpwd.aspx.cs" Inherits="Web.user.tpwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>三级密码</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server" class="stdform">
        <div class="right_content">
            <h2><%=GetLanguage("ThreePassword")%></h2>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("PleaseThreePassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtSecondPassword" id="txtSecondPassword" runat="server" maxlength="20" onkeydown="if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('ImageButton1').click();return false;}} else {return true}; " type="password" />
                        </div>
                    </div>
                    <div class="action">
                        <asp:Button ID="btnOK" runat="server" class="btn" OnClick="btnOK_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

