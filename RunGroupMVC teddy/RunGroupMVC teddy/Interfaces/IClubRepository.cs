using RunGroupMVC_teddy.Models;

namespace RunGroupMVC_teddy.Interfaces
{
 //Interfaces contract, signature
 public interface IClubRepository
 {
  Task<IEnumerable<Club>> GetAll();
  Task<Club> GetById(int id);
  Task<Club> GetByIdAsyncNoTracking(int id);

  Task<IEnumerable<Club>> GetClubByCity(string city);
  bool Add(Club club);

  bool Delete(Club club);
  bool Update(Club club);
  bool Save();
 }
} 
