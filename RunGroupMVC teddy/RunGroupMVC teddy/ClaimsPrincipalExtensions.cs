using System.Security.Claims;

namespace RunGroupMVC_teddy
{
 public static class ClaimsPrincipalExtensions
 {
  public static string GetUserId(this ClaimsPrincipal user)
  {
   return user.FindFirst(ClaimTypes.NameIdentifier).Value;
  }
 }
}
