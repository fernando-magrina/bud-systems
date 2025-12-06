using System.Text.Json;

using country_info_app.server.Models;
using country_info_app.server.Validation;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace country_info_app.server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CountryController> _logger;

    public CountryController(IHttpClientFactory httpClientFactory, ILogger<CountryController> logger)
    {
        _httpClient = httpClientFactory.CreateClient("worldbank");
        _logger = logger;
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
            var data = new List<Country>();
            var country = new Country();
            var root = JsonDocument.Parse(json).RootElement;

            if (root.GetArrayLength() > 1)
            {
                data = JsonConvert.DeserializeObject<List<Country>>(root[1].GetRawText());
                country = data.FirstOrDefault();
            }
            else
            {
                throw new InvalidDataException("No data returned from World Bank API");
            }

            var response = new Country
            {
                Name = country.Name,
                Region = country.Region,
                CapitalCity = country.CapitalCity,
                Longitude = country.Longitude,
                Latitude = country.Latitude
            };

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