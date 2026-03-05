using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using StaticPageGenerator_Library.Service.Base;
using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace StaticPageGenerator_Library.Service
{
    public class ViewRenderService : ViewRenderServiceBase
    {
        public ViewRenderService(IRazorViewEngine viewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider) : base(viewEngine, tempDataProvider, serviceProvider)
        {
        }
    }
}