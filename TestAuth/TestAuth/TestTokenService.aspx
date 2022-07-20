<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTokenService.aspx.cs" Inherits="TestAuth.TestTokenService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmTokenService" runat="server">
        <div>
            <asp:Button ID="btnRedirecttoAuth" runat="server" Text="ReDirectToAuth" OnClick="btnRedirecttoAuth_Click" />
        </div>
    </form>
</body>
</html>
