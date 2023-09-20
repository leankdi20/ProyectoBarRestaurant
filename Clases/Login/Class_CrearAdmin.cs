using Microsoft.VisualBasic.ApplicationServices;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBarRestaurant.Clases
{
    public class Class_CrearAdmin
    {
        private string UserID;
        private string LoginName;
        private string Password;
        private string FirstName;
        private string LastName;
        private string Position;
        private string Email;

        

        public string UserID1 { get => UserID; set => UserID = value; }
        public string LoginName1 { get => LoginName; set => LoginName = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string FirstName1 { get => FirstName; set => FirstName = value; }
        public string LastName1 { get => LastName; set => LastName = value; }
        public string Position1 { get => Position; set => Position = value; }
        public string Email1 { get => Email; set => Email = value; }
        public Class_CrearAdmin(string userID, string loginName, string password,
           string firstName, string lastName, string position, string email)
        {
            UserID = userID;
            LoginName = loginName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            Email = email;
        }

        public Class_CrearAdmin()
        {

        }

        Class_Conexion conexion = new Class_Conexion(); 

        public void AddAdmin(string userID, string loginName, string password,
           string firstName, string lastName, string position, string email)
        {
            try
            {
                conexion.OpenConnection();

               
                    // Define cadena de inserción con parámetros
                    string cadena = "INSERT INTO Login (UserID, LoginName, Password, FirstName, LastName, Position, Email) " +
                                    "VALUES (@UserID, @LoginName, @Password, @FirstName, @LastName, @Position, @Email)";

                    // Define comando de ejecución
                    SqlCommand comando = new SqlCommand(cadena, conexion.Connection);

                // Agregar parámetros

                    comando.Parameters.AddWithValue("@UserID", userID);
                    comando.Parameters.AddWithValue("@LoginName", loginName);
                    comando.Parameters.AddWithValue("@Password", password);
                    comando.Parameters.AddWithValue("@FirstName", firstName);
                    comando.Parameters.AddWithValue("@LastName", lastName);
                    comando.Parameters.AddWithValue("@Position", position);
                    comando.Parameters.AddWithValue("@Email", email);

                   

                    // Ejecuta comando
                    comando.ExecuteNonQuery();

                    // Envía mensaje de confirmación
                    MessageBox.Show("Los Datos se Guardaron Correctamente");

                // Limpia variables en pantalla (esto no modificará los parámetros originales)
                userID = "";
                loginName = "";
                password = "";
                firstName = "";
                lastName = "";
                position = "";
                email = ""; 

                // Cierra la conexión
                conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al incluir empleado" + ex.Message);
            }
        }



        public void Modificar(string userID, string loginName, string password, string firstName, string lastName, string position, string email)
        {
            try
            {
                conexion.OpenConnection();

                string cadena = "UPDATE Login SET " +
                    "LoginName = @LoginName," +
                    "Password = @Password, " +
                    "FirstName = @FirstName, " + // Agrega una coma aquí
                    "LastName = @LastName, " +   // Agrega una coma aquí
                    "Position = @Position, " +   // Agrega una coma aquí
                    "Email = @Email " +          // Agrega una coma aquí
                    "WHERE UserID = @UserID";

                SqlCommand comando = new SqlCommand(cadena, conexion.Connection);

                // Aquí se deben agregar los parámetros correspondientes para evitar la inyección SQL.
                comando.Parameters.AddWithValue("@UserID", userID);
                comando.Parameters.AddWithValue("@LoginName", loginName);
                comando.Parameters.AddWithValue("@Password", password);
                comando.Parameters.AddWithValue("@FirstName", firstName);
                comando.Parameters.AddWithValue("@LastName", lastName);
                comando.Parameters.AddWithValue("@Position", position);
                comando.Parameters.AddWithValue("@Email", email);

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


        public void Eliminar(string userID)
        {
            try
            {
                conexion.OpenConnection();

                string cadena = "delete from Login Where UserID=" + userID;
                SqlCommand comando = new SqlCommand(cadena, conexion.Connection);
                int cantidad_borrados = comando.ExecuteNonQuery();
                if (cantidad_borrados == 1)
                {
                    MessageBox.Show(" ----- El Registro fue Borrado ----- ");

                }
                else
                    MessageBox.Show("La Cedula No existe");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar cliente" + ex.Message);
            }
            finally { conexion.CloseConnection(); }
        }




        public void Consulta(DataGridView dataGridView1)
        {

            //Metodo para visualisar lo que hay en la base de datos

            string consulta = "select * from Login";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        public DataTable Llenar_tabla()
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.OpenConnection();

                if (conexion.Estado)
                {
                    String consulta = "Select * from Login";
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
