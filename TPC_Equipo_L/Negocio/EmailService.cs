using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using dominio;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;
        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("api", "********d085");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "live.smtp.mailtrap.io";
        }
        public void armarCorreo(string emailDestino, string asunto, Usuario usuario)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@supermercadoprog3.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = cuerpo;
            email.Body = "<h1>Bienvenido " + usuario.Nombre + "</h1> <br />" + 
                         "<br />" + 
                         "<p>¡Gracias por darte de alta en nuestro supermercado!</p>";
        }
        public void enviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
