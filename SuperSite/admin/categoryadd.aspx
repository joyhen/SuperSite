<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="categoryadd.aspx.cs" Inherits="SuperSite.admin.categoryadd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>栏目添加</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文：系统设置 > <a href="category.aspx">栏目管理</a> > 添加栏目</div>
        <div class="return"><a href="javascript:;" onclick="location.href='javascript:history.go(-1)'">&lt;&lt;返回</a></div>
    </div>
    <div class="clear"></div>

    <form id="myform">
        <div class="v52fmbx">
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>栏目名称：</dt>
                    <dd>
                        <input name="name" validate type="text" class="text nonull ccverify" value="" />
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>URL名称：</dt>
                    <dd>
                        <input name="url" validate type="text" class="text nonull ccverify" value="" />
                        <%--<input type="button" value="拼音" class="bnt_pinyin" />
                        <input type="button" value="英文" class="bnt_english" />--%>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>父级栏目：</dt>
                    <dd>
                        <select name="parentid" class="ccselect">
                            <option value="-1">——选择栏目——</option>
                            <%foreach (var item in PageParentCategory) { %>
                            <option value="<%=item.key %>"><%=item.value %></option>
                            <%} %>
                        </select>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>栏目模型：</dt>
                    <dd>
                        <select name="sitemodel" class="ccselect">     
                            <option value="-1">——选择模型——</option>
                             <%foreach (var item in PageSiteModelSiteModelStyle) { %>
                             <option value="<%=item.key %>"><%=item.value %></option>
                             <%} %>                       
                        </select>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>列表模板：</dt>
                    <dd>
                        <input name="listtemplate" type="text" class="text " value="" />
                        <span class="tips">可以为空 (模板路径) 例如:model/news/list</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>内容模板：</dt>
                    <dd>
                        <input name="contenttemplate" type="text" class="text " value="" />
                        <span class="tips">可以为空 (模板路径) 例如:model/news/show</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>是否启用：</dt>
                    <dd>
                        <input name="status" type="radio" class="radio" value="1" checked="checked" />是&nbsp;&nbsp;
                        <input name="status" type="radio" class="radio" value="0" />否&nbsp;&nbsp;&nbsp;&nbsp;
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>是否新窗口：</dt>
                    <dd>
                        <input name="targetblank" type="radio" class="radio" value="1" checked="checked" />是&nbsp;&nbsp;
                        <input name="targetblank" type="radio" class="radio" value="0" />否&nbsp;&nbsp;&nbsp;&nbsp;
                        <span class="tips">是否新窗口打开</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>底部显示：</dt>
                    <dd>
                        <input name="showfoot" type="radio" class="radio" value="1" checked="checked" />是&nbsp;&nbsp;
                        <input name="showfoot" type="radio" class="radio" value="0" />否&nbsp;&nbsp;&nbsp;&nbsp;
                        <span class="tips">是否底部显示</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>排序：</dt>
                    <dd>
                        <input name="sortnumber" type="text" title="不能为空" class="text mid" value="0" />
                        <span class="tips">排序越小越靠前</span>
                    </dd>
                </dl>
            </div>

            <%--<div class="v52fmbx_dlbox">
                <dl>
                    <dt>栏目图片：</dt>
                    <dd>
                        <input name="pic" type="text" class="text" maxlength="200" value="" />
                        <input type="button" id="image" class="bnt_public" value="图片上传" />
                        <span class="tips">预览</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>外部连接：</dt>
                    <dd>
                        <input name="url" type="text" class="text" maxlength="200" value="" />
                    </dd>
                </dl>
            </div>--%>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>详细内容：</dt>
                    <dd>
                        <textarea id="content" style="width:80%;height:100px;"></textarea>
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
            <%--<h3 class="v52fmbx_hr metsliding" sliding="3">这是分类项的表头</h3>--%>
        </div>
    </form>
   
    <script type="text/javascript" src="statics/base/js/jquery1.7.2.js"></script>
    <script type="text/javascript" src="statics/base/js/jquery-extend.js"></script>
    <script type="text/javascript" src="statics/lib/jquery.serializeJSON.js"></script>
    <script type="text/javascript">
        var editor; //定义编辑器对象        //新增
        function addCategory() {
            var $targetdom = $('input[validate],textarea[validate]');
            if (!parent.checkInput($targetdom, 'categoryadd', null, true)) return;

            var fitem = $('#myform').serializeJSON();
            delete fitem.undefined;
            fitem.content = parent.__escape(editor.html());

            parent.confirmLayerNormal('确认提交吗？', function (index) {
                parent.layer.close(index);

                var paramdata = {
                    action: "20ccc6dd8aa146d634ffa0d6f2265ca4",
                    arg: fitem,
                };
                parent.doAjaxPost(paramdata, function (_result) {
                    if (_result.success) {
                        location.href = 'category.aspx';
                    } else {
                        parent.SuperSite.MsgError(_result.msg);
                    }
                });
            });
        };        $(function () {
            parent.selectAllInputText($('input[type="text"]'));
            $('select[name="parentid"]').val('<%=ParentCategoryId%>')
            //初始化编辑器
            $('textarea[id="content"]').initEditor($('.word_count'), true, function (_e) {
                editor = _e;            });
            //新增栏目
            $('.submit').click(addCategory);

            //...

        });
    </script></body>
</html>
