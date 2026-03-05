using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using StaticPageGenerator_Library.Service.Base;

namespace StaticPageGenerator_Library.Service
{
    public class ViewRenderService : ViewRenderServiceBase
    {
        public ViewRenderService(IRazorViewEngine viewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider) : base(viewEngine, tempDataProvider, serviceProvider)
        {
        }
    }
}