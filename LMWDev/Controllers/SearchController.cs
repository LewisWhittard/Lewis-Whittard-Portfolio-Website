using LMWDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using Page_Library.Page.Entities.SearchResult.Interface;
using Page_Library.Page.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LMWDev.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPageService _pageService;
        private readonly ILogger<SearchController> _logger;
        private static readonly ActivitySource ActivitySource = new("LMWDev.SearchController");

        public SearchController(IPageService pageService, ILogger<SearchController> logger)
        {
            _logger = logger;
            try
            {
                _pageService = pageService;
                _logger.LogInformation("Page Service initialized successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize PageSearchService.");
                throw;
            }
        }

        [Route("search")]
        public IActionResult Index(SearchViewModel viewModel)
        {
            var cookieValue = HttpContext.Session.GetString("CookieApproved");

            // Variable 1: is it set?
            bool isCookieSet = cookieValue != null;

            // Variable 2: the actual value (true/false), defaulting to false if unset
            bool CookieApproved = bool.TryParse(cookieValue, out var parsed) && parsed;

            using var activity = ActivitySource.StartActivity("SearchController.Index");
            {
                try
                {
                    // NEW: Add session ID to the root activity
                    if (CookieApproved == true)
                    {
                        var sessionId = HttpContext.Session.Id;
                        activity?.SetTag("session.id", sessionId);
                    }

                    activity?.SetTag("Controller.Route", "search");
                    bool hasSearch = !string.IsNullOrWhiteSpace(viewModel.Search);
                    if (CookieApproved)
                    {
                        activity?.SetTag("search.category", viewModel.Category);
                    }
                    activity?.SetTag("search.value", hasSearch.ToString());

                    // ---------------------------
                    // 1. Search Operation Span
                    // ---------------------------
                    List<ISearchResult> results;
                    using (var searchSpan = ActivitySource.StartActivity("ExecuteSearch", ActivityKind.Internal))
                    {
                        _logger.LogInformation("Executing filtered search with parameters");

                        results = _pageService.Search(viewModel.Search, viewModel.Category);

                        
                        searchSpan?.SetStatus(ActivityStatusCode.Ok);
                    }

                    // ---------------------------
                    // 2. Session Retrieval Span
                    // ---------------------------
                    bool backgroundDisabled;
                    using (var sessionSpan = ActivitySource.StartActivity("ReadSession", ActivityKind.Internal))
                    {
                        backgroundDisabled = Convert.ToBoolean(
                            HttpContext.Session.GetString("BackgroundDisabled")
                        );

                        sessionSpan?.SetTag("session.backgroundDisabled", backgroundDisabled);
                    }

                    // ---------------------------
                    // 3. ViewModel Construction Span
                    // ---------------------------
                    SearchViewModel model;
                    using (var vmSpan = ActivitySource.StartActivity("BuildViewModel", ActivityKind.Internal))
                    {
                        model = new SearchViewModel(results, backgroundDisabled, isCookieSet);
                        vmSpan?.SetTag("viewmodel.created", true);
                    }

                    activity?.SetStatus(ActivityStatusCode.Ok);
                    activity?.SetTag("search.resultCount", model.Results.Count().ToString());
                    return View(model);
                }
                catch (Exception ex)
                {
                    activity?.RecordException(ex);
                    activity?.SetStatus(ActivityStatusCode.Error);

                    _logger.LogError(ex, "Error occurred during search operation.");
                    throw new Exception("Something went wrong during the search operation.");
                }
            }
        }
    }
}