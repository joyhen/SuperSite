<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="maintop.ascx.cs" Inherits="SuperSite.admin.control.maintop" %>
<%@ Register Src="~/admin/control/langlabel.ascx" TagPrefix="cc" TagName="label" %>

<div class="topnbox">
    <div class="floatr">
        <div class="top-r-box">
            <div class="top-right-boxr">
                <div class="top-r-t">
                    <ol class="rnav">
                        <li class="list"><cc:label runat="server" ID="hello" />
                            <a href="sysuseredit.aspx?id=<%=CurrentUser.Id %>" target="main" class='tui'><%=CurrentUser.RealName %></a>
                        </li>
                        <li class="line">|</li>
                        <li class="list">
                            <a target="_top" href="javascript:;" id="outhome" class='tui'><cc:label runat="server" ID="quite" /></a>
                        </li>
                        <li class="line">|</li>
                        <li class="list"><a href="javascript:;" id="kzqie"><cc:label runat="server" ID="narrow" /></a></li>
                        <li class="line">|</li>
                        <li class="list"><a href="javascript:;" id="language"><cc:label runat="server" ID="lang" /></a></li>
                        <li id="langcig" class="list langli">
                            <a id="cache" href="#"><cc:label runat="server" ID="ccache" /></a>
                            <span>|</span>
                            <a href="javascript:;" target="_blank"><cc:label runat="server" ID="bindqq" /></a>
                        </li>
                    </ol>
                    <div class="clear"></div>
                </div>
            </div>
            <div class="nav">
                <ul id="topnav">
                    <li id="metnav_1" class="list">
                        <a href="javascript:;" id="nav_1" class="onnav" hidefocus="true">
                            <span class="c1"></span>
                            <cc:label runat="server" ID="navigation" />
                        </a>
                    </li>
                    <li id="metnav_10" class="list">
                        <a href="javascript:;" id="nav_10" hidefocus="true">
                            <span class="c2"></span>
                            <cc:label runat="server" ID="content" />
                        </a>
                    </li>
                    <%--<li id="metnav_37" class="list">
                        <a href="javascript:;" id="nav_37" hidefocus="true">
                            <span class="c3"></span>
                            <cc:label runat="server" ID="plugin" />
                        </a>
                    </li>
                    <li id="metnav_12" class="list">
                        <a href="javascript:;" id="nav_12" hidefocus="true">
                            <span class="c4"></span>
                            <cc:label runat="server" ID="statistics" />
                        </a>
                    </li>--%>
                    <li id="metnav_20" class="list">
                        <a href="javascript:;" id="nav_20" hidefocus="true">
                            <span class="c5"></span>
                            <cc:label runat="server" ID="setting" />
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="floatl">
        <a href="http://www.id124.com" target="_blank" hidefocus="true" id="met_logo">
            <img src="statics/base/images/logoen.gif" alt="超级网站管理平台" title="超级网站管理平台" />
        </a>
    </div>
</div>
