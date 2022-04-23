using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Utils
{
    public class EmailManager
    {
        public static void SendEmailGmail(string email, string subject, string corpus)
        {
            var fromAddress = new MailAddress("obra.verif@gmail.com");
            var toAddress = new MailAddress(email);
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "disferodnddjlzpw")
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = corpus
            })
            {
                smtp.Send(message);
            }
        }
    }
}
