using AutoMapper;
using WeblearnApi_Nihira.Modal;
using WeblearnApi_Nihira.Repos.Models;

namespace WeblearnApi_Nihira.Helper
{
 public class AutoMapperHandler:Profile
 {
        public AutoMapperHandler()
        {
   CreateMap<TblCustomer, CustomerModal>().ForMember(item => item.Statusname, opt => opt.MapFrom(
                item => (item.IsActive != null && item.IsActive.Value) ? "Active" : "In active")).ReverseMap();
  }
    }
}
