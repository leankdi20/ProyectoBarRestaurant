using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBarRestaurant.Clases
{
    public class Class_BotonRedondo
    {

        private Color ColorFondo;



        public Class_BotonRedondo(Color colorFondo)
        {
            ColorFondo1 = colorFondo;
        }

        public Color ColorFondo1 { get => ColorFondo; set => ColorFondo = value; }




        public static void AplicarEstilo(Button boton, Color colorFondo, Color colorTexto)
        {
            boton.BackColor = colorFondo;
            boton.ForeColor = colorTexto;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(colorFondo, 0.2f);
            boton.FlatAppearance.MouseOverBackColor = ControlPaint.Dark(colorFondo, 0.1f);
            boton.Font = new Font("Arial", 10, FontStyle.Bold);

            // Crea la forma redonda al boton

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, boton.Width - 1, boton.Height - 1);
            boton.Region = new Region(path);

            // Manejar el evento MouseEnter para hacer el botón más grande al pasar el mouse
            boton.MouseEnter += (sender, e) =>
            {
                boton.Size = new Size(boton.Width + 10, boton.Height + 10);
            };

            // Manejar el evento MouseLeave para restaurar el tamaño original del botón
            boton.MouseLeave += (sender, e) =>
            {
                boton.Size = new Size(boton.Width - 10, boton.Height - 10);
            };
        }




        public static void CambiarColor(Button boton, Color ColorFondo)
        {
            boton.BackColor = ColorFondo;
        }
    }
}
