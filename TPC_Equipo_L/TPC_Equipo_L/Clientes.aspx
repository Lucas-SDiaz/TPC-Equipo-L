<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_Equipo_L.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<br />

	<h2 class="text-center p-2">Listado clientes</h2>

	<asp:GridView runat="server" ID="dgvClientes" CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
		<Columns>
			<asp:BoundField HeaderText="Apellido" DataField="Usuario.Apellido" HeaderStyle-BackColor="DarkGray" />
			<asp:BoundField HeaderText="Nombre" DataField="Usuario.Nombre" HeaderStyle-BackColor="DarkGray" />
			<asp:BoundField HeaderText="Telefono" DataField="Usuario.Telefono" HeaderStyle-BackColor="DarkGray" />
			<asp:BoundField HeaderText="Email" DataField="Usuario.Correo" HeaderStyle-BackColor="DarkGray" />
			<asp:BoundField HeaderText="Cantidad de compras" DataField="Cod_Venta" HeaderStyle-BackColor="DarkGray" />

		</Columns>
	</asp:GridView>
	<a href="dashboard.aspx" class="btn btn-outline-dark">Volver</a>
	<br />

	<br />
</asp:Content>
