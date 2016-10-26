<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recast.aspx.cs" Inherits="Web.user.member.Recast" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改密码</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="Form1" runat="server" class="stdform">
        <div class="right_content">
            <h2><%=GetLanguage("NumberRecast")%></h2>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("MembershipNumber")%>：
                        </label>
                        <div class="field">
                            <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Name")%>：
                        </label>
                        <div class="field">
                            <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("IDNumber")%>：
                        </label>
                        <div class="field">
                            <input name="txtIdenCode" type="text" id="txtIdenCode" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("ContactPhone")%>：
                        </label>
                        <div class="field">
                            <input name="txtPhoneNum" type="text" id="txtPhoneNum" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("RecastNumber")%>：
                        </label>
                        <div class="field">
                            <input name="txtBatch" type="text" id="txtBatch" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("TotalAAmount")%>：
                        </label>
                        <div class="field">
                            <input name="txtTotalAmount" type="text" id="txtTotalAmount" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("CapValue")%>：
                        </label>
                        <div class="field">
                            <input name="txtCapValue" type="text" id="txtCapValue" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("WhetherCast")%>：
                        </label>
                        <div class="field">
                            <input name="txtWhetherCast" type="text" id="txtWhetherCast" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="action">
                        自动复投
                       <%-- <asp:Button ID="btnSubmit" runat="server" class="btn" OnClick="btnSubmit_Click" />--%>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
