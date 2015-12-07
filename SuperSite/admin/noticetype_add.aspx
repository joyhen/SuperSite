<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="noticetype_add.aspx.cs" Inherits="SuperSite.admin.noticetype_add" %>

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
        <div class="position">简体中文：快捷导航 > <a href="noticetype.aspx">通知类型</a> > 添加类型</div>
        <div class="return"><a href="javascript:;" onclick="location.href='javascript:history.go(-1)'">&lt;&lt;返回</a></div>
    </div>
    <div class="clear"></div>

    <form id="myform">
        <div class="v52fmbx">
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>通知类别：</dt>
                    <dd>
                        <select name="category" class="ccselect">
                            <%foreach (var item in category)
                              { %>
                            <option value="<%=item %>"><%=item %></option>
                            <%} %>
                        </select>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>类型名称：</dt>
                    <dd><input name="typename" type="text" class="text nonull" validate="emptytypename" /></dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>提前通知：</dt>
                    <dd>
                        <input name="advday" type="text" class="text nonull" validate="emptyadvday" value="0" />
                        <span class="tips">（天），提前X天通知用【逗号,】区分多次通知</span>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>是否启用：</dt>
                    <dd>
                        <input name="open" type="radio" class="radio" value="1" checked="checked" />是&nbsp;&nbsp;
			            <input name="open" type="radio" class="radio" value="0" />否&nbsp;&nbsp;&nbsp;&nbsp;
                        <span class="tips">是否新窗口打开</span>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>简短描述：</dt>
                    <dd>
                        <textarea name="desc" class="textarea gen" validate="emptydesc"></textarea>
                    </dd>
                </dl>
            </div>
            <div class="v52fmbx_dlbox">
                <dl>
                    <dt>备用描述：</dt>
                    <dd>
                        <textarea name="remark" class="textarea gen"></textarea>
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
            <%--<h3 class="v52fmbx_hr metsliding" sliding="3">这是分类项的表头</h3>--%>
        </div>
    </form>

    <script type="text/javascript" src="statics/base/js/jquery1.7.2.js"></script>
    <script type="text/javascript" src="statics/lib/jquery.serializeJSON.js"></script>
    <script type="text/javascript" src="statics/base/js/app.js"></script>
    <script type="text/javascript">noticeModel.add();</script>
</body>
</html>
