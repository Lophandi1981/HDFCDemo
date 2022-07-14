<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TestAuth.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login-HDFC</title>
</head>
<body>
    <form id="frmHome" runat="server">
        <div>
            <asp:Button ID="btnRedirect" runat="server" Text="Redirect to Auth" OnClick="btnRedirect_Click" />
        </div>
    </form>
</body>
</html>
