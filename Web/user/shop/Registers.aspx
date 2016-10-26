<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registers.aspx.cs" Inherits="Web.user.shop.Registers" %>

<%@ Register Src="ShopHead.ascx" TagName="ShopHead" TagPrefix="uc1" %>
<%@ Register Src="shopSlider.ascx" TagName="shopSlider" TagPrefix="uc2" %>
<%@ Register Src="Foot.ascx" TagName="Foot" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会员注册</title>
    <link href="../../style/Shop.css" rel="stylesheet" type="text/css" />
    <%--    <link href="../../style/css.css" rel="Stylesheet" type="text/css" />--%>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <style type="text/css">
        .cRed
        {
            color: Red;
        }
    </style>
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
    </script>
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
    </style>
</head>
<body>
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="Header">
        <!--nav begin-->
        <uc1:ShopHead ID="ShopHead1" runat="server" />
        <!--nav end-->
    </div>
    <div class="ShopBody">
        <div class="slider">
            <!--slider begin-->
            <uc2:shopSlider ID="shopSlider1" runat="server" />
            <!--slider end-->
        </div>
        <div class="rightBox">
            <div class="box box_width">
                <div class="dataTable">
                    <fieldset class="fieldset">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                            <tr>
                                <td width="200" align="right">
                                    <h1>
                                        登录资料：</h1>
                                </td>
                                <td align="left">
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>会员编号：
                                </td>
                                <td align="left">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <input name="jd" type="text" id="txtUserCode" runat="server" class="input_reg" />
                                            &nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="生成编号"
                                                class="btn" />
                                            <asp:Button ID="Button2" runat="server" Text="检测账号" class="btn" OnClick="Button2_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>登陆密码：
                                </td>
                                <td align="left">
                                    <input name="jd" type="password" id="txtPassword" runat="server" class="input_reg"
                                        value="1" />
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>确认密码：
                                </td>
                                <td align="left">
                                    <input name="jd" type="password" id="txtRegPassword" runat="server" class="input_reg"
                                        value="1" />
                                </td>
                            </tr>
                            <%--<tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>省份：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownList3" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>二级密码：
                                </td>
                                <td align="left">
                                    <input name="jd" type="password" id="txtSecondPassword" runat="server" class="input_reg"
                                        value="1" />
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>确认密码：
                                </td>
                                <td align="left">
                                    <input name="jd" type="password" id="txtRegSecondPassword" runat="server" class="input_reg"
                                        value="1" />
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>三级密码：
                                </td>
                                <td align="left">
                                    <input name="jd" type="password" id="txtThreePassword" runat="server" class="input_reg"
                                        value="1" />
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>确认密码：
                                </td>
                                <td align="left">
                                    <input name="jd" type="password" id="txtRegThreePassword" runat="server" class="input_reg"
                                        value="1" />
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
                                        网络资料：</h1>
                                </td>
                                <td align="left">
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>会员级别：
                                </td>
                                <td align="left">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="dropLevel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropLevel_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right" class="style1">
                                    <span class="cRed">*</span>注册金额：
                                </td>
                                <td align="left" class="style1">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <input name="txtRegMoney" type="text" id="txtRegMoney" runat="server" disabled="disabled"
                                                class="input_reg1" /><%=GetLanguage("USD")%><%--元--%>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                </td>
                                <td align="left">
                                    <table style="display:none;">
                                        <tr>
                                            <td width="200" align="right">
                                                <span class="cRed">*</span>代理中心编号：
                                            </td>
                                            <td align="left">
                                                <input name="jd" type="text" id="txtAgentCode" runat="server" class="input_reg" visible="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="200" align="right">
                                                <span class="cRed">*</span>推荐人编号：
                                            </td>
                                            <td>
                                                <input name="jd" type="text" id="txtRecommendCode" runat="server" class="input_reg" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="200" align="right">
                                                <span class="cRed">*</span>安置会员编号：
                                            </td>
                                            <td align="left">
                                                <input name="jd" type="text" id="txtParentCode" runat="server" class="input_reg" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="200" align="right">
                                                <span class="cRed">*</span>注册区域：
                                            </td>
                                            <td align="left">
                                                <input id="Radio1" type="radio" name="qy" runat="server" checked="true" />
                                                1市场&nbsp;&nbsp;&nbsp;&nbsp;
                                                <input id="Radio2" type="radio" name="qy" runat="server" />
                                                2市场
                                            </td>
                                        </tr>
                                    </table>
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
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="dropBank" runat="server">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="dropProvince" runat="server">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>银行支行：
                                </td>
                                <td align="left">
                                    <input name="jd" type="text" id="txtBankBranch" runat="server" class="input_reg"
                                        value="" />
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>银行卡号：
                                </td>
                                <td align="left">
                                    <input name="jd" type="text" id="txtBankAccount" maxlength="19" runat="server" value=""
                                        class="input_reg" />
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>开户名：
                                </td>
                                <td align="left">
                                    <input name="jd" type="text" id="txtBankAccountUser" runat="server" class="input_reg"
                                        value="" />
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
                                    <input name="jd" type="text" id="txtTrueName" runat="server" class="input_reg" value="" />
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
                                    <input name="jd" type="text" id="txtIdenCode" runat="server" class="input_reg" maxlength="18"
                                        value="" />
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    联系电话：
                                </td>
                                <td align="left">
                                    <input name="jd" type="text" id="txtPhoneNum" runat="server" value="" class="input_reg" />
                                </td>
                            </tr>
                            <tr id="trAddress">
                                <td width="200" align="right" class="style1">
                                    <span class="cRed">*</span>联系地址：
                                </td>
                                <td align="left" class="style1">
                                    <input name="jd" type="text" id="txtAddress" runat="server" class="input_reg" />
                                </td>
                            </tr>
                            <tr>
                                <td width="200" align="right">
                                    <span class="cRed">*</span>密保答案：
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlQuestion" runat="server">
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
                                    <asp:TextBox ID="txtAnswer" runat="server" TextMode="Password"></asp:TextBox>
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
                            <%--                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>--%>
                            <%--    <tr>
                        <td width="200" align="right">
                            联系地址：
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownList4" runat="server" class="" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownList5" runat="server" class="">
                                        <asp:ListItem Value="请选择">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtAddress" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            Email：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtEmail" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
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
                            <%--                            <tr>
                                <td width="200" align="right">
                                </td>
                                <td align="left">
                                </td>
                            </tr>--%>
                            <%--                            <tr>
                                <td width="200" align="right">
                                    <h1>
                                        <span class="cRed">*</span>激活方式：</h1>
                                </td>
                                <td align="left">
                                    <input id="rdHK" type="radio" name="jh" runat="server" />
                                    银行汇款&nbsp;&nbsp;&nbsp;&nbsp;
                                    <input id="rdZX" type="radio" name="jh" runat="server" />
                                    在线激活
                                </td>
                            </tr>--%>
                            <tr>
                                <td width="200" align="right">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnSubmit" runat="server" Text="提 交" class="btn" OnClick="btnSubmit_Click" />
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <uc3:Foot ID="Foot1" runat="server" />
    </form>
</body>
</html>
