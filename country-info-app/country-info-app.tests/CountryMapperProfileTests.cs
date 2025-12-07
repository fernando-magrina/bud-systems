using AutoMapper;

using country_info_app.server.Mapper;
using country_info_app.server.Models.Dtos;
using country_info_app.server.Models.ResponseModels;

public class CountryMapperProfileTests
{
    private readonly IMapper _mapper;

    public CountryMapperProfileTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CountryMapperProfile>();
        });

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void CountryDto_Should_Map_To_CountryResponseModel_Correctly()
    {
        // Arrange
        var dto = new CountryDto
        {
            Id = "BRA",
            Iso2Code = "BR",
            Name = "Brazil",
            Region = new RegionDto { Id = "1", Iso2code = "AM", Value = "Americas" }
        };

        // Act
        var result = _mapper.Map<CountryResponseModel>(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Brazil", result.Name);
        Assert.Equal("Americas", result.Region);  // Mapped by profile
    }
}
