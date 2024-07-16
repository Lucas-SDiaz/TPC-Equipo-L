<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="TPC_Equipo_L.FinalizarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .rounded-gridview {
            border-radius: 10px;
            overflow: hidden;
        }

        .cardb {
            margin-bottom: 100px;
            padding: 30px;
        }

        .form-check {
            margin-bottom: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <figure class="text-center">
        <h2>Descripción de su compra</h2>
    </figure>
    <br />

    <% if (Session["usuario"] == null) { %>
        <div class="alert alert-dark" role="alert">
            Debe <a href="Login.aspx">iniciar sesión</a> o <a href="Register.aspx">registrarse</a> antes de continuar!
        </div>
        <a href="carritoCompra.aspx" class="btn btn-outline-dark">Volver</a>
    <% } else { %>
        <asp:GridView runat="server" ID="dgvFinalizarCompra" CssClass="table table-info table-borderless table-striped" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Producto" DataField="Nombre" />
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                <asp:TemplateField HeaderText="Precio">
                    <ItemTemplate>
                        <%# "$ "  + Eval("Precio") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrecioFinal" runat="server" CssClass="form-control" Style="text-align: right;" BorderColor="black" BackColor="#d5e8eb"></asp:Label>

        <br />
        <div class="row">
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="cardb" style="width: 80%;">
                    <h3 style="text-align: center">Método de entrega</h3>
                    <asp:RadioButtonList ID="rblDeliveryMethod" runat="server" CssClass="form-check" AutoPostBack="true" OnSelectedIndexChanged="rblDeliveryMethod_SelectedIndexChanged">
                        <asp:ListItem Text="Retiro en el local" Value="Retiro en el local" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Envio a domicilio.">
                            Envio a domicilio.
                            <span style="font-weight: bold; text-decoration: underline; color:green">PROMOCION VIGENTE * $2500 a toda argentina *</span>
                        </asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="cardb" style="width: 80%;">
                    <h3 style="text-align: center">Método de Pago</h3>
                    <asp:RadioButtonList ID="rblPaymentMethod" runat="server" CssClass="form-check">
                        <asp:ListItem Text="Transferencia Bancaria" Value="Transferencia Bancaria" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Efectivo" Value="Efectivo"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>

        <div class="delivery-form">
            <div class="cardb">
                <h3 style="text-align: center">Detalles de domicilio</h3>
                <br />
                <div class="mb-3">
                    <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle" BackColor="#99bbc2" ID="ddlDireccion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddDireccion_SelectedIndexChanged" />
                </div>
                <div class="delivery-form2" id="deliveryForm2" style="display: none;">
                    <div class="mb-3">
                        <asp:Label ID="lblCalle" CssClass="fs-5" Text="Calle" runat="server" />
                        <asp:TextBox ID="txtCalle" CssClass="form-control" placeholder="Calle" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblNro" CssClass="fs-5" Text="Número" runat="server" />
                        <asp:TextBox ID="txtNro" CssClass="form-control" placeholder="Número" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblCP" CssClass="fs-5" Text="Código Postal" runat="server" />
                        <asp:TextBox CssClass="form-control" ID="txtCP" placeholder="Código Postal" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblPiso" CssClass="fs-5" Text="Piso" runat="server" />
                        <asp:TextBox CssClass="form-control" ID="txtPiso" placeholder="Piso" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblDepto" CssClass="fs-5" Text="Depto" runat="server" />
                        <asp:TextBox CssClass="form-control" ID="txtDepto" placeholder="Depto" runat="server" />
                    </div>
                </div>
            </div>
        </div>

        <br />
        <a href="carritoCompra.aspx" class="btn btn-outline-dark">Volver</a>
        <asp:Button ID="btnFinalizarCompra" runat="server" class="btn btn-outline-dark" Style="background-color: #99bbc2; float: right;" Text="Finalizar Compra" OnClick="btnFinalizarCompra_Click" />

        <br />

        <script type="text/javascript">
            // Función para mostrar u ocultar el formulario de domicilio
            function toggleDeliveryForm() {
                var deliveryForm = document.querySelector('.delivery-form');
                var deliveryMethod = document.querySelector('[id*="rblDeliveryMethod"] input:checked');

                if (deliveryMethod && deliveryMethod.value === "Envio a domicilio.") {
                    deliveryForm.style.display = 'block'; // Mostrar el formulario si se selecciona "Envío a domicilio"
                } else {
                    deliveryForm.style.display = 'none'; // Ocultar el formulario en otros casos
                }
            }

            // Función para mostrar u ocultar el formulario de detalles de domicilio (delivery-form2)
            function toggleDeliveryForm2() {
                var ddlDireccion = document.getElementById('<%= ddlDireccion.ClientID %>');
                var deliveryForm2 = document.getElementById('deliveryForm2');

                if (ddlDireccion.value === "0") {
                    deliveryForm2.style.display = 'block'; // Mostrar el formulario si se selecciona "0"
                } else {
                    deliveryForm2.style.display = 'none'; // Ocultar el formulario en otros casos
                }
            }

            // Llamar inicialmente para establecer el estado correcto
            document.addEventListener('DOMContentLoaded', function () {
                toggleDeliveryForm(); // Estado inicial de delivery-form
                toggleDeliveryForm2(); // Estado inicial de delivery-form2

                // Asignar eventos de cambio
                var rblDeliveryMethod = document.querySelector('[id*="rblDeliveryMethod"]');
                rblDeliveryMethod.addEventListener('change', toggleDeliveryForm);

                var ddlDireccion = document.getElementById('<%= ddlDireccion.ClientID %>');
                ddlDireccion.addEventListener('change', toggleDeliveryForm2);
            });
        </script>

    <% } %>
</asp:Content>




