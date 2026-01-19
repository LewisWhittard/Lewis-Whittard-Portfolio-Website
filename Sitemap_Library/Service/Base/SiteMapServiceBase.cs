using Microsoft.AspNetCore.Http;
using Page_Library.Page.Repository.Interface;
using Sitemap_Library.Service.Interface;

namespace Sitemap_Library.Service.Base
{
    public abstract class SiteMapServiceBase : ISiteMapService
    {
        private protected readonly IPageRepository _pageRepository;
        private protected readonly string _baseUrl;

        public SiteMapServiceBase(IPageRepository pageRepository, IHttpContextAccessor http)
        {
            _pageRepository = pageRepository;
            var request = http.HttpContext?.Request;

            _baseUrl = request == null
                ? string.Empty
                : $"{request.Scheme}://{request.Host}";
        }

        public abstract string RenderSitemap();
    }
}

