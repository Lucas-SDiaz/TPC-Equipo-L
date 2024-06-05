<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="listarCategoria.aspx.cs" Inherits="TPC_Equipo_L.listarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .oculto {
            display: none;
        }
    </style>
    <h2 class="text-center p-2">Listado Categorias</h2>

    <div class=" container-fluid mx-auto p-2" style="width: 50%;">
        <asp:GridView ID="dgvCategoria" DataKeyNames="Cod_Categoria" CssClass="table table-dark table-bordered" OnSelectedIndexChanged="dgvCategoria_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Categoria" DataField="Cod_Categoria" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Categoria" DataField="Nombre" HeaderStyle-BackColor="DarkGray" />
                <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderStyle-BackColor="DarkGray" ControlStyle-CssClass="btn btn-outline-warning" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Modificar" />
                <asp:CommandField ShowDeleteButton="true" HeaderStyle-BackColor="DarkGray" ControlStyle-CssClass="btn btn-outline-danger" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Eliminar" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
