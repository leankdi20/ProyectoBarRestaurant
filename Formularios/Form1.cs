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
using ProyectoBarRestaurant.Clases;
using ProyectoBarRestaurant.Formularios;
using ProyectoBarRestaurant.Formulario_Login;
using ProyectoBarRestaurant.Formulario_Administrador;

namespace ProyectoBarRestaurant
{
    public partial class Form1 : Form
    {
        
        private bool mesaCargada = false;   
        private Class_GestionBaseDatos gestionBaseDatos;
        

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
            Class_BotonRedondo.AplicarEstilo(buttonMesa1, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa2, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa3, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa4, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa5, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa6, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa7, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa8, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa9, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa10, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa14, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa15, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa16, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa18, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);

            Class_BotonRedondo.AplicarEstilo(buttonMesa20, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa21, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa22, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa23, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa24, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa25, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa26, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa27, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa28, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa29, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa30, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);
            Class_BotonRedondo.AplicarEstilo(buttonMesa31, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.White);

            Class_BotonRedondo.CambiarColor(buttonMesa11, System.Drawing.Color.DarkOliveGreen);
            Class_BotonRedondo.CambiarColor(buttonMesa12, System.Drawing.Color.DarkOliveGreen);
            Class_BotonRedondo.CambiarColor(buttonMesa13, System.Drawing.Color.DarkOliveGreen);
            Class_BotonRedondo.CambiarColor(buttonMesa17, System.Drawing.Color.DarkOliveGreen);
            Class_BotonRedondo.CambiarColor(buttonMesa19, System.Drawing.Color.DarkOliveGreen);


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
                if (MESA.NumeroMesa == 13)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa13.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa13.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 14)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa14.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa14.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 15)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa15.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa15.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 16)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa16.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa16.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 17)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa17.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa17.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 18)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa18.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa18.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 19)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa19.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa19.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 20)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa20.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa20.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 21)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa21.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa21.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 22)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa22.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa22.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 23)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa23.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa23.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 24)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa24.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa24.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 25)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa25.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa25.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 26)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa26.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa26.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 27)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa27.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa27.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 28)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa28.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa28.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 29)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa29.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa29.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 30)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa30.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa30.BackgroundImage = Properties.Resources.Fondo_panel_2;
                    }

                }
                if (MESA.NumeroMesa == 31)
                {
                    if (MESA.Estado_Mesa1 == "o")
                    {
                        this.buttonMesa31.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                    }
                    else
                    {
                        this.buttonMesa31.BackgroundImage = Properties.Resources.Fondo_panel_2;
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
        private void buttonMesa13_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 13)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa13.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa13.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 13;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }

        }

        private void buttonMesa14_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 14)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa14.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa14.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 14;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa15_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 15)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa15.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa15.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 15;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa16_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 16)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa16.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa16.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 16;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa17_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 17)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa17.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa17.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 17;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa18_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 18)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa18.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa18.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 18;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa19_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 19)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa19.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa19.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 19;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa20_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 20)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa20.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa20.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 20;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa21_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 21)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa21.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa21.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 21;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa22_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 22)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa22.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa22.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 22;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa23_Click(object sender, EventArgs e)
        { // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 23)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa23.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa23.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 23;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }

        }

        private void buttonMesa24_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 24)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa24.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa24.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 24;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa25_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 25)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa25.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa25.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 25;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa26_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 26)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa26.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa26.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 26;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa27_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 27)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa27.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa27.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 27;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa28_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 28)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa28.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa28.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 28;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa29_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 29)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa29.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa29.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 29;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa30_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 30)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa30.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa30.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 30;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }

        private void buttonMesa31_Click(object sender, EventArgs e)
        {
            // Obtener las imágenes que deseas comparar
            List<Mesa> mesas = new Class_GestionBaseDatos().RetornaEstadoMesa();

            bool mesaEncontrada = false;

            foreach (Mesa mesa in mesas)
            {
                if (mesa.NumeroMesa == 31)
                {
                    if (mesa.Estado_Mesa1 == "o")
                    {
                        mesaEncontrada = true;
                        MessageBox.Show("Cargando datos de la mesa...");
                        this.buttonMesa31.BackgroundImage = Properties.Resources.Fondo_panel2_OCUPADA;

                        // Crear una instancia del formulario ConsumoMesa
                        ConsumoMesa consumoMesaForm = new ConsumoMesa();

                        // Llamamos al método AbrirMesaOcupada para obtener la información de la mesa ocupada
                        Mesa mesaOcupada = gestionBaseDatos.AbrirMesaOcupada(mesa.NumeroMesa);
                        consumoMesaForm.LlenarDatosMesa(mesaOcupada);

                        consumoMesaForm.Show();

                    }
                    else
                    {

                        this.buttonMesa31.BackgroundImage = Properties.Resources.Fondo_panel_2;
                        MessageBox.Show("La mesa está libre.");
                    }
                    break; // Salir del bucle foreach una vez que se ha encontrado la mesa
                }
            }

            if (!mesaEncontrada)
            {
                MessageBox.Show("Mesa disponible");

                int NumeroMesaDef = 31;
                AperturaDeMesa aperturaDeMesa = new AperturaDeMesa(this, NumeroMesaDef);
                aperturaDeMesa.Show();
            }
        }
        //-----------------------------------------------------------------------------------//




        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();

            Login login = new Login();
            login.Show();
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
            this.buttonMesa13.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa14.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa15.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa16.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa17.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa18.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa19.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa20.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa21.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa22.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa23.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa24.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa25.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa26.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa27.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa28.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa29.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa30.BackgroundImage = Properties.Resources.Fondo_panel_2;
            this.buttonMesa31.BackgroundImage = Properties.Resources.Fondo_panel_2;


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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
             Administrador add = new Administrador();
            add.Show();
        }
    }
}
