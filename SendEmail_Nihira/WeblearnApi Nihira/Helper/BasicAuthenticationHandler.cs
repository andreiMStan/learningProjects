using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using WeblearnApi_Nihira.Repos;

namespace WeblearnApi_Nihira.Helper
{
 public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
 {
  private readonly LearndataContext _context;
  public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, LearndataContext context) : base(options, logger, encoder, clock)
  {
   _context = context;
  }

  protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
  {
   if (!Request.Headers.ContainsKey("Authorization"))
   {
    return AuthenticateResult.Fail("No Header found");
   }
   var headervalue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
   if (headervalue != null)
   {
    var bytes = Convert.FromBase64String(headervalue.Parameter);
    string credentials = Encoding.UTF8.GetString(bytes);
    string[] array = credentials.Split(":");
    string username = array[0];
    string password = array[1];
    var user = await _context.TblUsers.FirstOrDefaultAsync(item => item.Username == username && item.Password == password);
   
    if (user!=null)
    {
     var claim = new[] { new Claim(ClaimTypes.Name, user.Username) };
     var identity = new ClaimsIdentity(claim, Scheme.Name);
     var pricipal = new ClaimsPrincipal(identity);
     var ticket = new AuthenticationTicket(pricipal, Scheme.Name);
     return AuthenticateResult.Success(ticket);
    }
    else
    {
     return AuthenticateResult.Fail("No Header found");

    }
   }
   else
   {
     return AuthenticateResult.Fail("empty header");

   }
  }

 }
}
