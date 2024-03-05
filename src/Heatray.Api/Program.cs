using Heatray.Infrastructure.Extensions.Logging;
using Serilog;

namespace Heatray.Api
{
    public class Program
    {
        private static IConfigurationRoot? _configurationRoot;

        public static async Task Main(string[] args)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
                    optional: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ConfigureLogging()
                .CreateBootstrapLogger();

            try
            {
                Log.Information("Starting web host.");
                var host = CreateHostBuilder(args)
                    .ConfigureAppConfiguration(x => x.AddUserSecrets<Program>())
                    .Build();

                using var scope = host.Services.CreateScope();
                await host.RunAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly.");
            }
            finally
            {
                await Log.CloseAndFlushAsync();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    _ = webBuilder.UseStartup<Startup>().ConfigureAppConfiguration(builder =>
                    {
                        if (_configurationRoot != null) _ = builder.AddConfiguration(_configurationRoot);
                    });
                });
        }
    }
}
