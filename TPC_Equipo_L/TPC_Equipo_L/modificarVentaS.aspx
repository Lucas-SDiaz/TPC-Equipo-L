<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="modificarVentaS.aspx.cs" Inherits="TPC_Equipo_L.modificarVentaS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <br />
    <br />


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="card col text-center" style="max-width: 30rem; margin: 0 auto;">
    <div class="card-body">
        <div class="mb-2 text-center">
            <label for="txtSeguimiento" class="form-label">Nro de seguimiento</label>
        <asp:TextBox ID="txtSeguimiento" runat="server" CssClass="form-control"></asp:TextBox>
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
