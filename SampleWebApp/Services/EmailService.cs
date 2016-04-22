using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SampleWebApp.Services
{
    public class EmailService
    {
        private const string SmtpClient = "smtp-relay.ldschurch.org";
        public MailMessage CreateMailMessage(string from, string to, string subject, string body)
        {
            return new MailMessage(from, to, subject, body);
        }

        public bool SendMailMessage(MailMessage message)
        {
            using(SmtpClient client = new SmtpClient(SmtpClient, 25)){
                client.EnableSsl = false;
                client.Send(message);
            }

            return true;
        }
    }
}