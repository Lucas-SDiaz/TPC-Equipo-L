<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoVentas.aspx.cs" Inherits="TPC_Equipo_L.ListadoVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:GridView runat="server" ID="dgvVentas" CssClass="table table-info table-borderless table-striped" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField HeaderText="Nombre" DataField="Usuario.Nombre" />
        <asp:BoundField HeaderText="Apellido" DataField="Usuario.Apellido" />
        <asp:BoundField HeaderText="Fecha" DataField="FechaVenta" DataFormatString="{0:d}" />
        <asp:BoundField HeaderText="Precio" DataField="MontoFinal" />
        <asp:BoundField HeaderText="Envio" DataField="MetodoEnvio" />

        <asp:BoundField HeaderText="Pago" DataField="MetodoPago" />

        <asp:BoundField HeaderText="Direccion" DataField="Direccion" />

        <asp:BoundField HeaderText="Estado Compra" DataField="EstadoVenta" />

        <asp:BoundField HeaderText="Nro de Seguimiento" DataField="NumSeguimiento" />
        <asp:BoundField HeaderText="Nro de Pago" DataField="IdPago" />



    </Columns>
</asp:GridView>


</asp:Content>
