﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LogReg.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPC_Equipo_L.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1 class="text-center fs-2 p-2">Hubo un problema</h1>
    <br />
    <figure class="text-center">
    <asp:Label Text="" ID="lblMensaje" runat="server" />
<br />
        <br />
        <br />
<a href="Default.aspx" class="btn btn-outline-dark" Style="background-color: #99bbc2;" >Volver al inicio</a>
</figure>

    
</asp:Content>
