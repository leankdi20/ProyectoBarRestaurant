using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Diagnostics;


namespace ProyectoBarRestaurant
{
    public partial class Facturacion : Form
    {

        Class_Conexion conexion = new Class_Conexion();

        Class_Factura fc;

        public Facturacion()
        {
            InitializeComponent();
            fc = new Class_Factura();
        }

       

        

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Facturacion_Load(object sender, EventArgs e)
        {
            llenacombobox();
            dataGridView2.Columns[6].DefaultCellStyle.Format = "N2";
            dataGridView2.Columns[7].DefaultCellStyle.Format = "N2";

            MostrarDiaHora();

            fc.Consulta(dataGridView1);
            fc.Llenar_tabla();
           

        }


        private void MostrarDiaHora()
        { 
            string FechaSemana = fc.ObtenerDiaSemana();
            string hora = fc.ObtenerHora();

            textFecha.Text = FechaSemana;
            textHora.Text = hora;
        }





        public void llenacombobox()
        {

            // Se declara una variable de tipo SqlConnection
            conexion.OpenConnection();
            try
            {
                // Código para llenar el comboBox
                DataSet ds = new DataSet();
                // Indicamos la consulta en SQL, los nombres de los camareros
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT NumeroMesa FROM MESA", conexion.Connection);
                // Se indica el nombre de la tabla
                da.Fill(ds, "MESA");

                // Creamos un objeto DataRow con un valor en blanco
                DataRow emptyRow = ds.Tables["MESA"].NewRow();
                emptyRow["NumeroMesa"] = DBNull.Value; // Puedes asignar un valor por defecto en lugar de ""

                // Agregamos la fila con valor en blanco al inicio de la tabla
                ds.Tables["MESA"].Rows.InsertAt(emptyRow, 0);

                comboBox1.DataSource = ds.Tables["MESA"].DefaultView;
                // Se especifica el campo de la tabla que será mostrado en el ComboBox
                comboBox1.DisplayMember = "NumeroMesa";
                // Se especifica el campo de la tabla que se utilizará como valor seleccionado en el ComboBox
                comboBox1.ValueMember = "NumeroMesa";

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró la mesa \n" + ex.Message);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica que haya un elemento seleccionado en el comboBox1
            if (comboBox1.SelectedItem != null)
            {
                // Obtiene el DataRowView seleccionado en el comboBox1
                DataRowView selectedRow = (DataRowView)comboBox1.SelectedItem;

                // Obtiene el número de mesa seleccionado en el comboBox1
                string numeroMesaSeleccionado = selectedRow["NumeroMesa"].ToString();

                try
                {
                    conexion.OpenConnection();

                    // Realiza una consulta SQL para obtener los datos de la mesa
                    string consultaSql = @"SELECT FechaApertura, Hora, Cantidad_Comenzales, 
                                        Camareros.Nombres AS NombreCamarero, Menu.Descripcion AS NombreMenu, 
                                        Cantidad_Menu, Precio_Unitario, Cantidad_Menu * Total AS Total
                                    FROM MESA
                                    INNER JOIN Camareros ON MESA.Codigo_Camarero = Camareros.Codigo
                                    INNER JOIN Menu ON MESA.Codigo_Menu = Menu.Codigo
                                    WHERE NumeroMesa = @NumeroMesa";

                    SqlCommand cmd = new SqlCommand(consultaSql, conexion.Connection);
                    cmd.Parameters.AddWithValue("@NumeroMesa", numeroMesaSeleccionado);

                    // Crea un DataTable para almacenar los resultados
                    DataTable dataTable = new DataTable();

                    // Crea un SqlDataAdapter para llenar el DataTable con los resultados de la consulta
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                    // Llena el DataTable con los datos de la consulta
                    dataAdapter.Fill(dataTable);

                    // Asigna el DataTable como fuente de datos para el dataGridView1
                    dataGridView2.DataSource = dataTable;

                    
                    if (dataTable.Rows.Count > 0)
                    {
                        decimal total = dataTable.AsEnumerable().Sum(row => row.Field<decimal>("Total"));
                        //textBox3.Text = total.ToString("N2");
                        lblTotal.Text = total.ToString("N2");
                    }
                    else
                    {
                        lblTotal.Text = "0.00"; // Si no hay datos, muestra 0 en el textBox3
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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Obtén los valores de las celdas y asígnalos a los TextBox correspondientes
                    textCedula.Text = row.Cells[0].Value.ToString();
                    textNombre.Text = row.Cells[1].Value.ToString();
                    textCelular.Text = row.Cells[2].Value.ToString();
                    textCorreo_Electronico.Text = row.Cells[3].Value.ToString();
                    textDireccion.Text = row.Cells[4].Value.ToString();
                   

                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btnImprimirFact_Click(object sender, EventArgs e)
        {

            try
            {
                // Obtén los valores de los TextBoxes y ComboBox
                string numeroFactura = textNumFactura.Text;
                string numeroMesa = comboBox1.Text;
                string nombre = textNombre.Text;
                string cedula = textCedula.Text;
                string direccion = textDireccion.Text;
                string celular = textCelular.Text;
                string correoElectronico = textCorreo_Electronico.Text;
                string total_final = lblTotal.Text;

                fc.InsertarDatosEnFactura(dataGridView2, numeroFactura, numeroMesa, nombre, cedula, direccion, celular, correoElectronico, total_final);
                MessageBox.Show("Datos insertados en la tabla Factura correctamente.");

                //Limpiar
                textNumFactura.Text = "";
                comboBox1.Text = "";
                textNombre.Text = "";
                textCedula.Text = "";
                textDireccion.Text = "";
                textCelular.Text = "";
                textCorreo_Electronico.Text = "";
                lblTotal.Text = "";



            }catch(Exception ex)
            {
                MessageBox.Show("Error al insertar datos en la factura: " + ex.Message);
            }
                

         //fc.ImprimirFacturaTxt(dataGridView2, numeroFactura, numeroMesa, nombre, cedula, direccion, celular, correoElectronico, total_final);
        }

        private void btnVerFacturas_Click(object sender, EventArgs e)
        {
            Facturas_Guardadas fg = new Facturas_Guardadas();
            fg.Show();
        }

        private void btnImprimirExcel_Click(object sender, EventArgs e)
        {
            // Obtiene el DataRowView seleccionado en el comboBox1
            DataRowView selectedRow = (DataRowView)comboBox1.SelectedItem;
            string numeroMesaSeleccionado = selectedRow["NumeroMesa"].ToString();
           
            Class_Factura fg = new Class_Factura();
            
            fg.ImprimirFacturaEnExcel(dataGridView2, textNumFactura.Text, comboBox1.Text, textNombre.Text, textCedula.Text, textDireccion.Text, textCelular.Text,
                                      textCorreo_Electronico.Text, lblTotal.Text, textFecha.Text, numeroMesaSeleccionado);
            MessageBox.Show("Factura Exportada en una hoja de calculo Excel. ");
        }
    }
}
