$(function () {
    $('#imgcode').click(changeValidCode);

    $('#btnlogin').bind('click', self.userlogin);

    $("input[class*='text']").on("keydown", function (e) {
        if (e.keyCode == 13) {
            self.userlogin();
        }
    });
});

function changeValidCode() {
    document.getElementById("code").value = "";

    var dt = new Date().getTime();
    $('#imgcode').attr('src', "control/validatecode.ashx?p=" + dt);
};

function userlogin() {
    var _f = function (msg) {
        $('.tipmsg').html(msg);
    };

    var $checkitem = $('input[validate],textarea[validate]');

    if (checkInput($checkitem, 'login', _f)) {
        $('.tipmsg').html('&nbsp;'); //提交前清空提示内容
        var paramdata = {
            action: "934fdb86f88159dd000255872fea60d0",
            arg: $('#myform').serializeJSON()
        };
        doAjaxPost(paramdata, loginCallBack);
    };
};

function loginCallBack(result) {
    if (!(result.success)) {
        SuperSite.MsgFailed(result.msg);
        $('#imgcode').trigger('click');
        return;
    };

    if (result.data == null || result.data == '') {
        window.location.href = "index.aspx";
        return;
    };

    $("#myform").fadeOut();

    layer.prompt({
        title: result.data,
        formType: 0,
        maxlength: 40,
        move: false,
        closeBtn: false,
        offset: ['240px']
    }, function (pass) {
        var paramdata = { action: '1e43711651eea8f1b3a6485a59a369ab', arg: { answer: pass } };
        doAjaxPost(paramdata, function (_result) {
            if (_result.success) {
                window.location.href = "index.aspx";
            } else {
                SuperSite.MsgError(_result.msg);
            }
        });
    });
};