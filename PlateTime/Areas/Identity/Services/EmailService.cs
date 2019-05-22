using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using PlateTimeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PlateTimeApp.Areas.Identity.Services
{
    public class EmailService : IEmailSender
    {
        private EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage myMessage = new MailMessage()
            {
                From = new MailAddress(_emailSettings.FromEmail, "System Admin")
            };

            myMessage.To.Add(new MailAddress(email));
            myMessage.Subject = subject;

            myMessage.AlternateViews.Add(
                AlternateView.CreateAlternateViewFromString(htmlMessage,
                    null, MediaTypeNames.Text.Plain));

            myMessage.AlternateViews.Add(
                AlternateView.CreateAlternateViewFromString(htmlMessage,
                    null, MediaTypeNames.Text.Html));

            try
            {
                SmtpClient smtp = new SmtpClient(
                    _emailSettings.Domain, _emailSettings.Port);

                smtp.Credentials = new NetworkCredential(
                    _emailSettings.UsernameLogin,
                    _emailSettings.UsernamePassword);

                smtp.EnableSsl = false;

                await smtp.SendMailAsync(myMessage);
            }
            catch (Exception e)
            {
                await Task.FromResult(0);
            }
        }
    }

}
