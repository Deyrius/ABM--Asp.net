<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Parcial.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox ID="Txt_Error" runat="server" Width="222px">Error al Logear, Vuelva a intentar</asp:TextBox>
    <asp:Button ID="btn_regresar" runat="server" OnClick="btn_regresar_Click" Text="Regresar" />

</asp:Content>
