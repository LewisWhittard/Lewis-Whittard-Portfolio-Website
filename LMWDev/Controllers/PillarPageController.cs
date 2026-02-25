using JsonLD_Library.Service;
using JsonLD_Library.Service.Interface;
using LMWDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Page_Library.Page.Service.Interface;
using System;
using System.Diagnostics;

namespace LMWDev.Controllers
{
    public class PillarPageController : Controller
    {
        private readonly IPageService _pageService;
        private readonly ILogger<PillarPageController> _logger;
        private readonly IJsonLDService _jsonLDService;
        private static readonly ActivitySource ActivitySource = new("LMWDev.PillarPageController");

        public PillarPageController(ILogger<PillarPageController> logger, IPageService pageService, IJsonLDService jsonLDService)
        {
            _logger = logger;
            try
            {
                _jsonLDService = jsonLDService;
                _pageService = pageService;
                _logger.LogInformation("PageService initialized successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize PageService.");
                throw;
            }
        }

        [Route("{id}")]
        public IActionResult Index(string id)
        {
            using var activity = new Activity("PillarPage.Index").Start();

            activity?.SetTag("external.id", id);
            _logger.LogInformation("Index action started with ExternalID: {ExternalID}", id);

            try
            {
                // Validate route
                bool isValidRoute = id == "software-development" || id == "creative-works";
                activity?.SetTag("route.valid", isValidRoute);

                if (!isValidRoute)
                {
                    activity?.SetStatus(ActivityStatusCode.Error, "Invalid route");
                    return NotFound();
                }

                // Retrieve page
                var page = _pageService.GetPage(id);
                bool pageFound = page != null;
                activity?.SetTag("page.found", pageFound);

                if (!pageFound)
                {
                    _logger.LogWarning("No page found for ExternalID: {ExternalID}", id);
                    activity?.SetStatus(ActivityStatusCode.Error, "Page not found");
                    return NotFound();
                }

                activity?.SetTag("page.category", page.Category);
                _logger.LogInformation("Page retrieved successfully for ExternalID: {ExternalID}", id);

                // Search
                var search = _pageService.Search(null, page.Category);
                activity?.AddEvent(new ActivityEvent("SearchCompleted", tags: new ActivityTagsCollection
        {
            { "search.category", page.Category }
        }));

                // JSON-LD generation
                var jsonLD = _jsonLDService.GenerateJsonLDPillarPage(page, search);
                activity?.AddEvent(new ActivityEvent("JsonLdGenerated"));

                // View model (constructor untouched)
                var viewModel = new PillarPageModel(
                    page,
                    search,
                    Convert.ToBoolean(HttpContext.Session.GetString("BackgroundDisabled")),
                    jsonLD
                );

                _logger.LogInformation("Returning view for ExternalID: {ExternalID}", id);
                activity?.SetStatus(ActivityStatusCode.Ok);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing ExternalID: {ExternalID}", id);

                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                activity?.SetTag("exception.type", ex.GetType().Name);
                activity?.SetTag("exception.message", ex.Message);
                activity?.SetTag("exception.stacktrace", ex.StackTrace);

                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
