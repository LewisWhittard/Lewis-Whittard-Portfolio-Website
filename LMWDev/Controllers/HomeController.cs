using JsonLD_Library.Service.Interface;
using LMWDev.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using StaticPageGenerator_Library.Service;
using System;
using System.Diagnostics;
using System.IO;

namespace LMWDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJsonLDService _jsonLDService;
        private readonly IWebHostEnvironment _env;


        private static readonly ActivitySource ActivitySource =
            new ActivitySource("LMWDev.HomeController");

        public HomeController(
            ILogger<HomeController> logger,
            IJsonLDService jsonLDService, IWebHostEnvironment env)
        {
            _logger = logger;
            _jsonLDService = jsonLDService;
            _env = env;
        }



        public IActionResult Index()
        {
            bool backgroundDisabled = Convert.ToBoolean(
                HttpContext.Session.GetString("BackgroundDisabled")
            );

            string filePath = backgroundDisabled
                ? Path.Combine(_env.WebRootPath, "pages", "Home", "BackgroundOff", "index.html")
                : Path.Combine(_env.WebRootPath, "pages", "Home", "BackgroundOn", "index.html");

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, max-age=0";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            return PhysicalFile(filePath, "text/html");
        }

        public IActionResult GenerateHomepage()
        {
            using var activity = ActivitySource.StartActivity("HomeController.RenderHomepage");

            try
            {
                activity?.SetTag("page.type", "HomePage");

                // Generate JSON-LD
                string jsonLD = _jsonLDService.GenerateJsonLDHomePage();

                // Build models
                var modelBackgroundOn = new HomeModel(false, jsonLD);
                var modelBackgroundOff = new HomeModel(true, jsonLD);

                // Resolve services
                var viewEngine = HttpContext.RequestServices.GetRequiredService<IRazorViewEngine>();
                var tempDataProvider = HttpContext.RequestServices.GetRequiredService<ITempDataProvider>();
                var serviceProvider = HttpContext.RequestServices;

                var renderer = new ViewRenderService(viewEngine, tempDataProvider, serviceProvider);

                // Render both versions
                string htmlBackgroundOn = renderer
                    .RenderToStringAsync("Home/Index", modelBackgroundOn)
                    .GetAwaiter().GetResult();

                string htmlBackgroundOff = renderer
                    .RenderToStringAsync("Home/Index", modelBackgroundOff)
                    .GetAwaiter().GetResult();

                // Output paths
                var pathOn = Path.Combine("wwwroot", "pages","Home", "BackgroundOn", "index.html");
                var pathOff = Path.Combine("wwwroot", "pages","Home", "BackgroundOff", "index.html");

                Directory.CreateDirectory(Path.GetDirectoryName(pathOn)!);
                Directory.CreateDirectory(Path.GetDirectoryName(pathOff)!);

                // Write both files
                System.IO.File.WriteAllText(pathOn, htmlBackgroundOn);
                System.IO.File.WriteAllText(pathOff, htmlBackgroundOff);

                activity?.SetStatus(ActivityStatusCode.Ok);
                _logger.LogInformation("Static Home pages generated (On + Off)");

                // Return one of them (or a simple message)
                return Content("Homepage Generated");
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error);
                activity?.RecordException(ex);

                _logger.LogError(ex, "Error generating static home pages");

                throw;
            }
        }
    }
}