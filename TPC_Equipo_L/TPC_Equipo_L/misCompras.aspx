<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="misCompras.aspx.cs" Inherits="TPC_Equipo_L.misCompras" %>
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
    Debe iniciar sesion o registrarse antes de continuar!
</div>
<a href="Default.aspx" class="btn btn-outline-dark">Volver</a>

<br />
<br />

<%}
    else
    {%>

    <asp:GridView runat="server" ID="dgvCompras" CssClass="table table-info table-borderless table-striped" AutoGenerateColumns="false" >
    <Columns>
       
        <asp:BoundField HeaderText="Codigo" DataField="Cod_Venta" />
        <asp:BoundField HeaderText="Fecha" DataField="FechaVenta" />
        <asp:BoundField HeaderText="Precio" DataField="MontoFinal" />
       </Columns>
</asp:GridView>




     <%   }%>


</asp:Content>
