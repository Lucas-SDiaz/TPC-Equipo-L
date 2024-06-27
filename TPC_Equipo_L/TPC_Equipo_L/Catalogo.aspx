

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPC_Equipo_L.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .img-thumbnail {
            width: 100%;
            height: 300px;
        }
        .custom-card-size {
            width: 250px;
            height: 300px;
        }
    </style>

    <figure class="text-center">
        <h1>CATALOGO</h1>
    </figure>
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="row row-cols-1 row-cols-md-4 g-4">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>       
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="col">
                            <div class="card">
                                <img src="<%#Eval("Imagen.Url")%>" class="img-thumbnail" alt="Alternate Text" />
                                <div class="card-body">
                                    <h5 class="card-title" style="color: black; text-align: center;"><b><%#Eval("Nombre")%></b></h5>
                                    <p class="card-text" style="color: black; text-align: center;"><%#Eval("Marca")%></p>
                                    <p class="card-text" style="color: black; text-align: center;">Stock: <%#Eval("Stock")%></p>
                                    <p class="card-text" style="color: black; text-align: center;">Precio: $ <%#Eval("Precio")%></p>
                                    <div class="d-grid gap-2">
                                    <a href="detalleProducto.aspx?id=<%#Eval("CodigoProducto")%>" class="btn btn-outline-success">Ver detalle</a>
                                        <div class="input-group">                                        
                                            <asp:Button class="btn btn-success" runat="server" type="button" Text="-" CommandName="Quitar" CommandArgument='<%#Eval("CodigoProducto")%>' OnCommand="Unnamed_Command"/>
                                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control text-center" Text="1" ReadOnly="true" />
                                            <asp:Button class="btn btn-success" runat="server" type="button" Text="+" CommandName="Agregar" CommandArgument='<%#Eval("CodigoProducto")%>' OnCommand="Unnamed_Command"/>                                          
                                        </div>
                                    <a href="carritoCompra.aspx?id=<%#Eval("CodigoProducto")%>" class="btn btn-success">Agregar al carrito</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>