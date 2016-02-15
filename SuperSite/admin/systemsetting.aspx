<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="systemsetting.aspx.cs" Inherits="SuperSite.admin.systemsetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统设置</title>
    <meta http-equiv="X-Frame-Options" content="SAMEORIGIN" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文：快捷导航 > <a href="noticemsg.aspx">系统设置</a> > 系统设置</div>
        <div class="return"><a href="javascript:;" onclick="location.href='javascript:history.go(-1)'">&lt;&lt;返回</a></div>
    </div>
    <div class="clear"></div>

    <form id="myform">
        <div class="v52fmbx">
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>站点状态：</dt>
                    <dd>
                        <select name="sitestatic" class="ccselect">
                            <option value="true" <%=SystemInfo.SiteStatic ? "selected='selected'" : "" %>>开启</option>
                            <option value="false" <%=!SystemInfo.SiteStatic ? "selected='selected'" : "" %>>关闭</option>
                        </select>                        
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>站点伪静态：</dt>
                    <dd>
                        <select name="pseudostatic" class="ccselect">
                            <option value="true" <%=SystemInfo.PseudoStatic ? "selected='selected'" : "" %>>开启</option>
                            <option value="false" <%=!SystemInfo.PseudoStatic ? "selected='selected'" : "" %>>关闭</option>
                        </select>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>登录验证码：</dt>
                    <dd>
                        <select name="loginvalidate" class="ccselect">
                            <option value="true" <%=SystemInfo.LoginValidate ? "selected='selected'" : "" %>>开启</option>
                            <option value="false" <%=!SystemInfo.LoginValidate ? "selected='selected'" : "" %>>关闭</option>
                        </select>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>登录口令：</dt>
                    <dd>
                        <select name="loginqustion" class="ccselect">
                            <option value="true" <%=SystemInfo.LoginQustion ? "selected='selected'" : "" %>>开启</option>
                            <option value="false" <%=!SystemInfo.LoginQustion ? "selected='selected'" : "" %>>关闭</option>
                        </select>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>支持多语言：</dt>
                    <dd>
                        <select name="multilanguage" class="ccselect">
                            <option value="true" <%=SystemInfo.MultiLanguage ? "selected='selected'" : "" %>>开启</option>
                            <option value="false" <%=!SystemInfo.MultiLanguage ? "selected='selected'" : "" %>>关闭</option>
                        </select>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>开启QQ登录：</dt>
                    <dd>
                        <select name="allowqqlogin" class="ccselect">
                            <option value="true" <%=SystemInfo.AllowQQLogin ? "selected='selected'" : "" %>>开启</option>
                            <option value="false" <%=!SystemInfo.AllowQQLogin ? "selected='selected'" : "" %>>关闭</option>
                        </select>
                    </dd>
                </dl>
            </div>
            
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>文件缓存时间：</dt>
                    <dd>
                        <input name="filecachetime" type="text" class="text nonull" value="<%=SystemInfo.FileCacheTime %>"
                            onkeyup="this.value=this.value.replace(/\D/g,'')" 
                            onafterpaste="this.value=this.value.replace(/\D/g,'')" />
                        <span class="tips">（分钟），默认60分钟</span>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox v52fmbx_mo">
                <dl>
                    <dt></dt>
                    <dd>
                        <input type="hidden" name="id" value="0" />
                        <input type="button" value="保存" class="submit" />
                    </dd>
                </dl>
            </div>
            <%--<h3 class="v52fmbx_hr metsliding" sliding="3">这是分类项的表头</h3>--%>
        </div>
    </form>
    
    <script type="text/javascript" src="statics/base/js/jquery1.7.2.js"></script>
    <script src="statics/lib/jquery.serializeJSON.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.submit').click(function () {
                var paramdata = {
                    action: "bcc1bbc5b26d96ad017d1b6af9b66fd3",
                    arg: $('#myform').serializeJSON()
                };
                parent.doAjaxPost(paramdata, function (_result) {
                    if (_result.success) {
                        parent.SuperSite.MsgOK('保存成功');
                    } else {
                        parent.SuperSite.MsgError(_result.msg);
                    }
                });
            });
        });
    </script>
</body>
</html>