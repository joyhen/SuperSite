<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToolsPage.aspx.cs" Inherits="SuperSite.admin.ToolsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body{ font-family:Arial; font-size:14px; line-height:23px;}
        ul,li{ list-style-type:none;}
        .fl{ float:left; margin-right:10px;}
        .tb td{ background-color:#fff; padding-left:5px;}
    </style>
</head>
<body>
    <table class="tb">
        <thead>
            <tr>
                <th>操作名</th>
                <th>客户端</th>
                <th>登录校验</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in GetActionHandlerInfo) { %>
            <tr>
                <td><%=item.ActionName %></td>
                <td><%=item.ClientName %></td>
                <td><%=item.CheckLogin%></td>
            </tr>
            <%} %>
        </tbody>        
    </table>

    <hr />

    <%foreach (var item in ClassProperty)
      { %>
    <p>
        <ul>
            <li><%=item%></li>
        </ul>
    </p>
    <%} %>
    
</body>
</html>
