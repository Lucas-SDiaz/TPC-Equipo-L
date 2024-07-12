<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoDetalleVentas.aspx.cs" Inherits="TPC_Equipo_L.ListadoDetalleVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<br />

	<h2 class="text-center p-2">Historial de ventas</h2>

	<asp:GridView runat="server" ID="dgvDetalleVentas" DataKeyNames="Cod_Venta" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvDetalleVentas_SelectedIndexChanged" OnRowCommand="dgvDetalleVentas_RowCommand">
		<Columns>
			<asp:BoundField HeaderText="Codigo de venta" DataField="Cod_Venta" HeaderStyle-BackColor="DarkGray" />
			<asp:TemplateField HeaderText="Fecha de venta" HeaderStyle-BackColor="DarkGray">
				<ItemTemplate>
					<%# Eval("FechaVenta", "{0:dd/MM/yyyy}") %>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField HeaderText="Importe" DataField="MontoFinal" HeaderStyle-BackColor="DarkGray" />

			<asp:TemplateField HeaderStyle-BackColor="DarkGray">
				<ItemTemplate>
					<asp:LinkButton ID="btnVerDetalleVenta" runat="server" CommandName="VerDetalleVenta" CommandArgument='<%# Eval("Cod_Venta") %>' CssClass="btn" ForeColor="White">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-info-circle" viewBox="0 0 16 16">
					<path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
					<path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0"/>
					</svg>  Detalle De Compra
                </asp:LinkButton>
				</ItemTemplate>

			</asp:TemplateField>


		</Columns>
	</asp:GridView>
	<a href="dashboard.aspx" class="btn btn-outline-dark">Volver</a>
	<br />

	<br />

</asp:Content>
