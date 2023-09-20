using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarRestaurant.Clases.Login
{
    public class Class_RecuoerarPassword
    {
        Class_Conexion conexion = new Class_Conexion();

        private SmtpClient smtpClient;


        private string remitenteCorreo;
        private string password;
        private string host;
        private int port;
        private bool ssl;

        protected string RemitenteCorreo1 { get => remitenteCorreo; set => remitenteCorreo = value; }
        protected string Password1 { get => password; set => password = value; }
        protected string Host1 { get => host; set => host = value; }
        protected int Port1 { get => port; set => port = value; }
        protected bool Ssl1 { get => ssl; set => ssl = value; }

        protected void InitializeSmtpClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(remitenteCorreo, password);
            smtpClient.Port = port;
            smtpClient.Host = host;
            smtpClient.EnableSsl = ssl;
        }


        public void SendMail(string subject, string body, List<string> destinatarioCorreo)
        {
            var mailMessage = new MailMessage();
            try
            {
                mailMessage.From = new MailAddress(remitenteCorreo);
                foreach (string mail in destinatarioCorreo)
                {
                    mailMessage.To.Add(mail);
                }
                mailMessage.Subject = subject;

                mailMessage.Body = body;

                mailMessage.Priority = MailPriority.Normal;
                smtpClient.Send(mailMessage);
            } catch (Exception ex)
            {

            }
            finally
            {
                mailMessage.Dispose();
                smtpClient.Dispose();

            }
        }

        public string recoverPassword(string usuarioSolicitado)
        {
            conexion.OpenConnection();
            using (var command = new SqlCommand())
            {
                command.Connection = conexion.Connection;
                command.CommandText = "select * from Login where LoginName=@LoginName or Email=@Email";
                command.Parameters.AddWithValue("@LoginName", usuarioSolicitado);
                command.Parameters.AddWithValue("@Email", usuarioSolicitado);
                command.CommandType = System.Data.CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read() == true)
                {
                    string nombreUsuario = reader.GetString(3);
                    string correoUsuario = reader.GetString(6);
                    string CuentaContraseña = reader.GetString(2);

                    var mailService = new Class_CorreoSoporte();
                    mailService.SendMail(
                        subject: "SISTEMA DE CAMELIDOS: Solicitud de recuperacion de contraseña",
                        body: "Hola, " + nombreUsuario + "\nUsted solicitó reciperar su contraseña. \n" +
                        "\nSin embargo, le pedimos que cambie su contraseña inmediatamente una vez que ingrese al sistema...",
                        destinatarioCorreo: new List<string> { correoUsuario }
                        );
                    return "Hola, " + nombreUsuario + "\nUsted solicitó recuperar su contraseña.\n" +
                        "Por favor revise su correo: " + correoUsuario +
                        "\nSin embargo, le pedimos que cambie su contraseña inmediatamente una vez que ingrese al sistema...";
                } else
                    return "Lo sentimos, no tiene una cuenta con ese correo o nombre del usuario";
            }
        }
    }


}

