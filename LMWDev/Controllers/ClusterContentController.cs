using LMWDev.SpreadsheetConnection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMWDev.Models;
using Page_Library.Page.Service.Interface;
using Page_Library.Page.Service;
using Page_Library.Page.Repository;
using Page_Library.Page.Factory;
using Page_Library.Content.Repository;

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
			Page.GetPage(Id);
			return View(null);
		}
	}
}
