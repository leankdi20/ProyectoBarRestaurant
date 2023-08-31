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
    public partial class Historial_Mesas_Cobradas : Form
    {
        public Historial_Mesas_Cobradas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Historial_Mesas_Cobradas_Load(object sender, EventArgs e)
        {
            Class_GestionBaseDatos historial = new Class_GestionBaseDatos();
            historial.Historial_Mesas_Cobradas(dataGridView1, lblTotal);

          
        }
    }
}
