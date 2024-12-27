using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using SendEmail_Nihira.Helper;
using SendEmail_Nihira.Service;
using System.Diagnostics.Metrics;

namespace SendEmail_Nihira.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class EmailController : ControllerBase
 {

  private readonly IEmailService _emailService;

  public EmailController(IEmailService emailService)
  {
   _emailService = emailService;
  }

  [HttpPost("SendMail")]
  public async Task<IActionResult> SendEmail()
  {
   try
   {

    MailRequest mailRequest = new MailRequest();
   // mailRequest.ToEmail = "1063948986@qq.com";
    mailRequest.ToEmail ="andreistan748@gmail.com";
    mailRequest.Subject = "Miss you";
    //mailRequest.Body = "you are amazing , I will never meet a perfect girl like you";
    mailRequest.Body = GetHtmlContent();
    await _emailService.SendEmailAsync(mailRequest);
    return Ok();

   }
   catch (Exception ex)
   {
    throw ;
   }}
  private string GenerateRandomNumber()
  {
   Random random = new Random();
   string randomNo = random.Next(0, 100000).ToString("D6");
   return randomNo;
  }

  [HttpPost("SendOtpMail")]
  public async Task SendOtpMail(string userEmail, string otpText, string Name) {

   var mailRequest = new MailRequest();
   mailRequest.ToEmail = userEmail;
   mailRequest.Subject = "thanks for registering";
   mailRequest.Body = GenerateEmailBody(Name, otpText);
   await _emailService.SendEmailAsync(mailRequest);
  }
  private string GenerateEmailBody(string name, string otpText)
  {
   string emailBody = string.Empty;
   emailBody = "<div style='width:100%; background-color:grey'>";
   emailBody += "<h1>Hi"+ name + " , Thanks for registering </h1>";
   emailBody += "  <h2> Please enter OTP text and complete the registration  </h2>";
   emailBody += "<h2>OTP text is " + otpText + " </h2>";
   return emailBody;
  }

  private string GetHtmlContent()
  {
   string response = "<h1>\"you are amazing , I will never meet a perfect girl like you.I miss you Andrei\"</h1>";
   return response;
  }

  //private string GetHtmlContent()
  //{
  // string logoUrl = "https://via.placeholder.com/200x50.png?text=Your+Logo"; // Placeholder logo image
  // string link1Url = "https://example.com/link1";
  // string link2Url = "https://example.com/link2";
  // string link3Url = "https://example.com/link3";

  // string response = $@"
  //  <div style=""text-align:center;"">
  //      <img src=""{logoUrl}"" alt=""Company Logo"" style=""width:200px; height:auto; margin-bottom:20px;""/>
  //      <h1>""You are amazing, I will never meet a perfect girl like you.""</h1>
  //      <p>Check out these links:</p>
  //      <p>
  //          <a href=""{link1Url}"" target=""_blank"">Link 1</a><br/>
  //          <a href=""{link2Url}"" target=""_blank"">Link 2</a><br/>
  //          <a href=""{link3Url}"" target=""_blank"">Link 3</a>
  //      </p>
  //  </div>";

  // return response;
  ////}
  //private string GetHtmlContent()
  //{
  // // Funny image URL (a cute kitten with sunglasses)
  // string funnyImageUrl = "https://i.imgur.com/jtT2WbX.png"; // Placeholder image URL for a funny/cute kitten
  // string link1Url = "https://example.com/cutecats";
  // string link2Url = "https://example.com/memes";
  // string link3Url = "https://example.com/jokes";

  // // Funny HTML content
  // string response = $@"
  //  <div style=""text-align:center; font-family: Comic Sans MS, Arial, sans-serif; color: #333;"">
  //      <img src=""{funnyImageUrl}"" alt=""Funny Kitten"" style=""width:200px; height:auto; margin-bottom:20px;""/>
  //      <h1 style=""color: #ff6b6b;"">Hey Gorgeous,</h1>
  //      <p style=""font-size: 18px;"">
  //          What do you call a cat that wears sunglasses? <br/>
  //          <strong>A cool cat!</strong> 😎
  //      </p>
  //      <p style=""font-size: 18px;"">
  //          I couldn't resist sharing this with you because, just like this kitten, you are the coolest and the cutest! 
  //          Now stop smiling, or I’ll have to send more jokes your way! 😉
  //      </p>
  //      <div style=""margin-top: 30px;"">
  //          <p style=""font-size: 18px;"">Need more laughs? Check these out:</p>
  //          <p>
  //              <a href=""{link1Url}"" target=""_blank"" style=""text-decoration:none; color:#ff6b6b;"">Cute Cats</a><br/>
  //              <a href=""{link2Url}"" target=""_blank"" style=""text-decoration:none; color:#ff6b6b;"">Hilarious Memes</a><br/>
  //              <a href=""{link3Url}"" target=""_blank"" style=""text-decoration:none; color:#ff6b6b;"">Funny Jokes</a>
  //          </p>
  //      </div>
  //  </div>";

  // return response;
  //}

  //private string GetHtmlContent()
  //{
  // // Heart logo URL
  // string heartLogoUrl = "https://via.placeholder.com/150x150.png?text=%E2%9D%A4"; // This URL creates a heart image using placeholder.com
  // string link1Url = "https://example.com/memories";
  // string link2Url = "https://example.com/ourfuture";
  // string link3Url = "https://example.com/forever";

  // // Beautiful HTML content
  // string response = $@"
  //  <div style=""text-align:center; font-family: Arial, sans-serif; color: #333;"">
  //      <img src=""{heartLogoUrl}"" alt=""Heart"" style=""width:150px; height:auto; margin-bottom:20px;""/>
  //      <h1 style=""color: #ff6b6b;"">To the Love of My Life</h1>
  //      <p style=""font-size: 18px;"">
  //          Every moment with you is a moment I cherish. You bring so much joy and love into my life, and I am incredibly grateful for you. 
  //          You are my sunshine on a cloudy day, the beat in my heart, and the love of my life. 
  //          I look forward to every memory we create together and all the beautiful moments that lie ahead.
  //      </p>
  //      <p style=""font-size: 18px;"">
  //          Always and Forever, <br/>
  //          <strong>Your [Your Name]</strong>
  //      </p>
  //      <div style=""margin-top: 30px;"">
  //          <p style=""font-size: 18px;"">Let's relive our favorite moments:</p>
  //          <p>
  //              <a href=""{link1Url}"" target=""_blank"" style=""text-decoration:none; color:#ff6b6b;"">Our Memories</a><br/>
  //              <a href=""{link2Url}"" target=""_blank"" style=""text-decoration:none; color:#ff6b6b;"">Our Future</a><br/>
  //              <a href=""{link3Url}"" target=""_blank"" style=""text-decoration:none; color:#ff6b6b;"">Forever Together</a>
  //          </p>
  //      </div>
  //  </div>";

  // return response;
  //}


 }
}
