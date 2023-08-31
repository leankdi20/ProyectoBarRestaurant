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
    public partial class Facturas_Guardadas : Form
    {

        public Facturas_Guardadas()
        {
            InitializeComponent();
        }

        private void Facturas_Guardadas_Load(object sender, EventArgs e)
        {
            Class_Factura fc = new Class_Factura();
            fc.Llenar_tablaFactura();
            fc.ConsultaFactura(dataGridView1);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Class_Factura fc = new Class_Factura();
                fc.BuscarFactura(dataGridView1, textBuscar.Text);

            }catch(Exception ex) {
                MessageBox.Show("Error al intentar acceder a la Base de datos." + ex.Message);
            }
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            try 
            { 

            Class_Factura fc = new Class_Factura();
            fc.BuscarFactura(dataGridView1,textBuscar.Text);

             }catch(Exception ex) {
                MessageBox.Show("Error al intentar acceder a la Base de datos." + ex.Message);
            }
}
    }
}
