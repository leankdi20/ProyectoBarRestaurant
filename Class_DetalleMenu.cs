using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarRestaurant
{
   public class Class_DetalleMenu
    {


        private int Codigo;
        private String Categoria;
        private String Descripcion;
        private decimal Precio_Unitario;
        private int Cantidad;
        private decimal Total;



        public Class_DetalleMenu() 
        {
        
        
        }

        public int Codigo1 { get => Codigo; set => Codigo = value; }
        public string Categoria1 { get => Categoria; set => Categoria = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public decimal Precio_Unitario1 { get => Precio_Unitario; set => Precio_Unitario = value; }
        public int Cantidad1 { get => Cantidad; set => Cantidad = value; }
        public decimal Total1 { get => Total; set => Total = value; }


        

        public Class_DetalleMenu(int codigo1, string categoria1, string descripcion1, decimal precio_Unitario1, int cantidad1, decimal total1)
        {
            Codigo = codigo1;
            Categoria = categoria1;
            Descripcion = descripcion1;
            Precio_Unitario = precio_Unitario1;
            Cantidad = cantidad1;
            Total = total1;
        }
    }
}
