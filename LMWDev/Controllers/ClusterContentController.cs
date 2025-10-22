using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Page_Library.Page.Service.Interface;
using LMWDev.Models;
using System.Diagnostics;
using System;

namespace LMWDev.Controllers
{
    public class ClusterContentController : Controller
    {
        private readonly IPageService _pageService;
        private readonly ILogger<ClusterContentController> _logger;
        private static readonly ActivitySource ActivitySource = new("LMWDev.ClusterContentController");

        public ClusterContentController(ILogger<ClusterContentController> logger, IPageService pageService)
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
            using var activity = ActivitySource.StartActivity("ClusterContentController.Index");
            try
            {
                _logger.LogInformation("Fetching page with ID: {Id}", id);
                var page = _pageService.GetPage(id);
                activity?.SetTag("page.id", id);
                activity?.SetTag("page.title", page?.Title);

                var viewModel = new ClusterContentModel(page);
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
    }
}

