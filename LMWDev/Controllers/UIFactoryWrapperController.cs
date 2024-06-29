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

        [HttpGet("{PageName}")]
        public IActionResult GetByPageNameController(string PageName)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[0]);
            return Ok(_UIFactoryStrategy.ExecuteByPageName(PageName));
        }

        [HttpGet("{Search}")]
        public IActionResult GetBySearchController(string Search)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[0]);
            return Ok(_UIFactoryStrategy.ExecuteBySearch(Search));
        }

        [HttpGet("{PageName}")]
        public IActionResult GetByPageNameAjax(string PageName)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[1]);
            return Ok(_UIFactoryStrategy.ExecuteByPageName(PageName));
        }

        [HttpGet("{Search}")]
        public IActionResult GetBySearchAjax(string Search)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[1]);
            return Ok(_UIFactoryStrategy.ExecuteBySearch(Search));
        }

        [HttpGet("{PageName}")]
        public IActionResult GetByPageNameMauiBlazor(string PageName)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[2]);
            return Ok(_UIFactoryStrategy.ExecuteByPageName(PageName));
        }

        [HttpGet("{Search}")]
        public IActionResult GetBySearchMauiBlazor(string Search)
        {
            _UIFactoryStrategy.SwitchStrategy(_Factories[2]);
            return Ok(_UIFactoryStrategy.ExecuteBySearch(Search));
        }
    }
}
