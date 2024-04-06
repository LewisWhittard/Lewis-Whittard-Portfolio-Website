using SEO.Models.JsonLD.Interface;

namespace SEO.Service.JsonLDService.Interface
{
    public interface IJsonLDService
    {
        public List<IJsonLDData> GetByPageName(string PageName);
    }
}
