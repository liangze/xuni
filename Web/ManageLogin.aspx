<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageLogin.aspx.cs" Inherits="Web.ManageLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>登录</title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="js/login1.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function replace(o) {
            var obj = document.getElementById(o)
            if (obj.value != "") {
                obj.value == "";
            }
        }
        $(document).ready(function () {
            cleartip();
            $("#txtPwd").focus(function () {
                $("#pwd_tip").html("");
            }).blur(function () {
                var tip = $("#pwd_tip").html();
                var txtpwd = $("#txtPwd").val();
                if (txtpwd == "") {
                    $("#pwd_tip").html("密码");
                }
            });

            $("#txtUserName").focus(function () {
                $("#user_tip").html("");
            }).blur(function () {
                var tip = $("#user_tip").html();
                var txtpwd = $("#txtUserName").val();
                if (txtpwd == "") {
                    $("#user_tip").html("用户名");
                }
            });

            $("#txtVa").focus(function () {
                $("#Va_tip").html("");
            }).blur(function () {
                var tip = $("#Va_tip").html();
                var txtpwd = $("#txtVa").val();
                if (txtpwd == "") {
                    $("#Va_tip").html("验证码");
                }
            });


        });


        function ssss(t, v) {
            $("#" + t).html("");
            $("#" + v).focus();

        }


        function cleartip() {

            if ($("#txtPwd").val() != "") {

                $("#pwd_tip").html("");
            }
            if ($("#txtUserName").val() != "") {
                $("#user_tip").html("");
            }
            if ($("#txtVa").val() != "") {
                $("#Va_tip").html("");
            }

        }
        //    $('.loginin').focus(function () {
        //        if ($(this).attr("title") == this.value) { this.value = ''; }
        //    })
        //    $('.loginin').focusout(function () {
        //        if ($(this).val().length == 0) {
        //            $(this).val($(this).attr("title")); $(this).removeClass('dan');
        //        } else { $(this).addClass('dan'); }
        //    })
    </script>

</head>
<body onload="createCode()" bgcolor="#fffcda">
    <form id="Form1" name="colorform" runat="server">
        <div id="big_box">
            <%--<div class="logo"><img src="../images/logo.png" width="445" height="70" /></div> --%>
            <%--<span id="pwd_tip" onclick="ssss('pwd_tip','txtPwd')" style=" position: absolute; top: 307px; z-index:5; 
                right: 613px;" >密码</span>
      <span id="user_tip"  onclick="ssss('user_tip','txtUserName')"  style=" position: absolute; top: 257px; right: 600px; z-index:5; ">用户名</span>
       <span id="Va_tip"  onclick="ssss('Va_tip','txtVa')"  style=" position: absolute; top: 356px; right: 600px; z-index:5; ">验证码</span>--%>
            <div class="loginbox">
                <table class="tb" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="title">账&nbsp;&nbsp;号
                        </td>
                        <td>
                            <input class="loginin" id="txtUserName" runat="server" type="text" value="" onfocus="this.value=''" onblur="if(!value){value=defaultValue;}" /></td>
                    </tr>
                    <tr>
                        <td class="title">密&nbsp;&nbsp;码
                        </td>
                        <td>
                            <input class="loginin" id="txtPwd" runat="server" type="password" /></td>
                    </tr>
                    <tr>
                        <td class="title">验证码
                        </td>
                        <td>
                            <input class="loginvadate" id="txtVa" runat="server" type="text" value="" onfocus="this.value=''"
                                onblur="if(!value){value=defaultValue;}" />&nbsp;</td>
                        <td>
                            <input type="text" readonly="readonly" id="checkCode" readonly="readonly" value="7878" onclick="createCode()" /></td>
                    </tr>
                    <tr>
                        <td class="title"></td>
                        <td>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/login99.gif"
                                OnClick="ImageButton1_Click" OnClientClick="return validate()" />
                        </td>
                    </tr>
                    <%--        <tr>
        <td>忘记密码？<a href="#" style=" text-decoration:none; color:#FF6C13;">找回密码</a></td>
        </tr>--%>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
