$(function () {
    //加载数据
    parent.renderTemplate(
        { action: "e512b6708661e86e4c95099c90635334" },
        $('#template').html(),
        function (view) {
            if (view && $.trim(view) != '') {
                $('.td_nodata').parent().remove();
                $('.table tr:first').after(view);
                $(".mouse:odd").css("background", "#FFFCEA");
            }
        }
    );

    //全选
    $('#chkAll').click(function () {
        var s = $(this).prop('checked');
        var t = $('.mouse input[type="checkbox"]');
        if (s) {
            t.prop('checked', true)
        } else {
            t.prop('checked', false)
        }
    });

    function delsysuser(items, callback) {
        var paramdata = {
            action: "26aa7ba937b014924702866fc555c81d",
            arg: { ids: items || [] }
        };

        parent.confirmLayerNormal('确定删除吗？', function (index) {
            parent.layer.close(index);
            parent.doAjaxPost(paramdata, function (result) {
                if (result.success) {
                    callback();
                    parent.resetDataTable($('.table'));
                } else {
                    parent.SuperSite.MsgError(result.msg);
                }
            });
        });
    };

    //删除
    $('.table').delegate('.ccbtnerror', 'click', function () {
        var target = $(this);        
        var item = [{ id: target.attr('ccvalue') }];

        delsysuser(item, function callback() {
            target.parent().parent().remove();            
        });
    });
    //删除
    $('#delnoticetype').click(function () {
        var removeitem = [];

        var chklist = $('.table tr:gt(0)').find(':checked');
        if (chklist.length == 0) {
            parent.SuperSite.MsgError(parent.$.msg.common.deleteitems);
            return;
        };

        var item = chklist.map(function (idx, dom) {
            removeitem.push($(dom).parent().parent());
            return { id: $(dom).attr('value') };
        }).get();

        delsysuser(item, function () {
            $(removeitem).each(function (idx, dom) { $(dom).remove(); });
        });
    });

    //...

});