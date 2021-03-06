﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysuser.aspx.cs" Inherits="SuperSite.admin.sysuser" %>

<!DOCTYPE html>

<html>
<head>
    <title>系统用户</title>
    <meta http-equiv="X-Frame-Options" content="SAMEORIGIN">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
    <link href="statics/base/css/common.css" rel="stylesheet" />
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文 > 系统设置 > <a href="noticetype.aspx">系统用户</a></div>
    </div>
    <div class="clear"></div>

    <div class="v52fmbx_tbmax v52fmbx_tbmaxmt">
        <div class="v52fmbx_tbbox">
            <h3 class="v52fmbx_hr">
                <span class="formleft">
                    <a href="sysuseradd.aspx">+新增</a>
                    <a href="javascript:;" id="delnoticetype" class="ml10">-删除</a>
                </span>
            </h3>

            <table cellpadding="2" cellspacing="1" class="table mt25">
                <tr>
                    <td width="40" class="list" style="padding: 0px; text-align: center;">
                        <input name="chkAll" type="checkbox" id="chkAll" style="vertical-align: middle;" />
                    </td>
                    <td width="60" class="list" style="padding: 0px; text-align: center;">ID</td>
                    <td width="100" class="list" style="padding: 0px; text-align: center;">用户名</td>
                    <td class="list">真实姓名</td>
                    <td width="50" class="list">性别</td>
                    <td width="50" class="list" style="padding: 0px; text-align: center;">状态</td>
                    <td width="50" class="list" style="padding: 0px; text-align: center;">添加时间</td>
                    <td width="10%" class="list" style="padding: 0px; text-align: center;">操作</td>
                </tr>
                <tr><td colspan="15" class="list td_nodata">没有数据</td></tr>
            </table>                                
        </div>
    </div>
    <script id="template" type="x-tmpl-mustache">
        {{#data}}
        <tr class="mouse click">
            <td class="list-text"><input type='checkbox' value='{{id}}' /></td>
            <td class="list-text">{{id}}</td>
            <td class="list-text"><span>{{userName}}</span></td>
            <td class="list-text alignleft">&nbsp;&nbsp;{{realName}}</td>
            <td class="list-text">
                {{#gender}}男{{/gender}}
                {{^gender}}女{{/gender}}
            </td>
            <td class="list-text">
                {{#state}}<img src="statics/base/images/ok_1.gif" />{{/state}}
                {{^state}}<img src="statics/base/images/ok_0.gif" />{{/state}}
            </td>
            <td class="list-text"><span>{{addTime}}</span></td>
            <td class="list-text">
                <a href="sysuseredit.aspx?id={{id}}" class="ccbtnedit">编辑</a>
                <a href="javascript:;" class="ccbtnerror" ccvalue="{{id}}">删除</a>
            </td>
        </tr>
        {{/data}}
    </script>

    <script type="text/javascript" src="statics/base/js/jquery1.7.2.js"></script>    
    <script type="text/javascript" src="statics/base/js/app.sysuser.js"></script>
</body>
</html>
