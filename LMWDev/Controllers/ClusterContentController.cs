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

        [Route("{pillar:regex(^(software-development|creative-works|intersections)$)}/{id}")]
        public IActionResult Index(string pillar,string id)
        {
            using var activity = ActivitySource.StartActivity("ClusterContentController.Index");
            try
            {
                _logger.LogInformation("Fetching page with ID: {Id}", id);
                var page = _pageService.GetPage(id);

                if (page == null)
                {
                    return NotFound();
                }

                
                else if (page.Category == "Software Development")
                {
                    if (pillar != "software-development")
                    {
                        return NotFound();
                    }
                }
                else if (page.Category == "Creative Works")
                {
                    if (pillar != "creative-works")
                    {
                        return NotFound();
                    }
                }
                else if (page.Category.Contains(","))
                {
                    if (pillar == "software-development")
                    {
                        return NotFound();
                    }

                    else if (pillar == "creative-works")
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }

                if (page.PageType != "Cluster Content Page")
                {
                    return NotFound();
                }

                activity?.SetTag("page.id", id);
                activity?.SetTag("page.title", page?.Title);

                var viewModel = new ClusterContentModel(page, Convert.ToBoolean(HttpContext.Session.GetString("BackgroundDisabled")));
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

