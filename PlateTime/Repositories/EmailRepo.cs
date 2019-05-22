using PlateTimeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PlateTimeApp.Repositories
{
    public class EmailRepo
    {
        private EmailSettings _emailSettings;
        public EmailRepo(EmailSettings _emailSettings)
        {
            this._emailSettings = _emailSettings;
        }

        public bool SendMail(string recipient, string subject, string body, string bodyText = null)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.FromEmail, "Platetime Inc.")
                };

                mail.To.Add(new MailAddress(recipient));

                // Subject and multipart/alternative Body
                mail.Subject = subject;
                
                mail.AlternateViews.Add(
                    AlternateView.CreateAlternateViewFromString(body,
                    null, MediaTypeNames.Text.Html));

                if (bodyText != null) {
                    mail.AlternateViews.Add(
                        AlternateView.CreateAlternateViewFromString(body,
                        null, MediaTypeNames.Text.Plain));
                }
                

                //optional priority setting
                //mail.Priority = MailPriority.High;
                // you can add attachments
                //mail.Attachments.Add(new Attachment(@"C:\mind.gif"));
                // Init SmtpClient and send
                SmtpClient smtp = new SmtpClient(_emailSettings.Domain, _emailSettings.Port);
                smtp.Credentials = new NetworkCredential(_emailSettings.UsernameLogin, _emailSettings.UsernamePassword);
                smtp.EnableSsl = false;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
