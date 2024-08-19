<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox CssClass="input-lg" ID="tboxUsername" runat="server"></asp:TextBox>
            <asp:TextBox CssClass="input-lg" ID="tboxPassword" runat="server"></asp:TextBox>
            <asp:Button ID="btnRegister" CssClass="btn btn-success" runat="server" Text="Register" OnClick="btnRegister_Click"/>
        </div>
    </form>
</body>
</html>
