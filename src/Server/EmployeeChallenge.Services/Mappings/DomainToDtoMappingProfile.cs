
namespace EmployeeChallenge.Services.Mappings
{
    using AutoMapper;
    using EmployeeChallenge.Dtos;
    using EmployeeChallenge.Entities;
    using System.Linq;

    public class EmployeeChallengeMappingProfile : Profile
    {
        public EmployeeChallengeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.AddressLine,
                    map => map.MapFrom(e => e.Address.AddressLine))
                .ForMember(dto => dto.City,
                    map => map.MapFrom(e => e.Address.City))
                .ForMember(dto => dto.Country,
                    map => map.MapFrom(e => e.Address.Country))
                .ForMember(dto => dto.ZipCode,
                    map => map.MapFrom(e => e.Address.ZipCode)).ReverseMap();

            CreateMap<Skill, SkillDto>().ReverseMap();

        }
    }
}
