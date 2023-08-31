using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;

namespace ProyectoBarRestaurant
{
    internal class Class_GestionBaseDatos
    {
        Class_Conexion conexion = new Class_Conexion();

        public void Consulta(DataGridView dataGridView2)
        {

            //Metodo para visualisar lo que hay en la base de datos

            string consulta = "select * from Menu";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView2.DataSource = dt;


        }
        public DataTable llenar_tabla()
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.OpenConnection();

                if (conexion.Estado)
                {
                    String consulta = "Select * from Menu";
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

        public void Buscar(DataGridView dataGridView2, String textBox1)
        {
            try
            {
               

                conexion.OpenConnection();

                //string consulta = "select * from Usuario2 WHERE Nombre='" + textBox6.Text + "'";
                string consulta = "SELECT * FROM Menu WHERE UPPER(Codigo) LIKE '%" + textBox1.ToUpper() + "%' OR UPPER(Descripcion) LIKE '%" + textBox1.ToUpper() + "%'";


                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);

                // Creo una tabla virtual de consulta
                DataTable dataTable = new DataTable();

                //Ahora hay que llenar el dataTable con lo que tiene el adaptador

                adaptador.Fill(dataTable);
                //ahora se va a reglejar en el siguiente tablero del diseño
                dataGridView2.DataSource = dataTable;

                SqlCommand comando = new SqlCommand(consulta, conexion.Connection);

                //Permite leer los datos en el DataTable y extraerlos.
                SqlDataReader lector;
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se encontro usuario" + ex.Message);
            }
            finally
            {
                conexion.CloseConnection();
            }

        }
        public void Buscar2(DataGridView dataGridView1, String textBox1)
        {
            try
            {


                DataTable dataTable = (DataTable)dataGridView1.DataSource;
                DataView dataView = new DataView(dataTable);

                string filtro = "UPPER(Codigo) LIKE '%" + textBox1.ToUpper() + "%' OR UPPER(Descripcion) LIKE '%" + textBox1.ToUpper() + "%'";
                dataView.RowFilter = filtro;

                dataGridView1.DataSource = dataView.ToTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se encontro usuario" + ex.Message);
            }
          

        }

        public void MostrarMenu(DataGridView dataGridView1)
        {
     
            conexion.OpenConnection();
            //Tabla de datos en memoria
            DataTable dt = new DataTable();
            //DataAdapter es un objeto que almacena n numero de DataTables 
            SqlDataAdapter adaptador = new SqlDataAdapter("select * from Menu", conexion.Connection);
            //Llena el adaptador con la instruccion sql
            adaptador.Fill(dt);
            //Cargar el datagridview1
            dataGridView1.DataSource = dt;
            conexion.CloseConnection();
        }

        // Retorna el estado de mesa para saber si está ocupado o desocupado
        public List<Mesa> RetornaEstadoMesa()
        {
            List<Mesa> listaMesas = new List<Mesa>();
            conexion.OpenConnection();
            string consultaSql = "SELECT DISTINCT [NumeroMesa], [Estado_Mesa] FROM [RestauranteSoto].[dbo].[MESA]";

            using (SqlCommand command = new SqlCommand(consultaSql, conexion.Connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int numeroMesa = Convert.ToInt32(reader["NumeroMesa"]);
                        string estadoMesa = reader["Estado_Mesa"].ToString();

                        // char estadoMesa = (char)reader["Estado_Mesa"];


                        Mesa mesa = new Mesa()
                        {

                            NumeroMesa = numeroMesa,
                            Estado_Mesa1 = estadoMesa
                        };

                        listaMesas.Add(mesa);
                    }
                }
            }
            conexion.CloseConnection( );    

           
            return listaMesas;
        }

       


        
        public Mesa AbrirMesaOcupada(int NumeroMesa)
        {
            Mesa mesa = null;
            conexion.OpenConnection();
            string consultaSql = "SELECT Cantidad_Comenzales, Codigo_Camarero, Estado_Mesa " +
                "FROM RestauranteSoto.DBO.MESA WHERE NumeroMesa = @num_Mesa";

            using (SqlCommand command = new SqlCommand(consultaSql, conexion.Connection))
            {
                command.Parameters.AddWithValue("@num_Mesa", NumeroMesa);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int CantidadComenzales = Convert.ToInt32(reader["Cantidad_Comenzales"]);
                        int codigoCamarero = Convert.ToInt32(reader["Codigo_Camarero"]);
                        String estadoMesa = Convert.ToString(reader["Estado_Mesa"]);

                        mesa = new Mesa()
                        {
                            NumeroMesa = NumeroMesa,
                            Cantidad_comenzales = CantidadComenzales,
                            Codigo_camareros = codigoCamarero,
                            Estado_Mesa1 = estadoMesa
                        };
                    }
                }
            }
            conexion.CloseConnection();

            return mesa;
        }

        public void Historial_Mesas_Cobradas(DataGridView dataGridView1, Label lblTotal)
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
            conexion.CloseConnection();
        }



    }
}
