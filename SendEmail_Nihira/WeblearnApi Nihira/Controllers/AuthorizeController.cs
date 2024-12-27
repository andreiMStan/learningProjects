using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeblearnApi_Nihira.Modal;
using WeblearnApi_Nihira.Repos;
using WeblearnApi_Nihira.Service;

namespace WeblearnApi_Nihira.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class AuthorizeController : ControllerBase
 {
  private readonly LearndataContext _context;
  private readonly JwtSettings _jwtSettings;
  private readonly IRefreshHandler _refresh;
  public AuthorizeController(LearndataContext context, IOptions<JwtSettings> options, IRefreshHandler refresh)
  {
   _context = context;
   _jwtSettings = options.Value;
   _refresh = refresh;
  }
  [HttpPost("GenerateRefreshToken")]
  public async Task<IActionResult> GenerateRefreshToken([FromBody] TokenResponse token)
  {

   var _refreshToken = await _context.TblRefreshtokens.FirstOrDefaultAsync(
    item => item.Refreshtoken == token.RefreshToken);
   if (_refreshToken != null)
   {
    //generate token
    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenkey = Encoding.UTF8.GetBytes(_jwtSettings.securitykey);

    SecurityToken securityToken;
    var principal = tokenHandler.ValidateToken(
     token.Token,
     new TokenValidationParameters()
     {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(tokenkey),
      ValidateIssuer = false,
      ValidateAudience = false,

     }, out securityToken);

    var _token = securityToken as JwtSecurityToken;

    if (_token != null && _token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
    {
     string userName = principal.Identity?.Name;
     var _existData = await _context.TblRefreshtokens.FirstOrDefaultAsync(
      item => item.Userid == userName &&
      item.Refreshtoken == token.RefreshToken);

     if (_existData != null)
     {
      var _newtoken = new JwtSecurityToken(
       claims: principal.Claims.ToArray(),
       expires: DateTime.Now.AddSeconds(30),
       signingCredentials: new SigningCredentials(
        new SymmetricSecurityKey(
         Encoding.UTF8.GetBytes(
         _jwtSettings.securitykey)),
        SecurityAlgorithms.HmacSha256
        ));
      var _finalToken = tokenHandler.WriteToken(_newtoken);
      return Ok(new TokenResponse()
      {
       Token = _finalToken,
       RefreshToken = await _refresh.GenerateToken(userName)
      });
     }
     else
     {
      return Unauthorized();
     }
    }

    else
    {
     return Unauthorized();
    }
  
   }
   else
   {
    return Unauthorized();
   }
  }

  [HttpPost("GenerateToken")]
  public async Task<IActionResult> GenerateToken([FromBody] UserCred userCred)
  {

   var user = await _context.TblUsers.FirstOrDefaultAsync(
    item => item.Username == userCred.userName && item.Password == userCred.password
    );
   if (user != null)
   {
    //generate token
    var tokenhandler = new JwtSecurityTokenHandler();
    var tokenkey = Encoding.UTF8.GetBytes(_jwtSettings.securitykey);
    var tokendesc = new SecurityTokenDescriptor
    {
     Subject = new ClaimsIdentity(new Claim[]
     {
      new Claim(ClaimTypes.Name, user.Username),
      new Claim(ClaimTypes.Role, user.Role)

     }),
     Expires = DateTime.UtcNow.AddSeconds(30),
     SigningCredentials = new SigningCredentials(
      new SymmetricSecurityKey(tokenkey),
      SecurityAlgorithms.HmacSha256)
    };
    var token = tokenhandler.CreateToken(tokendesc);
    var finaltoken = tokenhandler.WriteToken(token);
    return Ok(new TokenResponse()
    {
     Token = finaltoken,
     RefreshToken = await _refresh.GenerateToken(userCred.userName)
    });

   }
   else
   {
    return Unauthorized();
   }
  }
 }
}
