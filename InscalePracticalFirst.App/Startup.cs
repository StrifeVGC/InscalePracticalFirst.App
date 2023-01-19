using InscalePracticalFirst.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InscalePracticalFirst.Core
{
    public static class Startup
    {
        public static ServiceProvider ConfigureApp(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");

            IConfiguration Configuration = configBuilder.Build();

            var serviceProvider = new ServiceCollection();

            serviceProvider
                .AddDbContext<InscalePracticalContext>(
                                options => options.UseNpgsql(Configuration.GetConnectionString("InscaleConnectionString")))
                .AddHttpClient("DummyApiClient", httpClient =>
                {
                    httpClient.BaseAddress = new Uri("https://dummyjson.com/");
                });

            var serviceCollection = serviceProvider.BuildServiceProvider();



            return serviceCollection;
        }
    }
}
