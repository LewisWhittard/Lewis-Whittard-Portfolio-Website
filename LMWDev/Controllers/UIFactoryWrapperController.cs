using Microsoft.AspNetCore.Mvc;
using UIFactory.Strategy;
using System.Collections.Generic;
using Infrastructure.Repository.Page;
using Infrastructure.Service.Page;
using SEO.Repository.AltRepository;
using SEO.Repository.MockMetaRepository;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;
using SEO.Service.MetaService;
using SEO.Repository.JsonLDRepositoryRepository;

namespace LMWDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UIFactoryStrategyWrapperController : ControllerBase
    {
        private UIFactoryStrategy _UIFactoryStrategy;
        private List<UIFactory.Factory.UIFactory> _Factories;

        public UIFactoryStrategyWrapperController()
        {
            _Factories = new List<UIFactory.Factory.UIFactory>();

            // Controller
            _Factories.Add(new UIFactory.Factory.UIFactory(new PageService(new MockPageRepository()), new JsonLDService(new MockJsonLDRepository()), new AltService(new MockAltRepository()), new MetaService(new MockMetaRepository())));

            // Ajax
            _Factories.Add(new UIFactory.Factory.UIFactory(new PageService(new MockPageRepository()), null, new AltService(new MockAltRepository()), null));

            // MauiBlazor
            _Factories.Add(new UIFactory.Factory.UIFactory(new PageService(new MockPageRepository()), null, new AltService(new MockAltRepository()), null));
        }

        [HttpGet("default/page/{PageName}")]
        public IActionResult DefaultGetByPageName(string PageName)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[0]);
            return Ok(_UIFactoryStrategy.ExecuteByPageName(PageName));
        }

        [HttpGet("default/search/{Search}")]
        public IActionResult DefaultGetBySearch(string Search)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[0]);
            return Ok(_UIFactoryStrategy.ExecuteBySearch(Search));
        }

        [HttpGet("ajax/page/{PageName}")]
        public IActionResult AjaxGetByPageName(string PageName)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[1]);
            return Ok(_UIFactoryStrategy.ExecuteByPageName(PageName));
        }

        [HttpGet("ajax/search/{Search}")]
        public IActionResult AjaxGetBySearch(string Search)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[1]);
            return Ok(_UIFactoryStrategy.ExecuteBySearch(Search));
        }

        [HttpGet("mauiblazor/page/{PageName}")]
        public IActionResult MauiBlazorGetByPageName(string PageName)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[2]);
            return Ok(_UIFactoryStrategy.ExecuteByPageName(PageName));
        }

        [HttpGet("mauiblazor/search/{Search}")]
        public IActionResult MauiBlazorGetBySearch(string Search)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[2]);
            return Ok(_UIFactoryStrategy.ExecuteBySearch(Search));
        }
    }
}
