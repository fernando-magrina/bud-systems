using System.Net;

using Moq;
using Moq.Protected;

public class CountryApiServiceTests
{
    private HttpClient CreateHttpClientMock(string responseJson)
    {
        var handlerMock = new Mock<HttpMessageHandler>();

        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseJson)
            });

        return new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://fake-worldbank.org/")
        };
    }

    [Fact]
    public async Task FetchAsync_ReturnsCountry_WhenJsonHasSecondArrayWithItem()
    {
        var json = @"[
            { ""page"": 1 },
            [
                { ""name"": ""Brazil"", ""iso2Code"": ""BR"" }
            ]
        ]";

        var httpClient = CreateHttpClientMock(json);

        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("worldbank")).Returns(httpClient);

        var service = new CountryApiService(factory.Object);

        var result = await service.FetchAsync("BR");

        Assert.NotNull(result);
        Assert.Equal("Brazil", result!.Name);
        Assert.Equal("BR", result.Iso2Code);
    }

    [Fact]
    public async Task FetchAsync_ReturnsNull_WhenRootArrayHasLessThanTwoElements()
    {
        var json = @"[
            { ""page"": 1 }
        ]";

        var httpClient = CreateHttpClientMock(json);

        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("worldbank")).Returns(httpClient);

        var service = new CountryApiService(factory.Object);

        var result = await service.FetchAsync("BR");

        Assert.Null(result);
    }

    [Fact]
    public async Task FetchAsync_ReturnsNull_WhenSecondArrayIsEmpty()
    {
        var json = @"[
            { ""page"": 1 },
            []
        ]";

        var httpClient = CreateHttpClientMock(json);

        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("worldbank")).Returns(httpClient);

        var service = new CountryApiService(factory.Object);

        var result = await service.FetchAsync("BR");

        Assert.Null(result);
    }
}
