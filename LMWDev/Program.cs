using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;
using OpenTelemetry.Logs;
using OpenTelemetry.Exporter;
using System;
using Page_Library.Content.Repository.Interface;
using Page_Library.Content.Repository;
using Page_Library.Search.Repository.Interface;
using Page_Library.Search.Repository;
using Page_Library.Search.Service.Interface;
using Page_Library.Search.Service;

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
                            otlpOptions.Headers = "x-honeycomb-team=Key,x-honeycomb-dataset=LMWDevService";
                        });
                    });
                })
                .ConfigureServices((hostContext, services) =>
                {
                    // ?? Place your DI registrations here
                    services.AddScoped<IPageSearchRepository>(provider =>
                    {
                        var logger = provider.GetRequiredService<ILogger<JsonPageSearchRepository>>();
                        return new JsonPageSearchRepository(@"./Json/Search/Search.json");
                    });

                    services.AddScoped<IContentRepository>(provider =>
                    {
                        var logger = provider.GetRequiredService<ILogger<JsonContentRepository>>();
                        return new JsonContentRepository(@"./Json/Content/Content.json");
                    });

                    services.AddScoped<IPageSearchService, PageSearchService>();


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
                                    otlpOptions.Headers = "x-honeycomb-team=Key,x-honeycomb-dataset=LMWDevService";
                                });
                        });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}