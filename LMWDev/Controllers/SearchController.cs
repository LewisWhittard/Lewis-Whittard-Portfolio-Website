using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LMWDev.Models;
using Page_Library.Search.Service;
using Page_Library.Search.Repository;
using Page_Library.Content.Repository;
using System.Diagnostics;
using System;
using DocumentFormat.OpenXml.Drawing.Diagrams;
namespace LMWDev.Controllers
{
    public class SearchController : Controller
    {
        private readonly PageSearchService _pageSearchService;
        private readonly ILogger<SearchController> _logger;
        private static readonly ActivitySource ActivitySource = new("LMWDev.SearchController");

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
            try
            {
                _pageSearchService = new PageSearchService(new JsonPageSearchRepository(@"./Json/Search/Search.json"), new JsonContentRepository(@"./Json/Content/Content.json"));
                _logger.LogInformation("PageSearchService initialized successfully.");
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
                    SearchViewModel model; if (string.IsNullOrWhiteSpace(viewModel?.Search))
                    {
                        _logger.LogInformation("Executing default search.");
                        model = new SearchViewModel(_pageSearchService.Search());
                    }
                    else
                    {
                        _logger.LogInformation($"Executing filtered search with parameters", viewModel);
                        model = new SearchViewModel(_pageSearchService.Search(viewModel.Search, viewModel.ProgrammingCategory, viewModel.TestingCategory, viewModel.GamesCategory, viewModel.ThreeDAssetsCategory, viewModel.TwoDAssetCategory, viewModel.BlogCategory));
                    }
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