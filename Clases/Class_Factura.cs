using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using OfficeOpenXml;
using System.Xml.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using OfficeOpenXml.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics;

namespace ProyectoBarRestaurant
{
    internal class Class_Factura
    {
        //Cabeza de factura
        private string Numero_Factura;
        private string Numero_Mesa;
        
        //Facturar para Cliente:
        private string Nombre;
        private string Cedula;
        private string Direccion;
        private string Celular;
        private string Correo_Electronico;

        //Detalle del cuerpo de la factura
        private string Cantidad_Plato;
        private string Descripcion;
        private string Precio_Unitario;
        private string Total_Importe;
        private string Total_Final;

        //Metodos Get and Set
        public string numero_Factura { get => Numero_Factura; set => Numero_Factura = value; }
        public string numero_Mesa { get => Numero_Mesa; set => Numero_Mesa = value; }
        public string nombre { get => Nombre; set => Nombre = value; }
        public string cedula { get => Cedula; set => Cedula = value; }
        public string direccion { get => Direccion; set => Direccion = value; }
        public string celular { get => Celular; set => Celular = value; }
        public string cantidad_Plato { get => Cantidad_Plato; set => Cantidad_Plato = value; }
        public string descripcion { get => Descripcion; set => Descripcion = value; }
        public string precio_Unitario { get => Precio_Unitario; set => Precio_Unitario = value; }
        public string total_Importe { get => Total_Importe; set => Total_Importe = value; }
        public string total_FInal { get => Total_Final; set => Total_Final = value; }
        public string correo_Electronico { get => Correo_Electronico; set => Correo_Electronico = value; }
        public object HighDpiMode { get; private set; }



        // Constructor con sus respectivos Parametros
        public Class_Factura(string numero_Factura, string numero_Mesa, string nombre, string cedula, string direccion, 
                             string celular,string correo_electronico, string cantidad_Plato, string descripcion, string precio_Unitario, string total_Importe, string total_FInal)
        {
            Numero_Factura = numero_Factura;
            Numero_Mesa = numero_Mesa;
            Nombre = nombre;
            Cedula = cedula;
            Direccion = direccion;
            Celular = celular;
            Correo_Electronico = correo_electronico;
            Cantidad_Plato = cantidad_Plato;
            Descripcion = descripcion;
            Precio_Unitario = precio_Unitario;
            Total_Importe = total_Importe;
            Total_Final = total_FInal;
        }

        //Constructor Vacio
       public Class_Factura()
        {

        }

        Class_Conexion conexion = new Class_Conexion();



        public void BuscarFactura(DataGridView dataGridView1, String textBuscar)
        {
            try
            {


                conexion.OpenConnection();

                
                string consulta = "SELECT * FROM Factura WHERE UPPER(Fecha) LIKE '%" + textBuscar.ToUpper() + "%' OR UPPER(Numero_Factura) LIKE '%" + textBuscar.ToUpper() +"%' OR UPPER(Nombre) LIKE '%" + textBuscar.ToUpper() + "%' OR UPPER(Cedula) LIKE ' % " + textBuscar.ToUpper() +" % '";


                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);

                // Creo una tabla virtual de consulta
                DataTable dataTable = new DataTable();

                //Ahora hay que llenar el dataTable con lo que tiene el adaptador

                adaptador.Fill(dataTable);
                //ahora se va a reglejar en el siguiente tablero del diseño
                dataGridView1.DataSource = dataTable;

                SqlCommand comando = new SqlCommand(consulta, conexion.Connection);

                //Permite leer los datos en el DataTable y extraerlos.
                SqlDataReader lector;
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se encontro factura" + ex.Message);
            }
            finally
            {
                conexion.CloseConnection();
            }

        }



        // METODO DE DIA Y HORA 
        public string ObtenerDiaSemana()
        {
            DateTime fechaHoraActual = DateTime.Now;
            return fechaHoraActual.ToString("dddd dd-MM-yyyy");
        }

        public string ObtenerHora()
        {
            DateTime fechaHoraActual = DateTime.Now;
            return fechaHoraActual.ToString("hh:mm:ss tt");
        }


        public void Consulta(DataGridView dataGridView1)
        {
            try { 
                conexion.OpenConnection();  

            //Metodo para visualisar lo que hay en la base de datos

            string consulta = "select * from Clientes";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
                MessageBox.Show("Atención: " + ex.Message);
                //throw; // Vuelve a lanzar la excepción para manejarla en el nivel superior
            }
            finally { conexion.CloseConnection(); }

        }
        public DataTable Llenar_tabla()
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.OpenConnection();

                if (conexion.Estado)
                {
                    String consulta = "Select * from Clientes";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);

                    adaptador.Fill(dt);

                    conexion.CloseConnection();
                }
                else
                {
                    MessageBox.Show("Atención: No se pudo establecer conexion con la BD");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
                MessageBox.Show("Atención: " + ex.Message);
                //throw; // Vuelve a lanzar la excepción para manejarla en el nivel superior
            }
            finally { conexion.CloseConnection(); }
            return dt;
        }



        public void InsertarDatosEnFactura(DataGridView dataGridView, string numeroFactura, string numeroMesa,
                                     string nombre, string cedula, string direccion,
                                     string celular, string correoElectronico, string total_final)
        {
            conexion.OpenConnection();

            try
            {
                decimal totalSum = 0;

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    int cantidadMenu = Convert.ToInt32(row.Cells["Cantidad_Menu"].Value);
                    decimal precioUnitario = Convert.ToDecimal(row.Cells["Precio_Unitario"].Value);
                    decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

                    totalSum += total;

                    string descripcionMenu = row.Cells["NombreMenu"]?.Value?.ToString() ?? string.Empty;

                    //string descripcionMenu = row.Cells["NombreMenu"].Value.ToString(); // Obtener la descripción de la fila

                    string insertSql = "INSERT INTO Factura (Descripcion, Cantidad_Plato, Precio_Unitario, Total_Importe, " +
                                       "Numero_Factura, Numero_Mesa, Nombre, Cedula, Direccion, Celular, Correo_Electronico, Total_Final) " +
                                       "VALUES (@Descripcion, @Cantidad_Plato, @Precio_Unitario, @Total_Importe, " +
                                       "@Numero_Factura, @Numero_Mesa, @Nombre, @Cedula, @Direccion, @Celular, @Correo_Electronico, @Total_Final)";

                    using (SqlCommand insertCommand = new SqlCommand(insertSql, conexion.Connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Descripcion", descripcionMenu);
                        insertCommand.Parameters.AddWithValue("@Cantidad_Plato", cantidadMenu);
                        insertCommand.Parameters.AddWithValue("@Precio_Unitario", precioUnitario);
                        insertCommand.Parameters.AddWithValue("@Total_Importe", total);
                        insertCommand.Parameters.AddWithValue("@Numero_Factura", numeroFactura);
                        insertCommand.Parameters.AddWithValue("@Numero_Mesa", numeroMesa);  // Aquí se agrega el número de mesa
                        insertCommand.Parameters.AddWithValue("@Nombre", nombre);
                        insertCommand.Parameters.AddWithValue("@Cedula", cedula);
                        insertCommand.Parameters.AddWithValue("@Direccion", direccion);
                        insertCommand.Parameters.AddWithValue("@Celular", celular);
                        insertCommand.Parameters.AddWithValue("@Correo_Electronico", correoElectronico);
                        insertCommand.Parameters.AddWithValue("@Total_Final", total_final);

                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error durante la inserción: " + ex.Message);
            }
            finally
            {
                conexion.CloseConnection();
            }
        }

        public void ImprimirFacturaEnExcel(DataGridView dataGridView, string numeroFactura, string numeroMesa,
                                   string nombre, string cedula, string direccion,
                                   string celular, string correoElectronico, string total_final, string fecha,string numeroMesaSeleccionado)
        {
          
            
            // Realiza la consulta SQL para obtener los nombres de columna
            string consultaColumnasSql = @"SELECT FechaApertura, Hora, Cantidad_Comenzales, 
                                Camareros.Nombres AS NombreCamarero, Menu.Descripcion AS NombreMenu, 
                                Cantidad_Menu, Precio_Unitario, Cantidad_Menu * Total AS Total
                            FROM MESA
                            INNER JOIN Camareros ON MESA.Codigo_Camarero = Camareros.Codigo
                            INNER JOIN Menu ON MESA.Codigo_Menu = Menu.Codigo
                            WHERE NumeroMesa = @NumeroMesa";

            SqlCommand columnasCmd = new SqlCommand(consultaColumnasSql, conexion.Connection);
            columnasCmd.Parameters.AddWithValue("@NumeroMesa", numeroMesaSeleccionado);

            List<string> nombresColumnas = new List<string>();

            try
            {
                conexion.OpenConnection();
                SqlDataReader columnasReader = columnasCmd.ExecuteReader();

                for (int i = 0; i < columnasReader.FieldCount; i++)
                {
                    nombresColumnas.Add(columnasReader.GetName(i));
                }

                columnasReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los nombres de columna: " + ex.Message);
                return;
            }
            finally
            {
                conexion.CloseConnection();
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Configura el contexto de licencia

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Factura");

                // Merge y formato del título "FACTURA"
                worksheet.Cells["C1:E1"].Merge = true; // Combinar celdas C1, D1 y E1
                worksheet.Cells["C1:E1"].Value = "FACTURA";
                worksheet.Cells["C1:E1"].Style.Font.Size = 16; // Tamaño de fuente
                worksheet.Cells["C1:E1"].Style.Font.Bold = true; // Negrita
                worksheet.Cells["C1:E1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Alineación centrada

                // Encabezado
                worksheet.Cells["A3:B3"].Merge = true;
                worksheet.Cells["A3:B3"].Value = "DATOS DEL RESTAURANTE";
                worksheet.Cells["A4"].Value = "Direccion:";
                worksheet.Cells["B4"].Value = " Provincia de Alajuela, Alajuela.";

                worksheet.Cells["A5"].Value = "Teléfono:";
                worksheet.Cells["B5"].Value = "(506) 24382417";

                worksheet.Cells["F3"].Value = "Fecha:";
                worksheet.Cells["G3"].Value = fecha;
                worksheet.Cells["F4"].Value = "Factura #:";
                worksheet.Cells["G4"].Value = numeroFactura;
                worksheet.Cells["F5"].Value = "Número de Mesa:";
                worksheet.Cells["G5"].Value = numeroMesa;

                // Espacio
                worksheet.Cells["A6:G6"].Value = ""; // Deja una línea en blanco

                //Datos del Cliente
                worksheet.Cells["A7:B7"].Value = "Factura para:";
                worksheet.Cells["A8"].Value = "Nombre:";
                worksheet.Cells["B8"].Value = nombre;
                worksheet.Cells["A9"].Value = "Cedula:";
                worksheet.Cells["B9"].Value = cedula;
                worksheet.Cells["A10"].Value = "Dirección:";
                worksheet.Cells["B10"].Value = direccion;
                worksheet.Cells["A11"].Value = "Teléfono:";
                worksheet.Cells["B11"].Value = celular;
                worksheet.Cells["A12"].Value = "Email:";
                worksheet.Cells["B12"].Value = correoElectronico;

                worksheet.Cells["A13:G13"].Value = ""; // Deja una línea en blanco

                
                worksheet.Cells["A14"].Value = "Descripción";
                worksheet.Cells["B14"].Value = "Cantidad";
                worksheet.Cells["C14"].Value = "Precio";
                worksheet.Cells["D14"].Value = " Total";
                int[] columnIndexToExport = new int[] { 4, 5, 6, 7 }; // Índices de las columnas a exportar
                int rowIndex = 15; // Fila inicial para los datos en la hoja de Excel

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    for (int colIndex = 0; colIndex < dataGridView.ColumnCount; colIndex++)
                    {
                        if (columnIndexToExport.Contains(colIndex)) // Verificar si es una columna a exportar
                        {
                            object cellValue = row.Cells[colIndex]?.Value;
                            worksheet.Cells[rowIndex, colIndex - 4 + 1].Value = cellValue;
                        }
                    }

                    rowIndex++;
                }
                // Autoajustar el ancho de las columnas para que se adapten al contenido
                worksheet.Cells.AutoFitColumns();

                //Total Final
                worksheet.Cells[rowIndex, 3].Value = "Total Final:"; // Columna E
                worksheet.Cells[rowIndex, 4].Value = total_final;    // Columna F
                // Guardar el archivo
                string rutaArchivo = "C:\\Users\\Leandro\\Desktop\\Borrador\\Facturas-(" + numeroFactura + ")-.xlsx";
                FileInfo excelFile = new FileInfo(rutaArchivo);
                excelPackage.SaveAs(excelFile);

                // Abrir el archivo
                Process.Start(rutaArchivo);
            }
        }




        

        public void ConsultaFactura(DataGridView dataGridView1)
        {
            try
            {
                conexion.OpenConnection();

                //Metodo para visualisar lo que hay en la base de datos

                string consulta = "select * from Factura";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
                MessageBox.Show("Atención: " + ex.Message);
                //throw; // Vuelve a lanzar la excepción para manejarla en el nivel superior
            }
            finally { conexion.CloseConnection(); }

        }
        public DataTable Llenar_tablaFactura()
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.OpenConnection();

                if (conexion.Estado)
                {
                    String consulta = "Select * from Factura";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);

                    adaptador.Fill(dt);

                    conexion.CloseConnection();
                }
                else
                {
                    MessageBox.Show("Atención: No se pudo establecer conexion con la BD");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
                MessageBox.Show("Atención: " + ex.Message);
                //throw; // Vuelve a lanzar la excepción para manejarla en el nivel superior
            }
            finally { conexion.CloseConnection(); }
            return dt;
        }










    }
}
