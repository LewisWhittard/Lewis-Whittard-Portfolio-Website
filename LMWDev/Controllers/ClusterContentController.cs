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
    public class ClusterContentController : Controller
    {
        private readonly IPageService _pageService;
        private readonly IJsonLDService _jsonLDService;
        private readonly ILogger<ClusterContentController> _logger;
        private static readonly ActivitySource ActivitySource = new("LMWDev.ClusterContentController");

        public ClusterContentController(ILogger<ClusterContentController> logger, IPageService pageService, IJsonLDService jsonLDService)
        {
            _logger = logger;
            try
            {
                _pageService = pageService;
                _jsonLDService = jsonLDService;
                _logger.LogInformation("PageService initialized successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize PageService.");
                throw;
            }
        }

        [Route("{pillar:regex(^(software-development|creative-works|intersections)$)}/{id}")]
        public IActionResult Index(string pillar, string id)
        {
            using var activity = ActivitySource.StartActivity("ClusterContentController.Index");
            {

                try
                {
                    _logger.LogInformation("Fetching page with ID: {Id}", id);

                    // Fetch page
                    using (var fetchPageSpan = ActivitySource.StartActivity("FetchPage"))
                    {
                        fetchPageSpan?.SetTag("page.id", id);
                        var page = _pageService.GetPage(id);

                        activity?.SetTag("page.id", id);
                        activity?.SetTag("pillar.route", pillar);
                        activity?.SetTag("page.exists", page != null);

                        if (page == null)
                        {
                            activity?.SetTag("error.reason", "PageNotFound");
                            return NotFound();
                        }

                        // Validate page type
                        using (var validateTypeSpan = ActivitySource.StartActivity("ValidatePageType"))
                        {
                            validateTypeSpan?.SetTag("page.type", page.PageType);

                            if (page.PageType != "Cluster Content Page")
                            {
                                activity?.SetTag("error.reason", "InvalidPageType");
                                return NotFound();
                            }
                        }

                        // Validate pillar/category mapping
                        using (var validatePillarSpan = ActivitySource.StartActivity("ValidatePillarCategory"))
                        {
                            validatePillarSpan?.SetTag("page.category", page.Category);

                            if (!IsValidPillarForCategory(pillar, page.Category))
                            {
                                activity?.SetTag("error.reason", "PillarCategoryMismatch");
                                activity?.SetTag("page.category", page.Category);
                                return NotFound();
                            }
                        }

                        // Success tags
                        activity?.SetTag("page.title", page.Title);
                        activity?.SetTag("page.category", page.Category);

                        // Generate JSON-LD
                        string jsonLD;
                        using (var jsonLdSpan = ActivitySource.StartActivity("GenerateJsonLD"))
                        {
                            jsonLdSpan?.SetTag("page.id", page.ExternalId);
                            jsonLD = _jsonLDService.GenerateJsonLDCulsterContentPage(page);
                        }

                        // Build view model
                        ClusterContentModel viewModel;
                        using (var viewModelSpan = ActivitySource.StartActivity("BuildViewModel"))
                        {
                            viewModel = new ClusterContentModel(
                                page,
                                Convert.ToBoolean(HttpContext.Session.GetString("BackgroundDisabled")),
                                jsonLD
                            );
                        }

                        return View(viewModel);
                    }
                }
                catch (Exception ex)
                {
                    activity?.SetTag("error", true);
                    activity?.SetTag("exception.message", ex.Message);
                    activity?.SetTag("exception.stacktrace", ex.StackTrace);
                    throw;
                }
            }
        }

        private bool IsValidPillarForCategory(string pillar, string category)
        {
            return category switch
            {
                "Software Development" => pillar == "software-development",
                "Creative Works" => pillar == "creative-works",
                _ when category.Contains(",") => pillar == "intersections",
                _ => false
            };
        }
    }
}

