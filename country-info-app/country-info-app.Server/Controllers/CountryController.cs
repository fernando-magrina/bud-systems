using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("{isoCode}")]
    public async Task<IActionResult> Get(string isoCode)
    {
        var result = await _countryService.GetCountryAsync(isoCode);

        if (!result.Success)
        {
            return StatusCode(result.StatusCode, new { error = result.Message });
        }

        return Ok(result.Data);
    }
}
