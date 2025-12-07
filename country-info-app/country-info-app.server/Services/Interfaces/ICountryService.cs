using country_info_app.server.Models.ResponseModels;

public interface ICountryService
{
    Task<(bool Success, int StatusCode, string Message, CountryResponseModel? Data)>
        GetCountryAsync(string isoCode);
}
