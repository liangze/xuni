<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agent.aspx.cs" Inherits="Web.user.team.Agent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>申请服务中心</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server" class="stdform">
        <div class="right_content">
            <h2><%=GetLanguage("ApplyCentre")%></h2>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <asp:Literal ID="ltAgent" runat="server"></asp:Literal>：
                        </label>
                        <div class="field">
                            <input id="txtAgentCode" name="txtAgentCode" class="input_reg" runat="server" type="text" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            &nbsp;
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltAudit" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="action">
                        <asp:Button ID="btnSubmit" runat="server" class="btn" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
