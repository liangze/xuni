﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=getParamVarchar("SystemName2")%></title>
    <link href="static/css/login.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="JS/jquery-1.7.1.min.js"></script>
    <script src="js/login.js?v=1.0" type="text/javascript"></script>
    <style type="text/css">
        a.apk {
            font-weight: bold;
            font-size: 18px;
            width: 100%;
            text-align: center;
            display: block;
            margin-top: 20px;
            background-color: rgba(0,0,0,0.5);
            padding: 15px;
            border: 1px solid rgba(0,0,0,0.7);
            border-radius: 5px;
        }

            a.apk * {
                vertical-align: middle;
                margin-right: 10px;
            }

            a.apk img {
                width: 15%;
            }

        .backdiv {
            width: 500px;
            overflow: hidden;
            border: 6px solid #ccc;
            padding: 15px;
            position: absolute;
            z-index: 400;
            background-color: #fff;
            display: none;
        }
    </style>
    <style type="text/css">
        .fancybox-margin {
            margin-right: 0px;
        }
    </style>
    <script type="text/javascript">
        String.prototype.Trim = function () {
            return this.replace(/(^\s*)|(\s*$)/g, "");
        }

        function ed(id) { return document.getElementById(id); }

        function CheckText() {
            if (ed("TBUserName").value.Trim() == "") {
                alert("请输入账号！");
                ed("TBUserName").focus();
                ed("checkCode").src = $("checkCode").src;
                return false;
            }
            if (ed("TBPassWord").value.Trim() == "") {
                alert("请输入密码！");
                ed("TBPassWord").focus();
                ed("checkCode").src = $("checkCode").src;
                return false;
            }
            if (ed("TBCode").value.Trim() == "") {
                alert("请输入验证码！");
                ed("TBCode").focus();
                ed("checkCode").src = $("checkCode").src + "?";
                return false;
            }
            if (ed("checkCode").length < 4) {
                alert("请认真检查验证码是否输入完整！");
                ed("checkCode").focus();
                ed("checkCode").src = $("checkCode").src + "?";
                return false;
            }
            return true;
        }
    </script>
</head>
<body style="min-height: 932px;">
    <div class="login main_container" style="height: 900px; padding-top: 50px;">
        <div class="header clearfix">
            <div class="header-img">
                <div class="logo">
                    <h1></h1>
                </div>
                <!--end of logo-->
            </div>
        </div>
        <div class="right_content" style="left: 270px;">
            <h2>
                <img alt="" src="static/img/ico_lock.png" width="35" />会员登录 <small class="pull-right" style="font-size: 12px;"></small></h2>
            <div class="panel">
                <form class="stdform" id="Form1" name="colorform" runat="server">
                    <div class="row-fluid">
                        <div class="span8">
                            <div class="control-group">
                                <label for="email">登录用户名</label>
                                <div class="field">
                                    <input id="TBUserName" name="TBUserName" class="required" type="text" aria-required="true" runat="server" />
                                </div>
                            </div>
                            <!--end of control group-->
                            <div class="control-group">
                                <label for="password">密码</label>
                                <div class="field">
                                    <input id="TBPassWord" name="TBPassWord" class="required" type="password" aria-required="true" runat="server" />
                                    <div class="desc"><a href="javascript:void(0)" class="thickbox">忘记密码</a></div>
                                </div>
                            </div>
                            <!--end of control group-->
                            <div class="control-group">
                                <label for="password">语言</label>
                                <div class="field">
                                    <select name="locale" onchange="window.location.href='loginen.aspx';" aria-invalid="false" class="valid">
                                        <option value="en_us">English</option>
                                        <option value="zh_cn" selected="selected">中文</option>
                                    </select>
                                </div>
                            </div>
                            <!--end of control group-->
                            <div class="control-group">
                                <label for="catcha">&nbsp;</label>
                                <div class="field">
                                    <input type="image" id="checkCode" style="width: 280px; height: 40px; border: 0px; /*background: 0;*/ cursor: pointer;" onclick="createCode();" />
                                </div>
                            </div>
                            <!--end of control group-->
                            <div class="control-group">
                                <label for="catcha">验证码</label>
                                <div class="field">
                                    <input id="TBCode" name="TBCode" class="required" type="text" autocomplete="off" size="7" aria-required="true" runat="server" />
                                </div>
                            </div>
                            <!--end of control group-->
                            <div class="control-group action">
                                <asp:Button ID="btnLogin" runat="server" TabIndex="4" class="btn" OnClientClick="return CheckText();" OnClick="btnLogin_Click" Text="提交" />
                            </div>
                        </div>
                        <div class="span4">
                            <p>
                                <img alt="" src="static/img/570LOGO-CN.png" style="margin-top: 60px; margin-bottom: 97px; margin-left: 35px;" />
                            </p>
                        </div>
                        <!--end of span6-->
                        <div class="action">
                        </div>
                        <!--end of stdform-->
                    </div>
                    <div class="backdiv">
                        <a style="position: relative; top: -10px; left: 315px; color: Gray;" href="javascript:void(0)"
                            id="cle">关闭</a>
                        <div class="backinput">
                            <table>
                                <tr>
                                    <td align="right">
                                        <span id="UserName">用户名</span>：
                                    </td>
                                    <td class="winput">
                                        <asp:TextBox ID="txtUserCode" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <span id="question">密保问题</span>：
                                    </td>
                                    <td class="winput">
                                        <asp:DropDownList ID="dropQuestion" runat="server">
                                            <asp:ListItem Value="0">请选择</asp:ListItem>
                                            <asp:ListItem Value="1">您的姓名是？</asp:ListItem>
                                            <asp:ListItem Value="2">您的家乡是？</asp:ListItem>
                                            <asp:ListItem Value="3">您最敬佩的人是？</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="dropQuestionEn" runat="server" Style="display: none;">
                                            <asp:ListItem Value="0">Please select</asp:ListItem>
                                            <asp:ListItem Value="1">Your name is?</asp:ListItem>
                                            <asp:ListItem Value="2">Your home is?</asp:ListItem>
                                            <asp:ListItem Value="3">People you admire are?</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <span id="anwers">密保答案</span>：
                                    </td>
                                    <td class="winput">
                                        <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right"></td>
                                    <td class="btns">
                                        <input id="btnConfirm" type="button" value=" 确认 " style="width: 100px; height: 30px;"
                                            onclick="checkinput()" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </form>
                <!--end of login area-->
            </div>
            <!--end of right content-->
            <div class="footer">
                <p>Copyright © 2015 CPM. All rights reserved.</p>
            </div>
            <!--end of main container-->
        </div>
    </div>
</body>
</html>
