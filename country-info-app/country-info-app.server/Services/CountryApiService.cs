using System.Text.Json;

using country_info_app.server.Models.Dtos;

using Newtonsoft.Json;

public class CountryApiService : ICountryApiService
{
    private readonly HttpClient _httpClient;

    public CountryApiService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("worldbank");
    }

    public async Task<CountryDto?> FetchAsync(string isoCode)
    {
        var url = $"v2/country/{isoCode}?format=json";
        var json = await _httpClient.GetStringAsync(url);

        var root = JsonDocument.Parse(json).RootElement;
        if (root.GetArrayLength() < 2)
        {
            return null;
        }

        var dtoList = JsonConvert.DeserializeObject<List<CountryDto>>(root[1].GetRawText());

        return dtoList?.FirstOrDefault();
    }
}
