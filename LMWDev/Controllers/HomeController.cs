using JsonLD_Library.Service;
using JsonLD_Library.Service.Interface;
using LMWDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using System;
using System.Diagnostics;

namespace LMWDev.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private static readonly ActivitySource ActivitySource = new ActivitySource("LMWDev.HomeController");
		private readonly IJsonLDService _jsonLDService;

		public HomeController(ILogger<HomeController> logger, IJsonLDService jsonLDService)
		{
			_jsonLDService = jsonLDService;
			_logger = logger;
		}

        public IActionResult Index()
        {
            using var activity = ActivitySource.StartActivity("HomeController.Index", ActivityKind.Server);
            {
                try
                {
                    activity?.SetTag("page.type", "HomePage");

                    // NEW: Add session ID to the root activity
                    var sessionId = HttpContext.Session.Id;
                    activity?.SetTag("session.id", sessionId);
                    activity?.AddEvent(new ActivityEvent("session.id.captured",
                    tags: new ActivityTagsCollection { { "session.id", sessionId } }));

                    // ---------------------------
                    // 1. JSON-LD Generation Span
                    // ---------------------------
                    string jsonLD;
                    using (var jsonSpan = ActivitySource.StartActivity("GenerateJsonLD", ActivityKind.Internal))
                    {
                        jsonLD = _jsonLDService.GenerateJsonLDHomePage();
                        jsonSpan?.SetTag("jsonld.generated", jsonLD != null);
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
                    HomeModel viewModel;
                    using (var vmSpan = ActivitySource.StartActivity("BuildViewModel", ActivityKind.Internal))
                    {
                        viewModel = new HomeModel(backgroundDisabled, jsonLD);
                        vmSpan?.SetTag("viewmodel.created", true);
                    }

                    activity?.SetStatus(ActivityStatusCode.Ok);
                    _logger.LogInformation("Rendering Home/Index");

                    return View(viewModel);
                }
                catch (Exception ex)
                {
                    activity?.RecordException(ex);
                    activity?.SetStatus(ActivityStatusCode.Error);

                    _logger.LogError(ex, "Error in HomeController.Index");
                    throw;
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			using var activity = ActivitySource.StartActivity("Error Action");
			var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
			_logger.LogWarning("Rendering Error view with RequestId: {RequestId}", requestId);
			return View(new ErrorViewModel { RequestId = requestId });
		}
	}
}
