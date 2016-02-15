<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="advertedit.aspx.cs" Inherits="SuperSite.admin.advertedit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑广告</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文：系统设置 > <a href="advert.aspx">站内广告</a> > 编辑广告</div>
        <div class="return"><a href="javascript:;" onclick="location.href='javascript:history.go(-1)'">&lt;&lt;返回</a></div>
    </div>
    <div class="clear"></div>

    <div class="stat_list">
		<ul>
			<li><a href="advert.aspx" title="站内广告">站内广告</a></li>
			<li class="now"><a href="adverttype.aspx" title="广告类别">广告类别</a></li>
		</ul>
	</div>
    <div class="clear"></div>

    <form id="myform">
        <div class="v52fmbx">

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>广告类别：</dt> 
                    <dd>
                        <select name="adtype" class="ccselect">
                            <option value="-1">——广告类别——</option>
                            <option value="1" ccvalue="合作对象的广告">合作客户</option>
                            <option value="2" ccvalue="首页顶部轮播图广告">首页幻灯片</option>
                            <option value="3" ccvalue="内容页则边栏的广告">边距广告</option>
                            <option value="4" ccvalue="内容页横栏广告">横栏广告</option>
                        </select>
                        <span class="tips"></span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>广告名称：</dt>
                    <dd>
                        <input name="adname" validate type="text" class="text nonull ccverify" />
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>链接网址：</dt>
                    <dd>
                        <input name="adurl" validate type="text" class="text nonull ccverify" />
                        <span class="tips">此广告的链接，可以是一个活动页或广告商提供页</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>图片宽高：</dt>
                    <dd>
                       <input name="ad_w" 
                           type="text" class="text mid" value="100" />宽  <input name="ad_h" 
                               type="text" class="text mid" value="100" />高
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>排列顺序：</dt>
                    <dd>
                        <input name="adorder" validate type="text" value="1" class="text nonull ccverify" />
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
                    <dt>广告内容：</dt>
                    <dd>
                        <textarea id="content" style="width:80%;height:150px;"></textarea>
                        <span class="tips">您当前输入了 <span class="word_count">0</span> 个文字</span>
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
    <script type="text/javascript" src="statics/base/js/jquery-extend.js"></script>
    <script type="text/javascript" src="statics/lib/jquery.serializeJSON.js"></script>
    <script type="text/javascript">
        var editor; //定义编辑器对象
        //新增
        function editAdvert() {
            if ($('select[name="adtype"]').val() == '-1') {
                parent.SuperSite.MsgWarning('请选择广告类别')
                return;
            };

            var $targetdom = $('input[validate],textarea[validate]');
            if (!parent.checkInput($targetdom, 'sysuseradd', null, true)) return;

            parent.confirmLayerNormal('确认提交吗？', function (index) {
                parent.layer.close(index);

                var fitem = $('#myform').serializeJSON();
                delete fitem.undefined;
                fitem.content = parent.__escape(editor.html());

                var paramdata = {
                    action: "",
                    arg: fitem,
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

            //初始化编辑器
            $('textarea[id="content"]').initEditor($('.word_count'), false, function (_e) {
                editor = _e;
            });

            //编辑广告
            $('.submit').click(editAdvert);

            //...

        });
    </script></body>
</html>