using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca;

namespace Parcial
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_Login_Click(object sender, EventArgs e) 
        {
            var _Usuarios = new List<Usuarios>()
            {
                new Usuarios(){IdUsuario = 1, Usuario = "administrador", Pass="1234", Habilitado = 0},
                new Usuarios(){IdUsuario = 2, Usuario = "juez1", Pass="1234",Habilitado = 0},
                new Usuarios(){IdUsuario = 3, Usuario = "juez2", Pass="1234",Habilitado = 0}
            }; 

            var Usuario_Login = Txt_Login.Text;
            Usuario_Login = Usuario_Login.ToUpper();
            foreach(var x in _Usuarios) 
            {
                if(Usuario_Login == x.Usuario.ToUpper() & Txt_Pass.Text == x.Pass & x.Habilitado == 0)
                {
                    Session["Usuario"] = x.Usuario;
                    Response.Redirect("Principal.aspx");
                }
            }
            Response.Redirect("Error.aspx");
        }
    }
}