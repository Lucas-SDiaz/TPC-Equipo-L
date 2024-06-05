<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="modificarCategoria.aspx.cs" Inherits="TPC_Equipo_L.modificarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center">Modificar Categoria</h1>

    <div class="mx-auto p-2" style="width: 600px">
        <div class="card" style="width: 38rem;">
            <div class="card-body">
                <div class="mb-2">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-2">
                    <label for="txtImagen" class="form-label">Imagen</label>
                    <asp:TextBox ID="txtImagen" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-2 text-center p-2">
                    <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-outline-success" runat="server" />
                </div>
            </div>
        </div>

    </div>
    <div class="text-end p-4">
        <asp:Label Text="" ID="lblMensaje" runat="server" />
    </div>

</asp:Content>
