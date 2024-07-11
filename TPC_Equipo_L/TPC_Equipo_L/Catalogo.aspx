<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPC_Equipo_L.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style>
		.img-thumbnail {
			width: 100%;
			height: 300px;
			border: hidden
		}

		.custom-card-size {
			width: 250px;
			height: 300px;
		}

		.border-black {
			border: 1px solid black;
		}
	</style>

	<br />
	<figure class="text-center">
		<h1>CATALOGO</h1>
	</figure>

	<br />
	<div class="container-xxl">
		<div class="row row-cols-1 row-cols-md-4 g-4">
			<asp:Repeater runat="server" ID="repRepetidor" OnItemDataBound="repRepetidor_ItemDataBound">
				<ItemTemplate>
					<asp:UpdatePanel runat="server">
						<ContentTemplate>
							<div class="col">
								<div class="card border-black">
									<asp:Image ID="imgProducto" runat="server" CssClass="img-thumbnail" />
									<div class="card-body">
										<h5 class="card-title" style="color: black; text-align: center;"><b><%#Eval("Nombre")%></b></h5>
										<p class="card-text" style="color: black; text-align: center;"><%#Eval("Marca")%></p>
										<p class="card-text" style="color: black; text-align: center;">Stock: <%#Eval("Stock")%></p>
										<p class="card-text" style="color: black; text-align: center;">Precio: $ <%#Eval("Precio")%></p>
										<div class="d-grid gap-2">
											<a href="detalleProducto.aspx?id=<%#Eval("CodigoProducto")%>" class="btn btn-light border-black">Ver detalle</a>
											<div class="input-group">
												<asp:Button class="btn btn-outline-dark" runat="server" type="button" Text="-" CommandName="Quitar" CommandArgument='<%#Eval("CodigoProducto")%>' OnCommand="Unnamed_Command" Style="background-color: #99bbc2;" />
												<asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control text-center border-black" Text="1" ReadOnly="true" />
												<asp:Button class="btn btn-outline-dark" runat="server" type="button" Text="+" CommandName="Agregar" CommandArgument='<%#Eval("CodigoProducto")%>' OnCommand="Unnamed_Command" Style="background-color: #99bbc2;" />

											</div>
											<%--<a href="carritoCompra.aspx?id=<%#Eval("CodigoProducto")%>" class="btn btn-success">Agregar al carrito</a>--%>
											<asp:Button class="btn btn-outline-dark" runat="server" type="button" Text="Agregar al carrito" CommandName="carrito" CommandArgument='<%#Eval("CodigoProducto")%>' OnCommand="agregar" Style="background-color: #99bbc2;" />

										</div>
									</div>
								</div>
							</div>
						</ContentTemplate>
					</asp:UpdatePanel>
				</ItemTemplate>
			</asp:Repeater>
		</div>
	</div>
</asp:Content>
