<%@ Page Title="" Language="C#" MasterPageFile="~/user/shop/InsideSite.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="Web.user.shop.Article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        section, figure, aside {
            padding: 0;
            margin: 0;
            border: none;
        }
        /*---common---*/
        .art_box {
            border: solid 1px #dddddd;
        }

        .art_title {
            height: 30px;
            line-height: 30px;
            padding: 0 10px;
            border-bottom: solid 1px #dddddd;
            background-color:#a10000;
            /*background: url(/images/art_new.png) 0px 0px repeat-x;*/
            font-size: 12px;
        }
        /*---main---*/
        section.art_main {
            height: auto;
            margin-top: 10px;
        }
        /*aside nav*/
        aside.art_nav {
            width: 198px;
            height: auto;
        }

        aside h2 {
            color: #c5c5c5;
        }

        span.aside_txt {
            font-size: 15px;
            color: #000000;
        }

        aside section {
            height: auto;
            padding: 10px;
        }

            aside section dl {
                padding-bottom: 10px;
            }

                aside section dl dt, aside section dl dd {
                    padding: 0 10px;
                    overflow: hidden;
                }

                aside section dl dt {
                    height: 20px;
                    padding: 5px 10px;
                    border-bottom: dotted 1px #d7d7d7;
                }

        span.dt_ico, span.dt_txt {
            display: inline-block;
            float: left;
        }

        span.dt_ico {
            width: 16px;
            height: 16px;
            margin: 2px 0;
            overflow: hidden;
            background-color:#a10000;
            /*background: url(/images/art_new.png) no-repeat;*/
        }

        span.dt_txt {
            line-height: 20px;
            padding-left: 10px;
            font-size: 14px;
            font-weight: bold;
            color: #444444;
        }

        .art_ico1 {
            background-position: 0px -93px!important;
        }

        .art_ico2 {
            background-position: -16px -93px!important;
        }

        .art_ico3 {
            background-position: -32px -93px!important;
        }

        .art_ico4 {
            background-position: -48px -93px!important;
        }

        aside section dl dd {
            height: 20px;
            line-height: 20px;
            margin-top: 5px;
        }

            aside section dl dd a, aside section dl dd a:hover {
                display: block;
                height: 20px;
                line-height: 20px;
                padding-left: 18px;
                /*background-color:#a10000;*/
                background: url(/images/art_new.png);
                text-decoration: none;
                overflow: hidden;
            }

            aside section dl dd a {
                background-position: 0px -30px;
                color: #666666;
            }

                aside section dl dd a:hover {
                    background-position: 0px -50px;
                    color: #ffffff!important;
                }

            aside section dl dd .current {
                color: #a10000!important;
            }
        /*aside content*/
        .art_content {
            width: 760px;
            height: auto;
            line-height: 24px;
            border: 1px solid #ebebeb;
        }

            .art_content h2, .art_content h2 a {
                color: #777777;
            }

            .art_content article {
                padding: 20px;
            }

        .art_header {
            height: 23px;
            padding: 5px 0 10px;
            border-bottom: dotted 1px #d5d5d5;
            margin-bottom: 15px;
        }

            .art_header span {
                display: inline-block;
                float: left;
            }

        span.header_box {
            height: 23px;
        }

        span.header_txt, span.header_space {
            height: 22px;
            line-height: 22px;
            padding-bottom: 1px;
            background-color:#a10000;
            /*background: url(/images/art_new.png) repeat-x;*/
        }

        span.header_txt {
            background-position: 0px -70px;
            padding-left: 15px;
            font-size: 15px;
            font-weight: bold;
            color: #ffffff;
        }

        span.header_space {
            background-position: right -93px;
            width: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="art_main w clearfix">
  <aside class="art_nav art_box clearfix Left">
    <h2 class="art_title"><span class="header_txt">客服中心</span> SERVICE</h2>
    <section id="JS_silde_menu">
	      <dl>
                <dt><span class="dt_ico art_ico1"></span><span class="dt_txt">关于MDD易购</span></dt>
                <asp:Repeater runat="server" ID="Repeater_About" >
                    <ItemTemplate>
		                <dd><a href="article.aspx?id=<%#Eval("ID") %>" title="<%#Eval("NewsTitle") %>"><%#Eval("NewsTitle") %></a></dd>
                    </ItemTemplate>
                </asp:Repeater>
		  </dl>
	      <dl>
                <dt><span class="dt_ico art_ico2"></span><span class="dt_txt">新手指南</span></dt>
		        <asp:Repeater runat="server" ID="Repeater_Guide" >
                    <ItemTemplate>
		                <dd><a href="article.aspx?id=<%#Eval("ID") %>" title="<%#Eval("NewsTitle") %>"><%#Eval("NewsTitle") %></a></dd>
                    </ItemTemplate>
                </asp:Repeater>
		  </dl>
	      <dl>
                <dt><span class="dt_ico art_ico3"></span><span class="dt_txt">配送安装</span></dt>
		        <asp:Repeater runat="server" ID="Repeater_Build" >
                    <ItemTemplate>
		                <dd><a href="article.aspx?id=<%#Eval("ID") %>" title="<%#Eval("NewsTitle") %>"><%#Eval("NewsTitle") %></a></dd>
                    </ItemTemplate>
                </asp:Repeater>
		  </dl>
	      <dl>
          <dt><span class="dt_ico art_ico4"></span><span class="dt_txt">售后服务</span></dt>
		        <asp:Repeater runat="server" ID="Repeater_Service" >
                    <ItemTemplate>
		                <dd><a href="article.aspx?id=<%#Eval("ID") %>" title="<%#Eval("NewsTitle") %>"><%#Eval("NewsTitle") %></a></dd>
                    </ItemTemplate>
                </asp:Repeater>
		  </dl>
	      <dl>
          <dt><span class="dt_ico art_ico5"></span><span class="dt_txt">购物保障</span></dt>
		        <asp:Repeater runat="server" ID="Repeater_security" >
                    <ItemTemplate>
		                <dd><a href="article.aspx?id=<%#Eval("ID") %>" title="<%#Eval("NewsTitle") %>"><%#Eval("NewsTitle") %></a></dd>
                    </ItemTemplate>
                </asp:Repeater>
		  </dl>
	        
    </section>
  </aside>
  <section class="art_content clearfix Right">
    <h2 class="art_title">
        <header class="art_header"> 
            <span class="header_box"> 
                <span class="header_txt"><asp:Label ID="lbTitle" runat="server" Text="" Font-Size="Large"></asp:Label></span> 
                <span class="header_space"></span> 
            </span> 
        </header>
    </h2>
    <article >
        <div class="infomoreText">
        <asp:Literal ID="lilContent" runat="server"></asp:Literal>
        </div>
    </article>
  </section>
</section>
</asp:Content>
