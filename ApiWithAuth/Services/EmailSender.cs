using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ApiWithAuth.Services;

public class EmailSender: IEmailSender
{
    
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        string fromMail = "jecadae@yandex.ru";
        string fromPassword = "";
        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromMail);
        message.Subject = subject;
        message.To.Add(new MailAddress(email));
        message.Body = htmlMessage;
        var smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.yandex.com";
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials=new NetworkCredential(fromMail,fromPassword);
        smtpClient.Send(message);
    }
    
}