<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registers1.aspx.cs" Inherits="Web.Registers1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <%=GetLanguage("registration")%>
    </title>
    <link href="../../static/css/style.css?1" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#txtUserCode").val(" ");
            $("#txtUserCode").click(function () {
                $(this).val("");
            })
            $("#ddlQuestion").change(function () {
                $("#txtAnswer").val("");
            });
        })

        function hidd() {
            var value;
            var level = document.getElementById("dropLevel");
            //获取选中的城市名称
            for (i = 0; i < level.length; i++) {
                if (level[i].selected == true) {
                    value = level[i].value; //关键点
                }
            }
            if (value > 4) {
                $("#agentArea").show();
            } else {
                $("#agentArea").hide();
            }
            if (value > 1) {
                $("#Shop").show();
                $("#djq").hide();
            } else {
                $("#Shop").hide();
                $("#djq").show();
            }

        }
    </script>
    <style type="text/css">
        .style1 {
            height: 30px;
        }
    </style>
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
                            <span style="color: #f00;">*</span><%=GetLanguage("MembershipNumber")%><!--会员编号-->：
                        </label>
                        <div class="field">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="boxx"  />&nbsp;<asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" class="btn" Width="80px" />&nbsp;&nbsp;
                                    <asp:Button ID="btnValidate" runat="server" OnClick="btnValidate_Click" class="btn" Width="80px" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("ShopPassword")%>：<!--登陆密码-->
                        </label>
                        <div class="field">
                            <input name="txtPassword" type="password" id="txtPassword" runat="server" class="input_reg"
                                value="1"  />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("ConfirmPass")%>：<!--确认密码-->
                        </label>
                        <div class="field">
                            <input name="txtRegPassword" type="password" id="txtRegPassword" runat="server" class="input_reg"
                                value="1"  />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("SecondPassword")%><!--二级密码-->：
                        </label>
                        <div class="field">
                            <input name="txtSecondPassword" type="password" id="txtSecondPassword" runat="server" class="input_reg"
                                value="1"  />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("ConfirmPass")%>：
                        </label>
                        <div class="field">
                            <input name="txtRegSecondPassword" type="password" id="txtRegSecondPassword" runat="server" class="input_reg"
                                value="1"  />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("ThreePassword")%><!--三级密码-->:
                        </label>
                        <div class="field">
                            <input name="txtThreePassword" type="password" id="txtThreePassword" runat="server" class="input_reg"
                                value="1"  />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("ConfirmPass")%>：
                        </label>
                        <div class="field">
                            <input name="txtRegThreePassword" type="password" id="txtRegThreePassword" runat="server" class="input_reg"
                                value="1"  />
                        </div>
                    </div>
                </div>
            </div>
            <h6><%=GetLanguage("NetworkInformation")%>：</h6>
            <div class="row-fluid">
                <div class="span6">
                       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("MembershipLevels")%>：
                        </label>
                        <div class="field">
                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                <asp:ListItem Value="0">体验会员</asp:ListItem>
                                <asp:ListItem Value="1">一星会员</asp:ListItem>
                                <asp:ListItem Value="2">二星会员</asp:ListItem>
                                <asp:ListItem Value="3">三星会员</asp:ListItem>
                            </asp:DropDownList>
                         <%--   <input name="txtLevel" type="text" id="txtLevel" runat="server" class="input_reg" disabled="disabled" />--%>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("RegistrationAmount")%>：
                        </label>
                        <div class="field">
                            <input name="txtRegMoney" type="text" id="txtRegMoney" runat="server" disabled="disabled" class="input_reg1"  />
                        </div>
                    </div> 
                                    </ContentTemplate>
                            </asp:UpdatePanel> 
                    <div class="control-group"  >
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("Agent") %>：
                        </label>
                        <div class="field">
                            <input name="txtAgentCode" type="text" id="txtAgentCode" runat="server" class="input_reg"  />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("ReferenceNumber")%>：
                        </label>
                        <div class="field">
                            <input name="txtRecommendCode" type="text" id="txtRecommendCode" runat="server" disabled="disabled" class="input_reg"  />
                        </div>
                    </div>
                       <div class="control-group"  >
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("Placement")%>：
                        </label>
                             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                        <div class="field">
                            <input name="txtParentCode" type="text" id="txtParentCode" runat="server" class="input_reg"  />
                        </div>
                                    </ContentTemplate>
                                 </asp:UpdatePanel>
                    </div>
                    <div class="control-group" style="display:none">
                        <label for="memid">
                            <%--<span style="color: #f00;">*</span>--%><%--<%=GetLanguage("ReferenceNumber")%>：--%>
                            请选择缴费方式：
                        </label>
                        <div class="field">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Selected="True" Value="1">全额现金积分</asp:ListItem>
                                <asp:ListItem Value="2">44%现金积分+56%报单积分</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div class="control-group">
                        <label for="memid">
                            <%--<span style="color: #f00;">*</span>--%><%--<%=GetLanguage("ReferenceNumber")%>：--%>
                          <span style="color: #f00">*</span><%=GetLanguage("Registration")%><!--区域-->：
                        </label>
                           <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                        <div class="field">

                            <asp:RadioButton ID="radMarketOne" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged"   />1<%=GetLanguage("Market")%>
                             <asp:RadioButton ID="radMarketTwo" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton2_CheckedChanged"   />2<%=GetLanguage("Market")%>


                           <%--<input id="radMarketOne" type="radio"   name="Market" runat="server" />
                            1
                            <%=GetLanguage("Market")%><!--市场--> 
                            <input id="radMarketTwo" type="radio"   name="Market" runat="server" />
                            2
                            <%=GetLanguage("Market")%><!--市场-->--%>
                        </div>
                                    </ContentTemplate>
                               </asp:UpdatePanel>
                    </div> 
                </div>
            </div>
            <h6><%=GetLanguage("Banking")%>：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;"></span><%=GetLanguage("Depositary") %>：
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
                            <span style="color: #f00;"></span><%=GetLanguage("BankBranch")%>：
                        </label>
                        <div class="field">
                            <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="input_reg"  />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;"></span><%=GetLanguage("BankAccount")%>：
                        </label>
                        <div class="field">
                            <input name="txtBankAccount" type="text" id="txtBankAccount" runat="server" class="input_reg" value="" maxlength="19"  />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;"></span><%=GetLanguage("AccountName")%>：
                        </label>
                        <div class="field">
                            <input name="txtBankAccountUser" type="text" id="txtBankAccountUser" runat="server" class="input_reg"   />
                        </div>
                    </div>
                </div>
            </div>
            <h6><%=GetLanguage("Basic")%>：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;"></span><%=GetLanguage("Name")%>：
                        </label>
                        <div class="field">
                            <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="input_reg"   />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;"></span><%=GetLanguage("IDNumber")%>：
                        </label>
                        <div class="field">
                            <input name="txtIdenCode" type="text" id="txtIdenCode" runat="server" class="input_reg"  />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;"></span><%=GetLanguage("ContactPhone")%>：
                        </label>
                        <div class="field">
                            <input name="txtPhoneNum" type="text" id="txtPhoneNum" runat="server" class="input_reg"  />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;"></span><%=GetLanguage("ContactAddress")%>：
                        </label>
                        <div class="field">
                            <input name="txtAddress" type="text" id="txtAddress" runat="server" class="input_reg"  />
                        </div>
                    </div>
                    <div class="control-group" style="display:none">
                        <label for="memid">
                            <span style="color: #f00;"></span><%=GetLanguage("QQNumber")%>：
                        </label>
                        <div class="field">
                            <input name="txtQQnumer" type="text" id="txtQQnumer" runat="server" class="input_reg"  />
                        </div>
                    </div>
                    <div class="control-group" style="display:none">
                        <label for="memid">
                            <%=GetLanguage("Email")%>：
                        </label>
                        <div class="field">
                            <input name="txtEmail" type="text" id="txtEmail" runat="server" class="input_reg"  />
                        </div>
                    </div>
                         <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("Secret")%>：
                        </label>
                        <div class="field">
                             <asp:DropDownList ID="dropQuestion" runat="server">
                                            <asp:ListItem Value="0">请选择</asp:ListItem>
                                            <asp:ListItem Value="1">您的姓名是？</asp:ListItem>
                                            <asp:ListItem Value="2">您的家乡是？</asp:ListItem>
                                            <asp:ListItem Value="3">您最敬佩的人是？</asp:ListItem>
                                        </asp:DropDownList>
                            
                        </div>
                         </div>
                         <div class="control-group">
                        <label for="memid">
                            <span style="color: #f00;">*</span><%=GetLanguage("answer")%>：
                        </label>
                        <div class="field">
                            <input name="txtAddress" type="text" id="daan" runat="server" class="input_reg" />
                        </div>
                    </div>

                </div>
            </div>
            <div>  
                    </div>
            <div >
                <asp:Button ID="btnSubmit" runat="server" class="btn" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </form>
</body>
</html>
