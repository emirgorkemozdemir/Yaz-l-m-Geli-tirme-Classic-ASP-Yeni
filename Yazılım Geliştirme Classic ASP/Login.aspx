<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
      <div>
          <asp:TextBox CssClass="input-lg" ID="tboxUsername" runat="server"></asp:TextBox>
          <asp:TextBox CssClass="input-lg" ID="tboxPassword" runat="server"></asp:TextBox>
          <asp:Button ID="btnLogin" CssClass="btn btn-success" runat="server" Text="Register" OnClick="btnLogin_Click"/>
      </div>
  </form>
</body>
</html>
