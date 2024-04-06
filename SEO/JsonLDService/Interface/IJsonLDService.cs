using SEO.Models.JsonLD.Interface;

namespace SEO.JsonLDService.Interface
{
    public interface IJsonLDService
    {
        public List<IJsonLDData> Get(string PageName);
    }
}
