using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoBarRestaurant.Class_GestionBaseDatos;

namespace ProyectoBarRestaurant
{
    public partial class Comanda : Form
    {

         


        Class_Conexion conexion = new Class_Conexion();
        Class_GestionBaseDatos menu = new Class_GestionBaseDatos();


        //private ConsumoMesa consumoMesaForm;



        //public ConsumoMesa ConsumoMesaForm { get; set; }
        private Dictionary<string, int> dataDictionary = new Dictionary<string, int>();


        public Comanda()
        {
            InitializeComponent();
            this.Load += Comanda_Load;
           

        }

        private void Comanda_Load(object sender, EventArgs e)
        {
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            menu.Consulta(dataGridView2);
            menu.llenar_tabla();
            //Comienza en 1 la cantidad
            numericUpDown1.Value = 1;

            // Le doy decimal a los totales de los precios 
            dataGridView2.Columns[5].DefaultCellStyle.Format = "N2";
            dataGridView2.Columns[3].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";







            // panel1.Size = new System.Drawing.Size(700, 406); // Establecer tamaño personalizado para el panel
            numericUpDown1.Size = new System.Drawing.Size(40, 270); // Establecer tamaño personalizado para el NumericUpDown
            this.Width = 750;
            this.Height = 680;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu.Buscar(dataGridView2, textBox1.Text);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                    textBox1.Text = row.Cells["Descripcion"].Value.ToString();
                    textBox2.Text = row.Cells["Precio_Unitario"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al hacer click" + ex);
            }
        }

        private void dataGridView2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {

                //Este codigo refiere a que se señalen las filas cuando se presionan las teclas arriba y abajo
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    if (dataGridView2.SelectedCells.Count > 0)
                    {
                        int rowIndex = dataGridView2.SelectedCells[0].RowIndex;

                        if (e.KeyCode == Keys.Up && rowIndex > 0)
                        {
                            rowIndex--;
                        }
                        else if (e.KeyCode == Keys.Down && rowIndex < dataGridView2.Rows.Count - 1)
                        {
                            rowIndex++;
                        }

                        if (rowIndex >= 0 && rowIndex < dataGridView2.Rows.Count)
                        {
                            DataGridViewRow row = dataGridView2.Rows[rowIndex];
                            textBox1.Text = row.Cells["Descripcion"].Value.ToString();
                            textBox2.Text = row.Cells["Precio_Unitario"].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error, No hay mas columnas: {ex}");
            }
        }

        //Boton Agregar
        private void button2_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        public void Agregar()
        {
            try
            {
                if (dataGridView2.SelectedCells.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView2.SelectedCells[0].OwningRow;

                    string columna0 = selectedRow.Cells[0].Value?.ToString();
                    string columna1 = selectedRow.Cells[1].Value?.ToString();
                    string columna2 = selectedRow.Cells[2].Value?.ToString();
                    decimal columna5 = Convert.ToDecimal(selectedRow.Cells[5].Value);

                    int cantidad = (int)numericUpDown1.Value;
                    decimal total = columna5 * cantidad;

                    // Variable para rastrear si se encontró una fila existente
                    bool found = false;
                    // Recorre cada fila en el dataGridView1 para buscar una fila existente con los mismos valores
                    foreach (DataGridViewRow existingRow in dataGridView1.Rows)
                    {
                        // Obtiene los valores de las celdas de la fila existente
                        string existingColumn0 = existingRow.Cells[0].Value?.ToString();
                        string existingColumn1 = existingRow.Cells[1].Value?.ToString();
                        string existingColumn2 = existingRow.Cells[2].Value?.ToString();
                        // Compara los valores de las columnas 0, 1 y 2 de la fila existente con los valores actuales
                        if (existingColumn0 == columna0 && existingColumn1 == columna1 && existingColumn2 == columna2)
                        {
                            // Si los valores coinciden, actualiza la cantidad y el total en la fila existente
                            int existingCantidad = (int)existingRow.Cells[3].Value;
                            decimal existingTotal = (decimal)existingRow.Cells[5].Value;

                            existingRow.Cells[3].Value = existingCantidad + cantidad;
                            existingRow.Cells[5].Value = existingTotal + total;
                            // Marca que se encontró una fila existente
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        dataGridView1.Rows.Add(columna0, columna1, columna2, cantidad, columna5, total);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al ingresar la fila" + ex);
            }
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Suprime el sonido de Windows cuando se presiona Enter
                Agregar(); // Simula hacer clic en el botón "Agregar"
            }
        }


        //Metodo para enviar al formulario ConsumoMesa

        public DataGridView DataGridViewComanda
        {
            get { return dataGridView1; }
        }


        //Boton enviar Comanda
        public void button3_Click(object sender, EventArgs e)

        {
            // Obtener la instancia del formulario "ConsumoMesa" si está abierto
            ConsumoMesa consumoMesaForm = Application.OpenForms.OfType<ConsumoMesa>().FirstOrDefault();
            if (consumoMesaForm != null)
            {
                DataGridView dataGridView1Comanda = dataGridView1; // Reemplaza con el nombre correcto del DataGridView de tu formulario actual

                DataGridView dataGridView1ConsumoMesa = consumoMesaForm.dataGridView1;

                foreach (DataGridViewRow rowComanda in dataGridView1Comanda.Rows)
                {
                    // Obtener los valores de las celdas de la fila actual en el DataGridView de Comanda
                    string columna0 = rowComanda.Cells[0].Value?.ToString();
                    string columna1 = rowComanda.Cells[1].Value?.ToString();
                    string columna2 = rowComanda.Cells[2].Value?.ToString();
                    int cantidad = Convert.ToInt32(rowComanda.Cells[3].Value);
                    decimal precioUnitario = Convert.ToDecimal(rowComanda.Cells[4].Value);
                    decimal total = Convert.ToDecimal(rowComanda.Cells[5].Value);

                    bool found = false;

                    // Iterar sobre las filas existentes en el DataGridView de ConsumoMesa
                    foreach (DataGridViewRow rowConsumoMesa in dataGridView1ConsumoMesa.Rows)
                    {
                        string existingColumna0 = rowConsumoMesa.Cells[0].Value?.ToString();
                        string existingColumna1 = rowConsumoMesa.Cells[1].Value?.ToString();
                        string existingColumna2 = rowConsumoMesa.Cells[2].Value?.ToString();

                        if (existingColumna0 == columna0 && existingColumna1 == columna1 && existingColumna2 == columna2)
                        {
                            int existingCantidad = Convert.ToInt32(rowConsumoMesa.Cells[3].Value);
                            decimal existingTotal = Convert.ToDecimal(rowConsumoMesa.Cells[5].Value);

                            rowConsumoMesa.Cells[3].Value = existingCantidad + cantidad;
                            rowConsumoMesa.Cells[5].Value = existingTotal + total;

                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells(dataGridView1ConsumoMesa, columna0, columna1, columna2, cantidad, precioUnitario, total);
                        dataGridView1ConsumoMesa.Rows.Add(newRow);
                    }
                }

                // Realizar la suma de la columna 5 en el dataGridView1ConsumoMesa
                decimal sumaColumna5 = 0;
                foreach (DataGridViewRow row in dataGridView1ConsumoMesa.Rows)
                {
                    decimal valorColumna5 = Convert.ToDecimal(row.Cells[5].Value);
                    sumaColumna5 += valorColumna5;
                }

                // Actualizar el valor del label en el formulario ConsumoMesa con la suma de la columna 5
                consumoMesaForm.label9.Text = sumaColumna5.ToString("N2");
                consumoMesaForm.label13.Text = sumaColumna5.ToString("N2");

                consumoMesaForm.Cantidad_Orden();

                this.Close();
            }
            else
            {
                MessageBox.Show("El formulario 'ConsumoMesa' no está abierto.");
            }

        }


        





        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
               
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Error al eliminar la fila. La lista está vacía. Por favor, ingresa datos primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la fila: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                  
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

       
    }
}
