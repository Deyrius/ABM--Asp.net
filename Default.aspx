<%@  Language="C#" AutoEventWireup="true"  CodeBehind="Default.aspx.cs" Inherits="Parcial._Default" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>



<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login..</title>
<webopt:bundlereference runat="server" path="~/Content/css" />
    <%--  --%>
</head>
<body>
    <h2 id="Titulo2" style="text-align:center"> Ingreso a la Aplicacion</h2>
    <form id="form1" runat="server">
    <div id="Inicio">
        <table class="table table-dark">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txt_Login" runat="server" Font-Bold="True" ForeColor="Black"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
                </td>
                
                <td>
                    <asp:TextBox ID="Txt_Pass" runat="server" Font-Bold="True" ForeColor="Black" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>

        <div class="container">
            <div class="row justify-content-md-center">
            <asp:Button id="Button1" class="btn btn-dark" runat="server" Text="Ingresar" OnClick="Btn_Login_Click" />
            </div>
        </div>
        
              
    </form>


</body>
</html>

