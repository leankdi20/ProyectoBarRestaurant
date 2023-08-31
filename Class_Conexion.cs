using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBarRestaurant
{
    internal class Class_Conexion
    {
        //Variables para llamar a la conexion
        private SqlConnection connection;
        private String server, database;
        private String connectionString;
        private Boolean estado;

        public SqlConnection Connection { get => connection; set => connection = value; }
        public bool Estado { get => estado; set => estado = value; }

        public Class_Conexion()
        {
            //Le digo al sistema cual es mi Base de datos.
            this.server = "DESKTOP-31MUM0G";
            this.database = "RestauranteSoto";


            //Hace conexion con el servidor y lo hace seguro para el usuario
            connectionString = $"Server={server};Database={database}; integrated security = true; ";
            connection = new SqlConnection(connectionString);
        }

        //Metodo para abrir la conexion
        public void OpenConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                    estado = true;
                }
                // return estado; // Se devuelve el estado de la conexión (true si se abrió correctamente)
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening connection: " + ex.Message);
                MessageBox.Show("Atención: " + ex.Message);
                estado = false;
                //throw; // Vuelve a lanzar la excepción para manejarla en el nivel superior
            }


        }
        //Metodo para cerrar la conexion
        public bool CloseConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }

                return true; // Se devuelve true si la conexión se cerró correctamente
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
                MessageBox.Show("Atención: " + ex.Message);
                throw; // Vuelve a lanzar la excepción para manejarla en el nivel superior
            }
        }
    }
}
