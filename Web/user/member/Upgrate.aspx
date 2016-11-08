<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upgrate.aspx.cs" Inherits="Web.user.member.Upgrate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会员升级</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="Form1" runat="server" class="stdform">
        <div class="right_content" style="left: 0px">
            <h2>会员升级</h2>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            用户名：
                        </label>
                        <div class="field">
                            <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            当前等级：
                        </label>
                        <div class="field">
                            <input name="txtPresentLevel" type="text" id="txtPresentLevel" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            升级至：
                        </label>
                        <div class="field">
                            <asp:DropDownList ID="DropDownList1" runat="server" Style="min-width: 300px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            将扣除：
                        </label>
                        <div class="field">
                            <input name="txtPayFor" type="text" id="txtPayFor" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                        </label>
                        <div class="field">
                            <asp:Button ID="btnSubmit" runat="server" Text="升级" class="btn" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
