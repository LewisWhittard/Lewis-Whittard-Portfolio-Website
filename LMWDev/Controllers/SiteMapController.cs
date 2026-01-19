using Microsoft.AspNetCore.Mvc;
using Sitemap_Library.Service.Interface;
using System.Text;

namespace LMWDev.Controllers
{
    [Route("sitemap.xml")]
    public class SitemapController : Controller
    {
        private readonly ISiteMapService _sitemapService;

        public SitemapController(ISiteMapService sitemapService)
        {
            _sitemapService = sitemapService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var xml = _sitemapService.RenderSitemap();

            return Content(xml, "application/xml", Encoding.UTF8);
        }
    }
}