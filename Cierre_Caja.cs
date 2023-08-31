using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBarRestaurant
{
    public partial class Cierre_Caja : Form
    {
       
        public Cierre_Caja()
        {
            InitializeComponent();
        }

        private void Cierre_Caja_Load(object sender, EventArgs e)
        {
            Class_CierreCaja cierre = new Class_CierreCaja();
            cierre.LlamaCierreCaja(dataGridView1,textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            try
            {

                Class_CierreCaja cierre = new Class_CierreCaja();

                cierre.BtnCerrarCaja(textBox1.Text);

                cierre.EliminarMesaCobrada();

            }catch (Exception ex)
            {
                MessageBox.Show("No hay datos por cerrar" +  ex.Message);
            }
        }
    }
}
