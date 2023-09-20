using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBarRestaurant
{
    internal class Class_CierreCaja
    {
        Class_Conexion conexion = new Class_Conexion();

        private String Total;

       

        public string Total1 { get => Total; set => Total = value; }

        public Class_CierreCaja()
        {
            
        }



        public void BtnCerrarCaja(string total_dia)
        {
            try
            {
                conexion.OpenConnection();

                // Convertir el valor del TextBox1 a decimal
                if (decimal.TryParse(total_dia, out decimal totalDiaDecimal))
                {
                    // Define cadena de inserción con parámetros
                    string cadena = "INSERT INTO CierreCaja (Total_Dia) " +
                                    "VALUES (@Total_Dia)";

                    // Define comando de ejecución
                    SqlCommand comando = new SqlCommand(cadena, conexion.Connection);

                    // Agregar parámetros
                    comando.Parameters.AddWithValue("@Total_Dia", totalDiaDecimal);

                    // Ejecuta comando
                    comando.ExecuteNonQuery();

                    // Envía mensaje de confirmación
                    MessageBox.Show("CAJA CERRADA CORRECTAMENTE");

                    // Limpia variables en pantalla (esto no modificará los parámetros originales)
                }
                else
                {
                    MessageBox.Show("Ingrese un valor numérico válido en el TextBox.");
                }

                // Cierra la conexión
                conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }








        public void LlamaCierreCaja(DataGridView dataGridView1, TextBox lblTotal)
        {
            try
            {
                conexion.OpenConnection();

                //Llamo a la base de datos para rellenar la tabla

                //Tabla de datos en memoria
                DataTable dt = new DataTable();
                //DataAdapter es un objeto que almacena n numero de DataTables 
                SqlDataAdapter adaptador = new SqlDataAdapter("select * from MesaCobrada", conexion.Connection);
                //Llena el adaptador con la instruccion sql
                adaptador.Fill(dt);

                // Calcula la suma de la columna "Total"
                decimal totalSum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    //Esto suma La columna Total de la Tabla MesaCobrada.
                    if (decimal.TryParse(row["Total"].ToString(), out decimal total))
                    {
                        totalSum += total;
                    }
                }

                // Mostrar el total en el Label
                lblTotal.Text = totalSum.ToString("N2");

                //Cargar el datagridview1
                dataGridView1.DataSource = dt;

            }
            catch(Exception ex) {
                MessageBox.Show("Error" + ex.Message);
            }
            finally { conexion.CloseConnection(); }
            
            
            

        }

        public void EliminarMesaCobrada()
        {
            try
            {
                conexion.OpenConnection();

                // Realiza una consulta SQL para eliminar la fila de la tabla MESA
                string consultaSql = "Delete FROM[Restaurante].[dbo].[MesaCobrada]";

                SqlCommand cmd = new SqlCommand(consultaSql, conexion.Connection);


                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("La mesa se eliminó correctamente.");
                }
                else
                {
                    MessageBox.Show("No se encontró la mesa con el número especificado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la mesa: " + ex.Message);
            }
            finally
            {
                conexion.CloseConnection();
            }


        }




        public void Consulta(DataGridView dataGridView1)
        {

            //Metodo para visualisar lo que hay en la base de datos

            string consulta = "select * from CierreCaja";
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
                    String consulta = "Select * from CierreCaja";
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


    }
}
