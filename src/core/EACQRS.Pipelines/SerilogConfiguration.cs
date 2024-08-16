using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;
namespace EACQRS.Pipelines
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
