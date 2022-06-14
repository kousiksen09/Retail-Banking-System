using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retail_Bank_UI.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions emailOptions;

        public EmailSender(IOptions<EmailOptions> options)
        {
            emailOptions = options.Value;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(emailOptions.SendGridKey, subject, htmlMessage, email);
        }

        private async Task<Response> Execute(string sendGridKEy, string subject, string message, string email)
        {
            var client = new SendGridClient(sendGridKEy);
            var from = new EmailAddress("kousiksen09@gmail.com", "Retail Bank");
            var to = new EmailAddress(email, email.Split('@')[0]);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", message);
            return await client.SendEmailAsync(msg);
        }
    }
}
