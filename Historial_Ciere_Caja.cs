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
    public partial class Historial_Ciere_Caja : Form
    {
        public Historial_Ciere_Caja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Historial_Ciere_Caja_Load(object sender, EventArgs e)
        {
            Class_CierreCaja cr = new Class_CierreCaja();
            cr.llenar_tabla();
            cr.Consulta(dataGridView1);
        }
    }
}
