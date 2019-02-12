using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vote.App.Areas.Identity.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly SendGridSettings options;

        public SendGridEmailSender(IOptions<SendGridSettings> configApiKey)
        {
            this.options = configApiKey.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = options.SendGridApiKey;

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("vote.admin@ivote.live", "Vote Site Admin");

            var to = new EmailAddress(email);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, null);

            var response = await client.SendEmailAsync(msg);
        }
    }
}
