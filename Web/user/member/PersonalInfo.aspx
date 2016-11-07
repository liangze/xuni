<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="Web.user.member.PersonalInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会员信息</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="Form1" runat="server" class="stdform">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="right_content">
            <h6><%=GetLanguage("LoginInformation")%>：</h6>
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
                            <%=GetLanguage("LoginPassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtPassword" type="text" id="txtPassword" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("SecondPassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtSecondPassword" type="text" id="txtSecondPassword" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("ThreePassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtThreePassword" type="text" id="txtThreePassword" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                </div>
            </div>
            <h6><%=GetLanguage("NetworkInformation")%>：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("MembershipLevels")%>：
                        </label>
                        <div class="field">
                            <input name="txtLevel" type="text" id="txtLevel" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("RegistrationAmount")%>：
                        </label>
                        <div class="field">
                            <input name="txtRegMoney" type="text" id="txtRegMoney" runat="server" disabled="disabled" class="input_reg1" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Agent") %>：
                        </label>
                        <div class="field">
                            <input name="txtAgentCode" type="text" id="txtAgentCode" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("ReferenceNumber")%>：
                        </label>
                        <div class="field">
                            <input name="txtRecommendCode" type="text" id="txtRecommendCode" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                    <div class="control-group" style="display: none;">
                        <label for="memid">
                            <%=GetLanguage("Placement")%>：
                        </label>
                        <div class="field">
                            <input name="txtParentCode" type="text" id="txtParentCode" runat="server" class="input_reg" disabled="disabled" />
                        </div>
                    </div>
                </div>
            </div>
            <h6><%=GetLanguage("Banking")%>：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Depositary") %>：
                        </label>
                        <div class="field">
                            <asp:DropDownList ID="dropBank" runat="server">
                            </asp:DropDownList>
                            <asp:DropDownList ID="dropProvince" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("BankBranch")%>：
                        </label>
                        <div class="field">
                            <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="input_reg" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("BankAccount")%>：
                        </label>
                        <div class="field">
                            <input name="txtBankAccount" type="text" id="txtBankAccount" runat="server" class="input_reg" value="" maxlength="19" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("AccountName")%>：
                        </label>
                        <div class="field">
                            <input name="txtBankAccountUser" type="text" id="txtBankAccountUser" runat="server" class="input_reg" />
                        </div>
                    </div>
                </div>
            </div>
            <h6><%=GetLanguage("Basic")%>：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Name")%>：
                        </label>
                        <div class="field">
                            <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="input_reg" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("IDNumber")%>：
                        </label>
                        <div class="field">
                            <input name="txtIdenCode" type="text" id="txtIdenCode" runat="server" class="input_reg"  />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("ContactPhone")%>：
                        </label>
                        <div class="field">
                            <input name="txtPhoneNum" type="text" id="txtPhoneNum" runat="server" class="input_reg"   />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("ContactAddress")%>：
                        </label>
                        <div class="field">
                            <input name="txtAddress" type="text" id="txtAddress" runat="server" class="input_reg" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="action">
                <asp:Button ID="btnSubmit" runat="server" class="btn" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </form>
</body>
</html>
