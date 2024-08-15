using Serilog;

namespace Powerplant.Api.Config
{
    public class SerilogSettingsConfig
    {
        public static void ConfigureLogging(IConfigurationRoot configuration, string environment) => Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Debug()
                .WriteTo.Console()
                .Enrich.WithProperty("Environment", environment)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
    }
}
