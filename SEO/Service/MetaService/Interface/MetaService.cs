using SEO.Models.Meta.Interface;

namespace SEO.Service.MetaService.Interface
{
    public interface IMetaService
    {
        public List<MetaData> GetByPageId(int pageId, bool includeInactive);
    }
}
