<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="modificarVenta.aspx.cs" Inherits="TPC_Equipo_L.modificarVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="card col text-center" style="max-width: 30rem; margin: 0 auto;">
    <div class="card-body">
        <div class="mb-2 text-center">
            <label for="txtComprobante" class="form-label">Nro de pago</label>
        <asp:TextBox ID="txtComprobante" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
    </div>
</div>
        <br />
        <div class="mb-2 text-center">
        <asp:Button ID="btnModificar" runat="server"  Text="Modificar" CssClass="btn btn-outline-success" OnClick="btnModificar_Click" />
        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-outline-secondary" Text="Volver" OnClick="btnVolver_Click" />
            
           </div> 
        <br />
        <div class="mb-2 text-center">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
        <br />
    </ContentTemplate>
</asp:UpdatePanel>



</asp:Content>

<%--<div class="card col text-center" style="max-width: 30rem; margin: 0 auto;">
    <div class="card-body">
        <div class="mb-2 text-center">
            <label for="txtComprobante" class="form-label">Nro de pago</label>
            <asp:TextBox AutoPostBack="true" ID="TextBox1" CssClass="form-control" runat="server" />
            <asp:Label ID="txtInvNombre" Text="" runat="server"></asp:Label>
        </div>
    </div>
</div>
    <br />

    <div class="mb-2 text-center">
    <asp:Button Text="Volver" ID="Button1" CssClass="btn btn-outline-secondary" OnClick="btnVolver_Click" runat="server" />
    <asp:Button Text="Modificar" ID="Button2" OnClick="btnModificar_Click" CssClass="btn btn-outline-success" runat="server" />
</div>

        <div class="text-end p-4">
        <asp:Label Text="" ID="Label1" runat="server" />
    </div>--%>