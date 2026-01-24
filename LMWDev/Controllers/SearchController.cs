using LMWDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Page_Library.Page.Service.Interface;
using System;
using System.Diagnostics;

namespace LMWDev.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPageService _pageService;
        private readonly ILogger<SearchController> _logger;
        private static readonly ActivitySource ActivitySource = new("LMWDev.SearchController");

        public SearchController(IPageService pageService,ILogger<SearchController> logger)
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
            using var activity = ActivitySource.StartActivity("SearchController.Index");
            {
                try
                {
                    SearchViewModel model; 
                    _logger.LogInformation($"Executing filtered search with parameters", viewModel);
                    model = new SearchViewModel(_pageService.Search(viewModel.Search,viewModel.Category), Convert.ToBoolean(HttpContext.Session.GetString("BackgroundDisabled")));
                    return View(model);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred during search operation."); throw new Exception("Something went wrong during the search operation.");
                }
            }
        }
	}
}