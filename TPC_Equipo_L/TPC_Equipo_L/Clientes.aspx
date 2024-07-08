<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_Equipo_L.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .rounded-gridview {
            border-radius: 10px;
            overflow: hidden;
            margin-top: 50px; 
        }
        .centered-table {
            margin: 20px auto; 
            max-width: 90%; 
            text-align: center; 
        }
    </style>
        <asp:GridView runat="server" ID="dgvClientes" CssClass="table table-borderless table-striped rounded-gridview" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField HeaderText="Apellido" DataField="Usuario.Apellido" />
        <asp:BoundField HeaderText="Nombre" DataField="Usuario.Nombre" />
        <asp:BoundField HeaderText="Email" DataField="Usuario.Correo" />
        <asp:BoundField HeaderText="Cantidad de compras" DataField="Cod_Venta" />
        
    </Columns>
</asp:GridView>
</asp:Content>
