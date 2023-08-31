using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoBarRestaurant
{
    public partial class MantenimientoMenu : Form
    {
        
        public MantenimientoMenu()
        {
            InitializeComponent();
        }

        //Ingresar
        private void button1_Click(object sender, EventArgs e)
        {
            Class_ServicioMenu ServMenu = new Class_ServicioMenu();
            ServMenu.Ingresar(textBox1.Text, comboBox1.Text, textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text);

        }
        //Modificar
        private void button2_Click(object sender, EventArgs e)
        {
            Class_ServicioMenu ServMenu = new Class_ServicioMenu();
            ServMenu.Modificar(comboBox1.Text,textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox1.Text);

        }

        //Eliminar
        private void button3_Click(object sender, EventArgs e)
        {
            Class_ServicioMenu ServMenu = new Class_ServicioMenu();
            ServMenu.Eliminar(textBox1.Text);
        }

        //Refrescar consulta
        private void button4_Click(object sender, EventArgs e)
        {
            Class_ServicioMenu ServMenu = new Class_ServicioMenu();
            ServMenu.Consulta(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se haya hecho clic en una fila válida (no en los encabezados)
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asignar los valores de la fila a los controles correspondientes
                textBox1.Text = row.Cells["Codigo"].Value.ToString();
                comboBox1.Text = row.Cells["Categoria"].Value.ToString();
                textBox2.Text = row.Cells["Descripcion"].Value.ToString();
                textBox3.Text = row.Cells["Precio_Unitario"].Value.ToString();
                textBox4.Text = row.Cells["Cantidad"].Value.ToString();
                textBox5.Text = row.Cells["Total"].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MantenimientoMenu_Load(object sender, EventArgs e)
        {
            Class_GestionBaseDatos menu = new Class_GestionBaseDatos();
            menu.Consulta(dataGridView1);
            menu.llenar_tabla();

            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "N2";

            this.Width= 1200;


        }
    }
}
