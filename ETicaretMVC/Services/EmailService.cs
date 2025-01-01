using System.Net.Mail;
using System.Net;

namespace ETicaretMVC.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.your-email-provider.com"))
                {
                    smtpClient.Credentials = new NetworkCredential("your-email@example.com", "your-password");
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("your-email@example.com"),
                        Subject = subject,
                        Body = message,
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(toEmail);

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
