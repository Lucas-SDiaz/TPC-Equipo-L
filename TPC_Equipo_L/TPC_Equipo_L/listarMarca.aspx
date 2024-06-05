<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="listarMarca.aspx.cs" Inherits="TPC_Equipo_L.listarMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .oculto {
            display: none;
        }
    </style>
    <h2 class="text-center p-2">Listado Marcas</h2>

    <div class=" container-fluid mx-auto p-2" style="width: 50%;">
        <asp:GridView ID="dgvMarca" DataKeyNames="Cod_Marca" CssClass="table table-dark table-bordered" OnSelectedIndexChanged="dgvMarca_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Marca" DataField="Cod_Marca" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Marca" DataField="Nombre" HeaderStyle-BackColor="DarkGray" />
                <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderStyle-BackColor="DarkGray" ControlStyle-CssClass="btn btn-outline-warning" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Modificar" />
                <asp:CommandField ShowDeleteButton="true" HeaderStyle-BackColor="DarkGray" ControlStyle-CssClass="btn btn-outline-danger" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Eliminar" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
