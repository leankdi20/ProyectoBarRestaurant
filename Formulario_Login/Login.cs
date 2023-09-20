using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ProyectoBarRestaurant.Clases;
using ProyectoBarRestaurant.Formulario_Login;

namespace ProyectoBarRestaurant.Formularios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void RelaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text== "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;

            }
        }

        private void txtPas_Enter(object sender, EventArgs e)
        {
            if (txtPas.Text == "CONTRASEÑA")
            {
                txtPas.Text = "";
                txtPas.ForeColor = Color.LightGray;
                txtPas.UseSystemPasswordChar = true;
            }
        }

        private void txtPas_Leave(object sender, EventArgs e)
        {
            if (txtPas.Text == "")
            {
                txtPas.Text = "CONTRASEÑA";
                txtPas.ForeColor = Color.DimGray;
                txtPas.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();   
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            RelaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            RelaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                string User = txtUser.Text;
                string Password = txtPas.Text;
                Class_Login login = new Class_Login(User, Password);

              
               
                if (login.VerificarUsuario())
                {
                    login.IngresarForm1();
                    this.Hide(); // Oculta el formulario actual (LoginForm)
                    MessageBox.Show("Bienvenido a Thunder");
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al introducir datos. " +ex.Message);
            }
        }

        private void linkpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecuperarContraseña rec = new RecuperarContraseña();
            rec.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
