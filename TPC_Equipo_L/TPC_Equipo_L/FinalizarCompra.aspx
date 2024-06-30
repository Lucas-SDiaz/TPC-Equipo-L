<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="TPC_Equipo_L.FinalizarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .rounded-gridview {
            border-radius: 10px; 
            overflow: hidden;
        }
    </style>
<h2> Descripcion de su compra</h2><br />
<asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <asp:GridView runat="server" ID="dgvFinalizarCompra" CssClass="table table-borderless table-striped rounded-gridview" AutoGenerateColumns="false" DataKeyNames="CodigoProducto" OnSelectedIndexChanged="dgvFinalizarCompra_SelectedIndexChanged">
        <Columns>                    
            <asp:BoundField HeaderText="Producto" DataField="Nombre" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad"/>
            <asp:CommandField ShowSelectButton="true" SelectText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="" ControlStyle-CssClass="btn btn-outline-danger btn-sm" />
        </Columns>
    </asp:GridView>
    <br />
    <div class="row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <div class="card">
                <h3 style="text-align: center"> Metodo de enterga </h3>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                    <label class="form-check-label" for="flexRadioDefault1">
                    Coordinar con vendedor  
                    </label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked>
                    <label class="form-check-label" for="flexRadioDefault2">
                    Retirar en local
                    </label><br/><br />
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="card">                
                <h3 style="text-align: center"> Metodo de Pago </h3>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault3">
                    <label class="form-check-label" for="flexRadioDefault1">
                    Transferencia Bancaria 
                    </label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault4" checked>
                    <label class="form-check-label" for="flexRadioDefault2">
                    Coordino al retirar
                    </label><br /><br />
                </div>
                </div>
            </div>
        </div><br />
    <asp:Label ID="lblPrecioFinal" runat="server" CssClass="form-control"  style="text-align: right;" BorderColor="black"   BackColor="#d5e8eb"></asp:Label>
</asp:Content>
          

