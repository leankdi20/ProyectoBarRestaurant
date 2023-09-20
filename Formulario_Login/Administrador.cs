using ProyectoBarRestaurant.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoBarRestaurant.Formulario_Administrador
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
            this.MinimumSize = new Size(400, 300);
            this.MaximumSize = new Size(1200, 800);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Class_CrearAdmin log = new Class_CrearAdmin();
                log.AddAdmin(txtUserID.Text,txtLoginName.Text, txtPassword.Text,
                    txtFirstName.Text, txtLastName.Text, txtPosition.Text, txtEmail.Text);
                log.Consulta(dataGridView1);

                txtEmail.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtLoginName.Text = "";
                txtPassword.Text = "";
                txtPosition.Text = "";
                txtUserID.Text = "";

            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error en el sistema." + ex.Message);
            }
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            Class_CrearAdmin llenar = new Class_CrearAdmin();
            llenar.Consulta(dataGridView1);
            llenar.Llenar_tabla();
            Width = 800;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Obtén los valores de las celdas y asígnalos a los TextBox correspondientes
                    txtUserID.Text = row.Cells[1].Value.ToString();
                    txtLoginName.Text = row.Cells[2].Value.ToString();
                    txtPassword.Text = row.Cells[3].Value.ToString();
                    txtFirstName.Text = row.Cells[4].Value.ToString();
                    txtLastName.Text = row.Cells[5].Value.ToString();
                    txtPosition.Text = row.Cells[6].Value.ToString();
                    txtEmail.Text = row.Cells[7].Value.ToString();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Class_CrearAdmin log = new Class_CrearAdmin();
            log.Modificar(txtUserID.Text,txtLoginName.Text,txtPassword.Text, 
                txtFirstName.Text,txtLastName.Text,txtPosition.Text,txtEmail.Text);
            log.Consulta(dataGridView1);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Class_CrearAdmin log = new Class_CrearAdmin();
            log.Eliminar(txtUserID.Text);
            log.Consulta(dataGridView1);
        }

       
    }
}
