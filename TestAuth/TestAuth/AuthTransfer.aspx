<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthTransfer.aspx.cs" Inherits="TestAuth.AuthTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        window.onload = function () {
          
            var form = document.createElement('form');
            var hiddenFieldAuthHash = document.createElement('input');
            hiddenFieldAuthHash.setAttribute("type", "hidden");
            hiddenFieldAuthHash.setAttribute("name", "AuthHash");

            form.name = 'frmIssueManagement';
            form.method = "post";
            form.action = "IssueManagement.aspx";
            hiddenFieldAuthHash.value = window.location.hash;
            form.appendChild(hiddenFieldAuthHash);
            document.body.appendChild(form);
            form.submit();
        }

    </script>
</head>
<body>
    <form id="frmAuthTransfer" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
