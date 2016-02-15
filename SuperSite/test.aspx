<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="SuperSite.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>测试页面</title>
</head>
<body>
    <p><b>Values: </b></p>
    <form id="form1" runat="server">
        <input type="text" name="name" value="John" />
        <input type="text" name="password" value="password" />
        <input type="text" name="url" value="http://ejohn.org/" />
    </form>
    <br />
    <br />
    <input type="button" value="测试" id="btnclick" />
    <script src="admin/statics/base/js/jquery1.7.2.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btnclick').click(function () {
                var t = $("input").map(function () {
                    return { id: $(this).val() };
                }).get();

                console.log(t);
            });
        });
    </script>
</body>
</html>
