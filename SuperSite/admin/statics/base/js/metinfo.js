(function ($) {
    //ie6下gif背景色处理
    var jspath = $('script').last().attr('src');
    var basepath = '';
    if (jspath.indexOf('/') != -1) {
        basepath += jspath.substr(0, jspath.lastIndexOf('/') + 1);
    }
    $.fn.fixpng = function (options) {
        function _fix_img_png(el, emptyGIF) {
            var images = $('img[src*="png"]', el || document),
            png;
            images.each(function () {
                png = this.src;
                width = this.width;
                height = this.height;
                this.src = emptyGIF;
                this.width = width;
                this.height = height;
                this.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(src='" + png + "',sizingMethod='scale')";
            });
        }
        function _fix_bg_png(el) {
            var bg = $(el).css('background-image');
            if (/url\([\'\"]?(.+\.png)[\'\"]?\)/.test(bg)) {
                var src = RegExp.$1;
                $(el).css('background-image', 'none');
                $(el).css("filter", "progid:DXImageTransform.Microsoft.AlphaImageLoader(src='" + src + "',sizingMethod='scale')");
            }
        }
        if ($.browser.msie && $.browser.version < 7) {
            return this.each(function () {
                var opts = {
                    scope: '',
                    emptyGif: basepath + 'blank.gif'
                };
                $.extend(opts, options);
                switch (opts.scope) {
                    case 'img':
                        _fix_img_png(this, opts.emptyGif);
                        break;
                    case 'all':
                        _fix_img_png(this, opts.emptyGif);
                        _fix_bg_png(this);
                        break;
                    default:
                        _fix_bg_png(this);
                        break;
                }
            });
        }
    }
})(jQuery);

function domhidetime(dom, time) {
    if (!dom.is(':hidden')) {
        t = setTimeout(function () {
            dom.hide();
        },
        time);
        dom.hover(function () {
            clearTimeout(t);
        },
        function () {
            domhidetime(dom, time);
        });
    }
};
function domhover(dom, cs) {
    if (dom) {
        dom.hover(function () {
            $(this).addClass(cs);
        }, function () {
            $(this).removeClass(cs);
        });
    }
};

function cknav(d) {
    if (d instanceof jQuery) {
        if (d.attr("id") != 'top_quick_a') {
            $('#topnav a').removeClass("onnav");
            d.addClass("onnav");
            $("ul[id^='ul_']").hide();
            var u = String(d.attr('id'));
            u = u.split('_');
            u = u[1];

            $("#ul_" + u).show();
            u = $("#ul_" + u).find('li a').eq(0);
            frameget(u);
        }
    } else {
        cknav($('#nav_' + d));
    }
};

function frameget(u) {
    if (u.attr('target')) {
        if (u.attr('target') == '_blank') return false;

        $("#leftnav a").removeClass("on");
        $("#main").attr("src", u.attr('href'));
        $("#main").src = $("#main").src;
        u.addClass("on");
    }
};

//页面高度计算
function iframeresize() {
    resizeU();
    $(window).resize(resizeU);
    function resizeU() {
        var topH = 68 + 28;
        var footH = 33;
        var divkuangH = $(window).height();
        var mainH = divkuangH - topH - footH;

        $("#metcmsbox").attr('jiluht', mainH);
        $("#metcmsbox").css("height", mainH);
        $('#metleft').height(mainH);
        $('#metleft .floatl_box').height(mainH);
        $('#metright').height(mainH);
        $('#metright iframe').height(mainH);

        //alert(mainH);
    }
};

//顶部导航模块单击
$('#topnav a').click(function () {
    cknav($(this));
});
//左侧模块菜单单击
$("#leftnav a").click(function () {
    frameget($(this));
});

//设置语言
$('#language').click(function () {
    OpeniframeLayer('设置系统语言', 'control/langset.html?clang=' + _glang, ['540px', '300px']);
});

//退出
$('#outhome').click(function () {
    confirmLayerNormal('确定退出系统吗？', function (index) {
        layer.close(index);
        $("#top, #content").html('').fadeOut('fast', function () {
            location.href = "loginout.aspx";
        });
    });
});

//意见建议
$('.left_footer_box').click(function () {
    OpeniframeLayer('意见建议', 'control/advise.html', ['540px', '275px'], false);
});

//顶部导航宽度
function topwidth(tm) {
    var navk = $("#topnav").width();
    $("#langcig span.title img").hide();
    var ritk = $('ol.rnav').width() + 21;
    $("#langcig span.title img").show();
    //if((navk+ritk)>$(".top-r-box").width()){
    var ls = $("#topnav li").size();
    var kd = parseInt(($(".top-r-box").width() - ritk - 5) / ls);
    if (kd > 130) kd = 130;
    tm = tm ? tm : 0;
    $("#topnav li").animate({ width: kd + 'px' }, tm);
    //}
};
topwidth();

$(function () {
    iframeresize();

    $(document).keydown(function (e) {
        if (e.which === 27) {
            $('#outhome').trigger('click');         //ESC退出
        } else if (window.event.keyCode == 113) {   //F2
            showNavigationPanel();
        }
    });

    //...

})



