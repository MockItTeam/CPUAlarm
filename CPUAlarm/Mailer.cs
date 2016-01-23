using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CPUAlarm
{
    class Mailer
    {
        private String from = "sarun.wo.tv@gmail.com";
        private String to = "mapkabb@gmail.com";
        private SmtpClient smtp;

        public Mailer()
        {
            smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, ""),
                Timeout = 20000
            };
        }

        public void mail(String subject, String body)
        {
            using (var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

    }
}
