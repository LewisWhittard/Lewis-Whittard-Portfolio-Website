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

            try
            {
                _logger.LogInformation("Fetching page with ID: {Id}", id);

                var page = _pageService.GetPage(id);

                // Tag early so failures still have context
                activity?.SetTag("page.id", id);
                activity?.SetTag("pillar.route", pillar);
                activity?.SetTag("page.exists", page != null);

                if (page == null)
                {
                    activity?.SetTag("error.reason", "PageNotFound");
                    return NotFound();
                }

                // Validate page type
                if (page.PageType != "Cluster Content Page")
                {
                    activity?.SetTag("error.reason", "InvalidPageType");
                    return NotFound();
                }

                // Validate pillar/category mapping
                if (!IsValidPillarForCategory(pillar, page.Category))
                {
                    activity?.SetTag("error.reason", "PillarCategoryMismatch");
                    activity?.SetTag("page.category", page.Category);
                    return NotFound();
                }

                // Success tags
                activity?.SetTag("page.title", page.Title);
                activity?.SetTag("page.category", page.Category);

                var jsonLD = _jsonLDService.GenerateJsonLDCulsterContentPage(page);
                var viewModel = new ClusterContentModel(
                    page,
                    Convert.ToBoolean(HttpContext.Session.GetString("BackgroundDisabled")),
                    jsonLD
                );

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading ClusterContent for ID: {Id}", id);
                activity?.SetTag("error", true);
                activity?.SetTag("exception.message", ex.Message);
                throw new Exception("Something went wrong while loading the page.");
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

