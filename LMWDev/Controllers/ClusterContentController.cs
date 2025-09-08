using Microsoft.AspNetCore.Mvc;
using Page_Library.Page.Service.Interface;
using Page_Library.Page.Service;
using Page_Library.Page.Repository;
using Page_Library.Page.Factory;
using Page_Library.Content.Repository;
using LMWDev.Models;

namespace LMWDev.Controllers
{
	public class ClusterContentController : Controller
	{
		private readonly IPageService Page;

        public ClusterContentController()
        {
			Page = new PageService(new JsonPageRepository(@"./Json/Page/Page.json"), new ContentBlockFactory(), new JsonContentRepository(@"./Json/Content/Content.json"));
        }

        public IActionResult Index(int Id)
		{
			var page = Page.GetPage(Id);

            ClusterContentModel viewModel = new ClusterContentModel(page);

			return View(viewModel);
		}
	}
}
