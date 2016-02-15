<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supersiteinfo.aspx.cs" Inherits="SuperSite.admin.supersiteinfo" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>程序配置</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文：系统设置 > 程序配置</div>
        <div class="return"><a href="javascript:;" onclick="location.href='javascript:history.go(-1)'">&lt;&lt;返回</a></div>
    </div>
    <div class="clear"></div>

    <form id="myform">
        <div class="v52fmbx">
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>程序名称：</dt>
                    <dd>
                        <input name="name" validate type="text" class="text nonull ccverify" value="<%=SuperProgramInfo.Name %>" />
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>系统版本：</dt>
                    <dd>
                        <input name="version" validate type="text" class="text nonull ccverify" value="<%=SuperProgramInfo.Name %>" />
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>操作系统：</dt>
                    <dd>
                        <input name="system" validate type="text" class="text nonull ccverify" value="<%=SuperProgramInfo.System %>" />
                    </dd>
                </dl>
            </div>
            
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>Asp.Net：</dt>
                    <dd>
                        <input name="aspnet" validate type="text" class="text " value="<%=SuperProgramInfo.AspNet %>" />
                        <span class="tips">可以为空 (模板路径) 例如:model/news/list</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>SqlServer：</dt>
                    <dd>
                        <input name="sqlserver" validate type="text" class="text " value="<%=SuperProgramInfo.SqlServer %>" />
                        <span class="tips">可以为空 (模板路径) 例如:model/news/show</span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>开发成员：</dt>
                    <dd>
                        <input name="author" validate type="text" class="text " value="<%=SuperProgramInfo.Author %>" />
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox v52fmbx_mo">
                <dl>
                    <dt></dt>
                    <dd>
                        <input type="button" value="保存" class="submit" />
                    </dd>
                </dl>
            </div>
        </div>
    </form>
   
    <script src="statics/base/js/jquery1.7.2.js"></script>
    <script src="statics/lib/jquery.serializeJSON.js"></script>
    <script type="text/javascript">
        $(function () {

            parent.selectAllInputText($('input[type="text"]'));
            $('input').attr({ 'readonly': 'readonly', 'disabled': 'disabled' });

            //系统程序配置
            $('.submit').click(function () {
                if (!parent.checkInput($('input[validate]'), 'supersiteinfo', null, true)) return;
                
                parent.confirmLayerNormal('确认提交吗？', function (index) {
                    parent.layer.close(index);

                    var paramdata = {
                        action: "ed94457b1c939234dd61c82c0b44d903",
                        arg: $('#myform').serializeJSON(),
                    };
                    parent.doAjaxPost(paramdata, function (_result) {
                        if (_result.success) {
                            location.href = 'main.html';
                        } else {
                            parent.SuperSite.MsgError(_result.msg);
                        }
                    });
                });
            });

            //...

        });
    </script></body>
</html>
