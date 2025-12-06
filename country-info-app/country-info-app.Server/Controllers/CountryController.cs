using System.Text.Json;

using country_info_app.server.Mapper.Interfaces;
using country_info_app.server.Models.Dtos;
using country_info_app.server.validation;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace country_info_app.server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CountryController> _logger;
    private readonly ICountryMapper _countryMapper;

    public CountryController(IHttpClientFactory httpClientFactory, ILogger<CountryController> logger, ICountryMapper countryMapper)
    {
        _httpClient = httpClientFactory.CreateClient("worldbank");
        _logger = logger;
        _countryMapper = countryMapper;
    }

    [HttpGet("{isoCode}")]
    public async Task<IActionResult> Get(string isoCode)
    {
        if (!IsoCodeValidator.IsValid(isoCode))
        {
            return BadRequest(new { error = "ISO code must be 2 or 3 letters." });
        }

        try
        {
            var url = $"v2/country/{isoCode}?format=json";
            var json = await _httpClient.GetStringAsync(url);
            var data = new List<CountryDto>();
            var country = new CountryDto();
            var root = JsonDocument.Parse(json).RootElement;

            if (root.GetArrayLength() > 1)
            {
                data = JsonConvert.DeserializeObject<List<CountryDto>>(root[1].GetRawText());
                country = data.FirstOrDefault();
            }
            else
            {
                throw new InvalidDataException("No data returned from World Bank API");
            }

            var response = this._countryMapper.MapCountryDtoToResponseModel(country);

            //var response = new CountryDto
            //{
            //    Name = country.Name,
            //    Region = country.Region,
            //    CapitalCity = country.CapitalCity,
            //    Longitude = country.Longitude,
            //    Latitude = country.Latitude
            //};

            return Ok(response);
        }

        catch (InvalidDataException ex)
        {
            _logger.LogError(ex, "HTTP request error calling World Bank API");
            return StatusCode(404, new { error = $"{isoCode} is not a valid ISO code." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calling World Bank API");
            return StatusCode(500, new { error = "Internal server error." });
        }
    }
}