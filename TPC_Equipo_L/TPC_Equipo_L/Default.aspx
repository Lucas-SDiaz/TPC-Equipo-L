<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Equipo_L.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repCategorias" runat="server">
            <ItemTemplate>
                <div class="col">
                    <a href="Catalogo.aspx?Cat=<%#Eval("Cod_Categoria") %>">
                        <div class="card h-100 text-bg-dark text-uppercase">
                            <img src=" <%#Eval("ImagenURL") %> " class="card-img" alt="">
                            <div class="card-img-overlay">
                                <h5 class="card-title fs-3"><%#Eval("Nombre") %></h5>
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
