var loginModel = {
    userlogin: function () {
        var _f = function (msg) {
            $('.tipmsg').html(msg);
        };
        
        if (inputcheck(_f)) {
            var paramdata = {
                action: "Login",
                arg: $('#myform').serializeJSON()
            };
            
            doAjaxPost(paramdata, loginModel.logincallback);
        }
    },
    logincallback: function (result) {
        if (!(result.success)) {
            SuperSite.MsgFailed(result.msg);            
            $('#imgcode').trigger('click');
            return;
        }

        if (result.data == null || result.data == '') {
            window.location.href = "index.aspx";
            return;
        }

        $("#myform").fadeOut();

        layer.prompt({
            title: result.data,
            formType: 0,
            maxlength: 40,
            move: false,
            closeBtn: false,
            offset: ['240px']
        }, function (pass) {
            doAjaxPost({ action: 'AnswerQuesion', arg: { answer: pass } }, function (_result) {
                if (_result.success) {
                    window.location.href = "index.aspx";
                } else {
                    SuperSite.MsgError(_result.msg);
                }
            });
        });
    },
    changeValidCode: function () {
        document.getElementById("code").value = "";

        var dt = new Date().getTime();
        $('#imgcode').attr('src', "control/validatecode.ashx?p=" + dt);
    },
    init: function () {
        var self = this;

        $(function () {
            $('#imgcode').click(self.changeValidCode);

            $('#btnlogin').bind('click', self.userlogin);

            $("input[class*='text']").on("keydown", function (e) {
                if (e.keyCode == 13) {
                    self.userlogin();
                }
            });            

            //...
        });
    }
    
};