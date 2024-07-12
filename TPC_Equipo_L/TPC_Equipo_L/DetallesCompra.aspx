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

	<asp:GridView runat="server" ID="dgvDetalle" DataKeyNames="Cod_Prod" CssClass="table table-info table-borderless table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvDetalle_SelectedIndexChanged1" OnRowCommand="dgvDetalle_RowCommand">
		<Columns>

			<asp:BoundField HeaderText="Producto" DataField="Nombre" />

			<asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />

			<asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUni" />

			<asp:TemplateField HeaderStyle-BackColor="DarkGray" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
				<ItemTemplate>
					<asp:LinkButton ID="btnVerDetalle" runat="server" CommandName="VerDetalle" CommandArgument='<%# Eval("Cod_Prod") %>' CssClass="btn">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-info-circle" viewBox="0 0 16 16">
					<path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
					<path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0"/>
					</svg> Detalle Producto
                </asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>

		</Columns>
	</asp:GridView>




	<%   }%>
</asp:Content>
