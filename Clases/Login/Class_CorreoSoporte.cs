using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarRestaurant.Clases.Login
{
    public class Class_CorreoSoporte: Class_RecuoerarPassword
    {
        public Class_CorreoSoporte() {

            RemitenteCorreo1 = "leanvarela6@gmail.com";
            Password1 = "puvsqjlvxfkcuova_";
            Host1 = "smtp.gmail.com";
            Port1 = 587;
            Ssl1 = true;

            InitializeSmtpClient();
        }
    }
}
