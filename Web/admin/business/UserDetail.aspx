<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="Web.admin.business.UserDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注册</title>
    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class="dataTable">
            <fieldset class="fieldset">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr>
                        <td width="200" align="right">
                            <h1>
                                登录资料：
                            </h1>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>会员编号：
                        </td>
                        <td align="left">
                            <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="input_reg" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>登陆密码：
                        </td>
                        <td align="left">
                            <input name="txtPassword" type="text" id="txtPassword" runat="server" class="input_reg" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>二级密码：
                        </td>
                        <td align="left">
                            <input name="txtSecondPassword" type="text" id="txtSecondPassword" runat="server" class="input_reg"
                                disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>三级密码：
                        </td>
                        <td align="left">
                            <input name="txtThreePassword" type="text" id="txtThreePassword" runat="server" class="input_reg"
                                disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <h1>
                                网络资料：
                            </h1>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>会员级别：
                        </td>
                        <td align="left">
                            <input name="txtLevel" type="text" id="txtLevel" runat="server" class="input_reg" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>注册金额：
                        </td>
                        <td align="left">
                            <input name="txtRegMoney" type="text" id="txtRegMoney" runat="server" disabled="disabled"
                                class="input_reg1" />
                        </td>
                    </tr>
                    <tr id="txtArea" runat="server" visible="false">
                        <td width="200" align="right">
                            <span class="cRed">*</span>代理区域：
                        </td>
                        <td align="left">
                            <input name="txtProvince" type="text" id="txtProvince" runat="server" class="input_reg" disabled="disabled" />
                            <input name="txtCity" type="text" id="txtCity" runat="server" class="input_reg" disabled="disabled" />
                            <input name="txtCountry" type="text" id="txtCountry" runat="server" class="input_reg" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>代理中心编号：
                        </td>
                        <td align="left">
                            <input name="txtAgentCode" type="text" id="txtAgentCode" runat="server" class="input_reg" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>推荐人编号：
                        </td>
                        <td align="left">
                            <input name="txtRecommendCode" type="text" id="txtRecommendCode" runat="server" class="input_reg"
                                disabled="disabled" />
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td width="200" align="right">
                            <span class="cRed">*</span>安置会员编号：
                        </td>
                        <td align="left">
                            <input name="txtParentCode" type="text" id="txtParentCode" runat="server" class="input_reg"
                                disabled="disabled" />
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td width="200" align="right">
                            <span class="cRed">*</span>注册区域：
                        </td>
                        <td align="left">
                            <input id="Radio1" type="radio" name="qy" runat="server" disabled="disabled" />
                            1市场&nbsp;&nbsp;&nbsp;&nbsp;
                            <input id="Radio2" type="radio" name="qy" runat="server" disabled="disabled" />
                            2市场
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <h1>
                                银行资料：</h1>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>开户银行：
                        </td>
                        <td align="left">
                            <%--
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>--%>
                            <asp:DropDownList ID="dropBank" runat="server">
                            </asp:DropDownList>
                            <asp:DropDownList ID="dropProvince" runat="server">
                            </asp:DropDownList>
                            <%--
                                <asp:DropDownList ID="DropDownList1" runat="server" class="">
                                    <asp:ListItem Value="请选择">请选择</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>银行支行：
                        </td>
                        <td align="left">
                            <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>银行账户：
                        </td>
                        <td align="left">
                            <input name="txtBankAccount" type="text" id="txtBankAccount" runat="server" class="input_reg"
                                value="" maxlength="19" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>开户名：
                        </td>
                        <td align="left">
                            <input name="txtBankAccountUser" type="text" id="txtBankAccountUser" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <%--<tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>财付通号：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtCaiCode" runat="server" class="input_reg" />
                    </td>
                </tr>
                <tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>财付通名：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtCaiName" runat="server" class="input_reg" />
                    </td>
                </tr>--%>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <h1>
                                基本资料：</h1>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>姓名：
                        </td>
                        <td align="left">
                            <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="input_reg" />
                        </td>
                    </tr>
<%--                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>昵称：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtNickName" runat="server" class="input_reg" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>身份证号：
                        </td>
                        <td align="left">
                            <input name="txtIdenCode" type="text" id="txtIdenCode" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            联系电话：
                        </td>
                        <td align="left">
                            <input name="txtPhoneNum" type="text" id="txtPhoneNum" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr id="trAddress">
                        <td width="200" align="right">
                            <span class="cRed">*</span>联系地址：
                        </td>
                        <td align="left">
                            <input name="txtAddress" type="text" id="txtAddress" runat="server" class="input_reg" />
                        </td>
                    </tr>
                                           <tr>
                        <td width="200" align="right">
                          <span class="cRed">*</span>电子邮箱：
                        </td>
                        <td align="left">
                            <input name="txtEmail" type="text" id="txtEmail" runat="server" class="input_reg" />
                        </td>
                    </tr>
                         <tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>Q Q号码：
                    </td>
                    <td align="left">
                        <input name="txtQQnumer" type="text" id="txtQQnumer" runat="server" class="input_reg" />
                    </td>
                </tr>
   <%--                  <tr>
                        <td width="200" align="right">
                           <span class="cRed">*</span>密保答案：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlQuestion" runat="server"  AutoPostBack="true"
                                onselectedindexchanged="ddlQuestion_SelectedIndexChanged">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                                <asp:ListItem Value="1">您的姓名是？</asp:ListItem>
                                <asp:ListItem Value="2">您的家乡是？</asp:ListItem>
                                <asp:ListItem Value="3">您最敬佩的人是？</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>密保答案：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAnswer" runat="server" class="input_reg"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <%--                <tr>
                    <td width="200" align="right">
                        Email：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtEmail" runat="server" class="input_reg" />
                    </td>
                </tr>--%>
                    <%--<tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>邮编号码：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtYouBian" runat="server" class="input_reg" />
                    </td>
                </tr>
                <tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>QQ号码：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtQQnumer" runat="server" class="input_reg" />
                    </td>
                </tr>--%>
<%--                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <h1>
                                <span class="cRed">*</span>激活方式：</h1>
                        </td>
                        <td align="left">
                            <input id="rdHK" type="radio" name="jh" runat="server" disabled="disabled" />
                            银行汇款&nbsp;&nbsp;&nbsp;&nbsp;
                            <input id="rdZX" type="radio" name="jh" runat="server" disabled="disabled" />
                            在线激活
                        </td>
                    </tr>--%>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSubmit" runat="server" Text="提 交" class="btn" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnUpdatePwd" runat="server" Text="重置密码" OnClientClick="javascript:return confirm('是否确定将密码充值为111111？')" class="btn" OnClick="btnUpdatePwd_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
