<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="theme.aspx.cs" Inherits="SuperSite.admin.theme" %>

<!DOCTYPE html>

<html>
<head>
    <title>页面风格</title>
    <meta http-equiv="X-Frame-Options" content="SAMEORIGIN">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
    <style>
        .previewimg{margin:5px; border:1px solid #ddd; padding:3px;}
        .table td.list-text{background:#fff;}
    </style>
</head>
<body>
    <div class="metinfotop">
        <div class="position">系统设置 > 界面风格</div>
    </div>
    <div class="clear"></div>

    <div class="v52fmbx_tbmax v52fmbx_tbmaxmt">
        <div class="v52fmbx_tbbox">
            <h3 class="v52fmbx_hr">
                <span style="float:right;"><a href="javascript:;" title="更多模板" target="_blank">更多模板</a></span>
            </h3>
            <table cellpadding="2" cellspacing="1" class="table skin_manager">
                <tr>
                    <td width="30" class="list">启用</td>
                    <td width="40" class="list">预览</td>
                    <td width="40" class="list list_left">信息</td>
                    <td width="60" class="list">是否应用</td>
                    <td width="60" class="list" style="padding:0px; text-align:center;">操作</td>
                </tr>

                <tr>
                    <td class="list-text"><input type='radio' name='id' value='default' checked="checked" /></td>
                    <td class="list-text alignleft">
                        <img src="template/default/view.png" width="120" height="100" class="previewimg" />
                    </td>
                    <td class="list-text alignleft" style="padding-left:10px;">
                        <span style="font-size:14px;">官方模板</span>
                        <img src="statics/base/images/greencheck.png" style="position:relative; top:5px;">
                        <b class="color390">已启用</b>
                        <p style="color:#666;">
                            模板名称：默认模板<br />
                            模板作者：SuperSite CMS<br />
                        </p>
                    </td>
                    <td class="list-text"><span>否</span></td>
                    <td class="list-text">
                        <a href="theme_edit.html" title="模板设置">模板设置</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script id="template" type="x-tmpl-mustache">
        {{#data}}
        <tr class="mouse click">
            <td class="list-text"><input type='checkbox' value='{{id}}' /></td>
            <td class="list-text">{{id}}</td>
            <td class="list-text">{{showType}}</td>
            <td class="list-text">{{mobileType}}</td>
            <td class="list-text"><span>{{categoryName}}</span></td>
            <td class="list-text alignleft" ccvalue="{{bId}}">&nbsp;&nbsp;{{bName}}</td>
            <td class="list-text alignleft">&nbsp;&nbsp;{{message}}</td>
            <td class="list-text"><span>{{pushTime}}</span></td>
            <td class="list-text">{{status}}</td>
            <td class="list-text">{{addUser}}</td>
            <td class="list-text">{{addTime}}</td>
            <td class="list-text">
                <a href="noticemsg_edit.aspx?id={{id}}" class="ccbtnedit" ccvalue="{{status}}">编辑</a>
                <a href="statistics.aspx?id={{id}}" class="ccbtnsuccess" ccvalue="{{id}}">详情</a>
            </td>
        </tr>
        {{/data}}
    </script>

</body>
</html>