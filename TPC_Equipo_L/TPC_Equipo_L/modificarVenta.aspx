<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="modificarVenta.aspx.cs" Inherits="TPC_Equipo_L.modificarVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="card col text-center" style="max-width: 30rem; margin: 0 auto;">
    <div class="card-body">
        <div class="mb-2 text-center">
            <label for="txtComprobante" class="form-label">Nro de pago</label>
            <asp:TextBox AutoPostBack="true" ID="txtComprobante" CssClass="form-control" runat="server" />
            <asp:Label ID="txtInvNombre" Text="" runat="server"></asp:Label>
        </div>
    </div>
</div>
    <br />

    <div class="mb-2 text-center">
    <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-outline-secondary" OnClick="btnVolver_Click" runat="server" />
    <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-outline-success" runat="server" />
</div>

        <div class="text-end p-4">
        <asp:Label Text="" ID="lblMensaje" runat="server" />
    </div>
</asp:Content>
