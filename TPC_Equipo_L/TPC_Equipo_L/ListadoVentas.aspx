<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoVentas.aspx.cs" Inherits="TPC_Equipo_L.ListadoVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br />

<h2 class="text-center p-2">Pedidos actuales</h2>

    <asp:GridView runat="server" DataKeyNames="Cod_Venta" ID="dgvVentas" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged" OnRowDataBound="dgvVentas_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Usuario.Nombre"  HeaderStyle-BackColor="DarkGray" />
            <asp:BoundField HeaderText="Apellido" DataField="Usuario.Apellido"  HeaderStyle-BackColor="DarkGray" />
            <asp:BoundField HeaderText="Fecha" DataField="FechaVenta" DataFormatString="{0:d}"  HeaderStyle-BackColor="DarkGray" />
            <asp:BoundField HeaderText="Precio" DataField="MontoFinal"  HeaderStyle-BackColor="DarkGray" />
            <asp:BoundField HeaderText="Envio" DataField="MetodoEnvio"  HeaderStyle-BackColor="DarkGray" />

            <asp:BoundField HeaderText="Pago" DataField="MetodoPago"  HeaderStyle-BackColor="DarkGray" />

            <asp:BoundField HeaderText="Direccion" DataField="Direccion"  HeaderStyle-BackColor="DarkGray" />

            <asp:TemplateField HeaderText="Estado Compra" HeaderStyle-BackColor="DarkGray" >
                <ItemTemplate>
                    <asp:DropDownList ID="ddlEstadoCompra" runat="server"  CssClass="btn btn-secondary btn-sm dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlEstadoCompra_SelectedIndexChanged">
                        <%-- <asp:ListItem Text="Confirmado" Value="Confirmado"></asp:ListItem>
                    <asp:ListItem Text="Pendiente Pago" Value="Pendiente Pago"></asp:ListItem>
                    <asp:ListItem Text="En Camino" Value="En Camino"></asp:ListItem>
                    <asp:ListItem Text="Disponible Retiro" Value="Disponible Retiro"></asp:ListItem>
                    <asp:ListItem Text="Entregado" Value="Entregado"></asp:ListItem>--%>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Nro de Pago" DataField="IdPago"  HeaderStyle-BackColor="DarkGray" />

            <asp:BoundField HeaderText="Nro de Seguimiento" DataField="NumSeguimiento"  HeaderStyle-BackColor="DarkGray" />
            <asp:CommandField ShowSelectButton="true" SelectText="CARGAR" ItemStyle-ForeColor="White" ControlStyle-CssClass="btn" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Cargar Nro Seguimiento" HeaderStyle-BackColor="DarkGray" />



        </Columns>



    </asp:GridView>
    <a href="dashboard.aspx" class="btn btn-outline-dark">Volver</a>
    <br />

    <br />

</asp:Content>
