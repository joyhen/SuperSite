<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frienlinkedit.aspx.cs" Inherits="SuperSite.admin.frienlinkedit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑友情链接</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文：系统设置 > <a href="frienlink.aspx">友情链接</a> >  编辑(友情链接)</div>
        <div class="return"><a href="javascript:;" onclick="location.href='javascript:history.go(-1)'">&lt;&lt;返回</a></div>
    </div>
    <div class="clear"></div>

    <form id="myform">
        <div class="v52fmbx">

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>链接类型：</dt> 
                    <dd>
                        <input name="type" type="radio" class="radio" id="t3_0" value="1" checked="checked" />&nbsp;文字链接&nbsp;&nbsp;
				        <input name="type" type="radio" class="radio" id="t3_1" value="2"  />&nbsp;LOGO链接
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>网站名称：</dt>
                    <dd>
                        <input name="linkname" validate type="text" class="text nonull ccverify" />
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>网站域名：</dt>
                    <dd>
                        <input name="linkurl" validate type="text" class="text nonull ccverify" />
                        <span class="tips"></span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>关键词：</dt>
                    <dd>
                       <input name="linkurl" validate type="text" class="text nonull ccverify" />
                        <span class="tips">网站相关的关键词</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>排列顺序：</dt>
                    <dd>
                        <input name="linkorder" validate type="text" value="1" class="text nonull ccverify" />
                        <span class="tips">越小越靠前</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>审核状态：</dt>
                    <dd>
                        <input name="status" type="checkbox" class="checkbox" value="1" checked="checked" />&nbsp;审核通过
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>备注：</dt>
                    <dd>
                        <textarea name="content" cols="60" rows="5" class="textarea gen"></textarea>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox v52fmbx_mo">
                <dl>
                    <dt></dt>
                    <dd>
                        <input type="hidden" value="" name="id" />
                        <input type="button" value="保存" class="submit" />
                    </dd>
                </dl>
            </div>
        </div>
    </form>
   
    <script type="text/javascript" src="statics/base/js/jquery1.7.2.js"></script>
    <script type="text/javascript" src="statics/lib/jquery.serializeJSON.js"></script>
    <script type="text/javascript">
        //编辑友情链接
        function editFriendLink() {
            var $targetdom = $('input[validate],textarea[validate]');
            if (!parent.checkInput($targetdom, 'sysuseradd', null, true)) return;

            parent.confirmLayerNormal('确认提交吗？', function (index) {
                parent.layer.close(index);

                var paramdata = {
                    action: "",
                    arg: $('#myform').serializeJSON(),
                };
                parent.doAjaxPost(paramdata, function (_result) {
                    if (_result.success) {
                        location.href = 'sysuser.aspx';
                    } else {
                        parent.SuperSite.MsgError(_result.msg);
                    }
                });
            });
        };

        $(function () {
            parent.selectAllInputText($('input[type="text"]'));

            $('select[name="adtype"]').change(function () {
                var v = $(this).val();
                if (v != '-1') {
                    var msg = $(this).find('option:selected').attr('ccvalue');
                    $(this).next('.tips').text(msg);
                } else {
                    $(this).next('.tips').text('');
                }
            });
            
            //编辑友情链接
            $('.submit').click(editFriendLink);

            //...

        });
    </script></body>
</html>