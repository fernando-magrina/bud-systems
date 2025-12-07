using AutoMapper;

using country_info_app.server.Models.Dtos;
using country_info_app.server.Models.ResponseModels;

namespace country_info_app.server.Mapper
{
    public class CountryMapperProfile : Profile
    {
        public CountryMapperProfile()
        {
            CreateMap<CountryDto, CountryResponseModel>()
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region.Value));
        }
    }
}
