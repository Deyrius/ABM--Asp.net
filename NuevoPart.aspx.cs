using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca;
using Microsoft.Ajax.Utilities;
using BLL;

namespace Parcial
{
    public partial class NuevoPart : Page
    {
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) Response.Redirect("Default.aspx");
            lbl_usuario.Text = "Usuario: " + Session["Usuario"].ToString();
            //Txt_id.Text = Session["NuevoId"].ToString();
            //Txt_id.ReadOnly = true;
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            int puntaje = 0 ;
            bool nombreInvalido = (int.TryParse(txt_nombre.Text, out _) || string.IsNullOrEmpty(txt_nombre.Text));
            bool apellidoInvalido = (int.TryParse(txt_apellido.Text, out _) || string.IsNullOrEmpty(txt_apellido.Text));
            bool puntajeInvalido = (!int.TryParse(txt_puntaje.Text, out puntaje) || puntaje < 0);
            
            Error_Nombre.Text = nombreInvalido ? " Por favor coloque solo letras o no estar vacio" : "" ;
            Error_Apellido.Text = apellidoInvalido ? " Por favor coloque solo letras o no estar vacio" : "";
            Error_Puntaje.Text = puntajeInvalido ? "El valor no puede estar vacio o contener letras." : "";

            if (!nombreInvalido && !apellidoInvalido && !puntajeInvalido)
            {
                /*
                var participante = new Participantes()
                {
                    IdParticipante = Convert.ToInt32(Txt_id.Text),
                    Nombre = txt_nombre.Text,
                    Apellido = txt_apellido.Text,
                    Puntaje = puntaje,

                };
                Session["NuevoParticipante"] = participante;
                */
                var participanteBLL = new ParticipanteBLL();
                participanteBLL.InsertarParticipante(Int32.Parse(txt_puntaje.Text), txt_nombre.Text, txt_apellido.Text);

                Response.Redirect("Principal.aspx");
            }
        }

        protected void btn_volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Principal.aspx");
        }
        
    }
}