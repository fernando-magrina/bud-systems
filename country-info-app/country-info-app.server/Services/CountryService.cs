using country_info_app.server.Mapper.Interfaces;
using country_info_app.server.Models.ResponseModels;
using country_info_app.server.validation;

public class CountryService : ICountryService
{
    private readonly ICountryApiService _api;
    private readonly ICountryMapper _mapper;

    public CountryService(ICountryApiService api, ICountryMapper mapper)
    {
        _api = api;
        _mapper = mapper;
    }

    public async Task<(bool, int, string, CountryResponseModel?)> GetCountryAsync(string isoCode)
    {
        if (!IsoCodeValidator.IsValid(isoCode))
        {
            return (false, 400, "ISO code must be 2 or 3 letters.", null);
        }

        var dto = await _api.FetchAsync(isoCode);

        if (dto == null)
        {
            return (false, 404, $"{isoCode} is not a valid ISO code.", null);
        }

        var response = _mapper.MapCountryDtoToResponseModel(dto);

        return (true, 200, "", response);
    }
}
