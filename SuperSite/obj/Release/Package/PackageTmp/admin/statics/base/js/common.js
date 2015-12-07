document.write("<script type='text/javascript' src='statics/lib/parseUri.1.2.2.js'></script>");
document.write("<script type='text/javascript' src='statics/lib/jquery.serializeJSON.js'></script>");
document.write("<script type='text/javascript' src='statics/lib/layer-v2.0/layer/layer.js'></script>");

var globalAjaxParamGet = 'ajaxparam';
var globalRequestUrl = 'ashx/requestaction.ashx';

//固定浮动
$.fn.smartFloat = function (width_p) {

    var position = function (element) {
        var top = element.position().top,
            pos = element.css("position");

        $(window).scroll(function () {

            var scrolls = $(this).scrollTop();

            if (scrolls > top) {
                if (window.XMLHttpRequest) {
                    element.css({
                        position: "fixed",
                        'z-index': 999,
                        width: width_p,
                        top: 0
                    });
                } else {
                    element.css({ top: scrolls });
                }
            } else {
                element.css({
                    position: "", //absolute  
                    top: top
                });
            }
        });
    };

    return $(this).each(function () {
        position($(this));
    });
};

function getValidateMsg($validatedom) {
    var msgtip = "can't be empty";                      //out msg
    var msgmodel = '';                                  //smg model
    var msgkey = '';                                    //msg key
    var vtxt = $.trim($validatedom.attr('validate'));   //model$key

    if (vtxt == '') return msgtip;

    var arr = vtxt.split('$');
    if (arr.length >= 2) {
        msgmodel = $.trim(arr[0]);
        msgkey = $.trim(arr[1]);
    }
    else if (arr.length == 1) {
        msgkey = $.trim(arr[0]);

        var $modeltxt = $validatedom.attr('msgmodel');
        if ($modeltxt && $.trim($modeltxt).length > 0) {
            msgmodel = $.trim($modeltxt);
        }
    }

    if (msgkey == '') {
        return msgtip;
    }

    if (msgmodel == '') {
        var myurl = parseUri(location.href);
        var currentfile = myurl.file;
        var idx = currentfile.lastIndexOf('.');
        msgmodel = currentfile.substring(0, idx);
    }

    if (msgmodel == '') return msgtip;

    var tips = $.msg[msgmodel];
    if (tips && tips[msgkey]) {
        msgtip = tips[msgkey];
    }

    return msgtip;
}

//避免重复提交（间隔3秒钟，暂时没有用到,需要修改下）
function avoidSubmit(dom, fn) {    
    var avoidbutton = $(dom).attr('avoidfrequent');
    if (avoidbutton != undefined) {
        var txt = $(dom).val(); //需要修改
        var tag = parseInt($(dom).attr('submittag') || '0');

        if (tag == 0) {
            $(dom).attr({ submittag: "1", value: "..." });
            $(dom).unbind('click');

            setTimeout(function () {
                $(dom).attr({ submittag: "0", value: txt });
                $(dom).bind('click', fn);
            }, 1000 * 3);
        }
    }
}

//输入检查
function inputcheck(tipFn) {
    var tag = false;
    var checkitem = $('input[validate]');

    if (checkitem.length > 0) {
        checkitem.each(function (idx, dom) {
            var tar = $(dom);
            if ($.trim(tar.val()) == '') {
                if (typeof tipFn == "function") {
                    tipFn(getValidateMsg(tar));
                }

                tar.focus();
                tag = false;
                return false;
            } else {
                tag = true;
            }
        });
    }

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

    //固定面包屑
    $(".metinfotop").smartFloat($(".v52fmbx_tbmax").width());

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

function getJsonData(url, param, callback) {
    var p = param || {};

    $.getJSON(url, { ajaxparam: JSON.stringify(p) }, function (result) {
        if (typeof callback == "function") { callback(result); }
    });
};

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
        shadeClose: (isclose || true),
        area: layerwh, //['535px', '340px']
        content: openurl
    });

    if (isfull) {
        layer.full(_index);
    }
};

var SuperSite = {
    //0感叹，1对号，2差号，3问号，4凸号，5苦脸，6笑脸
    MsgWarning:function (msg) {
        layer.msg(msg || 'Warning', { icon: 0 });
    },
    MsgOK: function (msg) {
        layer.msg(msg || 'OK', { icon: 1 });
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
