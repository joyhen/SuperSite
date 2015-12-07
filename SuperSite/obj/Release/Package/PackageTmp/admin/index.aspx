﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SuperSite.admin.index" %>
<%@ Register Src="~/admin/control/maintop.ascx" TagPrefix="cc" TagName="top" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>supersite企业网站管理系统</title>
    <link href="statics/base/css/metinfo_box.css" rel="stylesheet" />
    <style>
        #content, #top .topnbox {
            width: 1000px;
        }

        #top .floatr li a span {
            behavior: url(statics/images/iepngfix.htc);
        }

        #top .floatr .top-right-boxr {
            top: 35px;
        }

        body {
            overflow: hidden;
        }
        .footer {
            line-height:35px;
        }
    </style>
</head>
<body id="indexid">
    <div id="metcmsbox">
        <div id="top">
            <cc:top runat="server" id="maintop" />
        </div>
        <div id="content">
            <div class="floatl" id="metleft">
                <div class="floatl_box">
                    <div class="nav_list" id="leftnav">
                        <div class="fast">
                            <a href="#" id="qthome" title="网站首页">网站首页</a>
                        </div>
                        <ul id="ul_1">
                            <li><a href="main.html" id="nav_1_2" target="main" class="on" title="系统信息" hidefocus="true">系统信息</a></li>
                            <li><a href="site.html" id="nav_1_49" target="main" title="基本设置" hidefocus="true">基本设置</a></li>
                            <li><a href="category.html" id="nav_1_77" target="main" title="栏目管理" hidefocus="true">栏目管理</a></li>
                            <li><a href="theme.html" id="nav_1_78" target="main" title="界面风格" hidefocus="true">界面风格</a></li>
                        </ul>
                        <ul style="display:none;" id="ul_10">
                            <li><a href="content.html" id="nav_10_58" target="main" title="内容管理" hidefocus="true">内容管理</a></li>
                            <li><a href="recycle.html" id="nav_10_59" target="main" title="内容回收站" hidefocus="true">内容回收站</a></li>
                        </ul>
                        <ul style="display:none;" id="ul_37">

                            <li><a href="expand_link.html" id="nav_37_13" target="main" title="友情链接" hidefocus="true">友情链接</a></li>
                            <li><a href="expand_ad.html" id="nav_37_63" target="main" title="站内广告" hidefocus="true">站内广告</a></li>

                        </ul>
                        <ul style="display:none;" id="ul_12">
                            <li><a href="app.html" id="nav_12_54" target="main" title="我的应用" hidefocus="true">我的应用</a></li>
                            <li><a href="app_lists.html" id="nav_12_79" target="main" title="应用市场" hidefocus="true">应用市场</a></li>
                        </ul>
                        <ul style="display:none;" id="ul_20">
                            <li><a href="category.html" id="nav_20_9" target="main" title="栏目管理" hidefocus="true">栏目管理</a></li>
                            <li><a href="theme.html" id="nav_20_21" target="main" title="界面风格" hidefocus="true">界面风格</a></li>
                            <li><a href="jpeg.html" id="nav_20_48" target="main" title="水印缩图" hidefocus="true">水印缩图</a></li>
                            <li><a href="safe.html" id="nav_20_47" target="main" title="网站安全" hidefocus="true">网站安全</a></li>
                            <li><a href="admin.html" id="nav_20_5" target="main" title="管理员管理" hidefocus="true">管理员管理</a></li>
                            <li><a href="expand_backup.html" id="nav_20_35" target="main" title="数据备份" hidefocus="true">数据备份</a></li>
                        </ul>
                    </div>
                    <div class="claer"></div>
                    <div class="left_footer"><div class="left_footer_box"><a href="http://www.id124.com" target="_blank">我要提建议</a></div></div>
                </div>
            </div>
            <div class="floatr" id="metright">
                <div class="iframe" style="overflow:hidden;">
                    <div class="min"><iframe id="main" name="main" src="main.html" frameborder="0" scrolling="yes" width="100%" height="100%"></iframe></div>
                </div>
            </div>
            <div class="clear"></div>
        </div>
    </div>
    <div class="footer">Powered by <b><a href="http://www.id124.com" target="_blank">艾德创意工作室</a></b> &copy;2015-2016 &nbsp;<a href="http://www.id124.com" target="_blank">id124.com</a></div>
    
    <script type="text/javascript" src="statics/base/js/jQuery1.7.2.js"></script>
    <script type="text/javascript" src="statics/base/js/cookie.js"></script>
    <script type="text/javascript" src="statics/base/js/common.js"></script>
    <script type="text/javascript" src="statics/base/js/metinfo.js"></script>
    <script type="text/javascript">
        var _glang = '<%=CurrentLanguage.ToString()%>';

        function showLarg(my) {
            $('#content,#top .topnbox').animate({ width: '99%' }, 80);
            my.attr('title', '切换到窄版');
            my.text('窄版');
            setTimeout("topwidth(100)", 100);
        };
        function showSmall(my) {
            $('#content,#top .topnbox').animate({ width: '1000px' }, 80);
            my.attr('title', '切换到宽版');
            my.text('宽版');
            setTimeout("topwidth(100)", 100);
        };

        $(function () {
            $('#content,#top .topnbox').animate({ width: '99%' }, 80);
            setTimeout("topwidth(100)", 100);
            $("#kzqie").click(function () {
                var my = $(this);
                if (my.text() == '宽版') {
                    showLarg(my);
                } else {
                    showSmall(my);
                }
            });

            $("#cache").click(function () {
                confirmLayerNormal('确定清除吗？', function (index) {
                    //...
                    layer.close(index);
                    layer.msg('缓存数据已清除');
                });
            });
        })
    </script>
</body>
</html>