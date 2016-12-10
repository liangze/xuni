<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPassWord.aspx.cs"
    Inherits="Web.user.member.ModifyPassWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改密码</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="Form1" runat="server" class="stdform">
        <div class="right_content">
            <h2><%=GetLanguage("ModifyPassword")%></h2>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Oldpassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtPwd" id="txtPwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("newpassword")%>：      
                        </label>
                        <div class="field">
                            <input name="txtNewPwd" id="txtNewPwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Confirmpassword")%>：        
                        </label>
                        <div class="field">
                            <input name="txtRPNewPwd" id="txtRPNewPwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="action">
                        <asp:Button ID="btnPwd" runat="server" class="btn" OnClick="btnPwd_Click" />
                    </div>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("OldSecondPassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtSecondPwd" id="txtSecondPwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("NewSecondPassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtNewSecondPwd" id="txtNewSecondPwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("ConfirmSecondPassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtRPSecondPwd" id="txtRPSecondPwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="action">
                        <asp:Button ID="btnSecond" runat="server" class="btn" OnClick="btnSecond_Click" />
                    </div>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("OldThreePassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtThreePwd" id="txtThreePwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("NewThreePassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtNewThreePwd" id="txtNewThreePwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("ConfirmThreePassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtRPThreePwd" id="txtRPThreePwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="action">
                        <asp:Button ID="btnThree" runat="server" class="btn" OnClick="btnThree_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
