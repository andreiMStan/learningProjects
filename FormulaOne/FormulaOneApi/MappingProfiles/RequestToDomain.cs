using AutoMapper;
using FormulaOne.Entities;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;

namespace FormulaOneApi.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateDriverAchivementRequest, Achivement>().
            ForMember(
                dest => dest.RaceWins,
                opt => opt.MapFrom(src => src.Wins))
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1))
             .ForMember(
                dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
             .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));


            CreateMap<UpdateDriverAchivementsRequest, Achivement>().
                ForMember(
                    dest => dest.RaceWins,
                    opt => opt.MapFrom(src => src.Wins))
                 .ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<CreateDriverRequest, Driver>().
            ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1))

             .ForMember(
                dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
             .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow)); 
            
            
            CreateMap<UpdateDriverRequest, Driver>()
                    .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));
        }

    } 
}
