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
    public partial class Ver_Consumo : Form
    {
        public Ver_Consumo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ver_Consumo_Load(object sender, EventArgs e)
        {
           Mesa ServMesa = new Mesa();
            ServMesa.Consulta(dataGridView1);
            ServMesa.llenar_tabla();

            this.Width = 950;

        }
    }
}
