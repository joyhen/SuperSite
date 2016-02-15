<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="SuperSite.admin.news" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>内容管理</title>
    <meta http-equiv="X-Frame-Options" content="SAMEORIGIN" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/newstyle.css" />
    <link href="statics/lib/jpage/css/jPages.css" rel="stylesheet" />
    <link href="statics/lib/jpage/css/animate.css" rel="stylesheet" />
</head>
<body>
    <div class="metinfotop">
        <div class="position">简体中文 > 内容管理 > <a href="content.html">内容管理</a> > <a href='news.aspx'>文章管理 </a></div>
        <div class="return"><a href="javascript:;" onclick="location.href='javascript:history.go(-1)'">&lt;&lt;返回</a></div>
    </div>
    <div class="clear"></div>

    <div class="v52fmbx_tbmax">
        <div class="v52fmbx_tbbox">

            <div class="clear"></div>

            <table cellpadding="2" cellspacing="1" class="table">
                <tr>
                    <td colspan="8" class="centle" style=" height:20px; line-height:30px; font-weight:normal; padding-left:10px;">
                        <div style="float:left;">
                            <a href="news_add.html">+新增</a>
                            <span style="font-weight:normal; color:#999; padding-left:10px;">排序数值越大越靠前</span>
                        </div>
                        <div class="formright">
                            <form method="POST" name="search" action="index.php/admin/news/index" target="_self">

                                <select name="new" id="new" onchange="changes($(this));">
                                    <option value="index.php/admin/news/index">所属栏目</option>
                                    <option value="index.php/admin/news/index?cid=45">艺术品展示</option>
                                    <option value="index.php/admin/news/index?cid=55">企业形象网站</option>
                                    <option value="index.php/admin/news/index?cid=74">品牌网站设计</option>
                                    <option value="index.php/admin/news/index?cid=96">互动专题设计</option>
                                </select>

                                <input name="keyword" type="text" class="text100" value="" />
                                <input type="submit" name="searchsubmit" value="搜索" class="bnt_pinyin" />
                            </form>
                        </div>
                    </td>
                </tr>
                <tr id="list-top">
                    <td width="30" class="list">选择</td>
                    <td width="250" class="list list_left">标题</td>
                    <td width="30" class="list">推荐</td>
                    <td width="30" class="list">置顶</td>
                    <td width="30" class="list">状态</td>
                    <td width="80" class="list">更新时间</td>
                    <td width="70" style="padding:0px; text-align:center;" class="list">访问次数</td>
                    <td width="70" class="list" style="padding:0px; text-align:center;">操作</td>
                </tr>

                <tbody id="itemContainer">
                    <tr class="mouse click">
                        <td class="list-text">
                            <input name='id[]' type='checkbox' id="id" value='30' />
                            <input name="data[id][]" type="hidden" value="30" />
                        </td>

                        <td class="list-text alignleft">&nbsp;&nbsp;<a href="show-30" title='预览：测试' target="_blank">测试</a></td>
                        <td class="list-text"><a href="index.php/admin/news/doset?act=isnice&id=30&&page=1"><img src="statics/base/images/ok_0.gif" /></a></td>
                        <td class="list-text"><a href="index.php/admin/news/doset?act=istop&id=30&&page=1"><img src="statics/base/images/ok_0.gif" /></a></td>
                        <td class="list-text"><a href="index.php/admin/news/doset?act=nostatus&id=30&&page=1"><img src="statics/base/images/ok_1.gif" /></a></td>
                        <td class="list-text color999">2014-11-27 15:40:25</td>
                        <td class="list-text color999">0</td>
                        <td class="list-text">
                            <a href="news_edit.html">编辑</a>&nbsp;&nbsp;
                            <a href="javascript:;">删除</a>
                        </td>
                    </tr>
                </tbody>
                <tr>
                    <td class="all"><input name="chkAll" type="checkbox" id="chkAll" value="checkbox" /></td>
                    <td class="all-submit" colspan="7" style="padding:5px;">

                        <input type='submit' value='删除' class="submit li-submit" />
                        
                        <div class="li-submit">
                            <select name="cid" id="is_move">
                                <option value="">移动至...</option>
                                <option value="45">艺术品展示</option>
                                <option value="55">企业形象网站</option>
                                <option value="74">品牌网站设计</option>
                                <option value="96">互动专题设计</option>
                            </select>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="8" class="page_list">
                        <div class="holder"></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script src="statics/base/js/jquery1.7.2.js"></script>
    <script src="statics/lib/jpage/jPages.min.js"></script>
    <script type="text/javascript">
        $(function () {

            $("div.holder").jPages({
                containerID: "itemContainer"
            });

        });
    </script>
</body>
</html>
