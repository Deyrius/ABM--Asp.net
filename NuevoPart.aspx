<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoPart.aspx.cs" Inherits="Parcial.NuevoPart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>

<webopt:bundlereference runat="server" path="~/Content/css" />

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            height: 25px;
        }
    </style>
</head>



<body>
    <form id="form1" runat="server" >
    <div id="lblUsuario" aria-readonly="True" class="alert alert-secondary" role="alert">

        <asp:Label ID="lbl_usuario" runat="server" Text="usuario"></asp:Label>

    </div>
    <div>

        <asp:Button ID="btn_volver" class="btn btn-dark" runat="server" OnClick="btn_volver_Click" Text="Volver" />

    </div>
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td id="lbl_nombre" class="auto-style3">Nombre</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txt_nombre"  runat="server" ToolTip="Coloque el nombre"></asp:TextBox>
                        <asp:Label ID="Error_Nombre" runat="server" Text="" ForeColor ="#ff0000"   ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Apellido</td>
                    <td >
                        <asp:TextBox ID="txt_apellido" runat="server" ToolTip="Coloque el apellido"></asp:TextBox>
                        <asp:Label ID="Error_Apellido" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Puntaje</td>
                    <td>
                        <asp:TextBox ID="txt_puntaje" runat="server" ToolTip="Coloque el puntaje"></asp:TextBox>
                        <asp:Label ID="Error_Puntaje" runat="server" ForeColor="#CC0000"></asp:Label>
                    </td>
                </tr>                                       
            </table>
          <asp:Button class="btn btn-success" ID="btn_id" runat="server" Text="Guardar" OnClick="Guardar_Click"  CausesValidation="true"/>
        </div>
    </form>
</body>
</html>

