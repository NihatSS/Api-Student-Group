using Api_intro.DTOs.City;
using Api_intro.DTOs.Countries;
using Api_intro.DTOs.Groups;
using Api_intro.Models;
using AutoMapper;

namespace Api_intro.Helpers.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryEditDto, Country>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null );
                });


            CreateMap<City, CityDto>();
            CreateMap<CityCreateDto, City>();
            CreateMap<CityEditDto, City>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });

            CreateMap<Group, GroupDto>();
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupEditDto, Group>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
        }
    }
}
