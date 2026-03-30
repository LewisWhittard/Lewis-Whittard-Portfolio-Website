using JsonLD_Library.Service.Interface;
using LMWDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Entities.SearchResult.Interface;
using Page_Library.Page.Service.Interface;
using System;
using System.Collections.Generic;
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
            using var activity = ActivitySource.StartActivity("PillarPage.Index");
            {
                activity?.SetTag("external.id", id);
                _logger.LogInformation("Index action started with ExternalID: {ExternalID}", id);

                try
                {
                    // Add session ID to the root activity
                    var sessionId = HttpContext.Session.Id;
                    activity?.SetTag("session.id", sessionId);
                    activity?.SetTag("Controller.Route", id);

                    // ---------------------------
                    // 1. Route Validation Span
                    // ---------------------------
                    using (var routeSpan = ActivitySource.StartActivity("ValidateRoute"))
                    {
                        bool isValidRoute = id == "software-development" || id == "creative-works";
                        routeSpan?.SetTag("route.valid", isValidRoute);
                        routeSpan?.SetTag("route.value", id);

                        if (!isValidRoute)
                        {
                            routeSpan?.SetStatus(ActivityStatusCode.Error, "Invalid route");
                            activity?.SetStatus(ActivityStatusCode.Error, "Invalid route");
                            return NotFound();
                        }
                    }

                    // ---------------------------
                    // 2. Page Retrieval Span
                    // ---------------------------
                    IPage page;
                    using (var pageSpan = ActivitySource.StartActivity("RetrievePage"))
                    {
                        page = _pageService.GetPage(id);
                        bool pageFound = page != null;

                        pageSpan?.SetTag("page.found", pageFound);

                        if (!pageFound)
                        {
                            pageSpan?.SetStatus(ActivityStatusCode.Error, "Page not found");
                            activity?.SetStatus(ActivityStatusCode.Error, "Page not found");
                            _logger.LogWarning("No page found for ExternalID: {ExternalID}", id);
                            return NotFound();
                        }

                        pageSpan?.SetTag("page.category", page.Category);
                    }

                    // ---------------------------
                    // 3. Search Span
                    // ---------------------------
                    List<ISearchResult> search;
                    using (var searchSpan = ActivitySource.StartActivity("Search"))
                    {
                        searchSpan?.SetTag("search.category", page.Category);
                        search = _pageService.Search(null, page.Category);
                    }

                    // ---------------------------
                    // 4. JSON-LD Generation Span
                    // ---------------------------
                    string jsonLD;
                    using (var jsonSpan = ActivitySource.StartActivity("GenerateJsonLD"))
                    {
                        jsonLD = _jsonLDService.GenerateJsonLDPillarPage(page, search);
                    }

                    // ---------------------------
                    // 5. ViewModel Construction Span
                    // ---------------------------
                    PillarPageModel viewModel;
                    using (var vmSpan = ActivitySource.StartActivity("BuildViewModel"))
                    {
                        vmSpan?.SetTag("session.backgroundDisabled",
                            Convert.ToBoolean(HttpContext.Session.GetString("BackgroundDisabled")));

                        viewModel = new PillarPageModel(
                            page,
                            search,
                            Convert.ToBoolean(HttpContext.Session.GetString("BackgroundDisabled")),
                            jsonLD
                        );
                    }

                    activity?.SetStatus(ActivityStatusCode.Ok);
                    _logger.LogInformation("Returning view for ExternalID: {ExternalID}", id);

                    return View(viewModel);
                }
                catch (Exception ex)
                {
                    activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                    activity?.SetTag("exception.type", ex.GetType().Name);
                    activity?.SetTag("exception.message", ex.Message);
                    activity?.SetTag("exception.stacktrace", ex.StackTrace);

                    _logger.LogError(ex, "Error occurred while processing ExternalID: {ExternalID}", id);
                    return StatusCode(500, "An unexpected error occurred.");
                }
            }
        }

    }
}
