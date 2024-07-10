<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="misCompras.aspx.cs" Inherits="TPC_Equipo_L.misCompras" EnableEventValidation="true" %>

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

	<asp:GridView runat="server" ID="dgvCompras" DataKeyNames="Cod_Venta" CssClass="table table-info table-borderless table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCompras_SelectedIndexChanged" OnRowDataBound="dgvCompras_RowDataBound" OnRowCommand="dgvCompras_RowCommand">
		<Columns>

			<asp:BoundField HeaderText="Fecha" DataField="FechaVenta" DataFormatString="{0:d}" />
			<asp:BoundField HeaderText="Precio" DataField="MontoFinal" />
			<asp:BoundField HeaderText="Envio" DataField="MetodoEnvio" />

			<asp:BoundField HeaderText="Pago" DataField="MetodoPago" />

			<asp:BoundField HeaderText="Direccion" DataField="Direccion" />

			<asp:BoundField HeaderText="Estado Compra" DataField="EstadoVenta" />

			<asp:BoundField HeaderText="Nro de Seguimiento" DataField="NumSeguimiento" />
			<asp:BoundField HeaderText="Nro de Pago" DataField="IdPago" />
			<asp:CommandField ShowSelectButton="true" SelectText="CARGAR" HeaderStyle-BackColor="DarkGray" ControlStyle-CssClass="btn" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Cargar Comprobante" />
			<asp:TemplateField HeaderText="Ver Detalle" HeaderStyle-BackColor="DarkGray" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
				<ItemTemplate>
					<asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle" CommandName="VerDetalle" CommandArgument='<%# Eval("Cod_Venta") %>' CssClass="btn btn-info" />
				</ItemTemplate>
			</asp:TemplateField>


		</Columns>
	</asp:GridView>




	<%   }%>
</asp:Content>
