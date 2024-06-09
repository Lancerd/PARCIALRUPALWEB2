﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmGVentas.aspx.cs" Inherits="FERRETERIA.FrmGVentas" %>

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
                background-color: rgba(255, 255, 255, 0.4);
                padding: 20px;
                border-radius: 10px;
            }

            .styled-label {
                font-size: 13px;
                color: black;
                font-weight: bold;
                text-transform: uppercase;
                letter-spacing: 1px;
            }

            .rounded-textbox {
                border-radius: 10px;
                border: 1px solid #ced4da;
                padding: 8px;
                width: 100%;
            }

            table {
                margin: auto; 
                position: relative;
            }

            tr, td {
                text-align: center; 
                position: relative;
            }

            .button-container {
                position: relative;
                top: 10px;
            }

            .button-container button {
                margin: 0 5px;
            }
        </style>
</head>
    <body class="d-flex justify-content-center align-items-center" style="min-height: 100vh;">
        <div class="container">
                <h1 class="text-center">
                    VENTAS
                </h1>
            <form id="form1" runat="server" class="mx-auto">
                <div class="d-flex">
                    <div class="col">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="LblClinte" runat="server" Text="CLIENTE" CssClass="styled-label"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="CmbCliente" runat="server" CssClass="rounded-textbox" AutoPostBack="true" OnSelectedIndexChanged="CmbCliente_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="LblNFactura" runat="server" Text="ID VENTA" CssClass="styled-label"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="CmbFactura" runat="server" CssClass="rounded-textbox"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="text-center button-container">
                                    <asp:Button ID="BtnBuscar" runat="server" Text="BUSCAR" CssClass="btn btn-primary" OnClick="BtnBuscar_Click" />
                                    <asp:Button ID="BtnAgregar" runat="server" Text="AGREGAR" CssClass="btn btn-primary" OnClick="BtnAgregar_Click" />
                                    <asp:Button ID="BtnActualizar" runat="server" Text="ACTUALIZAR" CssClass="btn btn-dark" OnClick="BtnActualizar_Click" />
                                    <asp:Button ID="BtnEliminar" runat="server" Text="ELIMINAR" CssClass="btn btn-danger" OnClick="BtnEliminar_Click" />
                                    <asp:Button ID="BtnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="BtnVolver_Click" />
                                </td>
                            </tr>
                        
                            <tr>
                            
                                <td colspan="6">
                                    <br />
                                    <asp:GridView ID="DgvProductos" runat="server" OnRowDataBound="DgvProductos_RowDataBound"></asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </form>
        </div>
    </body>
</html>