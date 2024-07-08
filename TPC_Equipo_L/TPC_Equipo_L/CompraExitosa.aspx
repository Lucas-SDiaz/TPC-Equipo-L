<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompraExitosa.aspx.cs" Inherits="TPC_Equipo_L.CompraExitosa" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Compra exitosa!</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .header {
            background-color: green;
            color: white;
            padding: 40px 20px;
            text-align: center;
        }

        .card-container {
            margin-top: 20px;
        }

        .card-custom {
            margin: 10px;
            border-radius: 15px;
            height: 200px;
            border: 2px solid black;
        }

        .card-horizontal {
            margin: 10px;
            border-radius: 15px;
            height: 200px;
            width: 100%;
            border: 2px solid black;
        }

        .button-container {
            text-align: center;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="header">
            <h1>Felicitaciones! Ya realizaste tu compra! 😎🎉</h1>
        </div>

        <div class="container card-container">
            <div class="card card-horizontal">
                <div class="card-body">
                    <h5 class="card-title">Resumen de la Compra</h5>
                    <p class="card-text">
                        <% int cant = 0;
                            System.Data.SqlTypes.SqlMoney monto = 0;
                            List<dominio.Producto> carrito = (List<dominio.Producto>)Session["carrito"];
                            Session.Add("carrito", carrito);
                            foreach (dominio.Producto producto in carrito)
                            {
                                cant += producto.Cantidad;

                            }
                            monto += (System.Data.SqlTypes.SqlMoney)Session["precioTotal"];
                        %>
                        Productos: <%= cant.ToString() %><br />
                        Total: $ <%= monto.ToString() %><br />
                        Fecha de Compra: <%= DateTime.Now.ToString("d") %><br />
                        Hora: <%= DateTime.Now.ToString("t") %>
                    </p>
                </div>
            </div>
            <%if (Session["metodoPago"].ToString() == "Efectivo" && Session["metodoEntrega"].ToString() == "Envio a domicilio.")
                {%>
            <div class="card card-horizontal">
                <div class="card-body">
                    <h5 class="card-title">Datos de contacto</h5>
                    <p class="card-text">
                        Whatsapp: 2246438721<br />
                        Instagram: @Supermercado<br />
                    </p>
                </div>
            </div>
            <%}
                else
                { %>
            <div class="row">
                <%if (Session["metodoEntrega"].ToString() == "Retiro en el local")
                    { %>
                <div class="col-md-6">
                    <div class="card card-custom">
                        <div class="card-body">
                            <h5 class="card-title">Dirección de retiro</h5>
                            <p class="card-text">
                                Dirección: Calle Falsa 123<br />
                                Ciudad: Springfield<br />
                                Código Postal: 12345<br />
                            </p>
                        </div>
                    </div>
                </div>
                <%}
                    else if (Session["metodoEntrega"].ToString() == "Envio a domicilio.")
                    {%>
                <div class="col-md-6">
                    <div class="card card-custom">
                        <div class="card-body">
                            <h5 class="card-title">Envio dentro de las 48hs habiles.</h5>
                            <p class="card-text">
                                Whatsapp: 2246438721<br />
                                Instagram: @Supermercado<br />
                            </p>
                        </div>
                    </div>
                </div>
                <%} %>
                <%if (Session["metodoPago"].ToString() == "Transferencia Bancaria")
                    {
                %>
                <div class="col-md-6">
                    <div class="card card-custom">
                        <div class="card-body">
                            <h5 class="card-title">Datos bancarios</h5>
                            <p class="card-text">
                                CBU: 6465465465464654646546<br />
                                Banco: BBVA Banco Frances<br />
                                Alias: supermercado.programacion.III<br />
                            </p>
                        </div>
                    </div>
                </div>
                <% }
                    else if (Session["metodoPago"].ToString() == "Efectivo")
                    {%><div class="col-md-6">
    <div class="card card-custom">
                        <div class="card-body">
                            <h5 class="card-title">Datos de contacto</h5>
                            <p class="card-text">
                                Whatsapp: 2246438721<br />
                                Instagram: @Supermercado<br />
                            </p>
                        </div>
                    </div>
                        </div>
                <%}
                    }%>
            </div>
        </div>
        <div class="button-container">
            <asp:Button ID="btnInicio" runat="server" CssClass="btn btn-success" Text="Ir al inicio!" OnClick="btnInicio_Click" />
        </div>
    </form>
</body>
</html>
