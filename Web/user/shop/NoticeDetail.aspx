<%@ Page Language="C#" MasterPageFile="~/user/shop/Index.Master" AutoEventWireup="true" CodeBehind="NoticeDetail.aspx.cs" Inherits="web.user.shop.NoticeDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/article.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- begin --%>

    <div id="subpage_nav" class="w">
        <div class="position">当前位置: <a href=".">首页</a> <code>&gt;</code> <a href="article_cat-9.html">商城公告</a> <code>&gt;</code><%=news.NewsTitle %></div>
    </div>
    <div class="w mt10 clearfix">
        <div class="sub_main clearfix">
            <div id="art_content" class="main">
                <h1 class="title"><%=news.NewsTitle %> </h1>
                <div class="bd_share_and_time clearfix">
                    <div class="note Left">来源：MDD易购商城&nbsp;&nbsp;  时间：<%=news.PublishTime %>&nbsp;&nbsp;</div>
                    <div class="share Right">
                        <!--
          <div id="bdshare" class="bdshare_t bds_tools get-codes-bdshare"> <span class="bds_more">分享到：</span> <a href="#" title="分享到QQ空间" class="bds_qzone"></a> <a href="#" title="分享到新浪微博" class="bds_tsina"></a> <a href="#" title="分享到腾讯微博" class="bds_tqq"></a> <a href="#" title="分享到人人网" class="bds_renren"></a> <a title="累计分享1次" href="#" class="shareCount">1</a> </div>
            -->
                    </div>
                </div>
                <!--
      <div class="summary"> <span class="daodu_ico"></span>
        <div></div>
        <p>关键字: </p>
      </div>
        -->

                <div class="content">
                    <%=news.NewsContent %>
                </div>
            </div>

            <ul class="art_page">
            </ul>

            <div class="art_relative">
                <div class="aTitle">最新文章</div>

                <ul class="clearfix clear">

                    <asp:Repeater ID="rpNews" runat="server">
                        <ItemTemplate>
                            <li><i>•</i><span><a target="_blank" href="NoticeDetail.aspx?id=<%# Eval("ID")%>" title="<%#Eval("NewsTitle")%>"><%#Eval("NewsTitle")%></a></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li id="trNull" runat="server">
                        <div class="NoData"><span class="cBlack"></span></div>
                    </li>

                </ul>
            </div>
            <div class="comment_info clear" style="display: none">
                <div class="aTitle">
                    <span>网友评论：</span>
                    <!--<span class="count">(共<em id="JS_total_page">0</em>条记录)</span>-->
                </div>
                <div class="body">
                    <div id="JS_comment_list">暂无评论 </div>
                    <div id="JS_comment_pager" data-id="9993" data-page="1" class="pager"></div>
                </div>
            </div>
            <div class="comment" style="display: none">
                <h3>我要发表评论：</h3>
                <textarea id="JS_art_content"></textarea>
                <div class="txtInfo"><strong>提示：</strong>你还可以输入<strong id="Js_txtInfo"></strong>个字！</div>
                <p>
                    <span class="Left" id="JS_art_login_status"><a class="red" href="javascript:;" onclick="userLogin();" title="登录">登录</a> | <a href="/user/?act=register" title="注册">注册</a></span><span class="Left"> | 匿名评论请填写邮箱：
       
                        <input id="JS_art_email" type="text">
                        ( 邮箱信息不会公开 )</span> <span class="Right"><a class="submit" href="javascript:;" onclick="postComment(this);" data-id="9993"></a></span>
                </p>
            </div>
        </div>
        <div class="sub_aside">
            <!--
    <div id="ad" class="zxFocus current"><a href="#" title="文章页-右侧广告" target="undefined"><img src="data/afficheimg/1385812505707871830.jpg" alt="文章页-右侧广告" height="250" width="300"></a></div>
  	-->
            <!--
    <div class="sideMod">
     
      <div class="header noTab">相关文章</div>
      <ul class="ul body current ">
	   
      </ul>
    </div>
    <div id="salePromote" class="sideMod">
      <div class="header noTab">相关商品</div>
      <div class="body clearfix" id="JS_tab_body_4">
        <ul id="JS_li_toggle_1" class="ul current clearfix">
		          
		  
        </ul>
        
      </div>
    </div>
-->

            <div class="sideMod">
                <div id="JS_tab_nav_1" class="header noTab clearfix"><span class="tabNum2 Left">新品特惠</span> <a class="Right more" href="ChangeUrl.aspx?type=37" target="_blank" title="更多">更多»</a> </div>
                <div id="JS_tab_body_1" class="body toggle clearfix">
                    <ul id="JS_li_toggle_4" class="ul current">

                        <asp:Repeater ID="DataList_quanggou" runat="server">
                            <ItemTemplate>
                                <li class="<%# (Container.ItemIndex + 1)>3?"":"first current "%> clearfix">
                                    <p class="normal">
                                        <i class="<%# (Container.ItemIndex + 1)>3?"i2":"i1"%>"><%# Container.ItemIndex + 1%></i><span> <a href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>">
                                            <%# Eval("GoodsName") %>
              </a></span>
                                    </p>
                                    <div class="hover">
                                        <i class="<%# (Container.ItemIndex + 1)>3?"i2":"i1"%>"><%# Container.ItemIndex + 1%></i> <span><a href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>">
                                            <img style="width: 88px; height: 56px; border: 0px" src="../../Upload/<%# Eval("Pic1")%>" data-src2="../../Upload/<%# Eval("Pic1") %>">
                                        </a></span>
                                        &nbsp;<dl>
                                            <dt><a class="GoodsName" href="goodsdetail.aspx?pid=<%# Eval("TypeID") %>&gid=<%# Eval("ID") %>" target="_blank" title="<%# Eval("GoodsName") %>">
                                                <%# Eval("GoodsName") %>
              </a></dt>
                                            <dd>市场价：<del class="yen">￥<%# Eval("Price") %></del><br>
                                                本站价:<b class="yen red">￥<%# Eval("RealityPrice") %></b></dd>
                                        </dl>
                                    </div>
                                </li>

                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>

        </div>
    </div>



    <%-- end --%>
</asp:Content>



