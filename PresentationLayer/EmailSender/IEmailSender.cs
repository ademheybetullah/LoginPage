using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTask.EmailSender
{
    public interface IEmailSender
    {
        void SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
