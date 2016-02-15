<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="SuperSite.admin.category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>站点栏目设置</title>
    <meta http-equiv="X-Frame-Options" content="SAMEORIGIN" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
    <style>
        .hidechildcategory, .preview{float:right; font-weight:normal; padding-right:10px;}
        .moreaction{position:relative; bottom:2px;}
        .nodata{ text-align:center; color:#ff6a00; background-color:#fff;}
        .relativeimg{position:relative; top:6px; padding-left:5px;}
        .actitem{float:left; margin-left:10px;}
    </style>
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文：系统设置 > 栏目管理</div>
        <div class="return"><a href="javascript:;" onclick="location.href='javascript:history.go(-1)'">&lt;&lt;返回</a></div>
    </div>
    <div class="clear"></div>

    <div class="v52fmbx_tbmax">
        <div class="v52fmbx_tbbox">
            <table cellpadding="0" cellspacing="0" class="table">
                <tr>
                    <td colspan="3" class="centle" style="font-weight:normal;">
                        <a href="javascript:;" class="preview">预览</a>
                        <a href="javascript:;" class="hidechildcategory">显示/隐藏栏目</a>
                        &nbsp;&nbsp;<a href="categoryadd.aspx">添加一级栏目</a>&nbsp;&nbsp;
                        <font style=' color:#999;'>排序越小越靠前</font>
                        <%--<span id="loadtxt"></span>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <form id="myform">
                            <table cellpadding="0" cellspacing="1" class="table neitable columntables">
                                <tr id="list-top">
                                    <td width="30" class="list">ID</td>
                                    <td width="30" class="list">排序</td>
                                    <td class="list">栏目名称</td>
                                    <td class="list" width="140">外部链接</td>
                                    <td class="list" width="60">所属模块</td>
                                    <td class="list" width="60">是否启用</td>
                                    <td class="list">操作</td>
                                </tr>
                                <tr><td colspan="7" class="list-text nodata">没有数据</td></tr>                          
                                <tr id="bottom-id">
                                    <td class="list-text" style="background-color:#fff;"></td>
                                    <td class="list-text alignleft" style="background-color:#fff;" colspan='6'>
                                        <a href="categoryadd.aspx">+添加一级栏目</a>
                                        <%--<span id="loadtxt"><img src="statics/base/images/loadings.gif" style="position:relative; top:4px;">正在加载...</span>--%>
                                    </td>
                                </tr>
                                <tr class="mouse ignore">
                                    <td class="list-text alignleft" style="padding-left:50px;" colspan='7'>
                                        <input type="button" value="保存" class="submit" />
                                    </td>
                                </tr>
                            </table>
                        </form>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script id="template" type="x-tmpl-mustache">
        {{#data}}
        <tr class="mouse{{classname}}">
            <td class="list-text">{{id}}</td>
            <td class="list-text" style="padding:8px 2px;">
                <input type="text" class="text no_order" value="{{sortnumber}}" style=" width:40px;" />
            </td>
            <td class="list-text blues" style="text-align:left; padding-left:2px;">
                {{#parentid}}<img src="statics/base/images/bg_column.gif" ccvalue="{{id}}" class="columnimg relativeimg" />{{/parentid}}
                {{^parentid}}<img src="statics/base/images/colum1nx2.gif" ccvalue="{{id}}" class="columnimg open" />{{/parentid}}
                <input type="text" class="text nonull" value="{{name}}" style=" width:155px;" />
            </td>
            <td class="list-text"><input type="text" class="text nonull" value="{{url}}" style="width:135px;" /></td>
            <td class="list-text">{{sitemodel}}</td>
            <td class="list-text color999">
                <a href="javascript:;">
                    {{#status}}<img src="statics/base/images/ok_1.gif" title="禁用" actvalue="{{id}}" ccvalue="{{status}}" />{{/status}}
                    {{^status}}<img src="statics/base/images/ok_0.gif" title="启用" actvalue="{{id}}" ccvalue="{{status}}" />{{/status}}
                </a>
            </td>
            <td class="list-text" width="100">
                <div style="position:relative;">
                    {{^parentid}}
                    <a href="categoryedit.aspx?id={{id}}" class="actitem">编辑</a>
                    <div class="columnmore">
                        <span class="text">更多&nbsp;<img src="statics/base/images/metcolumn12.gif" class="moreaction" /></span>
                        <div class="none columnmorediv">
                            <div><a href="categoryadd.aspx?pid={{id}}">添加子栏目</a></div>
                            <div><a href="javascript:;" ccvalue="{{id}}" class="del">删除</a></div>
                        </div>
                    </div>
                    {{/parentid}}

                    {{#parentid}}
                    <a href="categoryedit.aspx?id={{id}}" class="actitem">编辑</a>
                    <a href="javascript:;" ccvalue="{{id}}" class="actitem del">删除</a>
                    {{/parentid}}
                </div>
            </td>
        </tr>
        {{/data}}
    </script>
    
    <script src="statics/base/js/jquery1.7.2.js"></script>
    <script type="text/javascript">
        function getPageData() {
            var result = [];

            $('tr.mouse').map(function (idx, dom) {
                if (!($(this).hasClass('ignore'))) {
                    var _id = $(dom).find('td:first').text();
                    var _name = $(dom).find('td:eq(2) input').val();
                    var _url = $(dom).find('td:eq(3) input').val();
                    var _sort = $(dom).find('td:eq(1) input').val();

                    result.push({ id: _id, name: _name, url: _url, sort: _sort });
                }
            });

            return result;
        };

        $(function () {
            //加载数据
            parent.renderTemplate({ action: "0f717465e51169d80bfca1902f114740" },
                $('#template').html(), function (view) {
                if (view && $.trim(view) != '') {
                    $('.nodata').parent().remove();
                    $('#list-top').after(view);
                }
            });
            
            //切换栏目的显示隐藏
            $('.hidechildcategory').toggle(function () {
                $('.ischilad').addClass('none');

                var _imgsrc = 'statics/base/images/colum1nx.gif';
                var _imgtargt = $('.open');
                _imgtargt.attr('src', _imgsrc);
                _imgtargt.addClass('closed').removeClass('open');
            }, function () {
                $('.ischilad').removeClass('none');

                var _imgsrc = 'statics/base/images/colum1nx2.gif';
                var _imgtargt = $('.closed');
                _imgtargt.attr('src', _imgsrc);
                _imgtargt.addClass('open').removeClass('closed');
            });

            //单个显示隐藏
            $('.columntables').delegate('.open, .closed', 'click', function () {
                if ($(this).hasClass('open')) {
                    $(this).attr('src', 'statics/base/images/colum1nx.gif');
                    $(this).addClass('closed').removeClass('open');
                    $('.class_' + $(this).attr('ccvalue')).addClass('none');
                } else if ($(this).hasClass('closed')) {
                    $(this).attr('src', 'statics/base/images/colum1nx2.gif');
                    $(this).addClass('open').removeClass('closed');
                    $('.class_' + $(this).attr('ccvalue')).removeClass('none');
                }
            });

            //是否启用
            $('.columntables').delegate('.color999 img', 'click', function () {
                var targetimg = $(this);
                var tag = (targetimg.attr('ccvalue') == "true");
                var __title = tag ? '禁用' : '启用';
               
                parent.confirmLayerNormal('确定' + __title + '此栏目吗?', function (index) {
                    parent.layer.close(index);

                    var _paramdata = {
                        action: "19eafd3becd7109be5f2fea577cfb27a",
                        arg: { id: targetimg.attr('actvalue'), st: !tag }
                    };
                    parent.doAjaxPost(_paramdata, function (_result) {
                        if (_result.success) {
                            var __src = 'statics/base/images/ok_' + (tag ? '0' : '1') + '.gif';
                            targetimg.attr({ src: __src, alt: __title, title: __title, ccvalue: (!tag).toString() });
                            parent.SuperSite.MsgOK('设置成功');
                        } else {
                            parent.SuperSite.MsgError(_result.msg);
                        }
                    });
                });
            });
            
            //更多操作按钮
            $('.columntables').delegate('.columnmore', 'mouseenter', function () {
                $(this).find('span.text').addClass("columnmore_hover");
                $(this).find('div.columnmorediv').show();
            });
            $('.columntables').delegate('.columnmore', 'mouseleave', function () {
                $(this).find('span.text').removeClass("columnmore_hover");
                $(this).find('div.columnmorediv').hide();
                $(this).find('.moveb1').hide();
            });

            //行效果
            $('.columntables').delegate('tr','hover', function () {
                $(this).toggleClass("ontr");                
            });

            //删除栏目
            $('.columntables').delegate('.del', 'click', function () {
                var _id = $(this).attr('ccvalue');
                var _target = $(this).parents('tr[class^="mouse"]');
                var _tag = _target.hasClass('isparent');
                var _msg = _tag ? '此栏目下的所有子栏目都会删除，确定吗？' : '确定删除此栏目吗？';

                parent.confirmLayerNormal(_msg, function (index) {
                    parent.layer.close(index);

                    var _paramdata = {
                        action: "ec7f086dea9f0414cd8522fea9799e51",
                        arg: { id: _id, tag: _tag }
                    };
                    parent.doAjaxPost(_paramdata, function (_result) {
                        if (_result.success) {                            
                            _target.remove();
                            if (_tag) { $('.class_' + _id).remove(); };
                            parent.SuperSite.MsgOK('删除成功');
                        } else {
                            parent.SuperSite.MsgError(_result.msg);
                        }
                    });
                });
            });
            
            //预览栏目结构
            $('.preview').click(function () {
                parent.OpeniframeLayer('栏目预览', 'control/previewcategory.html', ['1000px', '550px'], true);
            });
            
            //保存栏目
            $('.submit').click(function () {
                parent.confirmLayerNormal('您要保存当前栏目信息吗？', function (index) {
                    parent.layer.close(index);

                    var paramdata = {
                        action: "81a67b5263efb73b60785d492435682f",
                        arg: { items: getPageData() }
                    };
                    parent.doAjaxPost(paramdata, function (_result) {
                        if (_result.success) {
                            //parent.SuperSite.MsgOK('保存成功', 2000);
                            location.reload(true);
                        } else {
                            parent.SuperSite.MsgError(_result.msg);
                        }
                    });
                });
            });

            //...

        });
    </script>
</body>
</html>
