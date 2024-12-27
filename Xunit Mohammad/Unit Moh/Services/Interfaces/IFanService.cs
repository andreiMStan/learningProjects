using Unit_Moh.Models;

namespace Unit_Moh.Services.Interfaces
{
 public interface IFanService
 {
  Task<List<Fan>?> GetAllFans();
 }
}
