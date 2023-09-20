using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoBarRestaurant
{
    public class Mesa
    {

        private int numeroMesa;
        private int cantidadComenzales;
        private int Codigo_camarero;
        private int Codigo_Menu;
        private int Cantidad_Menu;
        private decimal totalConsumo;
        private DateTime fechaConsumo;
        private DataGridView dataGrid;
        private string estado_Mesa;


        //Get and Set
        public int NumeroMesa { get => numeroMesa; set => numeroMesa = value; }
        public int Cantidad_comenzales { get => cantidadComenzales; set => cantidadComenzales = value; }

        public decimal TotalConsumo { get => totalConsumo; set => totalConsumo = value; }
        public DateTime FechaConsumo { get => fechaConsumo; set => fechaConsumo = value; }

        public DataGridView DataGrid { get => dataGrid; set => dataGrid = value; }
        public int Codigo_Menu1 { get => Codigo_Menu; set => Codigo_Menu = value; }
        public int Cantidad_Menu1 { get => Cantidad_Menu; set => Cantidad_Menu = value; }
        public string Estado_Mesa1 { get => estado_Mesa; set => estado_Mesa = value; }
        public int Codigo_camareros { get => Codigo_camarero; set => Codigo_camarero = value; }

        public Mesa(int NUMERO_MESA, int CANTIDAD_COMENZALES, int CODIGOCAMAREROS, decimal TOTAL_CONSUMO, int CODIGO_MENU, int CANTIDAD_MENU, string ESTADO_MESA)
        {
            numeroMesa = NUMERO_MESA;
            cantidadComenzales = CANTIDAD_COMENZALES;

            Codigo_camarero = CODIGOCAMAREROS;
            totalConsumo = TOTAL_CONSUMO;
            Codigo_Menu = CODIGO_MENU;
            Cantidad_Menu = CANTIDAD_MENU;
            estado_Mesa = ESTADO_MESA;

        }
        public Mesa()
        {

        }


        public Mesa ObtenerInformacionMesa(int numeroMesa)
        {
            Class_GestionBaseDatos gestionBaseDatos = new Class_GestionBaseDatos();

            // Luego, llama al método RetornaEstadoMesa() en la instancia creada
            List<Mesa> listaMesas = gestionBaseDatos.RetornaEstadoMesa();
            // Buscar la mesa con el número específico en la lista
            Mesa mesaEncontrada = listaMesas.FirstOrDefault(m => m.NumeroMesa == numeroMesa);

            // Si la mesa existe en la lista, la retornas; de lo contrario, podrías devolver null o un objeto Mesa vacío.
            return mesaEncontrada;
        }

        Class_Conexion conexion = new Class_Conexion();

        //NumeroMesa,       Cantidad_Comenzales,	   Codigo_Camarero,  	Codigo_Menu,	  Cantidad_Menu,	Estado_Mesa
        public void Ingresar(int NUMERO_MESA, int CANTIDAD_COMENZALES, int CODIGO_CAMAREROS, int CODIGO_MENU, int CANTIDAD_MENU, DataGridView dataGridView1, string ESTADO_MESA)
        {
            try
            {
                conexion.OpenConnection();
                bool huboError = false; // PAra saber si hubo un error al ingresar datos
                // Recorremos las filas del DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow) // Excluimos la fila de nueva entrada en el DataGridView (si la tienes)
                    {
                        int codigo_menu;
                        if (int.TryParse(row.Cells["Codigo"].Value.ToString(), out codigo_menu))
                        {
                            int cantidad_menu;
                            if (int.TryParse(row.Cells["Cant"].Value.ToString(), out cantidad_menu))
                            {
                                // Consulta SQL para insertar los datos en la base de datos
                                string query = "INSERT INTO MESA (NumeroMesa, Cantidad_Comenzales, Codigo_Camarero, Codigo_Menu, Cantidad_Menu, Estado_Mesa) " +
                                               "VALUES (@NumeroMesa, @Cantidad_Comenzales, @Codigo_Camarero, @Codigo_Menu, @Cantidad_Menu, @Estado_Mesa)";

                                using (SqlCommand command = new SqlCommand(query, conexion.Connection))
                                {
                                    // Agregamos los parámetros a la consulta
                                    command.Parameters.AddWithValue("@NumeroMesa", NUMERO_MESA);
                                    command.Parameters.AddWithValue("@Cantidad_Comenzales", CANTIDAD_COMENZALES);
                                    command.Parameters.AddWithValue("@Codigo_Camarero", CODIGO_CAMAREROS);
                                    command.Parameters.AddWithValue("@Codigo_Menu", codigo_menu);
                                    command.Parameters.AddWithValue("@Cantidad_Menu", cantidad_menu);
                                    command.Parameters.AddWithValue("@Estado_Mesa", ESTADO_MESA);

                                    command.ExecuteNonQuery(); // Ejecutamos la consulta para insertar los datos en la base de datos
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar los datos: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión a la base de datos al finalizar el proceso
                conexion.CloseConnection();
            }
        }







        public void Consulta(DataGridView dataGridView1)
        {
            conexion.OpenConnection();
            //Metodo para visualisar lo que hay en la base de datos
            try
            {
                string consulta = "select * from MESA";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conexion.CloseConnection();

        }
        public DataTable llenar_tabla()
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.OpenConnection();

                if (conexion.Estado)
                {
                    String consulta = "Select * from MESA";
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
        public void Limpiar_Pantalla(string Mesa, string Camarero, string Total, string Faltante, string Cambio, DataGridView Tabla)
        {
            Mesa = "";
            Camarero = "";
            Total = "";
            Faltante = "";
            Cambio = "";
            Tabla = null;


        }

        // Metodo para eliminar mesa de la base de datos
        public void Eliminar(String numeroMesa)
        {
            try
            {
                conexion.OpenConnection();

                // Realiza una consulta SQL para eliminar la fila de la tabla MESA
                string consultaSql = "DELETE FROM MESA WHERE NumeroMesa = @NumeroMesa";

                SqlCommand cmd = new SqlCommand(consultaSql, conexion.Connection);
                cmd.Parameters.AddWithValue("@NumeroMesa", numeroMesa);

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
    }
}

   

