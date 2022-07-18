<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueManagement.aspx.cs" Inherits="TestAuth.IssueManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HDFC - Issue Management</title>
</head>
<body>
    <form id="frmIssueManagement" runat="server">
        <div>
            <hr />
            <h2>Issue Management</h2>
            <hr />
            <br />
            <h2 id="h2UserInfo" runat="server" visible="false">User Information</h2>
            <h2 id="h2APIError" runat="server" visible="false">API Error</h2>
            <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
