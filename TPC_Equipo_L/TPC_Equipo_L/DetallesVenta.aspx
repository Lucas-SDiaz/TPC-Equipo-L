<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DetallesVenta.aspx.cs" Inherits="TPC_Equipo_L.DetallesVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<br />

	<h2 class="text-center p-2">Detalle de venta</h2>


	<%if (Session["usuario"] == null)
		{

	%>


	<h4 class="text-center p-2">No tiene permiso para acceder </h4>
	<figure class="text-center">

		<br />
		<a href="Default.aspx" class="btn btn-outline-dark">Volver</a>
	</figure>
	<br />


	<%}
		else
		{%>
	<br />
	<asp:GridView runat="server" ID="dgvDetalleVenta" DataKeyNames="Cod_Venta" CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
		<Columns>

			<asp:BoundField HeaderText="Codigo de producto" DataField="Cod_Prod" HeaderStyle-BackColor="DarkGray" />
			<asp:BoundField HeaderText="Producto" DataField="Nombre" HeaderStyle-BackColor="DarkGray" />
			<asp:BoundField HeaderText="Cantidad" DataField="Cantidad" HeaderStyle-BackColor="DarkGray" />
			<asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUni" HeaderStyle-BackColor="DarkGray" />

		</Columns>
	</asp:GridView>
	<a href="ListadoDetalleVentas.aspx" class="btn btn-outline-dark">Volver</a>
	<br />

	<br />
	<%   }%>
</asp:Content>
