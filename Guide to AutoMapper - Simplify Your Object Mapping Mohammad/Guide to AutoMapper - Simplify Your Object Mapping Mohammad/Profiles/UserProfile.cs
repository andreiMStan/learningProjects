using AutoMapper;
using Guide_to_AutoMapper___Simplify_Your_Object_Mapping_Mohammad.Models.DbSet;
using Guide_to_AutoMapper___Simplify_Your_Object_Mapping_Mohammad.Models.Dtos.Repositories;
using Guide_to_AutoMapper___Simplify_Your_Object_Mapping_Mohammad.Models.Dtos.Requests;

namespace Guide_to_AutoMapper___Simplify_Your_Object_Mapping_Mohammad.Profiles
{
	public class UserProfile:Profile
	{
        public UserProfile()
        {
            CreateMap<User, GetUserResponse>()
                 .ForMember(
                dest => dest.FullName,
                src => src.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(
                dest => dest.Email,
                src => src.MapFrom(x=>$"Email:{x.Email}"))
                .ForMember(
                dest => dest.Address,
                src => src.MapFrom(x =>$"{ x.PostalCode} - { x.StreetAddress}"));

            CreateMap<CreateUserRequest, User>()
                .ForMember(
                dest => dest.Id,
                src => src.MapFrom(x => Guid.NewGuid()))
                .ForMember(
                    dest => dest.Status,
                    src => src.MapFrom(x => 1))
                .ForMember(
                dest => dest.CreatedAt,
                src => src.MapFrom(x => DateTime.Now.ToUniversalTime()));
               
        }

    }
}
