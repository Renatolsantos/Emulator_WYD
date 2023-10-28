using Emulator.V2_CrossCutting;
using Emulator.V2_Domain.Model;
using Emulator.V2_Host.Settings;
using Microsoft.Extensions.Configuration;

namespace Emulator.V2_Host.Startup
{
    public static class Game
    {
        public static void Initialize(IConfiguration configuration)
        {
            try
            {
                Console.Title = "Open WYD Server";

                var server = new Server();
                configuration.Bind("Server", server);

                new ServerHandler(server);
            }
            finally
            {
                Initialize(configuration);
            }
        }
    }
}
