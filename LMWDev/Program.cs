using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;
using OpenTelemetry.Logs;
using System;
using Page_Library.Content.Repository.Interface;
using Page_Library.Content.Repository;
using Page_Library.Page.Repository.Interface;
using Page_Library.Page.Repository;
using Page_Library.Page.Factory.Interface;
using Page_Library.Page.Factory;
using Page_Library.Page.Service;
using Page_Library.Page.Service.Interface;

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

                    services.AddScoped<IContentRepository>(provider =>
                        new JsonContentRepository(@"./Json/Content/Content.json"));

                    // Singleton registrations for page-related services
                    services.AddSingleton<IPageRepository>(provider =>
                        new JsonPageRepository(@"./Json/Page/Page.json"));

                    services.AddSingleton<IContentRepository>(provider =>
                        new JsonContentRepository(@"./Json/Content/Content.json"));

                    services.AddSingleton<IContentBlockFactory, ContentBlockFactory>();

                    services.AddSingleton<IPageService>(provider =>
                    {
                        var pageRepo = provider.GetRequiredService<IPageRepository>();
                        var contentRepo = provider.GetRequiredService<IContentRepository>();
                        var blockFactory = provider.GetRequiredService<IContentBlockFactory>();

                        return new PageService(pageRepo, blockFactory, contentRepo);
                    });
               



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