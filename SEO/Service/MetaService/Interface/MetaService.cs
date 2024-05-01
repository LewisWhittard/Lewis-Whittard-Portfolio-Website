using SEO.Models.Meta.Interface;

namespace SEO.Service.MetaService.Interface
{
    public interface IMetaService
    {
        public List<MetaData> GetByPageName(string pageName, bool includeInactive);
    }
}
