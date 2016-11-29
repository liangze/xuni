<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
       <meta content="width=device-width, initial-scale=1, maximum-scale=1" name="viewport" />
    <title>故乡云商</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="css/datepicker.css" />
    <link rel="stylesheet" href="css/uniform.css" />
    <link rel="stylesheet" href="css/maruti-style.css" />
    <link rel="stylesheet" href="css/maruti-media.css" class="skin-color" />
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <script type="text/javascript" src="JS/jquery-1.7.1.min.js"></script>
    <script src="js/login.js?v=1.0" type="text/javascript"></script>
    <style type="text/css">
        body {
            /*background: url("img/loginBg.png");*/
              background: url("img/Login_11.jpg");
        }

        #top {
            height: 50px;
        }

        #content {
            background: none;
            min-height: auto;
            max-width: 610px;
            margin-top: 40px;
        }

        .widget-box {
            border: 2px solid #950101;
            background: rgba(255,255,255,.3);
        }

        .form-actions {
            background: rgba(255,255,255,.3);
            border: none;
        }

        .widget-title {
            background: none;
            border: none;
            height: auto;
            padding-bottom: 15px;
        }

            .widget-title span.icon {
                font-size: 24px;
                color: #950101;
                float: none;
                display: block;
                margin: 10px;
            }

            .widget-title h5 {
                float: none;
                margin: 0 60px;
                border-bottom: 4px solid #950101;
                text-align: center;
                font-size: 30px;
                color: #000;
                padding-bottom: 25px;
                font-weight: normal;
            }

        .widget-content label {
            font-size: 18px;
            color: #333;
        }

        .widget-content img {
            height: 30px;
            vertical-align: top;
        }

        .form-horizontal .control-group {
            border: none;
            padding-bottom: 5px;
        }

        .btnsubmit {
            background: #950101;
            color: #fff;
            margin: 10px auto;
            display: block;
            width: 45%;
            height: 40px;
            font-size: 16px;
            text-shadow: none;
        }

            .btnsubmit:hover {
                background: #da4f49;
                color: #fff;
            }
    </style>
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
     <script type="text/javascript" src="JS/jquery-1.7.1.min.js"></script>
    <script src="../js/login.js?v=1.0" type="text/javascript"></script>
</head>
<body>
   
    <div id="top"></div>
    <div id="content">
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <!--content start-->
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon">登录</span>
                            <h5>管理系统</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <form id="form1" runat="server" class="form-horizontal">
                                <asp:Panel runat="server" ID="Panel1" DefaultButton="btnLogin">
                                    <div class="control-group">
                                        <label class="control-label">账号：</label>
                                        <div class="controls">
                                            <input id="TBUserName" name="TBUserName" type="text" class="span9" placeholder="请输入账号" aria-required="true" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">密码：</label>
                                        <div class="controls">

                                            <input id="TBPassWord" name="TBPassWord" class="span9" type="password" placeholder="请输入密码" aria-required="true" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">验证码：</label>
                                        <div class="controls">

                                            <input id="TBCode" name="TBCode" class="span6" type="text" autocomplete="off" size="7" aria-required="true" runat="server" />

                                            <input type="image" id="checkCode" style="width: 101px; height: 32px; border: 0px; /*background: 0; */ cursor: pointer;" onclick="createCode();" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls"><a href="javascript:void(0)" class="thickbox">忘记密码?</a></div>
                                    </div>
                                    <div class="control-group">

                                        <asp:Button ID="btnLogin" runat="server" Style="background: #950101; color: #fff; margin: 10px auto; display: block; width: 45%; height: 40px; font-size: 16px; text-shadow: none;"
                                            OnClick="btnLogin_Click" Text="提交" />
                                    </div>
                                </asp:Panel>
                                <div class="backdiv" style="left:0px">
                        <a style="position: relative; top: -10px; left: 315px; color: Gray;" href="javascript:void(0)"
                            id="cle">关闭</a>
                        <div class="backinput" >
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
                                       <%-- <input id="btnConfirm" type="button" value=" 确认 " style="width: 100px; height: 30px;" runat="server"
                                           onclick="btnLogin_Click"/>--%>
                                        <asp:Button ID="Button1" runat="server" Text="确认" style="width: 100px; height: 30px;  " OnClick="btnLogin_Click1" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                            </form>
                        </div>
                    </div>
                    <!--content over-->
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery.min.js"></script>
    <script src="js/jquery.uniform.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrap-datepicker.js"></script>
    <script src="js/maruti.js"></script>
        
    <%-- </form>--%>
       
</body>
    
   
</html>
