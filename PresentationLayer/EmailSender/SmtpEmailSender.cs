using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BackendTask.EmailSender
{
    public class SmtpEmailSender: IEmailSender
    {
        private string _host;
        private bool _enableSSL;
        private string _username;
        private string _password;
        private int _port;
        public SmtpEmailSender(string host, int port, bool enableSSL, string username, string password)
        {
            _host = host;
            _port = port;
            _enableSSL = enableSSL;
            _username = username;
            _password = password;
        }
        public void SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = _enableSSL
            };
            client.Send(
                    new MailMessage(_username, email, subject, htmlMessage)
                    {
                        IsBodyHtml = true
                    }
                    );
        }

    }
}
