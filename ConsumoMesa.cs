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
    public partial class ConsumoMesa : Form
    {
        public Form1 form1;
        private Class_GestionBaseDatos gestionBaseDatos;

        private Mesa mesaOcupada;


        // Declara la variable miembro en la clase del formulario "Consumo"
        // private ConsumoMesa consumoMesaForm;
        // En el formulario del DataGridView1
        Class_Conexion conexion = new Class_Conexion();

        private Timer cronometro = new Timer();
        private DateTime horaInicio;






        public ConsumoMesa(AperturaDeMesa.Datos info, ConsumoMesa consumoMesaForm, Form1 form1)
        {
            InitializeComponent();
            textBox2.Text = Convert.ToString(info.NumeroMesa);
            textBox3.Text = info.Camarero;
            textBox4.Text = Convert.ToString(info.Comenzales);

            this.form1 = form1;




        }
        public ConsumoMesa()
        {
            InitializeComponent();
            gestionBaseDatos = new Class_GestionBaseDatos();

            
           
        }




        public void LlenarDatosMesa(Mesa mesa)
        {
            textBox2.Text = mesa.NumeroMesa.ToString();

            try
            {
                conexion.OpenConnection();

                string consultaSql = @"SELECT MESA.codigo_Menu, Menu.Categoria,
                            Cantidad_Comenzales, Camareros.Nombres AS NombreCamarero, 
                            Menu.Descripcion AS NombreMenu, Cantidad_Menu, Precio_Unitario, 
                            Cantidad_Menu * Total AS Total
                        FROM MESA
                        INNER JOIN Camareros ON MESA.Codigo_Camarero = Camareros.Codigo
                        INNER JOIN Menu ON MESA.codigo_Menu = Menu.Codigo
                        WHERE NumeroMesa = @NumeroMesa";

                SqlCommand cmd = new SqlCommand(consultaSql, conexion.Connection);
                cmd.Parameters.AddWithValue("@NumeroMesa", mesa.NumeroMesa);

                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);

                // Ocultar la columna "NombreCamarero" y "Cantidad_Comenzales" en el dataGridView2
                dataGridView2.DataSource = dataTable;
                dataGridView2.Columns["NombreCamarero"].Visible = false;
                dataGridView2.Columns["Cantidad_Comenzales"].Visible = false;

                // Agregar las columnas "Codigo del menu" y "Categoria" al dataGridView2
                dataGridView2.Columns["codigo_Menu"].HeaderText = "Código del Menú";

                dataGridView2.Columns["Categoria"].HeaderText = "Categoría";
                dataGridView2.Columns["NombreMenu"].HeaderText = "Nombre del Menú";
                dataGridView2.Columns["Cantidad_Menu"].HeaderText = "Cantidad";
                dataGridView2.Columns["Precio_Unitario"].HeaderText = "Precio Unitario";
                dataGridView2.Columns["Total"].HeaderText = "Total";

                //Llama el nombre del camarero y Comenzales
                if (dataTable.Rows.Count > 0)
                {
                    string nombreCamarero = dataTable.Rows[0]["NombreCamarero"].ToString();
                    textBox3.Text = nombreCamarero;

                    // Obtener la cantidad de comensales desde el DataTable
                    int cantidadComenzales = Convert.ToInt32(dataTable.Rows[0]["Cantidad_Comenzales"]);
                    // Mostrar la cantidad de comensales en textBox4
                    textBox4.Text = cantidadComenzales.ToString();
                }
                else
                {
                    textBox3.Text = ""; // Si no hay datos, muestra un campo vacío en el textBox3
                    textBox4.Text = "";
                }
                // Calcula y muestra el total en el textBox3
                if (dataTable.Rows.Count > 0)
                {
                    decimal total = dataTable.AsEnumerable().Sum(row => row.Field<decimal>("Total"));
                    //textBox3.Text = total.ToString("N2");
                    label9.Text = total.ToString("N2");
                    label13.Text = total.ToString("N2");
                }
                else
                {
                    label9.Text = "0"; // Si no hay datos, muestra 0
                    label13.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos de la mesa \n" + ex.Message);
            }
            finally
            {
                conexion.CloseConnection();
            }
        }








        private void ConsumoMesa_Load(object sender, EventArgs e)
        {
            this.Width = 1300;
            this.Height = 647;
            // Establecer la posición del formulario en la pantalla
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);



            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
            //dataGridView2.Columns[5].DefaultCellStyle.Format = "N2";
            //dataGridView2.Columns[4].DefaultCellStyle.Format = "N2";
            // CargarDatosDataGridView(mesaOcupada.NumeroMesa);


            Cantidad_Orden();


        }



        private void button2_Click(object sender, EventArgs e)
        {
            Comanda comanda = new Comanda();
            comanda.Size = new System.Drawing.Size(700, 406); // Establece el tamaño del formulario a 500 píxeles de ancho y 300 píxeles de alto
            comanda.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //Enviar Comanda
        private void button3_Click(object sender, EventArgs e)
        {

            Mesa Mesa1 = new Mesa();
            conexion.OpenConnection();
            // Obtener los otros parámetros necesarios para guardar en la base de datos
            int NUMERO_MESA = int.Parse(textBox2.Text); // Reemplaza ObtenerNumeroMesa() por el código adecuado para obtener el número de mesa.
            int CANTIDAD_COMENZALES = int.Parse(textBox4.Text); // Reemplaza ObtenerCantidadComensales() por el código adecuado para obtener la cantidad de comensales.

            int CANTIDAD_MENU = int.Parse(label11.Text); // Reemplaza ObtenerCantidadMenu() por el código adecuado para obtener la cantidad del menú o plato.
            string ESTADO_MESA = "o";

            string nombreCamarero = textBox3.Text;

            // Realiza una consulta SQL para obtener el CODIGO_CAMAREROS correspondiente al nombre del camarero
            int CODIGO_CAMAREROS = 0; // Inicializa el código del camarero como 0 (o cualquier otro valor predeterminado)

            // Consulta SQL para buscar el código del camarero por su nombre
            string consulta = "SELECT Codigo FROM Camareros WHERE Nombres = @Nombres";

            using (SqlCommand command = new SqlCommand(consulta, conexion.Connection))
            {
                // Agrega el parámetro al comando para evitar SQL Injection
                command.Parameters.AddWithValue("@Nombres", nombreCamarero);

                // Ejecuta la consulta y obtiene el resultado
                object resultado = command.ExecuteScalar();

                // Si se encontró el camarero, actualiza el valor de CODIGO_CAMAREROS
                if (resultado != null && resultado != DBNull.Value)
                {
                    CODIGO_CAMAREROS = Convert.ToInt32(resultado);
                }


            }


            List<int> codigosMenu = new List<int>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Verificamos que la fila no sea la fila de nueva entrada (si la tienes)
                if (!row.IsNewRow)
                {
                    // Accedemos al valor de la celda de la columna "Codigo"
                    // Asegúrate de que el nombre de la columna sea exactamente "Codigo" (mayúsculas y minúsculas).
                    string codigoMenuString = row.Cells["Codigo"].Value.ToString();

                    // Verifica que el valor en la celda sea convertible a un entero antes de obtenerlo.
                    if (int.TryParse(codigoMenuString, out int CODIGO_MENU))
                    {
                        codigosMenu.Add(CODIGO_MENU);
                    }
                    else
                    {
                        // Si la conversión falla, puedes manejar el error o ignorar el valor inválido.
                        // Por ejemplo, podrías mostrar un mensaje de error al usuario o simplemente no agregarlo a la lista.
                    }
                }
            }


            int primerCodigoMenu = codigosMenu.Count > 0 ? codigosMenu[0] : 0;

            // Llamar al método Ingresar pasando los parámetros requeridos

            Mesa1.Ingresar(NUMERO_MESA, CANTIDAD_COMENZALES, CODIGO_CAMAREROS, primerCodigoMenu, CANTIDAD_MENU, dataGridView1, ESTADO_MESA);

            MessageBox.Show("Se ingreso Comanda");

            conexion.CloseConnection();


            this.Close();


        }


        public void CargarDatosDataGridView(int numeroMesa)
        {
            dataGridView2.Rows.Clear();
            Class_GestionBaseDatos gestionBaseDatos = new Class_GestionBaseDatos();

            // Obtener la mesa ocupada desde la base de datos usando el método AbrirMesaOcupada
            Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(numeroMesa);

            // Llenar el DataGridView con los datos de la mesa ocupada
            if (mesaOcupada != null)
            {
                dataGridView2.Rows.Add(mesaOcupada.NumeroMesa, mesaOcupada.Cantidad_comenzales, mesaOcupada.Codigo_camareros, mesaOcupada.Estado_Mesa1);
                
            
            }



        }





      
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                try
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);

                    decimal sumaColumna5 = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        decimal valorColumna5 = Convert.ToDecimal(row.Cells[5].Value);
                        sumaColumna5 += valorColumna5;
                    }

                    // Actualizar el valor del textBox5 con la suma de la columna 5
                    label9.Text = sumaColumna5.ToString("N2");
                    label13.Text = sumaColumna5.ToString("N2");
                    Cantidad_Orden();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La lista está vacía. \n Por favor ingresar datos" + "\n" + ex);
                }

            }
            else
            {
                MessageBox.Show("No hay nada");
            }
        }


        //Borrar este boton
        private void button6_Click(object sender, EventArgs e)
        {
            Cantidad_Orden();

        }


        //Muestra la cantidad que de articulos que se está pidiendo en la orden.

        public void Cantidad_Orden()
        {

            // Variable para almacenar la suma de la columna "Cantidad"
            int sumaCantidad = 0;

            // Recorremos cada fila del DataGridView
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                // Verificamos si la celda de la columna "Cantidad" contiene un valor válido
                if (fila.Cells["Cant"].Value != null &&
                    int.TryParse(fila.Cells["Cant"].Value.ToString(), out int cantidad))
                {
                    // Sumamos el valor al total acumulado
                    sumaCantidad += cantidad;

                }
            }

            // Mostramos el resultado en un MessageBox
            //MessageBox.Show("La suma total de la columna 'Cantidad' es: " + sumaCantidad.ToString(), "Resultado de la suma", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label11.Text = sumaCantidad.ToString();
            label11.Show();

        }

      


       


      
    }
    
}
