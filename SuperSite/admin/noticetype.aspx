<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="noticetype.aspx.cs" Inherits="SuperSite.admin.noticetype" %>
<%@ Register Src="~/admin/control/Paging.ascx" TagPrefix="cc" TagName="paging" %>

<!DOCTYPE html>

<html>
<head>
    <title>友情链接</title>
    <meta http-equiv="X-Frame-Options" content="SAMEORIGIN">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
    <link href="statics/base/css/common.css" rel="stylesheet" />

    <!--[if lte IE 9]>
    <SCRIPT language=JavaScript>
    function killErrors() {
    return true;
    }
    window.onerror = killErrors;
    </SCRIPT>
    <![endif]-->
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文 > 快捷导航 > <a href="noticetype.aspx">通知类型</a></div>
    </div>
    <div class="clear"></div>

    <div class="v52fmbx_tbmax v52fmbx_tbmaxmt">
        <div class="v52fmbx_tbbox">
            <h3 class="v52fmbx_hr">
                <span class="formleft">
                    <a href="noticetype_add.aspx">+新增</a>
                    <a href="javascript:;" id="delnoticetype" class="ml10">-删除</a>
                </span>
            </h3>

            <table cellpadding="2" cellspacing="1" class="table mt25">
                <tr>
                    <td width="40" class="list" style="padding: 0px; text-align: center;">
                        <input name="chkAll" type="checkbox" id="chkAll" style="vertical-align: middle;" />
                    </td>
                    <td width="60" class="list" style="padding: 0px; text-align: center;">ID</td>
                    <td width="100" class="list" style="padding: 0px; text-align: center;">通知类别</td>
                    <td class="list">类型名称</td>
                    <td class="list">描述</td>
                    <td class="list" width="100" style="padding: 0px; text-align: center;">提前通知（天）</td>
                    <td width="50" class="list" style="padding: 0px; text-align: center;">备用</td>
                    <td width="50" class="list" style="padding: 0px; text-align: center;">状态</td>
                    <td width="10%" class="list" style="padding: 0px; text-align: center;">操作</td>
                </tr>                
            </table>
            <cc:paging runat="server" ID="paging" />                        
        </div>
    </div>
    <script id="template" type="x-tmpl-mustache">
        {{#data}}
        <tr class="mouse click">
            <td class="list-text"><input type='checkbox' value='{{id}}' /></td>
            <td class="list-text">{{id}}</td>
            <td class="list-text"><span>{{categoryName}}</span></td>
            <td class="list-text alignleft">&nbsp;&nbsp;{{name}}</td>
            <td class="list-text alignleft">&nbsp;&nbsp;{{description}}</td>
            <td class="list-text"><span>{{advanceDay}}</span></td>
            <td class="list-text">{{reserved1}}</td>
            <td class="list-text">
                {{#open}}<img src="statics/base/images/ok_1.gif" />{{/open}}
                {{^open}}<img src="statics/base/images/ok_0.gif" />{{/open}}
            </td>
            <td class="list-text">
                <a href="javascript:;" class="ccbtnedit" ccvalue="{{id}}">编辑</a>
                <a href="javascript:;" class="ccbtnsuccess" ccvalue="{{id}}">停用</a>
                <a href="javascript:;" class="ccbtnerror" ccvalue="{{id}}">删除</a>
            </td>
        </tr>
        {{/data}}
    </script>

    <script type="text/javascript" src="statics/base/js/jquery1.7.2.js"></script>    
    <script type="text/javascript" src="statics/base/js/app.js"></script>
    <script type="text/javascript">noticeModel.init();</script>
</body>
</html>
