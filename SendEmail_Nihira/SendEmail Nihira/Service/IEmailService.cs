using SendEmail_Nihira.Helper;

namespace SendEmail_Nihira.Service
{
 public interface IEmailService
 {
  Task SendEmailAsync(MailRequest mailRequest);
 }
}
