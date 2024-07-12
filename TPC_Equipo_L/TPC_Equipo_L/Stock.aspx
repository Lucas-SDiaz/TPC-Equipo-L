<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="TPC_Equipo_L.Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .oculto{
        display: none;
    }
</style>
     <br />

<h2 class="text-center p-2">Control de Stock</h2>

<div class=" container-fluid mx-auto p-2" style="width: 75%;">
    <asp:GridView ID="dgvProductos" DataKeyNames="CodigoProducto" CssClass="table table-dark table-bordered" AutoGenerateColumns="false"   runat="server" OnSelectedIndexChanged   ="dgvProductos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Cod_Categoria" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Cod_Marca" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" HeaderStyle-BackColor="DarkGray"/>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" HeaderStyle-BackColor="DarkGray"/>
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" HeaderStyle-BackColor="DarkGray"/>
            <asp:BoundField HeaderText="Precio" DataField="Precio" HeaderStyle-BackColor="DarkGray"/>
            <asp:BoundField HeaderText="Stock" DataField="Stock" HeaderStyle-BackColor="DarkGray"/>
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" HeaderStyle-BackColor="DarkGray"/>
            <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" HeaderStyle-BackColor="DarkGray"/>
            <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderStyle-BackColor="DarkGray" ControlStyle-CssClass="btn btn-outline-warning" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Modificar" />
                
             </Columns>
    </asp:GridView>
</div>

<asp:Label ID="lblMensaje" Text="" runat="server" />
</asp:Content>
