using country_info_app.server.Models.Dtos;
using country_info_app.server.Models.ResponseModels;

namespace country_info_app.server.Mapper.Interfaces
{
    public interface ICountryMapper
    {
        CountryResponseModel MapCountryDtoToResponseModel(CountryDto request);
    }
}
