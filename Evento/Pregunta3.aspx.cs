using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
namespace Evento
{
    public partial class Pregunta3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(DropDownList1.Items.Count == 0)
            {
                String s = "select claveA, nombre from asistente";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(s, conexion);
                OdbcDataReader lector = comando.ExecuteReader();
                DropDownList1.DataSource = lector;
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataValueField = "claveA";
                DropDownList1.DataBind();
                lector.Close();
                conexion.Close();

            }
            Button2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String s = "select conferencia.claveC, conferencia.nombre from conferencia inner join asistencia on asistencia.claveC = conferencia.claveC inner join asistente on asistente.claveA = asistencia.claveA where asistente.claveA = ?";
            
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(s, conexion);
            try
            {
                comando.Parameters.AddWithValue("claveA", Int32.Parse(DropDownList1.SelectedValue));
                OdbcDataReader lector = comando.ExecuteReader();
                RadioButtonList1.DataSource = lector;
                RadioButtonList1.DataTextField = "nombre";
                RadioButtonList1.DataValueField = "claveC";
                RadioButtonList1.DataBind();
                lector.Close();
                conexion.Close();
                Label1.Text = "Mostrando conferencias a las que está inscrito: " + DropDownList1.SelectedItem + ", seleccione la conferencia a la que ya no quiere asistir";
                Label2.Text = "";
                Button2.Visible = true;
            }
            catch
            {
                Label1.Text = "Ocurrió un error";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String d = "delete from asistencia where claveA = ? and claveC = ?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(d, conexion);
            try
            {
                comando.Parameters.AddWithValue("claveA", Int32.Parse(DropDownList1.SelectedValue));
                comando.Parameters.AddWithValue("claveC", Int32.Parse(RadioButtonList1.SelectedValue));
                comando.ExecuteNonQuery();
                conexion.Close();
                Label2.Text = "Se borró la asistencia correctamente";

                Button2.Visible = false;

            }
            catch
            {
                Label2.Text = "Ocurrió un error";
            }
        }
    }
}