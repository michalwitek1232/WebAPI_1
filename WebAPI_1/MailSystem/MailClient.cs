using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Limilabs.Mail;
using Limilabs.Mail.Headers;
using Limilabs.Client.SMTP;

namespace WebAPI_1.MailSystem
{
    public class MailClient
    {
        public string Email { get; set; }

        public void SendMail(string nazwa)
        {
            MailBuilder builder = new MailBuilder();
            builder.From.Add(new MailBox("michalwitek1232@gmail.com", "Napiwko.pl"));
            builder.To.Add(new MailBox("michalwitek1232@gmail.com", "Michał Witek"));
            builder.Subject = "Napiwko.pl - rejestracja";
            builder.Text = "Zarejestrowano nowego użytkownika o nazwie " + nazwa;

            IMail email = builder.Create();

            using (Smtp smtp = new Smtp())
            {
                smtp.Connect("smtp.gmail.com", 587);    // or ConnectSSL for SSL
                smtp.UseBestLogin("michalwitek1232@gmail.com", "michalwitek"); // remove if authentication is not needed

                ISendMessageResult result = smtp.SendMessage(email);
                if (result.Status == SendMessageStatus.Success)
                {
                    Console.WriteLine("Wysłano wiadomość o rejestracji użytkownika {0}", nazwa);
                }

                smtp.Close();
            }
        }
    }
}
