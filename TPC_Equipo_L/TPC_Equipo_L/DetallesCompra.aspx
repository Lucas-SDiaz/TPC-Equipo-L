<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetallesCompra.aspx.cs" Inherits="TPC_Equipo_L.DetallesCompra" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<br />
	<figure class="text-center">
		<h1>MIS COMPRAS</h1>
	</figure>

	<br />

	<%if (Session["usuario"] == null)
		{

	%>


	<div class="alert alert-dark" role="alert">
		Debe <a href="Login.aspx">iniciar sesion</a> o <a href="Register.aspx">registrarse</a> antes de continuar!

	</div>
	<a href="Default.aspx" class="btn btn-outline-dark">Volver</a>

	<br />
	<br />

	<%}
		else
		{%>

	<asp:GridView runat="server" ID="dgvDetalle" DataKeyNames="Cod_Venta" CssClass="table table-info table-borderless table-striped" AutoGenerateColumns="false">
		<Columns>

			<asp:BoundField HeaderText="Producto" DataField="Nombre" />

			<asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />

			<asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUni" />

		</Columns>
	</asp:GridView>




	<%   }%>
</asp:Content>
