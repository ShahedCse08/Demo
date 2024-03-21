using EmailService.Interfaces;
using EmailService.Models;
//using Entities.Context;
//using Entities.Models.Email;
using MailKit.Net.Smtp;
//using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Repository.Repository;
namespace EmailService.Services
{
    public class EmailSender :  IEmailSender 
    {
        private readonly EmailConfiguration _emailConfig;
        //  private RepositoryContext _repositoryContext;


        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }


        //public  List<EmailContent> GetEmailContent()
        //{
        //    return _repositoryContext.Set<EmailContent>().ToList();
        //}



        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Cc.AddRange(message.Cc);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }


    }
}
