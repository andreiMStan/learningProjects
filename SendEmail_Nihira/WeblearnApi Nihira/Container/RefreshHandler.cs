using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WeblearnApi_Nihira.Repos;
using WeblearnApi_Nihira.Repos.Models;
using WeblearnApi_Nihira.Service;

namespace WeblearnApi_Nihira.Container
{
 public class RefreshHandler : IRefreshHandler
 {
  private readonly LearndataContext _context;

  public RefreshHandler(LearndataContext context)
  {
   _context = context;
  }

  public async Task<string> GenerateToken(string username)
  {
   var randomNumber = new byte[32];
   using (var randomNumberGenerator = RandomNumberGenerator.Create())
   {
    randomNumberGenerator.GetBytes(randomNumber);
    string refreshToken = Convert.ToBase64String(randomNumber);
    var ExistToken = await _context.TblRefreshtokens.FirstOrDefaultAsync(
     item => item.Userid == username);
    if (ExistToken!=null)
    {
     ExistToken.Refreshtoken= refreshToken;
    }
    else
    {
     _context.TblRefreshtokens.AddAsync(new TblRefreshtoken
     {
      Userid = username,
      Tokenid = new Random().Next().ToString(),
      Refreshtoken = refreshToken

     }) ;
     
    }
    await _context.SaveChangesAsync();
    return refreshToken;
   }
  }
 }
}
