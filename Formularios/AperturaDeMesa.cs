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

namespace ProyectoBarRestaurant
{
    public partial class AperturaDeMesa : Form
    {

        int contador = 0;
        private ConsumoMesa consumoMesaForm;
        private Form1 form1;
        private int NumeroMesaDef;

        Class_Conexion conexion = new Class_Conexion();
        public AperturaDeMesa(Form1 form1, int numeroMesaDef)
        {
            InitializeComponent();
            this.form1 = form1;
            this.NumeroMesaDef = numeroMesaDef;

            textBox3.Text = numeroMesaDef.ToString();
        }

        public struct Datos
        {
            public int NumeroMesa;
            public int Comenzales;
            public String Camarero;
            public List<String> lista;

        }
        //------------------------------------------------------//

        DateTime hoy = DateTime.Now;
       

        //_______________________________________________________//
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        
        //BOTON ABRIR MESA1
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Datos info;

                info.NumeroMesa = Convert.ToInt32(textBox3.Text);
                info.Comenzales = Convert.ToInt32(textBox4.Text);
                info.Camarero = comboBox1.Text;
                info.lista = new List<String>(new string[] { textBox3.Text, textBox4.Text, comboBox1.Text });

                ConsumoMesa obj_consumo = new ConsumoMesa(info, consumoMesaForm, form1);
                obj_consumo.Show();

                // Asignar la instancia del formulario ConsumoMesa a la variable consumoMesaForm
                consumoMesaForm = obj_consumo;

                // Luego puedes llamar al método EnviarDatosConsumoMesa
             
                // ...
                // consumo.Show();
                ConsumoMesa panelForm = new ConsumoMesa(info, consumoMesaForm, form1);
                panelForm.Size = new System.Drawing.Size(680, 626); // Establece el tamaño del formulario a 500 píxeles de ancho y 300 píxeles de alto
                                                                    // panelForm.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe ingresar datos antes de ingresar a la apertura de consumo"+ex);
            }
        }


        
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString("HH:mm:ss tt");

          
        }

      
        private void AperturaDeMesa_Load(object sender, EventArgs e)
        {
            // textBox1.Text = hoy.ToString("hh:mm:ss tt");
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            

            timer1.Start();  
            textBox2.Text = hoy.ToShortDateString();
            llenacombobox();
          

        }



        public void llenacombobox()
        {
            // Se declara una variable de tipo SqlConnection
            conexion.OpenConnection();

            // Código para llenar el comboBox
            DataSet ds = new DataSet();
            // Indicamos la consulta en SQL, reemplaza "Nombres" con la columna correcta que contiene los nombres de los camareros
            SqlDataAdapter da = new SqlDataAdapter("SELECT Nombres FROM Camareros", conexion.Connection);
            // Se indica el nombre de la tabla
            da.Fill(ds, "Camareros");
            comboBox1.DataSource = ds.Tables["Camareros"].DefaultView;
            // Se especifica el campo de la tabla que será mostrado en el ComboBox
            comboBox1.DisplayMember = "Nombres";
            // Se especifica el campo de la tabla que se utilizará como valor seleccionado en el ComboBox
            comboBox1.ValueMember = "Nombres";
        }

            private void button1_Click(object sender, EventArgs e)
        {
          

            contador++;
            textBox4.Text = contador.ToString();

            if (contador == 1)
            {
                pictureBox3.Visible = true; // Mostrar la imagen en el PictureBox
            }
            else if(contador == 2){
                pictureBox4.Visible = true;
            }
            else if (contador == 3)
            {
                pictureBox5.Visible = true;
            }
            else if (contador == 4)
            {
                pictureBox6.Visible = true;
            }
            else if (contador == 5)
            {
                pictureBox7.Visible = true;
            }
            else if (contador == 6)
            {
                pictureBox8.Visible = true;
            }
           
  

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (contador > 0)
            {
                contador--;
                textBox4.Text = contador.ToString();
            }
          
            if (contador == 5)
            {
                pictureBox8.Visible = false;
            }
            if (contador == 4)
            {
                pictureBox7.Visible = false;
            }
            if (contador == 3)
            {
                pictureBox6.Visible = false;
            }
            if (contador == 2)
            {
                pictureBox5.Visible = false;
            }
            if (contador == 1)
            {
                pictureBox4.Visible = false;
            }
            if (contador == 0)
            {
                pictureBox3.Visible = false;
            }
        }

       

       
    }
}
