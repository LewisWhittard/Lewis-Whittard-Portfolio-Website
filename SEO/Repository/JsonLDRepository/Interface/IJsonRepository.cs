using SEO.Model.JsonLD;

namespace SEO.Repository.JsonLDRepository.Interface
{
    public interface IJsonLDRepository
    {
        public List<JsonLDData> GetJsonLDDatas();
    }
}
