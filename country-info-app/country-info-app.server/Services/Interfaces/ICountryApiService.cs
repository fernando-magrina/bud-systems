using country_info_app.server.Models.Dtos;

public interface ICountryApiService
{
    Task<CountryDto?> FetchAsync(string isoCode);
}
