using SEO.Models.Meta.Interface;
using SEO.Service.MetaService.Interface;

namespace SEO.Service.JsonLDService
{
    public class MetaService : IMetaService
    {
        public List<IMetaData> GetByPageName(string data)
        {
            return new List<IMetaData>();
        }
    }
}
