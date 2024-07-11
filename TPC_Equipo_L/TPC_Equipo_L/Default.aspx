<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Equipo_L.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style>
		 .custom-font {
			font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
			font-size: 2em;
			font-weight: bold;
			color: #000;
		 }
		 @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap'); 
		 .categorybrand-custom-font {
			 font-family: 'Montserrat', sans-serif;
			 font-size: 2em;
			 color: #000;
		 }
	</style>


	<br />
	<figure class="text-center">
		<h3 class="custom-font">CATEGORÍAS</h3>
	</figure>

	<br />



	<div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
		<div class="carousel-inner">
			<asp:Repeater ID="repCategorias" runat="server">
				<ItemTemplate>

					<%# Container.ItemIndex == 0 ? "<div class='carousel-item active'>" : "<div class='carousel-item'>" %>


					<div class="card border-light mb-3">
						<div class="card-header text-center  bg-white">
							<h3 class="categorybrand-custom-font">
								<%# Eval("Nombre") %>
							</h3>
						</div>
					</div>

					<br />
					<a href='<%# "Catalogo.aspx?Cat=" + Eval("Cod_Categoria") %>'>
						<img src='<%# Eval("ImagenURL") %>' class="rounded mx-auto d-block custom-carousel-img-size" alt='<%# Eval("Nombre") %> ' onerror="this.src='https://image.freepik.com/vector-gratis/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg'">
					</a>
					</div>

				</ItemTemplate>
			</asp:Repeater>
		</div>
		<button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev" color="black">
			<span class="badge text-bg-secondary p-3" aria-hidden="true">< </span>
			<span class="visually-hidden">Anterior</span>
		</button>
		<button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next" color="black">
			<span class="badge text-bg-secondary p-3" aria-hidden="true">> </span>
			<span class="visually-hidden">Siguiente</span>
		</button>
	</div>
	<%--  --%>


	<br />
	<br />
	<br />
	<br />
	<figure class="text-center">
		<h3 class="custom-font">MARCAS</h3>
	</figure>
	<br />



	<%--  --%>
	<div id="carouselExample1" class="carousel slide " data-bs-ride="carousel">
		<div class="carousel-inner">
			<asp:Repeater ID="repMarcas" runat="server">
				<ItemTemplate>

					<%# Container.ItemIndex == 0 ? "<div class='carousel-item active'>" : "<div class='carousel-item'>" %>


					<div class="card border-light mb-3">
						<div class="card-header text-center  bg-white">
							<h3 class="categorybrand-custom-font">
								<%# Eval("Nombre") %>
							</h3>
						</div>
					</div>

					<br />
					<a href='<%# "Catalogo.aspx?Mar=" + Eval("Cod_Marca") %>'>
						<img src='<%# Eval("ImagenURL") %>' class="rounded mx-auto d-block custom-carousel-img-size" alt='<%# Eval("Nombre") %>' onerror="this.src='https://image.freepik.com/vector-gratis/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg'">
					</a>
					</div>

				</ItemTemplate>
			</asp:Repeater>
		</div>
		<button class="carousel-control-prev" type="button" data-bs-target="#carouselExample1" data-bs-slide="prev" color="black">
			<span class="badge text-bg-secondary p-3" aria-hidden="true">< </span>
			<span class="visually-hidden">Anterior</span>
		</button>
		<button class="carousel-control-next" type="button" data-bs-target="#carouselExample1" data-bs-slide="next" color="black">
			<span class="badge text-bg-secondary p-3" aria-hidden="true">> </span>
			<span class="visually-hidden">Siguiente</span>
		</button>
	</div>



	<style>
		.custom-carousel-img-size {
			width: auto;
			height: 600px;
			object-fit: cover
		}
	</style>
	<br />
</asp:Content>
