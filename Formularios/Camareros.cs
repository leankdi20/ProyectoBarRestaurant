using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoBarRestaurant
{
    public partial class Camareros : Form
    {

        Class_GestionBaseDatos menu = new Class_GestionBaseDatos();
        Class_Empleado camarero = new Class_Empleado();

        Class_Conexion conexion = new Class_Conexion();

        public Camareros()
        {
            InitializeComponent();

        }
        public byte[] ImageToByteArray(System.Drawing.Image imagen)
        {
            MemoryStream ms = new MemoryStream();
            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //Boton Ingresar
        private void button2_Click(object sender, EventArgs e)
        {
            camarero.Ingresar(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value, pictureBox1.Image);

            // Limpia los campos de texto después de ingresar los datos
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            // Opcionalmente, puedes restablecer dateTimePicker1 y pictureBox1 según tus necesidades
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.Image = null;
        }

        //Boton Modificar
        private void button3_Click(object sender, EventArgs e)
        {
            camarero.Modificar(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value, textBox1.Text);


        }

        private void Camareros_Load(object sender, EventArgs e)
        {
            camarero.Consulta(dataGridView1);
            camarero.llenar_tabla();
            this.Width = 820;
            this.Height = 690;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Obtén los valores de las celdas y asígnalos a los TextBox correspondientes
                    textBox1.Text = row.Cells[0].Value.ToString();
                    textBox2.Text = row.Cells[1].Value.ToString();
                    textBox3.Text = row.Cells[2].Value.ToString();
                    textBox4.Text = row.Cells[3].Value.ToString();
                    textBox5.Text = row.Cells[4].Value.ToString();
                    dateTimePicker1.Text = row.Cells[5].Value.ToString();

                    // Verificar que la columna "Imagen" no sea nula
                    if (!Convert.IsDBNull(row.Cells[6].Value))
                    {
                        byte[] imagenBytes = (byte[])row.Cells[6].Value;
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // Si la imagen es nula, puedes asignar una imagen por defecto o limpiar el pictureBox
                        pictureBox1.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Obtén los valores de las celdas y asígnalos a los TextBox correspondientes
                    textBox1.Text = row.Cells[0].Value.ToString();
                    textBox2.Text = row.Cells[1].Value.ToString();
                    textBox3.Text = row.Cells[2].Value.ToString();
                    textBox4.Text = row.Cells[3].Value.ToString();
                    textBox5.Text = row.Cells[4].Value.ToString();
                    dateTimePicker1.Text = row.Cells[5].Value.ToString();

                    // Verificar que la columna "Imagen" no sea nula
                    if (!Convert.IsDBNull(row.Cells[6].Value))
                    {
                        byte[] imagenBytes = (byte[])row.Cells[6].Value;
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // Si la imagen es nula, puedes asignar una imagen por defecto o limpiar el pictureBox
                        pictureBox1.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //Boton Eliminar
        private void button5_Click(object sender, EventArgs e)
        {
            camarero.Eliminar(textBox1.Text);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void Refrescar_Click(object sender, EventArgs e)
        {
            camarero.Consulta(dataGridView1);
            camarero.llenar_tabla();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog Seleccionar = new OpenFileDialog();
            Seleccionar.Filter = "Imagenes|*.jpg; *.png";
            Seleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Seleccionar.Title = "Seleccionar Imagen";

            if (Seleccionar.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(Seleccionar.FileName);
            }
        }


        //Verificar empleado
        private void button4_Click(object sender, EventArgs e)
        {
            conexion.OpenConnection();
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from Camareros Where Codigo=" + textBox1.Text, conexion.Connection);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                    textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                    textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                    dateTimePicker1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);

                    // Verificar que la columna "Imagen" existe en el DataTable y no es nula
                    if (!Convert.IsDBNull(dt.Rows[0]["Imagen"]))
                    {
                        byte[] imagenBytes = (byte[])dt.Rows[0]["Imagen"];
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // Si la imagen es nula, puedes asignar una imagen por defecto o limpiar el pictureBox
                        pictureBox1.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("El código no existe en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar: " + ex.Message);
            }
            conexion.CloseConnection();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpia los campos de texto después de ingresar los datos
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            // Opcionalmente, puedes restablecer dateTimePicker1 y pictureBox1 según tus necesidades
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.Image = null;
        }
    }
}
