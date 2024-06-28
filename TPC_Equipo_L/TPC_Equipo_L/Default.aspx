<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Equipo_L.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <asp:Repeater ID="repCategorias" runat="server">
                <itemtemplate>

                    <%# Container.ItemIndex == 0 ? "<div class='carousel-item active'>" : "<div class='carousel-item'>" %>


                    <div class="card border-light mb-3">
                        <div class="card-header text-center  bg-white">
                            <h3>
                                <%# Eval("Nombre") %>
                            </h3>
                        </div>
                    </div>

                    <br />
                    <a href='<%# "Catalogo.aspx?Cat=" + Eval("Cod_Categoria") %>'>
                        <img src='<%# Eval("ImagenURL") %>' class="rounded mx-auto d-block custom-carousel-img-size" alt='<%# Eval("Nombre") %>'>
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
    <style>
        .custom-carousel-img-size {
            width: auto;
            height: 600px;
        }
    </style>
    <br />
</asp:Content>
