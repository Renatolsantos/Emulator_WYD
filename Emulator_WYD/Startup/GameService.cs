using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Emulator_WYD.Startup
{
    public class GameService : IHostedService
    {
        private readonly IConfiguration _configuration;

        public GameService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Game.Initialize(_configuration);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Game.Shutdown();

            return Task.CompletedTask;
        }
    }
}
