using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
namespace Core.EACrossCuttingConcerns.ExceptionLogging
{
    public static class SerilogConfiguration
    {
        public static Serilog.ILogger CreateLogger(IConfiguration configuration)
        {

            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.MySQL(
                    connectionString: configuration.GetConnectionString("MySqlLoggeableRequest"),
                    tableName: "RequestLogs",
                    restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();
        }

    }
}
