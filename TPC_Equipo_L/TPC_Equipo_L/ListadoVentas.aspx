<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoVentas.aspx.cs" Inherits="TPC_Equipo_L.ListadoVentas" %>

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
    <br />

    <br />
    <asp:GridView runat="server" DataKeyNames="Cod_Venta" ID="dgvVentas" CssClass="table table-dark table-borderless table-striped rounded-gridview" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged" OnRowDataBound="dgvVentas_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Usuario.Nombre" HeaderStyle-CssClass="text-center" />
            <asp:BoundField HeaderText="Apellido" DataField="Usuario.Apellido" HeaderStyle-CssClass="text-center" />
            <asp:BoundField HeaderText="Fecha" DataField="FechaVenta" DataFormatString="{0:d}" HeaderStyle-CssClass="text-center" />
            <asp:BoundField HeaderText="Precio" DataField="MontoFinal" HeaderStyle-CssClass="text-center" />
            <asp:BoundField HeaderText="Envio" DataField="MetodoEnvio" HeaderStyle-CssClass="text-center" />

            <asp:BoundField HeaderText="Pago" DataField="MetodoPago" HeaderStyle-CssClass="text-center" />

            <asp:BoundField HeaderText="Direccion" DataField="Direccion" HeaderStyle-CssClass="text-center" />

            <asp:TemplateField HeaderText="Estado Compra" HeaderStyle-CssClass="text-center">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlEstadoCompra" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEstadoCompra_SelectedIndexChanged">
                        <%-- <asp:ListItem Text="Confirmado" Value="Confirmado"></asp:ListItem>
                    <asp:ListItem Text="Pendiente Pago" Value="Pendiente Pago"></asp:ListItem>
                    <asp:ListItem Text="En Camino" Value="En Camino"></asp:ListItem>
                    <asp:ListItem Text="Disponible Retiro" Value="Disponible Retiro"></asp:ListItem>
                    <asp:ListItem Text="Entregado" Value="Entregado"></asp:ListItem>--%>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Nro de Pago" DataField="IdPago" HeaderStyle-CssClass="text-center" />

            <asp:BoundField HeaderText="Nro de Seguimiento" DataField="NumSeguimiento" HeaderStyle-CssClass="text-center" />
            <asp:CommandField ShowSelectButton="true" SelectText="CARGAR" ItemStyle-ForeColor="White" ControlStyle-CssClass="btn" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Cargar Nro Seguimiento" />



        </Columns>



    </asp:GridView>
    <a href="dashboard.aspx" class="btn btn-outline-dark">Volver</a>
    <br />

    <br />

</asp:Content>
