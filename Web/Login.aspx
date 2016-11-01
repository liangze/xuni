<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
            background: url("img/loginBg.png");
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
                                        <div class="controls"><a href="javascript:void(0)" class="btn">找回密码</a></div>
                                    </div>
                                    <div class="control-group">

                                        <asp:Button ID="btnLogin" runat="server" Style="background: #950101; color: #fff; margin: 10px auto; display: block; width: 45%; height: 40px; font-size: 16px; text-shadow: none;"
                                            OnClick="btnLogin_Click" Text="提交" />
                                    </div>
                                </asp:Panel>
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
