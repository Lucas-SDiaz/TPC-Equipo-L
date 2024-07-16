<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="agregarImagen.aspx.cs" Inherits="TPC_Equipo_L.agregarImagen" %>
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
            <label for="txtImagen" class="form-label">Url de Imagen</label>
        <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
    </div>
</div>
        <br />
        <div class="mb-2 text-center">
            
        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-outline-secondary" Text="Volver" OnClick="btnVolver_Click" />
        <asp:Button ID="btnModificar" runat="server"  Text="Modificar" CssClass="btn btn-outline-success" OnClick="btnModificar_Click" />
            
           </div> 
        <br />
        <div class="mb-2 text-center">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
        <br />
    </ContentTemplate>
</asp:UpdatePanel>




</asp:Content>
