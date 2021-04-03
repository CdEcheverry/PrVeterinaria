using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace PrVeterinaria.Libs
{
    public class EnviarCorreo
    {
        private static MailMessage mail = new MailMessage();

        public static async Task Enviar(string Destinatario, string Asunto, string Mensaje)
        {

            mail.To.Clear();
            mail.To.Add(Destinatario);
            mail.Subject = Asunto;
            mail.Body = Mensaje;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            await smtp.SendMailAsync(mail);
        }

        public static async Task Enviar(string[] Destinatarios, string Asunto, string Mensaje)
        {

            mail.To.Clear();
            foreach (string Destinatario in Destinatarios)
            {
                mail.To.Add(Destinatario);
            }
            mail.Subject = Asunto;
            mail.Body = Mensaje;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            await smtp.SendMailAsync(mail);

        }
    }
}