﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web.user.shop.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<!DOCTYPE HTML>
<html>
<head>
<meta charset="utf-8">
<meta name="keywords" content="南宁家具 南宁家具市场 南宁家具网" />
<meta name="description" content="MDD易购南宁家具体验馆为你提供南宁家具市场上各种风格类家具，如欧式家具，美式家具，法式家具,现代家具，韩式家具等，各种物美价廉新款家具尽在MDD易购家具网南宁体验馆." />
<link rel="icon" href="http://image.meilele.com/favicon.ico" />
  <script src="../../Scripts/jq.js" type="text/javascript"></script>
 <link href="../../css/mll_common.min.css" rel="stylesheet" type="text/css" />
<title>南宁家具-南宁家具市场-南宁家具网-MDD易购南宁家具体验馆</title>
<style type="text/css">.SCREEN-SHOW{display:none}.red{color:#c9033b;font-family:微软雅黑}.yahei{font-family:'Microsoft Yahei',微软雅黑}body,html body{background:#faf6f7 url(http://image.meilele.com/images/default/bbg.gif)}.mt12{margin-top:12px}.slide_banner,.slide_banner .slide_stage{width:100%;height:400px;overflow:hidden}.slide_banner .slide_stage .bg{height:400px;text-align:center}.slide_banner .slide_stage a{display:block;width:100%;height:400px;text-decoration:none}.slide_banner .slide_handdler{width:100%;height:12px;overflow:hidden;position:absolute;margin-top:-28px;text-align:center}.slide_banner .slide_handdler a{display:inline-block;width:12px;height:12px;border-radius:12px;overflow:hidden;vertical-align:top;margin-left:10px;background:#fff;opacity:.5;filter:alpha(opacity=50)}.slide_banner .slide_handdler a.first{margin-left:245px}.slide_banner .slide_handdler a:hover,.slide_banner .slide_handdler .current{background:#c9033b;opacity:1;filter:alpha(opacity=100)}.goods4_list{width:220px;padding:0 12px;float:left;border-left:1px solid #f3f3f3;padding-top:14px;height:203px}.goods4_list.first{border-left:none}.goods4_list .img{height:139px;overflow:hidden;position:relative}.goods4_list .img span{display:inline-block;width:42px;height:44px;color:#fff;padding-top:9px;background:url(http://image.meilele.com/images/default/tag_new_2.png) 0 0 no-repeat;_background:url(http://image.meilele.com/images/default/tag_new_2.gif) 0 0 no-repeat;position:absolute;right:8px;top:8px;line-height:13px;font-size:12px;text-align:center;padding-left:2px}.goods4_list .img span strong{font-size:17px;padding-left:3px}.goods4_list .img img{width:220px;height:146px}.goods4_list .info{margin-top:10px;line-height:20px;text-align:center;color:#999}.goods4_list .info .pr{font-size:16px;color:#d70000}.cat_shadow{display:block}.all_cat{display:block}.no_subject{margin-top:20px}.no_subject .side{width:230px}.no_subject .side .tab{border:solid 1px #ddd}.no_subject .side .tab .head{height:32px}.no_subject .side .tab .head a{display:inline-block;width:113px;height:31px;line-height:31px;border-left:solid 1px #ddd;border-bottom:solid 1px #ddd;background:#f6f6f6;text-align:center;color:#686765;text-decoration:none;vertical-align:top;position:relative;font-family:微软雅黑;font-size:14px}.no_subject .side .tab .head .first{width:114px;border-left:none}.no_subject .side .tab .head a:hover,.no_subject .side .tab .head .current{height:31px;border-bottom:0;background:#fff;border-top:solid 2px #c9033b;margin-top:-1px;color:#333!important;font-weight:bold}.no_subject .side .tab .body{height:102px;background:#fff;overflow:hidden}.no_subject .side .tab .long{height:137px;padding-bottom:10px}.no_subject .side .tab .show_news{height:85px;overflow:hidden}.no_subject .side .tab .long .show_news{height:130px}.no_subject .side .tab .body .tBody{display:none}.no_subject .side .tab .body .current{display:block}.no_subject .side .tab .body .gg{padding:12px 20px}.no_subject .side .tab .body .long{padding:2px 20px}.no_subject .side .tab .body .gg li{height:26px;line-height:26px}.no_subject .side .tab .long .gg li{height:26px;line-height:26px}.no_subject .side .tab .body .gg li a{color:#666;position:relative}.no_subject .side .tab .body .query{padding:10px 15px 0}.no_subject .side .tab .body .query .input{height:27px}.no_subject .side .tab .long .query .input{height:35px;margin-top:15px}.no_subject .side .tab .body .query .input input{height:25px;line-height:25px;background:url(http://image.meilele.com/images/common/bg.png) 0 0 repeat-x;border:solid 1px #d6d6d6;color:#999;padding:0 5px}.no_subject .side .tab .body .query .input .uOrder{width:185px}.no_subject .side .tab .body .query .input .uPhone{width:118px;float:left}.no_subject .side .tab .body .query .imgBtn{display:inline-block;width:56px;height:27px;margin-left:10px;_margin-left:5px;background:url(http://image.meilele.com/images/default/bg8.png) 0 -207px no-repeat;overflow:hidden}.no_subject .side .tab .body .query .login{margin-top:6px}.no_subject .side .tab .body .query .long{margin-top:10px}.no_subject .side .tab .body .query .login a{text-decoration:underline;color:#c9033b}.no_subject .side .ad{height:102px;border:solid 1px #ddd;overflow:hidden}.no_subject .side .long{height:120px;overflow:hidden}.no_subject .main{width:740px}.no_subject .main .head{height:29px;line-height:28px;position:relative}.no_subject .main .head strong,.no_subject .main .head span,.no_subject .main .head a{display:inline-block;vertical-align:top}.no_subject .main .head .count{width:42px;height:18px;line-height:18px;text-align:center;overflow:hidden;color:#fff;background:url(http://image.meilele.com/images/default/bg8.png) -56px -189px no-repeat;margin:6px 0 0 5px;font-weight:bold}.no_subject .main .head strong{font-size:17px;font-family:微软雅黑;font-weight:bold;color:#333}.no_subject .main .head strong.red{color:#c9033b}.no_subject .main .head .weekly{background:url(http://image.meilele.com/images/default/bg8.png) 0 0 no-repeat;width:62px;height:21px;position:relative;margin-left:4px;margin-top:4px;color:#fff;line-height:21px;text-align:center;padding-left:5px}.no_subject .main .head .ep{color:#333}.no_subject .main .head .go{position:relative;right:0;top:-2;color:#f60;padding-left:5px}.no_subject .main .head .go i{background:url(http://image.meilele.com/images/default/bg8.png) 0 -236px no-repeat;width:9px;height:14px;vertical-align:middle;display:inline-block;margin-right:5px}.no_subject .main .body{height:228px;border:solid 1px #ddd}.no_subject .main .body.no_right{border-right:0}.no_subject .main .week_body{height:217px;border-top:0;background:#fff}.no_subject .main .header_bg{height:3px;font-size:0;background:#dedede}.no_subject .main .header_bg .l_bg,.no_subject .main .header_bg .r_bg{width:10px;height:3px;display:inline-block;background:url(http://image.meilele.com/images/default/bg8.png)}.no_subject .main .header_bg .l_bg{float:left;background-position:-4px -122px}.no_subject .main .header_bg .r_bg{float:right;background-position:-4px -128px}.zxDesign{margin-top:20px}.zxDesign .head{height:30px;line-height:30px;font-size:19px;font-family:微软雅黑;color:#333;border-bottom:solid 2px #bbb;font-weight:bold}.zxDesign .body{height:290px}.zxDesign .body .list{width:230px;height:290px;overflow:hidden;float:left;padding-left:20px}.zxDesign .body .list.first{padding-left:0}.zxDesign .body .list img{width:230px;height:290px}.groupBuy{width:230px}.groupBuy .head{height:30px;line-height:30px;border-bottom:solid 1px #ddd}.groupBuy .head .name{font-size:17px;color:#333;font-family:"微软雅黑";font-weight:bold}.groupBuy .head .Right a{color:#999}.groupBuy .body{height:247px;padding-top:11px;border:solid 1px #ddd;border-top:0;background:#fff}.groupBuy .body .box{width:210px;overflow:hidden;margin-left:auto;margin-right:auto}.groupBuy .body .img{width:210px;height:192px;overflow:hidden;margin-left:auto;margin-right:auto}.groupBuy .body .cont{width:184px;height:37px;background:url(http://image.meilele.com/images/default/bg8.png) #c9033b -256px -66px no-repeat;display:inline-block;padding-left:20px;line-height:37px;margin-top:8px}.groupBuy .body .cont span,.groupBuy .body .cont strong{vertical-align:top;display:inline-block;color:#fff}.groupBuy .body .yen{padding-left:5px;position:relative;margin-top:1px;font-size:14px}.groupBuy .body .price{font-size:19px;font-family:"微软雅黑";color:#fff;font-weight:normal}.groupBuy .body .Right a{display:inline-block;width:67px;height:27px;margin-right:5px;margin-top:5px;background:url(http://image.meilele.com/images/default/bg8.png) -67px 0 no-repeat}.groupBuy .body.current .nav{display:block}.groupBuy .body .nav a{display:inline-block;width:17px;height:36px;background:url(http://image.meilele.com/images/zhuanti/upload/n1_1384933689.png) 0 0 no-repeat;_background:url(http://image.meilele.com/images/zhuanti/upload/n1_1384933685.gif) 0 0 no-repeat;position:absolute;margin-top:70px}.groupBuy .body .nav a.nr{margin-left:193px;background-position:-17px 0}.groupBuy .body .nav a:hover,.groupBuy .body:hover .nav a{opacity:.6;filter:alpha(opacity=60);background-position:0 -36px}.groupBuy .body .nav a.nr:hover,.groupBuy .body:hover .nav a.nr{background-position:-17px -36px}.todayDown{height:255px;margin-top:20px}.todayDown .head{height:30px;line-height:30px;font-size:14px;font-family:微软雅黑;border-bottom:solid 2px #bbb;font-weight:bold}.todayDown .head .name{font-size:17px;font-family:微软雅黑}.todayDown .body{border:solid 1px #ddd;border-top:0;height:222px;background:#fff}.todayDown .body .list{width:205px;border-left:solid 1px #fff;padding:20px 19px 19px;float:left}.todayDown .body .list.first{border-left:none}.todayDown .body .list .img{height:131px;overflow:hidden;position:relative}.todayDown .body .list .img span{display:inline-block;height:18px;line-height:18px;padding:0 5px;color:#fff;background:#cc2e2f;position:absolute;right:0;top:0}.todayDown .body .list .img img{width:205px;height:131px}.todayDown .body .list .info{margin-top:10px;height:40px;text-align:center;color:#999}.todayDown .body .list .info p{height:20px;line-height:20px}.todayDown .body .list .info p span{display:inline-block;vertical-align:top}.todayDown .body .list .info .txt{padding:0 5px 0 10px;height:18px;line-height:18px;background:#cd2e32;position:relative;margin:2px 5px 0 0;color:#fff}.todayDown .body .list .info .arrow{position:absolute;right:-5px;color:#cd2e32}.todayDown .body .list .info .pr{font-size:16px}.todayDown .goods4_list{padding:0 0 0 27px;width:210px;border:0}.todayDown .goods4_list .img img{width:210px}.hotBrand{margin-top:20px}.hotBrand .header{height:30px;line-height:30px;font-size:17px;font-weight:bold;border-bottom:2px solid #bbb}.hotBrand table{width:100%}.hotBrand table td{border:1px solid #efefef;overflow:hidden;height:80px;vertical-align:top;border-bottom-color:#ddd}.hotBrand table td .img{text-align:center;height:76px;padding-top:4px;color:#999;line-height:20px}.hotBrand table .first td{border-top:0}.hotBrand table td .bg{width:139px;height:82px;background:#000;opacity:.6;filter:alpha(opacity=60);display:none;position:absolute;margin-left:-1px;margin-top:-1px}.hotBrand table td.current .bg{display:block}.hotBrand table td .text{width:139px;height:72px;display:none;position:absolute;text-align:center;color:#fff;padding-top:10px;line-height:30px;margin-left:-1px;margin-top:-1px}.hotBrand table td .text a{display:inline-block;width:66px;height:19px;background:#ff9bb7;color:#fff;line-height:19px;text-align:center;border-radius:9px}.hotBrand table td .text a:hover{color:#fff!important}.hotBrand table td.current .text{display:block}.hotBrand table td .bd{border:1px solid #fff;background:#fff}.hotBrand table .td_1,.hotBrand table .td_8{border-left-color:#ddd}.hotBrand table .td_7,.hotBrand table .td_14{border-right-color:#ddd}.hotBrand table .first td{border-bottom-color:#efefef}.limitTime{width:740px}.limitTime .head{height:30px;line-height:30px;font-size:14px;font-family:微软雅黑;font-weight:bold;overflow:hidden;position:relative}.limitTime .head .name{display:inline-block;padding-right:50px;font-size:17px;font-family:微软雅黑;background:url(http://image.meilele.com/images/default/bg8.png) 75px -57px no-repeat;font-weight:bold}.limitTime .body{height:260px;width:740px;overflow:hidden;position:relative}.limitTime .body .buybtn{background:#fff;position:absolute;margin-top:176px;width:210px;height:50px;border-bottom:2px solid #f6545f;text-align:center;padding-top:20px;display:none}.limitTime .body .current .buybtn{display:block}.limitTime .body .buybtn a{display:inline-block;width:88px;height:31px;background:url(http://image.meilele.com/images/default/bg8.png) -134px 0}.limitTime .body .limit_time_container{height:26px;padding-left:30px;margin-bottom:10px}.limitTime .body .limit_time_container .limit_icon{width:18px;height:26px;background:url(http://image.meilele.com/images/default/bg8.png) -45px -90px no-repeat;float:left}.limitTime .body .leaveTime{height:26px;line-height:26px;color:#999;float:left}.limitTime .body .leaveTime .digital{font-size:12px;padding:0 2px}.limitTime .body .goods4_list{height:244px;border:1px solid #ddd;background:#fff;padding:14px 9px 0 9px}.limitTime .body td{padding-right:10px}.limitTime .limit_l,.limitTime .limit_r{display:inline-block;width:16px;height:16px;background:url(http://image.meilele.com/images/default/bg8.png);margin-top:9px;font-size:0;cursor:pointer;margin-left:4px}.limitTime .limit_l{background-position:-44px -63px}.limitTime .limit_r{background-position:-61px -63px}.floor1 .header{height:35px}.floor1 .header .Right{padding-top:6px;overflow:hidden;height:30px;line-height:30px}.floor1 .header .Right .words{display:inline-block;vertical-align:top;padding-right:16px}.floor1 .header .Right .words a{color:#666}.floor1 .header .Right .more{color:#c9033b;background:url(http://image.meilele.com/images/default/bg8.png) -206px -167px no-repeat;display:inline-block;height:30px;padding-right:18px}.floor1 .header .title{display:inline-block;height:35px;width:145px;background:url(http://image.meilele.com/images/default/bg8.png) 0 -306px no-repeat}.floor1_2 .header .title{background-position:0 -270px}.floor2_1 .header .title{background-position:0 -343px}.floor2_2 .header .title{background-position:0 -378px}.floor2_3 .header .title{background-position:0 -413px}.floor2_4 .header .title{background-position:0 -448px}.floor1 .main_new{padding:4px 3px;background:#fff;border:#ddd 1px solid;margin-top:2px}.floor1 .main_new a{display:inline-block;padding:4px;vertical-align:top}.floor1 .main_new .a_1,.floor1 .main_new .img_1{width:202px;height:290px;display:none;font-size:0}.floor1 .main_new .a_2,.floor1 .main_new .img_2{width:235px;height:290px}.floor1 .main_new .a_3,.floor1 .main_new .img_3{width:235px;height:290px}.floor1 .main_new .a_4,.floor1 .main_new .img_4{width:478px;height:290px}.floor1 .main_new .a_5,.floor1 .main_new .img_5{width:202px;height:290px;display:none}.floor1 .main_new .a_6,.floor1 .main_new .img_6{width:478px;height:290px}.floor1 .main_new .a_7,.floor1 .main_new .img_7{width:235px;height:290px}.floor1 .main_new .a_8,.floor1 .main_new .img_8{width:235px;height:290px}.floor1_2 .main_new .a_2,.floor1_2 .main_new .img_2{width:478px;height:290px}.floor1_2 .main_new .a_4,.floor1_2 .main_new .img_4{width:235px;height:290px}.floor1_2 .main_new .a_6,.floor1_2 .main_new .img_6{width:235px;height:290px}.floor1_2 .main_new .a_7,.floor1_2 .main_new .img_7{width:478px;height:290px}.floor2 .main_new .f_a_2{display:inline-block;padding:4px;vertical-align:top;overflow:hidden}.floor2 .main_new .f_a_2 .st{width:721px;height:330px;overflow:hidden}.floor2 .main_new .f_a_2 span{display:inline-block}.floor2 .main_new .f_a_2 a{padding:0}.floor2 .main_new .f_a_2 .nav{position:absolute;margin-top:255px;margin-left:644px}.floor2_2 .main_new .f_a_2 .nav,.floor2_3 .main_new .f_a_2 .nav,.floor2_4 .main_new .f_a_2 .nav{margin-top:300px}.floor2 .main_new .nav a{display:inline-block;width:12px;height:12px;background:#fff;opacity:.5;filter:alpha(opacity=50);border-radius:50%;margin-right:10px}.floor2 .main_new .nav a.current{opacity:1;filter:alpha(opacity=100)}.floor2 .main_new .f_a_1,.floor2 .main_new .f_img_1{width:202px;height:330px;display:none}.floor2 .main_new .f_a_2,.floor2 .main_new .f_a_2 img{width:721px;height:330px}.floor2 .main_new .f_a_3,.floor2 .main_new .f_img_3{width:235px;height:330px}.floor2 .main_new .f_a_6,.floor2 .main_new .f_img_6{width:202px;height:240px;display:none}.floor2 .main_new .f_a_7,.floor2 .main_new .f_img_7{width:235px;height:240px}.floor2 .main_new .f_a_8,.floor2 .main_new .f_img_8{width:235px;height:240px}.floor2 .main_new .f_a_9,.floor2 .main_new .f_img_9{width:235px;height:240px}.floor2 .main_new .f_a_10,.floor2 .main_new .f_img_10{width:235px;height:240px}.floor2 .header strong{color:#333}.zhuangxiu{margin-top:20px}.zhuangxiu .zxHead{height:30px;border-bottom:solid 2px #bbb}.zhuangxiu .zxHead strong,.zhuangxiu .zxHead .zxMore{display:inline-block;height:30px;line-height:30px}.zhuangxiu .zxHead strong{font-size:15px;font-family:"微软雅黑";font-size:17px}.zhuangxiu .zxHead .zxCase{height:30px;line-height:30px;padding-left:30px}.zhuangxiu .zxHead .zxMore{color:#c90239;text-align:right}.zhuangxiu .zxHead .zxMore i{font-style:normal}.zhuangxiu .zxHead .zxMore .yen{font-size:13px;font-family:"宋体"}.zhuangxiu .zxHead span{color:#e3e3e3}.zhuangxiu .zxBody{height:300px;overflow:hidden}.zhuangxiu .zxBody .comHeight{height:300px;overflow:hidden}.zhuangxiu .zxBody .sideGroup{width:212px;margin-right:7px}.zhuangxiu .zxBody .sideGroup .ad{height:110px;overflow:hidden}.zhuangxiu .zxBody .sideGroup .zxTools{height:183px;border:solid 1px #ebebeb;margin-top:5px}.zhuangxiu .zxBody .sideGroup .zxTools a{display:block;height:91px;overflow:hidden;float:left;text-decoration:none;background:#fff;cursor:pointer}.zhuangxiu .zxBody .sideGroup .zxTools a em,.zhuangxiu .zxBody .sideGroup .zxTools a span{display:inline-block;cursor:pointer}.zhuangxiu .zxBody .sideGroup .zxTools a em{width:44px;height:42px;overflow:hidden;background:url(http://image.meilele.com/images/default/index_ico.png) no-repeat;margin:12px 0 0 30px}.zhuangxiu .zxBody .sideGroup .zxTools a .t1{background-position:0 0}.zhuangxiu .zxBody .sideGroup .zxTools a .t2{background-position:-44px 0}.zhuangxiu .zxBody .sideGroup .zxTools a .t3{background-position:-88px 0}.zhuangxiu .zxBody .sideGroup .zxTools a .t4{background-position:-132px 0}.zhuangxiu .zxBody .sideGroup .zxTools a span{width:104px;height:18px;line-height:18px;text-align:center;margin-top:5px}.zhuangxiu .zxBody .sideGroup .zxTools a:hover{background:#fff!important}.zhuangxiu .zxBody .sideGroup .zxTools a:hover .t1{background-position:0 -42px}.zhuangxiu .zxBody .sideGroup .zxTools a:hover .t2{background-position:-44px -42px}.zhuangxiu .zxBody .sideGroup .zxTools a:hover .t3{background-position:-88px -42px}.zhuangxiu .zxBody .sideGroup .zxTools a:hover .t4{background-position:-132px -42px}.zhuangxiu .zxBody .sideGroup .zxTools a:hover span{color:#d11f43}.zhuangxiu .zxBody .sideGroup .zxTools .w104{width:104px}.zhuangxiu .zxBody .sideGroup .zxTools .w105{width:105px}.zhuangxiu .zxBody .sideGroup .zxTools .bl1{border-left:solid 1px #ebebeb}.zhuangxiu .zxBody .sideGroup .zxTools .bt1{border-top:solid 1px #ebebeb}.zhuangxiu .zxBody .focusGroup,.zhuangxiu .zxBody .focusGroup .stage{width:510px;height:300px;overflow:hidden}.zhuangxiu .zxBody .focusGroup{margin-right:6px}.zhuangxiu .zxBody .focusGroup .nav{width:500px;height:18px;position:absolute;margin-top:-28px;text-align:right}.zhuangxiu .zxBody .focusGroup .nav a{display:inline-block;width:18px;height:18px;line-height:18px;text-align:center;border-radius:18px;text-decoration:none;vertical-align:top;margin-left:10px;background:#fff}.zhuangxiu .zxBody .focusGroup .nav a:hover,.zhuangxiu .zxBody .focusGroup .nav .current{background:#c9033b;color:#fff!important}.zhuangxiu .zxBody .tags{width:225px;height:280px;padding:9px;border:1px solid #e9e9e9;background:#fff}.zhuangxiu .zxBody .tags .title{height:20px;line-height:20px;padding-left:5px;font-family:微软雅黑;font-size:16px;color:#020001}.zhuangxiu .zxBody .tags .body{height:260px;overflow:hidden}.zhuangxiu .zxBody .tags .body a{display:inline-block;height:30px;line-height:30px;padding:0 7px;border:1px solid #c8c8c8;color:#545454;margin-top:11px;margin-right:10px;*display:inline;*zoom:1;white-space:nowrap;background:#f9f9f9;font-size:12px}.zhuangxiu .zxBody .tags .body a:hover{color:#c9033b!important;background:#f2f2f2}.zhuangxiu .zxBody .tags .body .light{color:#c9033b!important;background:#fff!important}.zhuangxiu .zxBody .sideAd{width:200px;height:300px;overflow:hidden}.frameLay{height:341px;border:solid 1px #dedede;overflow:hidden}.frameLay .layHead{height:34px;line-height:34px;border-bottom:solid 1px #dedede;background:#f3f3f3}.frameLay .layBody{height:272px;padding:17px 16px;overflow:hidden;background:#fff}.showMyHome{width:593px;border-right:solid 1px #dedede}.showMyHome .layHead{padding:0 10px}.showMyHome .layHead .name{font-size:14px;font-family:"微软雅黑";float:left}.showMyHome .layHead .tNav{height:12px;margin-top:11px;float:right}.showMyHome .layHead .tNav a{display:inline-block;width:10px;height:10px;overflow:hidden;background:#d9d9d9;border-radius:10px;vertical-align:top;margin-right:5px}.showMyHome .layHead .tNav a:hover,.showMyHome .layHead .tNav .current{background:#ea7070}.showMyHome .layBody .stage{width:561px;height:272px;overflow:hidden}.showMyHome .layBody .list{width:167px;height:256px;padding:8px;background:url(http://image.meilele.com/images/default/xspace_bg.jpg) top center no-repeat;margin-right:6px}.showMyHome .layBody .list.first{margin-left:0}.showMyHome .layBody .list .img{height:200px;overflow:hidden}.showMyHome .layBody .list .txt{height:36px;line-height:18px;padding-top:10px;overflow:hidden;color:#666}.showMyHome .layBody .list .txt a{color:#666}.articleTab{width:384px;float:right}.articleTab .layHead .tabNav{height:36px;position:absolute;margin-top:-1px}.articleTab .layHead .tabNav a{display:inline-block;height:34px;line-height:34px;padding:0 28px;border-top:solid 1px #dedede;border-bottom:solid 1px #dedede;border-right:solid 1px #dedede;text-align:center;text-decoration:none;font-size:14px;font-weight:bold;font-family:"微软雅黑";float:left}.articleTab .layHead .tabNav a:hover,.articleTab .layHead .tabNav .current{height:33px;line-height:33px;cursor:default;border-top:solid 2px #c9033b;border-bottom:solid 1px #fff;background:#fff}.articleTab .layBody .tabBody{height:272px;display:none}.articleTab .layBody .current{display:block!important}.articleTab .dealRecord{height:232px;overflow:hidden}.articleTab .dealRecord .scrollBox{height:auto}.articleTab .dealRecord .item{height:79px;overflow:hidden;padding:6px 0;color:#646464}.articleTab .dealRecord .item .img{width:117px;height:79px;overflow:hidden;float:left;margin-right:10px}.articleTab .dealRecord .item .txt{height:79px;line-height:16px;overflow:hidden}.articleTab .dealRecord .item .txt .time{color:#ff6500}.articleTab .layBody .notes{height:106px;padding-bottom:15px;border-bottom:1px dashed #c8c5c4}.articleTab .layBody .notes .img{width:160px;height:106px;overflow:hidden;float:left;margin-right:10px}.articleTab .layBody .notes h3{height:30px;line-height:30px;font-size:14px;overflow:hidden}.articleTab .layBody .notes h3 a{font-family:"微软雅黑";font-size:14px;font-weight:bold}.articleTab .layBody .notes p{height:72px;line-height:18px;overflow:hidden}.articleTab .layBody ul{margin-top:10px}.articleTab .layBody ul li{height:22px;line-height:22px;overflow:hidden;float:left;width:49.5%}.articleTab .loading{height:16px;text-align:center;margin-top:100px}.randomExpr{border:solid 1px #dedede}.randomExpr .title{height:34px;background:#f3f3f3;border-bottom:solid 1px #dedede}.randomExpr .title strong{display:inline-block;height:35px;line-height:34px;padding:0 25px;font-size:15px;font-family:"微软雅黑";position:absolute;border-right:solid 1px #dedede;background:#fff}.randomExpr .body{height:auto;background:#fff}.randomExpr .body .list{height:80px;border-top:1px dashed #cfcfcf;overflow:hidden}.randomExpr .body .list.first{border-top:0}.randomExpr .body .list .name{width:64px;padding:15px 0 0 19px}.randomExpr .body .list .name h3{height:40px;padding:5px;line-height:20px;text-align:center;width:40px;color:#fff;background:#616161}.randomExpr .body .list .name h3 a{color:#fff!important}.randomExpr .body .list.current .name h3,.iei .list:hover .name h3{background:#c9033b}.randomExpr .body .list .addr{width:480px;padding-right:15px;border-right:1px dashed #cfcfcf;padding-top:15px;line-height:25px;color:#666;height:65px}.randomExpr .body .list.hasVideoIcon .addr{width:463px}.randomExpr .body .list .addr p{height:26px;line-height:26px;overflow:hidden}.randomExpr .body .list .phone{width:207px;height:52px;padding-left:25px;border-right:1px dashed #cfcfcf;padding-top:15px;line-height:25px;padding-bottom:13px;color:#666}.randomExpr .body .list.hasVideoIcon .phone{width:166px;padding-left:10px}.root_body .randomExpr .body .list.hasVideoIcon .phone{width:180px;padding-left:20px}.randomExpr .body .list .phone .f_13{font-size:13px}.randomExpr .body .list .sms{padding:28px 22px 0 0}.randomExpr .body .list .sms .icon{background:url(http://image.meilele.com/images/default/send_msg.png?2) 0 -56px no-repeat;display:inline-block;*display:inline;*zoom:1;width:119px;height:27px;vertical-align:top}.randomExpr .body .list .sms .video_icon{background-position:0 -84px;width:82px;margin-right:10px;*margin-right:5px}.randomExpr .body .list:hover h3{background:#c9033b}.floatMap{width:252px;height:254px;overflow:hidden;position:absolute;margin-top:43px;display:none}.floatMap .arrow{width:0;height:0;overflow:hidden;margin:0 auto;border-top:solid 7px #fff;border-right:solid 7px #fff;border-bottom:solid 7px #828282;border-left:solid 7px #fff}.floatMap .map{height:238px;border:solid 1px #9b9b9b;background:#fff;overflow:hidden}.randomExpr .body .list .addr.hover .floatMap{display:block!important}.root_body .no_subject .main{width:950px}.root_body .no_subject .main .bodyMap{width:784px}.root_body .no_subject .main .headMap{width:124px}.root_body .no_subject .main .headMap a{width:121px}.root_body .zxDesign .body .list{padding-left:10px}.root_body .zxDesign .body .list.first{padding-left:0}.root_body .limitTime{width:950px}.root_body .limitTime .body{width:950px}.root_body .no_subject .side .tab .body{height:163px}.root_body .no_subject .side .tab .body .long{padding:12px 20px}.root_body .no_subject .side .tab .long{height:198px}.root_body .no_subject .side .tab .show_news{height:145px}.root_body .no_subject .side .tab .long .show_news{height:190px}.root_body .no_subject .side .tab .body .query .input{height:35px;margin-top:15px}.root_body .no_subject .side .tab .body .query .login{padding-top:10px}.root_body .goods4_list{padding-left:22px}.root_body .no_subject .main .week_body{height:278px}.root_body .week_body .goods4_list{padding-left:13px;height:265px;width:290px}.root_body .exprnum .ebody .box2_3_td a.wide{background:url(http://image.meilele.com/images/default/send_msg.png?2) 0 0 no-repeat!important;display:inline-block;width:119px;height:27px}.root_body .exprnum .ebody .box2_1 .narrow,.root_body .exprnum .ebody .box2_3_td a.narrow{display:none}.root_body .exprnum .ebody .box2_1 .wide,.root_body .exprnum .ebody .box2_3_td a.wide{display:inline-block}.exprnum .ebody .box2_1 .wide,.exprnum .ebody .box2_3_td .wide{display:none}.root_body .exprnum .ebody .box2_1_td{width:173px}.root_body .exprnum .ebody .box2_1{width:154px}.root_body .exprnum .ebody .box2_3_td{width:135px;text-align:center}.root_body .exprnum .ebody .box2_3_td.box2_3_td_w{width:230px}.root_body .week_body .goods4_list .img,.root_body .limitTime .goods4_list .img{width:290px;height:192px}.root_body .week_body .goods4_list .img img,.root_body .limitTime .goods4_list .img img{width:290px;height:192px}.root_body .groupBuy .body{height:262px}.root_body .groupBuy .body .img{width:210px;height:192px}.root_body .groupBuy .body .cont{margin-top:17px}.root_body .limitTime .body .goods4_list{height:259px;width:290px;position:relative}.root_body .limitTime .body{height:275px}.root_body .limitTime .body .current .goods4_list .limit_time_container{background:#c9033b}.root_body .limitTime .body .limit_time_container,.root_body .limitTime .goods4_list .img .layer{position:absolute;width:290px;height:29px;left:9px;top:177px}.root_body .limitTime .body .limit_time_container{padding-left:65px;z-index:10;width:225px}.root_body .limitTime .body .limit_icon{height:29px;background:url(http://image.meilele.com/images/default/time_icon.png) center center no-repeat;_background:url(http://image.meilele.com/images/default/time_icon.gif) center center no-repeat;margin-right:2px}.root_body .limitTime .body .leaveTime{height:29px;line-height:29px;color:#fff}.root_body .limitTime .goods4_list .img .layer{z-index:1;background:#000;opacity:.5;filter:alpha(opacity=50)}.root_body .limitTime .goods4_list .img{position:static}.root_body .floor1 .main_new .a_1,.root_body .floor1 .main_new .img_1{display:inline-block}.root_body .floor1 .main_new .a_5,.root_body .floor1 .main_new .img_5{display:inline-block}.root_body .floor2 .main_new .f_a_1,.root_body .floor2 .main_new .f_img_1{display:inline-block}.root_body .floor2 .main_new .f_a_6,.root_body .floor2 .main_new .f_img_6{display:inline-block}.root_body .floor2 .l2 a.floora_6{display:inline-block}.root_body .todayDown .body{padding:0 4px}.root_body .todayDown .body .list{width:201px;padding:20px 17px 19px}.root_body .todayDown .body .list .img img{width:201px;height:131px}.root_body .articleTab{width:594px;float:right}.root_body .articleTab .dealRecord .item{width:49.8%;float:left}.root_body .randomExpr .body .list .addr{width:650px}.root_body .randomExpr .body .sms{padding:28px 44px 0 0}.randomExpr .body .list.hasVideoIcon .sms{padding:28px 14px 0 0}.root_body .SCREEN-SHOW{display:block}.root_body td.SCREEN-SHOW{display:table-cell}.root_body .hotBrand table td .bg,.root_body .hotBrand table td .text{width:169px}.pageAD{height:50px;overflow:hidden;position:relative}.pageAD .closeX{position:absolute;top:2px;right:2px;background:#c00;width:16px;height:16px;color:#fff;font-weight:bold;text-align:center;line-height:16px;cursor:pointer}.exprnum{height:62px;border:1px solid #ddd;border-top:0}.exprnum .t1,.exprnum .t2{width:100%;height:62px}.exprnum .t2{height:40px;margin-top:11px}.exprnum .enav{width:25px;overflow:hidden}.exprnum .enav a{height:52px;border-left:1px solid #fff;background:#a5a5a5;display:block;overflow:hidden;text-align:center;letter-spacing:6px;padding-left:6px;padding-top:10px;color:#fff;line-height:14px}.exprnum .enav4 a{height:59px;padding-top:3px}.exprnum .enav a:hover{color:#fff!important;text-decoration:none;background:#e40544}.exprnum .enav.first a{border-left:none}.exprnum .enav.current a{background:#c9033b;color:#fff}.exprnum .ebody{display:none}.exprnum .current{display:table-cell;*display:block}.exprnum .ebody a{background:none!important}.exprnum .ebody .box{height:62px;overflow:hidden;background:#fefaef}.exprnum .ebody .arrow{width:4px}.exprnum .ebody .arrow div{position:relative;overflow:hidden;width:4px;height:40px;font-family:宋体}.exprnum .ebody .arrow span{position:absolute;color:#c9033b;margin-top:15px;margin-left:-8px}.exprnum .ebody .box2{height:40px;line-height:20px;color:#777;border-right:1px dashed #ddd;padding-left:18px;text-overflow:ellipsis}.exprnum .ebody .box2 a{color:#777}.exprnum .ebody .box2_1_td{width:150px}.exprnum .ebody .box2_1{width:130px}.exprnum .ebody .box2_2{padding-right:15px;overflow:hidden}.exprnum .ebody .box2_3_td{width:115px;text-align:center}.exprnum .ebody .box2_3_td.box2_3_td_w{width:200px}.exprnum .ebody .box2_3_td a.narrow{display:inline-block;*display:inline;zoom:1;background:url(http://image.meilele.com/images/default/send_msg.png?2) 0 -28px no-repeat!important;width:83px;height:27px}.exprnum .ebody .box2_3_td a.video_icon{display:inline-block;*display:inline;zoom:1;background:url(http://image.meilele.com/images/default/send_msg.png?2) 0 -112px no-repeat!important;width:82px;height:27px;margin-right:8px}.exprnum.onlyone .arrow,.exprnum.onlyone .enav{display:none}.exprnum.onlyone{background:#f6f6f6}.virtual_bottom_ad{margin-top:20px;height:60px;overflow:hidden}.virtual_bottom_ad a{display:inline-block;margin-left:-105px}.root_body .virtual_bottom_ad img{width:1190px}.root_body .virtual_bottom_ad a{margin-left:0}
/*GH:2014-03-19 15:20:01*/</style>
<script>   
 window.getCookie = function (a) { var e; if (document.cookie && document.cookie !== "") { var d = document.cookie.split(";"); var f = d.length; for (var c = 0; c < f; c++) { var b = d[c].replace(/(^\s*)|(\s*$)/g, ""); if (b.substring(0, a.length + 1) == (a + "=")) { e = decodeURIComponent(b.substring(a.length + 1)); break; } } } return e; }; (function () { window.onerror = function (e, f, m) { window.onerror._root = window.onerror._root || {}; var j = encodeURIComponent(e + "").replace(/\W/g, ""); if (window.onerror._root[j]) { return; } var c = (Math.random() + "").replace("0.", "").substr(0, 9) - 0; var b = parseInt(new Date() / 1000); var l = (Math.random() + "").replace("0.", "").substr(0, 9) - 0; var i = { utmwv: "5.4.8dc", utms: 1, utmn: c, utmhn: location.host, utme: "8(COOKIE)9(" + document.cookie.replace(/[()]/g, "") + ")11(2)", utmcs: "UTF-8", utmdt: navigator.userAgent + "||" + e + "||" + f + "||" + m, utmhid: b, utmp: location.host + location.pathname + location.search, utmht: +new Date(), utmac: "UA-48396005-1", utmcc: "__utma=165027242." + l + "." + b + "." + b + "." + b + ".1;+__utmz=165027242." + b + ".1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)" }; var d = []; for (var g in i) { d.push(g + "=" + encodeURIComponent(i[g])); } var h = new Image(); h.src = "http://stats.g.doubleclick.net/__utm.gif?" + d.join("&"); window.onerror._root[j] = true; }; var a = function () { setTimeout(function () { window._gaq = window._gaq || []; window._ana = window._ana || []; if (_ana.push == Array.prototype.push) { throw new Error("亲，_ana未初始！"); } if (_gaq.push == Array.prototype.push) { throw new Error("亲，_gaq未初始！"); } }, 3000); }; if (window.addEventListener) { window.addEventListener("load", a, false); } else { if (window.attachEvent) { window.attachEvent("onload", a); } } })(); (function () { var b = document.createElement("script"); b.type = "text/javascript"; b.async = true; var a = document.getElementsByTagName("script")[0]; b.src = "http://image.meilele.com/js/recad.min.js"; a.parentNode.insertBefore(b, a); })(); window._gaq = window._gaq || []; window.MLLgaq = window.MLLgaq || []; window._onReadyList = window._onReadyList || []; window._ana = window._ana || []; _ana.baseTime = _ana.baseTime; _gaq.push(["_setAccount", "UA-10173353-1"]); _gaq.push(["_setDomainName", "meilele.com"]); (function (l) { if (getCookie("MLL_CID")) { _gaq.push(["_setCustomVar", 1, "CID", getCookie("MLL_CID"), 2]); } var n = (location.search + "").replace("?", "").split("&"); var i = {}; for (var c = 0, b = n.length; c < b; c++) { var m = n[c].split("="); i[m[0]] = m[1]; } var j = ((location.hash + "").replace("#", "")).split("#")[0].split("&"); for (var c = 0, b = j.length; c < b; c++) { var m = j[c].split("="); j[m[0]] = m[1]; } var g = ""; if (location.pathname.indexOf("/category-9999/") >= 0 && i.keywords) { g = i.keywords; } else { if (j.kw || i.kw) { g = j.kw || i.kw; } } try { g = decodeURIComponent(g); } catch (f) { } if (g && window._ana) { _ana.push(["trackEvent", "siteSearch", g]); } var a = { theme_group: i.thg || j.thg, ad_group: i.adg || j.adg, ad_name: i.adn || j.adn, ad_order: i.ado || j.ado }; for (var c in a) { if (a[c]) { try { a[c] = decodeURIComponent(a[c]); } catch (h) { } } } if (a && a.theme_group && a.ad_group && a.ad_name && a.ad_order) { MLLgaq.push(["_trackEvent", "ad_click_" + a.theme_group, "ad_click_" + a.ad_group, "ad_click_" + a.ad_name + "_" + a.ad_order, undefined, true]); } })(window);
 /*LDZ:2014-04-28 20:49:21*/
    </script> 
</head>

<body>
<form runat="server">
<script type="text/javascript">    (function () { var screenWidth = window.screen.width; if (screenWidth >= 1280) { document.body.className = "root_body"; window.LOAD = true; } else { window.LOAD = false; } })()</script>

<script>
    //初始空函数，防止页面报错，勿删，函数真身在页脚。
    function _show_() { }; function _hide_() { };
    var City = {
        init: function () { }
    }
    window.$ = window.$ || {};
    window.M = window.M || {};
    $.__IMG = M.__IMG = 'http://image.meilele.com' || 'http://image.meilele.com';
    var M = M || {}; M.getCookie = function (a) { var e; if (document.cookie && document.cookie !== "") { var d = document.cookie.split(";"); var f = d.length; for (var c = 0; c < f; c++) { var b = d[c].replace(/(^\s*)|(\s*$)/g, ""); if (b.substring(0, a.length + 1) == (a + "=")) { e = decodeURIComponent(b.substring(a.length + 1)); break; } } } return e; };
    /*LDZ:2013-08-06 09:54:53*/
  </script>



<div class="page-header"><div class="w clearfix">
	<div class="logo Left"><a id="JS_Header_Logo_link_home" href="/" title="MDD易购">
		<img src="./images/blank.gif" width="146" height="53" alt="" /></a></div>
	<div class="city Left">
		<div class="show">
			<span id="DY_site_name" class="name">全国站</span>
			<script>
			    (function (d) {
			        var rn = M.getCookie('region_name');
			        if (rn) {
			            var dd = d.getElementById('DY_site_name');
			            if (dd) dd.innerHTML = rn.slice(0, 4);
			        }
			    })(document);
			</script>
			
			<div class="city-select" id="JS_hide_city_menu_11" class="cut_handdler Left">
				<a href="javascript:void(0);" >切换城市</a>
				<div id="JS_header_city_bar_box" class="hide_city_group"></div>
			</div>
			
		</div>
		<img class="en_name" src="./images/blank.gif" width="121" height="14" alt="woshangwang.com" />
	</div>

	<div class="topArea Right">
		
		
	<table class="topMenu"><tr>
		<td id="JS_head_login" class="login"><span>您好，欢迎来MDD易购！</span><em class="line"></em><a href="./login.htm" title="登录MDD易购">登录</a><em class="line"></em><a href="./register.htm" title="免费注册MDD易购帐号">注册</a></td>
		<script>
		    function headLoginHtml(userName, notResuqst) {
		        userName = userName || (M.getCookie('wsw_login') == "1" && M.getCookie('ECS[username]'))
		        if (userName) {
		            var d = document.getElementById('JS_head_login');
		            d.innerHTML = '<a href="/user/" target="_blank" class="red" style="display:inline-block;text-overflow:ellipsis;white-space:nowrap;overflow:hidden;width:40px;">' + userName + '</a> <span id="JS_head_sita_name_haier">欢迎光临MDD易购！</span> <a href="javascript:;" class="red" id="JS_login_out" >[退出]</a>';
		        }
		        if (!notResuqst) {
		            var img = new Image();
		            img.onload = img.onerror = function () {
		                headLoginHtml(false, true);
		            };

		        }
		    }
		    headLoginHtml();
		</script>
		<td><em class="line"></em></td>
		<td><a href="/user/?act=order_list" target="_blank" title="我的订单">我的订单</a></td>
		<td><em class="line"></em></td>
		<td><a href="javascript:;" onclick="shoucang();">收藏本站</a></td>
		<td><em class="line"></em></td>
	</tr></table>
	

		
		<div class="btMap">
			<div class="Left search_box" style="position:relative;z-index:1;">
				<div class="search">
					<form id="JS_search_form" action="/category-9999/mcat0-scat0-b0-max0-min0-attr-page-1-sort-sort_order-order-asc.html" method="get" onsubmit="return MLL_header_search_submit();">
						<div class="sideShadow"></div>
						<input id="JS_MLL_search_header_input" type="text" name="keywords" class="keyWord" value="" autocomplete="off" />
						<input type="submit" class="submit" value="搜 索" />
						<input type="hidden" name="fl" value="q"/>
					</form>
					<div id="JS_search_suggest" class="suggest">
					</div>
				</div>
							</div>

			<div id="JS_header_cart_handler" class="cart Right">
				<a href="/flow/?step=cart&rel=header_icon" class="cartLink"><span class="">购物车</span><strong class="red cartCount" id="cartInfo_number">0</strong><span>件</span><span class="arrow"></span></a>
				<div id="JS_header_cart_list" class="hideCart" data-status="0"><div class="loadLay"><img src="http://image.meilele.com/themes/paipai/images/loading.gif" width="16" height="16" /> 正在加载，请稍后...</div></div>
			</div>
			<div class="cart Right mymll">
				<a href="/user/?act=index" class="cartLink"><span class="">我的MDD易购</span></a>
			</div>
		</div>
		
	</div>
</div></div>


<div class="globa-nav">
	<div class="shadow"></div>	<div class="w">
		<div class="allGoodsCat Left" >
			<a href="javascript:;" class="menuEvent"><strong class="catName">全部商品分类</strong></a>
			<div class="expandMenu" id="JS_head_expand_menu_target"></div>
		</div>
		<div class="allMenu Left"><a id="JS_Header_Home_Link" href="/" title="首页" class="index current">首页</a>
			<a href="/jiaju/" title="家具城" >家具城</a>
			<a href="/jiancai/" title="建材城" >建材城</a>
			<a href="/shipin/" title="家居家饰" >家居家饰</a>
			<a id="JS_n_head_menu_expr_1" href="/favorable.html" title="特惠套装" style="position:relative;" >特惠套装</a>
			<a id="JS_n_head_menu_expr" href="/expr.html" target="_blank" title="体验馆" style="position:relative;">体验馆</a>
			<a href="http://zx.meilele.com/" title="装修网" target="_blank">装修网</a>
		</div>
		<div class="sideMenu2 Right">
			<a class="menu" href="http://zx.meilele.com/albums/" target="_blank" title="装修效果图" style="position:relative;display:inline-block;">装修效果图</a>
			<a class="menu" href="/xspace/" title="秀家">秀家</a>
			<a class="menu" href="/dapei/" title="搭配">搭配</a>
		</div>
		<script>
		    function toggleExprName(d) {
		        d = d || document;
		        var m = d.getElementById('JS_n_head_menu_expr');
		        var py = M.getCookie('region_pinyin');
		        var is_vertual = M.getCookie('region_virtual');
		        if (py && m && is_vertual != 1) {
		            m.setAttribute('href', '/' + py + '/expr.html');
		            m.innerHTML = '体验馆';
		        } else if (py && m && is_vertual == 1) {
		            m.setAttribute('href', '/article_cat-12/article-10554.html?from=nav');
		            d.getElementById('JS_Header_Home_Link').setAttribute('href', '/' + py + '/');
		            d.getElementById('JS_Header_Logo_link_home').setAttribute('href', '/' + py + '/');
		            m.innerHTML = '招商加盟';
		        }

		    }
		    window._onReadyList = window._onReadyList || [];
		    _onReadyList.push(toggleExprName);
		</script>
	</div>
</div>


<script>
    window._onReadyList = window._onReadyList || [];
    _onReadyList.push(function () {
        $('#JS_hide_city_menu_11').hover(
		function () {
		    _show_(this, { source: 'JS_choose_city_source', target: 'JS_header_city_bar_box', data: 'JS_city_data', templateFunction: function (dom, json) {
		        dom = dom.jquery ? dom : $(dom);
		        if (json) {
		            var out = '';
		            var hot = '<a href="/" class="site_all Left" onclick="$.goExpr(\'index.html\',\'\',\'\',\'全国\');return !1;"><strong>全国</strong></a>&nbsp;';
		            var inner = '';
		            var charList = '';

		            $.each(json.city_list, function (key, item) {
		                charList += '<a href="javascript:;">' + key + '</a>';
		                out += '<tr><th><div>' + key + '</div></th><td>';
		                $.each(item, function (index, shi) {
		                    /*out += '<a href="/'+shi.pinyin+'/" data-region_id="'+shi.region_id+'" data-pinyin="'+shi.pinyin+'" onclick="$.goExpr(\''+shi.pinyin+'\',\''+shi.region_id+'\',\'\',\''+shi.region_name+'\'';
		                    //虚拟标记
		                    if(shi.is_virtual){
		                    out +=',\''+shi.is_virtual+'\');return !1;">'+shi.region_name+'</a>';
		                    }else{
		                    out +=');return !1;">'+shi.region_name+'</a>';*/
		                    //屏蔽虚拟站点
		                    if (shi.is_virtual) return;
		                    out += '<a href="/' + shi.pinyin + '/" data-region_id="' + shi.region_id + '" data-pinyin="' + shi.pinyin + '" onclick="$.goExpr(\'' + shi.pinyin + '\',\'' + shi.region_id + '\',\'\',\'' + shi.region_name + '\');return !1;">' + shi.region_name + '</a>';
		                });
		                out += '</td></tr>';
		            });

		            $.each(json.host_city_list, function (index, shi) {
		                hot += '<a href="/' + shi.pinyin + '/" data-region_id="' + shi.region_id + '" data-pinyin="' + shi.pinyin + '" onclick="$.goExpr(\'' + shi.pinyin + '\',\'' + shi.region_id + '\',\'\',\'' + shi.region_name + '\');return !1;">' + shi.region_name + '</a>';
		            });

		            dom.find('#JS_header_city_hot').html(hot);
		            dom.find('#JS_header_city_char').html(charList);
		            dom.find('#JS_header_city_list').html(out);

		            return dom;
		        }
		    } 
		    });
		    City.init();
		},
		function () {
		    _hide_(this);
		}
	);
        $('#JS_common_head_help').hover(
		function () { _show_(this); }, function () { _hide_(this); }
	);

        $('#JS_MLL_search_header_input').focus(function () {
            $.searchKey('JS_MLL_search_header_input', 'JS_search_suggest');
            $('#JS_MLL_search_header_input').unbind('focus');
        });
    })
</script>


<div class="w">
	<div class="all_cat" id="JS_index_menu_box">
				<div class="list">
			<dl class="cat">
				<dt class="catName"><strong class="cat1 Left"><a href="http://www.meilele.com/jiaju/" target="_blank" title="">家具</a></strong><span class="Right">&gt;</span></dt>
				<dd class="catList"><a href="http://www.meilele.com/category-wofang/" target="_blank" title="卧室">卧室</a>&emsp;<a href="http://www.meilele.com/category-keting/" target="_blank" title="客厅">客厅</a>&emsp;<a href="http://www.meilele.com/category-canting/" target="_blank" title="餐厅">餐厅</a>&emsp;<a href="http://www.meilele.com/category-shufang/" target="_blank" title="书房">书房</a>&emsp;<a href="http://www.meilele.com/category-ertongfang/" target="_blank" title="儿童房">儿童房</a>&emsp;<a href="http://www.meilele.com/category-huwaijiaju/" target="_blank" title="户外家具">户外家具</a></dd>
			</dl>
			<div id="JS_side_cat_list_1" class="hideMap">
			<div class="topMap clearfix">
		<div class="subCat clearfix">
			<div class="col">
					
				<dl class="item no_border">
					<dt class="dt"><a href="http://www.meilele.com/category-wofang/" class="red">卧室</a></dt>
					<dd class="dd">
												<span>| <a href="http://www.meilele.com/category-chuang/" target="_blank" title="床">床</a> </span>
												<span>| <a href="http://www.meilele.com/category-chuangdian/" target="_blank" title="床垫">床垫</a> </span>
												<span>| <a href="http://www.meilele.com/category-chuangtougui/" target="_blank" title="床头柜">床头柜</a> </span>
												<span>| <a href="http://www.meilele.com/category-yigui/" target="_blank" title="衣柜">衣柜</a> </span>
												<span>| <a href="http://www.meilele.com/category-dougui/" target="_blank" title="斗柜">斗柜</a> </span>
												<span>| <a href="http://www.meilele.com/category-zhuangtai/" target="_blank" title="妆台镜/妆凳">妆台镜/妆凳</a> </span>
												<span>| <a href="http://www.meilele.com/category-chuanyijing/" target="_blank" title="穿衣镜/衣帽架">穿衣镜/衣帽架</a> </span>
												<span>| <a href="http://www.meilele.com/category-guiyichuangweideng/" target="_blank" title="床尾凳">床尾凳</a> </span>
												<span>| <a href="http://www.meilele.com/category-woshitaofang/" target="_blank" title="卧室套装">卧室套装</a> </span>
											</dd>
				</dl>
					
				<dl class="item ">
					<dt class="dt"><a href="http://www.meilele.com/category-keting/" class="red">客厅</a></dt>
					<dd class="dd">
												<span>| <a href="http://www.meilele.com/category-shafa/" target="_blank" title="沙发">沙发</a> </span>
												<span>| <a href="http://www.meilele.com/category-chajihebianzhuo/" target="_blank" title="茶几/边桌">茶几/边桌</a> </span>
												<span>| <a href="http://www.meilele.com/category-dianshigui/" target="_blank" title="电视柜">电视柜</a> </span>
												<span>| <a href="http://www.meilele.com/category-xiegui/" target="_blank" title="鞋柜">鞋柜</a> </span>
												<span>| <a href="http://www.meilele.com/category-duoyonggui/" target="_blank" title="酒柜/装饰柜">酒柜/装饰柜</a> </span>
												<span>| <a href="http://www.meilele.com/category-pingfeng/" target="_blank" title="屏风">屏风</a> </span>
												<span>| <a href="http://www.meilele.com/category-denglei/" target="_blank" title="凳类">凳类</a> </span>
												<span>| <a href="http://www.meilele.com/category-ketingtaofang/" target="_blank" title="客厅套装">客厅套装</a> </span>
											</dd>
				</dl>
					
				<dl class="item ">
					<dt class="dt"><a href="http://www.meilele.com/category-canting/" class="red">餐厅</a></dt>
					<dd class="dd">
												<span>| <a href="http://www.meilele.com/category-canzhuo/" target="_blank" title="餐桌">餐桌</a> </span>
												<span>| <a href="http://www.meilele.com/category-canyi/" target="_blank" title="餐椅">餐椅</a> </span>
												<span>| <a href="http://www.meilele.com/category-canbiangui/" target="_blank" title="餐边柜">餐边柜</a> </span>
												<span>| <a href="http://www.meilele.com/category-cantingtaozhuang/" target="_blank" title="餐厅套装">餐厅套装</a> </span>
											</dd>
				</dl>
					
				<dl class="item ">
					<dt class="dt"><a href="http://www.meilele.com/category-shufang/" class="red">书房</a></dt>
					<dd class="dd">
												<span>| <a href="http://www.meilele.com/category-shuzhuogongzuotai/" target="_blank" title="书桌/工作台">书桌/工作台</a> </span>
												<span>| <a href="http://www.meilele.com/category-shugui/" target="_blank" title="书柜/书架">书柜/书架</a> </span>
												<span>| <a href="http://www.meilele.com/category-gongzuoyi/" target="_blank" title="书椅/转椅">书椅/转椅</a> </span>
												<span>| <a href="http://www.meilele.com/category-shufangtaozhuang/" target="_blank" title="书房套装">书房套装</a> </span>
											</dd>
				</dl>
					
				<dl class="item ">
					<dt class="dt"><a href="http://www.meilele.com/category-ertongfang/" class="red">儿童房</a></dt>
					<dd class="dd">
												<span>| <a href="http://www.meilele.com/category-ertongchuang/" target="_blank" title="儿童床">儿童床</a> </span>
												<span>| <a href="http://www.meilele.com/category-ertongchuangdian/" target="_blank" title="儿童床垫">儿童床垫</a> </span>
												<span>| <a href="http://www.meilele.com/category-ertongchuangtougui/" target="_blank" title="儿童床头柜">儿童床头柜</a> </span>
												<span>| <a href="http://www.meilele.com/category-ertongyigui/" target="_blank" title="儿童衣柜">儿童衣柜</a> </span>
												<span>| <a href="http://www.meilele.com/category-ertongshuzhuoertongdiannaotai/" target="_blank" title="书桌/电脑台">书桌/电脑台</a> </span>
												<span>| <a href="http://www.meilele.com/category-ertongyi/" target="_blank" title="儿童椅">儿童椅</a> </span>
												<span>| <a href="http://www.meilele.com/category-qitaertongjiaju/" target="_blank" title="其他">其他</a> </span>
												<span>| <a href="http://www.meilele.com/category-ertongfangtaozhuang/" target="_blank" title="儿童房套装">儿童房套装</a> </span>
											</dd>
				</dl>
					
				<dl class="item ">
					<dt class="dt"><a href="http://www.meilele.com/category-huwaijiaju/" class="red">户外家具</a></dt>
					<dd class="dd">
												<span>| <a href="http://www.meilele.com/category-xiuxianyi/" target="_blank" title="休闲椅">休闲椅</a> </span>
												<span>| <a href="http://www.meilele.com/category-diaolan/" target="_blank" title="吊篮/吊椅">吊篮/吊椅</a> </span>
												<span>| <a href="http://www.meilele.com/category-xiuxianzhuo/" target="_blank" title="休闲桌">休闲桌</a> </span>
												<span>| <a href="http://www.meilele.com/category-huwaitaozhuang/" target="_blank" title="户外套装">户外套装</a> </span>
												<span>| <a href="http://www.meilele.com/category-qiuqian/" target="_blank" title="秋千">秋千</a> </span>
												<span>| <a href="http://www.meilele.com/category-yaoyi/" target="_blank" title="摇椅">摇椅</a> </span>
												<span>| <a href="http://www.meilele.com/category-yaoyitengyitangyi/" target="_blank" title="藤艺家具">藤艺家具</a> </span>
												<span>| <a href="http://www.meilele.com/category-zheyangsan/" target="_blank" title="遮阳伞">遮阳伞</a> </span>
												<span>| <a href="http://www.meilele.com/category-tangchuang/" target="_blank" title="躺床">躺床</a> </span>
											</dd>
				</dl>
							</div>
		</div>
		<div class="bottomMap">
						<h1 class="f14 red">推荐品牌</h1>
			<ul class="brand clearfix"><li class="li addTopBorder"><a href="http://www.meilele.com/brand-241/" target="_blank" title="凯撒豪庭" class="img"><img src="http://image.meilele.com/images/201310/1382500123642169832.jpg" width="85" heiht="50" alt="凯撒豪庭"></a><a href="http://www.meilele.com/brand-241/" target="_blank" title="凯撒豪庭" class="name">凯撒豪庭</a></li><li class="li addTopBorder"><a href="http://www.meilele.com/brand-111/" target="_blank" title="韩菲尔" class="img"><img src="http://image.meilele.com/images/201310/1382500123237695148.jpg" width="85" heiht="50" alt="韩菲尔"></a><a href="http://www.meilele.com/brand-111/" target="_blank" title="韩菲尔" class="name">韩菲尔</a></li><li class="li "><a href="http://www.meilele.com/brand-267/" target="_blank" title="蒂美悦" class="img"><img src="http://image.meilele.com/images/201310/1382500123243571797.jpg" width="85" heiht="50" alt="蒂美悦"></a><a href="http://www.meilele.com/brand-267/" target="_blank" title="蒂美悦" class="name">蒂美悦</a></li><li class="li "><a href="http://www.meilele.com/brand-212/" target="_blank" title="卡富亚" class="img"><img src="http://image.meilele.com/images/201310/1382500123694697734.jpg" width="85" heiht="50" alt="卡富亚"></a><a href="http://www.meilele.com/brand-212/" target="_blank" title="卡富亚" class="name">卡富亚</a></li>			</ul>
									<h1 class="f14 red mt20">促销活动</h1>
			<ul class="activity"><li><a href="http://www.meilele.com/topic/201404-51jzh.html" target="_blank" title="5.1透明家装惠">•  5.1透明家装惠</a></li><li><a href="http://www.meilele.com/new_products.html?from=dhgc" target="_blank" title="新品家具，极速抢“鲜”">•  新品家具，极速抢“鲜”</a></li><li><a href="http://www.meilele.com/activity.html?from=dhgc" target="_blank" title="特价商品，抄底特卖专场!">•  特价商品，抄底特卖专场!</a></li>			</ul>
									<a class="g_ad_link" href="http://www.meilele.com/topic/201404-51jzh.html" target="_blank"><img src="http://image.meilele.com/images/201404/1398016205196897388.jpg"></a>
					</div>
	</div>
			</div>
		</div>
				<div class="list">
			<dl class="cat">
				<dt class="catName"><strong class="cat2 Left"><a href="http://www.meilele.com/jiancai/" target="_blank" title="">建材</a></strong><span class="Right">&gt;</span></dt>
				<dd class="catList"><a href="http://www.meilele.com/category-dengshizhaoming/" target="_blank" title="灯饰照明">灯饰照明</a>&emsp;<a href="http://www.meilele.com/category-chufangyongpin/" target="_blank" title="厨房用品">厨房用品</a>&emsp;<a href="http://www.meilele.com/category-chuweizhuangxiu/" target="_blank" title="卫浴用品">卫浴用品</a>&emsp;<a href="http://www.meilele.com/category-wujindianqi/" target="_blank" title="家装五金">家装五金</a>&emsp;<a href="http://www.meilele.com/category-qiangdimiancailiao/" target="_blank" title="墙地面">墙地面</a></dd>
			</dl>
			<div id="JS_side_cat_list_2" class="hideMap"></div>
		</div>
				<div class="list">
			<dl class="cat">
				<dt class="catName"><strong class="cat3 Left"><a href="http://www.meilele.com/shipin/" target="_blank" title="">家居家饰</a></strong><span class="Right">&gt;</span></dt>
				<dd class="catList"><a href="http://www.meilele.com/category-shenghuodianqi/" target="_blank" title="生活电器">生活电器</a>&emsp;<a href="http://www.meilele.com/category-chuangshangyongpin/" target="_blank" title="床上用品">床上用品</a>&emsp;<a href="http://www.meilele.com/category-jiajujiazhuang/" target="_blank" title="居家日用">居家日用</a>&emsp;<a href="http://www.meilele.com/category-buyizhiwu/" target="_blank" title="布艺织物">布艺织物</a>&emsp;<a href="http://www.meilele.com/category-gongyishipin/" target="_blank" title="家居饰品">家居饰品</a>&emsp;<a href="http://www.meilele.com/category-chufangcanyin/" target="_blank" title="厨房餐饮">厨房餐饮</a></dd>
			</dl>
			<div id="JS_side_cat_list_3" class="hideMap"></div>
		</div>
				<div class="hotMenu">
			<table><tr>
				<td>
					<strong>热荐</strong>
				</td>
				<td><a href="http://www.meilele.com/category-xidingdeng/" title="吸顶灯" target="_blank">吸顶灯</a><a href="http://www.meilele.com/category-diaodeng/" title="吊灯" target="_blank">吊灯</a><a href="http://www.meilele.com/category-chuangdian/" title="床垫" target="_blank">床垫</a></td>
			</tr></table>
		</div>
		<div class="otherMenu">
			<dl class="specal_zone">
				<dd>
					<a href="/miaosha/" target="_blank" title="秒杀" class="light">秒杀</a><a href="/paimai/" target="_blank" title="拍卖" class="light">拍卖</a><a href="/tuangou/" target="_blank" title="团购" class="light">团购</a><a href="/activity.html" target="_blank" title="特价">特价</a><!-- <a href="/countdown.html" target="_blank" title="现货" class="light">现货</a> --><a href="/hot_recommended.html" target="_blank" title="热销榜" class="light">热销榜</a>
															<a href="/nanning/temai_all_254.html" target="_blank" title="体验馆特卖" class="light">体验馆特卖</a>
										<a href="/new_products.html" target="_blank" title="新品特惠">新品特惠<i class="specal_new"></i></a>
				</dd>
			</dl>
			
		</div>
	</div>
	<div class="cat_shadow"></div>
</div>



<div class="slide_banner">
	<div id="JS_slide_container" class="slide_stage">
		<table id="JS_side_stage" style="width:500%;"><tr>
						<td><div class="bg" style="background:url(./images/1398013328534458490.jpg) 0 0 repeat-x;"><a href="" target="_blank" title="" style="background:url(./images/1398022653370505242.jpg) center center no-repeat;" data-bg="./images/1398022653370505242.jpg"></a></div></td>
						<td><div class="bg" style="background:url(./images/1398712429128225260.jpg) 0 0 repeat-x;"><a href="" target="_blank" title="" style="background:url(./images/loading.gif) center center no-repeat;" data-bg="./images/1398712223968843450.jpg"></a></div></td>
						<td><div class="bg" style="background:url(./images/1398020161197894201.jpg) 0 0 repeat-x;"><a href="" target="_blank" title="" style="background:url(./images/loading.gif) center center no-repeat;" data-bg="./images/1398015852289001228.jpg"></a></div></td>
						<td><div class="bg" style="background:url(./images/1399253027609995643.jpg) 0 0 repeat-x;"><a href="" target="_blank" title="" style="background:url(./images/loading.gif) center center no-repeat;" data-bg="./images/1399253003716629699.jpg"></a></div></td>
						<td><div class="bg" style="background:url(./images/1395628335290374707.jpg) 0 0 repeat-x;"><a href="" target="_blank" title="" style="background:url(./images/loading.gif) center center no-repeat;" data-bg="./images/1398015893135732531.jpg"></a></div></td>
					</tr></table> 
	</div>
	<div class="slide_handdler"><div id="JS_side_nav" class="w"><a class="current first" href="javascript:;"></a><a  href="javascript:;"></a><a  href="javascript:;"></a><a  href="javascript:;"></a><a  href="javascript:;"></a></div></div>
</div>


<div class="w mt20 floor1">
	<div class="header clearfix"><div class="Left"><a class="title" target="_blank"></a></div></div>
	<div class="main_new" id="JS_hover_img_box_1"><a href="http://www.meilele.com/category-yigui/goods-12434.html?from=syjp1" target="_blank" title="史上最甜美爆款衣柜" class="a_1 SCREEN-SHOW"><img class="img_1" src="http://image.meilele.com/images/blank.gif" data-src2="http://image.meilele.com/images/201404/1398273987802568877.jpg"></a><a href="http://www.meilele.com/topic/201404-cttz.html?from=syjp2" target="_blank" title="舌尖上的餐厅" class="a_2"><img class="img_2" src="http://image.meilele.com/images/blank.gif" data-src2="http://image.meilele.com/images/201404/1398831843479540267.jpg"></a><a href="http://www.meilele.com/category-yushigui/goods-51658.html?from=syjp3 " target="_blank" title="橡木雕花浴室柜" class="a_3"><img class="img_3" src="http://image.meilele.com/images/blank.gif" data-src2="http://image.meilele.com/images/201404/1397583708905406707.jpg"></a><a href="http://www.meilele.com/category-woshitaofang/goods-39273.html?from=syjp4 " target="_blank" title="甄选套装推荐
田园雕花卧室套装
" class="a_4"><img class="img_4" src="http://image.meilele.com/images/blank.gif" data-src2="http://image.meilele.com/images/201404/1398831869771852949.jpg"></a><a href="http://www.meilele.com/category-zhuangtai/goods-20400.html?from=syjp5" target="_blank" title="华贵之选*法式妆台镜" class="a_5"><img class="img_5" src="http://image.meilele.com/images/blank.gif" data-src2="http://image.meilele.com/images/201404/1398831929213748914.jpg"></a><a href="http://www.meilele.com/category-shafa/goods-39667.html?from=syjp6 " target="_blank" title="全网唯一英伦布艺
英式贵族实木沙发套装
" class="a_6"><img class="img_6" src="http://image.meilele.com/images/blank.gif" data-src2="http://image.meilele.com/images/201404/1398831964219038564.jpg"></a><a href="http://www.meilele.com/category-woshitaofang/goods-63439.html?from=syjp7 " target="_blank" title="万人热捧地中海卧室套房" class="a_7"><img class="img_7" src="http://image.meilele.com/images/blank.gif" data-src2="http://image.meilele.com/images/201404/1397583844032550266.jpg"></a><a href="http://www.meilele.com/category-cantingtaozhuang/goods-22187.html?from=syjp8" target="_blank" title="五星品质餐厅7套装" class="a_8"><img class="img_8" src="http://image.meilele.com/images/blank.gif" data-src2="http://image.meilele.com/images/201404/1397583888559176688.jpg"></a></div>
</div>

<div class="w footer-copy">
	
	<br />
	<span class="yen">&copy; 2005-2014 </span>MDD易购 版权所有，并保留所有权利。<br />
	<a href="http://www.miibeian.gov.cn/" target="_blank" class="gray" rel="nofollow">ICP备案证书号：桂ICP备0000000号</a><br />
	<span style="display:inline-block;margin-right:4px;vertical-align:top;"><a rel="nofollow" href="https://ss.knet.cn/verifyseal.dll?sn=e12042051010018574308175&amp;ct=df" id="kx_verify" tabindex="-1" target="_blank"><img src="http://image.meilele.com/themes/paipai/images/blank.gif" class="xinyu1" width="82" height="30" alt="可信网站"></a></span>
	<span style="display:inline-block;vertical-align:top;"><img class="xinyu2" src="http://image.meilele.com/themes/paipai/images/blank.gif" width="82" height="30" border="0"></span> 
</div>


<script id="JS_city_data" type="text/html">{"city_list":{"A":[{"pinyin":"anshan","region_name":"\u978d\u5c71","region_id":"76"},{"pinyin":"anqing","region_name":"\u5b89\u5e86","region_id":"142"},{"pinyin":"ahfuyang","region_name":"\u961c\u9633","region_id":"145"},{"pinyin":"anyang","region_name":"\u5b89\u9633","region_id":"196"},{"is_virtual":"1","pinyin":"aba","region_name":"\u963f\u575d","region_id":"290"},{"is_virtual":"1","pinyin":"anshun","region_name":"\u5b89\u987a","region_id":"296"},{"is_virtual":"1","pinyin":"ankang","region_name":"\u5b89\u5eb7","region_id":"333"},{"is_virtual":"1","pinyin":"akesudiqu","region_name":"\u963f\u514b\u82cf\u5730\u533a","region_id":"367"},{"is_virtual":"1","pinyin":"aletai","region_name":"\u963f\u52d2\u6cf0","region_id":"375"}],"B":[{"pinyin":"beijing","region_name":"\u5317\u4eac","region_id":"35"},{"pinyin":"baoding","region_name":"\u4fdd\u5b9a","region_id":"42"},{"pinyin":"baotou","region_name":"\u5305\u5934","region_id":"63"},{"pinyin":"bayannaoer","region_name":"\u5df4\u5f66\u6dd6\u5c14","region_id":"69"},{"is_virtual":"1","pinyin":"benxi","region_name":"\u672c\u6eaa","region_id":"78"},{"is_virtual":"1","pinyin":"baishan","region_name":"\u767d\u5c71","region_id":"93"},{"is_virtual":"1","pinyin":"baicheng","region_name":"\u767d\u57ce","region_id":"95"},{"pinyin":"bengbu","region_name":"\u868c\u57e0","region_id":"137"},{"pinyin":"bozhou","region_name":"\u4eb3\u5dde","region_id":"149"},{"pinyin":"binzhou","region_name":"\u6ee8\u5dde","region_id":"187"},{"is_virtual":"1","pinyin":"beihai","region_name":"\u5317\u6d77","region_id":"258"},{"is_virtual":"1","pinyin":"bazhong","region_name":"\u5df4\u4e2d","region_id":"288"},{"is_virtual":"1","pinyin":"baoshan","region_name":"\u4fdd\u5c71","region_id":"305"},{"pinyin":"baoji","region_name":"\u5b9d\u9e21","region_id":"327"},{"is_virtual":"1","pinyin":"baiyin","region_name":"\u767d\u94f6","region_id":"338"},{"is_virtual":"1","pinyin":"baiseshi","region_name":"\u767e\u8272\u5e02","region_id":"863"},{"is_virtual":"1","pinyin":"bijiediqu","region_name":"\u6bd5\u8282\u5730\u533a","region_id":"15311"}],"C":[{"pinyin":"chengde","region_name":"\u627f\u5fb7","region_id":"44"},{"pinyin":"cangzhou","region_name":"\u6ca7\u5dde","region_id":"45"},{"pinyin":"changzhi","region_name":"\u957f\u6cbb","region_id":"51"},{"pinyin":"chifeng","region_name":"\u8d64\u5cf0","region_id":"65"},{"is_virtual":"1","pinyin":"chaoyang","region_name":"\u671d\u9633","region_id":"86"},{"pinyin":"changchun","region_name":"\u957f\u6625","region_id":"88"},{"pinyin":"changzhou","region_name":"\u5e38\u5dde","region_id":"114"},{"pinyin":"chuzhou","region_name":"\u6ec1\u5dde","region_id":"144"},{"is_virtual":"1","pinyin":"chaohu","region_name":"\u5de2\u6e56","region_id":"147"},{"is_virtual":"1","pinyin":"chizhou","region_name":"\u6c60\u5dde","region_id":"150"},{"pinyin":"changsha","region_name":"\u957f\u6c99","region_id":"219"},{"pinyin":"changde","region_name":"\u5e38\u5fb7","region_id":"225"},{"pinyin":"chenzhou","region_name":"\u90f4\u5dde","region_id":"228"},{"is_virtual":"1","pinyin":"chongzuo","region_name":"\u5d07\u5de6","region_id":"267"},{"pinyin":"chongqing","region_name":"\u91cd\u5e86","region_id":"271"},{"pinyin":"chengdu","region_name":"\u6210\u90fd","region_id":"272"},{"pinyin":"cixi","region_name":"\u6148\u6eaa","region_id":"424"},{"is_virtual":"1","pinyin":"chuxiong","region_name":"\u695a\u96c4","region_id":"313"},{"pinyin":"changshu","region_name":"\u5e38\u719f","region_id":"15491"}],"D":[{"pinyin":"datong","region_name":"\u5927\u540c","region_id":"49"},{"pinyin":"dalian","region_name":"\u5927\u8fde","region_id":"75"},{"is_virtual":"1","pinyin":"dandong","region_name":"\u4e39\u4e1c","region_id":"79"},{"pinyin":"daqing","region_name":"\u5927\u5e86","region_id":"102"},{"pinyin":"dongying","region_name":"\u4e1c\u8425","region_id":"176"},{"pinyin":"dezhou","region_name":"\u5fb7\u5dde","region_id":"185"},{"pinyin":"dongguan","region_name":"\u4e1c\u839e","region_id":"249"},{"pinyin":"deyang","region_name":"\u5fb7\u9633","region_id":"276"},{"pinyin":"dazhou","region_name":"\u8fbe\u5dde","region_id":"285"},{"is_virtual":"1","pinyin":"dingxi","region_name":"\u5b9a\u897f","region_id":"345"},{"is_virtual":"1","pinyin":"danzhou","region_name":"\u510b\u5dde","region_id":"14905"},{"is_virtual":"1","pinyin":"dongfang","region_name":"\u4e1c\u65b9","region_id":"14908"},{"is_virtual":"1","pinyin":"dali","region_name":"\u5927\u7406","region_id":"314"},{"is_virtual":"1","pinyin":"dehong","region_name":"\u5fb7\u5b8f","region_id":"315"},{"is_virtual":"1","pinyin":"diqing","region_name":"\u8fea\u5e86","region_id":"317"}],"E":[{"is_virtual":"1","pinyin":"eerduosi","region_name":"\u9102\u5c14\u591a\u65af","region_id":"67"},{"pinyin":"ezhou","region_name":"\u9102\u5dde","region_id":"213"},{"pinyin":"enshi","region_name":"\u6069\u65bd","region_id":"218"}],"F":[{"pinyin":"fushun","region_name":"\u629a\u987a","region_id":"77"},{"is_virtual":"1","pinyin":"fuxin","region_name":"\u961c\u65b0","region_id":"82"},{"pinyin":"fuzhou","region_name":"\u798f\u5dde","region_id":"152"},{"is_virtual":"1","pinyin":"fuzhou2","region_name":"\u629a\u5dde","region_id":"170"},{"pinyin":"foshan","region_name":"\u4f5b\u5c71","region_id":"238"},{"is_virtual":"1","pinyin":"fangchenggang","region_name":"\u9632\u57ce\u6e2f","region_id":"259"},{"pinyin":"fuyang","region_name":"\u5bcc\u9633","region_id":"651"}],"G":[{"pinyin":"ganzhou","region_name":"\u8d63\u5dde","region_id":"167"},{"pinyin":"guangzhou","region_name":"\u5e7f\u5dde","region_id":"233"},{"pinyin":"guilin","region_name":"\u6842\u6797","region_id":"256"},{"is_virtual":"1","pinyin":"guigang","region_name":"\u8d35\u6e2f","region_id":"261"},{"is_virtual":"1","pinyin":"guangyuan","region_name":"\u5e7f\u5143","region_id":"278"},{"is_virtual":"1","pinyin":"guangan","region_name":"\u5e7f\u5b89","region_id":"284"},{"is_virtual":"1","pinyin":"ganzi","region_name":"\u7518\u5b5c","region_id":"291"},{"pinyin":"guiyang","region_name":"\u8d35\u9633","region_id":"293"},{"is_virtual":"1","pinyin":"guyuan","region_name":"\u56fa\u539f","region_id":"360"},{"pinyin":"gongzhuling","region_name":"\u516c\u4e3b\u5cad","region_id":"16247"}],"H":[{"pinyin":"handan","region_name":"\u90af\u90f8","region_id":"40"},{"is_virtual":"1","pinyin":"hengshui","region_name":"\u8861\u6c34","region_id":"47"},{"pinyin":"houma","region_name":"\u4faf\u9a6c","region_id":"59"},{"pinyin":"huhehaote","region_name":"\u547c\u548c\u6d69\u7279","region_id":"62"},{"pinyin":"hulunbeier","region_name":"\u547c\u4f26\u8d1d\u5c14","region_id":"68"},{"pinyin":"haerbin","region_name":"\u54c8\u5c14\u6ee8","region_id":"97"},{"is_virtual":"1","pinyin":"hegang","region_name":"\u9e64\u5c97","region_id":"100"},{"is_virtual":"1","pinyin":"heihe","region_name":"\u9ed1\u6cb3","region_id":"107"},{"pinyin":"huaian","region_name":"\u6dee\u5b89","region_id":"118"},{"pinyin":"hangzhou","region_name":"\u676d\u5dde","region_id":"124"},{"pinyin":"huzhou","region_name":"\u6e56\u5dde","region_id":"128"},{"pinyin":"hefei","region_name":"\u5408\u80a5","region_id":"135"},{"pinyin":"huainan","region_name":"\u6dee\u5357","region_id":"138"},{"is_virtual":"1","pinyin":"huaibei","region_name":"\u6dee\u5317","region_id":"140"},{"is_virtual":"1","pinyin":"huangshan","region_name":"\u9ec4\u5c71","region_id":"143"},{"pinyin":"huangshi","region_name":"\u9ec4\u77f3","region_id":"207"},{"is_virtual":"1","pinyin":"huanggang","region_name":"\u9ec4\u5188","region_id":"215"},{"pinyin":"hengyang","region_name":"\u8861\u9633","region_id":"222"},{"pinyin":"huaihua","region_name":"\u6000\u5316","region_id":"230"},{"pinyin":"huizhou","region_name":"\u60e0\u5dde","region_id":"243"},{"is_virtual":"1","pinyin":"heyuan","region_name":"\u6cb3\u6e90","region_id":"246"},{"is_virtual":"1","pinyin":"hezhou","region_name":"\u8d3a\u5dde","region_id":"264"},{"is_virtual":"1","pinyin":"hechi","region_name":"\u6cb3\u6c60","region_id":"265"},{"pinyin":"haikou","region_name":"\u6d77\u53e3","region_id":"268"},{"pinyin":"hanzhong","region_name":"\u6c49\u4e2d","region_id":"331"},{"is_virtual":"1","pinyin":"hami","region_name":"\u54c8\u5bc6","region_id":"365"},{"is_virtual":"1","pinyin":"hetian","region_name":"\u548c\u7530","region_id":"366"},{"is_virtual":"1","pinyin":"huludao","region_name":"\u846b\u82a6\u5c9b","region_id":"13717"},{"is_virtual":"1","pinyin":"heze","region_name":"\u83cf\u6cfd","region_id":"14294"},{"is_virtual":"1","pinyin":"honghe","region_name":"\u7ea2\u6cb3","region_id":"311"},{"pinyin":"haicheng","region_name":"\u6d77\u57ce","region_id":"16213"}],"J":[{"pinyin":"jincheng","region_name":"\u664b\u57ce","region_id":"52"},{"pinyin":"jinzhong","region_name":"\u664b\u4e2d","region_id":"54"},{"pinyin":"jinzhou","region_name":"\u9526\u5dde","region_id":"80"},{"pinyin":"jilin","region_name":"\u5409\u6797","region_id":"89"},{"is_virtual":"1","pinyin":"jixi","region_name":"\u9e21\u897f","region_id":"99"},{"pinyin":"jiamusi","region_name":"\u4f73\u6728\u65af","region_id":"104"},{"pinyin":"jstaizhou","region_name":"\u6cf0\u5dde","region_id":"122"},{"pinyin":"jiaxing","region_name":"\u5609\u5174","region_id":"127"},{"pinyin":"jinhua","region_name":"\u91d1\u534e","region_id":"130"},{"is_virtual":"1","pinyin":"jingdezhen","region_name":"\u666f\u5fb7\u9547","region_id":"162"},{"pinyin":"jiujiang","region_name":"\u4e5d\u6c5f","region_id":"164"},{"is_virtual":"1","pinyin":"jian","region_name":"\u5409\u5b89","region_id":"168"},{"pinyin":"jinan","region_name":"\u6d4e\u5357","region_id":"172"},{"pinyin":"jining","region_name":"\u6d4e\u5b81","region_id":"179"},{"pinyin":"jiaozuo","region_name":"\u7126\u4f5c","region_id":"193"},{"pinyin":"jingzhou","region_name":"\u8346\u5dde","region_id":"210"},{"pinyin":"jingmen","region_name":"\u8346\u95e8","region_id":"212"},{"pinyin":"jiangmen","region_name":"\u6c5f\u95e8","region_id":"239"},{"is_virtual":"1","pinyin":"jieyang","region_name":"\u63ed\u9633","region_id":"252"},{"pinyin":"jiayuguan","region_name":"\u5609\u5cea\u5173","region_id":"336"},{"is_virtual":"1","pinyin":"jinchang","region_name":"\u91d1\u660c","region_id":"337"},{"pinyin":"jiaozhou","region_name":"\u80f6\u5dde","region_id":"515"},{"pinyin":"jiangyin","region_name":"\u6c5f\u9634","region_id":"520"},{"pinyin":"jingjiang","region_name":"\u9756\u6c5f","region_id":"597"},{"pinyin":"jintan","region_name":"\u91d1\u575b","region_id":"598"},{"pinyin":"jiyuan","region_name":"\u6d4e\u6e90","region_id":"14527"}],"K":[{"pinyin":"kunming","region_name":"\u6606\u660e","region_id":"302"},{"is_virtual":"1","pinyin":"kelamayi","region_name":"\u514b\u62c9\u739b\u4f9d","region_id":"363"},{"is_virtual":"1","pinyin":"kashi","region_name":"\u5580\u4ec0","region_id":"368"},{"pinyin":"kunshan","region_name":"\u6606\u5c71","region_id":"521"},{"is_virtual":"1","pinyin":"kuerle","region_name":"\u5e93\u5c14\u52d2","region_id":"15479"}],"L":[{"pinyin":"langfang","region_name":"\u5eca\u574a","region_id":"46"},{"pinyin":"linfen","region_name":"\u4e34\u6c7e","region_id":"57"},{"pinyin":"lvliang","region_name":"\u5415\u6881","region_id":"58"},{"pinyin":"liaoyang","region_name":"\u8fbd\u9633","region_id":"83"},{"is_virtual":"1","pinyin":"liaoyuan","region_name":"\u8fbd\u6e90","region_id":"91"},{"pinyin":"lianyungang","region_name":"\u8fde\u4e91\u6e2f","region_id":"117"},{"pinyin":"lishui","region_name":"\u4e3d\u6c34","region_id":"134"},{"is_virtual":"1","pinyin":"liuan","region_name":"\u516d\u5b89","region_id":"148"},{"pinyin":"longyan","region_name":"\u9f99\u5ca9","region_id":"159"},{"is_virtual":"1","pinyin":"laiwu","region_name":"\u83b1\u829c","region_id":"183"},{"pinyin":"linyi","region_name":"\u4e34\u6c82","region_id":"184"},{"is_virtual":"1","pinyin":"liaocheng","region_name":"\u804a\u57ce","region_id":"186"},{"pinyin":"luoyang","region_name":"\u6d1b\u9633","region_id":"191"},{"pinyin":"luohe","region_name":"\u6f2f\u6cb3","region_id":"199"},{"pinyin":"loudi","region_name":"\u5a04\u5e95","region_id":"231"},{"pinyin":"liuzhou","region_name":"\u67f3\u5dde","region_id":"255"},{"is_virtual":"1","pinyin":"laibin","region_name":"\u6765\u5bbe","region_id":"266"},{"pinyin":"luzhou","region_name":"\u6cf8\u5dde","region_id":"275"},{"pinyin":"leshan","region_name":"\u4e50\u5c71","region_id":"281"},{"is_virtual":"1","pinyin":"liangshan","region_name":"\u51c9\u5c71","region_id":"292"},{"pinyin":"liupanshui","region_name":"\u516d\u76d8\u6c34","region_id":"294"},{"is_virtual":"1","pinyin":"lijiang","region_name":"\u4e3d\u6c5f","region_id":"307"},{"is_virtual":"1","pinyin":"lincang","region_name":"\u4e34\u6ca7","region_id":"309"},{"pinyin":"lanzhou","region_name":"\u5170\u5dde","region_id":"335"},{"pinyin":"laizhou","region_name":"\u83b1\u5dde","region_id":"506"},{"pinyin":"laixi","region_name":"\u83b1\u897f","region_id":"517"},{"pinyin":"liyang","region_name":"\u6ea7\u9633","region_id":"599"},{"pinyin":"linan","region_name":"\u4e34\u5b89","region_id":"661"},{"pinyin":"liuyang","region_name":"\u6d4f\u9633","region_id":"16217"}],"M":[{"pinyin":"mudanjiang","region_name":"\u7261\u4e39\u6c5f","region_id":"106"},{"pinyin":"maanshan","region_name":"\u9a6c\u978d\u5c71","region_id":"139"},{"is_virtual":"1","pinyin":"maoming","region_name":"\u8302\u540d","region_id":"241"},{"is_virtual":"1","pinyin":"meizhou","region_name":"\u6885\u5dde","region_id":"244"},{"pinyin":"mianyang","region_name":"\u7ef5\u9633","region_id":"277"},{"pinyin":"meishan","region_name":"\u7709\u5c71","region_id":"286"}],"N":[{"pinyin":"nanjing","region_name":"\u5357\u4eac","region_id":"111"},{"pinyin":"nantong","region_name":"\u5357\u901a","region_id":"116"},{"pinyin":"ningbo","region_name":"\u5b81\u6ce2","region_id":"125"},{"is_virtual":"1","pinyin":"nanping","region_name":"\u5357\u5e73","region_id":"158"},{"pinyin":"nanchang","region_name":"\u5357\u660c","region_id":"161"},{"pinyin":"nanyang","region_name":"\u5357\u9633","region_id":"201"},{"pinyin":"nanning","region_name":"\u5357\u5b81","region_id":"254"},{"is_virtual":"1","pinyin":"neijiang","region_name":"\u5185\u6c5f","region_id":"280"},{"pinyin":"nanchong","region_name":"\u5357\u5145","region_id":"282"},{"is_virtual":"1","pinyin":"ningdeshi","region_name":"\u5b81\u5fb7\u5e02","region_id":"650"},{"is_virtual":"1","pinyin":"nujiang","region_name":"\u6012\u6c5f","region_id":"316"}],"P":[{"pinyin":"panjin","region_name":"\u76d8\u9526","region_id":"84"},{"pinyin":"putian","region_name":"\u8386\u7530","region_id":"154"},{"is_virtual":"1","pinyin":"pingxiang","region_name":"\u840d\u4e61","region_id":"163"},{"pinyin":"pingdingshan","region_name":"\u5e73\u9876\u5c71","region_id":"192"},{"pinyin":"puyang","region_name":"\u6fee\u9633","region_id":"197"},{"is_virtual":"1","pinyin":"panzhihua","region_name":"\u6500\u679d\u82b1","region_id":"274"},{"is_virtual":"1","pinyin":"pingliang","region_name":"\u5e73\u51c9","region_id":"342"},{"is_virtual":"1","pinyin":"puershi","region_name":"\u666e\u6d31\u5e02","region_id":"787"}],"Q":[{"pinyin":"qinhuangdao","region_name":"\u79e6\u7687\u5c9b","region_id":"39"},{"is_virtual":"1","pinyin":"qiqihaer","region_name":"\u9f50\u9f50\u54c8\u5c14","region_id":"98"},{"is_virtual":"1","pinyin":"qitaihe","region_name":"\u4e03\u53f0\u6cb3","region_id":"105"},{"pinyin":"quzhou","region_name":"\u8862\u5dde","region_id":"131"},{"pinyin":"quanzhou","region_name":"\u6cc9\u5dde","region_id":"156"},{"pinyin":"qingdao","region_name":"\u9752\u5c9b","region_id":"173"},{"pinyin":"qingyuan","region_name":"\u6e05\u8fdc","region_id":"248"},{"pinyin":"qinzhou","region_name":"\u94a6\u5dde","region_id":"260"},{"is_virtual":"1","pinyin":"qianxinan","region_name":"\u9ed4\u897f\u5357","region_id":"299"},{"is_virtual":"1","pinyin":"qiandongnan","region_name":"\u9ed4\u4e1c\u5357","region_id":"300"},{"is_virtual":"1","pinyin":"qiannan","region_name":"\u9ed4\u5357","region_id":"301"},{"is_virtual":"1","pinyin":"qujing","region_name":"\u66f2\u9756","region_id":"303"},{"pinyin":"qingyang","region_name":"\u5e86\u9633","region_id":"344"},{"is_virtual":"1","pinyin":"qianjiang","region_name":"\u6f5c\u6c5f","region_id":"14668"},{"pinyin":"qionghai","region_name":"\u743c\u6d77","region_id":"14904"}],"R":[{"pinyin":"rizhao","region_name":"\u65e5\u7167","region_id":"182"},{"pinyin":"rugao","region_name":"\u5982\u768b","region_id":"587"}],"S":[{"pinyin":"shijiazhuang","region_name":"\u77f3\u5bb6\u5e84","region_id":"37"},{"is_virtual":"1","pinyin":"shuozhou","region_name":"\u6714\u5dde","region_id":"53"},{"pinyin":"shenyang","region_name":"\u6c88\u9633","region_id":"74"},{"is_virtual":"1","pinyin":"siping","region_name":"\u56db\u5e73","region_id":"90"},{"pinyin":"songyuan","region_name":"\u677e\u539f","region_id":"94"},{"is_virtual":"1","pinyin":"shuangyashan","region_name":"\u53cc\u9e2d\u5c71","region_id":"101"},{"is_virtual":"1","pinyin":"suihua","region_name":"\u7ee5\u5316","region_id":"108"},{"pinyin":"shanghai","region_name":"\u4e0a\u6d77","region_id":"110"},{"pinyin":"suzhou","region_name":"\u82cf\u5dde","region_id":"115"},{"pinyin":"suqian","region_name":"\u5bbf\u8fc1","region_id":"123"},{"pinyin":"shaoxing","region_name":"\u7ecd\u5174","region_id":"129"},{"is_virtual":"1","pinyin":"suzhou2","region_name":"\u5bbf\u5dde","region_id":"146"},{"pinyin":"shangrao","region_name":"\u4e0a\u9976","region_id":"171"},{"is_virtual":"1","pinyin":"sanmenxia","region_name":"\u4e09\u95e8\u5ce1","region_id":"200"},{"pinyin":"shangqiu","region_name":"\u5546\u4e18","region_id":"202"},{"pinyin":"shiyan","region_name":"\u5341\u5830","region_id":"209"},{"pinyin":"suizhou","region_name":"\u968f\u5dde","region_id":"217"},{"pinyin":"shaoyang","region_name":"\u90b5\u9633","region_id":"223"},{"pinyin":"shenzhen","region_name":"\u6df1\u5733","region_id":"234"},{"pinyin":"shantou","region_name":"\u6c55\u5934","region_id":"236"},{"is_virtual":"1","pinyin":"shaoguan","region_name":"\u97f6\u5173","region_id":"237"},{"is_virtual":"1","pinyin":"shanwei","region_name":"\u6c55\u5c3e","region_id":"245"},{"is_virtual":"1","pinyin":"sanya","region_name":"\u4e09\u4e9a","region_id":"269"},{"pinyin":"suining","region_name":"\u9042\u5b81","region_id":"279"},{"is_virtual":"1","pinyin":"shangluo","region_name":"\u5546\u6d1b","region_id":"334"},{"is_virtual":"1","pinyin":"shizuishan","region_name":"\u77f3\u5634\u5c71","region_id":"358"},{"is_virtual":"1","pinyin":"sanmingshi","region_name":"\u4e09\u660e\u5e02","region_id":"643"},{"pinyin":"shangyu","region_name":"\u4e0a\u865e","region_id":"669"},{"is_virtual":"1","pinyin":"shennongjialinqu","region_name":"\u795e\u519c\u67b6\u6797\u533a","region_id":"14651"}],"T":[{"pinyin":"tianjin","region_name":"\u5929\u6d25","region_id":"36"},{"pinyin":"tangshan","region_name":"\u5510\u5c71","region_id":"38"},{"pinyin":"taiyuan","region_name":"\u592a\u539f","region_id":"48"},{"pinyin":"tongliao","region_name":"\u901a\u8fbd","region_id":"66"},{"pinyin":"tieling","region_name":"\u94c1\u5cad","region_id":"85"},{"is_virtual":"1","pinyin":"tonghua","region_name":"\u901a\u5316","region_id":"92"},{"pinyin":"taizhou","region_name":"\u53f0\u5dde","region_id":"133"},{"is_virtual":"1","pinyin":"tongling","region_name":"\u94dc\u9675","region_id":"141"},{"pinyin":"taian","region_name":"\u6cf0\u5b89","region_id":"180"},{"is_virtual":"1","pinyin":"tongchuan","region_name":"\u94dc\u5ddd","region_id":"326"},{"is_virtual":"1","pinyin":"tianshui","region_name":"\u5929\u6c34","region_id":"339"},{"is_virtual":"1","pinyin":"tulufan","region_name":"\u5410\u9c81\u756a","region_id":"364"},{"pinyin":"taicang","region_name":"\u592a\u4ed3","region_id":"522"},{"pinyin":"taixing","region_name":"\u6cf0\u5174","region_id":"601"},{"pinyin":"tonglu","region_name":"\u6850\u5e90","region_id":"660"},{"pinyin":"tongxiang","region_name":"\u6850\u4e61","region_id":"664"},{"is_virtual":"1","pinyin":"tianmen","region_name":"\u5929\u95e8","region_id":"14667"},{"is_virtual":"1","pinyin":"tongrendiqu","region_name":"\u94dc\u4ec1\u5730\u533a","region_id":"15310"}],"W":[{"is_virtual":"1","pinyin":"wuhai","region_name":"\u4e4c\u6d77","region_id":"64"},{"is_virtual":"1","pinyin":"wulanchabushi","region_name":"\u4e4c\u5170\u5bdf\u5e03\u5e02","region_id":"70"},{"pinyin":"wuxi","region_name":"\u65e0\u9521","region_id":"112"},{"pinyin":"wenzhou","region_name":"\u6e29\u5dde","region_id":"126"},{"pinyin":"wuhu","region_name":"\u829c\u6e56","region_id":"136"},{"pinyin":"weifang","region_name":"\u6f4d\u574a","region_id":"178"},{"pinyin":"weihai","region_name":"\u5a01\u6d77","region_id":"181"},{"pinyin":"wuhan","region_name":"\u6b66\u6c49","region_id":"206"},{"is_virtual":"1","pinyin":"wuzhou","region_name":"\u68a7\u5dde","region_id":"257"},{"pinyin":"weinan","region_name":"\u6e2d\u5357","region_id":"329"},{"is_virtual":"1","pinyin":"wuwei","region_name":"\u6b66\u5a01","region_id":"340"},{"is_virtual":"1","pinyin":"wuzhong","region_name":"\u5434\u5fe0","region_id":"359"},{"pinyin":"wulumuqi","region_name":"\u4e4c\u9c81\u6728\u9f50","region_id":"362"},{"is_virtual":"1","pinyin":"wuzhishan","region_name":"\u4e94\u6307\u5c71","region_id":"14903"},{"is_virtual":"1","pinyin":"wenchang","region_name":"\u6587\u660c","region_id":"14906"},{"is_virtual":"1","pinyin":"wanning","region_name":"\u4e07\u5b81","region_id":"14907"},{"is_virtual":"1","pinyin":"wenshan","region_name":"\u6587\u5c71","region_id":"310"}],"X":[{"pinyin":"xingtai","region_name":"\u90a2\u53f0","region_id":"41"},{"is_virtual":"1","pinyin":"xinzhou","region_name":"\u5ffb\u5dde","region_id":"56"},{"is_virtual":"1","pinyin":"xinganmeng","region_name":"\u5174\u5b89\u76df","region_id":"71"},{"is_virtual":"1","pinyin":"xilinguolemeng","region_name":"\u9521\u6797\u90ed\u52d2\u76df","region_id":"72"},{"pinyin":"xuzhou","region_name":"\u5f90\u5dde","region_id":"113"},{"is_virtual":"1","pinyin":"xuancheng","region_name":"\u5ba3\u57ce","region_id":"151"},{"pinyin":"xiamen","region_name":"\u53a6\u95e8","region_id":"153"},{"pinyin":"xinyu","region_name":"\u65b0\u4f59","region_id":"165"},{"pinyin":"xinxiang","region_name":"\u65b0\u4e61","region_id":"195"},{"pinyin":"xuchang","region_name":"\u8bb8\u660c","region_id":"198"},{"pinyin":"xinyang","region_name":"\u4fe1\u9633","region_id":"203"},{"pinyin":"xiangyang","region_name":"\u8944\u9633","region_id":"208"},{"pinyin":"xiaogan","region_name":"\u5b5d\u611f","region_id":"214"},{"is_virtual":"1","pinyin":"xianning","region_name":"\u54b8\u5b81","region_id":"216"},{"pinyin":"xiangtan","region_name":"\u6e58\u6f6d","region_id":"221"},{"is_virtual":"1","pinyin":"xiangxi","region_name":"\u6e58\u897f","region_id":"232"},{"pinyin":"xian","region_name":"\u897f\u5b89","region_id":"325"},{"pinyin":"xianyang","region_name":"\u54b8\u9633","region_id":"328"},{"pinyin":"xining","region_name":"\u897f\u5b81","region_id":"349"},{"pinyin":"xiaoyi","region_name":"\u5b5d\u4e49","region_id":"471"},{"pinyin":"xiantao","region_name":"\u4ed9\u6843","region_id":"526"},{"pinyin":"xinghua","region_name":"\u5174\u5316","region_id":"593"},{"is_virtual":"1","pinyin":"xishuangbanna","region_name":"\u897f\u53cc\u7248\u7eb3","region_id":"312"}],"Y":[{"is_virtual":"1","pinyin":"yangquan","region_name":"\u9633\u6cc9","region_id":"50"},{"pinyin":"yuncheng","region_name":"\u8fd0\u57ce","region_id":"55"},{"pinyin":"yingkou","region_name":"\u8425\u53e3","region_id":"81"},{"is_virtual":"1","pinyin":"yichun2","region_name":"\u4f0a\u6625","region_id":"103"},{"pinyin":"yancheng","region_name":"\u76d0\u57ce","region_id":"119"},{"pinyin":"yangzhou","region_name":"\u626c\u5dde","region_id":"120"},{"is_virtual":"1","pinyin":"yingtan","region_name":"\u9e70\u6f6d","region_id":"166"},{"is_virtual":"1","pinyin":"yichun","region_name":"\u5b9c\u6625","region_id":"169"},{"pinyin":"yantai","region_name":"\u70df\u53f0","region_id":"177"},{"pinyin":"yichang","region_name":"\u5b9c\u660c","region_id":"211"},{"pinyin":"yueyang","region_name":"\u5cb3\u9633","region_id":"224"},{"pinyin":"yiyang","region_name":"\u76ca\u9633","region_id":"227"},{"is_virtual":"1","pinyin":"yongzhou","region_name":"\u6c38\u5dde","region_id":"229"},{"is_virtual":"1","pinyin":"yangjiang","region_name":"\u9633\u6c5f","region_id":"247"},{"is_virtual":"1","pinyin":"yunfu","region_name":"\u4e91\u6d6e","region_id":"253"},{"is_virtual":"1","pinyin":"yulin","region_name":"\u7389\u6797","region_id":"262"},{"pinyin":"yibin","region_name":"\u5b9c\u5bbe","region_id":"283"},{"is_virtual":"1","pinyin":"yaan","region_name":"\u96c5\u5b89","region_id":"287"},{"is_virtual":"1","pinyin":"yuxi","region_name":"\u7389\u6eaa","region_id":"304"},{"is_virtual":"1","pinyin":"yanan","region_name":"\u5ef6\u5b89","region_id":"330"},{"is_virtual":"1","pinyin":"yulin2","region_name":"\u6986\u6797","region_id":"332"},{"pinyin":"yinchuan","region_name":"\u94f6\u5ddd","region_id":"357"},{"pinyin":"yiwu","region_name":"\u4e49\u4e4c","region_id":"420"},{"pinyin":"yixing","region_name":"\u5b9c\u5174","region_id":"523"},{"pinyin":"yuyao","region_name":"\u4f59\u59da","region_id":"653"},{"is_virtual":"1","pinyin":"yiningshi","region_name":"\u4f0a\u5b81\u5e02","region_id":"16168"},{"pinyin":"yanji","region_name":"\u5ef6\u5409","region_id":"16249"}],"Z":[{"pinyin":"zhangjiakou","region_name":"\u5f20\u5bb6\u53e3","region_id":"43"},{"pinyin":"zhenjiang","region_name":"\u9547\u6c5f","region_id":"121"},{"pinyin":"zhoushan","region_name":"\u821f\u5c71","region_id":"132"},{"pinyin":"zhangzhou","region_name":"\u6f33\u5dde","region_id":"157"},{"pinyin":"zibo","region_name":"\u6dc4\u535a","region_id":"174"},{"pinyin":"zaozhuang","region_name":"\u67a3\u5e84","region_id":"175"},{"pinyin":"zhengzhou","region_name":"\u90d1\u5dde","region_id":"189"},{"pinyin":"zhoukou","region_name":"\u5468\u53e3","region_id":"204"},{"pinyin":"zhumadian","region_name":"\u9a7b\u9a6c\u5e97","region_id":"205"},{"pinyin":"zhuzhou","region_name":"\u682a\u6d32","region_id":"220"},{"is_virtual":"1","pinyin":"zhangjiajie","region_name":"\u5f20\u5bb6\u754c","region_id":"226"},{"pinyin":"zhuhai","region_name":"\u73e0\u6d77","region_id":"235"},{"pinyin":"zhanjiang","region_name":"\u6e5b\u6c5f","region_id":"240"},{"is_virtual":"1","pinyin":"zhaoqing","region_name":"\u8087\u5e86","region_id":"242"},{"pinyin":"zhongshan","region_name":"\u4e2d\u5c71","region_id":"250"},{"is_virtual":"1","pinyin":"zigong","region_name":"\u81ea\u8d21","region_id":"273"},{"pinyin":"ziyang","region_name":"\u8d44\u9633","region_id":"289"},{"pinyin":"zunyi","region_name":"\u9075\u4e49","region_id":"295"},{"is_virtual":"1","pinyin":"zhaotong","region_name":"\u662d\u901a","region_id":"306"},{"is_virtual":"1","pinyin":"zhangye","region_name":"\u5f20\u6396","region_id":"341"},{"is_virtual":"1","pinyin":"zhongweishi","region_name":"\u4e2d\u536b\u5e02","region_id":"361"},{"pinyin":"zhucheng","region_name":"\u8bf8\u57ce","region_id":"498"},{"pinyin":"zhangjiagang","region_name":"\u5f20\u5bb6\u6e2f","region_id":"524"},{"pinyin":"zhuji","region_name":"\u8bf8\u66a8","region_id":"670"}]},"host_city_list":{"9":{"region_name":"\u5357\u4eac","region_id":"111","pinyin":"nanjing"},"8":{"region_name":"\u91cd\u5e86","region_id":"271","pinyin":"chongqing"},"7":{"region_name":"\u6b66\u6c49","region_id":"206","pinyin":"wuhan"},"6":{"region_name":"\u5929\u6d25","region_id":"36","pinyin":"tianjin"},"5":{"region_name":"\u897f\u5b89","region_id":"325","pinyin":"xian"},"4":{"region_name":"\u6210\u90fd","region_id":"272","pinyin":"chengdu"},"3":{"region_name":"\u6df1\u5733","region_id":"234","pinyin":"shenzhen"},"2":{"region_name":"\u5e7f\u5dde","region_id":"233","pinyin":"guangzhou"},"1":{"region_name":"\u4e0a\u6d77","region_id":"110","pinyin":"shanghai"},"0":{"region_name":"\u5317\u4eac","region_id":"35","pinyin":"beijing"}}}</script>

<textarea id="JS_choose_city_source" style="display:none">
	<div class="hideMap">
		<div class="showPanel clearfix">
			<div class="Left mycity">
				<div id="JS_current_city_box">
					当前城市：<strong id="JS_city_current_city"></strong>
					<a class="red" style="display:none" id="JS_set_default_city_header" href="javascript:;">[设为默认城市]</a>
				</div>
				<div id="JS_default_city_delete" style="dsiplay:none"></div>
			</div>

		<div class="showPanel showPanel2 clearfix">
			<div class="hot_city" id="JS_header_city_hot"></div>
			<div class="mt10">
				<div id="JS_search_city_tip_header" class="search_city_tip"  style="display:none;">抱歉，该城市暂无体验馆！</div>
				<input id="JS_search_city_input_header" class="search_city_input" value="输入城市名" /><input type="button" id="JS_search_city_submit_header" class="search_city_submit" value="搜索">
			</div>
			<div class="city_words mt10" id="JS_header_city_char"></div>
		</div>
		<div class="scrollBody">
			<div class="cityMap clearfix">
				<table id="JS_header_city_list" class="city_list"></table>
			</div>

			<div class="scrollBar"><span id="JS_header_city_bar"></span></div>
		</div>
	</div>
</textarea>


<script src="./js/jq.js?0509"></script> 
<script>    window.M = window.M || {}; if ($.addToCart) M.addToCart = $.addToCart</script>
<script>
    $.__IMG = 'http://image.meilele.com' || 'http://image.meilele.com';

    (function ($) {
        var lists = [
		['checkPrize', 'checkprize.min.js?0116g'],
		['sendSms', 'sendsms.min.js?0428'],
		['orderQuery', 'orderquery.min.js?0116g'],
		['addToCart', 'addtocart.min.js?0219'],
		['costDownTip', 'costdowntip.min.js?1119'],
		['searchKey', 'searchkey.min.js?0915'],
		['getComment', 'getcomment.min.js?0107'],
		['quickBuy', 'quickbuy.min.js?0312'],
		['onlineVideo', 'onlinevideo.min.js?0410'],
		['wholehouse', 'wholehouse.min.js?0507']
	];
        var kk = lists.length;
        for (var k = 0; k < kk; k++) {
            var key = lists[k][0];
            var file = lists[k][1];
            $[key] = (function (key, file) {
                return function () {
                    var params = arguments;
                    $.req(file, function () {
                        $[key].apply($, params);
                    })
                }
            })(key, file);
        }
        //特殊
        $.showLoginBox = function (callback, refresh) {
            if ($.cookie("meilele_login") == "1" && $.cookie("ECS[username]")) {
                if (typeof callback == "function") {
                    callback({
                        "username": $.cookie("ECS[username]"),
                        "email": $.cookie("ECS[email]")
                    });
                }
                return;
            }
            $.req('showloginbox.min.js?0419', function () {
                $.showLoginBox(callback, refresh);
            });
        }
    })(jQuery);
</script>
<script type="text/javascript">
    (function (c, b) { var a = b("#JS_head_login"); a.on("click", "#JS_login_out", function () { b.ajax({ url: "/user/?act=logout", type: "get", cache: false, dataType: "json", success: function (d) { if (d.error == 0) { window.location.reload(); return false; } else { b.alert("注销失败，请重试！"); } }, error: function () { b.alert("网络异常，请重试！"); } }); }); })(document, jQuery); function _INIT_HEAD_SEARCH(data) { var json; try { json = eval(data.html_content); } catch (e) { } if (json && json.length) { var url = location.pathname; var wordIndex = -1; var tmpFilter; window.__HEAD_SEARCH_WORDS_ARR = []; window.__HEAD_SEARCH_WORDS_OBJ = {}; if (/\/jiaju\//.test(url)) { wordIndex = 0; } else { if (/\/jiancai\//.test(url)) { wordIndex = 1; } else { if (/\/shipin\//.test(url)) { wordIndex = 2; } } } for (var k = 0, kk = json.length; k < kk; k++) { tmpFilter = json[k].type.split(""); if (wordIndex == -1 || tmpFilter[wordIndex] == 1) { __HEAD_SEARCH_WORDS_ARR.push(json[k]); __HEAD_SEARCH_WORDS_OBJ[json[k].text] = json[k]; } } var inpt = $("#JS_MLL_search_header_input")[0]; if (__HEAD_SEARCH_WORDS_ARR.length && inpt && inpt.value == "") { inpt.value = MLL_Header_search_words(); inpt.onfocus = function () { this.value = ""; this.onfocus = function () { }; }; inpt.onblur = function () { if (this.value == "") { this.value = MLL_Header_search_words(); this.onfocus = function () { this.value = ""; this.onfocus = function () { }; }; } }; } } } function MLL_Header_search_words() { var b = __HEAD_SEARCH_WORDS_ARR, a = Math.floor(Math.random() * b.length); return b[a].text; } function MLL_header_search_submit() { var a = $("#JS_MLL_search_header_input")[0]; var b = $("#JS_search_form")[0]; var c = a.value + ""; c = c.replace(/\s/g, ""); if (!c) { return false; } if (window.__HEAD_SEARCH_WORDS_OBJ && __HEAD_SEARCH_WORDS_OBJ[c]) { location.href = __HEAD_SEARCH_WORDS_OBJ[c].href + (__HEAD_SEARCH_WORDS_OBJ[c].href.indexOf("#") >= 0 ? "&" : "#") + "kw=" + encodeURIComponent(c); return false; } else { a.value = c; return true; } } function _show_(j, d) { if (!j) { return; } if (d && d.source && d.target) { var b = typeof d.source === "string" ? $("#" + d.source) : $(d.source); var l = typeof d.target === "string" ? $("#" + d.target) : $(d.target); var f = typeof d.data === "string" ? $("#" + d.data) : $(d.data); if (b.length && l.length && !l.isDone) { var h = $(b.val() || sourse.html()); if (f.length && typeof d.templateFunction == "function") { var i = f.val() || f.html(); i = $.parseJSON(i); h = d.templateFunction(h, i); f.remove(); } l.empty().append(h); b.remove(); if (typeof d.callback == "function") { d.callback(); } l.isDone = true; } } $(j).addClass("hover"); if (d && d.isLazyLoad && j.isDone) { var g = j.find("img"); for (var e = 0, c = g.length; e < c; e++) { var a = g[e].getAttribute("data-src_index_menu"); if (a) { g[e].setAttribute("src", a); g[e].removeAttribute("data-src_index_menu"); } } j.isDone = true; } } function _hide_(b) { if (!b) { return; } var a = $(b); if (a.hasClass("hover")) { a.removeClass("hover"); } } function shoucang() { window._gaq = window._gaq || []; _gaq.push(["_trackEvent", "headerAddFavorite", location.href]); var b = window.location.href; var a = document.title; try { window.external.addFavorite(b, a); } catch (c) { try { window.sidebar.addPanel(a, b, ""); } catch (c) { alert("对不起，您的浏览器不支持此操作！\n请您使用菜单栏或Ctrl+D收藏本站。"); } } } var car_number = 0; function DY_cart_detail_nav_cb(b) { Cart.goodsList = 1; var a = b.goods_list.length; if (a > 0) { Cart.formatData(b); Cart.goodsNum = a; if (a > 4) { $("#JS_header_cart").css({ height: "312px", "overflow-y": "scroll" }); } } else { $.cookie("cart_number", 0); $("#cartInfo_number").html(0); Cart.Dom.html('<div class="loadLay" style="color:#626262;">您的购物车中还没有商品，先去选购吧！</div>'); } } $("#cartInfo_number").html($.cookie("cart_number") || 0); var Cart = {}; Cart.handdler = $("#JS_header_cart_handler"); Cart.Dom = $("#JS_header_cart_list"); Cart.show = function () { if (!Cart.goodsList) { $.ajax({ url: "/mll_api/api/cart_info", dataType: "json", cache: false, success: DY_cart_detail_nav_cb }); Cart.Dom.html('<div class="loadLay" style="color:#626262;">数据加载中...</div>'); } Cart.handdler.addClass("hover"); }; Cart.hide = function () { Cart.handdler.removeClass("hover"); }; Cart.del = function (i) { var l = i || window.event, j = l.target || l.srcElement; var a = $(j); if (!a.hasClass("Cart_del")) { return false; } var g = j.getAttribute("data-index"), b = j.getAttribute("data-rec_id"), f = j.getAttribute("data-num"); var k = j.getAttribute("data-act_id"); var d = []; var c = {}; if (k > 0) { var h = Cart.Dom.find(".JS_cart_list_act_" + k); h.each(function (o, p) { var q = $(this); var n = q.data("rec_id"); var m = q.data("index"); var e = q.data("num"); d.push(n); c[n] = { index: m, num: e }; }); } else { d.push(b); c[b] = { index: g, num: f }; } if (!Cart.inDelAjax && d.length > 0) { Cart.inDelAjax = true; $.ajax({ url: "/add_cart/?step=dropGoods&ajax=1&goods=" + d.join("|"), type: "GET", dataType: "json", success: function (e) { if (e.error == 0) { $.each(d, function (o) { var r = d[o]; var s = c[r].index; var q = c[r].num; var u = $("#JS_total").html() - 0; var p = ($("#JS_danjia" + s).html() - 0) * parseInt(q); var v = u - p; var n = parseInt($("#JS_num").html() - 0) - parseInt(q); var t = $(".JS_cart_list_gift_" + r); var m = $("#JS_cart_gift_total").html() - 0; t.each(function (w) { var x = parseInt(t.eq(w).attr("data-num")); n -= x; m -= x; }); $("#JS_cart_list_index_" + s).remove(); t.remove(); $("#cartInfo_number").html(n); if (n == 0) { Cart.Dom.html('<div class="loadLay" style="color:#626262;">您的购物车中还没有商品，先去选购吧！</div>'); } else { $("#JS_total").html(v); $("#JS_num").html(n); if ($("li", "#JS_header_cart").length <= 4) { $("#JS_header_cart")[0].style.cssText = ""; } if (m > 0) { $("#JS_cart_gift_total").html(m); } else { $("#JS_cart_gift_count").remove(); } } Cart.goodsNum--; $.cookie("cart_number", n); }); } else { this.error(); } }, error: function () { alert("删除失败，请稍后再试！"); }, complete: function () { Cart.inDelAjax = false; } }); } }; Cart.formatData = function (e) { var g = e.goods_list; var f = 0; var b = 0; var d = []; d.push('<ul id="JS_header_cart" class="cartUL" onclick="Cart.del(event);">'); for (var a = 0, h = g.length; a < h; a++) { var c = (g[a].goods_thumb_1) ? g[a].goods_thumb_1 : g[a].goods_thumb; d.push('<li id="JS_cart_list_index_' + a + '" class="' + (g[a].goods_activity_type != "newgift" ? "" : "JS_cart_list_gift_" + g[a].activity_par_id) + (g[a].price_activity_id > 0 ? " JS_cart_list_act_" + g[a].price_activity_id : "") + '" data-num="' + g[a].goods_number + '" data-rec_id="' + g[a].rec_id + '" data-index="' + a + '">'); d.push('<div class="tImg"><a href="' + g[a].url + '" target="_blank" title="' + g[a].goods_name + '"><img src="http://image.meilele.com/' + c + '" width="86" height="57" alt="' + g[a].goods_name + '" /></a></div>'); d.push('<div class="gInfo">'); d.push('<p class="gn"><a href="' + g[a].url + '" target="_blank" title="' + g[a].goods_name + '">' + g[a].goods_name + "</a></p>"); if (g[a].goods_activity_type != "newgift") { d.push('<p class="gt"><strong class="Left"><span class="cl yen">&yen;<span id="JS_danjia' + a + '">' + g[a].goods_price + "</span></span>&times;" + g[a].goods_number + '</strong><a class="Right Cart_del" href="javascript:;" data-index="' + a + '" data-rec_id="' + g[a].rec_id + '" data-num="' + g[a].goods_number + '" data-act_id="' + (g[a].price_activity_id || 0) + '">删除</a></p>'); } else { d.push('<p class="gt"><strong class="Left"><span class="cl">赠品</span>&times;' + g[a].goods_number + "</strong></p>"); b += parseInt(g[a].goods_number); } d.push("</div>"); d.push("</li>"); f += parseInt(g[a].goods_number); } d.push("</ul>"); d.push('<div class="cartDiv clearfix"><p class="totaoFee">共<strong class="red f14" id="JS_num">' + f + '</strong>件商品，共计<strong class="yen red num" >&yen;<span id="JS_total">' + e.total + "</span></strong></p>" + (b > 0 ? '<p id="JS_cart_gift_count" class="gray r">其中包含<strong id="JS_cart_gift_total" class="red f14">' + b + "</strong>件赠品</p>" : "") + '<div class="clearfix"><a class="toPay" href="javascript:;" onclick="Cart.goPreCheckOut();return false;">立刻购买</a><a href="/flow/?step=cart&rel=header" style="color:#333;margin-top:15px;padding-right:10px;" class="Right">查看购物车&gt;&gt;</a></div></div>'); $("#cartInfo_number").html(f); Cart.Dom.html(d.join("")); $.cookie("cart_number", f); }; Cart.goPreCheckOut = function () { $.showLoginBox(function () { location.href = "/flow/?step=pre_checkout&rel=header"; }); }; function exprCallBackNum(json) { if (json && json.html_content) { try { eval("json.html_content=" + json.html_content); } catch (e) { return; } if (!json) { return; } var o1 = $("#JS_n_head_menu_expr"); var o2 = $("#JS_temai_n_menu"); var o3 = $("#JS_Header_Home_Link"); var o4 = $("#JS_Header_Logo_link_home"); if (json.html_content && json.html_content.expr_count > 0) { o1.attr("href", "/" + json.html_content.pinyin + "/expr.html"); o3.attr("href", "/" + json.html_content.pinyin + "/"); o4.attr("href", "/" + json.html_content.pinyin + "/"); if (o2.length && json.html_content.out_goods) { o2.html('&nbsp;|&nbsp;<a class="red" href="/' + json.html_content.pinyin + "/temai_all_" + json.html_content.region_id + '.html" target="_blank" title="体验馆特卖">体验馆特卖</a>'); o2.removeClass("none"); } } } } $("#JS_header_cart_handler").hover(Cart.show, Cart.hide);
    /*TDG:2014-03-18 21:01:27*/</script>
<script>    var City = {}; City.init = function () {
        if (City.ready && City.currentCity == $("#DY_site_name").html().replace("站", "")) { return; } City.currentCity = $("#DY_site_name").html().replace("站", "");
        City.handdler = $("JS_header_city_char"); City.chars = $("#JS_header_city_char a"); City.stage = $("#JS_header_city_list"); City.lists = $("#JS_header_city_list tr");
        City.setDefaultDom = $("#JS_set_default_city_header"); City.deleteDefaultCityDom = $("#JS_default_city_delete"); City.nearDom = $("#JS_my_near_expr"); City.currentBox = $("#JS_current_city_box");
        var c = City.stage.find("a"); City.cityData = {}; for (var a = 0, d = c.length; a < d; a++) {
            var f = c[a]; var g = f.getAttribute("data-region_id"); var b = f.getAttribute("data-pinyin");
            var e = f.innerHTML; City.cityData[e] = City.cityData[b] = City.cityData[g] = { regionId: g, pinyin: b, regionName: e };
        } c = null; City.defaultCity = {}; if ($.cookie("default_rgn_id")) {
            City.defaultCity = City.cityData[$.cookie("default_rgn_id")] || {};
        } $("#JS_city_current_city").html(City.currentCity); City.currentCityData = City.cityData[City.currentCity]; City.refreshDefaultCityDom(); City.inputDom = $("#JS_search_city_input_header");
        City.tip = $("#JS_search_city_tip_header"); City.inputDom.keyup(function (h) { City.tip.hide(); if (h.keyCode == 13) { City.goSearch(); } }); City.inputDom.focus(function () {
            if (this.value == "输入城市名") {
                this.value = "";
            } City.tip.hide();
        }); $("#JS_search_city_submit_header").click(City.goSearch); City.bar = $("#JS_header_city_bar"); City.barBox = $("#JS_header_city_bar_box");
        City.size = City.chars.length; City.allHeight = City.stage.height(); City.rate = (City.allHeight - 170) / (180 - 36); City.to = 0; City.to2 = 0; City.nowH = 0; City.mouseDown = false;
        City.selectByChar(); City.scrollBar(); City.scrollByWheel(); City.ready = true;
    }; City.refreshDefaultCityDom = function () {
        if (City.currentCity != "全国" && City.currentCityData && City.currentCityData.regionId != City.defaultCity.regionId) {
            City.setDefaultDom.show();
            City.setDefaultDom.attr("href", "javascript:City.setDefaultCity('" + City.currentCityData.regionId + "')");
        } else {
            City.setDefaultDom.hide(); City.nearDom.hide();
        } if (City.currentCity != "全国" && City.currentCityData) {
            City.nearDom.attr("href", "/" + City.currentCityData.pinyin + "/area.html"); City.nearDom.show(); City.currentBox.show();
        } else { City.nearDom.hide(); City.currentBox.hide(); } if (City.defaultCity && City.defaultCity.regionId) {
            City.deleteDefaultCityDom.html('您默认的城市是：<a href="javascript:;" onclick="M.goExpr(City.defaultCity.pinyin,City.defaultCity.regionId,\'{$goExprUrlType}\',City.defaultCity.regionName);return false;" class="red">' + City.defaultCity.regionName + '</a> <a href="javascript:City.delDefaultCity();" class="red">[删除]</a>');
            City.deleteDefaultCityDom.show();
        } else { City.deleteDefaultCityDom.hide(); } 
    }; City.setDefaultCity = function (a) {
        if (a && City.cityData[a]) {
            City.defaultCity = City.cityData[a];
            $.cookie("default_rgn_id", City.cityData[a].regionId, { expires: 365 }); City.refreshDefaultCityDom();
        } 
    }; City.delDefaultCity = function () {
        City.defaultCity = {}; $.cookie("default_rgn_id", "", { expires: -1 });
        City.refreshDefaultCityDom();
    }; City.goSearch = function () {
        var b = (City.inputDom.val() + "").replace(/[\s\d]/g, ""); var a = City.cityData[b]; if (a) {
            City.tip.hide();
            $.goExpr(a.pinyin, a.regionId, "{$goExprUrlType}", a.regionName);
        } else { City.tip.show(); } 
    }; City.selectByChar = function () {
        var b = 0; for (var a = 0; a < City.size; a++) {
            City.chars[a]._h = b;
            City.chars[a].onmouseover = function () { City.move(this._h); City.to2 = City.to; }; b += City.lists.eq(a).height();
        } 
    }; City.move = function (b, a) {
        if (b < 0) { b = 0; } b = b >= (City.allHeight - 170) ? (City.allHeight - 170) : b;
        var c = parseInt(b / City.rate); if (a) { City.stage.css("margin-top", (0 - b) + "px"); City.bar.css("margin-top", c + "px"); } else {
            City.stage.stop(true, false).animate({ marginTop: (0 - b) + "px" });
            City.bar.stop(true, false).animate({ marginTop: c + "px" });
        } City.to = c; City.nowH = b;
    }; City.scrollBar = function () {
        City.bar.on("mousedown", function (a) {
            a = a || window.event;
            City.mouseDown = true; City.nowHeight = a.pageY || a.clientY; a.returnValue = false; return false;
        }); City.bar.on("dragstart", function (a) {
            a = a || window.event; a.returnValue = false;
        }); $("body").on("mouseup", function (a) { a = a || window.event; City.mouseDown = false; City.to2 = City.to; a.returnValue = false; return false; }); City.barBox.on("mousemove", function (a) {
            if (!City.mouseDown) {
                return;
            } a = a || window.event; var b = a.pageY || a.clientY; City.move((b - City.nowHeight + City.to2) * City.rate, true); a.returnValue = false; return false;
        });
    }; City.scrollByWheel = function (a) {
        City.addScrollListener(City.barBox[0], function (c) {
            c = c || window.event;
            var b; if (c.wheelDelta) { b = (0 - c.wheelDelta) / Math.abs(c.wheelDelta); } else { b = c.detail / Math.abs(c.detail); } City.move(City.nowH + b * 50); City.to2 = City.to; if (navigator.userAgent.toLowerCase().indexOf("msie") >= 0) {
                event.returnValue = false;
            } else { c.preventDefault(); } 
        });
    }; City.addScrollListener = function (e, d) {
        if (typeof e != "object") { return; } if (typeof d != "function") { return; } if (typeof arguments.callee.browser == "undefined") {
            var c = navigator.userAgent;
            var a = {}; a.opera = c.indexOf("Opera") > -1 && typeof window.opera == "object"; a.khtml = (c.indexOf("KHTML") > -1 || c.indexOf("AppleWebKit") > -1 || c.indexOf("Konqueror") > -1) && !a.opera;
            a.ie = c.indexOf("MSIE") > -1 && !a.opera; a.gecko = c.indexOf("Gecko") > -1 && !a.khtml; arguments.callee.browser = a;
        } if (e == window) { e = document; } if (arguments.callee.browser.ie) {
            e.attachEvent("onmousewheel", d);
        } else { e.addEventListener(arguments.callee.browser.gecko ? "DOMMouseScroll" : "mousewheel", d, false); } 
    }; City.exed = true;
    /*TDG:2014-04-16 17:12:36*/</script>


    .
<script type="text/javascript">
    (function ($) {
        if ($("#JS_ship_link a").length > 26) {
            $("#JS_more_link").hide();
            var openArrow = $("#JS_open_more");
            openArrow.css('display', 'inline-block').click(function () {
                $("#JS_ship_link a").each(function () {
                    $(this).show();
                });
                $(this).hide();
            });
        }
    })(jQuery);
    //期刊订阅
    function subscribe() {
        var em = $("#JS_subscribe").val();
        var reg = em.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/);
        if (reg == -1) {
            $.alert("您输入的邮箱地址不合法！");
            return;
        }
        $.ajax({
            url: "/subscribe.html?act=update_subscribe",
            data: "mail=" + em,
            dataType: "json",
            success: function (json) {
                var h = [];
                h.push('<div style="padding:10px;background:#eee;border-radius:4px;" class="clearfix">');
                h.push('<img src="' + $.__IMG + '/images/v1/logo.gif" style="border:1px solid #aaa;margin-right:10px;float:left;" />')
                h.push('<span class="bold">' + json.message + '</span>');
                h.push('<br />注册MDD易购会员即可获赠20元代金券一份！<a class="red" href="/user/?act=register">立即注册&raquo;</a>');
                h.push('</div>');
                $.lightBox(h.join(""), { "确定": "close" });
            },
            error: function () {
                $.alert("订阅失败，请稍候再试。");
            }
        });
    }

    function SyncLoginStatus(type) {
        if (!$.cookie('_sendCookie_') || type) {
            var keys = ['ECS[email]', 'ECS[username]', 'user_id', 'autoLogin', 'meilele_login', 'ECS[login_type]', 'ECS_ID'],
			parma = [],
			img = new Image();

            for (var i = 0, ii = keys.length; i < ii; i++) {
                var name = $.cookie(keys[i]) || null,
			item = keys[i] + "|" + name + "|.meilele.com";
                parma.push(item);
            }

            //TODO:上线修改zx.meilele.com
            img.src = "http://zx.meilele.com/rsync_data/?value=" + parma.join(',');
            $.cookie('_sendCookie_', 1, 'session');
        }
    }

    if (window.userName || ($.cookie('meilele_login') == "1" && $.cookie('ECS[username]'))) {
        SyncLoginStatus();
    }

    var region_id = $.cookie('region_id');
    if (region_id == 234 || region_id == 272 || region_id == 36 || region_id == 125) {
        $.wholehouse();
    }
</script>
<style>
.back_to_top .in_box.back_to_top_bonus{background:url(http://image.meilele.com/images/201402/1391714531274567485.gif) -44px 0;}
.back_to_top_hover .in_box.back_to_top_bonus{background-position:0 0;}
</style>
<script type="text/javascript">
    window._backToTopConfig = window._backToTopConfig || [];
    window._backToTopConfig.push(
	{
	    show: function () { return true },
	    html: '<div class="JS_back_to_top_hover back_to_top_hover_zoom"><div class="back_to_top_tip">20抵200</div><div class="in_box back_to_top_bonus"></div></div>',
	    click: [function () {
	        window.open('http://www.meilele.com/topic/201403-hongbao.html#thg=%E5%B9%BF%E5%91%8A%E6%95%B0%E6%8D%AE%E7%BB%9F%E8%AE%A1%E5%88%86%E7%B1%BB&adg=%E5%B9%BF%E5%91%8A%E6%95%B0%E6%8D%AE%E7%BB%9F%E8%AE%A1%E9%BB%98%E8%AE%A4%E7%BB%84&adn=%E6%B5%AE%E6%BC%8220%E6%8A%B5200&ado=1');
	    } ],
	    order: 25
	}
);
</script>
<script type="text/javascript">
    window.__QUIZ = false;
    _LOAD_SCRIPT_($.__IMG + '/themes/paipai/js/back_to_top.min.js?0120');
</script> 
 
 
<script>
    var __vir = 0;
    if (__vir) {
        $.cookie("region_virtual", 1, { expires: 5, domain: 'meilele.com' });
    } else {
        $.cookie("region_virtual", '', { expires: -1, domain: 'meilele.com' });
    }

    $('#JS_index_menu_box>div.list').hover(function () {
        var idx = $(this).index() + 1;
        _show_(this, { 'source': 'JS_side_cat_textarea_' + idx, 'target': 'JS_side_cat_list_' + idx });
    },
function () {
    _hide_(this);
});
    window._QUIZ = 'http://www.meilele.com/diaocha63.html';
</script>

<script type="text/javascript">    function limitCount() {
        var a = limitCount.doms = limitCount.doms || $("#JS_limit_table div.JS_leaveTime"); a.each(function () {
            var c = $(this); var b = c[0]._timeline = c[0]._timeline || c.data("timeline");
            c.html(limitFormatTime(b - limitCount.unixTime));
        }); limitCount.unixTime++;
    } function limitFormatTime(e) {
        if (e < 0) { e = 0; } var f = Math.floor(e / 3600 / 24), c = Math.floor((e / 3600) % 24), a = Math.floor((e % 3600) / 60), b = Math.floor((e % 3600) % 60);
        if (c < 10) { c = "0" + c; } if (a < 10) { a = "0" + a; } if (b < 10) { b = "0" + b; } return "剩余" + (f > 0 ? '<span class="digital">' + f + "</span>天" : "") + '<span class="digital">' + c + '</span>时<span class="digital">' + a + '</span>分<span class="digital">' + b + "</span>秒";
    } function _COMMON_UNIX_TIME(a) { if (a && a.html_content) { limitCount.unixTime = a.html_content; setInterval(limitCount, 1000); } } function getNewDealRecord() {
        $.ajax({ url: "/mem_ajax/?act=get_newly_sales", dataType: "json", type: "get", success: function (b) {
            $("#INDEX_LeiHao_XXXXX").html('<div class="loading"><img src="http://image.meilele.com/images/sub_expr20120717/loading.gif" width="16" height="16" /> 正在获取数据，请稍后...</div>');
            var a = []; a.push('<div id="JS_scroll_out_box" class="scrollBox">'); for (k in b) {
                var c = formatTime(b[k].order_time); a.push('<div class="item">'); a.push('<div class="img"><a href="' + b[k].goods_url + '" target="_blank" title="' + b[k].goods_name + '"><img src="' + $.__IMG + "/" + b[k].img + '" width="117" height="79" alt="' + b[k].goods_name + '" /></a></div>');
                a.push('<div class="txt">' + (b[k].zx_user_url ? '<a href="' + b[k].zx_user_url + '" target="_blank">' + b[k].consignee + "</a>" : b[k].consignee) + '<br /><span class="time">' + c + '</span>购买了<br /><a href="' + b[k].goods_url + '" target="_blank" title="' + b[k].goods_name + '">' + b[k].goods_name + "</a></div>");
                a.push("</div>");
            } a.push("</div>"); $("#INDEX_LeiHao_XXXXX").html(a.join("")); dealRecordAnimate();
        } 
        });
    } function formatTime(i) {
        if (!i) { return "刚刚"; } var b = parseInt((new Date()).getTime() / 1000);
        var f = b - i; if (f < 0) { f = 0; } var e = f % 60; var a = parseInt(f % 3600 / 60); var c = parseInt(f % (3600 * 24) / 3600); var g = parseInt(f / (3600 * 24)); if (g) { return g + "天前"; } else {
            if (c) {
                return c + "小时前";
            } else { if (a) { return a + "分钟前"; } else { if (e) { return e + "秒前"; } else { return "刚刚"; } } } 
        } 
    } function dealRecordAnimate() {
        window._JS_ZZ_LOCK_ = false; var e = $("#JS_scroll_out_box");
        var b = $("#JS_scroll_out_box .item"); var a = window.LOAD ? parseInt(b.length / 2) : b.length; var c; if (a > 3) {
            e.css("margin-top", a * (-91) + "px"); c = -a; e.hover(function () {
                window._JS_ZZ_LOCK_ = true;
            }, function () { window._JS_ZZ_LOCK_ = false; }); var d = e.html(); d += d; e.html(d); setInterval(f, 4000);
        } function f() {
            if (window._JS_ZZ_LOCK_) { return; } c++; e.animate({ "margin-top": c * 91 + "px" }, 200, "linear", function () {
                if (c > -1) {
                    e.css("margin-top", a * (-91) + "px");
                    c = -a;
                } 
            });
        } 
    } $(function () {
        $.lazyImg.start("both", { attributeTag: "data-src2" }); window._currentWidth = document.body.clientWidth; window.onresize = function () {
            window._currentWidth = document.body.clientWidth;
            c = 0; g();
        }; var f = $("#JS_side_stage"), a = $("#JS_side_stage a"), i = $("#JS_side_nav a"), b = $("#JS_side_stage a"), d = i.length, e = 0, c = 0; i.on("mouseover", function () {
            c = $(this).index();
            if (h) { clearInterval(h); } g();
        }).on("mouseout", function () { h = setInterval(function () { g(); }, 6000); }); var g = function () {
            $(i.get(e)).removeClass("current"); $(i.get(c)).addClass("current");
            f.stop(true, false).animate({ "margin-left": (0 - c) * window._currentWidth + "px" }, 200); e = c; var l = $(b.get(e)); var j = l.attr("data-bg"); if (j) {
                l.css({ background: "url(" + j + ") center center no-repeat" }).removeAttr("data-bg");
            } c = (c >= d - 1) ? 0 : c + 1;
        }; var h = setInterval(function () { g(); }, 6000);
    }); function slideLazy(a) {
        if (a.index > 0) {
            var b = a["_img_" + a.index] || a.stage.find("img").get(a.index);
            if (b && !b._lazYDone) { $.lazyImg.prepend([{ target: b, src: b.getAttribute("lazy-src2")}]); a["_img_" + a.index] = b; b._lazYDone = true; } 
        } 
    } $(function () {
        $.tab($("#JS_expr_num_box td.enav"), $("#JS_expr_num_box td.ebody"), { lazy: false });
        $.tab($("#JS_side_tab_nav a"), $("#JS_side_tab_body .tBody"), { lazy: false }); $("#JS_group_buy_body").on("mouseover", function () {
            this.className = "body current";
        }).on("mouseout", function () { this.className = "body"; }); $.slide({ prevBtn: $("#JS_group_nav_prev"), nextBtn: $("#JS_group_nav_next") }, $("#JS_groupBuy_stage"), { step: 210 });
        $.slide({ prevBtn: $("#JS_limit_left"), nextBtn: $("#JS_limit_right") }, $("#JS_limit_table"), { step: window.LOAD ? 960 : 750, onSlide: function (b) {
            if (b.index > 0 && !b._lazYDone) {
                var e = b.stage.find("div.img img");
                var d = []; for (var c = 3; c < 6; c++) { if (e[c]) { d.push({ target: e[c], src: e[c].getAttribute("lazy-src2") }); } } if (d.length) { $.lazyImg.prepend(d); } b._lazYDone = true;
            } 
        } 
        });
        $("#JS_limit_table").on("mouseenter", "td", function () { this.className = "current"; }); $("#JS_limit_table").on("mouseleave ", "td", function () {
            this.className = "";
        }); $("#JS_check_order").on("click", function () { $.orderQuery($("#JS_ordersn"), $("#JS_phone")); }); for (var a = 1; a <= 4; a++) {
            $.slide($("#JS_floor_focus_nav_" + a + " a"), $("#JS_floor_focus_stage_" + a), { step: 721, eventType: "mouseenter", autoRun: 5000, onSlide: slideLazy });
        } 
    }); $(window).on("load", function () {
        $.slide($("#JS_zx_slide_nav a"), $("#JS_zx_slide_body"), { step: 510, eventType: "mouseenter", autoRun: 3000, onSlide: slideLazy });
        $.slide($("#JS_focus_xspace_nav a"), $("#JS_focus_xspace_body"), { step: 567, eventType: "mouseenter", autoRun: 3500, onSlide: function (b) {
            var a = b.index; if (a > 0 && !b["_lazyDone_" + a]) {
                var e = b.stage.find("div.img img");
                var d = []; for (var c = a * 3; c < (a + 1) * 3; c++) { if (e[c]) { d.push({ target: e[c], src: e[c].getAttribute("lazy-src2") }); } } if (d.length) { $.lazyImg.prepend(d); } b["_lazyDone_" + a] = true;
            } 
        } 
        }); $.tab($("#JS_tab_article_nav a"), $("#JS_tab_article_body div.tabBody")); getNewDealRecord(); $("#JS_hotBrand_table").on("mouseenter", "td", function () {
            $(this).addClass("current");
        }); $("#JS_hotBrand_table").on("mouseleave ", "td", function () { $(this).removeClass("current"); });
    });
    /*LDZ:2013-08-16 15:52:28*/</script>

<div id="static_dynamic" page_sn="city_index" rgn_id="254" debug=""></div>
<script type="text/javascript">    window.static_dynamic && static_dynamic();</script>

<script>
    var google_tag_params = {
        pagetype: 'home'
    }
</script>
<script src="./js/ana.min.js?0509"></script>
<script>    window._ana && _ana.push(['trackView']);</script>
<script>    window._gaq = window._gaq || []; (function (a) { a._gaq = a._gaq || []; a.MLLgaq = a.MLLgaq || []; for (var b = 0; b < MLLgaq.length; b++) { _gaq.push(MLLgaq[b]); } _gaq.push(["_setAccount", "UA-10173353-1"]); _gaq.push(["_trackPageview"]); var d = document.createElement("script"); d.type = "text/javascript"; d.async = true; d.src = ("https:" == document.location.protocol ? "https://" : "http://") + "stats.g.doubleclick.net/dc.js"; var c = document.getElementsByTagName("script")[0]; c.parentNode.insertBefore(d, c); })(window); function parseGaData() { _gaq.push([arguments[0], arguments[1], arguments[2], arguments[3]]); } _LOAD_SCRIPT_("http://hm.baidu.com/h.js?d91942b1e6dd95baed4560c0c6d8071b"); window.bd_cpro_rtid = "rHnLnHT"; _LOAD_SCRIPT_("http://cpro.baidu.com/cpro/ui/rt.js"); _LOAD_SCRIPT_("http://tajs.qq.com/stats?sId=11450600"); _LOAD_SCRIPT_("http://tajs.qq.com/gdt.php?sId=23384945"); _LOAD_SCRIPT_("http://tajs.qq.com/gdt.php?sId=21253825"); _LOAD_SCRIPT_("http://tajs.qq.com/gdt.php?sId=26418742");
    /*LDZ:2014-03-24 16:54:17*/</script>
<script>
    (function () { //记录推广
        var s = location.search;
        if (s) {
            s = s.replace("?", "").split("&");
            for (var k = 0; k < s.length; k++) {
                if (s[k].indexOf("from=MT") === 0) {
                    var img = new Image;
                    img.src = "/solr_api/mss/message/statistic.do?fromUrl=" + encodeURIComponent(location.href);
                    return;
                }
            }
        }
    })();
</script>

</form>
</body>
</html>
<!--
GH:2014-03-13 10:49:55
-->
