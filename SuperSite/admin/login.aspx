<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SuperSite.admin.login" %>
<%@ Register Src="~/admin/control/langlabel.ascx" TagPrefix="cc" TagName="label" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>后台登录 -企业网站管理系统</title>
    <meta content="企业网站管理系统后台登录" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="statics/base/css/metinfo.css" />
    <style>
        html, body {
            background: #fbfbfb;
        }

        #code.vcode {
            width: 85px;
        }

        .login-min {
            padding: 0;
        }

        .tipmsg {
            width: 330px;
            margin: 0px auto 0px;
            padding-left: 270px;
            color: #ff0000;
        }
    </style>
</head>
<body id="login">
    <div class="tipmsg">&nbsp;</div>
    <div class="login-min">
        <div class="login-left">
            <div style="border-right: 1px solid #fff; padding: 0px 0px 20px;">
                <a href="http://www.id124.com" style="font-size: 0px;" target="_blank" title="id124" class="img">
                    <img src="statics/base/images/login-logo.jpg" alt="id124" title="id124" />
                </a>
                <cc:label runat="server" ID="des" />
                <%--<p>
                    <a href="#">
                        <img src="statics/base/images/login.gif" title="一键登录后台" />
                    </a>
                </p>--%>
            </div>
        </div>
        <div class="login-right">
            <h1 class="login-title"><%--管理员登录--%></h1>
            <div>
                <form id="myform">
                    <p>
                        <cc:label runat="server" ID="username" />
                        <input type="text" class="text" name="name" autocomplete="off" validate="emptyaccount" />
                    </p>
                    <p>
                        <cc:label runat="server" ID="pwd" />
                        <input type="password" class="text" name="pwd" validate="emptypassword" />
                    </p>
                    <%if(SystemInfo.LoginValidate){ %>
                    <p class="login-code">
                        <cc:label runat="server" ID="vcode" />
                        <input name="code" type="text" class="text vcode" id="code" maxlength="4" autocomplete="off" validate="emptyvalidatecode" />
                        <img id="imgcode" align="absbottom" src="control/validatecode.ashx" style="cursor: pointer;" title="点击刷新验证码" />
                    </p>
                    <%} %>
                    <p class="login-submit">
                        <input type="button" id="btnlogin" value="登录" />
                    </p>
                </form>
            </div>
        </div>
        <div class="clear"></div>
    </div>
    <%=SystemCopyRight() %>
    
    <script type="text/javascript" src="statics/base/js/jquery1.7.2.js"></script>
    <script type="text/javascript" src="statics/base/js/lang/message-lang-<%=CurrentLanguage.ToString() %>.js"></script>
    <script type="text/javascript" src="statics/base/js/common.js"></script>
    <script type="text/javascript" src="statics/base/js/app.login.js"></script>
</body>
</html>
