<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoDetalleVentas.aspx.cs" Inherits="TPC_Equipo_L.ListadoDetalleVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />

<h2 class="text-center p-2">Historial de ventas</h2>

        <asp:GridView runat="server" ID="dgvDetalleVentas" DataKeyNames="Cod_Venta" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvDetalleVentas_SelectedIndexChanged" OnRowCommand="dgvDetalleVentas_RowCommand">
    <Columns>
        <asp:BoundField HeaderText="Codigo de venta" DataField="Cod_Venta" HeaderStyle-BackColor="DarkGray" />
        <asp:TemplateField HeaderText="Fecha de venta" HeaderStyle-BackColor="DarkGray">
            <ItemTemplate>
                <%# Eval("FechaVenta", "{0:dd/MM/yyyy}") %>
            </ItemTemplate>
        </asp:TemplateField>        
        <asp:BoundField HeaderText="Importe" DataField="MontoFinal"  HeaderStyle-BackColor="DarkGray"/>
        <asp:TemplateField HeaderText="Ver Detalle" HeaderStyle-BackColor="DarkGray">
	        <ItemTemplate>
		        <asp:Button ID="btnVerDetalleVenta" runat="server" Text="Ver Detalle Venta" CommandName="VerDetalleVenta" CommandArgument='<%# Eval("Cod_Venta") %>' CssClass="btn btn-info" />
	        </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
