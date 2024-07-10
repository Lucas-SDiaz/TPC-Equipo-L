<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoDetalleVentas.aspx.cs" Inherits="TPC_Equipo_L.ListadoDetalleVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>
        .rounded-gridview {
            border-radius: 10px;
            overflow: hidden;
            margin-top: 50px; 
        }
        .centered-table {
            margin: 20px auto; 
            max-width: 90%; 
            text-align: center; 
        }
    </style>
        <asp:GridView runat="server" ID="dgvDetalleVentas" DataKeyNames="Cod_Venta" CssClass="table table-borderless table-striped rounded-gridview" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvDetalleVentas_SelectedIndexChanged" OnRowCommand="dgvDetalleVentas_RowCommand">
    <Columns>
        <asp:BoundField HeaderText="Codigo de venta" DataField="Cod_Venta" />
        <asp:TemplateField HeaderText="Fecha de venta">
            <ItemTemplate>
                <%# Eval("FechaVenta", "{0:dd/MM/yyyy}") %>
            </ItemTemplate>
        </asp:TemplateField>        
        <asp:BoundField HeaderText="Importe" DataField="MontoFinal" />
        <asp:TemplateField HeaderText="Ver Detalle">
	        <ItemTemplate>
		        <asp:Button ID="btnVerDetalleVenta" runat="server" Text="Ver Detalle Venta" CommandName="VerDetalleVenta" CommandArgument='<%# Eval("Cod_Venta") %>' CssClass="btn btn-info" />
	        </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
