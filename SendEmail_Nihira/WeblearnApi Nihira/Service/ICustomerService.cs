using WeblearnApi_Nihira.Helper;
using WeblearnApi_Nihira.Modal;
using WeblearnApi_Nihira.Repos.Models;

namespace WeblearnApi_Nihira.Service
{
 public interface ICustomerService
 {

  Task<List<CustomerModal>> GetAllAsync();
  Task<CustomerModal> GetByCodeAsync(string code);
  Task<APIResponse> Remove(string code);
  Task<APIResponse> Create(CustomerModal data);
  Task<APIResponse> Update(CustomerModal data, string code);
 }
}
