using SEO.Models.JsonLD;

namespace SEO.Repository.JsonLDRepository.Interface
{
    public interface IJsonLDRepository
    {
        public List<JsonLDData> GetJsonLDs();
    }
}
