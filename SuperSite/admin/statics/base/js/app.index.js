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
    OpeniframeLayer('设置系统语言', 'control/langset.html?clang=' + _glang, ['540px', '300px'], true);
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

//窄版/宽版切换
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
    iframeresize();

    $(document).keydown(function (e) {
        if (e.which === 27) {
            $('#outhome').trigger('click');         //ESC退出
        } else if (window.event.keyCode == 113) {   //F2
            showNavigationPanel();
        }
    });

    $('#content, #top .topnbox').animate({ width: '99%' }, 80);
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
            layer.close(index);
            doAjaxPost({ action: '1985727f158a4db42d79a71242df8df3' }, function (result) {
                if (result.success) {
                    SuperSite.MsgOK('缓存数据已清除');
                } else {
                    parent.layer.msg(result.msg);
                }
            });           
        });
    });

    //...

})



