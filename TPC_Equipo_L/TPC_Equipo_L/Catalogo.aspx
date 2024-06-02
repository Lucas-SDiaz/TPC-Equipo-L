<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPC_Equipo_L.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <figure class="text-center">
        <h1>CATALOGO</h1>
    </figure>

     <div class="row row-cols-1 row-cols-md-4 g-4">
          
        <%  
            List<string> lista = new List<string>();
            foreach(dominio.Producto producto in ListaProductos)
            {
               
        %>
            <div class="col">
                <div class="card custom-card-size">                
                    <div class="card-body">
                        <h5 class="card-title" style="color: black; text-align: center;"> <b><%: producto.Nombre %></b> </h5>
                        <%--<p class="card-text" style="color: #4675b9; text-align: center;"><%:"$" + producto.Precio %></p>                    </div>--%>
                </div>
            </div>
        <%  } %>
    </div>

</asp:Content>
