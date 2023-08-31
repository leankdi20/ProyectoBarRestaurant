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
    public partial class Creacion_Cliente : Form
    {
        Class_Cliente cl = new Class_Cliente();

        public Creacion_Cliente()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            cl.Ingresar(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cl.Modificar(textBox2.Text,textBox3.Text, textBox4.Text, textBox5.Text, textBox1.Text);

            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            Class_Cliente cliente = new Class_Cliente();
            cliente.BuscarEnFormulario(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,textBox5.Text, this);
            

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cl.Eliminar(textBox1.Text);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lista_Cliente lista = new Lista_Cliente();
            lista.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
