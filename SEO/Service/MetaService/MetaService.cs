using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;
using SEO.Models.Meta.Interface;
using SEO.Service.MetaService.Interface;

namespace SEO.Service.JsonLDService
{
    public class MetaService : IMetaService
    {
        public List<IMeta> GetBySuperClassGUID(IData data)
        {
            return new List<IMeta>();
        }
    }
}
