using Microsoft.Extensions.Configuration;

namespace Emulator_WYD.Helper
{
    public static class AppSettingsHelper
    {
        private static IConfiguration _config;

        public static void AppSettingsConfigure(IConfiguration configuration)
        {
            _config = configuration;
        }

        public static string? Settings(string key)
            => _config.GetSection(key).Value;

        public static string? GetConnectionString(string context)
            => _config.GetConnectionString(context);
    }
}
