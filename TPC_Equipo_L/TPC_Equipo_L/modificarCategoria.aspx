<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="modificarCategoria.aspx.cs" Inherits="TPC_Equipo_L.modificarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <h1 class="text-center">Modificar Categoria</h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="row m-4" style="display: flex; justify-content: space-around;">

                <div class="card col" style="max-width: 30rem; max-height: 19rem; background-color: black;">
                    <div class="mx-auto pt-4">
                        <div class="card col" style="width: 28rem;">
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
                                    <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-outline-secondary" OnClick="btnVolver_Click" runat="server" />
                                    <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-outline-success" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="card m-4 col" style="max-height: 20rem; max-width: 20rem; border: 5px solid black; padding: 0px;">
                    <div class="card-body p-1">
                        <img src="<% = url %>" class="img-fluid" style="max-width: 18rem; max-height: 18rem;" alt="" />
                    </div>
                </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="text-end p-4">
        <asp:Label Text="" ID="lblMensaje" runat="server" />
    </div>

</asp:Content>
