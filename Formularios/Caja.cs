using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoBarRestaurant
{
    public partial class Caja : Form


    {
        Class_Conexion conexion = new Class_Conexion();
        Mesa mesa = new Mesa();
        public List<Mesa> ListaMesas { get; set; }


        public Caja()
        {
            InitializeComponent();

        }

        private void Caja_Load(object sender, EventArgs e)
        {
            this.Height = 570;
            // Establecer la posición del formulario en la pantalla
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            llenacombobox();
            textBox3.Show();

            dataGridView1.Columns[6].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[7].DefaultCellStyle.Format = "N2";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ver_Consumo consumo = new Ver_Consumo();
            consumo.Show();
                   
        }


        public void llenacombobox()
        {

            // Se declara una variable de tipo SqlConnection
            conexion.OpenConnection();
            try
            {
                // Código para llenar el comboBox
                DataSet ds = new DataSet();
                // Indicamos la consulta en SQL, reemplaza "Nombres" con la columna correcta que contiene los nombres de los camareros
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
                    dataGridView1.DataSource = dataTable;

                    //Llama el nombre del camarero
                    if (dataTable.Rows.Count > 0)
                    {
                        string nombreCamarero = dataTable.Rows[0]["NombreCamarero"].ToString();
                        textBox2.Text = nombreCamarero;
                    }
                    else
                    {
                        textBox2.Text = ""; // Si no hay datos, muestra un campo vacío en el textBox2
                    }
                    // Calcula y muestra el total en el textBox3
                    if (dataTable.Rows.Count > 0)
                    {
                        decimal total = dataTable.AsEnumerable().Sum(row => row.Field<decimal>("Total"));
                        textBox3.Text = total.ToString("N2");
                        label6.Text = total.ToString("N2");
                        RealizarOperacionesConTotal(total);
                    }
                    else
                    {
                        textBox3.Text = "0"; // Si no hay datos, muestra 0 en el textBox3
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


        private void RealizarOperacionesConTotal(decimal total)
        {
            // Aquí puedes realizar tus operaciones matemáticas con el valor decimal total
            // Por ejemplo:
            if (total >= 0)
            {
                // Realiza operaciones específicas con el total positivo
                // ...
            }
            else
            {
                MessageBox.Show("No se puede cobrar la mesa hasta que no se pague.");
            }
        }




        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Tiquet_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (comboBox1.SelectedItem != null)
                {
                    // Obtiene el DataRowView seleccionado en el comboBox1
                    DataRowView selectedRow = (DataRowView)comboBox1.SelectedItem;
                    string numeroMesaSeleccionado = selectedRow["NumeroMesa"].ToString();


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

                    string nombreArchivo = @"C:\Users\Leandro\Desktop\Borrador\tiket_" + numeroMesaSeleccionado + "_" + DateTime.Now.Ticks + ".txt";


                    using (StreamWriter sw = new StreamWriter(nombreArchivo))
                    {
                        // Escribir los datos generales en el archivo
                        sw.WriteLine("Día: " + dataTable.Rows[0]["FechaApertura"].ToString());
                        sw.WriteLine("Hora apretura : " + dataTable.Rows[0]["Hora"].ToString());

                        sw.WriteLine("Numero de mesa: " + numeroMesaSeleccionado);
                        sw.WriteLine();

                        // Crear líneas de guiones para la tabla
                        string separador = new string('-', 56); // Ajusta el número de guiones según el ancho de la tabla

                        sw.WriteLine(separador);
                        sw.WriteLine("| Cantidad\t| Descripcion\t\t| Total\t\t|");
                        sw.WriteLine(separador);

                        // Recorrer el DataTable para obtener y escribir los datos en el archivo
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string cantidad = row["Cantidad_Menu"].ToString();
                            string descripcion = row["NombreMenu"].ToString();
                            string total = Convert.ToDecimal(row["Total"]).ToString("N2");
                            sw.WriteLine("| " + cantidad.PadRight(9) + "\t| " + descripcion.PadRight(20) + "\t| " + total.PadRight(10) + "\t|");
                        }

                        sw.WriteLine(separador);

                        // Obtener el total desde el textBox3
                        string totalTextBox = textBox3.Text;
                        sw.WriteLine("".PadRight(36) + "| TOTAL: " + totalTextBox.PadRight(10) + " |");

                        DateTime horaActual = DateTime.Now;
                        string horaActualFormateada = horaActual.ToString("hh.mm.ss");

                        // Imprime la hora actual

                        sw.WriteLine("Hora de cierre: " + horaActualFormateada);

                    }

                    MessageBox.Show("Tiket generado y guardado en " + nombreArchivo);
                    // Abrir el archivo de texto con la aplicación predeterminada
                    Process.Start(nombreArchivo);

                }
                else
                {
                    MessageBox.Show("Debe seleccionar una mesa del ComboBox antes de imprimir el ticket.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el tiket: " + ex.Message);
            }
        }

        private void btnLimpiarPantalla_Click(object sender, EventArgs e)
        {

            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label6.Text = "";
            label7.Text = "";
            dataGridView1.DataSource = null;

            //mesa.Limpiar_Pantalla( comboBox1.Text,  textBox2.Text,  textBox3.Text,  label6.Text, label7.Text, dataGridView1);

        }

        private void btnCobrarMesa_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.OpenConnection();

                decimal total1 = decimal.Parse(label6.Text);

                if (total1 <= 0)
                {



                    if (comboBox1.SelectedItem != null)
                    {


                        DataRowView selectedRow = (DataRowView)comboBox1.SelectedItem;
                        string numeroMesa = selectedRow["NumeroMesa"].ToString();
                        decimal total = decimal.Parse(textBox3.Text);




                        // Realiza una consulta SQL para insertar los datos en la tabla MesaCobrada
                        string consultaSql = "INSERT INTO MesaCobrada (FechaApertura, Hora, NumeroMesa, Total) VALUES (GETDATE(), GETDATE(), @NumeroMesa, @Total)";

                        SqlCommand cmd = new SqlCommand(consultaSql, conexion.Connection);
                        cmd.Parameters.AddWithValue("@NumeroMesa", numeroMesa);
                        cmd.Parameters.AddWithValue("@Total", total);

                        //este código obtiene el número de mesa seleccionado en el
                        //comboBox1 y el total de la cuenta ingresado en el textBox3, 
                        //para luego utilizar esta información y guardar los datos de
                        //la mesa cobrada en la base de datos.



                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {

                            MessageBox.Show("Datos de la mesa cobrada guardados correctamente.");


                            // Llamada al método para eliminar la fila de la tabla MESA
                            Mesa mesa = new Mesa();
                            mesa.Eliminar(numeroMesa);


                            comboBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            label6.Text = "";
                            label7.Text = "";
                            dataGridView1.DataSource = null;

                            MessageBox.Show("La mesa se eliminó correctamente. ");

                            if (numeroMesa.Equals("1")) {
                                Form1 form1 = new Form1();
                                form1.buttonMesa1.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }
                            if (numeroMesa.Equals("2"))
                            {
                                Form1 form1 = new Form1();
                                form1.buttonMesa2.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }
                            if (numeroMesa.Equals("3"))
                            {
                                Form1 form1 = new Form1();
                                form1.buttonMesa3.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }
                            if (numeroMesa.Equals("4"))
                            {
                                Form1 form1 = new Form1();
                                form1.buttonMesa4.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }
                            if (numeroMesa.Equals("5"))
                            {
                                Form1 form1 = new Form1();
                                form1.buttonMesa5.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }
                            if (numeroMesa.Equals("6"))
                            {
                                Form1 form1 = new Form1();
                                form1.buttonMesa6.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }
                            if (numeroMesa.Equals("7"))
                            {
                                Form1 form1 = new Form1();
                                form1.buttonMesa7.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }
                            if (numeroMesa.Equals("8"))
                            {
                                Form1 form1 = new Form1();
                                form1.buttonMesa8.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }
                            if (numeroMesa.Equals("9"))
                            {
                                Form1 form1 = new Form1();
                                form1.buttonMesa9.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }
                            if (numeroMesa.Equals("10"))
                            {
                                Form1 form1 = new Form1();
                                form1.buttonMesa10.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }
                            if (numeroMesa.Equals("11"))
                            {
                                Form1 form1 = new Form1();
                                form1.buttonMesa11.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }
                            if (numeroMesa.Equals("12"))
                            {
                                Form1 form1 = new Form1();
                                form1.buttonMesa12.BackgroundImage = Properties.Resources.Fondo_panel_2;
                            }


                        }
                        else
                        {
                            MessageBox.Show("No se pudieron guardar los datos de la mesa cobrada.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una mesa del ComboBox antes de cobrar.");
                    }

                }
                else
                {
                    MessageBox.Show("No se puede cobrar la mesa hasta que no se pague.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos de la mesa cobrada: " + ex.Message);
            }
            finally
            {
                conexion.CloseConnection();
            }
        }
    






        //Ingresa el efectivo del cobro de la mesa
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            
                // Verifica que el textBox1 contenga un valor numérico válido
                if (decimal.TryParse(textBox1.Text, out decimal montoIngresado))
                {
                    // Obtén el total actual del textBox3
                    if (decimal.TryParse(textBox3.Text, out decimal totalActual))
                    {
                        // Realiza la resta
                        decimal resta = totalActual - montoIngresado;

                        // Actualiza el label6 con el nuevo total
                        label6.Text = resta.ToString("N2");

                        // Actualiza el label7 con el faltante (si es negativo) o el excedente (si es positivo)
                        label7.Text = (resta >= 0) ? "0.00" : (-resta).ToString("N2");
                    }
                }
                else
                {
                    // Si el valor ingresado no es numérico válido, muestra 0 en el label6 y el textBox1
                    label6.Text = textBox3.Text;
                    label7.Text = "0.00";
                }


  

        }

        private void btnHistorialMesaCob_Click(object sender, EventArgs e)
        {
            Historial_Mesas_Cobradas historial = new Historial_Mesas_Cobradas();
            historial.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Facturacion fc = new Facturacion();
            fc.Show();

        }
        
        private void btnCierreCaja_Click(object sender, EventArgs e)
        {
            Cierre_Caja cierre = new Cierre_Caja();
            cierre.Show();
        }
    }
        
}
