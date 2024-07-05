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
            server.Credentials = new NetworkCredential("supermercadoprog3@gmail.com", "gyorzobhuiopygmy");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }
        public void armarCorreo(string emailDestino, string asunto, Usuario usuario)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@supermercadoprog3.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = cuerpo;
            email.Body = "<h1>😎 Bienvenido " + usuario.Nombre + " " + usuario.Apellido + " 😎</h1> <br />" +
                         "<br />" +
                         "<h3>¡Gracias por darte de alta en nuestro supermercado!</h3> <br />" +
                         "<br />" +
                         "<p>Esperamos que disfrutes de nuestro E-commerce.</p> <br />" +
                         "<p>Atte: SUPERMERCADO PROG 3 🛍</p>";
        }

        public void armarCorreoEnvio(string emailDestino, string asunto, Usuario usuario)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@supermercadoprog3.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = cuerpo;
            email.Body = "<h1>Muchas gracias por tu compra " + usuario.Nombre + " " + usuario.Apellido + " 😎</h1> <br />" +
                         "<br />" +
                         "<h3>¡La compra sera enviada a tu domicilio dentro de las proximas 48hs habiles!</h3> <br />" +
                         "<br />" +
                         "<p>Esperamos que la disfrutes.</p> <br />" +
                         "<p>Atte: SUPERMERCADO PROG 3 🛍</p>";
        }

        public void armarCorreoRetiro(string emailDestino, string asunto, Usuario usuario)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@supermercadoprog3.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = cuerpo;
            email.Body = "<h1>Muchas gracias por tu compra " + usuario.Nombre + " " + usuario.Apellido + " 😎</h1> <br />" +
                         "<br />" +
                         "<h3>¡Puedes retirar el producto de 09:00 a 18:00hs en nuestro local!</h3> <br />" +
                         "<br />" +
                         "<h3>¡Te esperamos!</h3> <br />" +
                         "<br />" +
                         "<p>Atte: SUPERMERCADO PROG 3 🛍</p>";
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
