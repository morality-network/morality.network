using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Utilities
{
    public class EmailUtility
    {
        public static bool SendMessage(string serverAddress, int port, string fromAddress, string fromPassword, 
            string toAddress, string subject, string body)
        {
            var smtp = new SmtpClient
            {
                Host = serverAddress,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body, IsBodyHtml = true })
            {
                smtp.Send(message);
                return true;
            }
        }
    }
}
