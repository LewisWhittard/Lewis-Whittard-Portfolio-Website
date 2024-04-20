using Infrastructure.Repository.Page;
using Infrastructure.Service.Page;
using LMWDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;
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
			_uIFactoryStrategy = new UIFactoryStrategy(new CSHTMLFactory(new PageService(new MockPageRepository()), new JsonLDService(), new AltService(), new MetaService()));
        }

		public IActionResult Index()
		{
			List<IUI> uIs = (List<IUI>)_uIFactoryStrategy.ExecuteByPageName("HomePage");
			HomeModel ViewModel = new HomeModel(false,uIs);
			return View(ViewModel);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
