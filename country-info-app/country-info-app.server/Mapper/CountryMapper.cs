using AutoMapper;

using country_info_app.server.Mapper.Interfaces;
using country_info_app.server.Models.Dtos;
using country_info_app.server.Models.ResponseModels;

namespace country_info_app.server.Mapper
{
    public class CountryMapper : ICountryMapper
    {
        private readonly IMapper mapper;

        public CountryMapper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public CountryResponseModel MapCountryDtoToResponseModel(CountryDto request)
        {
            return this.mapper.Map<CountryDto, CountryResponseModel>(request);
        }
    }
}
