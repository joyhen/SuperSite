var commModel = {
    latticeTable: function () {
        $(".mouse:odd").css("background", "#FFFCEA");
    },
};

var loginModel = {
    userlogin: function () {
        var _f = function (msg) {
            $('.tipmsg').html(msg);
        };

        if (inputcheck(_f)) {
            $('.tipmsg').html('&nbsp;');

            var paramdata = {
                action: "934fdb86f88159dd000255872fea60d0",
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
            var _p = { action: '1e43711651eea8f1b3a6485a59a369ab', arg: { answer: pass } };
            doAjaxPost(_p, function (_result) {
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

var noticeModel = {
    add: function () {
        function callback(result) {
            if (result.success) {
                location.href = 'noticetype.aspx';
            } else {
                parent.SuperSite.MsgFailed(result.msg);
            }
        };

        function addnoticetype() {
            var _f = function (msg) {
                parent.SuperSite.MsgFailed(msg);
            };
            var _chkitem = $('input[validate],textarea[validate]');
            var _url = location.href;

            if (parent.inputcheck(_f, _chkitem, _url)) {
                var paramdata = {
                    action: "6a24d4bf13f76fea4c5c5066d10cb2d3",
                    arg: $('#myform').serializeJSON()
                };
                parent.doAjaxPost(paramdata, callback);
            }
        };

        $(function () {
            $('.submit').click(addnoticetype);
        });
    },
    edit: function () {

    },
    init: function () {
        $(function () {
            //加载数据
            parent.renderTable(
                { action: "4ae1109be457ba23957be22267add1a3" },
                $('.table'),
                $('#template').html(),
                commModel.latticeTable
            );

            $('#delnoticetype').click(function () {
                var chklist = $('.table tr:gt(0)').find(':checked');
                if (chklist.length == 0) {
                    parent.SuperSite.MsgError(parent.$.msg.common.deleteitems);
                    return;
                }

                var ids = chklist.map(function (idx, dom) { return $(dom).attr('value'); });
                var paramdata = {
                    action: "fdsfdsfd",
                    arg: { globalAjaxParamGet: ids.get().join('&') }
                };

                parent.doAjaxPost(paramdata, function (result) {
                    if (result.success) {
                        //...移除对应的tr
                    } else {
                        parent.SuperSite.MsgError(success.msg);
                    }
                });
            });

            //...

        });
    }

};