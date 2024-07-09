<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoVentas.aspx.cs" Inherits="TPC_Equipo_L.ListadoVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    
    <br />
    <asp:GridView runat="server" DataKeyNames="Cod_Venta" ID="dgvVentas" CssClass="table table-primary table-borderless table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged" OnRowDataBound="dgvVentas_RowDataBound">
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
        <asp:CommandField ShowSelectButton="true" SelectText="CARGAR" HeaderStyle-BackColor="DarkGray" ControlStyle-CssClass="btn" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Cargar Nro Seguimiento" />
             


    </Columns>
</asp:GridView>


</asp:Content>
