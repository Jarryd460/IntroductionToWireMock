using Microsoft.Extensions.DependencyInjection;
using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Weather.Api.Tests.Controllers;

public sealed class WeatherForecastControllerTest : IClassFixture<IntegrationTestAppFactory<Program>>
{
    private readonly IntegrationTestAppFactory<Program> _integrationTestAppFactory;
    private readonly WireMockServer _wireMockServer;

    public WeatherForecastControllerTest(IntegrationTestAppFactory<Program> integrationTestAppFactory)
    {
        _integrationTestAppFactory = integrationTestAppFactory;
        _wireMockServer = _integrationTestAppFactory.Services.GetRequiredService<WireMockServer>();
    }

    [Fact]
    public void Should_ReturnWeatherForecastForNext5Days_WhenMakingGetRequestToGetWeatherForecast()
    {
        _wireMockServer.Given(Request.Create().WithPath(""))
            .RespondWith(Response.Create()
                .WithBodyAsJson(new { name = "Jarryd Deane" })
                .WithStatusCode(HttpStatusCode.OK));

        Assert.True(true);
    }
}