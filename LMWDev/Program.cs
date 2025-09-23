using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;
using OpenTelemetry.Logs;
using System;
using Microsoft.Extensions.Options;

namespace LMWDev
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();

                    // OpenTelemetry logging
                    logging.AddOpenTelemetry(options =>
                    {
                        options.IncludeFormattedMessage = true;
                        options.IncludeScopes = true;
                        options.ParseStateValues = true;

                        options.SetResourceBuilder(ResourceBuilder.CreateDefault()
                            .AddService("LMWDevService", serviceVersion: "1.0.0", serviceInstanceId: Environment.MachineName));

                        options.AddConsoleExporter(); // Logs to console
                    });
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOpenTelemetry()
                        .WithTracing(builder =>
                        {
                            builder
                                .SetResourceBuilder(ResourceBuilder.CreateDefault()
                                    .AddService("LMWDevService", serviceVersion: "1.0.0", serviceInstanceId: Environment.MachineName))
                                .AddSource("LMWDev.SearchController") // Match your ActivitySource name
                                .AddSource("LMWDev.HomeController")
                                .AddSource("LMWDev.ClusterContentController")// Match your ActivitySource name
                                .AddAspNetCoreInstrumentation()
                                .AddHttpClientInstrumentation()
                                .SetSampler(new AlwaysOnSampler()) // Collect all traces
                                .AddConsoleExporter(options => options.Targets = OpenTelemetry.Exporter.ConsoleExporterOutputTargets.Debug ); // Traces to console
                        });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}