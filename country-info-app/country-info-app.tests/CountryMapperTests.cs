using AutoMapper;

using country_info_app.server.Mapper;
using country_info_app.server.Models.Dtos;
using country_info_app.server.Models.ResponseModels;

using Moq;

public class CountryMapperTests
{
    [Fact]
    public void MapCountryDtoToResponseModel_Should_Map_Using_AutoMapper()
    {
        // Arrange
        var dto = new CountryDto
        {
            Id = "BRA",
            Iso2Code = "BR",
            Name = "Brazil",
            CapitalCity = "Brasilia",
            Longitude = "-47.8825",
            Latitude = "-15.7942",
            Region = new RegionDto { Id = "1", Iso2code = "AM", Value = "Americas" },
            AdminRegion = new RegionDto { Id = "2", Iso2code = "SAM", Value = "South America" },
            IncomeLevel = new RegionDto { Id = "3", Iso2code = "UM", Value = "Upper middle income" },
            LendingType = new RegionDto { Id = "4", Iso2code = "IBD", Value = "IBRD" }
        };

        var expected = new CountryResponseModel
        {
            Name = dto.Name,
            CapitalCity = dto.CapitalCity,
            Longitude = dto.Longitude,
            Latitude = dto.Latitude,
            Region = dto.Region?.Value,
        };

        var mapperMock = new Mock<IMapper>();
        mapperMock
            .Setup(m => m.Map<CountryDto, CountryResponseModel>(dto))
            .Returns(expected);

        var mapper = new CountryMapper(mapperMock.Object);

        // Act
        var result = mapper.MapCountryDtoToResponseModel(dto);

        // Assert
        Assert.Equal(expected, result);
        mapperMock.Verify(m => m.Map<CountryDto, CountryResponseModel>(dto), Times.Once);
    }
}
