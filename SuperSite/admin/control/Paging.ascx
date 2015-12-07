<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Paging.ascx.cs" Inherits="SuperSite.admin.control.Paging" %>
<%if (__showpage) {%>
<div class="box mt10 fr">
    <div class='ccpaging'>
        <a class="disabled" style="padding-right: 0px;">首页</a>
        <a class="disabled">上一页</a>

        <span class="current">1</span>
        <a href="noticetype.aspx?p=2">2</a>
        <a href="noticetype.aspx?p=3">3</a>
        <a href="noticetype.aspx?p=4">4</a>
        <a href="noticetype.aspx?p=5">5</a>
        <a href="noticetype.aspx?p=6">6</a>
        <a href="noticetype.aspx?p=2">下一页</a>
        <a href="noticetype.aspx?p=6">尾页</a>

        | 共<%=__totalcount.ToString() %>条  转到 <input type="text" maxlength="4"
            onkeyup="this.value=this.value.replace(/\D/g,'')" 
            onafterpaste="this.value=this.value.replace(/\D/g,'')" value="" />页
    </div>
</div>
<%} %>