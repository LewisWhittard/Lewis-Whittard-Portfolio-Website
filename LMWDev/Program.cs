using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;
using OpenTelemetry.Logs;
using OpenTelemetry.Exporter;
using System;

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

                    // OpenTelemetry logging with Honeycomb
                    logging.AddOpenTelemetry(options =>
                    {
                        options.IncludeFormattedMessage = true;
                        options.IncludeScopes = true;
                        options.ParseStateValues = true;

                        options.SetResourceBuilder(ResourceBuilder.CreateDefault()
                            .AddService("LMWDevService", serviceVersion: "1.0.0", serviceInstanceId: Environment.MachineName));

                        options.AddConsoleExporter();

                        options.AddOtlpExporter(otlpOptions =>
                        {
                            otlpOptions.Endpoint = new Uri("https://api.honeycomb.io");
                            otlpOptions.Headers = "x-honeycomb-team=Iof84w2kAeeUqvIFOg9p3Y,x-honeycomb-dataset=LMWDevService";
                        });
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
                                .AddSource("LMWDev.SearchController")
                                .AddSource("LMWDev.HomeController")
                                .AddSource("LMWDev.ClusterContentController")
                                .AddAspNetCoreInstrumentation()
                                .AddHttpClientInstrumentation()
                                .SetSampler(new AlwaysOnSampler())
                                .AddConsoleExporter(options =>
                                {
                                    options.Targets = OpenTelemetry.Exporter.ConsoleExporterOutputTargets.Debug;
                                })
                                .AddOtlpExporter(otlpOptions =>
                                {
                                    otlpOptions.Endpoint = new Uri("https://api.honeycomb.io");
                                    otlpOptions.Headers = "x-honeycomb-team=Iof84w2kAeeUqvIFOg9p3Y,x-honeycomb-dataset=LMWDevService";
                                });
                        });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}