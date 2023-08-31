using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBarRestaurant
{
    public partial class Comida : Form
    {
       Class_GestionBaseDatos menu = new Class_GestionBaseDatos();

        public Comida()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Colocar Metodo 
            menu.MostrarMenu(dataGridView1);
            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "N2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MantenimientoMenu mantenimiento = new MantenimientoMenu();
            mantenimiento.Show();
        }

        private void Comida_Load(object sender, EventArgs e)
        {
            
        }
    }
}
