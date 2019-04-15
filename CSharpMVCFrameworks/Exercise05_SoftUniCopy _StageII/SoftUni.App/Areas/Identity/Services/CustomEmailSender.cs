using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace SoftUni.App.Areas.Identity.Services
{
    public class CustomEmailSender : IEmailSender
    {
        private readonly CustomEmailSenderSettings options;

        public CustomEmailSender(IOptions<CustomEmailSenderSettings> configApiKey)
        {
            this.options = configApiKey.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = options.SendGridApiKey;

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("mytestproj@softuni.bg", "Test User");

            var to = new EmailAddress(email);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, null);

            var response = await client.SendEmailAsync(msg);
        }
    }
}