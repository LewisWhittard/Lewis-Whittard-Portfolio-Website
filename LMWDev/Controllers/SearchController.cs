using Microsoft.AspNetCore.Mvc;
using LMWDev.Models;
using Page_Library.Search.Service;
using Page_Library.Search.Repository;
using Page_Library.Content.Repository;

namespace LMWDev.Controllers
{
	public class SearchController : Controller
	{
		private readonly  PageSearchService _pageSearchService;

        public SearchController()
        {
			_pageSearchService = new PageSearchService(new JsonPageSearchRepository(@"./Json/Search/Search.json"),new JsonContentRepository(@"./Json/Content/Content.json"));
        }

        public IActionResult Index()
		{
			var results = _pageSearchService.Search();

			SearchViewModel model = new SearchViewModel(results);
			

			return View(model);
		}

		public IActionResult Modified(SearchViewModel search)
		{

			return View(null);
		}
	}
}
