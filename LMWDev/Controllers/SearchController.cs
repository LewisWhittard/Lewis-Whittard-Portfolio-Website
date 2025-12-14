using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LMWDev.Models;
using System.Diagnostics;
using System;
using Page_Library.Search.Service.Interface;
using Page_Library.Page.Service.Interface;

namespace LMWDev.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPageService _pageService;
        private readonly ILogger<SearchController> _logger;
        private static readonly ActivitySource ActivitySource = new("LMWDev.SearchController");

        public SearchController(IPageService pageSearchService,ILogger<SearchController> logger)
        {
            _logger = logger;
            try
            {
                _pageSearchService = pageSearchService;
                _logger.LogInformation("Page Service initialized successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize PageSearchService.");
                throw;
            }
        }

        public IActionResult Index(SearchViewModel viewModel)
        {
            using var activity = ActivitySource.StartActivity("SearchController.Index");
            {
                try
                {
                    SearchViewModel model; 
                    _logger.LogInformation($"Executing filtered search with parameters", viewModel);
                    model = new SearchViewModel(_pageService.Search(viewModel.Search,viewModel.Category));
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