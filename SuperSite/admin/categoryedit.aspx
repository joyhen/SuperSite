<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="categoryedit.aspx.cs" Inherits="SuperSite.admin.categoryedit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑栏目</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文：系统设置 > <a href="category.aspx">栏目管理</a> > 编辑栏目</div>
        <div class="return"><a href="javascript:;" onclick="location.href='javascript:history.go(-1)'">&lt;&lt;返回</a></div>
    </div>
    <div class="clear"></div>

    <form id="myform">
        <div class="v52fmbx">
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>栏目名称：</dt>
                    <dd>
                        <input name="name" type="text" validate class="text nonull ccverify" value="<%=PageCategory.Name %>" />
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>URL名称：</dt>
                    <dd>
                        <input name="url" type="text" validate class="text nonull ccverify" value="<%=PageCategory.Url %>" />
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
                        <input name="listtemplate" type="text" class="text " value="<%=PageCategory.ListTemplate %>" />
                        <span class="tips">可以为空 (模板路径) 例如:model/news/list</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>内容模板：</dt>
                    <dd>
                        <input name="contenttemplate" type="text" class="text " value="<%=PageCategory.ContentTemplate %>" />
                        <span class="tips">可以为空 (模板路径) 例如:model/news/show</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>是否启用：</dt>
                    <dd>
                        <input name="status" type="radio" class="radio" value="1" <%=PageCategory.Status.Value ? "checked='checked'" : "" %> />是&nbsp;&nbsp;
                        <input name="status" type="radio" class="radio" value="0" <%=!PageCategory.Status.Value ? "checked='checked'" : "" %> />否&nbsp;&nbsp;&nbsp;&nbsp;
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>是否新窗口：</dt>
                    <dd>
                        <input name="targetblank" type="radio" class="radio" value="1" <%=PageCategory.TargetBlank.Value ? "checked='checked'" : "" %> />是&nbsp;&nbsp;
                        <input name="targetblank" type="radio" class="radio" value="0" <%=!PageCategory.TargetBlank.Value ? "checked='checked'" : "" %> />否&nbsp;&nbsp;&nbsp;&nbsp;
                        <span class="tips">是否新窗口打开</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>底部显示：</dt>
                    <dd>
                        <input name="showfoot" type="radio" class="radio" value="1" <%=PageCategory.ShowFoot.Value ? "checked='checked'" : "" %> />是&nbsp;&nbsp;
                        <input name="showfoot" type="radio" class="radio" value="0" <%=!PageCategory.ShowFoot.Value ? "checked='checked'" : "" %> />否&nbsp;&nbsp;&nbsp;&nbsp;
                        <span class="tips">是否底部显示</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>排序：</dt>
                    <dd>
                        <input name="sortnumber" type="text" class="text mid" value="<%=PageCategory.SortNumber %>" />
                        <span class="tips">排序越小越靠前</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>详细内容：</dt>
                    <dd>
                        <textarea id="content" style="width:80%;height:100px;"><%=PageCategory.Content %></textarea>
                        <span class="tips">您当前输入了 <span class="word_count">0</span> 个文字</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox v52fmbx_mo">
                <dl>
                    <dt></dt>
                    <dd>
                        <input type="hidden" value="<%=PageCategory.Id %>" name="id" />
                        <input type="button" value="保存" class="submit" />
                    </dd>
                </dl>
            </div>
        </div>
    </form>

    <script src="statics/base/js/jquery1.7.2.js"></script>
    <script src="statics/base/js/jquery-extend.js"></script>
    <script src="statics/lib/jquery.serializeJSON.js"></script>
    <script type="text/javascript">
        var editor; //定义编辑器对象

        //编辑
        function editCategory() {
            var $targetdom = $('input[validate],textarea[validate]');
            if (!parent.checkInput($targetdom, 'categoryedit', null, true)) return;

            var fitem = $('#myform').serializeJSON();
            delete fitem.undefined;
            fitem.content = parent.__escape(editor.html());

            parent.confirmLayerNormal('确认修改吗？', function (index) {
                parent.layer.close(index);

                var paramdata = {
                    action: "62a06a1bb6816463218a0f20a5a340aa",
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
        };

        //初始化界面内容设置
        function setPageDefault() {
            $('select[name="parentid"]').val('<%=PageCategory.ParentId%>');
            $('select[name="sitemodel"]').val('<%=PageCategory.SiteModel%>');
        };

        $(function () {
            setPageDefault();

            //基础设置            parent.selectAllInputText($('input[type="text"]'));
                        //初始化编辑器            $('textarea[id="content"]').initEditor($('.word_count'), true, function (_e) {
                editor = _e;            });
            //编辑栏目
            $('.submit').click(editCategory);

            //...

        });
    </script></body>
</html>