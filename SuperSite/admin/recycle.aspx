<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recycle.aspx.cs" Inherits="SuperSite.admin.recycle" %>

<!DOCTYPE html>

<html>
<head>
    <title>内容回收站</title>
    <meta http-equiv="X-Frame-Options" content="SAMEORIGIN">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/common.css" />
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文 > 内容管理 > <a href="recycle.aspx">内容回收站</a></div>
    </div>
    <div class="clear"></div>

    <div class="v52fmbx_tbmax v52fmbx_tbmaxmt">
        <div class="v52fmbx_tbbox">
            <h3 class="v52fmbx_hr">
                <span class="formleft">
                    <a href="javascript:;" id="recycle">+还原</a>
                    <a href="javascript:;" id="delete" class="ml10">-删除</a>
                </span>
            </h3>

            <table cellpadding="2" cellspacing="1" class="table mt25">
                <tr>
                    <td width="40" class="list" style="padding: 0px; text-align: center;">
                        <input name="chkAll" type="checkbox" id="chkAll" style="vertical-align: middle;" />
                    </td>
                    <td class="list">标题</td>
                    <td width="100" class="list">所属栏目</td>
                    <td width="10%" class="list" style="padding: 0px; text-align: center;">操作</td>
                </tr>
                <tr><td colspan="15" class="list td_nodata" style="background-color:#fff;">没有数据</td></tr>
            </table>                                
        </div>
    </div>
    <script id="template" type="x-tmpl-mustache">
        {{#data}}
        <tr class="mouse click">
            <td class="list-text"><input type='checkbox' value='{{id}}' /></td>
            <td class="list-text alignleft">&nbsp;&nbsp;{{title}}</td>
            <td class="list-text">&nbsp;&nbsp;{{category}}</td>
            <td class="list-text">
                <a href="javascript:;" class="ccbtnedit" ccvalue="{{id}}">还原</a>
                <a href="javascript:;" class="ccbtnerror" ccvalue="{{id}}">删除</a>
            </td>
        </tr>
        {{/data}}
    </script>

    <script type="text/javascript" src="statics/base/js/jquery1.7.2.js"></script>    
    <script type="text/javascript">
        $(function () {

        });
    </script>
</body>
</html>