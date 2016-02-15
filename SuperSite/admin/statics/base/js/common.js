document.write("<script type='text/javascript' src='statics/lib/parseUri.1.2.2.js'></script>");
document.write("<script type='text/javascript' src='statics/lib/jquery.serializeJSON.js'></script>");
document.write("<script type='text/javascript' src='statics/lib/layer-v2.0/layer/layer.js'></script>");

//输入框校验
function checkInput($checkdom, validateModel, callbackfn, defaultfn) {
    var tag = false;
    var checkitem = $checkdom || $("iframe").contents().find("input[validate],textarea[validate]");
    if (checkitem.length == 0) return true;

    checkitem.each(function (idx, dom) {
        var tar = $(dom);
        if ($.trim(tar.val()) == '') {
            var msgtip = "can't be empty";
            var msgkey = $.trim(tar.attr('validate'));

            var tips = $.msg[validateModel];
            if (tips) {
                msgtip = tips[msgkey];
            } else {
                var _title = tar.attr('title');
                if ($.trim(_title) != '') {
                    msgtip = _title;
                }
            };

            if (typeof callbackfn == "function") {
                callbackfn(msgtip);
            } else if (defaultfn) {
                SuperSite.MsgWarning(msgtip);
            }

            tar.focus();
            tag = false;
            return false;
        } else {
            tag = true;
        }
    });

    return tag;
};

$(function () {

    layer.config({
        extend: '/extend/layer.ext.js',
        //skin: 'layer-ext-moon', //一旦设定，所有弹层风格都采用此主题。
        //extend:'skin/moon/style.css'
    });

    //输入框焦点样式处理
    $("input[class*='text']").focus(function () {
        $(this).addClass('metfocus');
    }).focusout(function () {
        $(this).removeClass('metfocus');
    });

    //回到顶部
    $('body').append('<div class="gototop" style="display:none;"><span title="回到顶部"></span></div>');
    $('.gototop').click(function () {
        $('html,body').animate({ scrollTop: '0px' }, 300);
    });
    //回到顶部显示与隐藏
    $(window).scroll(function () {
        if ($(window).scrollTop() >= 100) {
            $('.gototop').fadeIn(300);
        } else {
            $('.gototop').fadeOut(300);
        }
    });

    //...

});

var IndexNavigation = 0;
///导航
function showNavigationPanel() {
    if (IndexNavigation != 0) {
        layer.close(IndexNavigation)
    } else {
        IndexNavigation = layer.open({
            type: 2, //0~2
            title: '管理中心导航',
            skin: 'layui-layer-rim', //加上边框
            area: ['750px', '470px'], //宽高
            shade: false,
            content: 'control/navigation.html',
            cancel: function (_index) {
                IndexNavigation = 0;
            },
            end: function () {
                IndexNavigation = 0;
            }
        });
    }
};

//重置表格
function resetDataTable($table) {
    var _loading = '<tr><td colspan="15" class="list td_nodata">没有数据</td></tr>';

    var _tb = $table;
    var _tr = _tb.find('tr');
    if (_tr.length <= 1) {
        _tb.html(_loading);
    }
};

//获取数据，渲染模板
function renderTemplate(param, template, callback) {
    getJsonData(param, function (result) {
        if (result.success) {
            if (result.data) {
                Mustache.parse(template || '');
                var view = Mustache.render(template, result);
                if (typeof callback == "function") { callback(view); }
            } else {
                SuperSite.MsgWarning('获取模板数据失败');
            }
        } else {
            SuperSite.MsgFailed(result.msg);
        }
    });
};

//加载模板内容
function getTemplate(templateName, isasync, callback) {
    $.ajax({
        type: "get",
        url: 'statics/tpt/' + templateName + '.txt',
        async: isasync || false, //同步
        success: callback
    });
};

//获取Json数据
function getJsonData(param, callback) {
    var p = param || {};

    $.getJSON(globalRequestUrl, { ajaxparam: JSON.stringify(p) }, function (result) {
        if (typeof callback == "function") { callback(result); }
    });
};

//post提交
function doAjaxPost(paramdata, callback, errfn) {
    $.ajax({
        type: "post",
        dataType: "json",
        data: JSON.stringify(paramdata),
        url: globalRequestUrl,
        eache: false,
        success: function (result) {
            if (typeof callback == "function") {
                callback(result);
            }
        },
        error: errfn || function () {
            SuperSite.MsgError('error, please contact the administrator');
        }
    });
};

//获取html
function loadHtml($dom, url, callback, param) {
    var _p = param || {};

    $dom.load(url, _p, function () {
        if (typeof callback == "function") { callback(); }
    });
};

//Confirm窗口
function confirmLayerNormal(msg, callback) {
    layer.confirm(msg, { icon: 3, title: '提示', shadeClose: true, closeBtn: false }, function (_index) {
        if (typeof callback == "function") {
            callback(_index);
        }
    });
};
function confirmLayer(msg, btnarr, f1, f2) {
    layer.confirm(msg, {
        icon: 0,
        title: '提示',
        btn: btnarr, //['确定', '取消']
        closeBtn: false,
        shadeClose: true
    }, function (_index) {
        if (typeof f1 == "function") { f1(_index); }
    }, function (__index) {
        if (typeof f2 == "function") { f2(__index); }
    });
};

//打开iframe
function OpeniframeLayer(opentitle, openurl, layerwh, isclose, showmaxmin, isfull) {
    var _index = layer.open({
        type: 2,
        skin: 'layui-layer-lan',
        title: opentitle,
        fix: true,
        maxmin: (showmaxmin || false),
        shadeClose: (isclose || false),
        area: layerwh, //['535px', '340px']
        content: openurl
    });

    if (isfull) {
        layer.full(_index);
    }
};

var SuperSite = {
    //0感叹，1对号，2差号，3问号，4凸号，5苦脸，6笑脸
    MsgWarning: function (msg, time) {
        var t = time || 1500;
        layer.msg(msg || 'Warning', { icon: 0, time: t });
    },
    MsgOK: function (msg, time, callback) {
        var t = time || 1500;
        layer.msg(msg || 'OK', { icon: 1, time: t }, function () {
            if (typeof callback == "function") { callback(); }
        });
    },
    MsgError: function (msg) {
        layer.msg(msg || 'Error', { icon: 2 });
    },
    MsgConfirm: function (msg) {
        layer.msg(msg || 'Confirm', { icon: 3 });
    },
    MsgLock: function (msg) {
        layer.msg(msg || 'Lock', { icon: 4 });
    },
    MsgFailed: function (msg) {
        layer.msg(msg || 'Failed', { icon: 5 });
    },
    MsgSuccess: function (msg) {
        layer.msg(msg || 'Success', { icon: 6 });
    }

    //...

};

//检查图片有效性
function checkimgok(imgsrc) {
    var checkimg = ['jpg', 'gif', 'jpeg', 'png', 'bmp'];
    var idx = imgsrc.lastIndexOf('.');
    var tail = imgsrc.substring(idx + 1, imgsrc.length);

    if ($.trim(tail) == '') {
        return false;
    }

    for (var i = 0; i < checkimg.length; i++) {
        if (checkimg[i] == tail) return true;
    }

    return false;
};

//上传远程图片function uploadWebImg(editor) {
    var relaceSrc = []; //图片地址对象容器
    var imgs = $(editor.html()).find('img');

    imgs.map(function () {
        var _src = $(this).attr('src');
        //if ((_src.indexOf('http://') >= 0 || _src.indexOf('https://') >= 0) && checkimgok(_src)) {
        //考虑可能有动态生成的图片
        if ((_src.indexOf('http://') >= 0 || _src.indexOf('https://') >= 0) && _src.indexOf('localhost:') < 0) {
            relaceSrc.push({ k: _src });
        };
    });

    if (relaceSrc.length == 0) return;

    var msg = '内容包含' + relaceSrc.length.toString() + '张远程图片，是否现在上传？';

    confirmLayerNormal(msg, function (_index) {
        var loading = layer.load(0);
        var paramdata = {
            action: "791c252eee12530f4f3af326674b7d97",
            arg: { imgs: relaceSrc },
        };

        doAjaxPost(paramdata, function (result) {
            layer.close(loading);
            if (!result.success) {
                SuperSite.MsgError(result.msg);
                return;
            }

            //替换编辑器图片源
            var _content = editor.html();
            $(relaceSrc).each(function (idx, dom) {
                _content = _content.replace(dom.k, result.data[idx].value);
            });
            editor.html(_content);

            SuperSite.MsgOK('远程图片上传成功');
        });
        layer.close(_index);
    });
};

function __escape(val) {
    return val.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
};
function __unescape(val) {
    return val.replace(/&lt;/g, '<').replace(/&gt;/g, '>').replace(/&quot;/g, '"').replace(/&amp;/g, '&');
};

//绑定校验或提示效果（需要poshytip插件）
function bindTipMsg($dom) {
    $dom.poshytip({
        className: 'tip-yellowsimple',
        showOn: 'focus',
        alignTo: 'target',
        alignX: 'right',
        alignY: 'center',
        offsetX: 5,
        showTimeout: 100
        //content: function (updateCallback) {
        //    var msg = $(this).attr('title');
        //    if (msg && $.trim(msg) != '') {
        //        return msg;
        //    }

        //    var msgkey = $.trim($(this).attr('validate'));
        //    var tips = $.msg[validateModel];
        //    if (tips) {
        //        msgtip = tips[msgkey] || "can't be empty";
        //    }

        //    updateCallback('');

        //    return 'loading tips..';
        //}
    });
};

//鼠标移动到输入框上自动选中内容
function selectAllInputText($dom) {
    $dom.hover(function () {
        $(this).focus();
        $(this).select();
    }, function () {
        $(this).blur();
    });
};

//当前日期和时间
function setTime($dom) {
    var day = "";
    var month = "";
    var ampm = "";
    var ampmhour = "";
    var myweekday = "";
    var year = "";
    var myHours = "";
    var myMinutes = "";
    var mySeconds = "";
    mydate = new Date();
    myweekday = mydate.getDay();
    mymonth = mydate.getMonth() + 1;
    myday = mydate.getDate();
    myyear = mydate.getYear();
    myHours = mydate.getHours();
    myMinutes = mydate.getMinutes();
    mySeconds = mydate.getSeconds();
    myHours = parseInt(myHours) < 10 ? "0" + myHours : myHours;
    myMinutes = parseInt(myMinutes) < 10 ? "0" + myMinutes : myMinutes;
    mySeconds = parseInt(mySeconds) < 10 ? "0" + mySeconds : mySeconds;
    year = (myyear > 200) ? myyear : 1900 + myyear;

    if (myweekday == 0) {
        weekday = "星期日";
    } else if (myweekday == 1) {
        weekday = "星期一";
    } else if (myweekday == 2) {
        weekday = "星期二";
    } else if (myweekday == 3) {
        weekday = "星期三";
    } else if (myweekday == 4) {
        weekday = "星期四";
    } else if (myweekday == 5) {
        weekday = "星期五";
    } else if (myweekday == 6) {
        weekday = "星期六";
    }
    $dom.html(year + "年" + mymonth + "月" + myday + "日&nbsp;" + weekday + "&nbsp;" + myHours + ":" + myMinutes + ":" + mySeconds);
    setTimeout("setTime()", 1000);
};
