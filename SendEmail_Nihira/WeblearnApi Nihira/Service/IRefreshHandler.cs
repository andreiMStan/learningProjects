namespace WeblearnApi_Nihira.Service
{
 public interface IRefreshHandler
 {
  Task<string> GenerateToken(string username);
 }
}
