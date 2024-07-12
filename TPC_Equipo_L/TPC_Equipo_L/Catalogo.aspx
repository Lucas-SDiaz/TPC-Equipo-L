<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPC_Equipo_L.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style>
		@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap');
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
		 .custom-font {
            font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
            font-size: 2em;
            font-weight: bold;
            color: #000;
         }
	</style>

	<br />
	<figure class="text-center">
		<h2 class="custom-font">CATÁLOGO</h2>
	</figure>

	<br />
	<div class="container-xxl">
		<div class="row row-cols-1 row-cols-md-4 g-4">
			<asp:Repeater runat="server" ID="repRepetidor" OnItemDataBound="repRepetidor_ItemDataBound">
				<ItemTemplate>
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
									<asp:UpdatePanel runat="server">
										<ContentTemplate>
											<div class="input-group">
												<asp:Button class="btn btn-outline-dark" runat="server" type="button" Text="-" CommandName="Quitar" CommandArgument='<%#Eval("CodigoProducto")%>' OnCommand="Unnamed_Command" Style="background-color: #99bbc2;" />
												<asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control text-center border-black" Text="1" ReadOnly="true" />
												<asp:Button class="btn btn-outline-dark" runat="server" type="button" Text="+" CommandName="Agregar" CommandArgument='<%#Eval("CodigoProducto")%>' OnCommand="Unnamed_Command" Style="background-color: #99bbc2;" />
											</div>
										</ContentTemplate>
									</asp:UpdatePanel>
									<asp:Button class="btn btn-outline-dark" Style="background-color: #99bbc2;" runat="server" type="button" Text="Agregar al carrito" CommandName="carrito" CommandArgument='<%#Eval("CodigoProducto")%>' OnCommand="agregar"  />
								</div>
							</div>
						</div>
					</div>
				</ItemTemplate>
			</asp:Repeater>
		</div>
	</div>
</asp:Content>
