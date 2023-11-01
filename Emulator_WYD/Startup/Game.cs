using Microsoft.Extensions.Configuration;

namespace Emulator_WYD.Startup
{
    public static class Game
    {
        public static void Initialize(IConfiguration configuration)
        {
            try
            {
                Console.Title = "Open WYD Server";

                Server.Server.GetInstace().Start(configuration);
            }
            finally
            {
                Console.Read();
                Initialize(configuration);
            }
        }
    }
}
