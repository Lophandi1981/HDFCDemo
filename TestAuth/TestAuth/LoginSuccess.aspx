<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSuccess.aspx.cs" Inherits="TestAuth.LoginSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Show() {
            document.getElementById('<%= HiddenFieldHash.ClientID %>').value = window.location.hash;
        }
    </script>
</head>
<body>
    <form id="frmLoginSuccess" runat="server">
        <hr />
        <div id="divLogin" runat="server">
            <div>
                <h2>Login Successfull</h2>
            </div>
            <hr />
            <div style="padding: 20px;">
                <asp:Button ID="btngetUserInfo" runat="server" Text="Get User Info" OnClick="btngetUserInfo_Click" OnClientClick="Show()" />
            </div>
            <br />
            <div>
                <asp:HiddenField ID="HiddenFieldHash" runat="server" Value="" />
            </div>
            <br />
            <div>
                <asp:Label ID="lblResult" runat="server" Font-Bold="true"></asp:Label>
            </div>
        </div>
        <div id="divUnAuthorized" runat="server">
             <div>
                <h2>Skillmine Auth Demo</h2>
            </div>
        </div>
    </form>
</body>
</html>
