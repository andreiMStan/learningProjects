using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SendEmail_Nihira.Helper;

namespace SendEmail_Nihira.Service
{
 public class EmailService : IEmailService
 {
  private readonly EmailSettings emailSettings;

  public EmailService(IOptions<EmailSettings> options)
  {
    this.emailSettings = options.Value;
  }

  public async Task SendEmailAsync(MailRequest mailRequest)
  {
   var email = new MimeMessage();
   email.Sender = MailboxAddress.Parse(emailSettings.Email);
   //for loop can be used to add multiple emails 
   email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
  // email.Cc.Add(MailboxAddress.Parse(mailRequest.ToEmail));
   //to add the cc
   //email.Cc.Add
   //email.Bcc.Add
   email.Subject = mailRequest.Subject;
   var builder = new BodyBuilder();
   byte[] fileBytes;
   if (System.IO.File.Exists("Attachment/amazing.pdf")) 
   {
    FileStream file = new FileStream("Attachment/amazing.pdf",FileMode.Open,FileAccess.Read);
    using(var ms=new MemoryStream())
    {
     file.CopyTo(ms);
     fileBytes = ms.ToArray();
    }
    builder.Attachments.Add("attachment.pdf", fileBytes, ContentType.Parse("application/octet-stream")); 
    builder.Attachments.Add("attachment2.pdf", fileBytes, ContentType.Parse("application/octet-stream")); 
   }

   builder.HtmlBody = mailRequest.Body;
   email.Body = builder.ToMessageBody();

   using var smtp = new SmtpClient();
   smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
   smtp.Authenticate(emailSettings.Email, emailSettings.Password);
   await smtp.SendAsync(email);
   smtp.Disconnect(true);

  
  }
 }
}
