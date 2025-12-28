using LMWDev.Models;
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
        private static readonly ActivitySource ActivitySource = new("LMWDev.PillarPageController");

        public PillarPageController(ILogger<PillarPageController> logger, IPageService pageService)
        {
            _logger = logger;
            try
            {
                _pageService = pageService;
                _logger.LogInformation("PageService initialized successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize PageService.");
                throw;
            }
        }

        public IActionResult Index(string id)
        {
            using var activity = new Activity("PillarPage.Index").Start();

            _logger.LogInformation("Index action started with ExternalID: {ExternalID}", id);
            activity?.AddTag("external.id", id);

            try
            {
                var page = _pageService.GetPage(id);

                if (page == null)
                {
                    _logger.LogWarning("No page found for ExternalID: {ExternalID}", id);
                    activity?.AddTag("page.found", false);
                    return NotFound();
                }

                activity?.AddTag("page.category", page.Category);
                _logger.LogInformation("Page retrieved successfully for ExternalID: {ExternalID}", id);

                var search = _pageService.Search(null, page.Category);

                _logger.LogInformation("Search completed for category: {Category}", page.Category);

                var viewModel = new PillarPageModel(page, search);

                _logger.LogInformation("Returning view for ExternalID: {ExternalID}", id);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing ExternalID: {ExternalID}", id);
                activity?.AddTag("error", true);
                activity?.AddTag("error.message", ex.Message);

                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
