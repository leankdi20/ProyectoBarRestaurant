using ProyectoBarRestaurant.Formularios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBarRestaurant.Clases
{
    public class Class_Login 
    {
        Class_Conexion conexion = new Class_Conexion();

        private string User;
        private string Password;

        public string User1 { get => User; set => User = value; }
        public string Password1 { get => Password; set => Password = value; }

        public Class_Login(string user, string password)
        {
            User = user;
            Password = password;
        }

        public bool VerificarUsuario()
        {
           
                conexion.OpenConnection();


                string query = "SELECT COUNT(*) FROM [Restaurante].[dbo].[Login] WHERE [LoginName] = @User AND [Password] = @Password";
                SqlCommand command = new SqlCommand(query, conexion.Connection);
                command.Parameters.AddWithValue("@User", User);
                command.Parameters.AddWithValue("@Password", Password);

                int result = (int)command.ExecuteScalar();

                // Si el resultado es mayor que 0, significa que el usuario y contraseña son válidos
                if (result > 0)
                {
                    return true;
                    
                }
                else
                {
                    return false;
                }
                conexion.CloseConnection();
           
               
        }

        public void IngresarForm1()
        {
            try
            {
                if (VerificarUsuario())
                {
                    // Si el usuario es válido, crea y muestra el Form1
                    Form1 form1 = new Form1();
                    form1.Show();
                }
                else
                {
                    // Si el usuario no es válido, muestra un mensaje de error
                    MessageBox.Show("Usuario no existe.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex) {
                MessageBox.Show("Error al ingresar datos" + ex.Message);           
            }
        }

        

    }
}
