using country_info_app.server.Mapper.Interfaces;
using country_info_app.server.Models.Dtos;
using country_info_app.server.Models.ResponseModels;

using Moq;

public class CountryServiceTests
{
    [Fact]
    public async Task GetCountryAsync_ReturnsBadRequest_WhenIsoInvalid()
    {
        var api = new Mock<ICountryApiService>();
        var mapper = new Mock<ICountryMapper>();

        var service = new CountryService(api.Object, mapper.Object);

        var result = await service.GetCountryAsync("X");

        Assert.False(result.Item1);
        Assert.Equal(400, result.Item2);
        Assert.NotNull(result.Item3);
        Assert.Null(result.Item4);
    }

    [Fact]
    public async Task GetCountryAsync_ReturnsNotFound_WhenApiReturnsNull()
    {
        var api = new Mock<ICountryApiService>();
        api.Setup(x => x.FetchAsync("BR")).ReturnsAsync((CountryDto?)null);

        var mapper = new Mock<ICountryMapper>();

        var service = new CountryService(api.Object, mapper.Object);

        var result = await service.GetCountryAsync("BR");

        Assert.False(result.Item1);
        Assert.Equal(404, result.Item2);
        Assert.Contains("BR", result.Item3);
        Assert.Null(result.Item4);
    }

    [Fact]
    public async Task GetCountryAsync_ReturnsSuccess_WhenCountryExists()
    {
        var dto = new CountryDto { Name = "Brazil", Iso2Code = "BR" };
        var response = new CountryResponseModel { Name = "Brazil" };

        var api = new Mock<ICountryApiService>();
        api.Setup(x => x.FetchAsync("BR")).ReturnsAsync(dto);

        var mapper = new Mock<ICountryMapper>();
        mapper.Setup(x => x.MapCountryDtoToResponseModel(dto)).Returns(response);

        var service = new CountryService(api.Object, mapper.Object);

        var result = await service.GetCountryAsync("BR");

        Assert.True(result.Item1);
        Assert.Equal(200, result.Item2);
        Assert.Equal("", result.Item3);
        Assert.Equal(response, result.Item4);
    }
}
