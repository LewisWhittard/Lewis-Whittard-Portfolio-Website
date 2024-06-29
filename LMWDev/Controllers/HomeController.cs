using Infrastructure.Repository.Page;
using Infrastructure.Service.Page;
using LMWDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEO.Repository.AltRepository;
using SEO.Repository.MockMetaRepository;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;
using SEO.Service.MetaService;
using System.Collections.Generic;
using System.Diagnostics;
using UIFactory.Factory.CSHTML;
using UIFactory.Factory.Interface;
using UIFactory.Strategy;
using UIFactory.Strategy.Interface;

namespace LMWDev.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUIFactoryStrategy _uIFactoryStrategy;
        public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			_uIFactoryStrategy = new UIFactoryStrategy(new UIFactory.Factory.UIFactory(new PageService(new MockPageRepository()), new JsonLDService(), new AltService(new MockAltRepository()), new MetaService(new MockMetaRepository())));
        }

		public IActionResult Index()
		{

			return View(null);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
