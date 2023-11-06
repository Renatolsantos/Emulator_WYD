using Microsoft.Extensions.Configuration;

namespace Emulator_WYD.Startup
{
    public static class Game
    {
        public static DateTime Time => DateTime.UtcNow;

        public static void Initialize(IConfiguration configuration)
        {
            Console.Title = "Open WYD Server";

            Server.Server.GetInstance().Start(configuration);
        }

        public static void Shutdown()
            => Server.Server.GetInstance().Stop();
    }
}
