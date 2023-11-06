using Emulator_WYD.Data.Context;
using Emulator_WYD.Helper;
using Emulator_WYD.Startup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Emulator_WYD
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder =>
                {
                    builder.Sources.Clear();
                    builder.AddConfiguration(configuration);
                })
                .ConfigureServices((config, service) => ConfigureServices(service, config.Configuration))
                .Build()
                .Run();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SQLDbContext>(db => db.UseSqlServer(configuration.GetConnectionString("SQLDbContext")));
            services.AddDbContext<InMemoryDbContext>(db => db.UseInMemoryDatabase("Emulator_WYD"));

            AppSettingsHelper.AppSettingsConfigure(configuration);

            services.AddHostedService<GameService>();
        }
    }
}