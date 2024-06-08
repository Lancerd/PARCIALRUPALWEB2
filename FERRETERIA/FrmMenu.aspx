<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmMenu.aspx.cs" Inherits="FERRETERIA.FrmMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
        <style type="text/css">
            body {
                background-image: url('rsc/fondo.jpg'); 
                background-size: cover; 
                background-repeat: no-repeat; 
            }
            #form1 {
                background-color: rgba(255, 255, 255, 0.4); /* Color de fondo semi-transparente */
                padding: 20px;
                border-radius: 10px;
            }
        </style>
    </head>
    <body class="d-flex justify-content-center align-items-center" style="min-height: 100vh;">
        <div class="container">
            <h1 class="text-center">
                FERRETERIA SAMIR
            </h1>
            <form id="form1" runat="server" class="mx-auto">
                <div class="flex-row">
                    <table class="table table-bordered" style="border-color: transparent;">
                        <tr>
                            <td class="text-center">
                                <asp:Button ID="BtnRProductos" runat="server" Text="Registro de productos" CssClass="btn btn-primary" OnClick="BtnRProductos_Click" />
                            </td>
                            <td class="text-center">
                                <asp:Button ID="BtnGPedidos" runat="server" Text="Gestión de pedidos" CssClass="btn btn-primary" OnClick="BtnGPedidos_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center">
                                <asp:Button ID="BtnGInventario" runat="server" Text="Gestion de inventarios" CssClass="btn btn-primary" OnClick="BtnGInventario_Click" />
                            </td>
                            <td class="text-center">
                                <asp:Button ID="BtnGVentas" runat="server" Text="Gestion de ventas" CssClass="btn btn-primary" OnClick="BtnGVentas_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </form>
        </div>
    </body>
</html>
