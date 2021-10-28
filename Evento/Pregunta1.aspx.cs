using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Evento
{
    public partial class Pregunta1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(DropDownList1.Items.Count == 0)
            {
                String ponentes = "select * from ponente";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(ponentes, conexion);
                OdbcDataReader lector = comando.ExecuteReader();
                DropDownList1.DataSource = lector;
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataValueField = "claveP";
                DropDownList1.DataBind();
                lector.Close();
                conexion.Close();


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String queryClaveC = "select max(claveC)+1 from conferencia";
            String inserta = "insert into conferencia values(?, ?, ?, ?, ?) ";
            
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(queryClaveC, conexion);
            OdbcDataReader lector = comando.ExecuteReader();
            lector.Read();
            int claveC = lector.GetInt32(0);

            comando = new OdbcCommand(inserta, conexion);
            try
            {
                comando.Parameters.AddWithValue("claveC", claveC);
                comando.Parameters.AddWithValue("nombre", TextBox1.Text);
                comando.Parameters.AddWithValue("tema", TextBox2.Text);
                comando.Parameters.AddWithValue("fecha", TextBox3.Text);
                comando.Parameters.AddWithValue("claveP", Int32.Parse(DropDownList1.SelectedValue));
                comando.ExecuteNonQuery();
                lector.Close();
                conexion.Close();
                Label1.Text = "Se agregó la conferencia correctamente";
            } catch
            {
                Label1.Text = "Ocurrió un error, vuelva a intentar";
            }
        }
    }
}