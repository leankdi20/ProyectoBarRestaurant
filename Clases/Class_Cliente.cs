using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoBarRestaurant
{
    internal class Class_Cliente
    {

        private string Nombre;
        private string Cedula;
        private string Email;
        private string Celular;
        private string Direccion;

        Class_Conexion conexion = new Class_Conexion();



        public string nombre { get => Nombre; set => Nombre = value; }
        public string cedula { get => Cedula; set => Cedula = value; }
        public string email { get => Email; set => Email = value; }

        public string celular { get => Celular; set => Celular = value; }
        public string direccion { get => Direccion; set => Direccion = value; }



        public Class_Cliente(string nombre, string cedula, string email, string celular, string direccion)
        {
            this.Nombre = nombre;
            this.Cedula = cedula;
            this.Email = email;
            this.Celular = celular;
            this.Direccion = direccion;
        }

        //Constructor vacio
        public Class_Cliente()
        {

        }

        public void Ingresar(string cedula, string nombre, string celular, string email, string direccion)
        {
            conexion.OpenConnection();

            try
            {

                //Define cadena de inserción
                string cadena = "insert into Clientes (Cedula, Nombre, Celular, Correo_Electronico, Direccion)"
                + "values('" + cedula + "','" + nombre + "','" + celular + "','" + email + "','"+ direccion + "')";

                //Define comando de ejecución 
                SqlCommand comando = new SqlCommand(cadena, conexion.Connection);
                //ejecuta comando
                comando.ExecuteNonQuery();

                //envia msj de confirmación
                MessageBox.Show("Cliente guardado con exito");
                //limpia variables en pantalla

                conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar los datos" + ex.Message);
            }
            finally { conexion.CloseConnection(); }
        }

        public void Modificar(string nombre, string celular, string email, string cedula, string direccion)
        {
            try
            {
                conexion.OpenConnection();


                string cadena = "update Clientes set " +
                    "Nombre = @Nombre, " +
                    "Celular = @Celular, " +
                    "Correo_Electronico = @Email " +
                    "Direccion = @Direccion"+
                    "Where Cedula = @Cedula";

                SqlCommand comando = new SqlCommand(cadena, conexion.Connection);

                // Aquí se deben agregar los parámetros correspondientes para evitar la inyección SQL.
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Celular", celular);
                comando.Parameters.AddWithValue("@Email", email);
                comando.Parameters.AddWithValue("@Cedula", cedula);
                comando.Parameters.AddWithValue("@Direccion", direccion);

                int cantidad_modificados = comando.ExecuteNonQuery();
                if (cantidad_modificados == 1)
                {
                    MessageBox.Show(" ----- Se Modificaron los Datos ----- ");
                }
                else
                {
                    MessageBox.Show(" ----- No Existe una Identificación con el Código Ingresado ----- ");
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
            finally
            {
                conexion.CloseConnection();
            }
        }

        public void BuscarEnFormulario(string cedula, string nombre, string celular, string email, string direccion, Creacion_Cliente formulario)
        {
            // Accedo a los textBox del Form Clientes usando "formulario.textBox", etc.
            // Luego, pasa los valores necesarios a tu método Buscar.
            Buscar(cedula, nombre, celular, email, direccion, formulario.textBox2, formulario.textBox3, formulario.textBox4, formulario.textBox5);
        }

        public void Buscar(string cedula, string nombre, string celular, string email, string direccion,
            System.Windows.Forms.TextBox txtNombre, System.Windows.Forms.TextBox txtCelular, System.Windows.Forms.TextBox txtEmail, System.Windows.Forms.TextBox txtDireccion)
        {
            //Si no hay datos ingresados que no me de resultado alguno.
            if (string.IsNullOrWhiteSpace(cedula) && string.IsNullOrWhiteSpace(nombre) && string.IsNullOrWhiteSpace
                (celular) && string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("Debes introducir al menos un dato para buscar.");
                return;
            }
            try
            {
                conexion.OpenConnection();

                string cadena = "SELECT Nombre, Celular, Correo_Electronico, Direccion, Cedula FROM Clientes " +
                                "WHERE (@Cedula = '' OR Cedula LIKE @Cedula) AND " +
                                "(@Nombre = '' OR Nombre LIKE @Nombre) AND " +
                                "(@Celular = '' OR Celular LIKE @Celular) AND " +
                                "(@Email = '' OR Correo_Electronico LIKE @Email) AND"+
                                "(@Direccion = '' OR Direccion LIKE @Email)";

                SqlCommand comando = new SqlCommand(cadena, conexion.Connection);
                comando.Parameters.AddWithValue("@Cedula", "%" + cedula + "%");
                comando.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                comando.Parameters.AddWithValue("@Celular", "%" + celular + "%");
                comando.Parameters.AddWithValue("@Email", "%" + email + "%");
                comando.Parameters.AddWithValue("@Direccion", "%" + direccion + "%");

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtCelular.Text = reader["Celular"].ToString();
                    txtEmail.Text = reader["Correo_Electronico"].ToString();
                    txtDireccion.Text = reader["Direccion"].ToString();
                }
                else
                {
                    txtNombre.Text = "";
                    txtCelular.Text = "";
                    txtEmail.Text = "";
                    txtDireccion.Text = "";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
            finally
            {
                conexion.CloseConnection();
            }
        }


        public void Eliminar(string cedula)
        {
            try
            {
                conexion.OpenConnection();

                string cadena = "delete from Clientes Where Cedula=" + cedula;
                SqlCommand comando = new SqlCommand(cadena, conexion.Connection);
                int cantidad_borrados = comando.ExecuteNonQuery();
                if (cantidad_borrados == 1)
                {
                    MessageBox.Show(" ----- El Registro fue Borrado ----- ");

                }
                else
                    MessageBox.Show("La Cedula No existe");
                

            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error al eliminar cliente" + ex.Message);
            }
            finally { conexion.CloseConnection(); }
        }



        public void BtnVerHistorial(DataGridView dataGridView1)
        {
            try
            {

                conexion.OpenConnection();
                //Tabla de datos en memoria
                DataTable dt = new DataTable();
                //DataAdapter es un objeto que almacena n numero de DataTables 
                SqlDataAdapter adaptador = new SqlDataAdapter("select * from Clientes", conexion.Connection);
                //Llena el adaptador con la instruccion sql
                adaptador.Fill(dt);
                //Cargar el datagridview1
                dataGridView1.DataSource = dt;
               
            }
            catch(Exception ex)
            {

                MessageBox.Show("Error al buscar historial" + ex.Message);

            }finally { conexion.CloseConnection(); }    
        }

    }

 }
