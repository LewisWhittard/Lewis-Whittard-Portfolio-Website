using SEO.Models.JsonLD.Interface;

namespace SEO.Service.JsonLDService.Interface
{
    public interface IJsonLDService
    {
        public List<IJsonLDData> Get(string PageName);
    }
}
