using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlTypes;
using System.Reflection.Emit;

namespace ProyectoBarRestaurant
{
    
    
    public class Class_ServicioMenu
    {
        Class_Conexion conexion = new Class_Conexion();
        Class_DetalleMenu menu = new Class_DetalleMenu();
        Class_GestionBaseDatos gestion = new Class_GestionBaseDatos();

        public Class_ServicioMenu()
        {

        }

        public void Ingresar(String Codigo, String Categoria, String Descripcion, String PrecioUnitario, String Cantidad, String Total )
        {
            try
            {
               conexion.OpenConnection();


                string cadena = "insert into Menu (Codigo, Categoria, Descripcion, Precio_Unitario, Cantidad, Total) " +
                "values('" + Codigo + "','" + Categoria + "', '" + Descripcion+ "', " + PrecioUnitario + ", " + Cantidad + ", " + Total + ")";

                //Define comando de ejecusion
                SqlCommand comando = new SqlCommand(cadena, conexion.Connection);
                //Ejecuta comando
                int rowsAffected = comando.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("La consulta se ejecutó exitosamente. Filas afectadas: " + rowsAffected);
                }
                else
                {
                    MessageBox.Show("La consulta no afectó ninguna fila en la base de datos.");
                }
                //Limpiar variables en pantalla
                Codigo = "";
                Categoria = "";
                Descripcion = "";
                PrecioUnitario = "";
                Cantidad = "";
                Total = "";

              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al incluir articulo repetido" + ex.Message);
            }
            finally
            {
                conexion.CloseConnection();
            }
        }
        public void Modificar(String Categoria, String Descripcion, String PrecioUnitario,String Cantidad, String Total, String Codigo )
        {
            try
            {

                conexion.OpenConnection();

                // Define cadena de actualización
                string cadena = "UPDATE Menu SET Categoria='" + Categoria + "'" +
                                ", Descripcion='" + Descripcion + "'" +
                                ", Precio_Unitario=" + PrecioUnitario +
                                ", Cantidad=" + Cantidad +
                                ", Total=" + Total +
                                " WHERE Codigo='" + Codigo + "'";


                //Define comando de ejecusion
                SqlCommand comando = new SqlCommand(cadena, conexion.Connection);
                //Ejecuta comando
                comando.ExecuteNonQuery();
                //Enviar msg de confrmacion
                MessageBox.Show("Los datos se guardaron correctamente");
                //Limpiar variables en pantalla
               
                //Categoria = "";
                //Descripcion = "";
                //PrecioUnitario = "";
                //Cantidad = "";
                //Total = "";
                //Codigo = "";
                //Cierra conexion
                conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message);
            }


        }
        public void Eliminar(String Codigo)
        {
            try
            {
                conexion.OpenConnection();

                string cadena = "delete from Menu where Codigo=" + Codigo;
                SqlCommand comando = new SqlCommand(cadena, conexion.Connection);
                //Esta variable permite detectar cuantos productos fueron borrados
                int cantidad_borrados = comando.ExecuteNonQuery();
                if (cantidad_borrados == 1)
                {
                    MessageBox.Show("El producto fue borrado");
                }
                else
                    MessageBox.Show("El codigo no existe");
                Codigo = "";

                conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
        }

        public void Consulta(DataGridView dataGridView1)
        {
            conexion.OpenConnection();
            //Metodo para visualisar lo que hay en la base de datos
            try
            {
                string consulta = "select * from Menu";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;

               
            }catch (Exception ex)
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


       
        
    }
}
