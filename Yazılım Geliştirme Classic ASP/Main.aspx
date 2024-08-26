﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
</head>
<body>

    <form id="form1" runat="server">
        <asp:Button ID="btnLogout" runat="server" Text="Çıkış Yap" OnClick="btnLogout_Click" />
        <asp:TextBox ID="tboxFilter" runat="server" OnTextChanged="tboxFilter_TextChanged" AutoPostBack="true" ></asp:TextBox>
    </form>

    <table class="table table-responsive">
        <thead>
            <tr>
                <th>User ID</th>
                <th>User Name</th>
                <th>Kullanıcıyı Sil</th>
                <th>Kullanıcıyı Güncelle</th>
            </tr>
        </thead>

        <tbody>
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("UserID") %>  </td>
                        <td><%# Eval("UserName") %>  </td>
                        <td><a class="btn btn-danger" href="DeleteUser.aspx?userid=<%# Eval("UserID") %>">Sil</a></td>
                        <td><a class="btn btn-success" href="UpdateUser.aspx?userid=<%# Eval("UserID") %>&username=<%# Eval("UserName") %>">Güncelle</a></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </tbody>
    </table>

    <!-- Burayı html tablosuna dönüştürün. Tabloda thead ve tbody olsun. thead içerisinde
         başlık kısımlar UserID ve UserName. tbody içerisinde ise bunların değerleri yazsın -->

</body>
</html>
