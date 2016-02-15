<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysuseredit.aspx.cs" Inherits="SuperSite.admin.sysuseredit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改用户</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文：系统设置 > <a href="sysuseradd.aspx">系统用户</a> > 修改用户</div>
        <div class="return"><a href="javascript:;" onclick="location.href='javascript:history.go(-1)'">&lt;&lt;返回</a></div>
    </div>
    <div class="clear"></div>

    <form id="myform">
        <div class="v52fmbx">

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>用户名：</dt>
                    <dd>
                        <input name="username" validate type="text" value="<%=SysUser.UserName %>" class="text nonull ccverify" />
                        <span class="tips"></span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>真实名：</dt>
                    <dd>
                        <input name="realname" validate type="text" value="<%=SysUser.RealName %>" class="text nonull ccverify" />
                        <span class="tips"></span>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>用户性别</dt>
                    <dd>
                        <select name="gender" class="ccselect">
                            <option value="-1">——请选择——</option>
                            <option value="1">男</option>
                            <option value="0">女</option>
                        </select>
                    </dd>
                </dl>
            </div>

            <div class="v52fmbx_dlbox v52fmbx_mo">
                <dl>
                    <dt></dt>
                    <dd>
                        <input type="hidden" value="<%=SysUser.Id %>" name="id" />
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

            $('select[name="gender"]').val('<%=SysUser.Gender%>');

            //修改用户
            $('.submit').click(function () {
                var $targetdom = $('input[validate],textarea[validate]');
                if (!parent.checkInput($targetdom, 'sysuseradd', null, true)) return;

                parent.confirmLayerNormal('确认提交吗？', function (index) {
                    parent.layer.close(index);

                    var paramdata = {
                        action: "b9c5781f508ed51f693e7be7d6f0404e",
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
            });

            //...

        });
    </script></body>
</html>