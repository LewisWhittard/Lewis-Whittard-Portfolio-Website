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
			using var activity = ActivitySource.StartActivity("Index Action");
			try
			{
                string jsonLD = _jsonLDService.GenerateJsonLDHomePage();
				var viewModel = new HomeModel(Convert.ToBoolean(HttpContext.Session.GetString("BackgroundDisabled")),jsonLD);
				_logger.LogInformation("Rendering Index view");
				return View(viewModel);
			}
			catch (Exception ex)
			{
				activity?.SetStatus(ActivityStatusCode.Error);
				activity?.RecordException(ex);
				_logger.LogError(ex, "Error in Index action");
				throw;
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
