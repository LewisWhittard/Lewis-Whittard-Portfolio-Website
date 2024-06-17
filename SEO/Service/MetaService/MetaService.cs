using SEO.Model.Meta.Interface;
using SEO.Repository.MetaRepository.Interface;
using SEO.Service.MetaService.Interface;

namespace SEO.Service.MetaService
{
    public class MetaService : IMetaService
    {
        private IMetaRepository _metaRepository { get; set; }

        public MetaService(IMetaRepository metaRepository)
        {
            _metaRepository = metaRepository;
        }

        public List<MetaData> GetByPageId(int pageId, bool includeInactive)
        {
            if (includeInactive == true)
            {
                return _metaRepository.GetMetaDatas().Where(x => x.PageId == pageId && !x.Deleted).ToList();
            }

            else
            {
                return _metaRepository.GetMetaDatas().Where(x => x.PageId == pageId && !x.Deleted && !x.Inactive).ToList();
            }
        }
    }
}
