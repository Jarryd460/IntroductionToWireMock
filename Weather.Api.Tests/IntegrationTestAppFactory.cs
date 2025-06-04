using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WireMock.Server;

namespace Weather.Api.Tests;

public sealed class IntegrationTestAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var wiremockServer = WireMockServer.Start();

        builder.ConfigureAppConfiguration(configurationBuilder =>
        {
            configurationBuilder.AddInMemoryCollection(new KeyValuePair<string, string>[]
            {
                new("GitHub:BaseAddress", wiremockServer.Urls[0])
            });
        })
            .ConfigureServices(collection => collection.AddSingleton(wiremockServer));
    }
}
