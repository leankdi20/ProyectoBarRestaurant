using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Drawing2D;

namespace ProyectoBarRestaurant
{
    public partial class Form1 : Form
    {
        private int rotationAngle = 0;

        //Prueba de cambiar de color cuando se Cargue la Mesa 1
        private bool mesaCargada = false;
        private ConsumoMesa consumoMesaForm;
        private Class_GestionBaseDatos gestionBaseDatos;
        // Otras cosas en el Form1...

        ArrayList estadoBotones = new ArrayList();
        public bool MesaCargada
        {
            get { return mesaCargada; }
            set
            {
                mesaCargada = value;
                if (mesaCargada)
                {
                    buttonMesa1.BackColor = Color.Red;
                }
                else
                {
                    // Si la mesa no está cargada, puedes cambiar el color del botón de vuelta a su estado original.
                    buttonMesa1.BackColor = SystemColors.ControlDark; // Cambia "Default" al color que desees.
                }
            }
        }





        public Form1()
        {
            InitializeComponent();
           
            
            this.WindowState = FormWindowState.Maximized;
            
            gestionBaseDatos = new Class_GestionBaseDatos();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            

            timer1.Start();

        }



        public void Actualizar_Botones(List<Mesa> mesas)
        {


            // Ahora puedes usar la lista "mesas" como desees
            foreach (Mesa MESA in mesas)
            {
                if (MESA.NumeroMesa == 1)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa1.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {

                        this.buttonMesa1.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 2)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa2.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;


                    }
                    else
                    {
                        this.buttonMesa2.BackgroundImage = Properties.Resources.Fondo_panel_2;

                    }

                }
                if (MESA.NumeroMesa == 3)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa3.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {

                        this.buttonMesa3.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 4)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa4.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {

                        this.buttonMesa4.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 5)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa5.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;
                    }
                    else
                    {

                        this.buttonMesa5.BackgroundImage = Properties.Resources.Fondo_panel_2;

                    }

                }
                if (MESA.NumeroMesa == 6)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa6.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {

                        this.buttonMesa6.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 7)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa7.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa7.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 8)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa8.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa8.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 9)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa9.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa9.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 10)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa10.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa10.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 11)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa11.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa12.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 12)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa12.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa12.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
            }
        }




        private void timer1_Tick_1(object sender, EventArgs e)
        {
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();
            Actualizar_Botones(mesas);
            label2.Text = DateTime.Now.ToString("HH:mm:ss  tt");

          
        }

  



        //BOTON PARA ABRIR MESA1
        private void buttonMesa1_Click(object sender, EventArgs e)
        {// Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();
            
            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 1)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa1.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {
                        
                        this.buttonMesa1.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 1;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }

        }




        private void buttonMesa2_Click(object sender, EventArgs e)
        {

            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 2)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa2.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa2.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");
                int NumeroMesaDef = 2;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }


        }
        private void buttonMesa3_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 3)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa3.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa3.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 3;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }

        }

        private void buttonMesa4_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 4)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa4.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa4.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 4;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa5_Click(object sender, EventArgs e)
        { // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 5)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa5.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa5.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");
                int NumeroMesaDef = 5;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa6_Click(object sender, EventArgs e)
        { // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 6)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa6.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa6.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 6;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa7_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 7)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa7.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa7.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 7;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa8_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 8)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa8.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa8.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 8;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa9_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 9)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa9.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa9.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");
                int NumeroMesaDef = 9;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa10_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 10)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa10.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa10.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 10;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }

        }

        private void buttonMesa11_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 11)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa11.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa11.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");
                int NumeroMesaDef = 11;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa12_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 12)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa12.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa12.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 12;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }
        //-----------------------------------------------------------------------------------//






       
    
        
        
        
        


        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }


      

        private void button3_Click(object sender, EventArgs e)
        {
            Caja caja = new Caja();
            caja.FormClosing += Caja_FormClosing; // Suscribir al evento FormClosing de Caja
            caja.Show();
            this.Hide(); // Ocultar el formulario principal (Form1)
        }

        private void Caja_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show(); // Volver a mostrar el formulario principal (Form1) cuando Caja se cierra
            this.buttonMesa1.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa2.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa3.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa4.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa5.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa6.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa7.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa8.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa9.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa10.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa11.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa12.BackgroundImage = Properties.Resources.Fondo_panel_2;


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Camareros camareros = new Camareros();  
            camareros.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Comida comida = new Comida();
            comida.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            Creacion_Cliente client = new Creacion_Cliente();
            client.Show();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            Facturacion fc = new Facturacion();
            fc.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Historial_Ciere_Caja hist = new Historial_Ciere_Caja();
            hist.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.BackColor = Color.Transparent;
           
        }

       
    }
}
