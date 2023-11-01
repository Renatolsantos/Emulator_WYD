using Emulator_WYD.Startup;
using Microsoft.Extensions.Configuration;

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

            Game.Initialize(configuration);
        }
    }
}