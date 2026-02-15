using Microsoft.AspNetCore.Http;
using Page_Library.Page.Entities.Page.Interface;

namespace JsonLD_Library.Service.Interface
{
    public interface IJsonLDService
    {
        public string GenerateJsonLDCulsterContentPage(IHttpContextAccessor http, IPage page);
    }
}
