<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sitesetting.aspx.cs" Inherits="SuperSite.admin.sitesetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>站点设置</title>
    <meta http-equiv="X-Frame-Options" content="SAMEORIGIN" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文：快捷导航 > <a href="noticemsg.aspx">系统设置</a> > 站点设置</div>
        <div class="return"><a href="javascript:;" onclick="location.href='javascript:history.go(-1)'">&lt;&lt;返回</a></div>
    </div>
    <div class="clear"></div>

    <form id="myform">
        <div class="v52fmbx">
           <%--<h3 class="v52fmbx_hr metsliding" sliding="3">搜索引擎优化设置</h3>--%>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>URL分隔符：</dt>
                    <dd>
                        <input name="urlsplit" type="text" class="text nonull" value="<%=SiteInfo.UrlSplit %>" />
                        <span class="tips">优化URL,一般默认为 '-' </span>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>网站名称：</dt>
                    <dd>
                        <input name="sitename" type="text " class="text gen" value="<%=SiteInfo.SiteName %>" /> 
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>网站标题：</dt>
                    <dd>
                        <input name="sitetitle" type="text " class="text gen" value="<%=SiteInfo.SiteTitle %>" /> 
                        <span class="tips">多个关键词请用竖线|隔开，建议3到4个关键词。</span>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>网站关键词：</dt>
                    <dd>
                        <input name="sitekeywords" type="text " class="text gen" value="<%=SiteInfo.SiteKeywords %>" />
                        <span class="tips">多个关键词请用竖线|隔开，建议3到4个关键词。</span>
                    </dd>
                </dl>
            </div>
            
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>网站描述：</dt>
                    <dd>
                        <textarea name="sitedescription" class="textarea gen"><%=SiteInfo.SiteDescription %></textarea>
			            <span class="tips">100字以内</span>
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
        </div>
    </form>
    
    <script type="text/javascript" src="statics/base/js/jquery1.7.2.js"></script>
    <script src="statics/lib/jquery.serializeJSON.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.submit').click(function () {
                var paramdata = {
                    action: "3e41a0a632b028aca61c4adbd1ce520f",
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