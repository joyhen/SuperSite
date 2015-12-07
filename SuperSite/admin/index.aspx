<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SuperSite.admin.index" %>
<%@ Register Src="~/admin/control/maintop.ascx" TagPrefix="cc" TagName="top" %>
<%@ Register Src="~/admin/control/langlabel.ascx" TagPrefix="cc" TagName="label" %>

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
                            <a href="http://www.id124.com" target="_blank" title="网站首页"><cc:label runat="server" ID="idxhomepage" /></a>
                        </div>
                        <ul id="ul_1">
                            <li><a href="main.html" id="nav_1_2" target="main" class="on" hidefocus="true"><cc:label runat="server" ID="idxsysinfo" /></a></li>
                            <li><a href="noticetype.aspx" id="nav_1_49" target="main" hidefocus="true"><cc:label runat="server" ID="idxnoticetype" /></a></li>
                            <li><a href="noticemsg.aspx" id="nav_1_77" target="main" hidefocus="true"><cc:label runat="server" ID="idxcolumn" /></a></li>
                        </ul>
                        <ul style="display:none;" id="ul_10">
                            <li><a href="javascript:;" id="nav_10_58" target="main" hidefocus="true">内容管理</a></li>
                            <li><a href="javascript:;" id="nav_10_59" target="main" hidefocus="true">内容回收站</a></li>
                        </ul>
                        <ul style="display:none;" id="ul_37">

                            <li><a href="javascript:;" id="nav_37_13" target="main" hidefocus="true">定时服务</a></li>
                            <li><a href="javascript:;" id="nav_37_63" target="main" hidefocus="true">活动管理</a></li>

                        </ul>
                        <ul style="display:none;" id="ul_12">
                            <li><a href="javascript:;" id="nav_12_54" target="main" hidefocus="true">API调用</a></li>
                            <li><a href="javascript:;" id="nav_12_79" target="main" hidefocus="true">推送报表</a></li>
                        </ul>
                        <ul style="display:none;" id="ul_20">
                            <li><a href="javascript:;" id="nav_20_9" target="main" hidefocus="true">栏目管理</a></li>
                            <li><a href="javascript:;" id="nav_20_21" target="main" hidefocus="true">开发工具</a></li>
                            <li><a href="javascript:;" id="nav_20_48" target="main" hidefocus="true">系统设置</a></li>
                            <li><a href="javascript:;" id="nav_20_47" target="main" hidefocus="true">系统安全</a></li>
                            <li><a href="javascript:;" id="nav_20_5" target="main" hidefocus="true">系统用户</a></li>
                            <li><a href="javascript:;" id="nav_20_35" target="main" hidefocus="true">数据备份</a></li>
                        </ul>
                    </div>
                    <div class="claer"></div>
                    <div class="left_footer"><div class="left_footer_box"><a href="javascript:;" target="_blank">我要提建议</a></div></div>
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
    <div class="footer"><b><a href="https://www.id124.com" target="_blank">艾德创意工作室</a></b> &copy;2015-2016  id124.com</div>

    <script type="text/javascript" src="statics/base/js/jquery1.7.2.js"></script>
    <script type="text/javascript" src="statics/base/js/lang/message-lang-<%=CurrentLanguage.ToString() %>.js"></script>
    <%--<script type="text/javascript" src="statics/base/js/cookie.js"></script>--%>
    <script type="text/javascript" src="statics/base/js/common.js"></script>
    <script type="text/javascript" src="statics/base/js/metinfo.js"></script>
    <script type="text/javascript">
        var _glang = '<%=CurrentLanguage.ToString()%>';
        var globalRequestUrl = '<%=GlobalAjaxRequestUrl%>';

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