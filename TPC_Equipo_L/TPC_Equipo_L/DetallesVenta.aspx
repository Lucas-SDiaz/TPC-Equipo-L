<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DetallesVenta.aspx.cs" Inherits="TPC_Equipo_L.DetallesVenta" %>
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
	<%if (Session["usuario"] == null)
		{

	%>


	<h4>No tiene permiso para acceder </h4>
	<a href="Default.aspx" class="btn btn-outline-dark">Volver</a>
	<br />
	

	<%}
		else
		{%>
			<br />
			<asp:GridView runat="server" ID="dgvDetalleVenta" DataKeyNames="Cod_Venta" CssClass="table table-borderless table-striped rounded-gridview" AutoGenerateColumns="false">
				<Columns>

					<asp:BoundField HeaderText="Codigo de producto" DataField="Cod_Prod" />
					<asp:BoundField HeaderText="Producto" DataField="Nombre" />
					<asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
					<asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUni" />

				</Columns>
			</asp:GridView>
	<%   }%>
</asp:Content>
