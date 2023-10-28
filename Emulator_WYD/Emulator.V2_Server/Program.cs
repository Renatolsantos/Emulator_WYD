using Emulator.V2_Host.Startup;
using Microsoft.Extensions.Configuration;

namespace Emulator.V2_Host
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