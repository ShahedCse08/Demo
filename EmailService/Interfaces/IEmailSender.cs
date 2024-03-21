using EmailService.Models;
//using Entities.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
       // List<EmailContent> GetEmailContent();
    }
}
