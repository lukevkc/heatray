using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;

namespace Heatray.Infrastructure.Extensions.Logging;

public static class LoggingExtensions
{
    public static LoggerConfiguration ConfigureLogging(this LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder())
            .WriteTo.Async(config =>
                config.Debug(LogEventLevel.Information))
            .WriteTo.Async(config =>
                config.Console(LogEventLevel.Information));
        return loggerConfiguration;
    }
}