<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="TPC_Equipo_L.FinalizarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .rounded-gridview {
            border-radius: 10px; 
            overflow: hidden;
        }
        .card {
            margin-bottom: 100px; 
            padding: 30px; 
        }
        .form-check {
            margin-bottom: 5px; 
        }
    </style>
<h2> Descripcion de su compra</h2><br />
    <asp:GridView runat="server" ID="dgvFinalizarCompra" CssClass="table table-borderless table-striped rounded-gridview" AutoGenerateColumns="false">
        <Columns>                    
            <asp:BoundField HeaderText="Producto" DataField="Nombre" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad"/>
            <asp:TemplateField HeaderText="Precio">
            <ItemTemplate>
                <%# "$ "  + Eval("Precio") %>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblPrecioFinal" runat="server" CssClass="form-control"  style="text-align: right;" BorderColor="black"   BackColor="#d5e8eb"></asp:Label>
    <br />
    <div class="row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <div class="card" style="width: 80%;">
                <h3 style="text-align: center"> Metodo de entrega </h3>
                <asp:RadioButtonList ID="rblDeliveryMethod" runat="server" CssClass="form-check">
                    <asp:ListItem Text="Retirar en local" Value="Retirar en local" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Coordinar con vendedor" Value="Coordinar con vendedor"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="card" style="width: 80%;">                
                <h3 style="text-align: center"> Metodo de Pago </h3>
                <asp:RadioButtonList ID="rblPaymentMethod" runat="server" CssClass="form-check">
                    <asp:ListItem Text="Transferencia Bancaria" Value="Transferencia Bancaria" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Coordinar con vendedor" Value="Coordinar con vendedor"></asp:ListItem>
                </asp:RadioButtonList>
                </div>
            </div>
        </div>
    <br />

    <a href="carritoCompra.aspx" class="btn btn-outline-dark">Volver</a>
    <asp:Button ID="btnFinalizarCompra" runat="server" CssClass="btn btn-success" Text="Finalizar Compra" OnClick="btnFinalizarCompra_Click"/>
    <br />
</asp:Content>
          

