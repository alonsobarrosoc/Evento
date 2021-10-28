using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
namespace Evento
{
    public partial class Pregunta2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(DropDownList1.Items.Count == 0)
            {
                String asistentes = "select claveA, nombre from asistente";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(asistentes, conexion);
                OdbcDataReader lector = comando.ExecuteReader();
                DropDownList1.DataSource = lector;
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataValueField = "claveA";
                DropDownList1.DataBind();
                lector.Close();
                conexion.Close();

            }
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "select conferencia.nombre as 'Nombre de la conferencia', conferencia.fecha as 'Fecha de la conferencia', ponente.nombre as 'Nombre del ponente' from conferencia inner join ponente on ponente.claveP = conferencia.claveP inner join asistencia on asistencia.claveC = conferencia.claveC inner join asistente on asistencia.claveA = asistente.claveA where asistente.claveA = ?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            try
            {
                comando.Parameters.AddWithValue("claveA", Int32.Parse(DropDownList1.SelectedValue));
                OdbcDataReader lector = comando.ExecuteReader();
                GridView1.DataSource = lector;
                GridView1.DataBind();
                lector.Close();
                conexion.Close();
                Label1.Text = "Mostrando conferencias a las que asistirá " + DropDownList1.SelectedItem.Text;


            }
            catch
            {
                Label1.Text = "Ocurri'o un error, vuelva a intentarlo";
            }
        }
    }
}