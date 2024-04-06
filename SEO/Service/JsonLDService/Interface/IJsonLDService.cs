using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;

namespace SEO.Service.JsonLDService.Interface
{
    public interface IJsonLDService
    {
        public List<IJsonLDData> GetByPageName(string pageName);
        public List<IJsonLDData> GetByPageName(string pageName, IData data);

    }
}
