//jq 扩展库 2016-02-01

/// 【扩展写法1】

/// <summary>
/// 固定浮动
/// <demo>固定面包屑: $(".metinfotop").smartFloat($(".v52fmbx_tbmax").width());</demo>
/// </summary>
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

/// 【扩展写法2】
$.fn.extend({
    /// <summary>
    /// 加载模板
    /// <demo>$(".sysadmin").loadTemplate('main');</demo>
    /// </summary>
    loadTemplate: function (templateName, isasync) {
        var target = $(this);
        parent.getTemplate(templateName, isasync, function (result) {
            target.after(result);
        });
    },
    /// <summary>
    /// 异步加载编辑器
    /// <demo>$('textarea[id="content"]').initEditor($('.word_count'), true, null);</demo>
    /// </summary>
    initEditor: function ($domCountWord, istiny, callback) {
        var editor; //定义编辑器对象
        var domselector = $(this).selector;

        if (istiny) {
            $.getScript('../kindeditor/kindeditor-min.js', function () {
                KindEditor.basePath = '../kindeditor/';
                editor = KindEditor.create(domselector, {
                    id: 'editor_id',
                    uploadJson: '../kindeditor/asp.net/upload_json.ashx',
                    fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',
                    allowFileManager: true, //默认false
                    resizeType: 1,
                    items: [
                        'undo', 'redo', '|',
                        'fontname', 'fontsize', '|',
                        'forecolor', 'hilitecolor', 'bold', 'italic', 'underline', 'removeformat', '|',
                        'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist', 'insertunorderedlist', '|',                        'image', 'link', '|', 'preview'],                    autoHeightMode: true,   //默认值: false
                    afterCreate: function () {
                        this.loadPlugin('autoheight');

                        var __doc = this.edit.doc;
                        KindEditor.ctrl(__doc, 'V', function () {
                            setTimeout(function () { parent.uploadWebImg(editor); }, 200);
                        });

                        callback(editor);

                        //$(__doc).bind('paste', null, function () { //右键粘贴, 包括 ctrl+v 
                        //    alert('123');
                        //});
                    },                    afterChange: function () {
                        $domCountWord.html(this.count());   //（字数统计包含HTML代码。）
                    },
                });
            });
        } else {
            $.getScript('../kindeditor/kindeditor-min.js', function () {
                KindEditor.basePath = '../kindeditor/';
                editor = KindEditor.create(domselector, {
                    id: 'editor_id',
                    uploadJson: '../kindeditor/asp.net/upload_json.ashx',
                    fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',
                    allowFileManager: true,
                    resizeType: 1,
                    afterCreate: function () {
                        var __doc = this.edit.doc;
                        KindEditor.ctrl(__doc, 'V', function () {
                            setTimeout(function () { parent.uploadWebImg(editor); }, 200);
                        });

                        callback(editor);
                    },                    afterChange: function () {
                        $domCountWord.html(this.count());
                    },
                });
            });
        }
    }

});