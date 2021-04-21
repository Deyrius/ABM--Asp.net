using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca;
using BLL;

namespace Parcial
{
    public partial class Principal : Page
    {   
    
        public static List<Participantes> participaciones = new List<Participantes>()
            {/*
                new Participantes(){IdParticipante = 1, Nombre = "Damian" , Apellido = "Perez", Puntaje = 300},
                new Participantes(){IdParticipante = 2, Nombre = "Mateo" , Apellido = "Heredia", Puntaje = 400},
                new Participantes(){IdParticipante = 3, Nombre = "Leandro" , Apellido = "Bustamante", Puntaje = 550},
                new Participantes(){IdParticipante = 4, Nombre = "Alan" , Apellido = "Mitre", Puntaje = 250},
                new Participantes(){IdParticipante = 5, Nombre = "Federico" , Apellido = "Ezpeleta", Puntaje = 567},
                new Participantes(){IdParticipante = 6, Nombre = "Alejandro" , Apellido = "Dominguez", Puntaje = 326},
                new Participantes(){IdParticipante = 7, Nombre = "Dalma" , Apellido = "Herrera", Puntaje = 453},
                new Participantes(){IdParticipante = 8, Nombre = "Javier" , Apellido = "Gonzalez", Puntaje = 125},
                new Participantes(){IdParticipante = 9, Nombre = "Jesica" , Apellido = "Velez", Puntaje = 375},
                new Participantes(){IdParticipante = 10, Nombre = "Jeremias" , Apellido = "Gomez", Puntaje = 385},
                new Participantes(){IdParticipante = 11, Nombre = "Leonor" , Apellido = "Ayala", Puntaje = 100},
                new Participantes(){IdParticipante = 12, Nombre = "Florencia" , Apellido = "Perez", Puntaje = 305} */
            };
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null)Response.Redirect("Default.aspx");

            if (!Page.IsPostBack)
            {
                lbl_label1.Text = "Usuario: " + Session["Usuario"].ToString();
                // CargarParticipantes();
                MostrarGrilla();
                BindData();
            }
            //MostrarGrilla();
        }

        /*public void CargarParticipantes()
        {
            DataTable participantesTable = new DataTable("Participantes");
            participantesTable.Columns.Add("ID", typeof(int));
            participantesTable.Columns.Add("Nombre", typeof(string));
            participantesTable.Columns.Add("Apellido", typeof(string));
            participantesTable.Columns.Add("Puntaje", typeof(int));
            if (Session["NuevoParticipante"] != null) 
            {
                participaciones.Add((Participantes)Session["NuevoParticipante"]);
                Session["NuevoParticipante"] = null;
            }
            foreach(Participantes participante in participaciones)
            {
                DataRow tableRow = participantesTable.NewRow();
                tableRow["ID"] = participante.IdParticipante;
                tableRow["Nombre"] = participante.Nombre;
                tableRow["Apellido"] = participante.Apellido;
                tableRow["Puntaje"] = participante.Puntaje;
                participantesTable.Rows.Add(tableRow);
            }
             Session["Participantes"] = participantesTable;
        }*/

        protected void btn_inicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btn_ordenPuntaje_Click(object sender, EventArgs e)
        {
            //participaciones = participaciones.OrderByDescending(p => p.Puntaje).ToList();
            //CargarParticipantes();
            var participanteBLL = new ParticipanteBLL();
            GridView1.DataSource = participanteBLL.MostrarListadoParticipantes().OrderByDescending(p => p.Puntaje).ToList();
            //MostrarGrilla()  ;
            BindData();
        }

        protected void btn_ordenNombre_Click(object sender, EventArgs e)
        {
            //participaciones = participaciones.OrderBy(p => p.Nombre).ToList();
            //CargarParticipantes();
            var participanteBLL = new ParticipanteBLL();
            GridView1.DataSource = participanteBLL.MostrarListadoParticipantes().OrderByDescending(p => p.Nombre).ToList();
            BindData();
        }

        protected void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            //var MaxIdParticipante = participaciones.Count == 0 ? 1 : participaciones.Max(x => x.IdParticipante) + 1;
            //Session["NuevoId"] = MaxIdParticipante;
            Response.Redirect("NuevoPart.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void editar(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.Rows[e.NewEditIndex].Cells[1].Controls.Add(new Control() { Visible = false });
            BindData();
        }
        protected void cancelaredicion(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }
        protected void actualizar(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

            int puntaje = 0;
            string nombreParticipante = ((TextBox) row.Cells[2].Controls[0]).Text;
            string apellidoParticipante = ((TextBox) row.Cells[3].Controls[0]).Text;
            string puntajeParticipante = ((TextBox) row.Cells[4].Controls[0]).Text;
            bool nombreInvalido = (int.TryParse(nombreParticipante, out _) || string.IsNullOrEmpty(nombreParticipante));
            bool apellidoInvalido = (int.TryParse(apellidoParticipante, out _) || string.IsNullOrEmpty(apellidoParticipante));
            bool puntajeInvalido = (!int.TryParse(puntajeParticipante, out puntaje) || puntaje < 0);
            var participanteBLL = new ParticipanteBLL();

            Message.Text = nombreInvalido ? "Nombre Invalido" : "";
            Message.Text += apellidoInvalido ? " Apellido Invalido" : "";
            Message.Text += puntajeInvalido ? " Puntaje Invalido" : "";


            if (!nombreInvalido && !apellidoInvalido && !puntajeInvalido)
            {

                participanteBLL.ModificarParticipante(Convert.ToInt32(puntajeParticipante), nombreParticipante, apellidoParticipante, Convert.ToInt32(row.Cells[1].Text));
                Response.Redirect("Principal.aspx");
                MostrarGrilla();
                GridView1.EditIndex = -1;
                BindData();
            }
            else
            {
                e.Cancel = true;
            }
        }
        protected void borrado(object sender, GridViewDeletedEventArgs e){ }

        protected void borrando(object sender, GridViewDeleteEventArgs e)
        {
            //int filaIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
            var participanteBLL = new ParticipanteBLL();
            int filaIndex = e.RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[filaIndex].Cells[1].Text);
            int indice = 0;
            var participantes = participanteBLL.MostrarListadoParticipantes();

           // for (int i = 0; i < participantes.Count; i++)
           // {   
           //     if(participantes[i].IdParticipante == id) { indice = i ; };
           // };

           // participantes.Remove(participantes[indice]);
            participanteBLL.BorrarParticipante(id);
            //CargarParticipantes();
            MostrarGrilla();
            BindData();
        }
        private void BindData()
        {
            GridView1.DataKeyNames = new string[] { "IdParticipante" };
            // GridView1.DataSource = Session["Participantes"];
            //MostrarGrilla();
            GridView1.DataBind();
        }
        private void MostrarGrilla() 
        {
            var participanteBLL = new ParticipanteBLL();
            GridView1.DataSource = participanteBLL.MostrarListadoParticipantes();
        }
    }
}