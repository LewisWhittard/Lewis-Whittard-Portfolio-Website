using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;

namespace SEO.Service.JsonLDService.Interface
{
    public interface IJsonLDService
    {
        public List<IJsonLDData> GetByPageName(string PageName);
        public List<IJsonLDData> GetByPageName(string PageName,IData idata);

    }
}
