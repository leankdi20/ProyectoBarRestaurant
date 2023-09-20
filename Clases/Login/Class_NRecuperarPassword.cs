using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarRestaurant.Clases.Login
{
    public class Class_NRecuperarPassword
    {

        public string reconverPassword(string userRequesting)
        {
            return new Class_RecuoerarPassword().recoverPassword(userRequesting);
        }
    }
}
