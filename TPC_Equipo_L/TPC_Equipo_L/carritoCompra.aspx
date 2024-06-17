<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="carritoCompra.aspx.cs" Inherits="TPC_Equipo_L.carritoCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <figure class="text-center">
        <h1>CARRITO</h1>
    </figure>

    <style>
        .oculto {
            display: none;
        }
    </style>


   <asp:GridView runat="server" ID="dgvCarrito" CssClass="table table-info table-borderless table-striped" AutoGenerateColumns="false" DataKeyNames="CodigoProducto" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged">
    <Columns>
        <asp:BoundField HeaderText="Categoria" DataField="Categoria.Cod_Categoria" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
        <asp:BoundField HeaderText="Marca" DataField="Marca.Cod_Marca" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" HeaderStyle-BackColor="DarkGray" />
        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
        <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
        <asp:TemplateField HeaderText="&nbsp; &nbsp; Cantidad">
            <ItemTemplate>
                <div class="d-flex  align-items-center">
                    <asp:Button ID="btnRestar" runat="server" Text="-" Class="btn" style="color:red" OnClick="RestarCantidad_Click" CommandArgument='<%# Container.DataItemIndex %>' />
                    <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad") %>' Width="50px" CssClass="form-control text-center" ReadOnly="true" />
                    <asp:Button ID="btnSumar" runat="server" Text="+" Class="btn" style="color:green" OnClick="SumarCantidad_Click" CommandArgument='<%# Container.DataItemIndex %>' />
                </div>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Precio" DataField="Precio" />
        <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
        <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" />
        <asp:CommandField ShowSelectButton="true" SelectText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Eliminar" ControlStyle-CssClass="btn btn-outline-danger btn-sm" />
    </Columns>
</asp:GridView>

    <asp:Label ID="lblPrecioTotal" runat="server" CssClass="form-control"  style="text-align: right;" BorderColor="black"   BackColor="#d5e8eb"></asp:Label>

    <br />
    <a href="Catalogo.aspx" class="btn btn-outline-dark">Volver</a>
    <a href="#" class="btn btn-outline-success" style="float: right;">Finalizar compra</a>



</asp:Content>
