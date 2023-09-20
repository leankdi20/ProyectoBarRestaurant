using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Drawing;

namespace ProyectoBarRestaurant
{
    public class Class_Empleado
    {
        //private Form1 form1;
        Class_Conexion conexion = new Class_Conexion();

        public void Consulta(DataGridView dataGridView1)
        {

            //Metodo para visualisar lo que hay en la base de datos

            string consulta = "select * from Camareros";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        public DataTable llenar_tabla()
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.OpenConnection();

                if (conexion.Estado)
                {
                    String consulta = "Select * from Camareros";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);

                    adaptador.Fill(dt);

                    conexion.CloseConnection();
                }
                else
                {
                    MessageBox.Show("Atención: No se pudo establecer conexion con la BD");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
                MessageBox.Show("Atención: " + ex.Message);
                //throw; // Vuelve a lanzar la excepción para manejarla en el nivel superior
            }
            return dt;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imagen)
        {
            
                MemoryStream ms = new MemoryStream();
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            
        }

        public void Ingresar(string codigo, string nombres, string identificacion, string celular, string direccion, DateTime fechaIngreso, Image Imagen)
        {
            try
            {
                conexion.OpenConnection();

                // Validar y convertir la fecha ingresada
                if (fechaIngreso != null)
                {
                    // Define cadena de inserción con parámetros
                    string cadena = "INSERT INTO Camareros (Codigo, Nombres, Identificacion, Celular, Direccion, FechaIngreso, Imagen) " +
                                    "VALUES (@Codigo, @Nombres, @Identificacion, @Celular, @Direccion, @FechaIngreso, @Imagen)";

                    // Define comando de ejecución
                    SqlCommand comando = new SqlCommand(cadena, conexion.Connection);

                    // Agregar parámetros
                    comando.Parameters.AddWithValue("@Codigo", codigo);
                    comando.Parameters.AddWithValue("@Nombres", nombres);
                    comando.Parameters.AddWithValue("@Identificacion", identificacion);
                    comando.Parameters.AddWithValue("@Celular", celular);
                    comando.Parameters.AddWithValue("@Direccion", direccion);
                    comando.Parameters.AddWithValue("@FechaIngreso", fechaIngreso.ToString("yyyy-MM-dd"));

                    // Convertir la imagen a un arreglo de bytes
                    byte[] byteArrayImagen = ImageToByteArray(Imagen);
                    comando.Parameters.AddWithValue("@Imagen", byteArrayImagen);

                    // Ejecuta comando
                    comando.ExecuteNonQuery();

                    // Envía mensaje de confirmación
                    MessageBox.Show("Los Datos se Guardaron Correctamente");

                    // Limpia variables en pantalla (esto no modificará los parámetros originales)
                    codigo = "";
                    nombres = "";
                    identificacion = "";
                    celular = "";
                    direccion = "";
                    fechaIngreso = DateTime.Today;  // Restablecer el valor del DateTimePicker
                    Imagen = null;
                }
                else
                {
                    MessageBox.Show("El valor de FechaIngreso no es una fecha válida.");
                }

                // Cierra la conexión
                conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al incluir empleado" + ex.Message);
            }
        }



        public void Modificar(string textBox2, string textBox3, string textBox4, String textBox5, DateTime fechaIngreso, String textBox1)
        {
            try
            {
                // Abre conexión
                conexion.OpenConnection();
                string cadena = "update Camareros set Nombres='" + textBox2 + "'" +
                ", Identificacion=' " + textBox3 + "'" +
                ", Celular=' " + textBox4 + "'" +
                ", Direccion=' " + textBox5 + "'" +
                ", FechaIngreso=' " + DateTime.Today + "'" +
                    "Where Codigo=" + textBox1;
                SqlCommand comando = new SqlCommand(cadena, conexion.Connection);
                int cantidad_modificados = comando.ExecuteNonQuery();
                if (cantidad_modificados == 1)
                {
                    MessageBox.Show(" ----- Se Modificaron los Datos ----- ");
                }
                else
                    MessageBox.Show(" ----- No Existe una Identificación con el Código Ingresado ----- ");
                textBox1 = "";
                textBox2 = "";
                textBox3 = "";
                textBox4 = "";
                textBox5 = "";

                conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }


        public void Eliminar(String textBox1)
        {
            try
            {
                conexion.OpenConnection();
                string cadena = "delete from Camareros Where Codigo=" + textBox1;
                SqlCommand comando = new SqlCommand(cadena, conexion.Connection);
                int cantidad_borrados = comando.ExecuteNonQuery();
                if (cantidad_borrados == 1)
                {
                    MessageBox.Show(" ----- El Registro fue Borrado ----- ");

                }
                else
                    MessageBox.Show("El Codigo No existe");

                conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        public void Verificar_Empleado(DataGridView dataGridView1, String Codigo)
        {
           
        }

      

        public void Seleccionar_Imagen()
        {
           

        }
      




    }
}
